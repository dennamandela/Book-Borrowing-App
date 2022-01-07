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
        DateTimePicker1.Value = ""
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
            Dim simpan As String
            
            simpan = "insert into anggota values ('" & TextBox1.Text & "', '" & TextBox2.Text & "', '" & RichTextBox1.Text & "', '" & TextBox3.Text & "', '" & TextBox4.Text & "', '" & DateTimePicker1.Value.Date & "')"
            cmd = New OleDbCommand(simpan, conn)
            cmd.ExecuteNonQuery()
            MsgBox("Data Berhasil Tersimpan", MsgBoxStyle.Information, "Informasi")
            Call baca()
            Call kosong()
        End If
    End Sub

    Private Sub edit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles edit.Click
        Call Koneksi()
        Dim update As String
        update = "update anggota set nama='" & TextBox2.Text & "',alamat='" & RichTextBox1.Text & "',kota='" & TextBox3.Text & "',no_telp='" & TextBox4.Text & "', tgl_lahir='" & DateTimePicker1.Value & "', where id_anggota='" & TextBox1.Text & "'"
        cmd = New OleDbCommand(update, conn)
        cmd.ExecuteNonQuery()
        MsgBox("Data Berhasil Terupdate", MsgBoxStyle.Information, "Informasi")
        Call baca()
        Call kosong()
    End Sub

    Private Sub keluar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles keluar.Click
        Close()
    End Sub

    Private Sub hapus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles hapus.Click
        Call Koneksi()
        Dim delete As String
        delete = "delete from anggota where id_anggota = '" & TextBox1.Text & "'"
        cmd = New OleDbCommand(delete, conn)
        cmd.ExecuteNonQuery()
        MsgBox("Data Berhasil Terhapus", MsgBoxStyle.Information, "Informasi")
        Call baca()
        Call kosong()
    End Sub
End Class