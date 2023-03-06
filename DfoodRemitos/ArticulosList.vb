Imports MySql.Data.MySqlClient

Public Class ArticulosList
    Public entrada As String

    Private Sub ArticulosList_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        InitForm(Me)
        cboBuscar.SelectedIndex = 0
        Cargar()

    End Sub

    Sub Cargar()

        If cboBuscar.Text = "" Then
            cboBuscar.SelectedIndex = 1
        End If

        SQL = "SELECT id, codigo, descripcion, eliminado FROM articulos WHERE eliminado = 0 "
        If txtBuscar.Text <> "" Then
            SQL = SQL & " And " & cboBuscar.Text & " Like '%" & txtBuscar.Text & "%'"
        End If
        SQL = SQL & " ORDER BY " & cboBuscar.Text

        Dim da As New MySqlDataAdapter
        Dim dt As DataSet

        DoubleBufferedASD(Flex, True)
        Try
            da = New MySqlDataAdapter(SQL, conexion)
            dt = New DataSet
            da.Fill(dt, "articulos")
            Flex.DataSource = dt
            Flex.DataMember = "articulos"

        Catch ex As Exception
            CatchError(ex.Message, ex.StackTrace, SQL)
            End

        End Try

        OrdenaFlex()

    End Sub

    Private Sub CmdNuevo_Click(sender As Object, e As EventArgs) Handles cmdNuevo.Click

        Me.Close()
        Articulos.id = 0
        Articulos.Nuevo = True
        Articulos.Show()

    End Sub

    Private Sub CmdEliminar_Click(sender As Object, e As EventArgs) Handles cmdEliminar.Click

        If IsNothing(Flex.CurrentRow.Cells(0).Value) Then
            Exit Sub
        End If

        Select Case MsgBox("¿DESEA ELIMINAR EL ARTICULO " & Flex.CurrentRow.Cells(2).Value & "?", vbYesNo Or vbQuestion Or vbDefaultButton2)
            Case vbNo : Exit Sub
        End Select

        Try
            SQL = "UPDATE articulos SET eliminado = 1 WHERE id = " & Flex.CurrentRow.Cells(0).Value
            Dim comando As New MySqlCommand(SQL, conexion)
            comando.ExecuteNonQuery()
            MsgBox("Eliminado")

        Catch ex As Exception
            CatchError(ex.Message, ex.StackTrace, SQL)
            End

        End Try

        Cargar()

    End Sub

    Private Sub CboBuscar_Click(sender As Object, e As EventArgs) Handles cboBuscar.Click

        On Error Resume Next
        txtBuscar.Text = ""

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

        Dim ArrBajas(-1) As Integer

        If IsNothing(Flex.CurrentRow.Cells(0).Value) Then
            Exit Sub
        End If

        Articulos.Nuevo = False
        Articulos.id = Flex.CurrentRow.Cells(0).Value

        Try
            SQL = "SELECT codigo, descripcion FROM articulos WHERE id = " & Flex.CurrentRow.Cells(0).Value & " AND eliminado = 0"
            Dim comando As New MySqlCommand(SQL, conexion)
            Dim rsModificar As MySqlDataReader

            rsModificar = comando.ExecuteReader
            If rsModificar.Read Then
                Articulos.txtCodigo.Text = rsModificar("codigo").ToString
                Articulos.txtCodigo.Enabled = False
                Articulos.txtDescripcion.Text = rsModificar("descripcion").ToString
            End If

            rsModificar.Close()
            rsModificar.Dispose()
            Me.Close()

            Articulos.Show()

        Catch ex As Exception
            CatchError(ex.Message, ex.StackTrace, SQL)
            End

        End Try

    End Sub

    Private Sub Flex_DoubleClick(sender As Object, e As EventArgs) Handles Flex.DoubleClick

        If entrada = "REMITO" Then

            If IsNothing(Flex.CurrentRow.Cells(0).Value) Then
                Exit Sub
            End If

            Remitos.txtCodArt.Text = Flex.CurrentRow.Cells(1).Value
            Remitos.txtCantidad.Focus()
            Me.Close()
        Else
            cmdModificar.PerformClick()
        End If

    End Sub

    Private Sub Flex_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Flex.KeyPress

        If e.KeyChar = vbCr AND entrada = "REMITO" Then

            If IsNothing(Flex.CurrentRow.Cells(0).Value) Then
                Exit Sub
            End If

            'Remitos.txtCodArt.Text = Flex.CurrentRow.Cells(2).Value
            'Remitos.txtCantidad.Focus()
            Me.Close()
            e.KeyChar = ""
        End If

    End Sub

    Sub OrdenaFlex()

        Flex.Columns(0).HeaderText = "Id"
        Flex.Columns(0).Visible = False
        Flex.Columns(1).HeaderText = "Código"
        Flex.Columns(1).Width = 60
        Flex.Columns(2).HeaderText = "Descripción"
        Flex.Columns(2).Width = 400
        Flex.Columns(3).HeaderText = "Eliminado"
        Flex.Columns(3).Visible = False

    End Sub

    Private Sub txtBuscar_TextChanged(sender As Object, e As EventArgs) Handles txtBuscar.TextChanged

        cargar()

    End Sub

    Private Sub ActividadesList_Resize(sender As Object, e As EventArgs) Handles Me.Resize

        frmBuscar.Width = Me.Width - 40
        Flex.Width = Me.Width - 40
        If entrada = "" Then
            Flex.Height = Me.Height - frmBotones.Height - frmBuscar.Height - 40
            frmBotones.Top = Flex.Top + Flex.Height
            frmBotones.Left = Me.Width - frmBotones.Width - 28
        Else
            Flex.Height = Me.Height - frmBuscar.Height - 40
        End If

        Me.MaximizeBox = True

    End Sub

    Private Sub txtBuscar_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBuscar.KeyDown

        If e.KeyCode = Keys.Down Then
            Flex.Focus()
        End If

    End Sub

End Class