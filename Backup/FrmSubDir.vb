Imports System.Data
Imports System.IO
Imports System.Text
Imports System.Data.OleDb
Imports System.Data.Odbc
Imports System.Data.SqlClient
Public Class FrmSubDir
    Dim sqlfolio As New SqlCommand
    Dim sqldrfolio As SqlDataReader
    
    Private Sub FrmSubDir_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call carga_folio()
    End Sub
    Sub carga_folio()
        Try
            Me.SqlConnection1.Open()
            sqlfolio.CommandType = CommandType.Text
            sqlfolio.CommandText = ("select distinct folio  from requerimiento  where requerimiento.Status_Sub_Adm  =   'P' order by folio asc")
            '& "AND Status_Titular='" & "S" & "'")
            'sqlfolio.CommandText = ("Select Folio,Nombre_art,Fecha_Cap_Req,Cant_Art,Justificacion,Status_Titular from Requerimiento where requerimiento.Folio =  '" & TBFolio.Text & "'" & "AND Status_Titular =  '" & "N" & "'")
            sqlfolio.Connection = Me.SqlConnection1
            sqldrfolio = sqlfolio.ExecuteReader()
            While sqldrfolio.Read = True
                'CBFolioSDA.Text = sqldrfolio("FOLIO")
                CBFolio.Items.Add(sqldrfolio.Item(0))
            End While
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        sqldrfolio.Close()
        Me.SqlConnection1.Close()
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
            sqlfolio.CommandText = ("Select Depto,Titular_Depto,Folio,Nombre_art,Fecha_Cap_Req,Cant_Art,Justificacion,Status_Titular,Status_Sub_Adm,Act from Requerimiento where requerimiento.Folio =  '" & CBFolio.Text & "'")
            sqlfolio.Connection = Me.SqlConnection1
            sqldrfolio = sqlfolio.ExecuteReader()
            ' sqldrfolio.Read()

            While (sqldrfolio.Read())
                TBDepto.Text = sqldrfolio("Depto")
                TBTitular.Text = sqldrfolio("Titular_Depto")

                If sqldrfolio("Status_Sub_Adm") = "P" Then
                    BtnAutoriza.Enabled = True
                Else
                    BtnRechazar.Enabled = True
                End If

                With ListView1.Items.Add(sqldrfolio("folio"))
                    .subitems.add(sqldrfolio("nombre_art"))
                    .subitems.add(sqldrfolio("fecha_Cap_Req"))
                    .subitems.add(sqldrfolio("Cant_Art"))
                    .subitems.add(sqldrfolio("Justificacion"))
                    .subitems.add(sqldrfolio("Status_Titular"))
                    '.subitems.add(sqldrfolio("Fecha_Aut_Titular"))
                    .subitems.add(sqldrfolio("Status_Sub_Adm"))
                    '.subitems.add(sqldrfolio("Fecha_Aut_Sub_Adm"))
                    .subitems.add(sqldrfolio("Act"))
                End With
            End While
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        sqldrfolio.Close()
        Me.SqlConnection1.Close()
    End Sub
    Private Sub BtnMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnMostrar.Click
        Call buscar_folio()
    End Sub
    Sub Autorizar_Requerimiento()
        Try
            Dim Autoriza As String
            Me.SqlConnection1.Open()
            Autoriza = MsgBox("Esta seguro de Autorizar el Requerimiento ?", MsgBoxStyle.YesNo + MsgBoxStyle.Information, "Guardar")
            If Autoriza = vbYes Then
                'Dim insal As String = ("INSERT into talumno (matricula,nombre)" & "values(" & TBMatricula.Text & "," & TBNombre.Text & ",")
                Dim insal As String = ("UPDATE  Requerimiento SET Status_Sub_Adm=@Status_Sub_Adm,Fecha_Aut_Sub_Adm=@Fecha_Aut_Sub_Adm  where  Folio= '" & CBFolio.Text & "'")
                Dim conex1 As New SqlClient.SqlCommand(insal, Me.SqlConnection1)
                conex1.Parameters.Add(New SqlParameter("@Status_Sub_Adm", SqlDbType.NVarChar, 1)).Value = "A"
                conex1.Parameters.Add(New SqlParameter("@Fecha_Aut_Sub_Adm", SqlDbType.SmallDateTime)).Value = DateTimePicker1.Text
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
                Dim insal As String = ("UPDATE  Requerimiento SET Status_Sub_Adm=@Status_Sub_Adm  where  Folio= '" & CBFolio.Text & "'")
                Dim conex1 As New SqlClient.SqlCommand(insal, Me.SqlConnection1)
                conex1.Parameters.Add(New SqlParameter("@Status_Sub_Adm", SqlDbType.NVarChar, 1)).Value = "P"
                conex1.CommandText = insal
                conex1.ExecuteNonQuery()
                MsgBox("Requerimiento Rechazado correctamente", , "Guardar")
                Me.SqlConnection1.Close()
            End If
        Catch es As Exception
            MsgBox(es.ToString)
        End Try
    End Sub
    Private Sub BtnAutoriza_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAutoriza.Click
        Call Autorizar_Requerimiento()
        ListView1.Items.Clear()
        CBFolio.Focus()
    End Sub
    Private Sub BtnRechazar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRechazar.Click
        Call Rechaza_Requerimiento()
        ListView1.Items.Clear()
        CBFolio.Focus()
    End Sub
End Class