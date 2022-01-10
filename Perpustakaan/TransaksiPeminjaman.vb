Imports System.Data.OleDb
Public Class TransaksiPeminjaman
    Sub awal()
        Call noOtomatis()
        Call MunculKodeAnggota()
        LBLnama.Text = ""
        LBLalamat.Text = ""
        LBLtelepon.Text = ""
        LBLjudul.Text = ""
        LBLpengarang.Text = ""
        LBLtahun.Text = ""
        ComboBox1.Text = ""
        Call BuatKolom()
    End Sub

    Private Sub TransaksiPeminjaman_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call awal()
    End Sub
    Sub noOtomatis()
        Call Koneksi()
        cmd = New OleDbCommand("select * from peminjaman where no_pinjam in (select max (no_pinjam) from peminjaman)", conn)
        Dim urutanKode As String
        Dim hitung As Long
        dr = cmd.ExecuteReader
        dr.Read()
        If Not dr.HasRows Then
            urutanKode = "PJ" + Format(Now, "yyMMdd") + "001"
        Else
            hitung = Microsoft.VisualBasic.Right(dr.GetString(0), 9) + 1
            urutanKode = "PJ" + Format(Now, "yyMMdd") + Microsoft.VisualBasic.Right("000" & hitung, 3)
        End If
        LBLnopinjam.Text = urutanKode
        ' TextBox2.Text = Focus()
    End Sub

    Sub MunculKodeAnggota()
        Call Koneksi()
        ComboBox1.Items.Clear()
        cmd = New OleDbCommand("select * from anggota", conn)
        dr = cmd.ExecuteReader
        Do While dr.Read
            ComboBox1.Items.Add(dr.Item(0))
        Loop
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        Call Koneksi()
        cmd = New OleDbCommand("select * from anggota where id_anggota = '" & ComboBox1.Text & "'", conn)
        dr = cmd.ExecuteReader
        dr.Read()
        If dr.HasRows Then
            LBLnama.Text = dr!nama
            LBLalamat.Text = dr!alamat
            LBLtelepon.Text = dr!no_telp
        End If
    End Sub
    Sub BuatKolom()
        DataGridView1.Columns.Clear()
        DataGridView1.Columns.Add("no_buku", "No Buku")
        DataGridView1.Columns.Add("judul", "Judul Buku")
        DataGridView1.Columns.Add("pengarang", "Pengarang")
        DataGridView1.Columns.Add("jenis_buku", "Jenis Buku")
        DataGridView1.Columns.Add("tahun_terbit", "Tahun Terbit")
        DataGridView1.Columns.Add("status", "Status")
    End Sub

    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        If e.KeyChar = Chr(13) Then
            Call Koneksi()
            cmd = New OleDbCommand("select * from buku where no_buku = '" & TextBox1.Text & "'", conn)
            dr = cmd.ExecuteReader
            dr.Read()
            If Not dr.HasRows Then
                MsgBox("No Buku Tidak Ada!")
            Else
                TextBox1.Text = dr.Item("no_buku")
                LBLjudul.Text = dr.Item("judul")
                LBLpengarang.Text = dr.Item("pengarang")
                LBLtahun.Text = dr.Item("tahun_terbit")
                TextBox2.Text = dr.Item("status")
            End If
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If LBLjudul.Text = "" Or TextBox2.Text = "" Then
            MsgBox("Silahkan masukkan no buku dan tekan ENTER!")
        Else
            DataGridView1.Rows.Add(New String() {TextBox1.Text, LBLjudul.Text, LBLpengarang.Text, LBLtahun.Text, TextBox2.Text})
            TextBox1.Text = ""
            TextBox2.Text = ""
            LBLjudul.Text = ""
            LBLpengarang.Text = ""
            LBLtahun.Text = ""
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If LBLnama.Text = "" Then
            MsgBox("Peminjaman Tidak Ada, Silahkan lakukan peminjaman terlebih dahulu")
        Else
            Call Koneksi()
            Dim tanggal As String
            Dim tanggalKedua As String
            tanggal = Format(Today, "yyyy-MM-dd")
            tanggalKedua = Format(Today, "yyyy-MM-dd")
            Dim PinjamBuku As String = "insert into peminjaman values ('" & LBLnopinjam.Text & "', '" & ComboBox1.Text & "', '" & TextBox1.Text & "', '" & tanggal & "', '" & tanggalKedua & "')"
            cmd = New OleDbCommand(PinjamBuku, conn)
            cmd.ExecuteNonQuery()

            For baris As Integer = 0 To DataGridView1.Rows.Count - 2
                Call Koneksi()
                cmd = New OleDbCommand("select * from buku where no_buku = '" & DataGridView1.Rows(baris).Cells(0).Value & "'", conn)
                cmd.ExecuteNonQuery()
            Next
            Call awal()
            MsgBox("Data Berhasil Disimpan")
        End If
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Call awal()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Close()
    End Sub
End Class