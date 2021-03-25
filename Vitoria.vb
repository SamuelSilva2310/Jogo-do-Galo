Public Class Vitoria
    Private Sub Voltar_Click(sender As Object, e As EventArgs) Handles Voltar.Click
        Me.Hide()
        Menu.Activate()
        Menu.Show()
    End Sub
End Class