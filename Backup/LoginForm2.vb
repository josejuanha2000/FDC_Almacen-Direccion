Public Class LoginFormSA

    ' TODO: inserte el código para realizar autenticación personalizada usando el nombre de usuario y la contraseña proporcionada 
    ' (Consulte http://go.microsoft.com/fwlink/?LinkId=35339).  
    ' El objeto principal personalizado se puede adjuntar al objeto principal del subproceso actual como se indica a continuación: 
    '     My.User.CurrentPrincipal = CustomPrincipal
    ' donde CustomPrincipal es la implementación de IPrincipal utilizada para realizar la autenticación. 
    ' Posteriormente, My.User devolverá la información de identidad encapsulada en el objeto CustomPrincipal
    ' como el nombre de usuario, nombre para mostrar, etc.
    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        Try
            Dim dts As New Datos2
            Dim func As New FUNCIONES2
            dts.fdcusername = UsernameTextBox.Text
            dts.fdcpassword = PasswordTextBox.Text
            If func.validar(dts) = True Then
                'Dim MenuJ As New MenuJefe
                Call MenuSADM.Show()
                'SplashScreen1.Show()
                Me.Hide()
            Else
                MsgBox("Login failed")
                PasswordTextBox.Clear()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        'Me.Close()
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Me.Close()
    End Sub

    
    Private Sub LoginFormSA_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class
