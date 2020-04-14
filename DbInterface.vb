Public Class DbInterface
    Public Function GetLoginInfo(ByVal ApplicationName As String, ByVal System As String, ByVal State As String, Optional ByVal Region As String = "C", Optional ByVal IsWFASystem As Boolean = False) As Oracle_CPEObjects.LoginDetails
        Try
            Dim objLoginUtility As New DBUtilities.DBConnect
            objLoginUtility = SQLDBUtilGlobal()
            Dim objdataLogin As New Data.DataSet
            Dim strGetLoginQuery As String
            Dim objLogin() As Object
            Dim ex As New Exception
            Dim objQueryFleHndlr As New FileHandler.INIFileHandler([Global].p_sDS1CPEIni)
            objLogin = Array.CreateInstance(GetType(Object), 3)

            If IsWFASystem Then ''WFA System 
                With objLogin
                    .SetValue(ApplicationName, 0)
                    .SetValue("%", 1)
                    .SetValue("C", 2)
                End With
                strGetLoginQuery = objQueryFleHndlr.ReadString("QUERY", System & ".LoginDetails", "Obscure")
                objdataLogin = objLoginUtility.SelectQuery([Global].p_sGlobalDb, strGetLoginQuery, ex, objLogin)
                objQueryFleHndlr = Nothing
                objLoginUtility = Nothing

                Return PopulateLoginDetails(objdataLogin, False, True)
            Else ''Legacy System
                With objLogin
                    .SetValue(ApplicationName, 0)
                    .SetValue(System.Trim, 1)
                    .SetValue(State.Trim, 2)
                End With

                strGetLoginQuery = objQueryFleHndlr.ReadString("QUERY", System & ".LoginDetails", "Obscure")
                objdataLogin = objLoginUtility.SelectQuery([Global].p_sGlobalDb, strGetLoginQuery, ex, objLogin)


                objQueryFleHndlr = Nothing
                objLoginUtility = Nothing

                If System.Trim.Equals("SOAC") Then
                    Return PopulateLoginDetails(objdataLogin, False)
                Else
                    Return PopulateLoginDetails(objdataLogin)
                End If
            End If

        Catch ex As Exception
            p_objLogger.writenote("Exception: :-" & ex.ToString(), objordets.Task_Id, EventLogEntryType.Error)
            '    ''Capture the System error in Error Log
            '    [Global].p_objLogger.WriteNote(ex.ToString, "", EventLogEntryType.Error)
            '    ''Send a email notification to support team
            '    p_OEscalationProcess.DoEscalation(p_ApplicationName, p_ApplicationName & " application - DB Error message", "Unable to get login information from database.Please find the error below " & vbCrLf & ex.ToString(), HiCapEscalator.ProblemEscalator.EscalationLvl.Email)
            Return Nothing
        End Try
    End Function
    Private Function PopulateLoginDetails(ByVal LoginDatas As Data.DataSet, Optional ByVal IsEntityRequired As Boolean = False, Optional ByVal IsWFASystem As Boolean = False) As Oracle_CPEObjects.LoginDetails
        Try
            Dim objReturnLoginDetails As New Oracle_CPEObjects.LoginDetails
            If Not LoginDatas Is Nothing Then
                If LoginDatas.Tables.Count > 0 Then
                    If IsWFASystem Then ''WFAC/WFADO system
                        Dim objRow As DataRow
                        For Each objRow In LoginDatas.Tables(0).Rows
                            If objRow.Item("SYSTEM_NAME_NM") = "WFADO_RACF" Then
                                objReturnLoginDetails.LegacySystem = objRow.Item("SYSTEM_LOGIN_NAME")
                                objReturnLoginDetails.LoginId = objRow.Item("LOGIN_ID")
                                objReturnLoginDetails.LoginPwd = objRow.Item("LOGIN_PWD")
                            ElseIf objRow.Item("SYSTEM_NAME_NM") = "WFADO_SIGN" Then
                                objReturnLoginDetails.SubSystemName = objRow.Item("SYSTEM_LOGIN_NAME")
                                objReturnLoginDetails.SubSystemLoginId = objRow.Item("LOGIN_ID")
                                objReturnLoginDetails.SubSystemLoginPwd = objRow.Item("LOGIN_PWD")
                            End If
                        Next
                    Else ''Legacy Systems
                        If LoginDatas.Tables("Table").Rows.Count > 0 Then
                            objReturnLoginDetails.LegacySystem = LoginDatas.Tables("Table").Rows(0).Item("System_Name")
                            objReturnLoginDetails.LoginId = LoginDatas.Tables("Table").Rows(0).Item("Login_Id")
                            objReturnLoginDetails.LoginPwd = LoginDatas.Tables("Table").Rows(0).Item("Login_Pwd")
                            If IsEntityRequired Then
                                objReturnLoginDetails.LoginEntity = LoginDatas.Tables("Table").Rows(0).Item("Entity")
                            End If
                            LoginDatas = Nothing
                        End If
                    End If
                End If
            End If
            Return objReturnLoginDetails
        Catch ex As Exception
            p_objLogger.writenote("Exception: :-" & ex.ToString(), objordets.Task_Id, EventLogEntryType.Error)
            'Throw ex
        End Try
    End Function

End Class
