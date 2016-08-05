Public Class Transaction

    Public db As New TransactionDatabaseClass
    Private Sub btnPayOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPayOrder.Click

        If Val(txtCash.Text) >= convertToDecimal(txtTotalCost.Text) Then
            btnPayOrder.Enabled = False
            btnRemove.Enabled = False
            db.todaysDate(db.t, db.m, db.d, db.y)

            Dim temp As Integer = dGridItems.Rows.Count - 1

            For x = 0 To temp
                For y = 0 To dGrid.Rows.Count - 1
                    If dGridItems.Rows(x).Cells("ID").Value = dGrid.Rows(y).Cells("ID").Value Then
                        db.setPriceTo(db.price, CDec(dGridItems.Rows(x).Cells("Cost").Value))
                        db.setPriceTo(db.quantity, CInt(dGridItems.Rows(x).Cells("Qty").Value))

                        Dim s As String = dGrid.Rows(y).Cells("Qty").Value - dGridItems.Rows(x).Cells("Qty").Value
                        db.PayItems(dGrid.Rows(y).Cells("ID").Value, s)
                        Exit For
                    End If
                Next
            Next

            refresher()
            dGridItems.Rows.Clear()
            txtCash.Text = "0.00"
            MsgBox("Transaction Complete")
            Main.Enabled = True
            Main.Button3.PerformClick()
            Main.Enabled = False
        Else
            MsgBox("Please enter cash amount in decimal format.")
            txtCash.Focus()
        End If

    End Sub

    Public Function textBoxContent() As Boolean
        Return True
    End Function

    ''Clear text boxes
    Public Sub clearTextBoxes()
        txtBrandName.Clear()
        txtProdName.Clear()
        txtDescription.Clear()
        txtPrice.Clear()
        txtUnit.Clear()
        txtQty.Clear()
        txtType.Clear()
        txtSize.Clear()
    End Sub
    ''Set Value of the textbox according to their corresponding value
    Public Sub setTextboxValue()
        txtBrandName.Text = dGrid.CurrentRow.Cells("Brand").Value.ToString()
        txtProdName.Text = dGrid.CurrentRow.Cells("Product_Name").Value.ToString()
        txtDescription.Text = dGrid.CurrentRow.Cells("Description").Value.ToString()
        txtPrice.Text = dGrid.CurrentRow.Cells("Price").Value.ToString()
        txtUnit.Text = dGrid.CurrentRow.Cells("Unit").Value.ToString()
        txtQty.Text = dGrid.CurrentRow.Cells("Qty").Value.ToString()
        txtType.Text = dGrid.CurrentRow.Cells("Type").Value.ToString()
        txtSize.Text = dGrid.CurrentRow.Cells("Size").Value.ToString()

        setOrderDescriptionValue(dGrid.CurrentRow.Cells("ID").Value.ToString(), txtProdName.Text, txtQty.Text)
    End Sub

    Public Sub setOrderDescriptionValue(ByVal id As String, ByVal name As String, ByVal qty As String)
        txtOrderID.Text = id
        txtOrderName.Text = name
        txtOrderQty.Text = qty
    End Sub


    Public FieldNames() As String = {"ID", "Product_Name", "Description", _
                                     "Brand", "Type", "Qty", "Size", _
                                    "Unit", "Price", "Total"}

    Private Sub Transaction_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Main.Enabled = True

    End Sub
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        For x = 0 To FieldNames.Length - 1
            If x <> 9 Then
                dGrid.Columns.Add(FieldNames(x), FieldNames(x))
                comboFilter.Items.Add(FieldNames(x))
            End If
        Next
        'DataGridView1.Columns("Product_Name").Width = 200
        dGrid.Columns("ID").Width = 60
        dGrid.Columns("Unit").Width = 60
        dGrid.Columns("Qty").Width = 56
        refresher()
        dGridItemsWindow()
    End Sub


    ''Initialize items order dgv
    Private Sub dGridItemsWindow()
        dGridItems.Columns.Add("ID", "ID")
        dGridItems.Columns.Add("ItemName", "ItemName")
        dGridItems.Columns.Add("Unit", "Unit")
        dGridItems.Columns.Add("Qty", "Qty")
        dGridItems.Columns.Add("Cost", "Cost")
        dGridItems.Columns("ID").Width = 40
        dGridItems.Columns("Unit").Width = 40
        dGridItems.Columns("Qty").Width = 40
        ''dGridItems.Columns("Cost").Width = 30
    End Sub
    ''Add selected product in order list
    Private Sub dGridItemsAddWindow(ByVal qty As Integer)
        Dim x As Integer = 0

        If checkID(x) = False Then
            dGridItems.Rows.Add()
            editThis(x, qty, False)
        Else
            editThis(x, qty, True)
        End If

        Dim temp As String = ""
        Dim dTemp As Decimal = 0
        For x = 0 To dGridItems.Rows.Count() - 1
            dTemp += dGridItems.Rows(x).Cells("Cost").Value
        Next

        txtTotalCost.Text = "Php " & Format(dTemp, "Standard")

        If Val(txtCash.Text) > 0 Then
            txtChange.Text = "Php " & Format(Val(txtCash.Text) - Val(txtTotalCost.Text.Substring(4, txtTotalCost.TextLength - 4)), "Standard")
        Else
            txtChange.Text = "Php 0.00"
        End If

    End Sub

    ''condition if x exist
    Private Sub editThis(ByVal x As Integer, ByVal qty As Integer, ByVal bool As Boolean)


        If bool = False Then
            x = dGridItems.Rows.Count - 1
            dGridItems.Rows(x).Cells("ID").Value = dGrid.CurrentRow().Cells("ID").Value
            dGridItems.Rows(x).Cells("ItemName").Value = txtProdName.Text
            dGridItems.Rows(x).Cells("Unit").Value = txtUnit.Text
            dGridItems.Rows(x).Cells("Qty").Value = qty
            dGridItems.Rows(x).Cells("Cost").Value = Format(Val(dGridItems.Rows(x).Cells("Qty").Value) * Val(txtPrice.Text), "Standard")

        Else
            Dim temp As Integer = dGridItems.Rows(x).Cells("Qty").Value + qty
            If temp <= Val(txtQty.Text) Then
                dGridItems.Rows(x).Cells("Qty").Value += qty
                dGridItems.Rows(x).Cells("Cost").Value = Format(Val(dGridItems.Rows(x).Cells("Qty").Value) * Val(txtPrice.Text), "Standard")

            ElseIf temp > Val(txtQty.Text) Then
                MsgBox("The Oder Qty is greater than the stock!")
            Else
                MsgBox("Invalid Input!")
            End If

        End If


    End Sub

    ''Check if id # exist
    Private Function checkID(ByRef val As Integer) As Boolean
        For x = 0 To dGridItems.Rows.Count - 1
            val = x
            If dGridItems.Rows(x).Cells("ID").Value = dGrid.CurrentRow().Cells("ID").Value Then
                Return True
            End If

        Next
        Return False
    End Function


    ''Refresh
    Private Sub refresher()
        db = New TransactionDatabaseClass
        Dim tempString As String = Nothing
        For x = 0 To FieldNames.Length - 1
            If x <> 9 Then
                tempString &= "[" & FieldNames(x) & "]"
                If x < FieldNames.Length - 2 Then
                    tempString &= ","
                End If
            End If
        Next

        db.DatabaseClass("Select " & tempString & " From Items")


        dGrid.Rows.Clear()
        For x As Integer = 0 To db.dataSet.Tables("Inventory").Rows.Count - 1
            dGrid.Rows.Add()
            For y As Integer = 0 To db.dataSet.Tables("Inventory").Columns.Count - 1
                dGrid.Rows(x).Cells(y).Value = db.dataSet.Tables("Inventory").Rows(x).Item(y)
            Next
        Next

        If chkBoxfilter.Checked = True Then
            comboFilterNames.Text = Nothing
            comboFilter.Text = Nothing
        End If
        setTextboxValue()
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        refresher()
    End Sub

    Private Sub chkBoxfilter_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkBoxfilter.CheckedChanged
        If chkBoxfilter.Checked = True Then
            comboFilterNames.Enabled = True
            comboFilter.Enabled = True
        Else
            comboFilterNames.Enabled = False
            comboFilter.Enabled = False
            comboFilter.Text = ""
            comboFilterNames.Text = ""
            btnRefresh.PerformClick()


        End If
    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Main.Enabled = True
        Me.Close()

    End Sub

    Private Sub comboFilter_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles comboFilter.SelectedIndexChanged

        If comboFilter.Text <> Nothing Then
            comboFilterNames.Text = ""
            comboFilterNames.Items.Clear()

            Dim s() As String = db.Fill(comboFilter.Text).Split(";")

            For x As Integer = 0 To s.Length - 2
                comboFilterNames.Items.Add(s(x))
            Next
        End If
    End Sub

    Private Sub comboFilterNames_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles comboFilterNames.SelectedIndexChanged

        If comboFilter.Text = Nothing Or comboFilterNames.Text = Nothing Then

        Else

            db.FillDataWithType(comboFilter.Text, comboFilterNames.Text, "")
            dGrid.Rows.Clear()

            For x As Integer = 0 To db.dataSet.Tables("Inventory").Rows.Count - 1
                dGrid.Rows.Add()
                For y As Integer = 0 To db.dataSet.Tables("Inventory").Columns.Count - 1
                    dGrid.Rows(x).Cells(y).Value = db.dataSet.Tables("Inventory").Rows(x).Item(y)
                Next
            Next


        End If
        setTextboxValue()
    End Sub

    Private Sub diableButtons(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles comboFilterNames.KeyPress, comboFilter.KeyPress
        e.Handled = True
    End Sub

    Private Sub DataGridView1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dGrid.CellClick
        setTextboxValue()
    End Sub


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
                setTextboxValue()
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


            If TextBox1.Text <> Nothing Then
                lblDisplay.Text = ctr & " results found!"
            Else
                lblDisplay.Text = Nothing
            End If
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ''Main.Show()
        Me.Close()
    End Sub

    Private Sub dGrid_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dGrid.KeyUp
        setTextboxValue()
    End Sub

    Private Sub btnAddItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddItem.Click

        Me.TopMost = False

        Dim temp As Integer = Val(txtOrderQty.Text)

        If temp > Val(txtQty.Text) Then
            MsgBox("The Quantity that you have entered is bigger than the stock!")
        ElseIf temp <= Val(txtQty.Text) And temp > 0 Then
            dGridItemsAddWindow(temp)
            btnPayOrder.Enabled = True
            btnRemove.Enabled = True
        Else
            MsgBox("Invalid Input!")
        End If

        Me.TopMost = True
        calculateChange()
    End Sub

    ''Convert Standard to normal
    Private Function convertToDecimal(ByVal x As String) As Double
        x = x.Substring(4, txtTotalCost.TextLength - 4)
        If x.Contains(",") Then
            x = x.Replace(",", "")
        End If

        Return Convert.ToDouble(x)
    End Function

    Private Sub calculateChange()
        Dim temp As Double = convertToDecimal(txtTotalCost.Text)

        If Val(txtCash.Text) > 0 And Val(txtCash.Text) >= temp Then
            txtCash.Text = txtCash.Text
            txtChange.Text = "Php " & Format(Val(txtCash.Text) - Val(temp), "Standard")
        Else
            txtChange.Text = "Php 0.00"
        End If
    End Sub
    Dim flag As Boolean
    Private Sub txtCash_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCash.KeyPress

        If Asc(e.KeyChar) >= 46 And Asc(e.KeyChar) <= 58 Or Asc(e.KeyChar) = 8 Then
            e.Handled = False

            If txtCash.Text <> Nothing And txtCash.Text.Contains(".") And Asc(e.KeyChar) = 46 Then
                e.Handled = True
            End If

        Else
            e.Handled = True
        End If
    End Sub


    Private Sub txtCash_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCash.KeyUp
        calculateChange()
    End Sub



    Private Sub dGridItems_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dGridItems.CellClick
        If dGridItems.RowCount - 1 >= 0 Then
            setOrderDescriptionValue(dGridItems.CurrentRow.Cells("ID").Value, dGridItems.CurrentRow.Cells("ItemName").Value, dGridItems.CurrentRow.Cells("Qty").Value)
        End If
    End Sub

    Private Sub dGridItems_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dGridItems.KeyUp
        If dGridItems.RowCount - 1 > 0 Then
            setOrderDescriptionValue(dGridItems.CurrentRow.Cells("ID").Value, dGridItems.CurrentRow.Cells("ItemName").Value, dGridItems.CurrentRow.Cells("Qty").Value)
        End If
    End Sub

    Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemove.Click
        Try
            dGridItems.Rows.Remove(dGridItems.CurrentRow)
            Dim temp As String = ""
            Dim dTemp As Decimal = 0
            For x = 0 To dGridItems.Rows.Count() - 1
                dTemp += dGridItems.Rows(x).Cells("Cost").Value
            Next

            txtTotalCost.Text = "Php " & Format(dTemp, "Standard")
            calculateChange()

            If dGridItems.Rows.Count - 1 < 0 Then
                btnRemove.Enabled = False
                btnPayOrder.Enabled = False
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub txtOrderQty_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtOrderQty.KeyPress

        If Asc(e.KeyChar) >= 48 And Asc(e.KeyChar) <= 58 Or Asc(e.KeyChar) = 8 Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txtOrderQty_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtOrderQty.TextChanged

    End Sub


    Private Sub dGridItems_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dGridItems.CellContentClick

    End Sub

    Private Sub txtCash_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCash.TextChanged

    End Sub
End Class
