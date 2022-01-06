Imports System.Data.OleDb
Public Class FormBuku
    Sub baca()
        Call Koneksi()
        da = New OleDbDataAdapter("select * from buku", conn)
        ds = New DataSet
        ds.Clear()
        da.Fill(ds, "buku")
        DataGridView1.DataSource = (ds.Tables("buku"))
    End Sub
    Sub kosong()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        btnTambah.Enabled = True
        btnEdit.Enabled = True
    End Sub

    Private Sub FormBuku_Load(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Call Koneksi()
        da = New OleDbDataAdapter("select * from buku", conn)
        ds = New DataSet
        da.Fill(ds, "buku")
        DataGridView1.DataSource = (ds.Tables("buku"))
    End Sub

    Private Sub btnTambah_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTambah.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or TextBox5.Text = "" Or TextBox6.Text = "" Then
            MsgBox("Data belum lengkap, pastikan semua form terisi")
        Else
            Call Koneksi()
            Dim simpan As String = "insert into buku values ('" & TextBox1.Text & "', '" & TextBox2.Text & "', '" & TextBox3.Text & "', '" & TextBox4.Text & "' , '" & TextBox5.Text & "', '" & TextBox6.Text & "')"
            cmd = New OleDbCommand(simpan, conn)
            cmd.ExecuteReader()
            MsgBox("Data berhasil di Input", MsgBoxStyle.Information, "Information")
            Call baca()
        End If
    End Sub
End Class