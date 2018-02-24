<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Req_Materia
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.CBPRO = New System.Windows.Forms.ComboBox
        Me.TBCvePro = New System.Windows.Forms.TextBox
        Me.SuspendLayout()
        '
        'CBPRO
        '
        Me.CBPRO.FormattingEnabled = True
        Me.CBPRO.Location = New System.Drawing.Point(51, 63)
        Me.CBPRO.Name = "CBPRO"
        Me.CBPRO.Size = New System.Drawing.Size(124, 21)
        Me.CBPRO.TabIndex = 0
        '
        'TBCvePro
        '
        Me.TBCvePro.Location = New System.Drawing.Point(52, 91)
        Me.TBCvePro.Name = "TBCvePro"
        Me.TBCvePro.Size = New System.Drawing.Size(65, 20)
        Me.TBCvePro.TabIndex = 1
        '
        'Req_Materia
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(637, 375)
        Me.Controls.Add(Me.TBCvePro)
        Me.Controls.Add(Me.CBPRO)
        Me.Name = "Req_Materia"
        Me.Text = "Req_Materia"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CBPRO As System.Windows.Forms.ComboBox
    Friend WithEvents TBCvePro As System.Windows.Forms.TextBox
End Class
