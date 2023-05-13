Imports System.ComponentModel

Public Class frmLogin


    'Esconder contraseña'
    Private Sub txtPassword_TextChanged(sender As Object, e As EventArgs) Handles txtPassword.TextChanged

        txtPassword.PasswordChar = "*"
    End Sub

    'Boton Aceptar'
    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click

        Dim registro As New Form

        Try
            If Me.ValidateChildren And txtUser.Text = "DiegoT" And txtPassword.Text = "2403" Then
                MessageBox.Show("Te damos la bienvenido " + txtUser.Text)
                Me.Hide()
                registro = frmRegistroVehicular
                registro.Show()

            Else
                MessageBox.Show("El nombre de usuario o la contraseña no son correctos")
                txtUser.Clear()
                txtPassword.Clear()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


    End Sub

    'Salir'
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim opcion As DialogResult

        opcion = MessageBox.Show("Realmente desea salir?", "Salir de la APP", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If opcion = DialogResult.Yes Then
            Me.Close()
        End If
    End Sub



    Private Sub txtUser_Validating(sender As Object, e As CancelEventArgs) Handles txtUser.Validating
        If DirectCast(sender, TextBox).Text.Length > 0 Then

            Me.IconoError.SetError(sender, "     ")
        Else
            Me.IconoError.SetError(sender, "Ingrese el usuario")
        End If
    End Sub

    Private Sub txtPassword_Validating(sender As Object, e As CancelEventArgs) Handles txtPassword.Validating
        If DirectCast(sender, TextBox).Text.Length > 0 Then

            Me.IconoError.SetError(sender, "     ")
        Else
            Me.IconoError.SetError(sender, "Ingrese su contraseña")
        End If
    End Sub
End Class