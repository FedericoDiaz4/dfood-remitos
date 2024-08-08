Imports MySql.Data.MySqlClient

Public Class Clientes

    Public id As Integer
    Public Nuevo As Boolean

    Private Sub Clientes_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        InitForm(Me)
        CargaCombo("provincias", "nombre", "id", cboProvincia)
        CargaCombo("tiporesponsable", "nombre", "id", cboSituacion)
        CargaCombo("tipodocumento", "nombre", "id", cboTipoDocumento)

        If Nuevo Then

            SQL = "SELECT codigo FROM clientes ORDER BY codigo DESC LIMIT 1"
            Try
                Dim comando As New MySqlCommand(SQL, conexion)
                Dim rsNumero As MySqlDataReader

                rsNumero = comando.ExecuteReader
                If rsNumero.Read Then
                    txtCodigo.Text = Format(CInt(rsNumero("codigo") + 1), "0000")
                End If

                rsNumero.Close()
                rsNumero.Dispose()
                comando.Dispose()

            Catch ex As Exception
                catchError(ex.Message, ex.StackTrace, SQL)
                End

            End Try

        End If

    End Sub

    Private Sub CmdGuardar_Click(sender As Object, e As EventArgs) Handles CmdGuardar.Click

        'Validaciones
        If txtCodigo.Text = "" Then
            Call MsgBox("Falta ingresar codigo de cliente", vbCritical, "Falta codigo")
            txtCodigo.Select()
            Exit Sub
        End If

        If txtNombre.Text = "" Then
            Call MsgBox("Falta ingresar nombre de cliente", vbCritical, "Falta nombre")
            txtNombre.Select()
            Exit Sub
        End If

        If txtCuit.Text = "" Then
            Call MsgBox("Falta ingresar CUIT de cliente", vbCritical, "Falta cuit")
            txtCuit.Select()
            Exit Sub
        End If

        If (cboTipoDocumento.SelectedIndex = -1) Then
            Call MsgBox("Falta ingresar Tipo de documento del cliente", vbCritical, "Falta tipo documento")
            cboTipoDocumento.Select()
            Exit Sub
        End If

        'Guardo
        If Nuevo Then
            'Reviso que el código no este cargado para el usuario activo
            SQL = "SELECT * FROM clientes WHERE codigo = '" & txtCodigo.Text & "' AND eliminado = 0 "
            Try
                Dim rsConsulta As MySqlDataReader
                Dim comando = New MySqlCommand(SQL, conexion)
                rsConsulta = comando.ExecuteReader

                If rsConsulta.HasRows Then
                    Call MsgBox("El codigo ya esta en uso. Por favor coloque otro.", vbCritical, "Usuario repetido")
                    rsConsulta.Close()
                    Exit Sub
                End If

                rsConsulta.Close()
                comando.Dispose()

            Catch ex As Exception
                catchError(ex.Message, ex.StackTrace, SQL)
                Exit Sub

            End Try

            SQL = "INSERT INTO clientes(codigo, nombre, idtiporesponsable, idtipodocumento, numerodocumento, direccion, cp, "
            SQL &= "localidad, idprovincia, contacto, telefono, email, eliminado)"
            SQL &= "VALUES (@codigo, @nombre, @idtiporesponsable, @idtipodocumento, @numerodocumento, @direccion, @cp, "
            SQL &= "@localidad, @idprovincia, @contacto, @telefono, @email, @eliminado)"
        Else
            SQL = "UPDATE clientes SET codigo = @codigo, nombre = @nombre, idtiporesponsable = @idtiporesponsable, "
            SQL &= "idtipodocumento = @idtipodocumento, numerodocumento = @numerodocumento, direccion = @direccion, "
            SQL &= "cp = @cp, localidad = @localidad, idprovincia = @idprovincia, contacto = @contacto, telefono = @telefono, "
            SQL &= "email = @email WHERE id = " & id
        End If

        Try
            Dim comando = New MySqlCommand(SQL, conexion) With {
                .CommandType = CommandType.Text
            }
            comando.Parameters.AddWithValue("@codigo", txtCodigo.Text)
            comando.Parameters.AddWithValue("@nombre", txtNombre.Text)
            comando.Parameters.AddWithValue("@idtiporesponsable", cboSituacion.SelectedItem(0))
            comando.Parameters.AddWithValue("@idtipodocumento", cboTipoDocumento.SelectedItem(0))
            comando.Parameters.AddWithValue("@numerodocumento", txtCuit.Text)
            comando.Parameters.AddWithValue("@direccion", txtDireccion.Text)
            comando.Parameters.AddWithValue("@localidad", txtLocalidad.Text)
            If cboProvincia.SelectedIndex = -1 Then
                comando.Parameters.AddWithValue("@idprovincia", 0)
            Else
                comando.Parameters.AddWithValue("@idprovincia", cboProvincia.SelectedItem(0))
            End If
            comando.Parameters.AddWithValue("@cp", txtCP.Text)
            comando.Parameters.AddWithValue("@contacto", txtContacto.Text)
            comando.Parameters.AddWithValue("@email", txtMail.Text)
            comando.Parameters.AddWithValue("@telefono", txtTelefono.Text)
            comando.Parameters.AddWithValue("@eliminado", 0)
            comando.ExecuteNonQuery()
            comando.Dispose()

        Catch ex As Exception
            catchError(ex.Message, ex.StackTrace, SQL)
            Exit Sub

        End Try

        ClientesList.Show()
        Me.Close()

    End Sub

    Private Sub CmdSalir_Click(sender As Object, e As EventArgs) Handles cmdSalir.Click

        Me.Close()

    End Sub

    Private Sub TxtCodigo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCodigo.KeyPress

        If e.KeyChar = vbCr Then
            PasarFoco()
        Else
            e.Handled = SoloEnteros(Asc(e.KeyChar))
        End If

    End Sub

    Private Sub TxtNombre_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNombre.KeyPress

        If e.KeyChar = vbCr Then
            PasarFoco()
        End If

    End Sub

    Private Sub TxtCuit_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCuit.KeyPress

        If e.KeyChar = vbCr Then
            PasarFoco()
        Else
            e.Handled = SoloCuit(Asc(e.KeyChar), Len(txtCuit.Text))
        End If

    End Sub

    Private Sub TxtDireccion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDireccion.KeyPress

        If e.KeyChar = vbCr Then
            PasarFoco()
        End If

    End Sub

    Private Sub TxtLocalidad_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtLocalidad.KeyPress

        If e.KeyChar = vbCr Then
            PasarFoco()
        End If

    End Sub

    Private Sub CboProvincia_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboProvincia.KeyPress

        If e.KeyChar = vbCr Then
            PasarFoco()
        End If

    End Sub

    Private Sub TxtCP_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCP.KeyPress

        If e.KeyChar = vbCr Then
            PasarFoco()
        End If

    End Sub

    Private Sub TxtContacto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtContacto.KeyPress

        If e.KeyChar = vbCr Then
            PasarFoco()
        End If

    End Sub

    Private Sub TxtMail_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtMail.KeyPress

        If e.KeyChar = vbCr Then
            PasarFoco()
        End If

    End Sub

    Private Sub TxtTelefono_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTelefono.KeyPress

        If e.KeyChar = vbCr Then
            PasarFoco()
        Else
            e.Handled = SoloCuit(Asc(e.KeyChar), Len(txtTelefono.Text))
        End If

    End Sub

    Private Sub CboSituacion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboSituacion.KeyPress

        If e.KeyChar = vbCr Then
            PasarFoco()
        End If

    End Sub

    Private Sub cboTipoDocumento_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboTipoDocumento.KeyPress

        If e.KeyChar = vbCr Then
            PasarFoco()
        End If

    End Sub

    Private Sub Clientes_Closed(sender As Object, e As EventArgs) Handles Me.Closed

        ClientesList.Show()
        ClientesList.Cargar()

    End Sub

    Private Sub txtCodigo_GotFocus(sender As Object, e As EventArgs) Handles txtCodigo.GotFocus

        txtCodigo.SelectionStart = 0
        txtCodigo.SelectionLength = Len(txtCodigo.Text)

    End Sub

End Class