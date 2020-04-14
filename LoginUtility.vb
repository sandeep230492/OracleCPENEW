Namespace Oracle_CPE
    Public Class LoginUtility
        Public Function LoginWFA(ByRef Region As String, ByRef WFAScreen As AxSmartRumba.AxSmartRumbaControl, Optional ByVal TicketId As String = "") As Boolean
            Try

                Dim objLoginUtility As New DBUtilities.DBConnect
                objLoginUtility = SQLDBUtilGlobal()
                Dim objDbInterface As New DbInterface
                Dim objdataLogin As New Data.DataSet
                Dim strGetLoginQuery As String
                'Dim strSQL As String
                Dim oLogin As HCL.SessionLoginManager
                Dim bResult As Boolean = True
                Dim vex As Exception

                Dim ex As New Exception
                Dim objQueryFleHndlr As New FileHandler.INIFileHandler([Global].p_sDS1CPEIni)
                If Not WFAScreen.isConnected Then
                    If objLoginUtility.DB_SERVER_NAME = "CTOMASQL2SQL3\SQL_INSTANCE3,7117" Then ''PODUCTION SERVER
                        strGetLoginQuery = objQueryFleHndlr.ReadString("QUERY", "WFA.LoginDetails", "Obscure")
                        oLogin = New HCL.SessionLoginManager(objLoginUtility, [Global].p_sGlobalDb, strGetLoginQuery)
                        ' frmDS1CPE.Show()
                        bResult = oLogin.LoginWFADO(WFAScreen, Region, "CPE", vex)
                        Application.DoEvents()
                    ElseIf objLoginUtility.DB_SERVER_NAME = "10.6.68.180" Then ''TEST SERVER
                        ''******************* THIS IS TEST ENVIRONMENT LOGIN CREDENTIAL, REQUIRED TO COMMENT IT WHILE PRODUCTION RELEASE ****************'
                        Dim objLoginDetails As New Oracle_CPEObjects.LoginDetails
                        objLoginDetails = objDbInterface.GetLoginInfo("BULLET-TEST", "WFA", "%", Region, True)

                        WFAScreen.HostAddress = "IM065" ' objLoginDetails.LegacySystem
                        WFAScreen.LegacySystem = "IM065" '
                        WFAScreen.LoginId = "ORACLE1"
                        WFAScreen.LoginPwd = "OCTO2013"
                        WFAScreen.SubSystemLoginId = "ORACLE01"
                        WFAScreen.SubSystemLoginPwd = "AUGU2013"
                        myForm.SetWFADOScreen(Region, WFAScreen, "", "WFADO Test System")
                        ' [Global].SetFormLableRemarks(objLoginDetails.LegacySystem, TicketId, "Login into WFADO system.", "WFADO")

                        WFAScreen.Login()
                        If WFAScreen.IsRowHaving(24, "SUCCESSFUL") Then
                            bResult = True
                        End If

                        ''******************* THIS IS TEST ENVIRONMENT LOGIN CREDENTIAL, REQUIRED TO COMMENT IT WHILE PRODUCTION RELEASE ****************'
                    End If
                End If
                        If bResult = False Then
                            ''"Login Failed for WFADO system"
                            '[Global].p_objLogger.WriteNote(vex.ToString, "", EventLogEntryType.Error)
                            ' ''Send a Escalation (NetMSG, Pager) to Support team. 
                            'p_OEscalationProcess.DoEscalation("DS1CPE", "DS1CPE Application Stopped due to WFA/Do Login Failed.", HiCapEscalator.ProblemEscalator.EscalationLvl.NetSend)
                            'p_OEscalationProcess.DoEscalation("DS1CPE", "DS1CPE - WFA/Do Login Failed", " Unable to Login WFA-Do System - " & WFAScreen.GetString(24, 1, 79).ToString() & ". The DS1CPE application was stopped.", HiCapEscalator.ProblemEscalator.EscalationLvl.Email)
                            'p_OEscalationProcess.DoEscalation("DS1CPE", "DS1CPE Application Stopped due to WFA/Do Login Failed.", HiCapEscalator.ProblemEscalator.EscalationLvl.Pager)

                            ' ''Update the Status as 'I/R/E' in Global_Environment_DB.Legacy_Login_DEF for the respective user id.

                            Return False
                        Else
                            Return True
                        End If

            Catch vex As Exception
                ''System Error - Log Capture
                p_objLogger.writenote("Exception: :-" & vex.ToString(), objordets.Task_Id, EventLogEntryType.Error)
                'p_OEscalationProcess.DoEscalation(p_ApplicationName, "ORACLECPE - WFA/Do Login Failed", " Unable to Login WFA-Do System - " & vex.ToString() & ". The CPE application/tool was stopped.", HiCapEscalator.ProblemEscalator.EscalationLvl.Email)
                Return False
            End Try
        End Function

        Protected Overrides Sub Finalize()
            MyBase.Finalize()
        End Sub

        Public Sub New()

        End Sub
    End Class
End Namespace