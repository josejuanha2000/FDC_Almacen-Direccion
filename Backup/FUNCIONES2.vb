Imports System.Data
Imports System.IO
Imports System.Text
Imports System.Data.OleDb
Imports System.Data.SqlClient
Public Class FUNCIONES2
    Inherits CONEXION2
    'Public depto
    'Public tit
    'Public switch As Integer = 0
    'Public tit As String
    Dim cmd As New SqlCommand
    Public Function validar(ByVal dts As Datos2) As Boolean
        Try
            conectado()
            cmd = New SqlCommand("validar")
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = cnn
            cmd.Parameters.AddWithValue("@log", dts.fdcusername)
            cmd.Parameters.AddWithValue("@pas", dts.fdcpassword)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader
            dr.Read()
            If dr.HasRows = True Then
                'depto = dr("Departamento")
                'tit = dr("Titular")
                'MsgBox("El departamento es:" & Me.depto)
                'MsgBox("El Titular es:" & Me.tit)

                'FRMREQMAT.TBDepto.Text = dr("Departamento")
                'FRMREQMAT.TBTitular.Text = dr("Titular")
                'FrmJefes.TBDepto.Text = dr("Departamento")
                'FrmJefes.TBTitular.Text = dr("Titular")

                MenuJefes.TBDepto.Text = dr("Departamento")
                MenuJefes.TBTitular.Text = dr("Titular")

                'FrmSubDir.TBDepto.Text = dr("Departamento")
                'FrmSubDir.TBTitular.Text = dr("Titular")
                'If dr("ext") = 7024 Then
                ' Switch = 1
                'End If
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        Finally
            desconectado()
        End Try
    End Function
End Class
