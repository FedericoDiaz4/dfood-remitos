Imports MySql.Data.MySqlClient

Public Class RemitosList
    Public entrada As String

    Private Sub RemitosList_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        InitForm(Me)
        CargaCombo("tipocomprobante", "nombre", "id", cboTipoComprobante, False, "id = 99")
        CargaCombo("clientes", "nombre", "nombre", cboCliente, True, "eliminado = 0")
        cboCliente.SelectedIndex = 0
        cboTipoComprobante.SelectedIndex = 0
        Cargar()

    End Sub

    Sub Cargar()

        SQL = "SELECT v.id, v.idtipocomprobante, v.fecha, v.ptoventa, v.numerocomprobante, v.idcliente, c.codigo, c.nombre, v.cantidadtotal FROM Remitos AS v "
        SQL &= "INNER JOIN clientes AS c ON c.id = v.idcliente WHERE 0 = 0 AND v.eliminado = 0 "
        If cboCliente.SelectedIndex <> 0 And cboCliente.SelectedIndex <> -1 Then
            SQL &= "AND v.idcliente '" & cboCliente.SelectedItem(0) & "' "
        End If
        If cboTipoComprobante.SelectedIndex <> -1 Then
            SQL &= "AND v.idtipocomprobante = '" & cboTipoComprobante.SelectedItem(0) & "' "
        End If
        SQL = SQL & "ORDER BY v.numerocomprobante DESC, v.fecha DESC"

        Dim da As New MySqlDataAdapter
        Dim dt As DataSet

        DoubleBufferedASD(Flex, True)
        Try
            da = New MySqlDataAdapter(SQL, conexion)
            dt = New DataSet
            da.Fill(dt, "Remitos")
            Flex.DataSource = dt
            Flex.DataMember = "Remitos"

        Catch ex As Exception
            CatchError(ex.Message, ex.StackTrace, SQL)
            End

        End Try

        OrdenaFlex()

    End Sub

    Private Sub cmdNuevo_Click(sender As Object, e As EventArgs) Handles cmdNuevo.Click

        Me.Close()
        Remitos.id = nTmp
        Remitos.Nuevo = True
        Remitos.Show()

    End Sub

    Private Sub cmdSalir_Click(sender As Object, e As EventArgs) Handles cmdSalir.Click

        Me.Close()

    End Sub

    Private Sub cmdModificar_Click(sender As Object, e As EventArgs) Handles cmdModificar.Click

        If IsNothing(Flex.CurrentRow.Cells(0).Value) Then
            Exit Sub
        End If

        Remitos.Nuevo = False
        Remitos.id = Flex.CurrentRow.Cells(0).Value

        Try
            SQL = "SELECT idtipocomprobante, fecha, ptoventa, numerocomprobante, idcliente FROM Remitos WHERE id = " & Flex.CurrentRow.Cells(0).Value
            Dim comando As New MySqlCommand(SQL, conexion)
            Dim rsModificar As MySqlDataReader

            rsModificar = comando.ExecuteReader
            If rsModificar.Read Then
                Remitos.txtNumComprobante.Text = Format(CDbl(rsModificar("numerocomprobante").ToString), "00000000")
                Remitos.dtpFecha.Value = Format(rsModificar("fecha"), "dd/MM/yyyy")
                Remitos.idcliente = rsModificar("idCliente")
                Remitos.idcomprobante = rsModificar("idtipocomprobante")
                Remitos.cboPtoVenta.Text = rsModificar("ptoventa")
            End If

            rsModificar.Close()
            Me.Close()
            Remitos.Show()
            Remitos.Cargar()

        Catch ex As Exception
            CatchError(ex.Message, ex.StackTrace, SQL)
            End

        End Try

    End Sub

    Private Sub Flex_DoubleClick(sender As Object, e As EventArgs) Handles Flex.DoubleClick

        cmdModificar.PerformClick()

    End Sub

    Private Sub Flex_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Flex.KeyPress

        If e.KeyChar = vbCr Then
            cmdModificar.PerformClick()
            e.KeyChar = ""
        End If

    End Sub

    Sub OrdenaFlex()

        Flex.Columns(0).HeaderText = "Id"
        Flex.Columns(0).Visible = False
        Flex.Columns(1).HeaderText = "idtipocomprobante"
        Flex.Columns(1).Visible = False
        Flex.Columns(2).HeaderText = "Fecha"
        Flex.Columns(2).Width = 100
        Flex.Columns(3).HeaderText = "Pto Venta"
        Flex.Columns(3).Width = 100
        Flex.Columns(4).HeaderText = "Numero"
        Flex.Columns(4).Width = 90
        Flex.Columns(5).HeaderText = "idcliente"
        Flex.Columns(5).Visible = False
        Flex.Columns(6).HeaderText = "Codigo"
        Flex.Columns(6).Width = 80
        Flex.Columns(7).HeaderText = "Nombre"
        Flex.Columns(7).Width = 250
        Flex.Columns(8).HeaderText = "Cantidad"
        Flex.Columns(8).Width = 75


    End Sub

    Private Sub txtBuscar_TextChanged(sender As Object, e As EventArgs)

        Cargar()

    End Sub

    Private Sub RemitosList_Resize(sender As Object, e As EventArgs) Handles Me.Resize

        frmBuscar.Width = Me.Width - 40
        Flex.Width = Me.Width - 40
        Flex.Height = Me.Height - frmBotones.Height - frmBuscar.Height - 40
        frmBotones.Top = Flex.Top + Flex.Height
        frmBotones.Left = Me.Width - frmBotones.Width - 28
        Me.MaximizeBox = True

    End Sub

    Private Sub cboTipoComprobante_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboTipoComprobante.KeyPress

        If e.KeyChar = vbCr Then
            PasarFoco()
        End If

    End Sub

    Private Sub txtCodCliente_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCodCliente.KeyPress

        If e.KeyChar = vbCr Then
            PasarFoco()
        Else
            e.Handled = SoloEnteros(Asc(e.KeyChar))
        End If

    End Sub

    Private Sub cboCliente_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboCliente.KeyPress

        If e.KeyChar = vbCr Then
            PasarFoco()
        End If

    End Sub

    Private Sub TxtCodCliente_TextChanged(sender As Object, e As EventArgs) Handles txtCodCliente.TextChanged

        SQL = "SELECT nombre FROM clientes WHERE codigo = '" & txtCodCliente.Text & "' AND eliminado = 0"

        Try
            Dim comandoCli As New MySqlCommand(SQL, conexion)
            Dim rsCargar As MySqlDataReader

            rsCargar = comandoCli.ExecuteReader
            If rsCargar.Read Then
                cboCliente.Text = rsCargar("nombre").ToString
            Else
                cboCliente.SelectedIndex = -1
            End If

            rsCargar.Close()
            comandoCli.Dispose()

        Catch ex As Exception
            CatchError(ex.Message, ex.StackTrace, SQL)
            End

        End Try

    End Sub

    Private Sub cboCliente_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCliente.SelectedIndexChanged

        If cboCliente.SelectedIndex <> -1 Then
            txtCodCliente.Text = Getdata(cboCliente.SelectedItem(0), "codigo", "Clientes")
        End If

    End Sub

    Private Sub CmdEliminar_Click(sender As Object, e As EventArgs) Handles CmdEliminar.Click

        If IsNothing(Flex.CurrentRow.Cells(0).Value) Then
            Exit Sub
        End If

        Try
            SQL = "UPDATE Remitos SET eliminado = 1 WHERE id = " & Flex.CurrentRow.Cells(0).Value
            Dim comando As New MySqlCommand(SQL, conexion)
            comando.ExecuteNonQuery()
            comando.Dispose()

        Catch ex As Exception
            CatchError(ex.Message, ex.StackTrace, SQL)
            End

        End Try

        Cargar()

    End Sub


End Class