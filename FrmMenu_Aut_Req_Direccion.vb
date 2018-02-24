Public Class FrmMenu_Aut_Req_Direccion

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        FRMREQMAT.Show()
        'Hide()
    End Sub
    Private Sub BtnAutoriza_Click(sender As Object, e As EventArgs) Handles BtnAutoriza.Click
        FrmJefes.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Frm_Req_Mat_Aut_Direccion.Show()
    End Sub
    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles BtnSalir.Click
        End
    End Sub

    Private Sub FrmMenu_Aut_Req_Direccion_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class