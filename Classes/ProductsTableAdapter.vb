Imports System.Data.SqlClient

Namespace Shops_DBDataSetTableAdapters
    Partial Public Class ProductsTableAdapter
        Inherits Global.System.ComponentModel.Component
        'CallRetrieves the return value from a Stored Procedure

        Public Function GetReturnValue() As Integer
            Return CInt(Me.Adapter.UpdateCommand.Parameters(0).Value)
        End Function

        'Exposes the Typed DataSet DataAdapter
        Public Function GetAdapter() As SqlDataAdapter
            Return (Me.Adapter)
        End Function

        'Exposes the Command Object associated with Database Select Operations
        'This is important if Select commands are going to be issued during an
        'active Update/Insert/Delete Transaction. The Transaction and its
        'associated Connection Object will be set on the SelectCommand object
        'to prevent the Update Transaction from Blocking the Select statement.
        Public ReadOnly Property SelectCommand() As SqlCommand
            Get
                Return Me.CommandCollection(0)
            End Get
        End Property

        'Provides Access to the TableAdapters Transaction Object.
        Public Property Transaction() As SqlTransaction
            Get
                If (Not IsNothing((Me.Adapter.UpdateCommand.Transaction))) Then
                    Return (Me.Adapter.UpdateCommand.Transaction)
                ElseIf (Not IsNothing((Me.Adapter.InsertCommand.Transaction))) Then
                    Return (Me.Adapter.InsertCommand.Transaction)
                ElseIf (Not IsNothing((Me.Adapter.DeleteCommand.Transaction))) Then
                    Return (Me.Adapter.DeleteCommand.Transaction)
                ElseIf (Not IsNothing((Me.Adapter.SelectCommand.Transaction))) Then
                    Return (Me.Adapter.SelectCommand.Transaction)
                Else
                    Return (Nothing)
                End If
            End Get
            Set(ByVal value As SqlTransaction)
                If (Not IsNothing(Me.Adapter.UpdateCommand)) Then
                    Me.Adapter.UpdateCommand.Transaction = value
                    Me.Adapter.UpdateCommand.Connection = value.Connection
                End If
                If (Not IsNothing(Me.Adapter.DeleteCommand)) Then
                    Me.Adapter.DeleteCommand.Transaction = value
                    Me.Adapter.DeleteCommand.Connection = value.Connection
                End If
                If (Not IsNothing(Me.Adapter.InsertCommand)) Then
                    Me.Adapter.InsertCommand.Transaction = value
                    Me.Adapter.InsertCommand.Connection = value.Connection
                End If
            End Set
        End Property

    End Class
End Namespace

