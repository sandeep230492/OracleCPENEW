Imports System.IO
Public Class GlobalVariables
    Public Shared p_sLogFilePath As String
    Public Shared p_sLogFileName As String
    Public Shared P_sLogErrorType As String
    Public Shared Sub SetGlobalVariables()

        Dim Logpath As String = System.Configuration.ConfigurationManager.ConnectionStrings("LogPath").ConnectionString
        p_sLogFilePath = Logpath
        p_sLogFileName = "ErrorLog_TicketCreation.txt"
        P_sLogErrorType = "Error#Warning#Information"

        p_objLogger = New AppLogger(p_sLogFilePath, p_sLogFileName, P_sLogErrorType)
    End Sub
#Region "Applogger"
    Public Class AppLogger
        Private mstrLoggerFileName As String
        Private mstrLoggerPath As String
        Private mstrReason As String
        Private mstrErrType As String
        Private mstrCFCLocal As String
        Private mstrLoggingError() As String
        Sub New(ByVal LogFilePath As String, ByVal LogFileName As String, ByVal LogErrorTypes As String)
            Try
                mstrLoggingError = Split(LogErrorTypes, "#")
                mstrLoggerFileName = LogFileName
                mstrLoggerPath = LogFilePath
            Catch ex As Exception
                p_objLogger.writenote("Exception: :-" & ex.ToString(), "", EventLogEntryType.Error)
                MsgBox(ex.ToString)
            End Try
        End Sub
        Sub WriteNote(ByVal Reason As String, ByVal Report_ID As String, ByVal ErrorType As System.Diagnostics.EventLogEntryType)
            Dim objLogger As Logger.FileLogger
            Dim intIndex As Integer
            Dim objStackTrace As New StackTrace
            Dim objStackFrame As StackFrame, mstrTemp As String

            objStackFrame = objStackTrace.GetFrame(1)
            mstrTemp = objStackFrame.GetMethod.ReflectedType.FullName & "." & objStackFrame.GetMethod.Name

            If Not mstrLoggingError Is Nothing Then
                For intIndex = 0 To mstrLoggingError.GetUpperBound(0)
                    If UCase(ErrorType) = ErrorLogNumber(UCase(mstrLoggingError(intIndex))) Then
                        Dim sFileStream As New FileStream(mstrLoggerPath & "\" & mstrLoggerFileName, FileMode.Append, FileAccess.Write, FileShare.Write)
                        Dim StreamWriter As New StreamWriter(sFileStream)
                        StreamWriter.WriteLine("***************")
                        StreamWriter.WriteLine("Entity     :- " & Report_ID)
                        'StreamWriter.WriteLine("at System  :- " & SystemInformation.ComputerName)
                        'StreamWriter.WriteLine("Call Route :- " & mstrTemp)
                        StreamWriter.Close()
                        objLogger = New Logger.FileLogger(mstrLoggerFileName, mstrLoggerPath)
                        objLogger.WriteLog(Reason, ErrorType)
                    End If
                Next
            End If
            objLogger = Nothing
        End Sub
        Private Function ErrorLogNumber(ByVal ErrorLog As String) As Integer
            Dim intReturn As Integer
            Select Case ErrorLog
                Case "ERROR", "OBSCURE"
                    intReturn = 1
                Case "WARNING"
                    intReturn = 2
                Case "INFORMATION"
                    intReturn = 4
                Case "SUCCESSAUDIT"
                    intReturn = 8
                Case "FAILUREAUDIT"
                    intReturn = 16
                Case "OBSCURE"
                    intReturn = 32
            End Select
            Return intReturn
        End Function
    End Class
#End Region
End Class
