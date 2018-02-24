<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmJefes
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
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.BtnMostrar = New System.Windows.Forms.Button
        Me.TBFolio = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker
        Me.Label3 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.TBTitular = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.TBDepto = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.ListView1 = New System.Windows.Forms.ListView
        Me.FOLIO = New System.Windows.Forms.ColumnHeader
        Me.NOMBRE_ART = New System.Windows.Forms.ColumnHeader
        Me.FECHA_CAPTURA = New System.Windows.Forms.ColumnHeader
        Me.CAN_ART = New System.Windows.Forms.ColumnHeader
        Me.JUSTIFICACION = New System.Windows.Forms.ColumnHeader
        Me.ACTIVO = New System.Windows.Forms.ColumnHeader
        Me.STATUS_TITULAR = New System.Windows.Forms.ColumnHeader
        Me.FECHA_AUT_TITULAR = New System.Windows.Forms.ColumnHeader
        Me.STATUS_SUB_ADM = New System.Windows.Forms.ColumnHeader
        Me.FECHA_AUT_SUB_ADM = New System.Windows.Forms.ColumnHeader
        Me.BtnAutoriza = New System.Windows.Forms.Button
        Me.SqlConnection1 = New System.Data.SqlClient.SqlConnection
        Me.BtnRechazar = New System.Windows.Forms.Button
        Me.BtnRegresa = New System.Windows.Forms.Button
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.BtnMostrar)
        Me.GroupBox2.Controls.Add(Me.TBFolio)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.DateTimePicker1)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(281, 99)
        Me.GroupBox2.TabIndex = 9
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Req."
        '
        'BtnMostrar
        '
        Me.BtnMostrar.Location = New System.Drawing.Point(200, 68)
        Me.BtnMostrar.Name = "BtnMostrar"
        Me.BtnMostrar.Size = New System.Drawing.Size(47, 23)
        Me.BtnMostrar.TabIndex = 12
        Me.BtnMostrar.Text = "Mostrar"
        Me.BtnMostrar.UseVisualStyleBackColor = True
        '
        'TBFolio
        '
        Me.TBFolio.Location = New System.Drawing.Point(118, 70)
        Me.TBFolio.Name = "TBFolio"
        Me.TBFolio.Size = New System.Drawing.Size(60, 20)
        Me.TBFolio.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(55, 71)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(55, 16)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "FOLIO:"
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Enabled = False
        Me.DateTimePicker1.Location = New System.Drawing.Point(19, 31)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(228, 20)
        Me.DateTimePicker1.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(16, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Fecha:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TBTitular)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.TBDepto)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Location = New System.Drawing.Point(309, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(325, 104)
        Me.GroupBox1.TabIndex = 8
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Datos:"
        '
        'TBTitular
        '
        Me.TBTitular.Enabled = False
        Me.TBTitular.Location = New System.Drawing.Point(9, 71)
        Me.TBTitular.Name = "TBTitular"
        Me.TBTitular.Size = New System.Drawing.Size(281, 20)
        Me.TBTitular.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(5, 55)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Titular:"
        '
        'TBDepto
        '
        Me.TBDepto.Enabled = False
        Me.TBDepto.Location = New System.Drawing.Point(9, 32)
        Me.TBDepto.Name = "TBDepto"
        Me.TBDepto.Size = New System.Drawing.Size(281, 20)
        Me.TBDepto.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(6, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(90, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Departamento:"
        '
        'ListView1
        '
        Me.ListView1.AllowColumnReorder = True
        Me.ListView1.CausesValidation = False
        Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.FOLIO, Me.NOMBRE_ART, Me.FECHA_CAPTURA, Me.CAN_ART, Me.JUSTIFICACION, Me.ACTIVO, Me.STATUS_TITULAR, Me.FECHA_AUT_TITULAR, Me.STATUS_SUB_ADM, Me.FECHA_AUT_SUB_ADM})
        Me.ListView1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListView1.FullRowSelect = True
        Me.ListView1.GridLines = True
        Me.ListView1.Location = New System.Drawing.Point(31, 134)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(892, 220)
        Me.ListView1.TabIndex = 10
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'FOLIO
        '
        Me.FOLIO.Text = "FOLIO"
        Me.FOLIO.Width = 50
        '
        'NOMBRE_ART
        '
        Me.NOMBRE_ART.Text = "NOMBRE_ART"
        Me.NOMBRE_ART.Width = 294
        '
        'FECHA_CAPTURA
        '
        Me.FECHA_CAPTURA.Text = "FECHA_CAPTURA"
        Me.FECHA_CAPTURA.Width = 89
        '
        'CAN_ART
        '
        Me.CAN_ART.Text = "CANT_ART"
        '
        'JUSTIFICACION
        '
        Me.JUSTIFICACION.Text = "JUSTIFICACION"
        Me.JUSTIFICACION.Width = 127
        '
        'ACTIVO
        '
        Me.ACTIVO.Text = "ACT"
        '
        'STATUS_TITULAR
        '
        Me.STATUS_TITULAR.Text = "STATUS_TITULAR"
        '
        'FECHA_AUT_TITULAR
        '
        Me.FECHA_AUT_TITULAR.Text = "FECHA_AUT_TITULAR"
        '
        'STATUS_SUB_ADM
        '
        Me.STATUS_SUB_ADM.Text = "STATUS_SUB_ADM"
        '
        'FECHA_AUT_SUB_ADM
        '
        Me.FECHA_AUT_SUB_ADM.Text = "FECHA_AUT_SUB_ADM"
        '
        'BtnAutoriza
        '
        Me.BtnAutoriza.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.BtnAutoriza.Enabled = False
        Me.BtnAutoriza.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnAutoriza.Location = New System.Drawing.Point(626, 374)
        Me.BtnAutoriza.Name = "BtnAutoriza"
        Me.BtnAutoriza.Size = New System.Drawing.Size(106, 35)
        Me.BtnAutoriza.TabIndex = 11
        Me.BtnAutoriza.Text = "Autorizar Compra"
        Me.BtnAutoriza.UseVisualStyleBackColor = False
        '
        'SqlConnection1
        '
        Me.SqlConnection1.ConnectionString = "Data Source=COLMASQLFDC01\FACDYCDES;Initial Catalog=ALMACEN;Integrated Security=T" & _
            "rue"
        Me.SqlConnection1.FireInfoMessageEventOnUserErrors = False
        '
        'BtnRechazar
        '
        Me.BtnRechazar.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.BtnRechazar.Enabled = False
        Me.BtnRechazar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnRechazar.Location = New System.Drawing.Point(42, 374)
        Me.BtnRechazar.Name = "BtnRechazar"
        Me.BtnRechazar.Size = New System.Drawing.Size(106, 35)
        Me.BtnRechazar.TabIndex = 12
        Me.BtnRechazar.Text = "Rechazar Compra"
        Me.BtnRechazar.UseVisualStyleBackColor = False
        '
        'BtnRegresa
        '
        Me.BtnRegresa.Location = New System.Drawing.Point(367, 374)
        Me.BtnRegresa.Name = "BtnRegresa"
        Me.BtnRegresa.Size = New System.Drawing.Size(90, 35)
        Me.BtnRegresa.TabIndex = 13
        Me.BtnRegresa.Text = "Regresar"
        Me.BtnRegresa.UseVisualStyleBackColor = True
        '
        'FrmJefes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(937, 426)
        Me.Controls.Add(Me.BtnRegresa)
        Me.Controls.Add(Me.BtnRechazar)
        Me.Controls.Add(Me.BtnAutoriza)
        Me.Controls.Add(Me.ListView1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "FrmJefes"
        Me.Text = "Autorización Titular"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents TBFolio As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TBTitular As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TBDepto As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents BtnAutoriza As System.Windows.Forms.Button
    Friend WithEvents SqlConnection1 As System.Data.SqlClient.SqlConnection
    Friend WithEvents NOMBRE_ART As System.Windows.Forms.ColumnHeader
    Friend WithEvents FECHA_CAPTURA As System.Windows.Forms.ColumnHeader
    Friend WithEvents FOLIO As System.Windows.Forms.ColumnHeader
    Friend WithEvents CAN_ART As System.Windows.Forms.ColumnHeader
    Friend WithEvents JUSTIFICACION As System.Windows.Forms.ColumnHeader
    Friend WithEvents BtnMostrar As System.Windows.Forms.Button
    Friend WithEvents BtnRechazar As System.Windows.Forms.Button
    Friend WithEvents ACTIVO As System.Windows.Forms.ColumnHeader
    Friend WithEvents BtnRegresa As System.Windows.Forms.Button
    Friend WithEvents FECHA_AUT_TITULAR As System.Windows.Forms.ColumnHeader
    Friend WithEvents STATUS_SUB_ADM As System.Windows.Forms.ColumnHeader
    Friend WithEvents FECHA_AUT_SUB_ADM As System.Windows.Forms.ColumnHeader
    Friend WithEvents STATUS_TITULAR As System.Windows.Forms.ColumnHeader
End Class
