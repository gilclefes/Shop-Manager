Imports System.Net.NetworkInformation
Imports System.Globalization

Public Class frmDbaseConnector
    Private dbase As New DBConnect
    Private servername As String
    Dim WithEvents pingClient As New Ping()

    Private Sub pingClient_PingCompleted( _
        ByVal sender As Object, ByVal e As PingCompletedEventArgs) Handles pingClient.PingCompleted
        ' Check to see if an error occurred.  If no error, then display the 
        ' address used and the ping time in milliseconds
        If e.Error Is Nothing Then
            If e.Cancelled Then
                'lbl1.Text &= _
                '    "Ping cancelled." & Environment.NewLine
            Else
                If e.Reply.Status = IPStatus.Success Then
                    'lbl1.Text &= _
                    '    "  " & e.Reply.Address.ToString() & " " & _
                    '    e.Reply.RoundtripTime.ToString( _
                    '    NumberFormatInfo.CurrentInfo) & "ms "

                    Utils.showMessage("You are Connected to the Server")
                Else
                    Utils.showError("Make sure the correct Server Name is Entered")
                    Exit Sub
                End If
            End If
        Else
           
            MessageBox.Show( _
                "An error occurred while sending this ping. " & _
                e.Error.InnerException.Message.ToString())
        End If

    End Sub

    Private Function GetStatusString(ByVal status As IPStatus) As String
        Select Case status
            Case IPStatus.Success
                Return "Success."
            Case IPStatus.DestinationHostUnreachable
                Return "Destination host unreachable."
            Case IPStatus.DestinationNetworkUnreachable
                Return "Destination network unreachable."
            Case IPStatus.DestinationPortUnreachable
                Return "Destination port unreachable."
            Case IPStatus.DestinationProtocolUnreachable
                Return "Destination protocol unreachable."
            Case IPStatus.PacketTooBig
                Return "Packet too big."
            Case IPStatus.TtlExpired
                Return "TTL expired."
            Case IPStatus.ParameterProblem
                Return "Parameter problem."
            Case IPStatus.SourceQuench
                Return "Source quench."
            Case IPStatus.TimedOut
                Return "Timed out."
            Case Else
                Return "Ping failed."
        End Select
    End Function

    Private Sub frmDbaseConnector_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        
        With My.Settings
            Me.txtServer.Text = .Server
            Me.txtDbase.Text = .Dbase
            Me.txtUserName.Text = .UserName
            Me.txtPassWord.Text = .Password
            Me.ChkSecurity.Checked = CBool(.integrated)
        End With

    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click


        If Me.txtDbase.Text = "" Then
            Utils.showMessage("Please enter the Database Name")
            Exit Sub
        End If

        If Me.txtServer.Text = "" Then
            Utils.showMessage("Please enter the Server Name")
            Exit Sub
        End If


        If Utils.QuestionPrompt("Are Sure to Save Setting") = Windows.Forms.DialogResult.Yes Then

            Try

                With My.Settings
                    .Server = Me.txtServer.Text
                    .Dbase = Me.txtDbase.Text
                    .UserName = Me.txtUserName.Text
                    .Password = Me.txtPassWord.Text
                    .integrated = Me.ChkSecurity.Checked
                    .Save()
                End With


            Catch ex As Exception
                Utils.showError(ex.ToString)
            End Try
        End If

    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click

        Me.Close()
       
    End Sub

    Private Sub btnConnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConnect.Click

        If Me.txtDbase.Text = "" Then
            Utils.showMessage("Please enter the Database Name")
            Exit Sub
        End If

        If Me.txtServer.Text = "" Then
            Utils.showMessage("Please enter the Server Name")
            Exit Sub
        End If

        Try
            pingClient.SendAsync(Me.txtServer.Text, Nothing)
            'Utils.showMessage(Dns.GetHostName)
            dbase.PClient = Utils.getClientName
            dbase.PServername = Me.txtServer.Text
            dbase.PDatabase = Me.txtDbase.Text
            dbase.PIntegratedSecurity = Me.ChkSecurity.Checked
            dbase.PUsername = Me.txtUserName.Text
            dbase.PPassword = Me.txtPassWord.Text

            If Me.dbase.IsConnected = True Then
                Utils.showMessage("Connection is Succesfull")
            Else
                Utils.showError("Connection not Succefesfull")
            End If
        Catch ex As Exception
            Utils.showError(e.ToString)
        End Try

    End Sub

End Class


