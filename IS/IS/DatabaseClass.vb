Public Class DatabaseClass
    Private con As New OleDb.OleDbConnection
    Private dataAdapter As OleDb.OleDbDataAdapter
    Public dataSet As DataSet
    Private dataProvider As String = "Provider=Microsoft.ACE.OLEDB.12.0;"
    Private dataSource As String = "Data Source = " & System.Environment.CurrentDirectory & "\Inventory.accdb;Persist Security Info=True;User ID=admin"
    'Provider=Microsoft.ACE.OLEDB.12.0;Data Source="C:\Users\pukulot\Documents\Visual Studio 2010\Projects\POS\POS\bin\Debug\inventory.accdb";Persist Security Info=True;User ID=admin
    Public dataTables As DataTable

    Public Sub DatabaseClass()


        con.ConnectionString = dataProvider & dataSource
        con.Open()
        dataSet = New DataSet
        dataAdapter = New OleDb.OleDbDataAdapter("Select * From Items", con)
        dataAdapter.Fill(dataSet, "Inventory")
        con.Dispose()
        dataAdapter.Dispose()
        ''MsgBox(dataSource)

    End Sub

    Public Sub DatabaseClass(ByVal sql As String)

        con.ConnectionString = dataProvider & dataSource
        con.Open()
        dataSet = New DataSet
        dataAdapter = New OleDb.OleDbDataAdapter(sql, con)
        dataAdapter.Fill(dataSet, "Inventory")
        dataTables = New DataTable
        dataAdapter.Fill(dataTables)
        con.Dispose()
        dataAdapter.Dispose()
        ''MsgBox(dataSource)

    End Sub

    ''Critical Function starts here

    Public Function DataSets() As DataSet
        Return dataSet
    End Function

    Public Function DataTabless() As DataTable
        Return dataTables
    End Function
    ''Critical Function Ends here


    'Add function for the
    'Add function for the
    Public Sub Add(ByVal items() As String)
        con.Close()
        con.ConnectionString = dataProvider & dataSource
        con.Open()

        Dim sqlCmd As String = "INSERT INTO Items ([Product_Name],[Description],[Brand],[Type],[Size],[Qty],[Unit],[Price]) Values (?,?,?,?,?,?,?,?)"

        Dim cmd As New OleDb.OleDbCommand(sqlCmd, con)

        cmd.Parameters.Add(New OleDb.OleDbParameter("Product_Name", items(0)))
        cmd.Parameters.Add(New OleDb.OleDbParameter("Description", items(1)))
        cmd.Parameters.Add(New OleDb.OleDbParameter("Brand", items(2)))
        cmd.Parameters.Add(New OleDb.OleDbParameter("Type", items(3)))
        cmd.Parameters.Add(New OleDb.OleDbParameter("Size", items(4)))
        cmd.Parameters.Add(New OleDb.OleDbParameter("Qty", items(5)))
        cmd.Parameters.Add(New OleDb.OleDbParameter("Unit", items(6)))
        cmd.Parameters.Add(New OleDb.OleDbParameter("Price", items(7)))

        Try
            cmd.ExecuteNonQuery()
            cmd.Dispose()
            con.Dispose()
        Catch e As Exception
            MsgBox(e.ToString)
        End Try

        MsgBox("You have successfully added a new item")

    End Sub
    ''end of add function
    ''end of add function


    ''Delete code starts here

    ''Delete 
    Public Sub DeleteQuery(ByVal x As Integer)

        Dim sqlCmd As String = "DELETE FROM Items Where ID = ?"
        con.ConnectionString = dataProvider & dataSource
        con.Open()

        Dim cmd As New OleDb.OleDbCommand(sqlCmd, con)

        cmd.Parameters.Add(New OleDb.OleDbParameter("ID", x))


        Try
            cmd.ExecuteNonQuery()
            cmd.Dispose()
            con.Dispose()
            MsgBox("ID no " & x & " successfully deleted!")
        Catch ex As Exception
            MsgBox(ex.ToString)

        End Try

    End Sub



    ''End of delete
    ''Fill the combobox depending of the field name

    Public Function Fill(ByVal sql As String) As String

        con.ConnectionString = dataProvider & dataSource
        con.Open()
        dataAdapter = New OleDb.OleDbDataAdapter("Select Distinct [" & sql & "] from Items", con)
        Dim tempDs As New DataSet
        dataAdapter.Fill(tempDs, "Combobox")
        Dim combo As String = Nothing

        For x As Integer = 0 To tempDs.Tables("Combobox").Rows.Count - 1
            combo &= tempDs.Tables("Combobox").Rows(x).Item(sql) & ";"

        Next
        con.Dispose()
        dataAdapter.Dispose()
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
        con.Dispose()
        dataAdapter.Dispose()
    End Sub

    ''end of filling the datagrid
    ''Delete code ends here



    ''Updating Code Starts here

    ''Updating Query
    Public Sub UpdateQuery(ByVal x As Integer, ByVal s As String)
        Dim tableFields() As String = s.Trim.Split(";")
        For y = 0 To tableFields.Length - 1
            '' MsgBox(tableFields(y))
        Next
        con.Close()
        Dim sqlCmd As String = "Update Items SET [Product_Name] = '" & tableFields(0) & "',[Description] = '" & tableFields(1) _
                               & "',[Brand] = '" & tableFields(2) & "',[Type] = '" & tableFields(3) _
                               & "',[Qty] = " & Val(tableFields(4)) & ",[Size] = '" & tableFields(5) _
                               & "',[Unit] = '" & tableFields(6) & "',[Price] = " & Val(tableFields(7)) & " Where ID = ?"
        con.ConnectionString = dataProvider & dataSource
        con.Open()

        Dim cmd As New OleDb.OleDbCommand(sqlCmd, con)

        cmd.Parameters.Add(New OleDb.OleDbParameter("ID", x))
        Try
            cmd.ExecuteNonQuery()
            cmd.Dispose()
            con.Dispose()
            MsgBox("ID no " & x & " successfully updated!")
        Catch ex As Exception
            MsgBox(ex.ToString)

        End Try

    End Sub

    ''Fill the datagrid depending on the type update
    Public Sub FillDataWithType(ByVal sql As String, ByVal sql2 As String, ByVal sql3 As String)
        Dim temp As String = "Select [ID],[Product_Name],[Description],[Brand],[Type],[Qty],[Size],[Unit],[Price] From [Items] Where "

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

        con.Dispose()
        dataAdapter.Dispose()
    End Sub

    ''end of filling the datagrid
    ''Updating query ends here

End Class
