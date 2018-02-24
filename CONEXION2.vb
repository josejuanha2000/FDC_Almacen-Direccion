Imports System.Data
Imports System.IO
Imports System.Text
Imports System.Data.OleDb
Imports System.Data.SqlClient
Public Class CONEXION2
    Protected cnn As New SqlConnection
    Protected Function conectado()
        Try
            'cnn = New SqlConnection("Data Source=COLMASQLFDC01\FACDYCDES;Initial Catalog=EPROFESIONALES;Integrated Security=True")
            cnn = New SqlConnection("Data Source=COLMASQLFDC01\FACDYCDES;Initial Catalog=ALMACEN;Integrated Security=True")
            cnn.Open()
            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function
    Protected Function desconectado()
        Try
            If cnn.State = ConnectionState.Open Then
                cnn.Close()
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function
End Class
