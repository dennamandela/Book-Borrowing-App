Imports System.Data.OleDb
Module ModuleKoneksi
    Public conn As OleDbConnection
    Public cmd As OleDbCommand
    Public ds As DataSet
    Public da As OleDbDataAdapter
    Public dr As OleDbDataReader
    Public LokasiData As String
End Module
