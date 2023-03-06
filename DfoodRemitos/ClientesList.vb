Imports MySql.Data.MySqlClient

Public Class ClientesList
    Public entrada As String

    Private Sub ClientesList_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        InitForm(Me)
        cboBuscar.SelectedIndex = 0
        'Me.WindowState = 2
        Cargar()

    End Sub

    Sub Cargar()

        SQL = "SELECT id, codigo, nombre, numerodocumento, telefono FROM Clientes WHERE eliminado = 0 "
        If txtBuscar.Text <> "" Then
            SQL = SQL & " AND " & cboBuscar.Text & " LIKE '" & txtBuscar.Text & "%'"
        End If
        SQL = SQL & " ORDER BY " & cboBuscar.Text

        Dim unused As New MySqlDataAdapter
        Dim dt As DataSet

        DoubleBufferedASD(Flex, True)
        Try
            Dim da As MySqlDataAdapter = New MySqlDataAdapter(SQL, conexion)
            dt = New DataSet
            da.Fill(dt, "Clientes")
            Flex.DataSource = dt
            Flex.DataMember = "Clientes"
            da.Dispose()

        Catch ex As Exception
            catchError(ex.Message, ex.StackTrace, SQL)
            End

        End Try
        unused.Dispose()

        OrdenaFlex()

    End Sub

    Private Sub CmdNuevo_Click(sender As Object, e As EventArgs) Handles cmdNuevo.Click

        Me.Close()
        Clientes.id = 0
        Clientes.Nuevo = True
        Clientes.Show()

    End Sub

    Private Sub CmdEliminar_Click(sender As Object, e As EventArgs) Handles cmdEliminar.Click

        If IsNothing(Flex.CurrentRow.Cells(0).Value) Then
            Exit Sub
        End If

        Select Case MsgBox("¿DESEA ELIMINAR EL CLIENTE " & Flex.CurrentRow.Cells(1).Value & "?", vbYesNo Or vbQuestion Or vbDefaultButton2)
            Case vbNo : Exit Sub
        End Select

        Try
            SQL = "UPDATE clientes SET eliminado = 1 WHERE id = " & Flex.CurrentRow.Cells(0).Value
            Dim comando As New MySqlCommand(SQL, conexion)
            comando.ExecuteNonQuery()
            MsgBox("Eliminado")
            comando.Dispose()

        Catch ex As Exception
            catchError(ex.Message, ex.StackTrace, SQL)
            End

        End Try

        Cargar()

    End Sub

    Private Sub CboBuscar_Click(sender As Object, e As EventArgs) Handles cboBuscar.Click

        On Error Resume Next
        txtBuscar.Text = ""
        Cargar()
        txtBuscar.Focus()

    End Sub

    Private Sub CboBuscar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboBuscar.KeyPress

        If e.KeyChar = vbCr Then
            PasarFoco()
            e.KeyChar = ""
        End If

    End Sub

    Private Sub CmdSalir_Click(sender As Object, e As EventArgs) Handles cmdSalir.Click

        Me.Close()

    End Sub

    Private Sub CmdModificar_Click(sender As Object, e As EventArgs) Handles cmdModificar.Click

        If IsNothing(Flex.CurrentRow.Cells(0).Value) Then
            Exit Sub
        End If

        Clientes.Nuevo = False
        Clientes.id = Flex.CurrentRow.Cells(0).Value
        Clientes.Show()

        Try
            SQL = "SELECT id, codigo, nombre, idtiporesponsable, idtipodocumento, numerodocumento, "
            SQL &= "direccion, CP, localidad, idprovincia, contacto, telefono, email FROM clientes "
            SQL &= "WHERE id = " & Flex.CurrentRow.Cells(0).Value & " AND eliminado = 0"
            Dim comando As New MySqlCommand(SQL, conexion)
            Dim rsModificar As MySqlDataReader

            rsModificar = comando.ExecuteReader
            If rsModificar.Read Then
                Clientes.txtCodigo.Text = rsModificar("codigo").ToString
                Clientes.txtCodigo.Enabled = False
                Clientes.txtNombre.Text = rsModificar("nombre").ToString
                Clientes.cboSituacion.Text = Getdata(rsModificar("idtiporesponsable"), "nombre", "tiporesponsable")
                Clientes.cboTipoDocumento.Text = Getdata(rsModificar("idtipodocumento"), "nombre", "tipodocumento")
                Clientes.txtCuit.Text = rsModificar("numerodocumento").ToString
                Clientes.txtDireccion.Text = rsModificar("direccion").ToString
                Clientes.txtLocalidad.Text = rsModificar("localidad").ToString
                Clientes.cboProvincia.Text = Getdata(rsModificar("idprovincia"), "nombre", "provincias")
                Clientes.txtCP.Text = rsModificar("CP").ToString
                Clientes.txtContacto.Text = rsModificar("contacto").ToString
                Clientes.txtMail.Text = rsModificar("email").ToString
                Clientes.txtTelefono.Text = rsModificar("telefono").ToString
            End If

            rsModificar.Close()
            comando.Dispose()
            Me.Close()

        Catch ex As Exception
            catchError(ex.Message, ex.StackTrace, SQL)
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
        Flex.Columns(1).HeaderText = "Codigo"
        Flex.Columns(1).Width = 65
        Flex.Columns(2).HeaderText = "Nombre"
        Flex.Columns(2).Width = 450
        Flex.Columns(3).HeaderText = "Cuit"
        Flex.Columns(3).Width = 115
        Flex.Columns(4).HeaderText = "Telefono"
        Flex.Columns(4).Width = 130

    End Sub

    Private Sub TxtBuscar_TextChanged(sender As Object, e As EventArgs) Handles txtBuscar.TextChanged

        Cargar()

    End Sub

    Private Sub ClientesList_Resize(sender As Object, e As EventArgs) Handles Me.Resize

        frmBuscar.Width = Me.Width - 40
        Flex.Width = Me.Width - 40
        Flex.Height = Me.Height - frmBotones.Height - frmBuscar.Height - 40
        frmBotones.Top = Flex.Top + Flex.Height
        frmBotones.Left = Me.Width - frmBotones.Width - 28
        Me.MaximizeBox = True

    End Sub

    Private Sub TxtBuscar_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBuscar.KeyDown

        If e.KeyCode = Keys.Down Then
            Flex.Focus()
        End If

    End Sub

End Class