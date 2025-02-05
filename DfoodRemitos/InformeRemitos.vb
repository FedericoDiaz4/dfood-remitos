Imports MySql.Data.MySqlClient

Public Class InformeRemitos
    Private Sub InformeRemitos_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        DtpDesde.Value = Date.Now
        DtpHasta.Value = Date.Now
        CargaCombo("Clientes", "nombre", "nombre", CboClientes, True)

    End Sub

    Private Sub cmdOk_Click(sender As Object, e As EventArgs) Handles cmdOk.Click

        If (CboClientes.SelectedIndex = -1) Then
            MsgBox("Debe elegir un cliente")
            CboClientes.Focus()
            Exit Sub
        End If

        Dim aplicacion As New Microsoft.Office.Interop.Excel.Application()
        Dim libros_trabajo As Microsoft.Office.Interop.Excel.Workbook
        Dim hoja_trabajo As Microsoft.Office.Interop.Excel.Worksheet

        libros_trabajo = aplicacion.Workbooks.Add()
        hoja_trabajo = libros_trabajo.Worksheets.Item(1)
        'aplicacion.Visible = True

        hoja_trabajo.Cells(1, 1) = "Informe Remitos"
        Try
            SQL = "SELECT r.id, r.numerocomprobante, r.idcliente, r.fecha, c.codigo, c.nombre FROM remitos as r "
            SQL &= "INNER JOIN clientes AS c ON c.id = r.idcliente "
            SQL &= " WHERE fecha BETWEEN '" & Format(DtpDesde.Value, "yyyy-MM-dd") & "' AND '" & Format(DtpHasta.Value, "yyyy-MM-dd") & "' "
            SQL &= " AND r.eliminado = 0"
            If (CboClientes.Text <> "Todos") Then
                SQL &= " AND idcliente = " & CboClientes.SelectedValue
            End If
            SQL &= " ORDER BY fecha"
            Dim comando As New MySqlCommand(SQL, conexion)
            Dim rsRemito As MySqlDataReader
            Dim fila As Integer = 3
            Dim vuelta As Integer = 1
            Dim cantidadTotal As Integer = 0
            Dim codigosSinUsar = New Integer() {7, 8, 12, 13, 14, 18, 19, 20}
            rsRemito = comando.ExecuteReader
            Do While rsRemito.Read()
                Dim sql1 As String
                sql1 = "SELECT a.codigo, rd.art, rd.cantidad, a.informe FROM remitosd as rd "
                sql1 &= "INNER JOIN articulos AS a ON rd.idart = a.id "
                sql1 &= "WHERE idremito = " & rsRemito("id") & " AND a.informe = 1 "
                conexionBis.ConnectionString = cadenaConexion
                conexionBis.Open()
                Dim comando1 As New MySqlCommand(sql1, conexionBis)
                Dim rsRemitoD As MySqlDataReader
                rsRemitoD = comando1.ExecuteReader
                If rsRemitoD.HasRows Then
                    If (vuelta = 1) Then
                        hoja_trabajo.Cells(fila, 1) = "REMITO N° " + rsRemito("numerocomprobante")
                        hoja_trabajo.Cells(fila, 2) = rsRemito("fecha")
                        hoja_trabajo.Cells(fila, 3) = rsRemito("nombre")
                        fila += 1
                    End If
                    Dim cantidad As Integer = 0
                    Do While rsRemitoD.Read
                        If (vuelta = 1) Then
                            hoja_trabajo.Cells(fila, 1) = "Codigo"
                            hoja_trabajo.Cells(fila, 2) = "Nombre"
                            hoja_trabajo.Cells(fila, 3) = "Cantidad"
                            vuelta += 1
                            fila += 1
                        End If
                        If Not codigosSinUsar.Contains(rsRemitoD("codigo")) Then
                            hoja_trabajo.Cells(fila, 1) = rsRemitoD("codigo")
                            hoja_trabajo.Cells(fila, 2) = rsRemitoD("art")
                            hoja_trabajo.Cells(fila, 3) = rsRemitoD("cantidad")
                            fila += 1
                            cantidad += rsRemitoD("cantidad")
                        End If
                    Loop
                    conexionBis.Close()
                    hoja_trabajo.Cells(fila, 1) = rsRemito("fecha")
                    hoja_trabajo.Cells(fila, 2) = "TOTAL: "
                    hoja_trabajo.Cells(fila, 3) = cantidad
                    cantidadTotal += cantidad
                    fila += 1
                    cantidad = 0
                    vuelta = 1
                    fila += 1
                Else
                    conexionBis.Close()
                End If
            Loop

            hoja_trabajo.Cells(fila, 2) = "TOTAL GENERAL: "
            hoja_trabajo.Cells(fila, 3) = cantidadTotal
            rsRemito.Close()
            comando.Dispose()
            aplicacion.Visible = True
        Catch ex As Exception
            MsgBox(ex.Message)
            Exit Sub

        End Try

    End Sub
End Class