Imports System.ComponentModel

Public Class frmRegistroVehicular


    Dim costo = 0
    Dim IntervaloHoras As TimeSpan

    'Mostrar fecha'
    Private Sub frmRegistroVehicular_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Mostrar fecha actual'
        lblFecha.Text = DateTime.Now.ToShortDateString()

    End Sub

    'Categoria'
    Private Sub cboTipo_Veh_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTipo_Veh.SelectedIndexChanged

        Dim categoria As String

        categoria = cboTipo_Veh.Text

        If categoria = "Moto" Then
            costo = 800
        End If
        If categoria = "Carro" Then
            costo = 1000
        End If
        If categoria = "Camión" Then
            costo = 1300
        End If

    End Sub

    'Calcular'
    Private Sub btnRegistrar_Click(sender As Object, e As EventArgs) Handles btnCalcular.Click

        Dim placa_num As String
        Dim tipo_v As String
        Dim num_es As String
        Dim horaInicio As DateTime
        Dim horaSalida As DateTime
        Dim total As Integer


        placa_num = txtPlaca.Text
        tipo_v = cboTipo_Veh.Text
        num_es = txtNum_Estacionamiento.Text
        horaInicio = DateTime.Parse(txtHoraInicio.Text)
        horaSalida = DateTime.Parse(txtHoraSalida.Text)
        IntervaloHoras = horaSalida - horaInicio


        total = costo * IntervaloHoras.TotalHours


        'Motos'
        If IntervaloHoras.Minutes >= 15 And cboTipo_Veh.Text = "Moto" Then

            costo = total + 200
        End If
        If IntervaloHoras.Minutes <= 15 And IntervaloHoras.Minutes >= 30 And cboTipo_Veh.Text = "Moto" Then

            costo = total + 400
        End If
        If IntervaloHoras.Minutes <= 30 And IntervaloHoras.Minutes >= 45 And cboTipo_Veh.Text = "Moto" Then

            costo = total + 600
        End If


        'Carros'
        If IntervaloHoras.Minutes <= 15 And cboTipo_Veh.Text = "Carro" Then

            costo = total + 250
        End If
        If IntervaloHoras.Minutes > 15 And IntervaloHoras.Minutes <= 30 And cboTipo_Veh.Text = "Carro" Then

            costo = total + 500
        End If
        If IntervaloHoras.Minutes > 30 And IntervaloHoras.Minutes <= 45 And cboTipo_Veh.Text = "Carro" Then

            costo = total + 750
        End If

        'Camión'
        If IntervaloHoras.Minutes >= 15 And cboTipo_Veh.Text = "Camión" Then

            costo = total + 325
        End If
        If IntervaloHoras.Minutes <= 15 And IntervaloHoras.Minutes >= 30 And cboTipo_Veh.Text = "Camión" Then

            costo = total + 650
        End If
        If IntervaloHoras.Minutes <= 30 And IntervaloHoras.Minutes >= 45 And cboTipo_Veh.Text = "Camión" Then

            costo = total + 975
        End If






        'Catch'

        Try
            If Me.ValidateChildren And txtPlaca.Text <> String.Empty And txtNum_Estacionamiento.Text <> String.Empty Then

                MessageBox.Show("Ticket de Estacionamiento Registrado Correctamente", "Registro de Parqueo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else

                MessageBox.Show("Ingrese los datos solicitados", "Registro de Parqueo", MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try






        dgvInfo.Rows.Insert(0, IntervaloHoras, tipo_v, placa_num, num_es, total)











        'Limpiar TextBox'
        txtPlaca.Clear()
        txtNum_Estacionamiento.Clear()
        txtHoraInicio.Clear()
        txtHoraSalida.Clear()



    End Sub


    'Limpiar'
    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click

        dgvInfo.Rows.Clear()




    End Sub

    'Salir'
    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Dim opcion As DialogResult

        opcion = MessageBox.Show("Realmente desea salir?", "Salir de la APP", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If opcion = DialogResult.Yes Then
            Me.Close()
        End If

    End Sub







    Private Sub cboTipo_Veh_Validating(sender As Object, e As CancelEventArgs) Handles cboTipo_Veh.Validating
        If DirectCast(sender, ComboBox).Text.Length > 0 Then

            Me.IconoError.SetError(sender, "     ")
        Else
            Me.IconoError.SetError(sender, "Dato Obligatorio")
        End If
    End Sub



    Private Sub txtPlaca_Validating(sender As Object, e As CancelEventArgs) Handles txtPlaca.Validating
        If DirectCast(sender, TextBox).Text.Length > 0 Then

            Me.IconoError.SetError(sender, "     ")
        Else
            Me.IconoError.SetError(sender, "Dato Obligatorio")
        End If
    End Sub



    Private Sub txtNum_Estacionamiento_Validating(sender As Object, e As CancelEventArgs) Handles txtNum_Estacionamiento.Validating
        If DirectCast(sender, TextBox).Text.Length > 0 Then

            Me.IconoError.SetError(sender, "     ")
        Else
            Me.IconoError.SetError(sender, "Dato Obligatorio")
        End If
    End Sub





End Class