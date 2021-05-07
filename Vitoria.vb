Public Class Vitoria
    Private Sub Button1_Click(sender As Object, e As EventArgs)
        Me.Hide()
        Menu.Activate()
        Menu.Show()
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Me.Hide()
        Menu.Show()
    End Sub

End Class
