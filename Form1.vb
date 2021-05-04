Public Class Form1

    Public Function isWinner(ByVal key As Char)
        Return ((Button1.Text = Button2.Text And Button2.Text = Button3.Text And Button3.Text = key) Or
            (Button4.Text = Button5.Text And Button5.Text = Button6.Text And Button6.Text = key) Or
            (Button7.Text = Button8.Text And Button8.Text = Button9.Text And Button9.Text = key) Or
            (Button1.Text = Button5.Text And Button5.Text = Button9.Text And Button9.Text = key) Or
            (Button3.Text = Button5.Text And Button5.Text = Button7.Text And Button7.Text = key) Or
            (Button1.Text = Button4.Text And Button4.Text = Button7.Text And Button7.Text = key) Or
            (Button2.Text = Button5.Text And Button5.Text = Button8.Text And Button8.Text = key) Or
            (Button3.Text = Button6.Text And Button6.Text = Button9.Text And Button9.Text = key))


    End Function

    Public Function ComputerInput()
        Dim btns As Button() = {Button1, Button2, Button3, Button4, Button5, Button6, Button7, Button8, Button9}
        Dim possInput As List(Of Button) = New List(Of Button)

        For j As Integer = 0 To btns.Length - 1
            If (btns(j).Text = "") Then
                possInput.Add(btns(j))
            End If
        Next

        Dim chs() As Char = {"X", "O"}

        For Each ch As Char In chs
            For Each btn As Button In possInput
                btn.Text = ch
                If isWinner(ch) Then
                    btn.Text = "O"
                    btn.Enabled = False
                    Return (True)
                End If
                btn.Text = ""
            Next
        Next

        Dim cornerBtn As List(Of Button) = New List(Of Button)

        For Each btn As Button In possInput
            If (btn Is Button1 Or btn Is Button3 Or btn Is Button7 Or btn Is Button9) Then
                cornerBtn.Add(btn)
            End If
        Next

        Dim tempBtn As Button
        If cornerBtn.Count > 0 Then
            tempBtn = cornerBtn(New Random().Next(0, cornerBtn.Count - 1))
            tempBtn.Text = "O"
            tempBtn.Enabled = False
            Return (True)
        End If

        If possInput.Contains(Button5) Then
            Button5.Text = "O"
            Button5.Enabled = False
            Return (True)
        End If

        Dim edgeBtn As List(Of Button) = New List(Of Button)
        For Each btn As Button In possInput
            If (btn Is Button2 Or btn Is Button4 Or btn Is Button6 Or btn Is Button8) Then
                edgeBtn.Add(btn)
            End If
        Next

        If edgeBtn.Count > 0 Then
            tempBtn = edgeBtn(New Random().Next(0, edgeBtn.Count - 1))
            tempBtn.Text = "O"
            tempBtn.Enabled = False
            Return (True)
        End If

        Return (False)
    End Function

    Public Sub reset()
        Dim btns As Button() = {Button1, Button2, Button3, Button4, Button5, Button6, Button7, Button8, Button9}
        For Each btn As Button In btns
            btn.Text = ""
            btn.Enabled = True
            btn.BackColor = DefaultBackColor

        Next
    End Sub

    Public Function checkTheWinner(ByVal key As Char)
        If (Button1.Text = Button2.Text And Button2.Text = Button3.Text And Button3.Text = key) Then
            Button1.BackColor = Color.GreenYellow
            Button2.BackColor = Color.GreenYellow
            Button3.BackColor = Color.GreenYellow
        ElseIf (Button4.Text = Button5.Text And Button5.Text = Button6.Text And Button6.Text = key) Then
            Button4.BackColor = Color.GreenYellow
            Button5.BackColor = Color.GreenYellow
            Button6.BackColor = Color.GreenYellow
        ElseIf (Button7.Text = Button8.Text And Button8.Text = Button9.Text And Button9.Text = key) Then
            Button7.BackColor = Color.GreenYellow
            Button8.BackColor = Color.GreenYellow
            Button9.BackColor = Color.GreenYellow
        ElseIf (Button1.Text = Button5.Text And Button5.Text = Button9.Text And Button9.Text = key) Then
            Button1.BackColor = Color.GreenYellow
            Button5.BackColor = Color.GreenYellow
            Button9.BackColor = Color.GreenYellow
        ElseIf (Button3.Text = Button5.Text And Button5.Text = Button7.Text And Button7.Text = key) Then
            Button3.BackColor = Color.GreenYellow
            Button5.BackColor = Color.GreenYellow
            Button7.BackColor = Color.GreenYellow
        ElseIf (Button1.Text = Button4.Text And Button4.Text = Button7.Text And Button7.Text = key) Then
            Button1.BackColor = Color.GreenYellow
            Button4.BackColor = Color.GreenYellow
            Button7.BackColor = Color.GreenYellow
        ElseIf (Button2.Text = Button5.Text And Button5.Text = Button8.Text And Button8.Text = key) Then
            Button2.BackColor = Color.GreenYellow
            Button5.BackColor = Color.GreenYellow
            Button8.BackColor = Color.GreenYellow
        ElseIf (Button3.Text = Button6.Text And Button6.Text = Button9.Text And Button9.Text = key) Then
            Button3.BackColor = Color.GreenYellow
            Button6.BackColor = Color.GreenYellow
            Button9.BackColor = Color.GreenYellow
        Else
            Return (False)
        End If
        Return (True)
    End Function
    Public Sub check()
        If checkTheWinner("X") Then
            Button11.Text = "Tu ganhaste! 😀"
            Button11.BackColor = Color.GreenYellow
            Button11.Enabled = False
            Button10.Enabled = True
        ElseIf checkTheWinner("O") Then
            Button11.Text = "Tu perdeste! 😔"
            Button11.BackColor = Color.Red
            Button11.Enabled = False
            Button10.Enabled = True
        Else
            Dim btns As Button() = {Button1, Button2, Button3, Button4, Button5, Button6, Button7, Button8, Button9}
            Dim possInput As List(Of Button) = New List(Of Button)

            For j As Integer = 0 To btns.Length - 1
                If (btns(j).Text = "") Then
                    possInput.Add(btns(j))
                End If
            Next
            If possInput.Count = 0 Then
                Button11.Text = "Empatado! 😐"
                Button11.BackColor = Color.Yellow
                Button11.Enabled = False
                Button10.Enabled = True
            End If
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Button1.Text = "X"
        Button1.Enabled = False
        ComputerInput()
        check()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Button2.Text = "X"
        Button2.Enabled = False
        ComputerInput()
        check()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Button3.Text = "X"
        Button3.Enabled = False
        ComputerInput()
        check()
    End Sub


    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Button4.Text = "X"
        Button4.Enabled = False
        ComputerInput()
        check()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Button5.Text = "X"
        Button5.Enabled = False
        ComputerInput()
        check()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Button6.Text = "X"
        Button6.Enabled = False
        ComputerInput()
        check()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Button7.Text = "X"
        Button7.Enabled = False
        ComputerInput()
        check()
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Button8.Text = "X"
        Button8.Enabled = False
        ComputerInput()
        check()
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Button9.Text = "X"
        Button9.Enabled = False
        ComputerInput()
        check()
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        reset()
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        reset()
        Button11.Text = "Reset"
        Button11.BackColor = DefaultBackColor
        Button11.Enabled = True
        Button10.Enabled = False

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
