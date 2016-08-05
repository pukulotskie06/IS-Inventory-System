Public Class AddOrRemove


    ''Add
    Private Sub btnCloseAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCloseAdd.Click
        Me.Close()
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click

        If txtUser.Text <> Nothing Then
            If txtPass.Text = txtRetype.Text And txtPass.Text <> Nothing Then
                Dim addUser As New AddNewUserDB()
                Dim s() As String = {txtUser.Text, txtPass.Text, comboAdd.Text}
                addUser.AddNewUser(s)
                txtPass.Clear()
                txtRetype.Clear()
                txtUser.Clear()
                RefreshData()
            ElseIf txtPass.Text <> txtRetype.Text Then
                MsgBox("The password did not match please try again!")
                txtRetype.Focus()
            Else
                MsgBox("Invalid input!")
            End If
        End If


    End Sub

    Private Sub comboAdd_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles comboAdd.MouseEnter
        comboAdd.ContextMenu = New ContextMenu()
    End Sub

    ''End add
    Private Sub TabPage1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabPage1.Click

    End Sub

    Private Sub AddOrRemove_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        If flag = False Then
            SettingsForm.Show()
            SettingsForm.TopMost = True
        End If
    End Sub

   
  
    Private Sub AddOrRemove_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        RefreshData()
    End Sub

    ''Remove
    Dim ru As New RemoveUserClass()

    Public Sub RefreshData()
        ru.ViewData()
        ComboBox1.Items.Clear()
        For x = 0 To ru.ds.Tables("Users").Rows.Count - 1
            ComboBox1.Items.Add(ru.ds.Tables("Users").Rows(x).Item("ID"))
        Next
        ComboBox1.Text = ComboBox1.Items(0)
    End Sub

    Private Sub ComboBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ComboBox1.KeyPress
        e.Handled = True
    End Sub

    Private Sub ComboBox1_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox1.MouseEnter
        ComboBox1.ContextMenu = New ContextMenu()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged

        TextBox2.Text = ru.ds.Tables("Users").Rows(ComboBox1.SelectedIndex()).Item("User_ID")

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
    Dim flag As Boolean = False
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        If ComboBox1.Text <> Nothing And (MessageBox.Show("Are you sure you want to remove User ID " & ComboBox1.Text & "?", "Remove", MessageBoxButtons.YesNo, MessageBoxIcon.Question)) = 6 Then
            ru.RemoveUser(ComboBox1.Text)
            Try
                RefreshData()
                Dim temp As New LoginDataBase()
                If temp.GetID("Select [User_Stat] from tblUser Where [User_Stat] = -1", "User_Stat") <> True Then
                    MsgBox("Ok nothing online")
                    Main.Button1.PerformClick()
                    Me.Close()
                End If
            Catch ex As Exception
                flag = True
                Main.Enabled = True
                Main.Button1.PerformClick()
                Me.Close()
            End Try

        End If

    End Sub
    ''End Remove

    Private Sub TabPage2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabPage2.Click
        RefreshData()
    End Sub
End Class
