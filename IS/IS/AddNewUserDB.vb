Public Class AddNewUserDB
    Dim dataProvider As String = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source = "
    Dim path As String = System.Environment.CurrentDirectory & "\Identity.accdb;JET OLEDB:Database Password=alenigumasing;"
    Dim con As New OleDb.OleDbConnection()

    Public Sub AddNewUser(ByVal value() As String)

        con.ConnectionString = dataProvider & path
        con.Open()
        Dim cmd As New OleDb.OleDbCommand("Insert Into tblUser ([User_ID],[User_Pass],[User_Level],[User_Stat],[User_Business],[CriticalLevel]) Values (?,?,?,?,?,?)", con)

        Try
            cmd.Parameters.Add(New OleDb.OleDbParameter("[User_ID]", value(0)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("[User_Pass]", value(1)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("[User_Level]", value(2)))
            cmd.Parameters.Add(New OleDb.OleDbParameter("[User_Stat]", 0))
            cmd.Parameters.Add(New OleDb.OleDbParameter("[User_Business]", ""))
            cmd.Parameters.Add(New OleDb.OleDbParameter("[CriticalLevel]", 0))
            cmd.ExecuteNonQuery()
            con.Dispose()
            cmd.Dispose()
            MsgBox("New user has been added successfully!")
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

End Class
