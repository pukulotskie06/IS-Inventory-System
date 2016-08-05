Public Class MySplashcreen

    Dim x As Integer = 0

    Private Sub MySplashcreen_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        login.Show()
    End Sub
    Private Sub MySplashcreen_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Timer1.Start()
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        x += 1
        ProgressBar1.Value = x

        If x = ProgressBar1.Maximum() Then
            Timer1.Stop()
            Label1.Text = ProgressBar1.Value * 100 / 10 & "% Completed!"
            Timer1.Interval = 100
            Timer2.Start()
        Else
            Label1.Text = ProgressBar1.Value * 100 / 10 & "% Completed!"
        End If

    End Sub

    Private Sub ProgressBar1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProgressBar1.Click

    End Sub

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        x += 1
        If x = 20 Then
            Timer1.Stop()
            Me.Close()
        End If
    End Sub
End Class