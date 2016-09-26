Public Class db_class


#Region "Fields"

    Private connection_string As String = System.Configuration.ConfigurationManager.ConnectionStrings("Dev_connection_string").ConnectionString
    Private db_connection As OleDb.OleDbConnection
    Private db_command As OleDb.OleDbCommand
    Dim db_adapter As OleDb.OleDbDataAdapter
    Private db_dataset As DataSet

#End Region

#Region "Methods"

    Public Function exe_insert_and_get_id(Sql As String) As Integer
        'this method will execute an insert statement and return the id of the newly inserted record to be used as a foreign key in other tables

        Try
            Dim new_id As Integer
            db_connection = New OleDb.OleDbConnection(connection_string)
            db_command = New OleDb.OleDbCommand
            db_command.CommandText = Sql
            db_command.Connection = db_connection
            db_connection.Open()
            db_command.ExecuteNonQuery()
            Dim newcmd As New OleDb.OleDbCommand("SELECT @@IDENTITY", db_connection)
            new_id = newcmd.ExecuteScalar
            db_connection.Close()

            Return new_id
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function execute_fill_dataset(sql As String) As DataSet
        'this method will fill a dataset
        'could also use ExecuteScalar which will return a single value
        'could also use ExecuteReader which will return multiple rows and columns

        Try
            db_connection = New OleDb.OleDbConnection(connection_string)
            db_command = New OleDb.OleDbCommand
            db_command.CommandText = sql
            db_command.Connection = db_connection
            db_adapter = New OleDb.OleDbDataAdapter(db_command.CommandText, db_command.Connection)
            db_dataset = New DataSet
            db_adapter.Fill(db_dataset)
            Return db_dataset
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub execute_non_query(sql As String)
        'this method will execute a nonquery (returning nothing from the database such as UPDATE and INSERT queries)

        db_connection = New OleDb.OleDbConnection(connection_string)
        db_command = New OleDb.OleDbCommand
        db_command.CommandText = sql
        db_command.Connection = db_connection
        db_connection.Open()
        db_command.ExecuteNonQuery()
        db_connection.Close()
    End Sub

    Public Sub clear_connection_dataset()
        'clears all the resources needed to execute query
        db_adapter.Dispose()
        db_connection.Dispose()
        db_dataset.Dispose()
        db_command.Dispose()
    End Sub

    Public Sub clear_connection_nonquery()
        'clears all the resources needed to execute nonquery
        db_command.Dispose()
        db_connection.Dispose()
    End Sub

#End Region



End Class
