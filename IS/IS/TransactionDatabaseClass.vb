Public Class TransactionDatabaseClass
    Private con As New OleDb.OleDbConnection
    Private dataAdapter As OleDb.OleDbDataAdapter
    Public dataSet As New DataSet
    Private dataProvider As String = "Provider=Microsoft.ACE.OLEDB.12.0;"
    Private dataSource As String = "Data Source = " & System.Environment.CurrentDirectory & "\Inventory.accdb"
    'Provider=Microsoft.ACE.OLEDB.12.0;Data Source="C:\Users\pukulot\Documents\Visual Studio 2010\Projects\POS\POS\bin\Debug\inventory.accdb";Persist Security Info=True;User ID=admin



    ''End of delete
    ''Fill the combobox depending of the field name

    Public Function Fill(ByVal sql As String) As String

        con.Close()

        con.ConnectionString = dataProvider & dataSource
        con.Open()
        dataAdapter = New OleDb.OleDbDataAdapter("Select Distinct [" & sql & "] from Items", con)
        Dim tempDs As New DataSet
        dataAdapter.Fill(tempDs, "Combobox")
        Dim combo As String = Nothing

        For x As Integer = 0 To tempDs.Tables("Combobox").Rows.Count - 1
            combo &= tempDs.Tables("Combobox").Rows(x).Item(sql) & ";"

        Next
        dataAdapter.Dispose()
        con.Dispose()
        Return combo
    End Function

    ''Énd of fill here

    ''Fill the datagrid depending on the type
    Public Sub FillDataWithType(ByVal sql As String, ByVal sql2 As String)
        Dim temp As String = "Select [ID],[Product_Name],[Description],[Brand],[Type],[Size],[Unit],[Price] From [Items] Where "
        con.Close()
        con.ConnectionString = dataProvider & dataSource
        con.Open()
        dataSet = New DataSet


        sql = "[" & sql & "] = " & "'" & sql2 & "'"

        'sql = "[" & sql & "] = " & sql2
        dataAdapter = New OleDb.OleDbDataAdapter(temp & sql, con)

        Try
            dataAdapter.Fill(dataSet, "Inventory")
        Catch ex As Exception
            sql = sql.Replace("'" & sql2 & "'", sql2)
            dataAdapter = New OleDb.OleDbDataAdapter(temp & sql, con)
            dataAdapter.Fill(dataSet, "Inventory")
        End Try
        dataAdapter.Dispose()
        con.Dispose()
    End Sub

    ''end of filling the datagrid


    ''Updating query
    Public Sub DatabaseClass(ByVal sql As String)
        con.Close()
        con.ConnectionString = dataProvider & dataSource
        con.Open()
        dataSet = New DataSet()
        dataAdapter = New OleDb.OleDbDataAdapter(sql, con)
        dataAdapter.Fill(dataSet, "Inventory")
        dataAdapter.Dispose()
        con.Dispose()

        ''MsgBox(dataSource)

    End Sub


    ''Paying and Pay query

    Public Sub PayItems(ByVal x As Integer, ByVal sql As String)
        con.Close()
        con.ConnectionString = dataProvider & dataSource
        con.Open()
        sql = "Update Items Set [Qty] = " & Val(sql) & " Where [ID] = " & x
        Dim cmd As New OleDb.OleDbCommand(sql, con)
        Try
            cmd.ExecuteNonQuery()
            cmd.Dispose()
            dataAdapter.Dispose()
            con.Dispose()
            AddItemsToSoldRecords(x)
        Catch e As Exception
            MsgBox(e.ToString)
        End Try
    End Sub

    ''Add items in tblSoldRecords
    Public Sub AddItemsToSoldRecords(ByVal x As Integer)

        con.Close()
        con.ConnectionString = dataProvider & dataSource
        con.Open()
        Dim cmd As New OleDb.OleDbCommand("Insert into tblSoldRecord([Product_Name],[Total_Sold_Qty],[Time_Sold],[Day_Sold],[Month_Sold],[Year_Sold],[Total_Earned]) Values('" & x & "','" & quantity & "','" & t & "','" & d & "','" & m & "','" & y & "','" & price & "')", con)
        Try
            cmd.ExecuteNonQuery()
            cmd.Dispose()
            dataAdapter.Dispose()
            con.Dispose()
        Catch e As Exception
            MsgBox(e.ToString)
        End Try

    End Sub

    Public t = Nothing, m = Nothing, d = Nothing, y As String = Nothing
    Public price As Decimal = 0.0
    Public quantity As Integer = 0
    Public Sub todaysDate(ByRef t As String, ByRef m As String, ByRef d As String, ByRef y As String)
        Dim todaysMonth As String = MonthName(Integer.Parse(Date.Now.ToString("MM")), True)
        Dim todaysYear As String = Date.Now.ToString("yyyy")
        Dim todaysDay As String = Date.Now.ToString("dd")
        Dim todaysTime As String = Date.Now.ToString("HH:mm:ss")

        d = todaysDay
        y = todaysYear
        m = todaysMonth
        t = todaysTime
    End Sub

    Public Sub setPriceTo(ByRef price As Decimal, ByVal newPrice As Decimal)
        price = newPrice
    End Sub

    Public Sub setQuantityTo(ByRef quantity As Integer, ByVal newPrice As Integer)
        quantity = newPrice
    End Sub
    ''End of paying
    ''

    ''Fill the datagrid depending on the type update
    Public Sub FillDataWithType(ByVal sql As String, ByVal sql2 As String, ByVal sql3 As String)
        Dim temp As String = "Select [ID],[Product_Name],[Description],[Brand],[Type],[Qty],[Size],[Unit],[Price] From [Items] Where "
        con.Close()
        con.ConnectionString = dataProvider & dataSource
        con.Open()
        dataSet = New DataSet


        sql = "[" & sql & "] = " & "'" & sql2 & "'"

        'sql = "[" & sql & "] = " & sql2
        dataAdapter = New OleDb.OleDbDataAdapter(temp & sql, con)

        Try
            dataAdapter.Fill(dataSet, "Inventory")
        Catch ex As Exception
            sql = sql.Replace("'" & sql2 & "'", sql2)
            dataAdapter = New OleDb.OleDbDataAdapter(temp & sql, con)
            dataAdapter.Fill(dataSet, "Inventory")
        End Try
        dataAdapter.Dispose()
        con.Dispose()

    End Sub

    ''end of filling the datagrid

    ''Updating query ends here


End Class
