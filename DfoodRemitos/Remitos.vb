Imports MySql.Data.MySqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Drawing.Printing
Imports Microsoft.Reporting.WinForms
Imports System.IO

Public Class Remitos

    Public id As String
    Public Nuevo As Boolean
    Public idcliente As Integer
    Public idcomprobante As Integer
    Dim ModificandoArticulo As Boolean
    Dim idart As Single
    Dim idArticuloSeleccionado As Integer
    Dim Desdecodigo As Boolean = False
    Declare Function SetDefaultPrinter Lib "winspool.drv" Alias "SetDefaultPrinterA" (ByVal pszPrinter As String) As Boolean
    Private Declare Function ShellExecute Lib "shell32.dll" Alias "ShellExecuteA" (ByVal hwnd As Long, ByVal lpOperation As String, ByVal lpFile As String, ByVal lpParameters As String, ByVal lpDirectory As String, ByVal nShowCmd As Long) As Long

    Private Sub Remitos_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        InitForm(Me)
        If Nuevo Then
            dtpFecha.Value = Date.Now
        End If

        CargaCombo("tipocomprobante", "nombre", "id", cboTipoComprobante, False, "id = 99")
        CargaCombo("Clientes", "nombre", "nombre", cboCliente)
        CargaCombo("articulos", "DESCRIPCION", "codigo", cboArticulo)
        CargaCombo("tiporesponsable", "NOMBRE", "id", cboSitIva)
        txtCodCliente.Text = ""
        txtCodArt.Text = ""
        cboCliente.SelectedIndex = -1
        cboArticulo.SelectedIndex = -1
        cboSitIva.SelectedIndex = -1

        If Nuevo Then
            cboTipoComprobante.SelectedIndex = 0
        Else
            cboTipoComprobante.Text = Getdata(idcomprobante, "nombre", "tipocomprobante")
            cboCliente.Text = Getdata(idcliente, "nombre", "clientes")
            txtNumComprobante.Enabled = False
        End If

        'Borra comprobantes temporales no guardados
        Try
            SQL = "DELETE FROM Remitosd WHERE idremito = " & nTmp
            Dim comando As New MySqlCommand(SQL, conexion)
            comando.ExecuteNonQuery()
            comando.Dispose()

        Catch ex As Exception
            CatchError(ex.Message, ex.StackTrace, SQL)
            End

        End Try

        Cargar()

    End Sub

    Sub Cargar()

        txtTotal.Text = "0,00"

        If Nuevo Then
            cmdImprimir.Enabled = False
            CmdGuardar.Enabled = True
        Else
            CmdGuardar.Enabled = True
            cmdImprimir.Enabled = True
        End If

        Flex.DataSource = Nothing

        SQL = "SELECT v.id, v.idremito, v.idart, a.codigo, v.art, v.cantidad "
        SQL &= "FROM Remitosd AS v "
        SQL &= "Left Join articulos AS a ON v.idart = a.id WHERE v.idremito = " & id & " ORDER BY v.id ASC"

        Dim unused As New MySqlDataAdapter
        Dim dt As DataSet

        DoubleBufferedASD(Flex, True)

        Try
            Dim da As MySqlDataAdapter = New MySqlDataAdapter(SQL, conexion)
            dt = New DataSet
            da.Fill(dt, "Remitos")
            Flex.DataSource = dt
            Flex.DataMember = "Remitos"
            da.Dispose()

        Catch ex As Exception
            CatchError(ex.Message, ex.StackTrace, SQL)
            End

        End Try
        unused.Dispose()

        OrdenaFlex()

        Dim total As Double = 0
        For i = 0 To Flex.RowCount - 1
            total += CDec(Flex.Rows(i).Cells(5).Value)
        Next

        txtTotal.Text = Format(total, "0.00")

    End Sub

    Sub OrdenaFlex()

        Flex.Columns(0).HeaderText = "id"
        Flex.Columns(0).Visible = False
        Flex.Columns(1).HeaderText = "idremito"
        Flex.Columns(1).Visible = False
        Flex.Columns(2).HeaderText = "idart"
        Flex.Columns(2).Visible = False
        Flex.Columns(3).HeaderText = "Código"
        Flex.Columns(3).Width = 70
        Flex.Columns(4).HeaderText = "Artículo"
        Flex.Columns(4).Width = 500
        Flex.Columns(5).HeaderText = "Cantidad"
        Flex.Columns(5).Width = 100

    End Sub

    Sub Add()

        Dim SubTotal As Double

        If txtCodArt.Text = "" Then
            txtCodArt.Focus()
            Exit Sub
        ElseIf txtCantidad.Text = "" Then
            txtCantidad.Focus()
            Exit Sub
        End If

        If txtCantidad.Text = "0" Then
            Select Case MsgBox("¿Desea eliminar el item " & Flex.CurrentRow.Cells(3).Value & "?", vbYesNo Or vbExclamation Or vbDefaultButton1)
                Case vbNo : Exit Sub
            End Select

            ModificandoArticulo = False

            SQL = "DELETE FROM Remitosd WHERE id = " & idArticuloSeleccionado
            Try
                Dim comando As New MySqlCommand(SQL, conexion)
                comando.ExecuteNonQuery()
                MsgBox("Eliminado")
                comando.Dispose()

            Catch ex As Exception
                CatchError(ex.Message, ex.StackTrace, SQL)
                End

            End Try

            Cargar()

            'Vaciar Box
            txtCodArt.Text = ""
            cboArticulo.Text = ""
            txtCantidad.Text = ""
            txtCodArt.Focus()

            Exit Sub
        End If

        SubTotal = CDec(txtCantidad.Text)

        'Guardar
        If ModificandoArticulo Then
            SQL = "UPDATE Remitosd SET idremito = @idremito, idart = @idart, art = @art, cantidad = @cantidad WHERE id = " & idArticuloSeleccionado
        Else
            SQL = "INSERT INTO Remitosd (idremito, idart, art, cantidad) "
            SQL &= "VALUES (@idremito, @idart, @art, @cantidad)"
        End If

        Try
            Dim comando = New MySqlCommand(SQL, conexion) With {
                .CommandType = CommandType.Text
            }
            comando.Parameters.AddWithValue("@idremito", id)
            comando.Parameters.AddWithValue("@idart", idart)
            If cboArticulo.Visible = True Then
                comando.Parameters.AddWithValue("@art", cboArticulo.Text)
            ElseIf txtArticulo.Visible = True Then
                comando.Parameters.AddWithValue("@art", txtArticulo.Text)
            End If
            comando.Parameters.AddWithValue("@cantidad", txtCantidad.Text)
            comando.ExecuteNonQuery()
            comando.Dispose()

        Catch ex As Exception
            CatchError(ex.Message, ex.StackTrace, SQL)
            End

        End Try

        Cargar()

        idArticuloSeleccionado = 0
        ModificandoArticulo = False
        idart = 0
        txtCodArt.Text = ""
        cboArticulo.Text = ""
        txtCantidad.Text = ""
        txtCodArt.Focus()

    End Sub

    Private Sub CmdGuardar_Click(sender As Object, e As EventArgs) Handles CmdGuardar.Click

        If txtTotal.Text = "0,00" Then Exit Sub

        If cboTipoComprobante.SelectedIndex = -1 Then
            Call MsgBox("Debe especificar el tipo de comprobante.    ", vbExclamation)
            cboTipoComprobante.Focus()
            Exit Sub
        End If

        Select Case MsgBox("¿DESEA GUARDAR EL COMPROBANTE?", vbYesNo Or vbQuestion Or vbDefaultButton2)
            Case vbNo : Exit Sub
        End Select

        'Guardo
        If Nuevo Then
            SQL = "INSERT INTO Remitos (idtipocomprobante, ptoventa, numerocomprobante, idcliente, fecha, cantidadtotal) "
            SQL &= "VALUES (@idtipocomprobante, @ptoventa, @numerocomprobante, @idcliente, @fecha, @cantidadtotal) "
        Else
            SQL = "UPDATE Remitos SET idtipocomprobante = @idtipocomprobante, ptoventa = @ptoventa, numerocomprobante = @numerocomprobante, "
            SQL &= "idcliente = @idcliente, fecha = @fecha, cantidadtotal = @cantidadtotal WHERE id = " & id
        End If

        Try
            Dim comando = New MySqlCommand(SQL, conexion) With {
                .CommandType = CommandType.Text
            }
            comando.Parameters.AddWithValue("@idtipocomprobante", cboTipoComprobante.SelectedItem(0))
            comando.Parameters.AddWithValue("@ptoventa", cboPtoVenta.Text)
            comando.Parameters.AddWithValue("@numerocomprobante", txtNumComprobante.Text)
            comando.Parameters.AddWithValue("@idcliente", cboCliente.SelectedItem(0))
            comando.Parameters.AddWithValue("@fecha", Format(dtpFecha.Value, "yyyy-MM-dd"))
            comando.Parameters.AddWithValue("@cantidadtotal", txtTotal.Text)

            comando.ExecuteNonQuery()
            comando.Dispose()

        Catch ex As Exception
            CatchError(ex.Message, ex.StackTrace, SQL)
            End

        End Try

        'Obtengo nuevo ID.
        Try
            SQL = "SELECT id FROM Remitos WHERE numerocomprobante = " & txtNumComprobante.Text & " AND ptoventa = " & cboPtoVenta.Text
            Dim comando As New MySqlCommand(SQL, conexion)
            Dim rsID As MySqlDataReader

            rsID = comando.ExecuteReader
            If rsID.Read Then
                id = rsID("id")
            End If

            rsID.Close()
            comando.Dispose()

        Catch ex As Exception
            CatchError(ex.Message, ex.StackTrace, SQL)
            End

        End Try

        'Asigno nuevo ID a Tablas relacionadas.
        Try
            SQL = "UPDATE Remitosd SET idremito = " & id & " WHERE idremito = " & nTmp
            Dim comando As New MySqlCommand(SQL, conexion)
            comando.ExecuteNonQuery()
            comando.Dispose()

        Catch ex As Exception
            CatchError(ex.Message, ex.StackTrace, SQL)
            End

        End Try

        'Actualizo Indices
        If Nuevo Then
            Try
                SQL = "UPDATE indices SET ultimocomprobante = " & CInt(txtNumComprobante.Text) & " WHERE puntoventa = " & cboPtoVenta.Text & " AND idtipocomprobante = " & cboTipoComprobante.SelectedItem(0)
                Dim comando As New MySqlCommand(SQL, conexion)
                comando.ExecuteNonQuery()
                comando.Dispose()

            Catch ex As Exception
                CatchError(ex.Message, ex.StackTrace, SQL)
                End

            End Try
        End If

        Nuevo = False

        Cargar()

    End Sub

    Private Sub cboCliente_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCliente.SelectedIndexChanged

        If cboCliente.SelectedIndex <> -1 And Not Desdecodigo Then
            txtCodCliente.Text = Getdata(cboCliente.SelectedItem(0), "codigo", "clientes")
        End If

    End Sub

    Sub CargarNumero()

        SQL = "SELECT ultimocomprobante FROM indices WHERE idtipocomprobante = " & cboTipoComprobante.SelectedItem(0) & " AND puntoventa = " & cboPtoVenta.Text
        Try
            Dim comando As New MySqlCommand(SQL, conexion)
            Dim rsNumero As MySqlDataReader

            rsNumero = comando.ExecuteReader
            If rsNumero.Read Then
                txtNumComprobante.Text = Format(CInt(rsNumero("ultimocomprobante")) + 1, "00000000")
            End If
            rsNumero.Close()
            comando.Dispose()

        Catch ex As Exception
            CatchError(ex.Message, ex.StackTrace, SQL)
            End

        End Try

        txtNumComprobante.Enabled = False
        txtNumComprobante.Text.PadLeft(8, "0")

    End Sub

    Private Sub cboTipoComprobante_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboTipoComprobante.KeyPress

        If e.KeyChar = vbCr Then
            PasarFoco()
        End If

    End Sub

    Private Sub cmdSalir_Click(sender As Object, e As EventArgs) Handles cmdSalir.Click

        id = nTmp
        Nuevo = True
        ModificandoArticulo = False

        RemitosList.Show()
        Me.Close()

    End Sub

    Private Sub cboArticulo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboArticulo.KeyPress

        If e.KeyChar = vbCr Then
            PasarFoco()
        End If

    End Sub

    Private Sub cboCliente_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboCliente.KeyPress

        If e.KeyChar = vbCr Then
            PasarFoco()
        End If

    End Sub

    Private Sub Flex_Click(sender As Object, e As EventArgs) Handles Flex.Click

        If Flex.RowCount = 0 Then
            Exit Sub
        End If

        If IsNothing(Flex.CurrentRow.Cells(0).Value) Then
            Exit Sub
        End If

        ModificandoArticulo = True
        idArticuloSeleccionado = Flex.CurrentRow.Cells(0).Value
        txtCodArt.Text = Flex.CurrentRow.Cells(3).Value
        cboArticulo.Text = Flex.CurrentRow.Cells(4).Value
        txtCantidad.Text = Flex.CurrentRow.Cells(5).Value
        txtCantidad.Focus()

    End Sub

    Private Sub txtCantidad_GotFocus(sender As Object, e As EventArgs) Handles txtCantidad.GotFocus

        txtCantidad.SelectionStart = 0
        txtCantidad.SelectionLength = Len(txtCantidad.Text)

    End Sub

    Private Sub txtCantidad_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCantidad.KeyPress

        If e.KeyChar = vbCr Then
            Add()
        Else
            If e.KeyChar = "." Then
                e.KeyChar = ","
            End If
            e.KeyChar = CambiaPunto(txtCantidad.Text, e.KeyChar)
        End If

    End Sub

    Private Sub txtCodArt_TextChanged(sender As Object, e As EventArgs) Handles txtCodArt.TextChanged

        If txtCodArt.Text = "0" Then
            cboArticulo.SelectedIndex = -1
            cboArticulo.Visible = False
            txtArticulo.Visible = True
        Else
            cboArticulo.Visible = True
            txtArticulo.Visible = False
            txtArticulo.Text = ""
        End If

        SQL = "SELECT id, codigo, descripcion FROM articulos WHERE codigo = '" & txtCodArt.Text & "' and eliminado = 0"
        Try
            Dim comando As New MySqlCommand(SQL, conexion)
            Dim rsCargar As MySqlDataReader

            rsCargar = comando.ExecuteReader
            If rsCargar.Read Then
                idart = rsCargar("id")
                cboArticulo.Text = rsCargar("descripcion").ToString
            Else
                cboArticulo.SelectedIndex = -1
                idart = -1
            End If

            rsCargar.Close()
            comando.Dispose()

        Catch ex As Exception
            CatchError(ex.Message, ex.StackTrace, SQL)
            End

        End Try

    End Sub

    Function EsComprobanteA()

        If cboSitIva.Text = "IVA Responsable Inscripto" Then
            Return True
        Else
            Return False
        End If

    End Function

    Private Sub txtCodArt_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCodArt.KeyPress

        If e.KeyChar = vbCr Then
            If cboArticulo.Text = "" And txtCodArt.Text = "" Then
                ArticulosList.entrada = "REMITO"
                'ArticulosList.WindowState = 0
                'ArticulosList.FormBorderStyle = 1
                ArticulosList.Height = zmain.Height - 70
                ArticulosList.frmBotones.Visible = False
                ArticulosList.txtBuscar.Text = txtCodArt.Text
                ArticulosList.txtBuscar.SelectionStart = Len(txtCodArt.Text)
                ArticulosList.Show()
                ArticulosList.Cargar()
                ArticulosList.txtBuscar.Focus()
            Else
                PasarFoco()
            End If
        End If

    End Sub

    Private Sub txtCodCliente_TextChanged(sender As Object, e As EventArgs) Handles txtCodCliente.TextChanged

        If txtCodCliente.Text = "" Then
            cboCliente.SelectedIndex = -1
            cboSitIva.SelectedIndex = -1
            txtDireccion.Text = ""
            txtNumeroDocumento.Text = ""
            Exit Sub
        End If

        SQL = "SELECT id, codigo, nombre, numerodocumento, direccion, idtiporesponsable FROM clientes WHERE codigo = " & txtCodCliente.Text & " AND eliminado = 0 "
        Try
            Dim comando As New MySqlCommand(SQL, conexion)
            Dim rsCliente As MySqlDataReader

            rsCliente = comando.ExecuteReader
            If rsCliente.Read Then
                Desdecodigo = True
                cboCliente.Text = rsCliente("nombre").ToString
                txtNumeroDocumento.Text = rsCliente("numerodocumento").ToString
                txtDireccion.Text = rsCliente("direccion").ToString
                cboSitIva.Text = Getdata(rsCliente("idtiporesponsable"), "nombre", "tiporesponsable")
            Else
                cboCliente.SelectedIndex = -1
                cboSitIva.SelectedIndex = -1
                txtDireccion.Text = ""
                txtNumeroDocumento.Text = ""
            End If

            Desdecodigo = False
            rsCliente.Close()
            comando.Dispose()

        Catch ex As Exception
            CatchError(ex.Message, ex.StackTrace, SQL)
            End

        End Try

        txtCodCliente.SelectionStart = Len(txtCodCliente.Text)

    End Sub

    Private Sub txtCodCliente_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCodCliente.KeyPress

        If e.KeyChar = vbCr Then
            PasarFoco()
        Else
            e.Handled = SoloEnteros(Asc(e.KeyChar))
        End If

    End Sub

    Private Sub txtDireccion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDireccion.KeyPress

        If e.KeyChar = vbCr Then
            PasarFoco()
        End If

    End Sub

    Private Sub txtNumeroDocumento_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNumeroDocumento.KeyPress

        If e.KeyChar = vbCr Then
            PasarFoco()
        End If

    End Sub

    Private Sub cboCliente_Click(sender As Object, e As EventArgs) Handles cboCliente.Click

        If cboCliente.SelectedIndex <> -1 Then
            txtCodCliente.Text = Getdata(cboCliente.SelectedItem(0), "codigo", "clientes")
        End If

    End Sub

    Private Sub txtNumComprobante_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNumComprobante.KeyPress

        If e.KeyChar = vbCr Then
            PasarFoco()
        Else
            e.Handled = SoloEnteros(Asc(e.KeyChar))
        End If

    End Sub

    Private Sub txtNumComprobante_LostFocus(sender As Object, e As EventArgs) Handles txtNumComprobante.LostFocus

        txtNumComprobante.Text = txtNumComprobante.Text.PadLeft(8, "0")

    End Sub

    Private Sub dtpFecha_KeyPress(sender As Object, e As KeyPressEventArgs) Handles dtpFecha.KeyPress

        If e.KeyChar = vbCr Then
            PasarFoco()
        End If

    End Sub

    Private Sub cboArticulo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboArticulo.SelectedIndexChanged

        If cboArticulo.SelectedIndex <> -1 Then
            txtCodArt.Text = Getdata(cboArticulo.SelectedItem(0), "codigo", "articulos")
        End If

    End Sub

    Private Sub cboSitIva_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboSitIva.KeyPress

        If e.KeyChar = vbCr Then
            PasarFoco()
        End If

    End Sub

    Private Sub cboTipoComprobante_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTipoComprobante.SelectedIndexChanged

        If cboTipoComprobante.Text = "" Then
            Exit Sub
        End If

        cboPtoVenta.Items.Clear()

        SQL = "SELECT puntoventa FROM indices WHERE idtipocomprobante = " & cboTipoComprobante.SelectedItem(0)
        Try
            Dim comando As New MySqlCommand(SQL, conexion)
            Dim rsPuntoVenta As MySqlDataReader

            rsPuntoVenta = comando.ExecuteReader
            If rsPuntoVenta.Read Then
                cboPtoVenta.Items.Add(rsPuntoVenta("puntoventa"))
                rsPuntoVenta.NextResult()
            End If

            rsPuntoVenta.Close()
            comando.Dispose()

        Catch ex As Exception
            CatchError(ex.Message, ex.StackTrace, SQL)
            End

        End Try

        cboPtoVenta.SelectedIndex = 0

    End Sub

    Private Sub cboPtoVenta_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPtoVenta.SelectedIndexChanged

        If Not Nuevo Then
            Exit Sub
        End If

        If cboPtoVenta.Text <> "" Then
            CargarNumero()
        End If

    End Sub

    Private Sub CmdImprimir_Click(sender As Object, e As EventArgs) Handles cmdImprimir.Click

        Imprimir(True)

    End Sub

    Function generoListaDatos()

        Dim datosRemito As New List(Of datosRemito)
        Dim datos As New datosRemito

        datos.cuitCliente = "CUIT" & ": " & txtNumeroDocumento.Text
        datos.domicilioCliente = txtDireccion.Text
        datos.fechaRemito = "Fecha: " & Format(dtpFecha.Value, "dd/MM/yyyy")
        datos.nombreCliente = cboCliente.Text
        datos.numeroRemito = Format(CInt(cboPtoVenta.Text), "0000") & " - " & Format(CInt(txtNumComprobante.Text), "00000000")
        datos.tipoIvaCliente = "IVA: " & cboSitIva.Text
        datos.total = FormatNumber(txtTotal.Text, 2)

        datosRemito.Add(datos)
        Return datosRemito

    End Function

    Function generoDetalleRemito()

        Dim detalleRemito As New List(Of detalleRemito)
        If (Flex.Rows.Count > 0) Then
            For Each row As DataGridViewRow In Flex.Rows
                If Not row Is Nothing Then
                    Dim detalle As New detalleRemito
                    If (row.Cells(3).Value.ToString() = "") Then
                        detalle.codigo = "X"
                    Else
                        detalle.codigo = row.Cells(3).Value
                    End If
                    detalle.art = row.Cells(4).Value
                    detalle.cantidad = row.Cells(5).Value
                    detalleRemito.Add(detalle)
                End If
            Next
        End If

        Return detalleRemito

    End Function

    Sub Imprimir(Optional GenerarPDF As Boolean = False)

        Form1.ReportViewer1.LocalReport.ReportEmbeddedResource = "BsAsRemitos.Report1.rdlc"
        Form1.ReportViewer1.LocalReport.DataSources.Clear()
        Form1.ReportViewer1.LocalReport.DataSources.Add(New ReportDataSource("datosRemito", generoListaDatos()))
        Form1.ReportViewer1.LocalReport.DataSources.Add(New ReportDataSource("detalleRemito", generoDetalleRemito()))

        Dim deviceInfo = " <DeviceInfo>
                                <EmbedFonts>None</EmbedFonts>
                            </DeviceInfo>"

        Dim bytes = Form1.ReportViewer1.LocalReport.Render("PDF", deviceInfo)
        Dim ruta = "\\server\c\REMITOS SISTEMA\RE-" & Format(CInt(cboPtoVenta.Text), "0000") & "-" & Format(CInt(txtNumComprobante.Text), "00000000") & ".pdf"
        'Dim ruta = "c:\fe\RE-" & Format(CInt(cboPtoVenta.Text), "0000") & "-" & Format(CInt(txtNumComprobante.Text), "00000000") & ".pdf"

        Dim archivo = New FileStream(ruta, FileMode.Create)
        archivo.Write(bytes, 0, bytes.Length)
        archivo.Close()

        Timer1.Interval = 1500
        Timer1.Enabled = True

        ''Vacio tabla Temporal
        'SQL = "DELETE FROM temp"
        'Try
        '    Dim comando As New MySqlCommand(SQL, conexion)
        '    comando.ExecuteNonQuery()
        '    comando.Dispose()

        'Catch ex As Exception
        '    CatchError(ex.Message, ex.StackTrace, SQL)
        '    End

        'End Try

        ''Cargo Tabla temporal
        'SQL = "INSERT INTO temp (col0, col1, col2) VALUES (@col0, @col1, @col2)"
        'For i = 0 To Flex.RowCount - 1
        '    Try
        '        Dim comando = New MySqlCommand(SQL, conexion) With {
        '        .CommandType = CommandType.Text
        '    }
        '        comando.Parameters.AddWithValue("@col0", Flex.Rows(i).Cells(5).Value)
        '        comando.Parameters.AddWithValue("@col1", Flex.Rows(i).Cells(3).Value)
        '        comando.Parameters.AddWithValue("@col2", Flex.Rows(i).Cells(4).Value)
        '        comando.ExecuteNonQuery()
        '        comando.Dispose()

        '    Catch ex As Exception
        '        CatchError(ex.Message, ex.StackTrace, SQL)
        '        End

        '    End Try
        'Next i

        'Dim oCampoInforme As TextObject
        'Dim oDatosInforme As SummaryInfo

        'oCampoInforme = oInforme.ReportDefinition.ReportObjects.Item("lblTipo")
        'oCampoInforme.Text = cboTipoComprobante.Text

        'oCampoInforme = oInforme.ReportDefinition.ReportObjects.Item("lblNumero")
        'oCampoInforme.Text = Format(CInt(cboPtoVenta.Text), "0000") & " - " & Format(CInt(txtNumComprobante.Text), "00000000")

        'oCampoInforme = oInforme.ReportDefinition.ReportObjects.Item("lblFecha")
        'oCampoInforme.Text = "Fecha: " & Format(dtpFecha.Value, "dd/MM/yyyy")

        'oCampoInforme = oInforme.ReportDefinition.ReportObjects.Item("lblNombre")
        'oCampoInforme.Text = cboCliente.Text

        'oCampoInforme = oInforme.ReportDefinition.ReportObjects.Item("lblDireccion")
        'oCampoInforme.Text = txtDireccion.Text

        'oCampoInforme = oInforme.ReportDefinition.ReportObjects.Item("lblTipoIVA")
        'oCampoInforme.Text = "IVA: " & cboSitIva.Text

        'oCampoInforme = oInforme.ReportDefinition.ReportObjects.Item("lblCUIT")
        'oCampoInforme.Text = "CUIT" & ": " & txtNumeroDocumento.Text

        ''oCampoInforme = oInforme.ReportDefinition.ReportObjects.Item("lblIdTipo")
        ''oCampoInforme.Text = Format(CInt(cboTipoComprobante.SelectedItem(0)), "00")


        'oCampoInforme = oInforme.ReportDefinition.ReportObjects.Item("lblLetra")
        'oCampoInforme.Text = "X"

        'oCampoInforme = oInforme.ReportDefinition.ReportObjects.Item("text28")
        'oCampoInforme.Text = "Total"

        'oCampoInforme = oInforme.ReportDefinition.ReportObjects.Item("lblTotal")
        'oCampoInforme.Text = FormatNumber(txtTotal.Text, 2)

        'SQL = "SELECT col0, col1, col2 FROM temp"
        'Try
        '    Dim rsArticulos As New MySqlDataAdapter(SQL, conexion)
        '    Dim ds As New DataSet
        '    rsArticulos.Fill(ds)

        '    oInforme.SetDataSource(ds)

        'Catch ex As Exception
        '    CatchError(ex.Message, ex.StackTrace, SQL)
        '    End

        'End Try

        'Comprobante.Visor.ReportSource = oInforme
        ''Comprobante.Show()

        'If GenerarPDF = True Then
        '    Try
        '        ImprimePDF("Remito", Format(CInt(cboPtoVenta.Text), "0000"), Format(CInt(txtNumComprobante.Text), "00000000"), "RE", Format(CInt(txtCodCliente.Text), "0000"), "X")
        '    Catch ex As Exception
        '        MsgBox(ex.Message)
        '        MsgBox(ex.InnerException)
        '    End Try

        'Else
        '    Comprobante.Visor.PrintReport()
        'End If

    End Sub

    Function estaAbierto(ruta As String) As Boolean

        Try
            Dim fileopen As System.IO.FileStream = System.IO.File.OpenWrite(ruta)
            fileopen.Close()
        Catch ex As Exception
            Return True
        End Try

        Return False

    End Function

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        Dim ruta = "\\server\c\REMITOS SISTEMA\RE-" & Format(CInt(cboPtoVenta.Text), "0000") & "-" & Format(CInt(txtNumComprobante.Text), "00000000") & ".pdf"
        'Dim ruta = "c:\fe\RE-" & Format(CInt(cboPtoVenta.Text), "0000") & "-" & Format(CInt(txtNumComprobante.Text), "00000000") & ".pdf"


        If ExisteArchivo(ruta) Then
            If Not estaAbierto(ruta) Then
                Timer1.Enabled = False
                Dim proceso As New Process
                proceso.StartInfo.FileName = ruta
                proceso.StartInfo.Arguments = ""
                proceso.Start()
                Me.Close()
            End If
        End If

    End Sub

End Class