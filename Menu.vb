﻿Public Class Menu
    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles btnsair.Click
        End
    End Sub

    Private Sub btnplayer_Click(sender As Object, e As EventArgs) Handles btnplayer.Click
        AI = False
        Me.Hide()
        Tabuleiro.Activate()
        Tabuleiro.Show()
    End Sub

    Private Sub btnai_Click(sender As Object, e As EventArgs) Handles btnai.Click
        AI = True
        Me.Hide()
        Tabuleiro.Activate()
        Tabuleiro.Show()
    End Sub


End Class
