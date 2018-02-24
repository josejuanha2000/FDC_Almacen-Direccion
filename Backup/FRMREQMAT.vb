Imports System.Data
Imports System.IO
Imports System.Text
Imports System.Data.OleDb
Imports System.Data.Odbc
Imports System.Data.SqlClient
Public Class FRMREQMAT
    Inherits System.Windows.Forms.Form

    Dim cbprod1 As New SqlCommand
    Dim cbprod2 As New SqlCommand
    Dim DAPRODUCTO As SqlDataReader

    Dim CTArt1 As New SqlCommand
    Dim CTArt2 As New SqlCommand
    Dim CTArt3 As New SqlCommand
    Dim CTArt4 As New SqlCommand
    Dim CTArt5 As New SqlCommand
    Dim CTArt6 As New SqlCommand
    Dim CTArt7 As New SqlCommand
    Dim CTArt8 As New SqlCommand
    Dim CTArt9 As New SqlCommand
    Dim CTArt10 As New SqlCommand

    Dim CTBTArt1 As New SqlCommand
    Dim CTBTArt2 As New SqlCommand
    Dim CTBTArt3 As New SqlCommand
    Dim CTBTArt4 As New SqlCommand
    Dim CTBTArt5 As New SqlCommand
    Dim CTBTArt6 As New SqlCommand
    Dim CTBTArt7 As New SqlCommand
    Dim CTBTArt8 As New SqlCommand
    Dim CTBTArt9 As New SqlCommand
    Dim CTBTArt10 As New SqlCommand

    Dim cbart1 As New SqlCommand
    Dim cbart2 As New SqlCommand
    Dim cbart3 As New SqlCommand

    Dim DAARTICULO1 As SqlDataReader
    Dim DAARTICULO2 As SqlDataReader
    Dim DAARTICULO3 As SqlDataReader
    Dim DAARTICULO4 As SqlDataReader
    Dim DAARTICULO5 As SqlDataReader
    Dim DAARTICULO6 As SqlDataReader
    Dim DAARTICULO7 As SqlDataReader
    Dim DAARTICULO8 As SqlDataReader
    Dim DAARTICULO9 As SqlDataReader
    Dim DAARTICULO10 As SqlDataReader

    Dim SW As Integer = 0
    Dim req1 As Integer = 0
    Dim req2 As Integer = 0
    Dim req3 As Integer = 0
    Dim req4 As Integer = 0
    Dim req5 As Integer = 0
    Dim req6 As Integer = 0
    Dim req7 As Integer = 0
    Dim req8 As Integer = 0
    Dim req9 As Integer = 0
    Dim req10 As Integer = 0
    Dim clave_producto As Char
    Dim Clave_articulo As Char
    'Dim tit As Char
    'Dim depto As Char


    Private Sub FRMREQMAT_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        TBDepto.Text = MenuJefes.TBDepto.Text
        TBTitular.Text = MenuJefes.TBTitular.Text

        Call buscar_ultimo_folio()
        Call cargar_producto()
        'Call cargar_Art()
    End Sub
    Sub buscar_ultimo_folio()
        Try
            Me.SqlConnection1.Open()
            Dim comsql As New SqlClient.SqlCommand
            comsql.Connection = Me.SqlConnection1
            comsql.CommandText = ("select top 1 * from Requerimiento order by folio desc")
            Dim DRFolio As SqlClient.SqlDataReader
            DRFolio = comsql.ExecuteReader(CommandBehavior.CloseConnection)
            DRFolio.Read()
            TBFolio.Text = DRFolio("Folio") + 1
            DRFolio.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Me.SqlConnection1.Close()
    End Sub
    Sub buscar_ultimo_folio_ocupado()
        Try
            Me.SqlConnection1.Open()
            Dim comsql As New SqlClient.SqlCommand
            comsql.Connection = Me.SqlConnection1
            comsql.CommandText = ("select top 1 * from Requerimiento order by folio desc")
            Dim DRFolio As SqlClient.SqlDataReader
            DRFolio = comsql.ExecuteReader(CommandBehavior.CloseConnection)
            DRFolio.Read()
            If TBFolio.Text = DRFolio("Folio") Then
                SW = 1
                MsgBox("El folio ya fue ocupado!", , " Folio")
                TBFolio.Text = DRFolio("Folio") + 1
                MsgBox("El nuevo Folio es :" & TBFolio.Text & " Nuevo Folio")
            End If
            DRFolio.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Me.SqlConnection1.Close()
    End Sub

    Sub cargar_producto()
        Try
            Me.SqlConnection1.Open()
            cbprod1.CommandType = CommandType.Text
            cbprod1.CommandText = ("select Nombre_Pro from producto")
            'cbprod.CommandText = ("select cve_pro from producto")
            cbprod1.Connection = Me.SqlConnection1
            DAPRODUCTO = cbprod1.ExecuteReader()
            While DAPRODUCTO.Read = True
                CBProducto.Items.Add(DAPRODUCTO.Item(0))
            End While
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        cbprod2.CommandType = CommandType.StoredProcedure
        cbprod2.Connection = Me.SqlConnection1
        cbprod2.CommandText = ("Buscar_Articulo")
        cbprod2.Parameters.Add("var_cve_producto", SqlDbType.NVarChar, 2)
        DAPRODUCTO.Close()
        Me.SqlConnection1.Close()
        'Call cargar_Art()
    End Sub
    Private Sub CBProducto_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBProducto.SelectedIndexChanged
        'Dim cvepro As Char
        Try
            Me.SqlConnection1.Open()
            cbprod2.Parameters("var_cve_producto").Value = CBProducto.SelectedItem
            DAPRODUCTO = cbprod2.ExecuteReader()
            DAPRODUCTO.Read()
            TBCpro.Text = CStr(DAPRODUCTO("Cve_pro").toupper)
            'TextBox2.Text = DAPRODUCTO("Cve_pro")
            'Select CBProducto.SelectedItem
            '   Case "AUDIOVISUAL"
            'cvepro = "AU"
            '   Case "CAFETERIA"
            ' cvepro = "CA"
            '    Case "COMPUTACION"
            'cvepro = "CO"
            'End Select
            '''''''''''''''''''''''''''''''''''''''''''''''
            'While DAPRODUCTO.Read = True
            'CBA1.Items.Add(DAPRODUCTO.Item(0))
            'CBA2.Items.Add(DAPRODUCTO.Item(0))
            ' End While
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Me.SqlConnection1.Close()
        'Call cargar_Art1()
        'Call cargar_Art2()
    End Sub
    Sub limpiar_formulario()
        CBA1.Items.Clear()
        CBA2.Items.Clear()
        CBA3.Items.Clear()
        CBA4.Items.Clear()
        CBA5.Items.Clear()
        CBA6.Items.Clear()
        CBA7.Items.Clear()
        CBA8.Items.Clear()
        CBA9.Items.Clear()
        CBA10.Items.Clear()

        CBA1.Enabled = False
        CBA2.Enabled = False
        CBA3.Enabled = False
        CBA4.Enabled = False
        CBA5.Enabled = False
        CBA6.Enabled = False
        CBA7.Enabled = False
        CBA8.Enabled = False
        CBA9.Enabled = False
        CBA10.Enabled = False

        TB1.Clear()
        TB2.Clear()
        TB3.Clear()
        TB4.Clear()
        TB5.Clear()
        TB6.Clear()
        TB7.Clear()
        TB8.Clear()
        TB9.Clear()
        TB10.Clear()

        TB1.Enabled = False
        TB2.Enabled = False
        TB3.Enabled = False
        TB4.Enabled = False
        TB5.Enabled = False
        TB6.Enabled = False
        TB7.Enabled = False
        TB8.Enabled = False
        TB9.Enabled = False
        TB10.Enabled = False


        NUpDown1.Enabled = False
        NUpDown2.Enabled = False
        NUpDown3.Enabled = False
        NUpDown4.Enabled = False
        NUpDown5.Enabled = False
        NUpDown6.Enabled = False
        NUpDown7.Enabled = False
        NUpDown8.Enabled = False
        NUpDown9.Enabled = False
        NUpDown10.Enabled = False

        CheckBox1.Checked = False
        CheckBox2.Checked = False
        CheckBox3.Checked = False
        CheckBox4.Checked = False
        CheckBox5.Checked = False
        CheckBox6.Checked = False
        CheckBox7.Checked = False
        CheckBox8.Checked = False
        CheckBox9.Checked = False
        CheckBox10.Checked = False

    End Sub
    Sub cargar_Art1()
        Try
            Me.SqlConnection1.Open()
            'Dim CBART As New SqlClient.SqlCommand
            CBA1.Items.Clear()
            'CBA2.Items.Clear()
            'CBA2.Items.Clear()
            'CBA3.Items.Clear()
            CTArt1.CommandType = CommandType.Text
            'cbart1.CommandText = ("Select Nombre_art,Cve_Art,Cve_Pro from Articulo where Articulo.Cve_pro =  '" & TBCPro.Text & "'")
            CTArt1.CommandText = ("Select Nombre_art,Cve_Art,Cve_Pro from Articulo where Articulo.Cve_pro =  '" & TBCpro.Text & "'order by Nombre_Art Asc")
            'cbart1.CommandText = ("Select Nombre_art,Cve_Art,Cve_Pro from Articulo where Articulo.Cve_pro =  'AU'")
            CTArt1.Connection = Me.SqlConnection1
            'EJEMPLO'' "select * from clientes where rfc = '" & rfctxt.text & " ' "
            'cbart1.CommandText = ("Select nombre_art from Articulo where Articulo.Cve_pro = 'AU'")
            DAARTICULO1 = CTArt1.ExecuteReader()

            'DAARTICULO.Read()
            While DAARTICULO1.Read = True
                CBA1.Items.Add(DAARTICULO1.Item(0))
                'CBA2.Items.Add(DAARTICULO1.Item(0))
                'CBA3.Items.Add(DAARTICULO1.Item(0))
                'TextBox1.Text = DAARTICULO("Cve_Art")
            End While
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        'cbart1.CommandType = CommandType.StoredProcedure
        'cbart1.Connection = Me.SqlConnection1
        'cbart1.CommandText = ("Cargar_Articulo")
        'cbart1.Parameters.Add("var_cve_Articulo", SqlDbType.NVarChar, 5)
        DAARTICULO1.Close()
        Me.SqlConnection1.Close()
    End Sub
    Sub cargar_Art2()
        Try
            Me.SqlConnection1.Open()
            CBA2.Items.Clear()
            CTArt2.CommandType = CommandType.Text
            CTArt2.CommandText = ("Select Nombre_art,Cve_Art,Cve_Pro from Articulo where Articulo.Cve_pro =  '" & TBCpro.Text & "'order by Nombre_Art Asc")
            CTArt2.Connection = Me.SqlConnection1
            DAARTICULO2 = CTArt2.ExecuteReader()
            'DAARTICULO2.Read()
            While DAARTICULO2.Read = True
                CBA2.Items.Add(DAARTICULO2.Item(0))
            End While
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        DAARTICULO2.Close()
        Me.SqlConnection1.Close()
    End Sub
    Sub cargar_Art3()
        Try
            Me.SqlConnection1.Open()
            CBA3.Items.Clear()
            CTArt3.CommandType = CommandType.Text
            CTArt3.CommandText = ("Select Nombre_art,Cve_Art,Cve_Pro from Articulo where Articulo.Cve_pro =  '" & TBCpro.Text & "'order by Nombre_Art Asc")
            CTArt3.Connection = Me.SqlConnection1
            DAARTICULO3 = CTArt3.ExecuteReader()
            While DAARTICULO3.Read = True
                CBA3.Items.Add(DAARTICULO3.Item(0))
            End While
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        DAARTICULO3.Close()
        Me.SqlConnection1.Close()
    End Sub
    Sub cargar_Art4()
        Try
            Me.SqlConnection1.Open()
            CBA4.Items.Clear()
            CTArt4.CommandType = CommandType.Text
            CTArt4.CommandText = ("Select Nombre_art,Cve_Art,Cve_Pro from Articulo where Articulo.Cve_pro =  '" & TBCpro.Text & "'order by Nombre_Art Asc")
            CTArt4.Connection = Me.SqlConnection1
            DAARTICULO4 = CTArt4.ExecuteReader()
            While DAARTICULO4.Read = True
                CBA4.Items.Add(DAARTICULO4.Item(0))
            End While
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        DAARTICULO4.Close()
        Me.SqlConnection1.Close()
    End Sub
    Sub cargar_Art5()
        Try
            Me.SqlConnection1.Open()
            CBA5.Items.Clear()
            CTArt5.CommandType = CommandType.Text
            CTArt5.CommandText = ("Select Nombre_art,Cve_Art,Cve_Pro from Articulo where Articulo.Cve_pro =  '" & TBCpro.Text & "'order by Nombre_Art Asc")
            CTArt5.Connection = Me.SqlConnection1
            DAARTICULO5 = CTArt5.ExecuteReader()
            While DAARTICULO5.Read = True
                CBA5.Items.Add(DAARTICULO5.Item(0))
            End While
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        DAARTICULO5.Close()
        Me.SqlConnection1.Close()
    End Sub
    Sub cargar_Art6()
        Try
            Me.SqlConnection1.Open()
            CBA6.Items.Clear()
            CTArt6.CommandType = CommandType.Text
            CTArt6.CommandText = ("Select Nombre_art,Cve_Art,Cve_Pro from Articulo where Articulo.Cve_pro =  '" & TBCpro.Text & "'order by Nombre_Art Asc")
            CTArt6.Connection = Me.SqlConnection1
            DAARTICULO6 = CTArt6.ExecuteReader()
            While DAARTICULO6.Read = True
                CBA6.Items.Add(DAARTICULO6.Item(0))
            End While
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        DAARTICULO6.Close()
        Me.SqlConnection1.Close()
    End Sub
    Sub cargar_Art7()
        Try
            Me.SqlConnection1.Open()
            CBA7.Items.Clear()
            CTArt7.CommandType = CommandType.Text
            CTArt7.CommandText = ("Select Nombre_art,Cve_Art,Cve_Pro from Articulo where Articulo.Cve_pro =  '" & TBCpro.Text & "'order by Nombre_Art Asc")
            CTArt7.Connection = Me.SqlConnection1
            DAARTICULO7 = CTArt7.ExecuteReader()
            While DAARTICULO7.Read = True
                CBA7.Items.Add(DAARTICULO7.Item(0))
            End While
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        DAARTICULO7.Close()
        Me.SqlConnection1.Close()
    End Sub
    Sub cargar_Art8()
        Try
            Me.SqlConnection1.Open()
            CBA8.Items.Clear()
            CTArt8.CommandType = CommandType.Text
            CTArt8.CommandText = ("Select Nombre_art,Cve_Art,Cve_Pro from Articulo where Articulo.Cve_pro =  '" & TBCpro.Text & "'order by Nombre_Art Asc")
            CTArt8.Connection = Me.SqlConnection1
            DAARTICULO8 = CTArt8.ExecuteReader()
            While DAARTICULO8.Read = True
                CBA8.Items.Add(DAARTICULO8.Item(0))
            End While
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        DAARTICULO7.Close()
        Me.SqlConnection1.Close()
    End Sub
    Sub cargar_Art9()
        Try
            Me.SqlConnection1.Open()
            CBA9.Items.Clear()
            CTArt9.CommandType = CommandType.Text
            CTArt9.CommandText = ("Select Nombre_art,Cve_Art,Cve_Pro from Articulo where Articulo.Cve_pro =  '" & TBCpro.Text & "'order by Nombre_Art Asc")
            CTArt9.Connection = Me.SqlConnection1
            DAARTICULO9 = CTArt9.ExecuteReader()
            While DAARTICULO9.Read = True
                CBA9.Items.Add(DAARTICULO9.Item(0))
            End While
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        DAARTICULO9.Close()
        Me.SqlConnection1.Close()
    End Sub
    Sub cargar_Art10()
        Try
            Me.SqlConnection1.Open()
            CBA10.Items.Clear()
            CTArt10.CommandType = CommandType.Text
            CTArt10.CommandText = ("Select Nombre_art,Cve_Art,Cve_Pro from Articulo where Articulo.Cve_pro =  '" & TBCpro.Text & "'order by Nombre_Art Asc")
            CTArt10.Connection = Me.SqlConnection1
            DAARTICULO10 = CTArt10.ExecuteReader()
            While DAARTICULO10.Read = True
                CBA10.Items.Add(DAARTICULO10.Item(0))
            End While
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        DAARTICULO10.Close()
        Me.SqlConnection1.Close()
    End Sub
    Private Sub CBA1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBA1.SelectedIndexChanged
        Try
            Me.SqlConnection1.Open()
            CTBTArt1.CommandType = CommandType.Text
            CTBTArt1.CommandText = ("Select Cve_Art,Cve_Pro from Articulo where Articulo.NOMBRE_ART =  '" & CBA1.Text & "'")
            'cbart1.CommandText = ("Select Cve_art from Articulo where Articulo.Cve_pro =  '" & TBCPro.Text & "'")
            CTBTArt1.Connection = Me.SqlConnection1
            DAARTICULO1 = CTBTArt1.ExecuteReader()
            'DAARTICULO.Read()
            While DAARTICULO1.Read
                'CBA2.Items.Add(DAARTICULO.Item(0))
                'Me.TextBox1.Text = DAARTICULO("Cve_Art")
                Me.Label21.Text = (DAARTICULO1("cve_art"))
                'DAARTICULO.NextResult()
                'Me.TextBox1.Text = DAARTICULO("Cve_Art")
            End While
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        DAARTICULO1.Close()
        CTBTArt1.Connection.Close()
        Me.SqlConnection1.Close()
    End Sub
    Private Sub CBA2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBA2.SelectedIndexChanged
        Try
            Me.SqlConnection1.Open()
            CTBTArt2.CommandType = CommandType.Text
            CTBTArt2.CommandText = ("Select Cve_Art,Cve_Pro from Articulo where Articulo.NOMBRE_ART =  '" & CBA2.Text & "'")
            CTBTArt2.Connection = Me.SqlConnection1
            DAARTICULO2 = CTBTArt2.ExecuteReader()
            While DAARTICULO2.Read
                Me.Label22.Text = (DAARTICULO2("cve_art"))
            End While
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        DAARTICULO2.Close()
        Me.SqlConnection1.Close()
    End Sub
    Private Sub CBA3_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBA3.SelectedIndexChanged
        Try
            Me.SqlConnection1.Open()
            CTBTArt3.CommandType = CommandType.Text
            CTBTArt3.CommandText = ("Select Cve_Art,Cve_Pro from Articulo where Articulo.NOMBRE_ART =  '" & CBA3.Text & "'")
            CTBTArt3.Connection = Me.SqlConnection1
            DAARTICULO3 = CTBTArt3.ExecuteReader()
            While DAARTICULO3.Read
                Me.Label23.Text = (DAARTICULO3("cve_art"))
            End While
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        DAARTICULO3.Close()
        Me.SqlConnection1.Close()
    End Sub
    Private Sub CBA4_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBA4.SelectedIndexChanged
        Try
            Me.SqlConnection1.Open()
            CTBTArt4.CommandType = CommandType.Text
            CTBTArt4.CommandText = ("Select Cve_Art,Cve_Pro from Articulo where Articulo.NOMBRE_ART =  '" & CBA4.Text & "'")
            CTBTArt4.Connection = Me.SqlConnection1
            DAARTICULO4 = CTBTArt4.ExecuteReader()
            While DAARTICULO4.Read
                Me.Label24.Text = (DAARTICULO4("cve_art"))
            End While
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        DAARTICULO4.Close()
        Me.SqlConnection1.Close()
    End Sub
    Private Sub CBA5_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBA5.SelectedIndexChanged
        Try
            Me.SqlConnection1.Open()
            CTBTArt5.CommandType = CommandType.Text
            CTBTArt5.CommandText = ("Select Cve_Art,Cve_Pro from Articulo where Articulo.NOMBRE_ART =  '" & CBA5.Text & "'")
            CTBTArt5.Connection = Me.SqlConnection1
            DAARTICULO5 = CTBTArt5.ExecuteReader()
            While DAARTICULO5.Read
                Me.Label25.Text = (DAARTICULO5("cve_art"))
            End While
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        DAARTICULO5.Close()
        Me.SqlConnection1.Close()
    End Sub
    Private Sub CBA6_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBA6.SelectedIndexChanged
        Try
            Me.SqlConnection1.Open()
            CTBTArt6.CommandType = CommandType.Text
            CTBTArt6.CommandText = ("Select Cve_Art,Cve_Pro from Articulo where Articulo.NOMBRE_ART =  '" & CBA6.Text & "'")
            CTBTArt6.Connection = Me.SqlConnection1
            DAARTICULO6 = CTBTArt6.ExecuteReader()
            While DAARTICULO6.Read
                Me.Label26.Text = (DAARTICULO6("cve_art"))
            End While
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        DAARTICULO6.Close()
        Me.SqlConnection1.Close()
    End Sub
    Private Sub CBA7_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBA7.SelectedIndexChanged
        Try
            Me.SqlConnection1.Open()
            CTBTArt7.CommandType = CommandType.Text
            CTBTArt7.CommandText = ("Select Cve_Art,Cve_Pro from Articulo where Articulo.NOMBRE_ART =  '" & CBA7.Text & "'")
            CTBTArt7.Connection = Me.SqlConnection1
            DAARTICULO7 = CTBTArt7.ExecuteReader()
            While DAARTICULO7.Read
                Me.Label27.Text = (DAARTICULO7("cve_art"))
            End While
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        DAARTICULO7.Close()
        Me.SqlConnection1.Close()
    End Sub
    Private Sub CBA8_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBA8.SelectedIndexChanged
        Try
            Me.SqlConnection1.Open()
            CTBTArt8.CommandType = CommandType.Text
            CTBTArt8.CommandText = ("Select Cve_Art,Cve_Pro from Articulo where Articulo.NOMBRE_ART =  '" & CBA8.Text & "'")
            CTBTArt8.Connection = Me.SqlConnection1
            DAARTICULO8 = CTBTArt8.ExecuteReader()
            While DAARTICULO8.Read
                Me.Label28.Text = (DAARTICULO8("cve_art"))
            End While
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        DAARTICULO8.Close()
        Me.SqlConnection1.Close()
    End Sub
    Private Sub CBA9_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBA9.SelectedIndexChanged
        Try
            Me.SqlConnection1.Open()
            CTBTArt9.CommandType = CommandType.Text
            CTBTArt9.CommandText = ("Select Cve_Art,Cve_Pro from Articulo where Articulo.NOMBRE_ART =  '" & CBA9.Text & "'")
            CTBTArt9.Connection = Me.SqlConnection1
            DAARTICULO9 = CTBTArt9.ExecuteReader()
            While DAARTICULO9.Read
                Me.Label29.Text = (DAARTICULO9("cve_art"))
            End While
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        DAARTICULO9.Close()
        Me.SqlConnection1.Close()
    End Sub
    Private Sub CBA10_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBA10.SelectedIndexChanged
        Try
            Me.SqlConnection1.Open()
            CTBTArt10.CommandType = CommandType.Text
            CTBTArt10.CommandText = ("Select Cve_Art,Cve_Pro from Articulo where Articulo.NOMBRE_ART =  '" & CBA10.Text & "'")
            CTBTArt10.Connection = Me.SqlConnection1
            DAARTICULO10 = CTBTArt10.ExecuteReader()
            While DAARTICULO10.Read
                Me.Label30.Text = (DAARTICULO10("cve_art"))
            End While
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        DAARTICULO10.Close()
        Me.SqlConnection1.Close()
    End Sub
    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            Call cargar_Art1()
            req1 = 1
            CBA1.Enabled = True
            TB1.Enabled = True
            NUpDown1.Enabled = True
        Else
            req1 = 0
            CBA1.Enabled = False
            TB1.Enabled = False
            NUpDown1.Enabled = False
        End If
    End Sub
    Private Sub CheckBox2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox2.CheckedChanged
        If CheckBox2.Checked = True Then
            Call cargar_Art2()
            req2 = 2
            CBA2.Enabled = True
            TB2.Enabled = True
            NUpDown2.Enabled = True
        Else
            req2 = 0
            CBA2.Enabled = False
            TB2.Enabled = False
            NUpDown2.Enabled = False
        End If
    End Sub
    Private Sub CheckBox3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox3.CheckedChanged
        If CheckBox3.Checked = True Then
            Call cargar_Art3()
            req3 = 3
            CBA3.Enabled = True
            TB3.Enabled = True
            NUpDown3.Enabled = True
        Else
            req3 = 0
            CBA3.Enabled = False
            TB3.Enabled = False
            NUpDown3.Enabled = False
        End If
    End Sub
    Private Sub CheckBox4_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox4.CheckedChanged
        If CheckBox4.Checked = True Then
            Call cargar_Art4()
            req4 = 4
            CBA4.Enabled = True
            TB4.Enabled = True
            NUpDown4.Enabled = True
        Else
            req4 = 0
            CBA4.Enabled = False
            TB4.Enabled = False
            NUpDown4.Enabled = False
        End If
    End Sub
    Private Sub CheckBox5_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox5.CheckedChanged
        If CheckBox5.Checked = True Then
            Call cargar_Art5()
            req5 = 5
            CBA5.Enabled = True
            TB5.Enabled = True
            NUpDown5.Enabled = True
        Else
            req5 = 0
            CBA5.Enabled = False
            TB5.Enabled = False
            NUpDown5.Enabled = False
        End If
    End Sub
    Private Sub CheckBox6_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox6.CheckedChanged
        If CheckBox6.Checked = True Then
            Call cargar_Art6()
            req6 = 6
            CBA6.Enabled = True
            TB6.Enabled = True
            NUpDown6.Enabled = True
        Else
            req6 = 0
            CBA6.Enabled = False
            TB6.Enabled = False
            NUpDown6.Enabled = False
        End If
    End Sub
    Private Sub CheckBox7_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox7.CheckedChanged
        If CheckBox7.Checked = True Then
            Call cargar_Art7()
            req7 = 7
            CBA7.Enabled = True
            TB7.Enabled = True
            NUpDown7.Enabled = True
        Else
            req7 = 0
            CBA7.Enabled = False
            TB7.Enabled = False
            NUpDown7.Enabled = False
        End If
    End Sub
    Private Sub CheckBox8_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox8.CheckedChanged
        If CheckBox8.Checked = True Then
            Call cargar_Art8()
            req8 = 8
            CBA8.Enabled = True
            TB8.Enabled = True
            NUpDown8.Enabled = True
        Else
            req8 = 0
            CBA8.Enabled = False
            TB8.Enabled = False
            NUpDown8.Enabled = False
        End If
    End Sub
    Private Sub CheckBox9_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox9.CheckedChanged
        If CheckBox9.Checked = True Then
            Call cargar_Art9()
            req9 = 9
            CBA9.Enabled = True
            TB9.Enabled = True
            NUpDown9.Enabled = True
        Else
            req9 = 0
            CBA9.Enabled = False
            TB9.Enabled = False
            NUpDown9.Enabled = False
        End If
    End Sub
    Private Sub CheckBox10_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox10.CheckedChanged
        If CheckBox10.Checked = True Then
            Call cargar_Art10()
            req10 = 10
            CBA10.Enabled = True
            TB10.Enabled = True
            NUpDown10.Enabled = True
        Else
            req10 = 0
            CBA10.Enabled = False
            TB10.Enabled = False
            NUpDown10.Enabled = False
        End If
    End Sub
    Sub buscar_clave_producto()
        Try
            Me.SqlConnection1.Open()
            Dim commsql As New SqlClient.SqlCommand
            commsql.Connection = Me.SqlConnection1
            commsql.CommandText = ("select * from Articulo where Articulo.nombre_Art=" & (CBA1.Text))
            Dim dr As SqlClient.SqlDataReader
            dr = commsql.ExecuteReader(CommandBehavior.CloseConnection)
            dr.Read()
            'Label5.Text = dr("cve_art")
            dr.Close()
            Me.SqlConnection1.Close()
        Catch es As Exception
            MsgBox(es.ToString)
        End Try
    End Sub
    Sub requerimiento1()
        'Call buscar_clave_producto()
        Try
            Me.SqlConnection1.Open()
            Dim Insar1 As String = "INSERT INTO Requerimiento (Folio,Cve_Pro,Cve_Art,Nombre_Art,Fecha_Cap_Req,Depto,Titular_Depto,Cant_Art,Justificacion,Act,Status_titular,Status_Sub_Adm,Status_Direccion,No_Factura,No_Compra,Precio_Unitario,Total_x_Cantidad,IVA,Total_IVA,Status_Entrega) values(@Folio,@Cve_Pro,@Cve_Art,@Nombre_Art,@Fecha_Cap_Req,@Depto,@Titular_Depto,@Cant_Art,@Justificacion,@Act,@Status_titular,@Status_Sub_Adm,@Status_Direccion,@No_Factura,@No_Compra,@Precio_Unitario,@Total_x_Cantidad,@IVA,@Total_IVA,@Status_Entrega)"
            Dim conex1 As New SqlClient.SqlCommand(Insar1, Me.SqlConnection1)
            conex1.Parameters.Add(New SqlParameter("@Folio", SqlDbType.Int, 4)).Value = Me.TBFolio.Text
            conex1.Parameters.Add(New SqlParameter("@Cve_Pro", SqlDbType.NVarChar, 2)).Value = Mid(Me.Label21.Text, 1, 2)
            conex1.Parameters.Add(New SqlParameter("@Cve_Art", SqlDbType.NVarChar, 5)).Value = Me.Label21.Text
            conex1.Parameters.Add(New SqlParameter("@Nombre_Art", SqlDbType.NVarChar, 50)).Value = Me.CBA1.Text
            conex1.Parameters.Add(New SqlParameter("@Fecha_Cap_Req", SqlDbType.SmallDateTime)).Value = DateTimePicker1.Text
            conex1.Parameters.Add(New SqlParameter("@Depto", SqlDbType.NVarChar, 40)).Value = Me.TBDepto.Text
            conex1.Parameters.Add(New SqlParameter("@Titular_Depto", SqlDbType.NVarChar, 50)).Value = Me.TBTitular.Text
            conex1.Parameters.Add(New SqlParameter("@Cant_Art", SqlDbType.Int, 5)).Value = Me.NUpDown1.Text
            conex1.Parameters.Add(New SqlParameter("@Justificacion", SqlDbType.NVarChar)).Value = Me.TB1.Text
            conex1.Parameters.Add(New SqlParameter("@Act", SqlDbType.Int, 4)).Value = "1"
            conex1.Parameters.Add(New SqlParameter("@Status_Titular", SqlDbType.NChar, 1)).Value = "P"
            conex1.Parameters.Add(New SqlParameter("@Status_Sub_Adm", SqlDbType.NChar, 1)).Value = "P"
            conex1.Parameters.Add(New SqlParameter("@Status_Direccion", SqlDbType.NChar, 1)).Value = "P"

            conex1.Parameters.Add(New SqlParameter("@No_Factura", SqlDbType.NChar, 7)).Value = ""
            conex1.Parameters.Add(New SqlParameter("@No_Compra", SqlDbType.NChar, 5)).Value = ""
            conex1.Parameters.Add(New SqlParameter("@Precio_Unitario", SqlDbType.Decimal, 9)).Value = 0
            conex1.Parameters.Add(New SqlParameter("@Total_x_Cantidad", SqlDbType.Decimal, 9)).Value = 0
            conex1.Parameters.Add(New SqlParameter("@IVA", SqlDbType.Int, 4)).Value = 0
            conex1.Parameters.Add(New SqlParameter("@Total_IVA", SqlDbType.Decimal, 9)).Value = 0
            conex1.Parameters.Add(New SqlParameter("@Status_Entrega", SqlDbType.NChar, 1)).Value = ""

            conex1.CommandText = Insar1
            conex1.ExecuteNonQuery()
            'MsgBox("Datos guardados correctamente", , "Guardar")
            Me.SqlConnection1.Close()
            'Call mostrar()
        Catch es As Exception
            MsgBox(es.ToString)
        End Try
    End Sub
    Sub requerimiento2()
        Try
            Me.SqlConnection1.Open()
            Dim Insar2 As String = "INSERT INTO Requerimiento (Folio,Cve_Pro,Cve_Art,Nombre_Art,Fecha_Cap_Req,Depto,Titular_Depto,Cant_Art,Justificacion,Act,Status_titular,Status_Sub_Adm,Status_Direccion,No_Factura,No_Compra,Precio_Unitario,Total_x_Cantidad,IVA,Total_IVA,Status_Entrega) values(@Folio,@Cve_Pro,@Cve_Art,@Nombre_Art,@Fecha_Cap_Req,@Depto,@Titular_Depto,@Cant_Art,@Justificacion,@Act,@Status_titular,@Status_Sub_Adm,@Status_Direccion,@No_Factura,@No_Compra,@Precio_Unitario,@Total_x_Cantidad,@IVA,@Total_IVA,@Status_Entrega)"
            Dim conex1 As New SqlClient.SqlCommand(insar2, Me.SqlConnection1)
            conex1.Parameters.Add(New SqlParameter("@Folio", SqlDbType.Int, 4)).Value = Me.TBFolio.Text
            conex1.Parameters.Add(New SqlParameter("@Cve_Pro", SqlDbType.NVarChar, 2)).Value = Mid(Me.Label22.Text, 1, 2)
            conex1.Parameters.Add(New SqlParameter("@Cve_Art", SqlDbType.NVarChar, 5)).Value = Me.Label22.Text
            conex1.Parameters.Add(New SqlParameter("@Nombre_Art", SqlDbType.NVarChar, 50)).Value = Me.CBA2.Text
            conex1.Parameters.Add(New SqlParameter("@Fecha_Cap_Req", SqlDbType.SmallDateTime)).Value = DateTimePicker1.Text
            conex1.Parameters.Add(New SqlParameter("@Depto", SqlDbType.NVarChar, 40)).Value = Me.TBDepto.Text
            conex1.Parameters.Add(New SqlParameter("@Titular_Depto", SqlDbType.NVarChar, 50)).Value = Me.TBTitular.Text
            conex1.Parameters.Add(New SqlParameter("@Cant_Art", SqlDbType.Int, 5)).Value = Me.NUpDown2.Text
            conex1.Parameters.Add(New SqlParameter("@Justificacion", SqlDbType.NVarChar)).Value = Me.TB2.Text
            conex1.Parameters.Add(New SqlParameter("@Act", SqlDbType.Int, 4)).Value = "2"
            conex1.Parameters.Add(New SqlParameter("@Status_Titular", SqlDbType.NChar, 1)).Value = "P"
            conex1.Parameters.Add(New SqlParameter("@Status_Sub_Adm", SqlDbType.NChar, 1)).Value = "P"
            conex1.Parameters.Add(New SqlParameter("@Status_Direccion", SqlDbType.NChar, 1)).Value = "P"

            conex1.Parameters.Add(New SqlParameter("@No_Factura", SqlDbType.NChar, 7)).Value = ""
            conex1.Parameters.Add(New SqlParameter("@No_Compra", SqlDbType.NChar, 5)).Value = ""
            conex1.Parameters.Add(New SqlParameter("@Precio_Unitario", SqlDbType.Decimal, 9)).Value = 0
            conex1.Parameters.Add(New SqlParameter("@Total_x_Cantidad", SqlDbType.Decimal, 9)).Value = 0
            conex1.Parameters.Add(New SqlParameter("@IVA", SqlDbType.Int, 4)).Value = 0
            conex1.Parameters.Add(New SqlParameter("@Total_IVA", SqlDbType.Decimal, 9)).Value = 0
            conex1.Parameters.Add(New SqlParameter("@Status_Entrega", SqlDbType.NChar, 1)).Value = ""

            conex1.CommandText = insar2
            conex1.ExecuteNonQuery()
            'MsgBox("Datos guardados correctamente", , "Guardar")
            Me.SqlConnection1.Close()
            'Call mostrar()
        Catch es As Exception
            MsgBox(es.ToString)
        End Try
    End Sub
    Sub requerimiento3()
        Try
            Me.SqlConnection1.Open()
            Dim Insar3 As String = "INSERT INTO Requerimiento (Folio,Cve_Pro,Cve_Art,Nombre_Art,Fecha_Cap_Req,Depto,Titular_Depto,Cant_Art,Justificacion,Act,Status_titular,Status_Sub_Adm,Status_Direccion,No_Factura,No_Compra,Precio_Unitario,Total_x_Cantidad,IVA,Total_IVA,Status_Entrega) values(@Folio,@Cve_Pro,@Cve_Art,@Nombre_Art,@Fecha_Cap_Req,@Depto,@Titular_Depto,@Cant_Art,@Justificacion,@Act,@Status_titular,@Status_Sub_Adm,@Status_Direccion,@No_Factura,@No_Compra,@Precio_Unitario,@Total_x_Cantidad,@IVA,@Total_IVA,@Status_Entrega)"
            Dim conex1 As New SqlClient.SqlCommand(insar3, Me.SqlConnection1)
            conex1.Parameters.Add(New SqlParameter("@Folio", SqlDbType.Int, 4)).Value = Me.TBFolio.Text
            conex1.Parameters.Add(New SqlParameter("@Cve_Pro", SqlDbType.NVarChar, 2)).Value = Mid(Me.Label23.Text, 1, 2)
            conex1.Parameters.Add(New SqlParameter("@Cve_Art", SqlDbType.NVarChar, 5)).Value = Me.Label23.Text
            conex1.Parameters.Add(New SqlParameter("@Nombre_Art", SqlDbType.NVarChar, 50)).Value = Me.CBA3.Text
            conex1.Parameters.Add(New SqlParameter("@Fecha_Cap_Req", SqlDbType.SmallDateTime)).Value = DateTimePicker1.Text
            conex1.Parameters.Add(New SqlParameter("@Depto", SqlDbType.NVarChar, 40)).Value = Me.TBDepto.Text
            conex1.Parameters.Add(New SqlParameter("@Titular_Depto", SqlDbType.NVarChar, 50)).Value = Me.TBTitular.Text
            conex1.Parameters.Add(New SqlParameter("@Cant_Art", SqlDbType.Int, 5)).Value = Me.NUpDown3.Text
            conex1.Parameters.Add(New SqlParameter("@Justificacion", SqlDbType.NVarChar)).Value = Me.TB3.Text
            conex1.Parameters.Add(New SqlParameter("@Act", SqlDbType.Int, 4)).Value = "3"
            conex1.Parameters.Add(New SqlParameter("@Status_Titular", SqlDbType.NChar, 1)).Value = "P"
            conex1.Parameters.Add(New SqlParameter("@Status_Sub_Adm", SqlDbType.NChar, 1)).Value = "P"
            conex1.Parameters.Add(New SqlParameter("@Status_Direccion", SqlDbType.NChar, 1)).Value = "P"

            conex1.Parameters.Add(New SqlParameter("@No_Factura", SqlDbType.NChar, 7)).Value = ""
            conex1.Parameters.Add(New SqlParameter("@No_Compra", SqlDbType.NChar, 5)).Value = ""
            conex1.Parameters.Add(New SqlParameter("@Precio_Unitario", SqlDbType.Decimal, 9)).Value = 0
            conex1.Parameters.Add(New SqlParameter("@Total_x_Cantidad", SqlDbType.Decimal, 9)).Value = 0
            conex1.Parameters.Add(New SqlParameter("@IVA", SqlDbType.Int, 4)).Value = 0
            conex1.Parameters.Add(New SqlParameter("@Total_IVA", SqlDbType.Decimal, 9)).Value = 0
            conex1.Parameters.Add(New SqlParameter("@Status_Entrega", SqlDbType.NChar, 1)).Value = ""
            conex1.CommandText = insar3
            conex1.ExecuteNonQuery()
            Me.SqlConnection1.Close()
        Catch es As Exception
            MsgBox(es.ToString)
        End Try
    End Sub
    Sub requerimiento4()
        Try
            Me.SqlConnection1.Open()
            Dim Insar4 As String = "INSERT INTO Requerimiento (Folio,Cve_Pro,Cve_Art,Nombre_Art,Fecha_Cap_Req,Depto,Titular_Depto,Cant_Art,Justificacion,Act,Status_titular,Status_Sub_Adm,Status_Direccion,No_Factura,No_Compra,Precio_Unitario,Total_x_Cantidad,IVA,Total_IVA,Status_Entrega) values(@Folio,@Cve_Pro,@Cve_Art,@Nombre_Art,@Fecha_Cap_Req,@Depto,@Titular_Depto,@Cant_Art,@Justificacion,@Act,@Status_titular,@Status_Sub_Adm,@Status_Direccion,@No_Factura,@No_Compra,@Precio_Unitario,@Total_x_Cantidad,@IVA,@Total_IVA,@Status_Entrega)"
            Dim conex1 As New SqlClient.SqlCommand(insar4, Me.SqlConnection1)
            conex1.Parameters.Add(New SqlParameter("@Folio", SqlDbType.Int, 4)).Value = Me.TBFolio.Text
            conex1.Parameters.Add(New SqlParameter("@Cve_Pro", SqlDbType.NVarChar, 2)).Value = Mid(Me.Label24.Text, 1, 2)
            conex1.Parameters.Add(New SqlParameter("@Cve_Art", SqlDbType.NVarChar, 5)).Value = Me.Label24.Text
            conex1.Parameters.Add(New SqlParameter("@Nombre_Art", SqlDbType.NVarChar, 50)).Value = Me.CBA4.Text
            conex1.Parameters.Add(New SqlParameter("@Fecha_Cap_Req", SqlDbType.SmallDateTime)).Value = DateTimePicker1.Text
            conex1.Parameters.Add(New SqlParameter("@Depto", SqlDbType.NVarChar, 40)).Value = Me.TBDepto.Text
            conex1.Parameters.Add(New SqlParameter("@Titular_Depto", SqlDbType.NVarChar, 50)).Value = Me.TBTitular.Text
            conex1.Parameters.Add(New SqlParameter("@Cant_Art", SqlDbType.Int, 5)).Value = Me.NUpDown4.Text
            conex1.Parameters.Add(New SqlParameter("@Justificacion", SqlDbType.NVarChar)).Value = Me.TB4.Text
            conex1.Parameters.Add(New SqlParameter("@Act", SqlDbType.Int, 4)).Value = "4"
            conex1.Parameters.Add(New SqlParameter("@Status_Titular", SqlDbType.NChar, 1)).Value = "P"
            conex1.Parameters.Add(New SqlParameter("@Status_Sub_Adm", SqlDbType.NChar, 1)).Value = "P"
            conex1.Parameters.Add(New SqlParameter("@Status_Direccion", SqlDbType.NChar, 1)).Value = "P"

            conex1.Parameters.Add(New SqlParameter("@No_Factura", SqlDbType.NChar, 7)).Value = ""
            conex1.Parameters.Add(New SqlParameter("@No_Compra", SqlDbType.NChar, 5)).Value = ""
            conex1.Parameters.Add(New SqlParameter("@Precio_Unitario", SqlDbType.Decimal, 9)).Value = 0
            conex1.Parameters.Add(New SqlParameter("@Total_x_Cantidad", SqlDbType.Decimal, 9)).Value = 0
            conex1.Parameters.Add(New SqlParameter("@IVA", SqlDbType.Int, 4)).Value = 0
            conex1.Parameters.Add(New SqlParameter("@Total_IVA", SqlDbType.Decimal, 9)).Value = 0
            conex1.Parameters.Add(New SqlParameter("@Status_Entrega", SqlDbType.NChar, 1)).Value = ""
            conex1.CommandText = insar4
            conex1.ExecuteNonQuery()
            Me.SqlConnection1.Close()
        Catch es As Exception
            MsgBox(es.ToString)
        End Try
    End Sub
    Sub requerimiento5()
        Try
            Me.SqlConnection1.Open()
            Dim Insar5 As String = "INSERT INTO Requerimiento (Folio,Cve_Pro,Cve_Art,Nombre_Art,Fecha_Cap_Req,Depto,Titular_Depto,Cant_Art,Justificacion,Act,Status_titular,Status_Sub_Adm,Status_Direccion,No_Factura,No_Compra,Precio_Unitario,Total_x_Cantidad,IVA,Total_IVA,Status_Entrega) values(@Folio,@Cve_Pro,@Cve_Art,@Nombre_Art,@Fecha_Cap_Req,@Depto,@Titular_Depto,@Cant_Art,@Justificacion,@Act,@Status_titular,@Status_Sub_Adm,@Status_Direccion,@No_Factura,@No_Compra,@Precio_Unitario,@Total_x_Cantidad,@IVA,@Total_IVA,@Status_Entrega)"
            Dim conex1 As New SqlClient.SqlCommand(insar5, Me.SqlConnection1)
            conex1.Parameters.Add(New SqlParameter("@Folio", SqlDbType.Int, 4)).Value = Me.TBFolio.Text
            conex1.Parameters.Add(New SqlParameter("@Cve_Pro", SqlDbType.NVarChar, 2)).Value = Mid(Me.Label25.Text, 1, 2)
            conex1.Parameters.Add(New SqlParameter("@Cve_Art", SqlDbType.NVarChar, 5)).Value = Me.Label25.Text
            conex1.Parameters.Add(New SqlParameter("@Nombre_Art", SqlDbType.NVarChar, 50)).Value = Me.CBA5.Text
            conex1.Parameters.Add(New SqlParameter("@Fecha_Cap_Req", SqlDbType.SmallDateTime)).Value = DateTimePicker1.Text
            conex1.Parameters.Add(New SqlParameter("@Depto", SqlDbType.NVarChar, 40)).Value = Me.TBDepto.Text
            conex1.Parameters.Add(New SqlParameter("@Titular_Depto", SqlDbType.NVarChar, 50)).Value = Me.TBTitular.Text
            conex1.Parameters.Add(New SqlParameter("@Cant_Art", SqlDbType.Int, 5)).Value = Me.NUpDown5.Text
            conex1.Parameters.Add(New SqlParameter("@Justificacion", SqlDbType.NVarChar)).Value = Me.TB5.Text
            conex1.Parameters.Add(New SqlParameter("@Act", SqlDbType.Int, 4)).Value = "5"
            conex1.Parameters.Add(New SqlParameter("@Status_Titular", SqlDbType.NChar, 1)).Value = "P"
            conex1.Parameters.Add(New SqlParameter("@Status_Sub_Adm", SqlDbType.NChar, 1)).Value = "P"
            conex1.Parameters.Add(New SqlParameter("@Status_Direccion", SqlDbType.NChar, 1)).Value = "P"

            conex1.Parameters.Add(New SqlParameter("@No_Factura", SqlDbType.NChar, 7)).Value = ""
            conex1.Parameters.Add(New SqlParameter("@No_Compra", SqlDbType.NChar, 5)).Value = ""
            conex1.Parameters.Add(New SqlParameter("@Precio_Unitario", SqlDbType.Decimal, 9)).Value = 0
            conex1.Parameters.Add(New SqlParameter("@Total_x_Cantidad", SqlDbType.Decimal, 9)).Value = 0
            conex1.Parameters.Add(New SqlParameter("@IVA", SqlDbType.Int, 4)).Value = 0
            conex1.Parameters.Add(New SqlParameter("@Total_IVA", SqlDbType.Decimal, 9)).Value = 0
            conex1.Parameters.Add(New SqlParameter("@Status_Entrega", SqlDbType.NChar, 1)).Value = ""

            conex1.CommandText = insar5
            conex1.ExecuteNonQuery()
            Me.SqlConnection1.Close()
        Catch es As Exception
            MsgBox(es.ToString)
        End Try
    End Sub
    Sub requerimiento6()
        Try
            Me.SqlConnection1.Open()
            Dim Insar6 As String = "INSERT INTO Requerimiento (Folio,Cve_Pro,Cve_Art,Nombre_Art,Fecha_Cap_Req,Depto,Titular_Depto,Cant_Art,Justificacion,Act,Status_titular,Status_Sub_Adm,Status_Direccion,No_Factura,No_Compra,Precio_Unitario,Total_x_Cantidad,IVA,Total_IVA,Status_Entrega) values(@Folio,@Cve_Pro,@Cve_Art,@Nombre_Art,@Fecha_Cap_Req,@Depto,@Titular_Depto,@Cant_Art,@Justificacion,@Act,@Status_titular,@Status_Sub_Adm,@Status_Direccion,@No_Factura,@No_Compra,@Precio_Unitario,@Total_x_Cantidad,@IVA,@Total_IVA,@Status_Entrega)"
            Dim conex1 As New SqlClient.SqlCommand(insar6, Me.SqlConnection1)
            conex1.Parameters.Add(New SqlParameter("@Folio", SqlDbType.Int, 4)).Value = Me.TBFolio.Text
            conex1.Parameters.Add(New SqlParameter("@Cve_Pro", SqlDbType.NVarChar, 2)).Value = Mid(Me.Label26.Text, 1, 2)
            conex1.Parameters.Add(New SqlParameter("@Cve_Art", SqlDbType.NVarChar, 5)).Value = Me.Label26.Text
            conex1.Parameters.Add(New SqlParameter("@Nombre_Art", SqlDbType.NVarChar, 50)).Value = Me.CBA6.Text
            conex1.Parameters.Add(New SqlParameter("@Fecha_Cap_Req", SqlDbType.SmallDateTime)).Value = DateTimePicker1.Text
            conex1.Parameters.Add(New SqlParameter("@Depto", SqlDbType.NVarChar, 40)).Value = Me.TBDepto.Text
            conex1.Parameters.Add(New SqlParameter("@Titular_Depto", SqlDbType.NVarChar, 50)).Value = Me.TBTitular.Text
            conex1.Parameters.Add(New SqlParameter("@Cant_Art", SqlDbType.Int, 5)).Value = Me.NUpDown6.Text
            conex1.Parameters.Add(New SqlParameter("@Justificacion", SqlDbType.NVarChar)).Value = Me.TB6.Text
            conex1.Parameters.Add(New SqlParameter("@Act", SqlDbType.Int, 4)).Value = "6"
            conex1.Parameters.Add(New SqlParameter("@Status_Titular", SqlDbType.NChar, 1)).Value = "P"
            conex1.Parameters.Add(New SqlParameter("@Status_Sub_Adm", SqlDbType.NChar, 1)).Value = "P"
            conex1.Parameters.Add(New SqlParameter("@Status_Direccion", SqlDbType.NChar, 1)).Value = "P"

            conex1.Parameters.Add(New SqlParameter("@No_Factura", SqlDbType.NChar, 7)).Value = ""
            conex1.Parameters.Add(New SqlParameter("@No_Compra", SqlDbType.NChar, 5)).Value = ""
            conex1.Parameters.Add(New SqlParameter("@Precio_Unitario", SqlDbType.Decimal, 9)).Value = 0
            conex1.Parameters.Add(New SqlParameter("@Total_x_Cantidad", SqlDbType.Decimal, 9)).Value = 0
            conex1.Parameters.Add(New SqlParameter("@IVA", SqlDbType.Int, 4)).Value = 0
            conex1.Parameters.Add(New SqlParameter("@Total_IVA", SqlDbType.Decimal, 9)).Value = 0
            conex1.Parameters.Add(New SqlParameter("@Status_Entrega", SqlDbType.NChar, 1)).Value = ""
            conex1.CommandText = insar6
            conex1.ExecuteNonQuery()
            Me.SqlConnection1.Close()
        Catch es As Exception
            MsgBox(es.ToString)
        End Try
    End Sub
    Sub requerimiento7()
        Try
            Me.SqlConnection1.Open()
            Dim Insar7 As String = "INSERT INTO Requerimiento (Folio,Cve_Pro,Cve_Art,Nombre_Art,Fecha_Cap_Req,Depto,Titular_Depto,Cant_Art,Justificacion,Act,Status_titular,Status_Sub_Adm,Status_Direccion,No_Factura,No_Compra,Precio_Unitario,Total_x_Cantidad,IVA,Total_IVA,Status_Entrega) values(@Folio,@Cve_Pro,@Cve_Art,@Nombre_Art,@Fecha_Cap_Req,@Depto,@Titular_Depto,@Cant_Art,@Justificacion,@Act,@Status_titular,@Status_Sub_Adm,@Status_Direccion,@No_Factura,@No_Compra,@Precio_Unitario,@Total_x_Cantidad,@IVA,@Total_IVA,@Status_Entrega)"
            Dim conex1 As New SqlClient.SqlCommand(insar7, Me.SqlConnection1)
            conex1.Parameters.Add(New SqlParameter("@Folio", SqlDbType.Int, 4)).Value = Me.TBFolio.Text
            conex1.Parameters.Add(New SqlParameter("@Cve_Pro", SqlDbType.NVarChar, 2)).Value = Mid(Me.Label27.Text, 1, 2)
            conex1.Parameters.Add(New SqlParameter("@Cve_Art", SqlDbType.NVarChar, 5)).Value = Me.Label27.Text
            conex1.Parameters.Add(New SqlParameter("@Nombre_Art", SqlDbType.NVarChar, 50)).Value = Me.CBA7.Text
            conex1.Parameters.Add(New SqlParameter("@Fecha_Cap_Req", SqlDbType.SmallDateTime)).Value = DateTimePicker1.Text
            conex1.Parameters.Add(New SqlParameter("@Depto", SqlDbType.NVarChar, 40)).Value = Me.TBDepto.Text
            conex1.Parameters.Add(New SqlParameter("@Titular_Depto", SqlDbType.NVarChar, 50)).Value = Me.TBTitular.Text
            conex1.Parameters.Add(New SqlParameter("@Cant_Art", SqlDbType.Int, 5)).Value = Me.NUpDown7.Text
            conex1.Parameters.Add(New SqlParameter("@Justificacion", SqlDbType.NVarChar)).Value = Me.TB7.Text
            conex1.Parameters.Add(New SqlParameter("@Act", SqlDbType.Int, 4)).Value = "7"
            conex1.Parameters.Add(New SqlParameter("@Status_Titular", SqlDbType.NChar, 1)).Value = "P"
            conex1.Parameters.Add(New SqlParameter("@Status_Sub_Adm", SqlDbType.NChar, 1)).Value = "P"
            conex1.Parameters.Add(New SqlParameter("@Status_Direccion", SqlDbType.NChar, 1)).Value = "P"

            conex1.Parameters.Add(New SqlParameter("@No_Factura", SqlDbType.NChar, 7)).Value = ""
            conex1.Parameters.Add(New SqlParameter("@No_Compra", SqlDbType.NChar, 5)).Value = ""
            conex1.Parameters.Add(New SqlParameter("@Precio_Unitario", SqlDbType.Decimal, 9)).Value = 0
            conex1.Parameters.Add(New SqlParameter("@Total_x_Cantidad", SqlDbType.Decimal, 9)).Value = 0
            conex1.Parameters.Add(New SqlParameter("@IVA", SqlDbType.Int, 4)).Value = 0
            conex1.Parameters.Add(New SqlParameter("@Total_IVA", SqlDbType.Decimal, 9)).Value = 0
            conex1.Parameters.Add(New SqlParameter("@Status_Entrega", SqlDbType.NChar, 1)).Value = ""
            conex1.CommandText = insar7
            conex1.ExecuteNonQuery()
            Me.SqlConnection1.Close()
        Catch es As Exception
            MsgBox(es.ToString)
        End Try
    End Sub
    Sub requerimiento8()
        Try
            Me.SqlConnection1.Open()
            Dim Insar8 As String = "INSERT INTO Requerimiento (Folio,Cve_Pro,Cve_Art,Nombre_Art,Fecha_Cap_Req,Depto,Titular_Depto,Cant_Art,Justificacion,Act,Status_titular,Status_Sub_Adm,Status_Direccion,No_Factura,No_Compra,Precio_Unitario,Total_x_Cantidad,IVA,Total_IVA,Status_Entrega) values(@Folio,@Cve_Pro,@Cve_Art,@Nombre_Art,@Fecha_Cap_Req,@Depto,@Titular_Depto,@Cant_Art,@Justificacion,@Act,@Status_titular,@Status_Sub_Adm,@Status_Direccion,@No_Factura,@No_Compra,@Precio_Unitario,@Total_x_Cantidad,@IVA,@Total_IVA,@Status_Entrega)"
            Dim conex1 As New SqlClient.SqlCommand(insar8, Me.SqlConnection1)
            conex1.Parameters.Add(New SqlParameter("@Folio", SqlDbType.Int, 4)).Value = Me.TBFolio.Text
            conex1.Parameters.Add(New SqlParameter("@Cve_Pro", SqlDbType.NVarChar, 2)).Value = Mid(Me.Label28.Text, 1, 2)
            conex1.Parameters.Add(New SqlParameter("@Cve_Art", SqlDbType.NVarChar, 5)).Value = Me.Label28.Text
            conex1.Parameters.Add(New SqlParameter("@Nombre_Art", SqlDbType.NVarChar, 50)).Value = Me.CBA8.Text
            conex1.Parameters.Add(New SqlParameter("@Fecha_Cap_Req", SqlDbType.SmallDateTime)).Value = DateTimePicker1.Text
            conex1.Parameters.Add(New SqlParameter("@Depto", SqlDbType.NVarChar, 40)).Value = Me.TBDepto.Text
            conex1.Parameters.Add(New SqlParameter("@Titular_Depto", SqlDbType.NVarChar, 50)).Value = Me.TBTitular.Text
            conex1.Parameters.Add(New SqlParameter("@Cant_Art", SqlDbType.Int, 5)).Value = Me.NUpDown8.Text
            conex1.Parameters.Add(New SqlParameter("@Justificacion", SqlDbType.NVarChar)).Value = Me.TB8.Text
            conex1.Parameters.Add(New SqlParameter("@Act", SqlDbType.Int, 4)).Value = "8"
            conex1.Parameters.Add(New SqlParameter("@Status_Titular", SqlDbType.NChar, 1)).Value = "P"
            conex1.Parameters.Add(New SqlParameter("@Status_Sub_Adm", SqlDbType.NChar, 1)).Value = "P"
            conex1.Parameters.Add(New SqlParameter("@Status_Direccion", SqlDbType.NChar, 1)).Value = "P"

            conex1.Parameters.Add(New SqlParameter("@No_Factura", SqlDbType.NChar, 7)).Value = ""
            conex1.Parameters.Add(New SqlParameter("@No_Compra", SqlDbType.NChar, 5)).Value = ""
            conex1.Parameters.Add(New SqlParameter("@Precio_Unitario", SqlDbType.Decimal, 9)).Value = 0
            conex1.Parameters.Add(New SqlParameter("@Total_x_Cantidad", SqlDbType.Decimal, 9)).Value = 0
            conex1.Parameters.Add(New SqlParameter("@IVA", SqlDbType.Int, 4)).Value = 0
            conex1.Parameters.Add(New SqlParameter("@Total_IVA", SqlDbType.Decimal, 9)).Value = 0
            conex1.Parameters.Add(New SqlParameter("@Status_Entrega", SqlDbType.NChar, 1)).Value = ""
            conex1.CommandText = insar8
            conex1.ExecuteNonQuery()
            Me.SqlConnection1.Close()
        Catch es As Exception
            MsgBox(es.ToString)
        End Try
    End Sub
    Sub requerimiento9()
        Try
            Me.SqlConnection1.Open()
            Dim Insar9 As String = "INSERT INTO Requerimiento (Folio,Cve_Pro,Cve_Art,Nombre_Art,Fecha_Cap_Req,Depto,Titular_Depto,Cant_Art,Justificacion,Act,Status_titular,Status_Sub_Adm,Status_Direccion,No_Factura,No_Compra,Precio_Unitario,Total_x_Cantidad,IVA,Total_IVA,Status_Entrega) values(@Folio,@Cve_Pro,@Cve_Art,@Nombre_Art,@Fecha_Cap_Req,@Depto,@Titular_Depto,@Cant_Art,@Justificacion,@Act,@Status_titular,@Status_Sub_Adm,@Status_Direccion,@No_Factura,@No_Compra,@Precio_Unitario,@Total_x_Cantidad,@IVA,@Total_IVA,@Status_Entrega)"
            Dim conex1 As New SqlClient.SqlCommand(insar9, Me.SqlConnection1)
            conex1.Parameters.Add(New SqlParameter("@Folio", SqlDbType.Int, 4)).Value = Me.TBFolio.Text
            conex1.Parameters.Add(New SqlParameter("@Cve_Pro", SqlDbType.NVarChar, 2)).Value = Mid(Me.Label29.Text, 1, 2)
            conex1.Parameters.Add(New SqlParameter("@Cve_Art", SqlDbType.NVarChar, 5)).Value = Me.Label29.Text
            conex1.Parameters.Add(New SqlParameter("@Nombre_Art", SqlDbType.NVarChar, 50)).Value = Me.CBA9.Text
            conex1.Parameters.Add(New SqlParameter("@Fecha_Cap_Req", SqlDbType.SmallDateTime)).Value = DateTimePicker1.Text
            conex1.Parameters.Add(New SqlParameter("@Depto", SqlDbType.NVarChar, 40)).Value = Me.TBDepto.Text
            conex1.Parameters.Add(New SqlParameter("@Titular_Depto", SqlDbType.NVarChar, 50)).Value = Me.TBTitular.Text
            conex1.Parameters.Add(New SqlParameter("@Cant_Art", SqlDbType.Int, 5)).Value = Me.NUpDown9.Text
            conex1.Parameters.Add(New SqlParameter("@Justificacion", SqlDbType.NVarChar)).Value = Me.TB9.Text
            conex1.Parameters.Add(New SqlParameter("@Act", SqlDbType.Int, 4)).Value = "9"
            conex1.Parameters.Add(New SqlParameter("@Status_Titular", SqlDbType.NChar, 1)).Value = "P"
            conex1.Parameters.Add(New SqlParameter("@Status_Sub_Adm", SqlDbType.NChar, 1)).Value = "P"
            conex1.Parameters.Add(New SqlParameter("@Status_Direccion", SqlDbType.NChar, 1)).Value = "P"

            conex1.Parameters.Add(New SqlParameter("@No_Factura", SqlDbType.NChar, 7)).Value = ""
            conex1.Parameters.Add(New SqlParameter("@No_Compra", SqlDbType.NChar, 5)).Value = ""
            conex1.Parameters.Add(New SqlParameter("@Precio_Unitario", SqlDbType.Decimal, 9)).Value = 0
            conex1.Parameters.Add(New SqlParameter("@Total_x_Cantidad", SqlDbType.Decimal, 9)).Value = 0
            conex1.Parameters.Add(New SqlParameter("@IVA", SqlDbType.Int, 4)).Value = 0
            conex1.Parameters.Add(New SqlParameter("@Total_IVA", SqlDbType.Decimal, 9)).Value = 0
            conex1.Parameters.Add(New SqlParameter("@Status_Entrega", SqlDbType.NChar, 1)).Value = ""
            conex1.CommandText = insar9
            conex1.ExecuteNonQuery()
            Me.SqlConnection1.Close()
        Catch es As Exception
            MsgBox(es.ToString)
        End Try
    End Sub
    Sub requerimiento10()
        Try
            Me.SqlConnection1.Open()
            Dim Insar10 As String = "INSERT INTO Requerimiento (Folio,Cve_Pro,Cve_Art,Nombre_Art,Fecha_Cap_Req,Depto,Titular_Depto,Cant_Art,Justificacion,Act,Status_titular,Status_Sub_Adm,Status_Direccion,No_Factura,No_Compra,Precio_Unitario,Total_x_Cantidad,IVA,Total_IVA,Status_Entrega) values(@Folio,@Cve_Pro,@Cve_Art,@Nombre_Art,@Fecha_Cap_Req,@Depto,@Titular_Depto,@Cant_Art,@Justificacion,@Act,@Status_titular,@Status_Sub_Adm,@Status_Direccion,@No_Factura,@No_Compra,@Precio_Unitario,@Total_x_Cantidad,@IVA,@Total_IVA,@Status_Entrega)"
            Dim conex1 As New SqlClient.SqlCommand(insar10, Me.SqlConnection1)
            conex1.Parameters.Add(New SqlParameter("@Folio", SqlDbType.Int, 4)).Value = Me.TBFolio.Text
            conex1.Parameters.Add(New SqlParameter("@Cve_Pro", SqlDbType.NVarChar, 2)).Value = Mid(Me.Label30.Text, 1, 2)
            conex1.Parameters.Add(New SqlParameter("@Cve_Art", SqlDbType.NVarChar, 5)).Value = Me.Label30.Text
            conex1.Parameters.Add(New SqlParameter("@Nombre_Art", SqlDbType.NVarChar, 50)).Value = Me.CBA10.Text
            conex1.Parameters.Add(New SqlParameter("@Fecha_Cap_Req", SqlDbType.SmallDateTime)).Value = DateTimePicker1.Text
            conex1.Parameters.Add(New SqlParameter("@Depto", SqlDbType.NVarChar, 40)).Value = Me.TBDepto.Text
            conex1.Parameters.Add(New SqlParameter("@Titular_Depto", SqlDbType.NVarChar, 50)).Value = Me.TBTitular.Text
            conex1.Parameters.Add(New SqlParameter("@Cant_Art", SqlDbType.Int, 5)).Value = Me.NUpDown10.Text
            conex1.Parameters.Add(New SqlParameter("@Justificacion", SqlDbType.NVarChar)).Value = Me.TB10.Text
            conex1.Parameters.Add(New SqlParameter("@Act", SqlDbType.Int, 4)).Value = "10"
            conex1.Parameters.Add(New SqlParameter("@Status_Titular", SqlDbType.NChar, 1)).Value = "P"
            conex1.Parameters.Add(New SqlParameter("@Status_Sub_Adm", SqlDbType.NChar, 1)).Value = "P"
            conex1.Parameters.Add(New SqlParameter("@Status_Direccion", SqlDbType.NChar, 1)).Value = "P"

            conex1.Parameters.Add(New SqlParameter("@No_Factura", SqlDbType.NChar, 7)).Value = ""
            conex1.Parameters.Add(New SqlParameter("@No_Compra", SqlDbType.NChar, 5)).Value = ""
            conex1.Parameters.Add(New SqlParameter("@Precio_Unitario", SqlDbType.Decimal, 9)).Value = 0
            conex1.Parameters.Add(New SqlParameter("@Total_x_Cantidad", SqlDbType.Decimal, 9)).Value = 0
            conex1.Parameters.Add(New SqlParameter("@IVA", SqlDbType.Int, 4)).Value = 0
            conex1.Parameters.Add(New SqlParameter("@Total_IVA", SqlDbType.Decimal, 9)).Value = 0
            conex1.Parameters.Add(New SqlParameter("@Status_Entrega", SqlDbType.NChar, 1)).Value = ""
            conex1.CommandText = insar10
            conex1.ExecuteNonQuery()
            Me.SqlConnection1.Close()
        Catch es As Exception
            MsgBox(es.ToString)
        End Try
    End Sub
    Private Sub BtnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click
        Dim guardar As String
        guardar = MsgBox("Esta seguro de guardar los datos ?", MsgBoxStyle.YesNo + MsgBoxStyle.Information, "Guardar")
        If guardar = vbYes Then
            Call buscar_ultimo_folio_ocupado()
            If req1 = 1 Then
                Call requerimiento1()
            End If
            If req2 = 2 Then
                Call requerimiento2()
            End If
            If req3 = 3 Then
                Call requerimiento3()
            End If
            If req4 = 4 Then
                Call requerimiento4()
            End If
            If req5 = 5 Then
                Call requerimiento5()
            End If
            If req6 = 6 Then
                Call requerimiento6()
            End If
            If req7 = 7 Then
                Call requerimiento7()
            End If
            If req8 = 8 Then
                Call requerimiento8()
            End If
            If req9 = 9 Then
                Call requerimiento9()
            End If
            If req10 = 10 Then
                Call requerimiento10()
            End If
            MsgBox("Datos guardados correctamente..!", , "Guardar")
        Else
            'MsgBox("No existen elementos con STATUS seleccionado..!", , "Guardar")
            Me.SqlConnection1.Close()
            Me.CBProducto.Focus()
        End If
        Call limpiar_formulario()
        Call buscar_ultimo_folio()
        CBProducto.Focus()
    End Sub
    
    Private Sub BtnRegresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRegresar.Click

        Me.Close()
        'MenuJefes.Show()
        'Me.Hide()

    End Sub

    Private Sub GroupBox3_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox3.Enter
        'Me.TBDepto.Text = FrmJefes.TBDepto.Text
        'Me.TBTitular.Text = LoginFormJefes.Password.Text
    End Sub
End Class
