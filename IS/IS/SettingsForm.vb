Imports System.IO
Imports System.Security.AccessControl

Public Class SettingsForm

    Dim ld As New SettingsDatabase

    Private Sub SettingsForm_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Main.RefreshBusinessMain()
        Main.Enabled = True
    End Sub


    Private Sub SettingsForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If ld.GetID("Select User_Level from tblUser Where User_Stat = -1", "User_Level") = "admin" Then
            btnNew.Enabled = True
            btnNew.Visible = True
            btnBEdit.Visible = True
            btnBSave.Visible = True
            btnCEdit.Visible = True
            btnCSave.Enabled = True
        End If

        LoadValue()
    End Sub


    Private Sub LoadValue()
        txtCritical.Text = ld.GetID("Select CriticalLevel from tblUser Where User_Stat = -1", "CriticalLevel")
        txtTitle.Text = ld.GetID("Select User_Business from tblUser Where User_Stat = -1", "User_Business")
        txtUsername.Text = ld.GetID("Select User_ID from tblUser Where User_Stat = -1", "User_ID")
        txtCurrentPass.Text = ld.GetID("Select User_Pass from tblUser Where User_Stat = -1", "User_Pass")
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        Me.Close()
    End Sub

    Private Sub btnBEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBEdit.Click

        If btnBEdit.Text = "Edit" Then
            btnBEdit.Text = "Cancel"
            btnBSave.Enabled = True
            txtTitle.Enabled = True
        Else
            txtTitle.Text = ld.GetID("Select [User_Business] from tblUser Where [User_Stat] = -1", "User_Business")
            btnBEdit.Text = "Edit"
            btnBSave.Enabled = False
            txtTitle.Enabled = False
        End If

    End Sub

    Private Sub btnBSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBSave.Click

        If txtTitle.Text <> Nothing Then
            ld.SaveChanges("User_Business", txtTitle.Text, Val(ld.GetID("Select [ID] from tblUser Where User_Stat = -1", "ID")))
            LoadValue()
            btnBSave.Enabled = False
            txtTitle.Enabled = False
            btnBEdit.Text = "Edit"
            MsgBox("Business Title Saved!")
        End If


    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUEdit.Click


        If btnUEdit.Text = "Edit" Then
            btnUEdit.Text = "Cancel"
            btnUSave.Enabled = True
            txtUsername.Enabled = True
        Else
            txtUsername.Text = ld.GetID("Select [User_ID] from tblUser Where [User_Stat] = -1", "User_ID")
            btnUEdit.Text = "Edit"
            btnUSave.Enabled = False
            txtUsername.Enabled = False

        End If

    End Sub

    Private Sub btnUSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUSave.Click

        If txtUsername.Text <> Nothing Then
            ld.SaveChanges("User_ID", txtUsername.Text, Val(ld.GetID("Select [ID] from tblUser Where User_Stat = -1", "ID")))
            LoadValue()
            MsgBox("Username Saved!!!")
            btnUSave.Enabled = False
            txtUsername.Enabled = False
            btnUEdit.Text = "Edit"
        Else
            MsgBox("Fill in the username!!!")
            txtUsername.Focus()
        End If

    End Sub

    Private Sub btnCEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCEdit.Click
        If btnCEdit.Text = "Edit" Then
            btnCEdit.Text = "Cancel"
            btnCSave.Enabled = True
            txtCritical.Enabled = True
        Else
            txtCritical.Text = ld.GetID("Select [CriticalLevel] from tblUser Where [User_Stat] = -1", "CriticalLevel")
            btnCEdit.Text = "Edit"
            btnCSave.Enabled = False
            txtCritical.Enabled = False
        End If

    End Sub

    Private Sub btnCSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCSave.Click

        If Val(txtCritical.Text) >= 0 Then
            ld.SaveChanges("CriticalLevel", txtCritical.Text, Val(ld.GetID("Select [ID] from tblUser Where User_Stat = -1", "ID")))
            LoadValue()
            btnCEdit.Text = "Edit"
            MsgBox("Critical Level Saved!")
            btnCSave.Enabled = False
            txtCritical.Enabled = False
        Else
            MsgBox("Invalid value!")
        End If

    End Sub

    Private Sub btnPSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPSave.Click

        If txtCurrentPass.Text = ld.GetID("Select [User_Pass] from tblUser Where User_Stat = -1", "User_Pass") And txtNewPass.Text = txtRetypePass.Text And txtNewPass.Text <> Nothing Then
            ld.SaveChanges("User_Pass", txtNewPass.Text, Val(ld.GetID("Select [ID] from tblUser Where User_Stat = -1", "ID")))
            LoadValue()
            btnPEdit.Text = "Edit"
            MsgBox("Password Saved!!!")
            btnPSave.Enabled = False
            txtCurrentPass.Enabled = False
            txtNewPass.Enabled = False
            txtRetypePass.Enabled = False
            txtNewPass.Clear()
            txtRetypePass.Clear()
        ElseIf txtRetypePass.Text <> txtNewPass.Text Then
            MsgBox("Password did not matched!")
            txtRetypePass.Focus()
        End If

       
       
    End Sub


    Private Sub btnPEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPEdit.Click

        If btnPEdit.Text = "Edit" Then
            btnPEdit.Text = "Cancel"
            btnPSave.Enabled = True
            txtCurrentPass.Enabled = True
            txtNewPass.Enabled = True
            txtRetypePass.Enabled = True
        Else
            txtCurrentPass.Text = txtUsername.Text = ld.GetID("Select [User_Pass] from tblUser Where [User_Stat] = -1", "User_Pass")
            btnPEdit.Text = "Edit"
            btnPSave.Enabled = False
            txtCurrentPass.Enabled = False
            txtNewPass.Enabled = False
            txtRetypePass.Enabled = False
            txtNewPass.Clear()
            txtRetypePass.Clear()

        End If
    End Sub

    Private Sub txtCritical_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCritical.KeyPress
        If Asc(e.KeyChar) >= 47 And Asc(e.KeyChar) <= 58 Or Asc(e.KeyChar) = 8 Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click

        Me.Hide()
        Main.TopMost = True
        AddOrRemove.Show()

    End Sub
End Class
