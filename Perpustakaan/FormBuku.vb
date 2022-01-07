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
        ds.Clear()
        da.Fill(ds, "buku")
        DataGridView1.DataSource = (ds.Tables("buku"))
    End Sub

    Private Sub btnTambah_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTambah.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or TextBox5.Text = "" Or TextBox6.Text = "" Then
            MsgBox("Data belum lengkap, pastikan semua form terisi")
            Exit Sub
        Else
            Call Koneksi()
            Dim simpan As String = "insert into buku values ('" & TextBox1.Text & "', '" & TextBox2.Text & "', '" & TextBox3.Text & "', '" & TextBox4.Text & "' , '" & TextBox5.Text & "', '" & TextBox6.Text & "')"
            cmd = New OleDbCommand(simpan, conn)
            cmd.ExecuteNonQuery()
            MsgBox("Data berhasil di Input", MsgBoxStyle.Information, "Information")
            Call baca()
        End If
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        Dim update As String
        update = "update buku set judul='" & TextBox2.Text & "',pengarang='" & TextBox3.Text & "',tahun_terbit='" & TextBox4.Text & "',jenis_buku='" & TextBox5.Text & "', status='" & TextBox6.Text & "' where no_buku='" & TextBox1.Text & "'"
        cmd = New OleDbCommand(update, conn)
        cmd.ExecuteNonQuery()
        MsgBox("Data Sudah Terupdate", MsgBoxStyle.Information, "Informasi")
        TextBox1.Enabled = True
        Call baca()
        Call kosong()
    End Sub

    Private Sub btnKeluar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnKeluar.Click
        Me.Close()
    End Sub

    Private Sub btnHapus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHapus.Click
        Dim hapus As String
        hapus = "delete from buku where no_buku='" & TextBox1.Text & "'"
        cmd = New OleDbCommand(hapus, conn)
        cmd.ExecuteNonQuery()
        MsgBox("Data Sudah Terhapus", MsgBoxStyle.Information, "Informasi")
        TextBox1.Enabled = True
        Call baca()
        Call kosong()
    End Sub

    
    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)

    End Sub

    Private Sub FormBuku_Load_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'PerpustakaanDataSet1.buku' table. You can move, or remove it, as needed.
        Me.BukuTableAdapter.Fill(Me.PerpustakaanDataSet1.buku)

    End Sub
End Class
