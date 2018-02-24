Imports System.Data
Imports System.IO
Imports System.Text
Imports System.Data.OleDb
Imports System.Data.Odbc
Imports System.Data.SqlClient
Public Class FrmJefes
    Dim sqlCTDV As New SqlCommand
    Dim sqlfolio As New SqlCommand
    Dim sqldr As SqlDataReader
    Dim sqldrfolio As SqlDataReader
    Private Sub FrmJefes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TBDepto.Text = MenuJefes.TBDepto.Text
        TBTitular.Text = MenuJefes.TBTitular.Text
        'Me.cargalistview()
    End Sub
    Sub buscar_folio()
        Try
            Me.SqlConnection1.Open()
            'CBA2.Items.Clear()
            BtnAutoriza.Enabled = False
            BtnRechazar.Enabled = False
            ListView1.Items.Clear()
            sqlfolio.CommandType = CommandType.Text
            'sqlfolio.CommandText = ("Select Folio,Nombre_art,Fecha_Cap_Req,Cant_Art,Justificacion from Requerimiento where requerimiento.Folio =  '" & TBFolio.Text & "'")
            'sqlfolio.CommandText = ("Select Folio,Nombre_art,Fecha_Cap_Req,Cant_Art,Justificacion,Status_Titular from Requerimiento where requerimiento.Folio =  '" & TBFolio.Text & "'" & "AND Status_Titular =  '" & "N" & "'")
            sqlfolio.CommandText = ("Select Folio,Nombre_art,Fecha_Cap_Req,Cant_Art,Justificacion,Act,Status_Titular,Fecha_Aut_Titular,Status_Sub_Adm,Fecha_Aut_Sub_Adm from Requerimiento where requerimiento.Folio =  '" & TBFolio.Text & "'")
            sqlfolio.Connection = Me.SqlConnection1
            sqldrfolio = sqlfolio.ExecuteReader()
            ' sqldrfolio.Read()
            While (sqldrfolio.Read())
                If sqldrfolio("Status_Titular") = "P" Then
                    BtnAutoriza.Enabled = True
                Else
                    BtnRechazar.Enabled = True
                End If
                With ListView1.Items.Add(sqldrfolio("folio"))
                    .subitems.add(sqldrfolio("nombre_art"))
                    .subitems.add(sqldrfolio("fecha_Cap_Req"))
                    .subitems.add(sqldrfolio("Cant_Art"))
                    .subitems.add(sqldrfolio("Justificacion"))
                    .subitems.add(sqldrfolio("Act"))
                    .subitems.add(sqldrfolio("Status_Titular"))
                    If Not IsDBNull(sqldrfolio("Fecha_Aut_Titular")) Then
                        .subitems.add(sqldrfolio("Fecha_Aut_Titular"))
                    End If
                    .subitems.add(sqldrfolio("Status_Sub_Adm"))
                    If Not IsDBNull(sqldrfolio("Fecha_Aut_Sub_Adm")) Then
                        .subitems.add(sqldrfolio("Fecha_Aut_Sub_Adm"))
                    End If
                End With
            End While
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        sqldrfolio.Close()
        Me.SqlConnection1.Close()
    End Sub
    Sub cargalistview()
        Try
            Me.SqlConnection1.Open()
            ListView1.Items.Clear()
            sqlCTDV.CommandType = CommandType.Text
            'sqlCTDV.CommandText = ("Select Nombre_art,Cve_Art,Cve_Pro from Articulo where Articulo.Cve_pro =  '" & TBCPro.Text & "'")
            sqlCTDV.CommandText = ("Select * from Requerimiento")
            sqlCTDV.Connection = Me.SqlConnection1
            sqldr = sqlCTDV.ExecuteReader()
            ListView1.Items.Clear()
            'DRDView.Read()
            While sqldr.Read()
                With ListView1.Items.Add(sqldr("folio"))
                    .subitems.add(sqldr("nombre_art"))
                    .subitems.add(sqldr("fecha_Cap_Req"))
                    .subitems.add(sqldr("Cant_Art"))
                    .subitems.add(sqldr("Justificacion"))
                    .subitems.add(sqldr("Act"))
                    .subitems.add(sqldr("Status_Titular"))
                    .subitems.add(sqldr("Fecha_Aut_Titular"))
                    .subitems.add(sqldr("Status_Sub_Adm"))
                    .subitems.add(sqldr("Fecha_Aut_Sub_Adm"))
                End With
                'ListView1.Items.Add(sqldr("Nombre_Art"))
                '.subitems.add(sqldr("nombre_art"))
                '.subitems.add(sqldr("fecha_cap_req"))
                'End With
            End While
            sqldr.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        sqldr.Close()
        Me.SqlConnection1.Close()
    End Sub
    Sub Autorizar_Requerimiento()
        Try
            Dim Autoriza As String
            Me.SqlConnection1.Open()
            Autoriza = MsgBox("Esta seguro de Autorizar el Requerimiento ?", MsgBoxStyle.YesNo + MsgBoxStyle.Information, "Guardar")
            If Autoriza = vbYes Then
                'Dim insal As String = ("INSERT into talumno (matricula,nombre)" & "values(" & TBMatricula.Text & "," & TBNombre.Text & ",")
                Dim insal As String = ("UPDATE  Requerimiento SET Status_Titular=@Status_Titular,Fecha_Aut_Titular=@Fecha_Aut_Titular  where  Folio= '" & TBFolio.Text & "'")
                Dim conex1 As New SqlClient.SqlCommand(insal, Me.SqlConnection1)
                conex1.Parameters.Add(New SqlParameter("@Status_Titular", SqlDbType.NVarChar, 1)).Value = "A"
                conex1.Parameters.Add(New SqlParameter("@Fecha_Aut_Titular", SqlDbType.SmallDateTime)).Value = DateTimePicker1.Text

                conex1.CommandText = insal
                conex1.ExecuteNonQuery()
                MsgBox("Requerimiento Autorizado correctamente", , "Guardar")
                Me.SqlConnection1.Close()
            End If
        Catch es As Exception
            MsgBox(es.ToString)
        End Try
    End Sub
    Sub Rechaza_Requerimiento()
        Try
            Dim Autoriza As String
            Me.SqlConnection1.Open()
            Autoriza = MsgBox("Esta seguro de Rechazar el Requerimiento ?", MsgBoxStyle.YesNo + MsgBoxStyle.Information, "Guardar")
            If Autoriza = vbYes Then
                'Dim insal As String = ("INSERT into talumno (matricula,nombre)" & "values(" & TBMatricula.Text & "," & TBNombre.Text & ",")
                Dim insal As String = ("UPDATE  Requerimiento SET Status_Titular=@Status_Titular  where  Folio= '" & TBFolio.Text & "'")
                Dim conex1 As New SqlClient.SqlCommand(insal, Me.SqlConnection1)
                conex1.Parameters.Add(New SqlParameter("@Status_Titular", SqlDbType.NVarChar, 1)).Value = "P"
                conex1.CommandText = insal
                conex1.ExecuteNonQuery()
                MsgBox("Requerimiento Rechazado correctamente", , "Guardar")
                Me.SqlConnection1.Close()
            End If
        Catch es As Exception
            MsgBox(es.ToString)
        End Try
    End Sub
    Private Sub BtnMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnMostrar.Click
        Call buscar_folio()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAutoriza.Click
        Call Autorizar_Requerimiento()
        ListView1.Items.Clear()
        TBFolio.Focus()
    End Sub
    Private Sub BtnRechazar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRechazar.Click
        Call Rechaza_Requerimiento()
        ListView1.Items.Clear()
        TBFolio.Focus()
    End Sub

    Private Sub BtnRegresa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRegresa.Click
        'Me.Hide()
        'MenuJefes.Visible = True
        Me.Close()
    End Sub

End Class