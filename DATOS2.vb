Imports System.Data
Imports System.IO
Imports System.Text
Imports System.Data.OleDb
Imports System.Data.SqlClient
Public Class Datos2
    Dim username As String
    Dim password As String
    Public Property fdcusername()
        Get
            Return username
        End Get
        Set(ByVal value)
            username = value
        End Set
    End Property
    Public Property fdcpassword()
        Get
            Return password
        End Get
        Set(ByVal value)
            password = value
        End Set
    End Property
    Public Sub New(ByVal username As String, ByVal password As String)
        fdcusername = username
        fdcpassword = password
        ' Llamada necesaria para el Diseñador de Windows Forms.
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub
    Public Sub New()
    End Sub
End Class
