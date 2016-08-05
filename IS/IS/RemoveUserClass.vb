Public Class RemoveUserClass
    Dim dataProvider As String = "Provider = Microsoft.ACE.OLEDB.12.0;Data Source ="
    Dim path As String = System.Environment.CurrentDirectory & "\Identity.accdb;JET OLEDB:Database Password=alenigumasing"
    Dim con As New OleDb.OleDbConnection
    Dim dataAdapter As New OleDb.OleDbDataAdapter
    Public ds As New DataSet

    Public Sub ViewData()
        con.ConnectionString = dataProvider & path
        con.Open()
        ds = New DataSet
        dataAdapter = New OleDb.OleDbDataAdapter("Select [ID],[User_ID] from tblUser", con)
        dataAdapter.Fill(ds, "Users")
        con.Dispose()
        dataAdapter.Dispose()
        ds.Dispose()
    End Sub

    Public Sub RemoveUser(ByVal ID As Integer)
        con.ConnectionString = dataProvider & path
        con.Open()
        Dim cmd As New OleDb.OleDbCommand("Delete from tblUser Where [ID] =" & ID, con)

        Try
            cmd.ExecuteNonQuery()
            cmd.Dispose()
            con.Dispose()
            MsgBox("User ID " & ID & " has been removed!")
        Catch ex As Exception
            MsgBox(ex.ToString())
        End Try

    End Sub


End Class
