Public Class login


    Dim db As New LoginDataBase()

    'Check if didn't logged out
    Private Function isLoggedIn() As Boolean

        For x = 0 To db.dataSet.Tables("Users").Rows.Count - 1
            If db.dataSet.Tables("Users").Rows(x).Item("User_Stat").Equals(True) Then
                Main.Show()
                Me.Close()
                Return True
            End If
        Next

        Return False
    End Function

    'Check the validity of the username and password entered by the user
    Private Function login(ByVal uName As String, ByVal pass As String) As Boolean

        If chkAdmin.Checked = True Then
            db.AccessData("Select * From tblUser Where User_Level = 'admin'")
        Else
            db.AccessData("Select * From tblUser Where Not User_Level = 'admin'")
        End If

        Dim flag As Boolean
        Dim x As Integer
        For x = 0 To db.dataSet.Tables("Users").Rows.Count - 1
            If uName = db.dataSet.Tables("Users").Rows(x).Item("User_ID") _
                And pass = db.dataSet.Tables("Users").Rows(x).Item("User_Pass") Then
                flag = True
                Exit For
            End If
        Next


        If flag = True Then
            db.LoginStat(db.dataSet.Tables("Users").Rows(x).Item("ID"), -1)
            Main.Show()
            Me.Close()
            Return True
        Else

            MsgBox("Incorrect Username or Password!")
            txtUname.Focus()
        End If


        Return False
    End Function




    Private Sub btnLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogin.Click
        Try
            If txtUname.Text = Nothing Then
                MsgBox("Enter your username!")
                txtUname.Focus()
            ElseIf txtPass.Text = Nothing Then
                MsgBox("Enter your password!")
                txtPass.Focus()
            Else
                login(txtUname.Text, txtPass.Text)
                txtPass.Clear()
                txtUname.Clear()
            End If
           
        Catch ex As Exception
            MsgBox(ex.ToString())
        End Try

    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub login_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        db.AccessData("Select * From tblUser")
        Try
            Dim test As String = db.dataSet.Tables("Users").Rows(0).Item(0)

            If db.dataSet.Tables("Users").Rows.Count() = 1 And db.dataSet.Tables("Users").Rows(0).Item("User_Level") <> "admin" Then

                Me.Close()
                AddNewUserForm.Show()

            ElseIf db.dataSet.Tables("Users").Rows.Count > 1 Then
                Dim flag As Boolean = False
                For x = 0 To db.dataSet.Tables("Users").Rows.Count - 1
                    If db.dataSet.Tables("Users").Rows(x).Item("User_Level") = "admin" Then
                        flag = True
                        Exit For
                    End If
                Next
                If flag = False Then

                    AddNewUserForm.Show()
                    Me.Close()

                End If
            End If


        Catch ex As Exception
            AddNewUserForm.Show()
            Me.Close()
        End Try

        If isLoggedIn() = True Then
            Main.Show()
            Me.Close()
        End If

    End Sub

    Private Sub txtPass_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPass.KeyPress
        If Asc(e.KeyChar) = 13 Then
            btnLogin.PerformClick()
        End If
    End Sub

  
End Class
