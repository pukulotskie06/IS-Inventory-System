Public Class Main
    ''Autor pukulot
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click

        Dim con As New DatabaseClass
        con.DatabaseClass()
        dGrid.Rows.Clear()
        For x As Integer = 0 To con.dataSet.Tables("Inventory").Rows.Count - 1
            dGrid.Rows.Add()
            For y As Integer = 0 To con.dataSet.Tables("Inventory").Columns.Count - 1
                dGrid.Rows(x).Cells(y).Value = con.dataSet.Tables("Inventory").Rows(x).Item(y)
            Next
        Next

    End Sub

    Public Sub RefreshBusinessMain()
        Dim lds As New LoginDataBase()
        Label2.Text = lds.GetID("Select [User_Business] from tblUser Where [User_Stat] = -1", "User_Business") & " (Inventory)"

        Dim temp As String = lds.GetID("Select [User_Level] from tblUser Where [User_Stat] = -1", "User_Level")

        lblUser.Text = temp.ToUpper


            If temp = "admin" Then
                btnAdd.Visible = True
                btnCritical.Visible = True
                btnEdit.Visible = True
                btnTop.Visible = True
                btnDelete.Visible = True
            End If

    End Sub

    Private Sub Main_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        RefreshBusinessMain()
        dGrid.Columns.Add("ID", "ID")
        dGrid.Columns.Add("Product_Name", "Product_Name")
        dGrid.Columns.Add("Description", "Description")
        dGrid.Columns.Add("Brand", "Brand")
        dGrid.Columns.Add("Type", "Type")
        dGrid.Columns.Add("Qty", "Qty")
        dGrid.Columns.Add("Size", "Size")
        dGrid.Columns.Add("Unit", "Unit")
        dGrid.Columns.Add("Price", "Price")
        dGrid.Columns.Add("Total", "Total")

        'DataGridView1.Columns("Product_Name").Width = 200
        dGrid.Columns("Description").Width = 200
        '' DataGridView1.Columns("Price").Width = 160
        ''DataGridView1.Columns("Total").Width = 170
        Button3.PerformClick()
    End Sub

    ''Searching starts here
    Dim rowCtr As Integer
    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress


        If Asc(e.KeyChar) = 13 And TextBox1.Text <> Nothing Then
            If rowCtr <= ctr Then
                dGrid.ClearSelection()
                dGrid.Rows(Val(row(rowCtr))).Selected = True
                dGrid.CurrentCell = dGrid.SelectedCells(0)
                rowCtr += 1
                If rowCtr = ctr Then
                    rowCtr = 0
                End If
            End If
        End If
       
    End Sub


    Dim ctr As Integer
    Dim row As New Collections.ArrayList
    Private Sub TextBox1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox1.KeyUp

        If e.KeyCode <> 13 Then
            row.Clear()
            Dim temp As Integer = -1
            ctr = 0
            For x = 0 To dGrid.Rows.Count - 1
                For y = 0 To dGrid.Rows(x).Cells.Count - 1
                    If dGrid.Rows(x).Cells(y).Value.ToString.ToLower.Contains(TextBox1.Text.ToString.ToLower) Then
                        If temp <> x Then
                            ctr += 1
                            temp = x
                            row.Add(x)
                        End If
                    End If
                Next

            Next

        End If
    End Sub
   
    ''Searching ends here

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Me.Enabled = False
        Delete.Show()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Me.Enabled = False
        Add.Show()
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        Me.Enabled = False
        UpdateForm.Show()
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCritical.Click
        Me.Enabled = False
        Critical.Show()
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTransact.Click
        Me.Enabled = False
        Transaction.Show()
    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTop.Click
        Me.Enabled = False
        Topseller.Show()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim db As New LoginDatabase
        db.LoginStat(Val(db.GetID("Select * From tblUser Where User_Stat = -1", "ID")), 0)
        login.Show()
        Me.Close()
    End Sub

    Private Sub btnSettings_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSettings.Click

        SettingsForm.Show()
        Me.Enabled = False
    End Sub


End Class
