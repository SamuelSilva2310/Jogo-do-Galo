Public Class Menu
    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles btnsair.Click
        End
    End Sub

    Private Sub btnplayer_Click(sender As Object, e As EventArgs) Handles btnplayer.Click
        Me.Hide()
        Tabuleiro.Activate()
        Tabuleiro.Show()
    End Sub
End Class
