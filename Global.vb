
Imports System.Data.Odbc
Imports System.Net.Mail
Module [Global]
    Public p_sDS1CPEIni As String = ""
    Public p_sCPE_NotifierIni As String = ""
    Public p_sEnvironmentIni As String = ""
    Public p_sHCLIni As String = ""
    Public p_sDS1CPEDB As String = ""
    'CPE NOTIFER
    Public p_sCPE_NOTIFIER As String = ""
    Public Region As String = ""
    Public Status As String = ""
    'Public p_sDS1CPE_Access_DB As String = ""
    Public p_sTrackerDB As String = ""
    Public p_sGlobalDb As String = ""
    Public p_sSopadBoxFilePath As String = ""

    Public p_sNTPSopadBoxFilePath As String
    Public p_sNTPMailFilePath As String
    Public p_sNTPArchiveFilePath As String
    'Public objWFADOScreen As New AxSmartRumba.AxSmartRumbaControl
    Public p_sLogFilePath As String = ""
    Public p_sLogFileName As String = ""
    Public P_sLogErrorType As String = ""
    Public p_objLogger As Object
    Public CenterId As String = ""
    Public Tech_Ec As String = ""
    Public jobstat_id As String = ""
    Public myForm As New OracleCPENew
    Public Timetaken As String = ""
    Public blnStartnow As Boolean, blnEndNow As Boolean
    Public p_ApplicationName As String = "CPE"
    'Public objmail As New MailId
    'Public SupervisorMailId As String
    'Public centre_ID As String = ""
    'Public job_ID As String = ""
    'Public PON As String = ""
    'Public CPK_CKL_Created As String = ""
    'Public CPK_CKL_Created_date As String = ""
    'Public NTP_Received As String = ""
    'Public ProcessStart_date_Time As String = ""
    'Public A_Loc As String = ""
    'Public Z_Loc As String = ""
    'Public WireCenter As String = ""
    'Public TechEc As String = ""
    'Public SupervisorName As String

    Public p_sCPE_NOTIFIERDB As String


    Public Function SQLDBUtil() As DBUtilities.DBConnect
        Try
            Dim objSQLDBUtil As New FileHandler.SQLServerLoginCredential
            Dim DBConnect As New DBUtilities.DBConnect
            Dim ErrorMsg As Exception
            objSQLDBUtil.SQLDBUtil(p_sEnvironmentIni, "IT SQL Server", DBConnect, ErrorMsg)
            'objSQLDBUtil.SQLDBUtil(p_sEnvironmentIni, "SQL Test Server", DBConnect, ErrorMsg)
            DBConnect.DbAuthenticationMode = DBUtilities.DBConnect.AuthenticationMode.SQLMode
            If Not ErrorMsg Is Nothing Then
                [Global].p_objLogger.WriteNote("Error While reading SQL Server details from Environment INI file :-" & ErrorMsg.ToString(), "", EventLogEntryType.Error)
            End If
            Return DBConnect
        Catch ex As Exception
            p_objLogger.writenote("Exception: :-" & ex.ToString(), objordets.Task_Id, EventLogEntryType.Error)
        End Try
    End Function

    Public Function SQLDBUtilGlobal() As DBUtilities.DBConnect
        Try
            Dim objSQLDBUtil As New FileHandler.SQLServerLoginCredential
            Dim DBConnect As New DBUtilities.DBConnect
            Dim ErrorMsg As Exception
            objSQLDBUtil.SQLDBUtil(p_sEnvironmentIni, "SQL Server Global", DBConnect, ErrorMsg)
            'objSQLDBUtil.SQLDBUtil(p_sEnvironmentIni, "SQL Test Server", DBConnect, ErrorMsg)
            DBConnect.DbAuthenticationMode = DBUtilities.DBConnect.AuthenticationMode.SQLMode
            If Not ErrorMsg Is Nothing Then
                [Global].p_objLogger.WriteNote("Error While reading SQL Server details from Environment INI file :-" & ErrorMsg.ToString(), "", EventLogEntryType.Error)
            End If
            Return DBConnect
        Catch ex As Exception
            p_objLogger.writenote("Exception: :-" & ex.ToString(), objordets.Task_Id, EventLogEntryType.Error)
        End Try
    End Function

    Public Sub SetFormLableRemarks(ByVal SystemName As String, ByVal Clli As String, ByVal ProcessRemark As String, Optional ByVal SystemType As String = "LFACS")
        Try
            If SystemType = "LFACS" Then
                If SystemName <> "" Then
                    myForm.lbl_WFADO_System.Text = "System :" & SystemName
                End If
                If Clli <> "" Then
                    myForm.lbl_TicketNo.Text = "CPE Ticket#: : " & Clli.Trim
                End If

            ElseIf SystemType = "WFADO" Then
                If SystemName <> "" Then
                    myForm.lbl_WFADO_System.Text = "System :" & SystemName
                End If
                If Clli <> "" Then
                    myForm.lbl_TicketNo.Text = "CPE Ticket#: : " & Clli.Trim
                End If
            End If
            myForm.lbl_Process_RMK.Text = ProcessRemark
        Catch ex As Exception
            p_objLogger.writenote("Exception: :-" & ex.ToString(), objordets.Task_Id, EventLogEntryType.Error)
        End Try
    End Sub

    Public Function ReadLocalINI() As Boolean
        Try
            Dim objfileHandler As New FileHandler.INIFileHandler(Environment.CurrentDirectory & _
                                                     "\DS1CPE_Local.ini")

            ''INI Details
            p_sEnvironmentIni = objfileHandler.ReadString("Ini path", "Ini.Environment", "Obscure")
            p_sDS1CPEIni = objfileHandler.ReadString("Ini path", "Ini.DS1CPE", "Obscure")

            p_sHCLIni = objfileHandler.ReadString("Ini path", "Ini.HCL", "Obscure")
            p_sCPE_NotifierIni = objfileHandler.ReadString("Ini path", "Ini.CPE_Notifier", "Obscure")
            Dim objCPE_Notifierfilehndler As New FileHandler.INIFileHandler(p_sCPE_NotifierIni)
            p_sCPE_NOTIFIERDB = objCPE_Notifierfilehndler.ReadString("DBPath", "DB.CPE_Notifier", "CPE_Notifier")

            Dim objCPEIniFile As New FileHandler.INIFileHandler(p_sDS1CPEIni)
            p_sDS1CPEDB = objCPEIniFile.ReadString("DBPath", "DB.DS1CPE", "Obscure")

            p_sGlobalDb = objCPEIniFile.ReadString("DBPath", "DB.Global", "Obscure")

            ''NTP Details
            p_sNTPMailFilePath = objCPEIniFile.ReadString("NTPDetails", "Path.MailContentFile", Environment.CurrentDirectory)
            p_sNTPSopadBoxFilePath = objCPEIniFile.ReadString("NTPDetails", "Path.SpoadBox", Environment.CurrentDirectory)
            p_sNTPArchiveFilePath = objCPEIniFile.ReadString("NTPDetails", "Path.Archive", Environment.CurrentDirectory)


            p_sTrackerDB = objCPEIniFile.ReadString("DBPath", "DB.Tracker", "Obscure")

            ''SopadBic File Path
            p_sSopadBoxFilePath = objCPEIniFile.ReadString("SopadBox", "Path.SopadBox", Environment.CurrentDirectory)

            ''Error Log file details
            p_sLogFilePath = objCPEIniFile.ReadString("Logger", "FilePath", Environment.CurrentDirectory & "\")
            p_sLogFileName = objCPEIniFile.ReadString("Logger", "FileName", "ErrorLog.txt")
            P_sLogErrorType = objCPEIniFile.ReadString("Logger", "ErrorsType", "Error#Warning#Information")


            ''Escalation Process INI

            objfileHandler = Nothing

            Return True
        Catch ex As Exception
            p_objLogger.writenote("Exception: :-" & ex.ToString(), objordets.Task_Id, EventLogEntryType.Error)
        End Try
    End Function

    Function p_notifierIni() As String
        Throw New NotImplementedException
    End Function

    Function CPE_NOTIFIERINI() As String
        Throw New NotImplementedException
    End Function

    Function CPE_CKL_Created() As Object
        Throw New NotImplementedException
    End Function

End Module
#Region "comment lines"
'Public Function OracleUtil() As OdbcConnection
'    Try
'        Dim strTnsName As String = "", strUserId As String = "", strPassword As String = ""

'        Dim objCPEIniFile As New FileHandler.INIFileHandler(p_sDS1CPEIni)
'        strTnsName = objCPEIniFile.ReadString("OracleDBConnection", "TNSName", "Obscure")
'        strUserId = objCPEIniFile.ReadString("OracleDBConnection", "UserId", "Obscure")
'        strPassword = objCPEIniFile.ReadString("OracleDBConnection", "Password", "Obscure")

'        Dim objOracleConnection As OdbcConnection
'        Dim strConnString As String = ""
'        strConnString = "Driver={Microsoft ODBC for Oracle};" & _
'                        "Server=" & strTnsName & ";" & _
'                        "Uid=" & strUserId & ";Pwd=" & strPassword
'        objOracleConnection = New Odbc.OdbcConnection(strConnString)
'        objOracleConnection.Open()
'        Return objOracleConnection
'    Catch ex As Exception
'        Return Nothing
'    End Try
'End Function
'Public Function GetNTPData(ByVal NTPMailContent As String, ByVal DataKeyWord As String, Optional ByVal ReturnOnlyData As Boolean = True) As String
'    Try
'        Dim strResultValue As String = ""
'        Dim aMailContent As String()

'        aMailContent = NTPMailContent.Split(vbCrLf)

'        For iIndex As Int16 = 0 To UBound(aMailContent)
'            If UCase(aMailContent(iIndex).Trim).IndexOf(UCase(DataKeyWord)) > -1 Then
'                Dim strTemp As String = UCase(Trim(aMailContent(iIndex)))
'                If ReturnOnlyData Then
'                    strResultValue = strTemp.Substring(Len(DataKeyWord) + 1)
'                Else
'                    strResultValue = strTemp.Trim ''Return the DataKeyWord with Value (entire line from the mail content)
'                End If

'                Exit For
'            End If
'        Next

'        Return strResultValue
'    Catch ex As Exception

'    End Try
'End Function
'Public Function GetRegion(ByVal State As String) As String
'    Select Case State
'        Case "AZ", "CO", "ID", "MT", "NM", "UT", "WY"
'            Return "Central"
'        Case "SD", "ND", "NE", "MN", "IA"
'            Return "Eastern"
'        Case "NO", "SO", "WA", "OR"
'            Return "Western"
'        Case Else
'            Return ""
'    End Select
'End Function
#End Region






