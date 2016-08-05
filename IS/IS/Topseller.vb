Public Class Topseller
    Dim db As New TopsellerDatabase()
    Dim flag As Boolean

    Private Sub Topseller_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Main.Enabled = True
    End Sub
    Private Sub Topseller_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        flag = False
        ComboBox1.Items.Clear()
        ComboBox2.Items.Clear()
        For x = 1 To 12
            ComboBox1.Items.Add(MonthName(x, True))
        Next

        For x = 2000 To CInt(Date.Now.ToString("yyyy"))
            ComboBox2.Items.Add(x)
        Next
        ComboBox1.Text = ComboBox1.Items(0)
        ComboBox2.Text = ComboBox2.Items(0)
        Button1.PerformClick()
        flag = True
    End Sub



    Private Sub dGridView_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dGridView.CellContentClick

    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        dGridView.Rows.Clear()
        dGridView.Columns.Clear()
        TextBox1.Text = 0
        db.Connect(ComboBox1.Text, ComboBox2.Text)

        For x = 0 To db.dataTable.Columns.Count - 1
            Dim temp As String = db.dataTable.Columns(x).ToString()
            dGridView.Columns.Add(temp, temp)
        Next

        For x = 0 To db.dataSet.Tables("Inventory").Rows.Count - 1
            dGridView.Rows.Add()
            For cols = 0 To db.dataTable.Columns.Count - 1
                dGridView.Rows(x).Cells(cols).Value = db.dataSet.Tables("Inventory").Rows(x).Item(cols)
            Next
            TextBox1.Text = Val(TextBox1.Text) + dGridView.Rows(x).Cells("Earnings").Value
        Next
        TextBox1.Text = "Php " & Format(CDec(TextBox1.Text), "Standard")

        If dGridView.Rows.Count() < 1 And flag = True Then
            MsgBox("No records found!")
        End If
    End Sub

    Private Sub disableKeys(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ComboBox2.KeyPress, ComboBox1.KeyPress
        e.Handled = True
    End Sub
End Class
