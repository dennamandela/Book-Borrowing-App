Imports System.Data.OleDb
Public Class TransaksiPeminjaman
    Sub baca()
        Call Koneksi()
        da = New OleDbDataAdapter("select * from peminjaman", conn)
        ds = New DataSet
        ds.Clear()
        da.Fill(ds, "peminjaman")
        DataGridView1.DataSource = (ds.Tables("peminjaman"))
    End Sub
    Sub kosong()
        TextBox1.Text = ""
        ComboBox1.Text = ""
        ComboBox2.Text = ""
        DateTimePicker1.Value = ""
        DateTimePicker2.Value = ""
        simpan.Enabled = True
        edit.Enabled = True
    End Sub

    Private Sub TransaksiPeminjaman_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call Koneksi()
        da = New OleDbDataAdapter("select * from peminjaman", conn)
        ds = New DataSet
        ds.Clear()
        da.Fill(ds, "peminjaman")
        DataGridView1.DataSource = (ds.Tables("peminjaman"))
    End Sub
End Class