Public Class SettingsDatabase

    Dim dataProvider As String = "Provider = Microsoft.ACE.OLEDB.12.0;Data Source = "
    Dim dataSource As String = System.Environment.CurrentDirectory & "\Identity.accdb;Jet OLEDB:Database Password=alenigumasing"
    Dim con As New OleDb.OleDbConnection()
    Dim cmd As OleDb.OleDbCommand


    Dim dataAdapter As OleDb.OleDbDataAdapter
    Public dataSet As DataSet

    Public Sub AccessData(ByVal sql As String)

        con.ConnectionString = dataProvider & dataSource
        con.Open()
        dataSet = New DataSet

        dataAdapter = New OleDb.OleDbDataAdapter(sql, con)

        dataAdapter.Fill(dataSet, "Users")
        con.Dispose()
        dataAdapter.Dispose()
        dataSet.Dispose()
    End Sub

    ''Set User_Stat to logged in or logged out condition
    Public Sub LoginStat(ByVal id As Integer, ByVal stat As Integer)
        con.ConnectionString = dataProvider & dataSource
        con.Open()
        cmd = New OleDb.OleDbCommand("Update tblUser Set [User_Stat] = " & stat & " Where [ID] = " & id, con)
        MsgBox(id)
        Try
            cmd.ExecuteNonQuery()
            cmd.Dispose()
            con.Dispose()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Public Function GetID(ByVal sql As String, ByVal colName As String) As String
        con.ConnectionString = dataProvider & dataSource
        con.Open()
        dataSet = New DataSet
        dataAdapter = New OleDb.OleDbDataAdapter(sql, con)
        dataAdapter.Fill(dataSet, "Users")
        If dataSet.Tables("Users").Rows.Count - 1 >= 0 Then
            colName = dataSet.Tables("Users").Rows(dataSet.Tables("Users").Rows.Count - 1).Item(colName)
        End If
        con.Dispose()
        dataAdapter.Dispose()
        dataSet.Dispose()
        Return colName
    End Function


    Public Sub SaveChanges(ByVal colName As String, ByVal newVal As String, ByVal id As Integer)
        con.ConnectionString = dataProvider & dataSource
        con.Open()

        Try
            cmd = New OleDb.OleDbCommand("Update tblUser SET " & "[" & colName & "] = '" & newVal & "' Where [ID] = " & id, con)
            cmd.ExecuteNonQuery()
            cmd.Dispose()
            con.Dispose()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try



    End Sub
End Class
