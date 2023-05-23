Imports MySql.Data.MySqlClient
Imports System.Reflection
Imports ADODB
Imports System.Management
Imports System.Text
Imports System.Drawing.Printing
Imports System.IO
Imports System.Drawing.Text
Imports System.Drawing.Image

Module Module1

    Public conexion As New MySqlConnection()
    Public conexionBis As New MySqlConnection()
    Public Const cadenaConexion As String = "SERVER=gloria-pc; PORT=3306; DataBase=dfoodremitos; Uid=root; Pwd=cmsis00; Convert Zero Datetime=True; "
    'Public Const cadenaConexion As String = "SERVER=localhost; PORT=3306; DataBase=dfoodremitos; Uid=root; Pwd=cmsis00; Convert Zero Datetime=True; "
    Public SQL As String
    Public nTmp As String
    Private Declare Function ShellExecute Lib "shell32.dll" Alias "ShellExecuteA" (ByVal hwnd As Long, ByVal lpOperation As String, ByVal lpFile As String, ByVal lpParameters As String, ByVal lpDirectory As String, ByVal nShowCmd As Long) As Long
    Declare Function SetDefaultPrinter Lib "winspool.drv" Alias "SetDefaultPrinterA" (ByVal pszPrinter As String) As Boolean

    Sub ConectarDB()

        Try
            conexion.ConnectionString = cadenaConexion
            conexion.Open()

        Catch ex As Exception
            CatchError(ex.Message, ex.StackTrace, SQL)
            End

        End Try

    End Sub

    Sub AbrirConexionBis()

        Try
            conexionBis.ConnectionString = cadenaConexion
            conexionBis.Open()

        Catch ex As Exception
            catchError(ex.Message, ex.StackTrace, SQL)
            Exit Sub

        End Try

    End Sub

    Sub CierroConexion()

        conexionBis.Close()

    End Sub

    Sub ObtengoNtmp()

        Dim serial As String
        Dim serialDD As New ManagementObject("Win32_LogicalDisk.DeviceId='C:'")
        serial = serialDD.Properties("VolumeSerialNumber").Value.ToString

        nTmp = DevuelveSoloNumero(serial)

    End Sub

    Function DevuelveSoloNumero(cadena As String)

        Dim numeros As String
        Dim f As Integer

        numeros = ""

        For f = 1 To Len(cadena)
            If (Mid$(cadena, f, 1) Like "#") Then
                numeros &= Mid$(cadena, f, 1)
            End If
        Next

        Return numeros

    End Function

    Private Function CpuId() As String

        Dim computer As String = "."
        Dim wmi As Object = GetObject("winmgmts:" &
           "{impersonationLevel=impersonate}!\\" &
           computer & "\root\cimv2")
        Dim processors As Object = wmi.ExecQuery("Select * from " &
           "Win32_Processor")

        Dim cpu_ids As String = ""
        For Each cpu As Object In processors
            cpu_ids = cpu_ids & ", " & cpu.ProcessorId
        Next cpu
        If cpu_ids.Length > 0 Then cpu_ids =
           cpu_ids.Substring(2)
        Return cpu_ids

    End Function

    Public Sub PasarFoco()

        SendKeys.SendWait("{TAB}")

    End Sub

    Public Sub InitForm(Frm As Form)

        Frm.StartPosition = FormStartPosition.CenterScreen
        Frm.MdiParent = zMain

    End Sub

    Function ExisteArchivo(strFile As String) As Boolean

        Dim strName As String
        strName = Dir$(strFile)
        ExisteArchivo = Not (strName = "")

    End Function

    Function Getdata(id As VariantType, field As String, table As String)

        Dim conn As New MySqlConnection
        With conn
            .ConnectionString = cadenaConexion
            .Open()
        End With

        Try
            SQL = "SELECT id, " & table & "." & field & " AS data FROM " & table & " WHERE id = '" & id & "'"
            Dim cmd As New MySqlCommand(SQL, conn)
            Dim rsData As MySqlDataReader
            Getdata = ""

            rsData = cmd.ExecuteReader
            If rsData.Read Then
                Getdata = rsData("Data").ToString
            End If
            rsData.Close()
            conn.Close()
        Catch ex As Exception
            CatchError(ex.Message, ex.StackTrace, SQL)
            Getdata = ""

        End Try

    End Function

    Public Sub DoubleBufferedASD(dgv As DataGridView, setting As Boolean)

        Dim dgvType As Type = dgv.[GetType]()
        Dim pi As PropertyInfo = dgvType.GetProperty("DoubleBuffered", BindingFlags.Instance Or BindingFlags.NonPublic)
        pi.SetValue(dgv, setting, Nothing)

    End Sub

    Public Sub CargaCombo(rsTable As String, rsField As String, rsOrder As String, Cbo As ComboBox, Optional Todos As Boolean = False, Optional Condicion As String = "")

        SQL = "SELECT id, " & rsField & " AS field FROM " & rsTable & " WHERE eliminado = '0'"
        If Condicion <> "" Then
            SQL = SQL & "AND " & Condicion
        End If
        SQL = SQL & " ORDER BY " & rsOrder

        Try
            AbrirConexionBis()
            Dim da As New MySqlDataAdapter(SQL, conexionBis)
            Dim dt = New DataTable()
            da.Fill(dt)

            If Todos Then
                Dim row As DataRow = dt.NewRow
                row("field") = "Todos"
                row("id") = 0
                dt.Rows.InsertAt(row, 0)
            End If

            Cbo.ValueMember = "id"
            Cbo.DisplayMember = "field"
            Cbo.DataSource = dt
            CierroConexion()

        Catch ex As Exception
            CatchError(ex.Message, ex.StackTrace, SQL)
            End

        End Try

        Cbo.SelectedIndex = -1

    End Sub

    Function SoloEnteros(KeyAscii As Integer)

        If Char.IsDigit(Chr(KeyAscii)) Then
            Return False
        ElseIf Char.IsControl(Chr(KeyAscii)) Then
            Return False
        Else
            Return True
        End If

    End Function

    Function SoloCuit(keyascii As Integer, len As Integer)
        If len < 13 And (Char.IsDigit(Chr(keyascii)) Or keyascii = 45) Then
            Return False
        ElseIf Char.IsControl(Chr(keyascii)) Then
            Return False
        Else
            Return True
        End If

    End Function

    Public Sub ImportarExcel()

        Dim dialog As New OpenFileDialog()
        dialog.Filter = "Excel files |*.xls;*.xlsx"
        dialog.InitialDirectory = "C:\IMPO\"
        dialog.Title = "Elegir Archivo"
        If dialog.ShowDialog() = DialogResult.OK Then
            Dim dt As DataTable
            dt = ImportarExcelATabla(dialog.FileName)

            For i = 0 To dt.Rows.Count - 1
                Try
                    SQL = "INSERT INTO clientes (codigo, nombre, contacto, direccion, localidad, cp, idprovincia, cuit, "
                    SQL &= "idtiporesponsable, mail, telefono) VALUES (@codigo, @nombre, @contacto, @direccion, @localidad, @cp, "
                    SQL &= "@idprovincia, @cuit, @idtiporesponsable, @mail, @telefono)"
                    Dim comando = New MySqlCommand(SQL, conexion) With {
                        .CommandType = CommandType.Text
                    }
                    comando.Parameters.AddWithValue("@codigo", dt.Rows(i)(0))
                    comando.Parameters.AddWithValue("@nombre", dt.Rows(i)(1))
                    If dt.Rows(i)(2).ToString = "" Then
                        comando.Parameters.AddWithValue("@contacto", "")
                    Else
                        comando.Parameters.AddWithValue("@contacto", dt.Rows(i)(2))
                    End If
                    If dt.Rows(i)(3).ToString = "" Then
                        comando.Parameters.AddWithValue("@direccion", "")
                    Else
                        comando.Parameters.AddWithValue("@direccion", dt.Rows(i)(3))
                    End If
                    If dt.Rows(i)(4).ToString = "" Then
                        comando.Parameters.AddWithValue("@localidad", "")
                    Else
                        comando.Parameters.AddWithValue("@localidad", dt.Rows(i)(4))
                    End If
                    If dt.Rows(i)(5).ToString = "" Then
                        comando.Parameters.AddWithValue("@cp", "")
                    Else
                        comando.Parameters.AddWithValue("@cp", dt.Rows(i)(5))
                    End If
                    comando.Parameters.AddWithValue("@idprovincia", dt.Rows(i)(6))
                    If dt.Rows(i)(7).ToString = "" Then
                        comando.Parameters.AddWithValue("@cuit", "")
                    Else
                        comando.Parameters.AddWithValue("@cuit", dt.Rows(i)(7))
                    End If
                    comando.Parameters.AddWithValue("@idtiporesponsable", dt.Rows(i)(8))
                    If dt.Rows(i)(9).ToString = "" Then
                        comando.Parameters.AddWithValue("@mail", "")
                    Else
                        comando.Parameters.AddWithValue("@mail", dt.Rows(i)(9))
                    End If
                    If dt.Rows(i)(10).ToString = "" Then
                        comando.Parameters.AddWithValue("@telefono", "")
                    Else
                        comando.Parameters.AddWithValue("@telefono", dt.Rows(i)(10))
                    End If

                    comando.ExecuteNonQuery()

                Catch ex As Exception
                    CatchError(ex.Message, ex.StackTrace, SQL)
                    Exit Sub

                End Try

            Next

        End If

        MsgBox("fin")

    End Sub

    Public Function ImportarExcelATabla(filepath As String) As DataTable

        Dim dt As New DataTable
        Try
            Dim ds As New DataSet()
            Dim constring As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & filepath & ";Extended Properties=""Excel 12.0;HDR=YES;"""
            Dim con As New OleDb.OleDbConnection(constring & "")
            con.Open()

            Dim Tabla = con.GetSchema("Tables").Rows(0)("TABLE_NAME")
            Dim mysqlquery As String = String.Format("SELECT * FROM [{0}]", Tabla)

            Dim da As New OleDb.OleDbDataAdapter(mysqlquery, con)
            da.Fill(ds)

            dt = ds.Tables(0)
            Return dt

        Catch ex As Exception
            MsgBox(Err.Description, MsgBoxStyle.Critical)
            Return dt

        End Try

    End Function

    Function CambiaPunto(Text As String, KeyChar As Char) As Char

        Dim KeyAscii As Integer = Asc(KeyChar)
        Dim Permitido As String = "0123456789-"

        If KeyAscii = 46 Then
            KeyAscii = 44
        End If

        If InStr(Text, ",") = 0 Then
            Permitido &= ","
        End If

        If InStr(Permitido, Chr(KeyAscii)) = 0 And KeyAscii <> 8 Then
            KeyAscii = 0
        End If

        Return Chr(KeyAscii)

    End Function

    Function GetDataRecibos(ID As VariantType, Field As String, Table As String)

        Dim conn As New MySqlConnection
        With conn
            .ConnectionString = cadenaConexion
            .Open()
        End With

        SQL = "SELECT id, " & Table & "." & Field & " AS data FROM " & Table & " WHERE id = '" & ID & "'"
        Dim cmd As New MySqlCommand(SQL, conn)
        Dim rsData As MySqlDataReader
        GetDataRecibos = ""

        rsData = cmd.ExecuteReader
        If rsData.Read Then
            GetDataRecibos = rsData("Data").ToString
        End If
        rsData.Close()
        conn.Close()

    End Function

    Function Num2Text(ByVal value As Double) As String

        Select Case value
            Case 0 : Num2Text = "CERO"
            Case 1 : Num2Text = "UN"
            Case 2 : Num2Text = "DOS"
            Case 3 : Num2Text = "TRES"
            Case 4 : Num2Text = "CUATRO"
            Case 5 : Num2Text = "CINCO"
            Case 6 : Num2Text = "SEIS"
            Case 7 : Num2Text = "SIETE"
            Case 8 : Num2Text = "OCHO"
            Case 9 : Num2Text = "NUEVE"
            Case 10 : Num2Text = "DIEZ"
            Case 11 : Num2Text = "ONCE"
            Case 12 : Num2Text = "DOCE"
            Case 13 : Num2Text = "TRECE"
            Case 14 : Num2Text = "CATORCE"
            Case 15 : Num2Text = "QUINCE"
            Case Is < 20 : Num2Text = "DIECI" & Num2Text(value - 10)
            Case 20 : Num2Text = "VEINTE"
            Case Is < 30 : Num2Text = "VEINTI" & Num2Text(value - 20)
            Case 30 : Num2Text = "TREINTA"
            Case 40 : Num2Text = "CUARENTA"
            Case 50 : Num2Text = "CINCUENTA"
            Case 60 : Num2Text = "SESENTA"
            Case 70 : Num2Text = "SETENTA"
            Case 80 : Num2Text = "OCHENTA"
            Case 90 : Num2Text = "NOVENTA"
            Case Is < 100 : Num2Text = Num2Text(Int(value \ 10) * 10) & " Y " & Num2Text(value Mod 10)
            Case 100 : Num2Text = "CIEN"
            Case Is < 200 : Num2Text = "CIENTO " & Num2Text(value - 100)
            Case 200, 300, 400, 600, 800 : Num2Text = Num2Text(Int(value \ 100)) & "CIENTOS"
            Case 500 : Num2Text = "QUINIENTOS"
            Case 700 : Num2Text = "SETECIENTOS"
            Case 900 : Num2Text = "NOVECIENTOS"
            Case Is < 1000 : Num2Text = Num2Text(Int(value \ 100) * 100) & " " & Num2Text(value Mod 100)
            Case 1000 : Num2Text = "MIL"
            Case Is < 2000 : Num2Text = "MIL " & Num2Text(value Mod 1000)
            Case Is < 1000000 : Num2Text = Num2Text(Int(value \ 1000)) & " MIL"
                If value Mod 1000 Then Num2Text = Num2Text & " " & Num2Text(value Mod 1000)
            Case 1000000 : Num2Text = "UN MILLON"
            Case Is < 2000000 : Num2Text = "UN MILLON " & Num2Text(value Mod 1000000)
            Case Is < 1000000000000.0# : Num2Text = Num2Text(Int(value / 1000000)) & " MILLONES "
                If (value - Int(value / 1000000) * 1000000) Then Num2Text = Num2Text & " " & Num2Text(value - Int(value / 1000000) * 1000000)
            Case 1000000000000.0# : Num2Text = "UN BILLON"
            Case Is < 2000000000000.0# : Num2Text = "UN BILLON " & Num2Text(value - Int(value / 1000000000000.0#) * 1000000000000.0#)
            Case Else : Num2Text = Num2Text(Int(value / 1000000000000.0#)) & " BILLONES"
                If (value - Int(value / 1000000000000.0#) * 1000000000000.0#) Then Num2Text = Num2Text & " " & Num2Text(value - Int(value / 1000000000000.0#) * 1000000000000.0#)

        End Select


    End Function

    Sub CatchError(MensajeError As String, evento As String, CadenaSql As String)

        Dim NombreArchivo As String
        NombreArchivo = Format(Date.Now, "dd-MM-yyyy HH.mm.ss") & ".txt"
        Dim path As String = "c:\sistema\logs\"
        Dim filest As FileStream = File.Create(path & NombreArchivo)

        Dim info As Byte() = New UTF8Encoding(True).GetBytes(MensajeError)
        filest.Write(info, 0, info.Length)

        info = New UTF8Encoding(True).GetBytes(vbCrLf)
        filest.Write(info, 0, info.Length)

        'info = New UTF8Encoding(True).GetBytes(CadenaSql)
        'filest.Write(info, 0, info.Length)

        info = New UTF8Encoding(True).GetBytes(vbCrLf)
        filest.Write(info, 0, info.Length)

        info = New UTF8Encoding(True).GetBytes(evento)
        filest.Write(info, 0, info.Length)

        filest.Close()
        MsgBox("Error interno, por favor consulte con el soporte del sistema.")

    End Sub


    Sub ImprimePDF(Comprobante As String, ptoventa As Integer, numcomprobante As String, TC As String,
                   Optional CodigoPersona As Integer = 0, Optional Letra As String = "")

        Dim pdfjob As PDFCreator.clsPDFCreator
        Dim sPDFName As String
        Dim sPDFPath As String
        Dim sPrinterName As String
        Dim sReportName As String
        Dim lPrinters As Long
        Dim lPrinterCurrent As Long
        Dim lPrinterPDF As Long
        Dim prtDefault As New PrinterSettings
        Dim impresoraActual As String

        If Comprobante = "Remito" Then
            'sReportName = "crRemito"
            sReportName = "crComprobante"
            sPDFName = TC & "-" & Format(CInt(ptoventa), "0000") & "-" & Format(CInt(numcomprobante), "00000000") & ".pdf"
            sPDFPath = "\\server\F\RemitosSistema\"
            'sPDFPath = "c:\pdf\"
        Else
            Exit Sub
        End If

        If ExisteArchivo(sPDFPath & sPDFName) Then
            Try
                Dim fs As System.IO.FileStream = System.IO.File.OpenWrite(sPDFPath & sPDFName)
                fs.Close()
            Catch ex As Exception
                MsgBox("Archivo PDF " & sPDFPath & sPDFName & " esta abierto. Por favor verifique cierre el mismo y re-imprima.")
                Exit Sub

            End Try

        End If


        impresoraActual = prtDefault.PrinterName
        SetDefaultPrinter("PDFCreator")

        pdfjob = New PDFCreator.clsPDFCreator
        With pdfjob
            If .cStart("/NoProcessingAtStartup") = False Then
                MsgBox("No se puede iniciar PDFCreator.", vbCritical + vbOKOnly, "PrtPDFCreator")
                Exit Sub
            End If
            .cOption("UseAutosave") = 1
            .cOption("UseAutosaveDirectory") = 1
            .cOption("Title") = sPDFName
            .cOption("DocumentName") = sPDFName
            .cOption("AutosaveDirectory") = sPDFPath
            .cOption("AutosaveFilename") = sPDFName
            .cOption("AutosaveFormat") = 0 ' 0 = PDF
            .cClearCache()

        End With

        If Comprobante = "Remito" Then
            'Remitos.oInforme.SetDatabaseLogon("root", "cmsis00", "localhost", "dfoodremitos")'
            Remitos.oInforme.PrintToPrinter(1, False, 1, 1)
        End If

        Do Until pdfjob.cCountOfPrintjobs = 1

        Loop

        pdfjob.cPrinterStop = False

        Do Until pdfjob.cCountOfPrintjobs = 0

        Loop
        pdfjob.cClose()

        SetDefaultPrinter(impresoraActual)
        pdfjob = Nothing

        If ExisteArchivo(sPDFPath & "\" & sPDFName) Then
            Dim proceso As New Process
            proceso.StartInfo.FileName = sPDFPath & "\" & sPDFName
            proceso.StartInfo.Arguments = ""
            proceso.Start()
        End If

    End Sub

End Module
