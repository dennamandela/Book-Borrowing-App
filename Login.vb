Imports System.Data.OleDb
Public Class Login

    Private Sub Login_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtUsername.Text = ""
        txtPassword.Text = ""
    End Sub

    Private Sub btnLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogin.Click
        If txtUsername.Text = "" Or txtPassword.Text = "" Then
            MsgBox("Data belum lengkap, silahkan isi semua form!")
        Else
            Call Koneksi()
            cmd = New OleDbCommand("select * from login where username='" & txtUsername.Text & "' and password='" & txtPassword.Text & "'", conn)
            dr = cmd.ExecuteReader
            dr.Read()
            If dr.HasRows Then
                Me.Hide()
                Beranda.Show()
            Else
                MsgBox("Username dan Password Salah")
            End If
        End If

    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
End Class