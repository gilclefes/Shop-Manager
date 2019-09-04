Imports System.Data.SqlClient
Imports System.Net
Imports Microsoft.Win32

Public Class DBConnect

    Private servername As String
    Private database As String
    Private username As String
    Private password As String
    Private client As String

    Private integratedSecurity As Boolean
    Private connectionString As String
    Private conn As SqlConnection
    Private command As SqlCommand

    Public Property PConnectionString() As String
        Get
            Return connectionString
        End Get
        Set(ByVal value As String)
            connectionString = value
        End Set
    End Property

    Public Property PServername() As String
        Get
            Return servername
        End Get

        Set(ByVal value As String)
            servername = value
        End Set

    End Property

    Public Property PDatabase() As String
        Get
            Return database
        End Get
        Set(ByVal value As String)
            database = value
        End Set
    End Property

    Public Property PUsername() As String
        Get
            Return username
        End Get
        Set(ByVal value As String)
            username = value
        End Set
    End Property

    Public Property PPassword() As String
        Get
            Return password
        End Get
        Set(ByVal value As String)
            password = value
        End Set
    End Property

    Public Property PClient() As String
        Get
            Return client
        End Get
        Set(ByVal value As String)
            client = value
        End Set
    End Property

    Public Property PIntegratedSecurity() As Boolean
        Get
            Return integratedSecurity
        End Get
        Set(ByVal value As Boolean)
            integratedSecurity = value
        End Set
    End Property

    Public Property PConn() As SqlConnection
        Get
            Return conn
        End Get
        Set(ByVal value As SqlConnection)
            conn = value
        End Set
    End Property

    Public Sub setConnectionString()
        Try
            If Me.servername = "" Or Me.servername Is Nothing Then
                'Dim oReg As RegistryKey
                ' oReg = Registry.LocalMachine.OpenSubKey("Software\\UCMS")
                'Dim ispass As Boolean = CBool(oReg.GetValue("Ispass", "DEFAULT-VALUE").ToString)
                ' Utils.showError(oReg.ToString)
                'If Not oReg Is Nothing Then
                '    'If Not IsDBNull(oReg.GetValue("ServerName", "DEFAULT-VALUE")) Then
                '    servername = oReg.GetValue("ServerName", "DEFAULT-VALUE").ToString
                '    'End If
                '    database = oReg.GetValue("DatabaseName", "DEFAULT-VALUE").ToString
                '    username = oReg.GetValue("UserName", "DEFAULT-VALUE").ToString
                '    password = oReg.GetValue("Password", "DEFAULT-VALUE").ToString
                '    integratedSecurity = CBool(oReg.GetValue("Integrated"))

                'End If

                With My.Settings
                    servername = .Server
                    database = .Dbase
                    username = .UserName
                    password = .Password
                    integratedSecurity = .integrated
                End With
            End If

            'client = "clefes-77"
            client = getClientName()

            If servername = client Then

                If Me.integratedSecurity = False Then
                    connectionString = "Data source= " & servername & "; initial catalog= " & database & ";user id= " & username & " ;password = " & password
                Else
                    connectionString = "Data source= " & servername & "; initial catalog= " & database & "; Integrated Security= " & integratedSecurity
                End If
                'for false integrated security
                '
                'connectionString = "workstationid= " & client & " ;Data source= " & servername & " ;initial catalog= " & database & " ;Integrated Security=True"

            Else
                connectionString = "workstation id= " & client & " ;Data source= " & servername & " ;initial catalog= " & database & " ;user id= " & username & " ;password = " & password & " ;Integrated Security=" & integratedSecurity & " ; Connect TimeOut=30"
            End If
        Catch ex As Exception
            Utils.showError(ex.ToString)
        End Try


    End Sub

    Public Sub openConnection()
        Try
            'client = "clefes-e44fb44"
            'servername = "clefes-e44fb44"
            'database = "ucms"
            'Utils.showMessage(Me.connectionString)
            setConnectionString()
            'conn = New SqlConnection("Data Source=clefes-e44fb44;Initial Catalog=ucms;Integrated Security=True")
            conn = New SqlConnection(connectionString) '"Data Source=clefes-e44fb44;Initial Catalog=ucms;Integrated Security=True")
            conn.Open()
        Catch ex As Exception
            Utils.showError(ex.ToString)
        End Try
    End Sub
    'to check if your cable is connencted
    Public Function isCabbleConnected() As Boolean
        Dim isAvailable As Boolean
        isAvailable = My.Computer.Network.IsAvailable
        Return isAvailable
    End Function

    Public Sub CloseConnection()
        Try
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
        Catch ex As Exception

        End Try

    End Sub

    Public Function getIpAddresses() As String()
        Dim ips() As String = New String() {}
        Dim strHostName As String = Dns.GetHostName()
        Dim ipEntry As IPHostEntry = Dns.GetHostEntry(strHostName)
        Dim addr As IPAddress() = ipEntry.AddressList

        ReDim ips(addr.Length)

        For i As Integer = 0 To ips.Length - 1
            ips(i) = addr(0).ToString
        Next

        Return ips

    End Function

    Public Function returnConnectionString() As String
        setConnectionString()
        While Me.IsConnected = False
            Dim frmDbase As New frmDbaseConnector
            frmDbase.ShowDialog()
        End While
       
        Return Me.connectionString
    End Function
    Public Function returnConnState() As String
        openConnection()
        Return conn.State.ToString
    End Function
    'check if database connection is available
    Public Function IsConnected() As Boolean
        openConnection()
        Return CBool(conn.State)
    End Function
    Public Function getClientName() As String
        Dim client As String = ""
        client = Dns.GetHostName
        Return client
    End Function

    Public Function getServerName() As String
        Dim sname As String = ""

        Try
            'Dim oReg As RegistryKey
            'oReg = Registry.LocalMachine.OpenSubKey("Software\\UCMS")
            ''Dim ispass As Boolean = CBool(oReg.GetValue("Ispass", "DEFAULT-VALUE").ToString)
            '' Utils.showError(oReg.ToString)
            'If Not oReg Is Nothing Then
            '    'If Not IsDBNull(oReg.GetValue("ServerName", "DEFAULT-VALUE")) Then
            '    sname = oReg.GetValue("ServerName", "DEFAULT-VALUE").ToString
            '    'End If
            '    'database = oReg.GetValue("DatabaseName", "DEFAULT-VALUE").ToString
            'End If
            sname = My.Settings.Server

        Catch ex As Exception
            Utils.showMessage(ex.ToString)
        End Try

        Return sname
    End Function


    Public Function getDataname() As String
        Dim dname As String = ""

        Try
            'Dim oReg As RegistryKey
            'oReg = Registry.LocalMachine.OpenSubKey("Software\\UCMS")
            ''Dim ispass As Boolean = CBool(oReg.GetValue("Ispass", "DEFAULT-VALUE").ToString)
            '' Utils.showError(oReg.ToString)
            'If Not oReg Is Nothing Then
            '    'If Not IsDBNull(oReg.GetValue("ServerName", "DEFAULT-VALUE")) Then
            '    ' = oReg.GetValue("ServerName", "DEFAULT-VALUE").ToString
            '    'End If
            '    dname = oReg.GetValue("DatabaseName", "DEFAULT-VALUE").ToString
            'End If
            dname = My.Settings.Dbase
            'Utils.showMessage(dname)
            'Return dname
        Catch ex As Exception
            Utils.showMessage(ex.ToString)
        End Try

        Return dname
    End Function

    Public Function getSignname() As String
        Dim dname As String = ""

        Try
            Dim oReg As RegistryKey
            oReg = Registry.LocalMachine.OpenSubKey("Software\\UCMS")
            'Dim ispass As Boolean = CBool(oReg.GetValue("Ispass", "DEFAULT-VALUE").ToString)
            ' Utils.showError(oReg.ToString)
            If Not oReg Is Nothing Then
                'If Not IsDBNull(oReg.GetValue("ServerName", "DEFAULT-VALUE")) Then
                ' = oReg.GetValue("ServerName", "DEFAULT-VALUE").ToString
                'End If
                dname = oReg.GetValue("SigName", "DEFAULT-VALUE").ToString
            End If
        Catch ex As Exception
            Utils.showMessage(ex.ToString)
        End Try

        Return dname
    End Function


    Public Function getSignPost() As String
        Dim dname As String = ""

        Try
            Dim oReg As RegistryKey
            oReg = Registry.LocalMachine.OpenSubKey("Software\\UCMS")
            'Dim ispass As Boolean = CBool(oReg.GetValue("Ispass", "DEFAULT-VALUE").ToString)
            ' Utils.showError(oReg.ToString)
            If Not oReg Is Nothing Then
                'If Not IsDBNull(oReg.GetValue("ServerName", "DEFAULT-VALUE")) Then
                ' = oReg.GetValue("ServerName", "DEFAULT-VALUE").ToString
                'End If
                dname = oReg.GetValue("SigPos", "DEFAULT-VALUE").ToString
            End If
        Catch ex As Exception
            Utils.showMessage(ex.ToString)
        End Try

        Return dname
    End Function

    Public Function getdbasePassword() As String

        Dim pname As String = ""

        Try
            'Dim oReg As RegistryKey
            'oReg = Registry.LocalMachine.OpenSubKey("Software\\UCMS")

            'If Not oReg Is Nothing Then
            '    'dname = oReg.GetValue("UserName", "DEFAULT-VALUE").ToString
            '    pname = oReg.GetValue("Password", "DEFAULT-VALUE").ToString
            'End If
            pname = My.Settings.Password
        Catch ex As Exception
            Utils.showMessage(ex.ToString)
        End Try

        Return pname
    End Function

    Public Function getUName() As String
        Dim dname As String = ""

        Try
            'Dim oReg As RegistryKey
            'oReg = Registry.LocalMachine.OpenSubKey("Software\\UCMS")

            'If Not oReg Is Nothing Then
            '    dname = oReg.GetValue("UserName", "DEFAULT-VALUE").ToString
            '    'password = oReg.GetValue("Password", "DEFAULT-VALUE").ToString
            'End If
            dname = My.Settings.UserName
        Catch ex As Exception
            Utils.showMessage(ex.ToString)
        End Try

        Return dname
    End Function

    Public Function getIntegratedSecurity() As Boolean
        Dim dname As Boolean = False

        Try
            'Dim oReg As RegistryKey
            'oReg = Registry.LocalMachine.OpenSubKey("Software\\UCMS")

            'If Not oReg Is Nothing Then
            '    dname = CBool(oReg.GetValue("Integrated"))
            '    'password = oReg.GetValue("Password", "DEFAULT-VALUE").ToString
            'End If
            dname = My.Settings.integrated
        Catch ex As Exception
            Utils.showMessage(ex.ToString)
        End Try

        Return dname
    End Function

    Public Function ReturnUsersByName_Pass() As DataTable
        Dim query As String = "sp_databases"
        Dim dTable As New DataTable
        Dim dAdapter As New SqlClient.SqlDataAdapter
        Try
            openConnection()
            command = New SqlCommand(query, conn)
            command.CommandType = CommandType.StoredProcedure
            dAdapter.SelectCommand = command
            dAdapter.Fill(dTable)

        Catch ex As Exception

        Finally
            CloseConnection()
        End Try
        Return dTable
    End Function

End Class
