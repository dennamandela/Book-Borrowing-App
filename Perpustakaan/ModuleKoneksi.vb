Imports System.Data.OleDb
Module ModuleKoneksi
    Public conn As OleDbConnection
    Public cmd As OleDbCommand
    Public ds As DataSet
    Public da As OleDbDataAdapter
    Public dr As OleDbDataReader
    Public LokasiData As String
    Sub Koneksi()
        LokasiData = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=perpustakaan.accdb"
        conn = New OleDbConnection(LokasiData)
        If conn.State = ConnectionState.Closed Then
            conn.Open()
        Else
            MsgBox("Koneksi Gagal")
        End If
    End Sub

End Module
