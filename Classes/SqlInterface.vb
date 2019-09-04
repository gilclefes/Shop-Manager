Imports System.Data.SqlClient

Public Class SqlInterface

#Region " Singleton Constructor Methods "

    'Private Shared reference to this Class required to provide a Singleton instance
    Private Shared SqlInterfaceInstance As SqlInterface

    'Provides a Singleton reference to this Class Instance
    Public Shared Function GetInstance() As SqlInterface
        If (IsNothing(SqlInterfaceInstance)) Then
            SqlInterfaceInstance = New SqlInterface()
        End If
        Return SqlInterfaceInstance
    End Function

    'Private Class Constructor called by the Shared Singleton GetInstance Method
    Private Sub New()
        'Do not remove this sub. This prevents someone from instantiating another
        'SqlInterface Class Instance. Call the 'GetInstance()' method to get an
        'instance reference to this Class. This enforces a Singleton Pattern.
    End Sub

#End Region
#Region " Private Class Variables "

    Private _UsingTransaction As Boolean = False
    Private _Transaction As SqlTransaction = Nothing
    Private _TransConnection As SqlConnection = Nothing
    Private _TableAdapter As SqlDataAdapter = Nothing
    Private _TransCommand As SqlCommand = Nothing

#End Region
#Region "Transaction Methods"

    'Initiates a Transaction on a Typed DataSet TableAdapter Connection. This
    'transaction is automatically assigned to any other Typed DataSet TableAdapter
    'initialized through this Interface Class during an active Transaction until
    'the transaction is explicitly Committed or Rolled back through the SqlInterface
    'Class Instance. (Note: The Private Scope of this method is intentional)
    Private Function BeginTransaction(ByVal TableAdapter As SqlDataAdapter) As Boolean

        'Be sure we don't already have a transaction initiated
        If (Not IsNothing(_Transaction)) Then Return False

        'Set Class TableAdapter Object
        _TableAdapter = TableAdapter

        'Set Class Connection Object
        If (Not IsNothing(_TableAdapter.UpdateCommand)) Then
            _TransConnection = _TableAdapter.UpdateCommand.Connection
        ElseIf (Not IsNothing(_TableAdapter.InsertCommand)) Then
            _TransConnection = _TableAdapter.InsertCommand.Connection
        ElseIf (Not IsNothing(_TableAdapter.DeleteCommand)) Then
            _TransConnection = _TableAdapter.DeleteCommand.Connection
        ElseIf (Not IsNothing(_TableAdapter.SelectCommand)) Then
            _TransConnection = _TableAdapter.SelectCommand.Connection
        Else
            Throw New Exception("A Connection could not be established _
                because no Command Object has been initialized")
        End If

        'Open the DB Connection
        _TransConnection.Open()

        'Set the Class Transaction Object
        _Transaction = _TransConnection.BeginTransaction()

        'Set the Transaction property for any instantiated Command Objects
        If (Not IsNothing(_TableAdapter.UpdateCommand)) _
            Then _TableAdapter.UpdateCommand.Transaction = _Transaction
        If (Not IsNothing(_TableAdapter.InsertCommand)) _
            Then _TableAdapter.InsertCommand.Transaction = _Transaction
        If (Not IsNothing(_TableAdapter.DeleteCommand)) _
            Then _TableAdapter.DeleteCommand.Transaction = _Transaction
        If (Not IsNothing(_TableAdapter.SelectCommand)) _
            Then _TableAdapter.SelectCommand.Transaction = _Transaction

        Return True
    End Function

    'This method enlists Adapters used for Database Select 
    'Operations during an active Transaction into the current
    'Transaction and Connection so the Select operation is not blocked 
    'by the active Update Transaction.
    'This is required because the Auto-Generated TableAdpater Class 
    'is coded in such a way that the DataAdapter's
    'SelectCommand is not initialized like the 
    'Update, Insert and Delete Command Objects. The SelectCommand is instead
    'added to the TableAdapater internal CommandCollection 
    '(it's the ONLY Command object in the collection). So this is
    'somewhat of a hack to work around this but at least 
    'it keeps all the necessary code confined to the TableAdapter
    'Extension Class and this DAL Interface Class eliminating the need 
    'for any complicated code in the general application.
    Private Sub EnlistAdapterInTransaction(ByVal Adapter As Object)
        Adapter.SelectCommand.Transaction = Me._Transaction
        Adapter.SelectCommand.Connection = Me._TransConnection
    End Sub

    'Commits all DB changes performed during the Transaction and releases 
    'all resources and SQL DB connections.
    Public Function CommitTransaction() As Boolean
        If (Not IsNothing(_Transaction)) Then
            _Transaction.Commit()
            EndTransaction()
            Return True
        Else
            EndTransaction()
            Return False
        End If
    End Function

    'Rolls back all DB changes performed during the Transaction and 
    'releases all resources and SQL DB connections.
    Public Function RollBackTransaction() As Boolean
        If (Not IsNothing(_Transaction)) Then
            _Transaction.Rollback()
            EndTransaction()
            Return True
        Else
            Return False
        End If
    End Function

    'Handles cleanup for a DAL initiated transaction
    Private Sub EndTransaction()
        If (Not IsNothing(_TransConnection)) Then _TransConnection.Close()
        If (Not IsNothing(_Transaction)) Then _Transaction.Dispose()
        If (Not IsNothing(_TableAdapter)) Then _TableAdapter.Dispose()
    End Sub

#End Region
#Region " Public Class Methods "

    'Example method that executes a Select Operation on the DataBase 
    'with a check for an active
    'transaction. If a transaction is active on the Connection, 
    'the SelectCommand object from
    'the TableAdapter is enlisted into that Transaction 
    'so it is not blocked by the active Transaction.
    'Note: The Typed DataSet name shown in the example is 'TdSomeData'
    Public Function GetSomeDataByKey(ByVal Key As Integer) As TdSomeDataDataTable
        Dim TdAdapter As New TdSomeDataAdapter

        'See if an active transaction exists on the DAL and enlist 
        'the TableAdapter in the Transaction if there is.
        If (Not IsNothing(Me._Transaction)) Then EnlistAdapterInTransaction(TdAdapter)
        Return (TdAdapter.GetSomeData(Key))
    End Function

#End Region
#Region " Public Class Properties "

    'This Property provides access to an active Transaction object 
    'regardless of what Typed DataSet initiated the transaction.
    Public ReadOnly Property Transaction(ByVal TableAdapter As SqlDataAdapter) _
        As SqlTransaction
        Get
            If ((Me.UsingTransAction) AndAlso (IsNothing(_Transaction))) Then
                Me.BeginTransaction(TableAdapter)
            End If
            Return (_Transaction)
        End Get
    End Property

    'Class flag indicating a Transaction is to be used for 
    'subsequent DB changes until committed or rolled back.
    'This flag is required to initiate a transaction on 
    'subsequent TableAdapter reads/writes on the underlying Database.
    'The SqlInterface Class Instance (DAL Interface) will 
    'automatically initiate and maintain the Command, Connection and
    'Transaction objects across multiple Typed DataSet TableAdapter 
    'interactions with the Database until the Transaction
    'is explicitly Committed or Rolled back. Setting this property to True 
    'automatically begins a transaction when required.
    Public Property UsingTransAction() As Boolean
        Get
            Return (_UsingTransaction)
        End Get
        Set(ByVal value As Boolean)
            _UsingTransaction = value
        End Set
    End Property

#End Region
End Class