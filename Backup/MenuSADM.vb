Public Class MenuSADM

    Private Sub MenuSADM_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'Me.Hide()
        FRMREQMAT.Show()
    End Sub

    Private Sub BtnAutoriza_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAutoriza.Click
        FrmSubDir.Show()
    End Sub

    Private Sub BtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSalir.Click
        End
    End Sub
End Class