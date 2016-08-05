Public Class TopsellerDatabase
    Dim con As New OleDb.OleDbConnection()
    Public dataSet As DataSet
    Dim stringProvider As String = "Provider = Microsoft.ACE.OLEDB.12.0;Data Source =" & System.Environment.CurrentDirectory & "\Inventory.accdb;"
    Public dataTable As DataTable
    Dim cmd As OleDb.OleDbCommand
    Dim dataAdapter As OleDb.OleDbDataAdapter
    Dim sql As String

    'Public Sub Connect(ByVal months As String, ByVal years As String)
    '    con.ConnectionString = stringProvider
    '    con.Open()
    '    dataSet = New DataSet
    '    dataTable = New DataTable

    '    sql = "Select Items.[ID], Items.[Product_Name], Sum(tblSoldRecord.[Total_Sold_Qty]) as Qty_Sold, Sum(tblSoldRecord.[Total_Earned]) as Earnings " _
    '       & ",tblSoldRecord.[Month_Sold], tblSoldRecord.[Year_Sold] from Items " _
    '       & "Inner Join tblSoldRecord On Items.[ID] = tblSoldRecord.[Product_Name] " _
    '       & "Where tblSoldRecord.[Year_Sold] = '" & years & "' And tblSoldRecord.[Month_Sold] = '" & months & "' Group By Items.[ID],Items.Product_Name,tblSoldRecord.[Month_Sold],tblSoldRecord.[Year_Sold]"

    '    cmd = New OleDb.OleDbCommand(sql, con)
    '    cmd.ExecuteNonQuery()
    '    dataAdapter = New OleDb.OleDbDataAdapter(sql, con)
    '    dataAdapter.Fill(dataTable)
    '    dataAdapter.Fill(dataSet, "Inventory")
    '    con.Dispose()
    '    cmd.Dispose()
    '    dataAdapter.Dispose()
    'End Sub

    Public Sub Connect(ByVal months As String, ByVal years As String)
        con.ConnectionString = stringProvider
        con.Open()
        dataSet = New DataSet
        dataTable = New DataTable

        sql = "Select Items.[ID], Items.[Product_Name], Sum(tblSoldRecord.[Total_Sold_Qty]) as Qty_Sold, Sum(tblSoldRecord.[Total_Earned]) as Earnings " _
           & ",tblSoldRecord.[Month_Sold], tblSoldRecord.[Year_Sold] from Items " _
           & "Inner Join tblSoldRecord On Items.[ID] = tblSoldRecord.[Product_Name] " _
           & "Where tblSoldRecord.[Year_Sold] = '" & years & "' And tblSoldRecord.[Month_Sold] = '" & months & "' Group By Items.[ID],Items.Product_Name,tblSoldRecord.[Month_Sold],tblSoldRecord.[Year_Sold] Order By Sum(tblSoldRecord.[Total_Sold_Qty]) DESC"

        cmd = New OleDb.OleDbCommand(sql, con)
        cmd.ExecuteNonQuery()
        dataAdapter = New OleDb.OleDbDataAdapter(sql, con)
        dataAdapter.Fill(dataTable)
        dataAdapter.Fill(dataSet, "Inventory")
        con.Dispose()
        cmd.Dispose()
        dataAdapter.Dispose()
    End Sub

End Class
