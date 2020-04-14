

Public Class WFADOProcess
    Public moWFADOScreen As AxSmartRumba.AxSmartRumbaControl
    Public objWFADOScreen As Object

    Sub New(ByVal WFADOSCREEN As AxSmartRumba.AxSmartRumbaControl)
        Me.moWFADOScreen = WFADOSCREEN

    End Sub

    Sub New()
        ' TODO: Complete member initialization

    End Sub




    Sub SendKey(ByVal ScreenName As AxSmartRumba.AxSmartRumbaControl, ByVal Key2Process As String)
        Try
            ScreenName.SendString(24, 25, "XXXXXX")
            ScreenName.SendKeys(Key2Process)
        Catch ex As Exception
            p_objLogger.writenote("Exception: :-" & ex.ToString(), objordets.Task_Id, EventLogEntryType.Error)
        End Try
    End Sub



    Function OpenScreen(ByVal Tirksess As AxSmartRumba.AxSmartRumbaControl, ByVal ShortName As String)
        Try
            Dim Scrname As String, Row As Integer
            ShortName = UCase(ShortName)
            Select Case ShortName
                Case "DOISWR"
                    Scrname = "DOISWR" : Row = 1
                Case "DOCOMM"
                    Scrname = "DOCOMM" : Row = 1
                Case "DOSOI"
                    Scrname = "DOSOI" : Row = 1
                Case "DOCOMP"
                    Scrname = "DOCOMP" : Row = 1
                Case "DOLOG"
                    Scrname = "DOLOG" : Row = 1
                Case "DOMCWR"
                    Scrname = "DOMCWR" : Row = 1
                Case "DOTLOG"
                    Scrname = "DOTLOG" : Row = 1
            End Select
            If ((Tirksess.GetString(1).Contains("/FOR"))) Then
                Tirksess.SendKeys("@8")
                Tirksess.SendString(1, 73, Scrname)
                SendKey(Tirksess, "@E")
                System.Threading.Thread.Sleep(1000)
                System.Windows.Forms.Application.DoEvents()

            End If

            'If (Tirksess.GetString(1).Contains("WFADO: SS INST WORK REQUEST (DOISWR)")) Then
            '    Return True
            'Else
            '    Return False


            'End If

        Catch ex As Exception
            p_objLogger.writenote("Exception: :-" & ex.ToString(), objordets.Task_Id, EventLogEntryType.Error)
        End Try
    End Function
    Function GetRegion(ByVal state As String) As String

        Select Case state.ToUpper
            Case "IA", "MN", "NE", "SD", "ND"
                Return "EASTERN"
            Case "AZ", "CO", "ID", "MT", "NM", "UT", "WY"
                Return "CENTRAL"
            Case "OR", "WA"
                Return "WESTERN"
        End Select
    End Function
    'chck for need
    Private Sub setLNO(ByRef center As String, ByVal location As String)
        Dim state As String
        If location.Length >= 6 Then
            state = location.Substring(4, 2).Trim.ToString().ToUpper
            If state.ToUpper.Equals("ND") Or state.ToUpper.Equals("SD") Then
                state = "NSD"
            End If
            center = state & "LNO"
        Else
            center = ""
        End If

    End Sub
    Function doProcess(ByVal Tirksess As AxSmartRumba.AxSmartRumbaControl,ByVal objordets As OrderDetails)



        Try
            Dim ObjOracleProcess As New Oracle_Process


            ObjOracleProcess.GetInput(Tirksess)

        Catch ex As Exception
            p_objLogger.writenote("Exception: :-" & ex.ToString(), objordets.Task_Id, EventLogEntryType.Error)
        End Try
    End Function
    Public Shared Function GetCenterCLLI(ByVal CLLI As String, ByVal Tirksess As AxSmartRumba.AxSmartRumbaControl) As String

        Dim bytCount As Int16
        Dim sBackupCLLI As String = ""
        Dim sCenterCLLI As String = ""
        Dim oDOCLLI_SCREEN As HCL.DOCLLIdata
        'SetScreen("Central")

        Dim c_oHCL As Object = New HCL.HicapClassLibrary(Nothing, Nothing, Tirksess)
        Try
            Tirksess.SendKeys(HCL.ActionKeyList.Refresh)
            Tirksess.SendKeys(HCL.ActionKeyList.PA3)
            Tirksess.SendKeys(HCL.ActionKeyList.Clear)
            Tirksess.SendString(3, 2, "/For DOCLLI")
            Tirksess.SendKeys(HCL.ActionKeyList.Enter)

            oDOCLLI_SCREEN = c_oHCL.Screens.DOCLLI.Read

            If oDOCLLI_SCREEN.ROW_1_DOCLLI_SCREEN.Text.ToUpper.Trim.IndexOf("WFADO: CLLI-WC MAPPING TABLE (DOCLLI)") <> -1 Then
                oDOCLLI_SCREEN.ROW_5_DESTINATION_CODE.Text = CLLI
                c_oHCL.Screens.DOCLLI.Write(oDOCLLI_SCREEN)
                Tirksess.SendKeys(HCL.ActionKeyList.Find)
                oDOCLLI_SCREEN = c_oHCL.Screens.DOCLLI.Read
                For bytCount = 5 To 23
                    If sBackupCLLI = "" And bytCount = 5 Then
                        sBackupCLLI = Mid(oDOCLLI_SCREEN.Rows(5).Text, 57, 67).Trim
                    End If
                    If Mid(oDOCLLI_SCREEN.Rows(bytCount).Text, 5, 9).Trim.Equals(CLLI + "*") And Mid(oDOCLLI_SCREEN.Rows(bytCount).Text, 30, 1).Trim.Equals("*") Then
                        'And Mid(oDOCLLI_SCREEN.Rows(bytCount).Text, 44, 6).Trim.Equals(LSO)
                        sCenterCLLI = Mid(oDOCLLI_SCREEN.Rows(bytCount).Text, 57, 11).Trim
                        Exit For
                    End If
                    If bytCount = 23 Then
                        Exit For
                    End If
                Next bytCount
                If sCenterCLLI.Trim.Length = 0 Then
                    sCenterCLLI = sBackupCLLI
                End If
            Else

            End If

            If sCenterCLLI = "" Then
                Return ""
            End If
            Return sCenterCLLI

        Catch ex As Exception
            p_objLogger.writenote("Exception: :-" & ex.ToString(), objordets.Task_Id, EventLogEntryType.Error)
            'GlobalVariables.p_objLogger.WriteNote(ex.ToString, "", EventLogEntryType.Error)
        End Try
    End Function
    Function checkscreen(ByVal tirksess As AxSmartRumba.AxSmartRumbaControl) As Boolean
        Try

            If (tirksess.GetString(1).Contains("WFADO: SS INST WORK REQUEST (DOMCWR)")) Then
                Return True
            Else
                Return False
            End If



        Catch ex As Exception
            p_objLogger.writenote("Exception: :-" & ex.ToString(), objordets.Task_Id, EventLogEntryType.Error)


        End Try


    End Function
End Class
