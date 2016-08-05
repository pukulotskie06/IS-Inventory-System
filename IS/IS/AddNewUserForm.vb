Public Class AddNewUserForm

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        If txtUser.Text <> Nothing Then
            If txtPass.Text = txtRetype.Text And txtPass.Text <> Nothing Then
                Dim addUser As New AddNewUserDB()
                Dim s() As String = {txtUser.Text, txtPass.Text, ComboBox1.Text}
                addUser.AddNewUser(s)
                txtPass.Clear()
                txtRetype.Clear()
                txtUser.Clear()
                login.Show()
                Me.Close()
            ElseIf txtPass.Text <> txtRetype.Text Then
                MsgBox("The password did not match please try again!")
                txtRetype.Focus()
            ElseIf txtPass.Text = Nothing Then
                MsgBox("Enter your password!")
                txtPass.Focus()
            Else
                MsgBox("Invalid input!")
            End If
        Else
            MsgBox("Enter username!")
            txtUser.Focus()
        End If


    End Sub

    Private Sub AddNewUserForm_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        ''SettingsForm.Enabled = True
    End Sub

  
  
    Private Sub ComboBox1_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox1.MouseEnter
        ComboBox1.ContextMenu = New ContextMenu()
    End Sub

    Private Sub AddNewUserForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class
