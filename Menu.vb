Public Class Menu
    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles btnsair.Click
        End
    End Sub

    Private Sub btnplayer_Click(sender As Object, e As EventArgs) Handles btnplayer.Click
        AI = False
        Me.Hide()
        Tabuleiro.resetJogo()
        Tabuleiro.Activate()
        Tabuleiro.Show()
    End Sub

    Private Sub btnai_Click(sender As Object, e As EventArgs) Handles btnai.Click
        AI = True
        Tabuleiro.resetJogo()
        If AI Then
            Tabuleiro.jogador2Label.Text = "AI"
            Tabuleiro.jogador2Label.Location = New Point(803, 146)
        End If
        Me.Hide()

        Tabuleiro.Activate()
        Tabuleiro.Show()
    End Sub

    Private Sub btninfo_Click(sender As Object, e As EventArgs) Handles btninfo.Click
        Me.Hide()
        Instrucoes.Show()
    End Sub

    Private Sub btnsobre_Click(sender As Object, e As EventArgs) Handles btnsobre.Click
        Me.Hide()
        Info.Show()
    End Sub
End Class
