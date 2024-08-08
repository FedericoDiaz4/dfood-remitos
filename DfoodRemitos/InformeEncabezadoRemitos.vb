Imports MySql.Data.MySqlClient

Public Class InformeEncabezadoRemitos
    Private Sub InformeEncabezadoRemitos_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        DtpDesde.Value = Date.Now
        DtpHasta.Value = Date.Now

    End Sub

    Private Sub cmdOk_Click(sender As Object, e As EventArgs) Handles cmdOk.Click

        Dim aplicacion As New Microsoft.Office.Interop.Excel.Application()
        Dim libros_trabajo As Microsoft.Office.Interop.Excel.Workbook
        Dim hoja_trabajo As Microsoft.Office.Interop.Excel.Worksheet

        libros_trabajo = aplicacion.Workbooks.Add()
        hoja_trabajo = libros_trabajo.Worksheets.Item(1)
        'aplicacion.Visible = True

        hoja_trabajo.Cells(1, 1) = "Informe Remitos"

        hoja_trabajo.Cells(3, 1) = "Remito"
        hoja_trabajo.Cells(3, 2) = "Fecha"
        hoja_trabajo.Cells(3, 3) = "Cliente"
        Try
            SQL = "SELECT r.id, r.numerocomprobante, r.idcliente, r.fecha, c.codigo, c.nombre FROM remitos as r "
            SQL &= "INNER JOIN clientes AS c ON c.id = r.idcliente "
            SQL &= " WHERE fecha BETWEEN '" & Format(DtpDesde.Value, "yyyy-MM-dd") & "' AND '" & Format(DtpHasta.Value, "yyyy-MM-dd") & "' "
            SQL &= " AND r.eliminado = 0"
            SQL &= " ORDER BY fecha"
            Dim comando As New MySqlCommand(SQL, conexion)
            Dim rsRemito As MySqlDataReader
            Dim fila As Integer = 4
            rsRemito = comando.ExecuteReader
            Do While rsRemito.Read()
                hoja_trabajo.Cells(fila, 1) = "REMITO N° " + rsRemito("numerocomprobante")
                hoja_trabajo.Cells(fila, 2) = rsRemito("fecha")
                hoja_trabajo.Cells(fila, 3) = rsRemito("nombre")
                fila += 1
            Loop

            hoja_trabajo.Cells(fila, 2) = "TOTAL GENERAL: "
            hoja_trabajo.Cells(fila, 3) = rsRemito.FieldCount
            rsRemito.Close()
            comando.Dispose()
            aplicacion.Visible = True
        Catch ex As Exception
            MsgBox(ex.Message)
            Exit Sub

        End Try

    End Sub
End Class