Imports MySql.Data.MySqlClient

Public Class Articulos

    Public id As Integer
    Public Nuevo As Boolean

    Private Sub Articulos_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        InitForm(Me)

        If Nuevo Then
            CargoNumero()
        End If

    End Sub

    Private Sub CargoNumero()

        SQL = "SELECT codigo FROM articulos ORDER BY codigo DESC LIMIT 1"
        Try
            Dim comando = New MySqlCommand(SQL, conexion)
            Dim rsConsulta As MySqlDataReader

            rsConsulta = comando.ExecuteReader

            If rsConsulta.Read Then
                txtCodigo.Text = CInt(rsConsulta("codigo")) + 1
                rsConsulta.Close()
            Else
                txtCodigo.Text = 1
            End If
            rsConsulta.Close()
            rsConsulta.Dispose()
            comando.Dispose()

        Catch ex As Exception
            CatchError(ex.Message, ex.StackTrace, SQL)
            End

        End Try

    End Sub

    Private Sub CmdGuardar_Click(sender As Object, e As EventArgs) Handles CmdGuardar.Click

        'Validaciones
        If txtCodigo.Text = "" Then
            Call MsgBox("Falta ingresar código de artículo", vbCritical, "Falta código")
            txtCodigo.Select()
            Exit Sub
        End If

        If txtDescripcion.Text = "" Then
            Call MsgBox("Falta ingresar descripción de artículo", vbCritical, "Falta descripción")
            txtDescripcion.Select()
            Exit Sub
        End If

        'Guardo
        If Nuevo Then
            'Reviso que el código no este cargado para el usuario activo
            SQL = "SELECT * FROM articulos WHERE codigo = '" & txtCodigo.Text & "' AND eliminado = 0 "

            Try
                Dim comando = New MySqlCommand(SQL, conexion)
                Dim rsConsulta As MySqlDataReader

                rsConsulta = comando.ExecuteReader

                If rsConsulta.HasRows Then
                    Call MsgBox("El código ya existe. Por favor coloque otro.", vbCritical, "codigo repetido")
                    rsConsulta.Close()
                    Exit Sub
                End If

                rsConsulta.Close()
                rsConsulta.Dispose()
                comando.Dispose()

            Catch ex As Exception
                CatchError(ex.Message, ex.StackTrace, SQL)
                Exit Sub

            End Try

            SQL = "INSERT INTO articulos(codigo, descripcion) VALUES (@codigo, @descripcion) "
        Else
            SQL = "UPDATE articulos SET codigo = @codigo, descripcion = @descripcion WHERE id = " & id
        End If
        Try
            Dim comando = New MySqlCommand(SQL, conexion) With {
                .CommandType = CommandType.Text
            }
            comando.Parameters.AddWithValue("@codigo", txtCodigo.Text).ToString()
            comando.Parameters.AddWithValue("@descripcion", txtDescripcion.Text).ToString()
            comando.ExecuteNonQuery()
            comando.Dispose()

        Catch ex As Exception
            CatchError(ex.Message, ex.StackTrace, SQL)
            Exit Sub

        End Try

        ArticulosList.Show()
        Me.Close()

    End Sub

    Private Sub CmdSalir_Click(sender As Object, e As EventArgs) Handles cmdSalir.Click

        ArticulosList.Show()
        Me.Close()

    End Sub

    Private Sub TxtCodigo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCodigo.KeyPress

        If e.KeyChar = vbCr Then
            PasarFoco()
        End If

    End Sub

    Private Sub TxtDescripcion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDescripcion.KeyPress

        If e.KeyChar = vbCr Then
            PasarFoco()
        End If

    End Sub

End Class