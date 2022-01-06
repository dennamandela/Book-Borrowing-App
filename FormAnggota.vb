Imports System.Data.OleDb
Public Class FormAnggota
    Sub baca()
        Call Koneksi()
        da = New OleDbDataAdapter("select * from anggota", conn)
        ds = New DataSet
        ds.Clear()
        da.Fill(ds, "anggota")
        DataGridView1.DataSource = (ds.Tables("anggota"))
    End Sub
    Sub kosong()
        TextBox1.Text = ""
        TextBox2.Text = ""
        RichTextBox1.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        simpan.Enabled = True
        edit.Enabled = True
    End Sub

    Private Sub FormAnggota_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call Koneksi()
        da = New OleDbDataAdapter("select * from anggota", conn)
        ds = New DataSet
        ds.Clear()
        da.Fill(ds, "anggota")
        DataGridView1.DataSource = (ds.Tables("anggota"))
    End Sub

    Private Sub simpan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles simpan.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Or RichTextBox1.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Then
            MsgBox("Data belum lengkap, pastikan form harus terisi!")
        Else
            Call Koneksi()
            Dim tanggalLahir As String
            tanggalLahir = Format(DateTimePicker1.Value, "yyyy-MM-dd")
            Dim simpan As String
            simpan = "insert into anggota values ('" & TextBox1.Text & "', '" & TextBox2.Text & "', '" & RichTextBox1.Text & "', '" & TextBox3.Text & "', '" & TextBox4.Text & "', '" & tanggalLahir & "')"
            cmd = New OleDbCommand(simpan, conn)
            cmd.ExecuteNonQuery()
            MsgBox("Data Berhasil Tersimpan", MsgBoxStyle.Information, "Informasi")
            Call baca()
        End If
    End Sub
End Class