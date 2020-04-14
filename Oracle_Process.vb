
Imports System.IO.File
Imports System.Data
Imports System.IO
Imports System.Data.OleDb
Imports System.Configuration
Imports System.Net.Mail
Imports Oracle.ManagedDataAccess.Client

Public Class Oracle_Process
    Public Function GetInput(ByVal Tirksess As AxSmartRumba.AxSmartRumbaControl)
        Try
            'Dim oradb As String = "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=cpet2dbsg.dev.qintra.com)(PORT=1524))(CONNECT_DATA=(SID=CPET2)));User Id=xxcpewfa;Password=xxcpewfa_0813;"
            Dim oradb As String = System.Configuration.ConfigurationManager.ConnectionStrings("ConnStr").ConnectionString
            'Dim oradb As String = "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=cpepdb1.qintra.com)(PORT=1521))(CONNECT_DATA=(SID=CPEP)));User Id=xxcpewfa;Password=cpewfa_1213;"
            Dim conn As New OracleConnection(oradb)
            Dim oadapter2 As OracleDataAdapter
            Dim oreader2 As OracleDataReader
            Dim objDbutility As New DBUtilities.DBConnect
            objDbutility = SQLDBUtil()
            Dim objdataLogin As New Data.DataSet
            Dim objSelect As New Object
            Dim ex As New Exception
            'Dim Region As String

            Dim objQueryFleHndlr As New FileHandler.INIFileHandler(p_sCPE_NotifierIni)
            Dim objLoginUtility As New Oracle_CPE.LoginUtility
            'Dim TicketType As String

            conn.Open()
            'Dim strQuery5 As String = "select * from XXQST.XXQST_WFA_INTERFACE where msg_status='ORACLE_COMPLETE'"
            'Dim strQuery5 As String = "select * from XXQST.XXQST_WFA_INTERFACE where msg_status='ORACLE_PICKED'"
            'Dim strQuery5 As String = "select * from XXQST.XXQST_WFA_INTERFACE where WFAO_JOBID = 'CPEI1431515'"
            Dim strQuery5 As String = "select * from XXQST.XXQST_WFA_INTERFACE where WFAO_JOBID = 'CPEI1892694'"
            'Dim strQuery5 As String = "select * from XXQST.XXQST_WFA_INTERFACE where msg_status='WFA_READY'"
            Dim objCommand As New OracleCommand(strQuery5, conn)
            oreader2 = objCommand.ExecuteReader()
            oadapter2 = New OracleDataAdapter(strQuery5, conn)
            Dim Input_ds As DataSet = New DataSet()
            Input_ds.Clear()
            oadapter2.Fill(Input_ds)
            Dim i As Integer = 0
            If Input_ds.Tables(0).Rows.Count > 0 Then
                For i = 0 To Input_ds.Tables(0).Rows.Count - 1

                    Dim objordets As New OrderDetails
                    objordets.Task_Id = Input_ds.Tables(0).Rows(i)(0).ToString()
                    objordets.Incident_Id = Input_ds.Tables(0).Rows(i)(1).ToString()
                    objordets.Task_Number = Input_ds.Tables(0).Rows(i)(2).ToString()
                    objordets.Incident_Number = Input_ds.Tables(0).Rows(i)(3).ToString()
                    objordets.WFAO_CENTER = Input_ds.Tables(0).Rows(i)(4).ToString()
                    objordets.WFAO_JOBID = Input_ds.Tables(0).Rows(i)(5).ToString()
                    objordets.WFAI_JSTAT = Input_ds.Tables(0).Rows(i)(6).ToString()
                    objordets.WFAO_JT = Input_ds.Tables(0).Rows(i)(7).ToString()
                    objordets.WFAO_TASK_PRIORITY = Input_ds.Tables(0).Rows(i)(8).ToString()
                    objordets.WFAO_SKILLS = Input_ds.Tables(0).Rows(i)(9).ToString()
                    objordets.WFAO_CKTID = Input_ds.Tables(0).Rows(i)(10).ToString()
                    objordets.WFAO_POM = Input_ds.Tables(0).Rows(i)(11).ToString()
                    objordets.WFAO_PON = Input_ds.Tables(0).Rows(i)(12).ToString()
                    objordets.WFAO_BILLNAME = Input_ds.Tables(0).Rows(i)(13).ToString()
                    'Code Added to avoid more than 30 characters
                    If objordets.WFAO_BILLNAME.Length > 30 Then
                        objordets.WFAO_BILLNAME = objordets.WFAO_BILLNAME.Substring(0, 30)
                    End If

                    objordets.WFAO_TELEPHONE = Input_ds.Tables(0).Rows(i)(14).ToString()
                    objordets.WFAO_WC = Input_ds.Tables(0).Rows(i)(15).ToString()
                    objordets.WFAO_RTE = Input_ds.Tables(0).Rows(i)(16).ToString()
                    objordets.WFAO_DAA = Input_ds.Tables(0).Rows(i)(17).ToString()
                    objordets.WFAO_AA = Input_ds.Tables(0).Rows(i)(18).ToString()
                    objordets.WFAO_ACT = Input_ds.Tables(0).Rows(i)(19).ToString()
                    objordets.WFAO_CKLNAME = Input_ds.Tables(0).Rows(i)(20).ToString()
                    'Code Added to avoid more thgan 30 characters
                    If objordets.WFAO_CKLNAME.Length > 30 Then
                        objordets.WFAO_CKLNAME = objordets.WFAO_CKLNAME.Substring(0, 30)
                    End If
                    'objordets.WFAO_CKLNAME = objordets.WFAO_CKLNAME.Substring(0, 30)
                    objordets.WFAO_CKLADDR = Input_ds.Tables(0).Rows(i)(21).ToString()
                    objordets.WFAO_LOC_CITY = Input_ds.Tables(0).Rows(i)(22).ToString()
                    objordets.WFAO_LOC_STATE = Input_ds.Tables(0).Rows(i)(23).ToString()
                    objordets.WFAO_COMM = Input_ds.Tables(0).Rows(i)(24).ToString()
                    objordets.WFAO_START_DATE = Input_ds.Tables(0).Rows(i)(25).ToString()
                    objordets.WFAO_ACC = Input_ds.Tables(0).Rows(i)(26).ToString()
                    objordets.WFAO_A = Input_ds.Tables(0).Rows(i)(27).ToString()
                    objordets.WFAO_B = Input_ds.Tables(0).Rows(i)(28).ToString()
                    objordets.WFAO_DD = Input_ds.Tables(0).Rows(i)(29).ToString()
                    objordets.WFAO_PRC = Input_ds.Tables(0).Rows(i)(30).ToString()
                    objordets.WFAO_TPRC = Input_ds.Tables(0).Rows(i)(31).ToString()
                    objordets.WFAO_ORD_ORIG = Input_ds.Tables(0).Rows(i)(32).ToString()
                    objordets.WFAO_SVY = Input_ds.Tables(0).Rows(i)(33).ToString()
                    objordets.WFAO_PST = Input_ds.Tables(0).Rows(i)(34).ToString()
                    objordets.WFAO_COMMENTS_SUBJECT = Input_ds.Tables(0).Rows(i)(35).ToString()
                    objordets.WFAO_COMMENTS_URGENCY = Input_ds.Tables(0).Rows(i)(36).ToString()
                    objordets.WFAO_JOBPRI = Input_ds.Tables(0).Rows(i)(37).ToString()
                    objordets.WFAO_FACILITY_LABEL = Input_ds.Tables(0).Rows(i)(38).ToString()
                    objordets.WFAO_F1 = Input_ds.Tables(0).Rows(i)(39).ToString()
                    objordets.WFAO_PR = Input_ds.Tables(0).Rows(i)(40).ToString()
                    objordets.WFAO_JOB = Input_ds.Tables(0).Rows(i)(41).ToString()
                    objordets.WFAO_SCRATCHPAD_TASK_DESC = Input_ds.Tables(0).Rows(i)(42).ToString()
                    objordets.WFAO_DOCOMM_1 = Input_ds.Tables(0).Rows(i)(43).ToString()
                    objordets.WFAO_DOCOMM_2 = Input_ds.Tables(0).Rows(i)(44).ToString()
                    objordets.WFAO_DOCOMM_3 = Input_ds.Tables(0).Rows(i)(45).ToString()
                    objordets.WFAO_DOCOMM_4 = Input_ds.Tables(0).Rows(i)(46).ToString()
                    objordets.WFAO_DOCOMM_5 = Input_ds.Tables(0).Rows(i)(47).ToString()
                    objordets.WFAO_DOCOMM_6 = Input_ds.Tables(0).Rows(i)(48).ToString()
                    objordets.WFAO_DOCOMM_7 = Input_ds.Tables(0).Rows(i)(49).ToString()
                    objordets.WFAI_DEBRIEF_COMMENTS = Input_ds.Tables(0).Rows(i)(50).ToString()
                    'objordets.sWFAI_JOB_STRD = Input_ds.Tables(0).Rows(i)(46).ToString()
                    objordets.WFAI_JOB_RETURNED = Input_ds.Tables(0).Rows(i)(51).ToString()
                    objordets.MSG_INS_UPDATE_CANCEL = Input_ds.Tables(0).Rows(i)(52).ToString()
                    objordets.MSG_STATUS = Input_ds.Tables(0).Rows(i)(53).ToString()
                    objordets.MSG_ERROR = Input_ds.Tables(0).Rows(i)(54).ToString()
                    objordets.EXCEPTION_INFO = Input_ds.Tables(0).Rows(i)(55).ToString()
                    objordets.DEBRIEF_COMMENT_HISTORY = Input_ds.Tables(0).Rows(i)(56).ToString()
                    objordets.PREV_WFAI_JSTAT = Input_ds.Tables(0).Rows(i)(57).ToString()
                    objordets.TASK_CREATED_BY = Input_ds.Tables(0).Rows(i)(58).ToString()
                    objordets.SR_CREATED_BY = Input_ds.Tables(0).Rows(i)(59).ToString()
                    objordets.CREATED_BY = Input_ds.Tables(0).Rows(i)(60).ToString()
                    objordets.CREATION_DATE = Input_ds.Tables(0).Rows(i)(61).ToString()
                    objordets.LAST_UPDATED_BY = Input_ds.Tables(0).Rows(i)(62).ToString()
                    objordets.LAST_UPDATE_DATE = Input_ds.Tables(0).Rows(i)(63).ToString()
                    objordets.LAST_UPDATE_LOGIN = Input_ds.Tables(0).Rows(i)(64).ToString()
                    objordets.Ticket_Status = "WFA_PICKED"
                    conn.Close()
                    sendResponse_Ticket(objordets, 1, "WFA_INTERFACE")      'picked response


                    Dim dsTask As New DataSet
                    Dim SelectTaskId As String
                    If Not objordets.Task_Id = Nothing Then
                        If (objordets.Task_Id.ToString.Length = 0) Then
                            objordets.Task_Id = DBNull.Value.ToString
                        End If
                    Else
                        objordets.Task_Id = DBNull.Value.ToString
                    End If
                    objSelect = Array.CreateInstance(GetType(Object), 1)
                    objSelect.setvalue(objordets.Task_Id, 0)
                    SelectTaskId = "select [TASK_ID] from [OracleCPE].[dbo].[INPUT_HEADER_STAGE] where TASK_ID=?"
                    dsTask = objDbutility.SelectQuery([Global].p_sCPE_NOTIFIERDB, SelectTaskId, ex, objSelect)
                    If dsTask.Tables(0).Rows.Count > 0 Then
                        UpdateInputHeaderTask(objordets)
                    Else
                        InsertInputHeader(objordets)
                    End If


                    'Login TO WFA
                    Dim objCPEWFADOProcess As New WFADOProcess
                    Region = objCPEWFADOProcess.GetRegion(objordets.WFAO_LOC_STATE)
                    myForm.SetWFADOScreen(Region, Tirksess, Nothing)
                    objLoginUtility.LoginWFA(Region, Tirksess, Nothing)


                    Dim SelectQueryCenter As String
                    Dim Select_Ds As New DataSet
                    If Not objordets.WFAO_CENTER = Nothing Then
                        If (objordets.WFAO_CENTER.ToString.Length = 0) Then
                            objordets.WFAO_CENTER = DBNull.Value.ToString
                        End If
                    Else
                        objordets.WFAO_CENTER = DBNull.Value.ToString
                    End If
                    objSelect = Array.CreateInstance(GetType(Object), 1)
                    objSelect.setvalue(objordets.WFAO_CENTER, 0)
                    'objSelect.setvalue(objordets.WFAO_LOC_CITY, 1)
                    SelectQueryCenter = "select * from [OracleCPE].[dbo].[ZipCodes] where [ZipCode]=?"
                    Select_Ds = objDbutility.SelectQuery([Global].p_sCPE_NOTIFIERDB, SelectQueryCenter, ex, objSelect)
                    If Select_Ds.Tables(0).Rows.Count > 0 Then
                        objordets.WFAO_CENTER = Select_Ds.Tables(0).Rows(0)(4).ToString.Trim
                        objordets.WFAO_WC = Select_Ds.Tables(0).Rows(0)(2).ToString
                        UpdateInputHeader(objordets)



                        'new ticket
                        If objordets.MSG_INS_UPDATE_CANCEL = "NEW" Then
                            If objordets.WFAO_JOBID.Contains("I") Or objordets.WFAO_JOBID.Contains("R") Then
                                If objordets.WFAO_JOBID.Contains("I") Then
                                    objCPEWFADOProcess.OpenScreen(Tirksess, "DOISWR")
                                    If (Tirksess.GetString(1).Contains("(DOISWR)")) Then
                                        Tirksess.SendString(2, 9, "           ")
                                        Tirksess.SendString(2, 9, objordets.WFAO_CENTER)
                                        Tirksess.SendString(3, 8, "            ")
                                        Tirksess.SendString(3, 8, objordets.WFAO_JOBID)
                                        Tirksess.SendKeys("@1")
                                        System.Windows.Forms.Application.DoEvents()
                                        System.Threading.Thread.Sleep(1000)
                                        If (Tirksess.GetString(24).Contains("SUCCESSFUL")) Then
                                            'Send Negative Response saying already present
                                            'objordets.MSG_ERROR = "TICKET ALREADY EXIST"

                                            objordets.Ticket_Status = "TICKET CREATED"
                                            sendResponse_Ticket(objordets, -2, "WFA_INTERFACE")

                                        Else
                                            objCPEWFADOProcess.OpenScreen(Tirksess, "DOISWR")
                                            Tirksess.SendString(2, 9, "           ")
                                            Tirksess.SendString(2, 9, objordets.WFAO_CENTER)
                                            Tirksess.SendString(3, 8, "            ")
                                            Tirksess.SendString(3, 8, objordets.WFAO_JOBID)
                                            Dim DueDate1() As String
                                            Dim DDate() As String
                                            Dim DueDate As String
                                            DueDate1 = Split(objordets.WFAO_DD, " ")
                                            DDate = Split(DueDate1(0), "/")
                                            If DDate(0).Length = 1 Then
                                                DDate(0) = "0" + DDate(0)
                                            End If
                                            If DDate(1).Length = 1 Then
                                                DDate(1) = "0" + DDate(1)
                                            End If
                                            If DDate(2).Length = 4 Then
                                                DDate(2) = DDate(2).Remove(0, 2)
                                            End If
                                            DueDate = DDate(0) + DDate(1) + DDate(2)
                                            Dim lsdDate1() As String
                                            Dim LDate() As String
                                            Dim StartDate As String
                                            lsdDate1 = Split(objordets.WFAO_START_DATE, " ")
                                            LDate = Split(lsdDate1(0), "/")
                                            If LDate(0).Length = 1 Then
                                                LDate(0) = "0" + LDate(0)
                                            End If
                                            If LDate(1).Length = 1 Then
                                                LDate(1) = "0" + LDate(1)
                                            End If
                                            If LDate(2).Length = 4 Then
                                                LDate(2) = LDate(2).Remove(0, 2)
                                            End If
                                            StartDate = LDate(0) + LDate(1) + LDate(2)
                                            Dim CommDate1() As String
                                            Dim CmDate() As String
                                            Dim tym1() As String
                                            Dim tym As String
                                            Dim CommDate As String
                                            CommDate1 = Split(objordets.WFAO_COMM, " ")
                                            CmDate = Split(CommDate1(0), "/")
                                            tym1 = Split(CommDate1(1), ":")
                                            CommDate1(2) = CommDate1(2).Substring(0, 1)
                                            If tym1(0).Length = 1 Then
                                                tym1(0) = "0" + tym1(0)
                                            End If
                                            tym = tym1(0) + tym1(1)
                                            If CmDate(0).Length = 1 Then
                                                CmDate(0) = "0" + CmDate(0)
                                            End If
                                            If CmDate(1).Length = 1 Then
                                                CmDate(1) = "0" + CmDate(1)
                                            End If
                                            If CmDate(2).Length = 4 Then
                                                CmDate(2) = CmDate(2).Remove(0, 2)
                                            End If
                                            CommDate = CmDate(0) + CmDate(1) + CmDate(2) + tym + CommDate1(2)
                                            Tirksess.SendString(2, 9, "           ") 'center
                                            Tirksess.SendString(2, 9, objordets.WFAO_CENTER)
                                            Tirksess.SendString(3, 8, "            ")
                                            Tirksess.SendString(3, 8, objordets.WFAO_JOBID) 'jobid
                                            Tirksess.SendString(3, 54, "   ")
                                            Tirksess.SendString(3, 54, "PLD")
                                            objordets.WFAI_JSTAT = "PLD"

                                            'jobtype(Install or Repair)

                                            If objordets.WFAO_SKILLS.Trim.Length = 0 Or objordets.WFAO_SKILLS.Trim.Length > 3 Then


                                                objordets.WFAO_SKILLS = "EXX"

                                            End If

                                            'Added the Jobtype for New enahacment-Hari 24/08/2015

                                            If objordets.WFAO_TASK_PRIORITY.Contains("High") And Not objordets.WFAO_SKILLS.Equals("ICPSVY") Then
                                                objordets.WFAO_SKILLS = objordets.WFAO_SKILLS.Remove(2) + "U"
                                            End If

                                            objordets.WFAO_JT = "ICP" + objordets.WFAO_SKILLS
                                            Tirksess.SendString(3, 70, "      ")
                                            Tirksess.SendString(3, 70, objordets.WFAO_JT)   'changed JT for update
                                            If objordets.WFAO_CKTID.Trim.Length = 0 Then
                                                objordets.WFAO_CKTID = "123456"
                                            End If
                                            Tirksess.SendString(4, 8, "                                              ")
                                            Tirksess.SendString(4, 8, "S" + objordets.WFAO_CKTID)
                                            'billname
                                            Tirksess.SendString(6, 11, "                              ")
                                            If objordets.WFAO_BILLNAME.Contains("QCC") Then
                                                Tirksess.SendString(6, 11, objordets.WFAO_CKLNAME)
                                            Else
                                                Tirksess.SendString(6, 11, objordets.WFAO_BILLNAME)
                                            End If
                                            ' Tirksess.SendKeys("@8")
                                            Tirksess.SendString(7, 11, "                              ")
                                            Tirksess.SendString(7, 11, objordets.WFAO_CKLNAME) 'cklname
                                            Tirksess.SendString(6, 60, "      ")
                                            Tirksess.SendString(6, 60, objordets.WFAO_WC)
                                            Tirksess.SendString(8, 11, "                              ")
                                            Tirksess.SendString(8, 11, objordets.WFAO_CKLADDR) 'ckladd
                                            Tirksess.SendString(8, 47, "           ")
                                            Tirksess.SendString(8, 47, CommDate) 'commitmentdate-0927130500P
                                            Tirksess.SendString(8, 64, " ") 'acc
                                            Tirksess.SendString(8, 64, "A") 'acc
                                            Tirksess.SendString(5, 6, "                    ")
                                            Tirksess.SendString(5, 6, objordets.WFAO_PON) 'PON
                                            Tirksess.SendString(13, 11, objordets.WFAO_ORD_ORIG)
                                            Tirksess.SendString(10, 5, "      ")
                                            Tirksess.SendString(10, 5, DueDate) 'due date
                                            Tirksess.SendString(9, 54, "           ")
                                            Tirksess.SendString(9, 54, StartDate) 'lsd
                                            Tirksess.SendString(11, 32, "            ")
                                            Tirksess.SendString(11, 32, objordets.WFAO_PRC) 'prc
                                            Tirksess.SendString(11, 41, "000:00") 'prc
                                            'Tirksess.SendString(13, 29, "           ")
                                            ' Tirksess.SendString(13, 29, "1114130600A") 'rcvdso
                                            Tirksess.SendString(13, 29, CommDate) 'rcvdso
                                            Tirksess.SendString(14, 26, " ")
                                            Tirksess.SendString(14, 26, objordets.WFAO_SVY) 'svy
                                            Tirksess.SendString(22, 2, "  ")
                                            Tirksess.SendString(22, 2, "f1") ' f1
                                            Tirksess.SendString(22, 12, "   ")
                                            Tirksess.SendString(22, 12, "UNK") 'cbl
                                            Tirksess.SendString(22, 26, "        ")
                                            Tirksess.SendString(13, 29, "           ")
                                            Tirksess.SendString(13, 60, "  ")
                                            Tirksess.SendString(22, 26, "0001") 'pr
                                            Tirksess.SendString(9, 6, objordets.WFAO_LOC_CITY + " " + objordets.WFAO_LOC_STATE) 'loc
                                            Tirksess.SendString(18, 11, objordets.WFAO_COMMENTS_SUBJECT)
                                            Tirksess.SendKeys("@4")
                                            System.Windows.Forms.Application.DoEvents()
                                            System.Threading.Thread.Sleep(1000)
                                            If Tirksess.GetString(24).Contains("INVALID DATE") Then
                                                Tirksess.SendString(13, 29, CommDate)
                                                Tirksess.SendKeys("@4")
                                            End If
                                            'Ticket Created
                                            If Tirksess.GetString(24).Contains("ADD SUCCESSFUL ") Then
                                                objordets.Ticket_Status = "TICKET CREATED"
                                                objordets.DOSOI_URL = save_text(objordets, Tirksess)
                                                objCPEWFADOProcess.OpenScreen(Tirksess, "DOSOI")
                                                Tirksess.SendString(2, 9, "           ")
                                                Tirksess.SendString(2, 9, objordets.WFAO_CENTER)
                                                Tirksess.SendString(3, 8, "            ")
                                                Tirksess.SendString(3, 8, objordets.WFAO_JOBID)
                                                Tirksess.SendKeys("@1")
                                                If Tirksess.GetString(24).Contains("SUCCESSFUL") Then
                                                    Tirksess.SendString(19, 2, objordets.DOSOI_URL)
                                                    Tirksess.SendKeys("@5")
                                                    If Tirksess.GetString(24).Contains("SUCCESSFUL") Then
                                                        Docomm_Comment_Update(Tirksess, objordets)
                                                        objordets.Ticket_Created_Date = DateTime.Now()
                                                    End If
                                                End If
                                                'TICKET NOT CREATED
                                            Else
                                                objordets.MSG_ERROR = Tirksess.GetString(24).ToString
                                                objordets.Ticket_Status = "INVALID DETAILS PROVIDED"
                                                objordets.MAIL_ERROR_MSG = Tirksess.GetString(24).ToString
                                                Send_mail(objordets)
                                            End If
                                        End If
                                    End If


                                    'Repair Ticket Process Starts 

                                ElseIf objordets.WFAO_JOBID.Contains("R") Then
                                    objCPEWFADOProcess.OpenScreen(Tirksess, "DOMCWR")
                                    If Tirksess.GetString(1).Contains("(DOMCWR)") Then

                                        Dim CommDate1() As String
                                        Dim CmDate() As String
                                        Dim tym1() As String
                                        Dim tym As String
                                        Dim CommDate As String
                                        'Gowtham Check

                                        CommDate1 = Split(objordets.WFAO_COMM, " ")
                                        CmDate = Split(CommDate1(0), "/")
                                        tym1 = Split(CommDate1(1), ":")
                                        CommDate1(2) = CommDate1(2).Substring(0, 1)
                                        If tym1(0).Length = 1 Then
                                            tym1(0) = "0" + tym1(0)
                                        End If
                                        tym = tym1(0) + tym1(1)
                                        If CmDate(0).Length = 1 Then
                                            CmDate(0) = "0" + CmDate(0)
                                        End If
                                        If CmDate(1).Length = 1 Then
                                            CmDate(1) = "0" + CmDate(1)
                                        End If
                                        If CmDate(2).Length = 4 Then
                                            CmDate(2) = CmDate(2).Remove(0, 2)
                                        End If
                                        CommDate = CmDate(0) + CmDate(1) + CmDate(2) + tym + CommDate1(2)
                                        Tirksess.SendString(2, 9, "           ") 'center
                                        Tirksess.SendString(2, 9, objordets.WFAO_CENTER)
                                        Tirksess.SendString(3, 8, "            ")
                                        Tirksess.SendString(3, 8, objordets.WFAO_JOBID) 'jobid
                                        Tirksess.SendKeys("@1")
                                        If Tirksess.GetString(24).Contains("SUCCESSFULL") Then
                                            objordets.MSG_ERROR = "TICKET ALREADY EXIST"
                                            objordets.Ticket_Status = "TICKET NOT CREATED"
                                            objordets.MAIL_ERROR_MSG = Tirksess.GetString(24).ToString
                                            Send_mail(objordets)
                                        Else
                                            Tirksess.SendString(3, 40, "   ") 'JSTAT
                                            Tirksess.SendString(3, 40, "PLD")
                                            objordets.WFAI_JSTAT = "PLD"
                                            Tirksess.SendString(3, 56, "     ") 'JT
                                            If objordets.WFAO_SKILLS.Trim.Length = 0 Then
                                                objordets.WFAO_SKILLS = "EXX"
                                            End If
                                            If objordets.WFAO_TASK_PRIORITY.Contains("High") Then
                                                objordets.WFAO_SKILLS = objordets.WFAO_SKILLS.Remove(2, 1) + "U"
                                            End If
                                            objordets.WFAO_JT = "MCP" + objordets.WFAO_SKILLS
                                            Tirksess.SendString(3, 56, objordets.WFAO_JT)
                                            'Tirksess.SendString(3, 56, "MCPEXX")
                                            Tirksess.SendString(3, 67, "          ")
                                            Tirksess.SendString(5, 8, "                                              ") 'cktid
                                            If objordets.WFAO_CKTID.Trim.Length = 0 Then
                                                objordets.WFAO_CKTID = "123456"
                                            End If
                                            Tirksess.SendString(5, 8, "S" + objordets.WFAO_CKTID)
                                            Tirksess.SendString(6, 7, "                             ")
                                            If objordets.WFAO_BILLNAME.Contains("QCC") Then
                                                Tirksess.SendString(6, 7, objordets.WFAO_CKLNAME)
                                            Else
                                                Tirksess.SendString(6, 7, objordets.WFAO_BILLNAME)
                                            End If
                                            'billname
                                            Tirksess.SendString(7, 7, "                              ")
                                            Tirksess.SendString(7, 7, objordets.WFAO_CKLADDR) 'addr
                                            Tirksess.SendString(6, 41, "      ")
                                            Tirksess.SendString(6, 41, objordets.WFAO_WC) 'WC
                                            Tirksess.SendString(8, 6, objordets.WFAO_LOC_CITY + " " + objordets.WFAO_LOC_STATE) 'loc
                                            'Tirksess.SendString(9, 10, "") 'RPTRCV
                                            Tirksess.SendString(9, 55, "            ")
                                            Tirksess.SendString(9, 55, objordets.WFAO_PRC) 'prc
                                            Tirksess.SendString(9, 67, "            ")
                                            Tirksess.SendString(9, 67, objordets.WFAO_TPRC) 'TPRC
                                            Tirksess.SendString(10, 7, "           ")
                                            Tirksess.SendString(9, 79, " ")
                                            Tirksess.SendString(10, 7, CommDate) 'commitmentdate
                                            Tirksess.SendString(10, 25, " ") 'ac
                                            Tirksess.SendString(10, 25, "A")
                                            Tirksess.SendString(11, 10, objordets.WFAO_COMMENTS_SUBJECT) 'trouble
                                            Tirksess.SendString(15, 34, "CR") 'RPTCAT
                                            Tirksess.SendString(16, 7, "N") 'LMOS

                                            Tirksess.SendString(20, 2, "  ")
                                            Tirksess.SendString(20, 2, "f1")
                                            Tirksess.SendString(20, 8, "   ")
                                            Tirksess.SendString(20, 8, "UNK")
                                            Tirksess.SendString(20, 19, "    ")
                                            Tirksess.SendString(20, 19, "0001")
                                            Tirksess.SendString(19, 59, "Z") 'end
                                            Tirksess.SendKeys("@4")
                                            System.Windows.Forms.Application.DoEvents()
                                            System.Threading.Thread.Sleep(1000)


                                            If Tirksess.GetString(24).Contains("SUCCESSFUL") Then

                                                objordets.Ticket_Status = "TICKET CREATED"
                                                objordets.DOSOI_URL = save_text(objordets, Tirksess)
                                                'objCPEWFADOProcess.OpenScreen(Tirksess, "DOSOI")
                                                Tirksess.SendString(2, 9, "           ")
                                                Tirksess.SendString(2, 9, objordets.WFAO_CENTER)
                                                Tirksess.SendString(3, 8, objordets.WFAO_JOBID)
                                                Tirksess.SendKeys("@1")
                                                If Tirksess.GetString(24).Contains("SUCCESSFUL") Then
                                                    Tirksess.SendString(12, 7, objordets.DOSOI_URL)
                                                    Tirksess.SendKeys("@5")
                                                    If Tirksess.GetString(24).Contains("SUCCESSFUL") Then
                                                        Docomm_Comment_Update(Tirksess, objordets)
                                                        objordets.Ticket_Created_Date = DateTime.Now() 'Now().ToString
                                                    End If
                                                End If
                                            Else
                                                objordets.MSG_ERROR = Tirksess.GetString(24).ToString
                                                objordets.Ticket_Status = "INVALID DETAILS PROVIDED"
                                                objordets.MAIL_ERROR_MSG = Tirksess.GetString(24).ToString
                                                Send_mail(objordets)
                                            End If
                                        End If
                                    End If
                                End If
                            Else
                                'neg response for no I or R
                            End If
                            If (objordets.Ticket_Status.Equals("TICKET CREATED")) Then
                                sendResponse_Ticket(objordets, 2, "WFA_INTERFACE")
                                'BK_sendResponse_Ticket(objordets, 2, "WFA_INTERFACE")
                            Else
                                sendResponse_Ticket(objordets, -2, "WFA_INTERFACE")
                            End If
                            ' UpdateInputHeaderTask(objordets)
                            'UPDATE process
                        ElseIf objordets.MSG_INS_UPDATE_CANCEL = "UPDATE" Then
                            If objordets.WFAO_JOBID.Contains("I") Then
                                objCPEWFADOProcess.OpenScreen(Tirksess, "DOISWR")
                                If (Tirksess.GetString(1).Contains("(DOISWR)")) Then
                                    Tirksess.SendString(2, 9, objordets.WFAO_CENTER) ' cntrID
                                    Tirksess.SendString(3, 8, objordets.WFAO_JOBID)
                                    Tirksess.SendKeys("@1")
                                    System.Windows.Forms.Application.DoEvents()
                                    System.Threading.Thread.Sleep(1000)

                                    If Tirksess.GetString(24).Contains("SUCCESSFUL") Then

                                        objordets.WFAI_JSTAT = Tirksess.GetString(3, 54, 56)
                                        If objordets.WFAI_JSTAT = "PLD" Or objordets.WFAI_JSTAT = "PRE" Then
                                            Dim DueDate1() As String
                                            Dim DueDate As String
                                            Dim DDate() As String
                                            DueDate1 = Split(objordets.WFAO_DD, " ")
                                            DDate = Split(DueDate1(0), "/")
                                            If DDate(0).Length = 1 Then
                                                DDate(0) = "0" + DDate(0)
                                            End If
                                            If DDate(1).Length = 1 Then
                                                DDate(1) = "0" + DDate(1)
                                            End If
                                            If DDate(2).Length = 4 Then
                                                DDate(2) = DDate(2).Remove(0, 2)
                                            End If
                                            DueDate = DDate(0) + DDate(1) + DDate(2)

                                            Dim lsdDate1() As String
                                            Dim LDate() As String
                                            Dim StartDate As String
                                            lsdDate1 = Split(objordets.WFAO_START_DATE, " ")
                                            LDate = Split(lsdDate1(0), "/")
                                            If LDate(0).Length = 1 Then
                                                LDate(0) = "0" + LDate(0)
                                            End If
                                            If LDate(1).Length = 1 Then
                                                LDate(1) = "0" + LDate(1)
                                            End If
                                            If LDate(2).Length = 4 Then
                                                LDate(2) = LDate(2).Remove(0, 2)
                                            End If
                                            StartDate = LDate(0) + LDate(1) + LDate(2)
                                            Dim CommDate As String
                                            Dim CommDate1() As String
                                            Dim CmDate() As String
                                            Dim tym1() As String
                                            Dim tym As String
                                            CommDate1 = Split(objordets.WFAO_COMM, " ")
                                            CmDate = Split(CommDate1(0), "/")
                                            tym1 = Split(CommDate1(1), ":")
                                            CommDate1(2) = CommDate1(2).Substring(0, 1)
                                            If tym1(0).Length = 1 Then
                                                tym1(0) = "0" + tym1(0)
                                            End If
                                            tym = tym1(0) + tym1(1)
                                            If CmDate(0).Length = 1 Then
                                                CmDate(0) = "0" + CmDate(0)
                                            End If
                                            If CmDate(1).Length = 1 Then
                                                CmDate(1) = "0" + CmDate(1)
                                            End If
                                            If CmDate(2).Length = 4 Then
                                                CmDate(2) = CmDate(2).Remove(0, 2)
                                            End If
                                            CommDate = CmDate(0) + CmDate(1) + CmDate(2) + tym + CommDate1(2)
                                            Tirksess.SendString(8, 47, CommDate)
                                            Tirksess.SendString(9, 54, StartDate)
                                            Tirksess.SendString(10, 5, DueDate)
                                            Tirksess.SendString(5, 9, objordets.WFAO_PON)
                                            Tirksess.SendKeys("@5")

                                            System.Windows.Forms.Application.DoEvents()
                                            System.Threading.Thread.Sleep(1000)
                                            If (Tirksess.GetString(24).Contains(" UPDATED")) Then
                                                objordets.WFAI_DEBRIEF_COMMENTS = objordets.WFAI_DEBRIEF_COMMENTS + "UPDATED PROCESS COMPLETED." + "RESOLVE BY DATE: " & CommDate & "SCHEDULE START DATE:" & StartDate & "DUE DATE:" & DueDate
                                                sendResponse_Ticket(objordets, 4, "WFA_INTERFACE")
                                                objordets.Ticket_Status = "UPDATED"
                                            Else
                                                objordets.MSG_ERROR = Tirksess.GetString(24)
                                                sendResponse_Ticket(objordets, -4, "WFA_INTERFACE")
                                                objordets.Ticket_Status = "WFA_ERROR"

                                            End If
                                            'UpdateInputHeaderTask(objordets)
                                        End If

                                    End If

                                End If
                            ElseIf objordets.WFAO_JOBID.Contains("R") Then
                                objCPEWFADOProcess.OpenScreen(Tirksess, "DOMCWR")
                                If Tirksess.GetString(1).Contains("(DOMCWR)") Then
                                    Tirksess.SendString(2, 9, objordets.WFAO_CENTER) ' cntrID
                                    Tirksess.SendString(3, 8, objordets.WFAO_JOBID)
                                    Tirksess.SendKeys("@1")
                                    System.Windows.Forms.Application.DoEvents()
                                    System.Threading.Thread.Sleep(1000)
                                    If Tirksess.GetString(24).Contains("SUCCESSFUL") Then

                                        objordets.WFAI_JSTAT = Tirksess.GetString(3, 40, 42)
                                        If objordets.WFAI_JSTAT = "PLD" Or objordets.WFAI_JSTAT = "PRE" Then
                                            Dim CommDate As String
                                            Dim CommDate1() As String
                                            Dim CmDate() As String
                                            Dim tym1() As String
                                            Dim tym As String
                                            CommDate1 = Split(objordets.WFAO_COMM, " ")
                                            CmDate = Split(CommDate1(0), "/")
                                            tym1 = Split(CommDate1(1), ":")
                                            CommDate1(2) = CommDate1(2).Substring(0, 1)
                                            If tym1(0).Length = 1 Then
                                                tym1(0) = "0" + tym1(0)
                                            End If
                                            tym = tym1(0) + tym1(1)
                                            If CmDate(0).Length = 1 Then
                                                CmDate(0) = "0" + CmDate(0)
                                            End If
                                            If CmDate(1).Length = 1 Then
                                                CmDate(1) = "0" + CmDate(1)
                                            End If
                                            If CmDate(2).Length = 4 Then
                                                CmDate(2) = CmDate(2).Remove(0, 2)
                                            End If
                                            CommDate = CmDate(0) + CmDate(1) + CmDate(2) + tym + CommDate1(2)
                                            Tirksess.SendString(10, 7, CommDate)
                                            Tirksess.SendKeys("@5")
                                            System.Windows.Forms.Application.DoEvents()
                                            System.Threading.Thread.Sleep(1000)
                                            If Tirksess.GetString(24).Contains("UPDATED") Then
                                                'send response
                                                objordets.WFAI_DEBRIEF_COMMENTS = objordets.WFAI_DEBRIEF_COMMENTS + "UPDATED PROCESS COMPLETED." + "RESOLVE BY DATE: " & CommDate
                                                sendResponse_Ticket(objordets, 4, "WFA_INTERFACE")
                                                objordets.Ticket_Status = "UPDATED"
                                            Else
                                                objordets.MSG_ERROR = Tirksess.GetString(24)
                                                sendResponse_Ticket(objordets, -4, "WFA_INTERFACE")
                                                objordets.Ticket_Status = "WFA_ERROR"
                                            End If
                                            ' UpdateInputHeaderTask(objordets)
                                        End If

                                    End If
                                End If
                            End If
                            'Cancel
                        ElseIf objordets.MSG_INS_UPDATE_CANCEL = "CANCELLED" Then
                            If objordets.WFAO_JOBID.Contains("I") Then
                                objCPEWFADOProcess.OpenScreen(Tirksess, "DOISWR")
                                If (Tirksess.GetString(1).Contains("(DOISWR)")) Then
                                    'Tirksess.SendString(2, 9, objordets.WFAO_WC) 'centerid
                                    Tirksess.SendString(2, 9, "           ") 'center
                                    Tirksess.SendString(2, 9, objordets.WFAO_CENTER)
                                    'Tirksess.SendString(4, 8, objordets.WFAO_CKTID)
                                    Tirksess.SendString(3, 8, "            ")
                                    Tirksess.SendString(3, 8, objordets.WFAO_JOBID)
                                    Tirksess.SendKeys("@1")
                                    System.Windows.Forms.Application.DoEvents()
                                    System.Threading.Thread.Sleep(1000)
                                    objordets.WFAO_JT = Tirksess.GetString(3, 70, 75)
                                    objordets.WFAI_JSTAT = Tirksess.GetString(3, 54, 56)
                                    If (Tirksess.GetString(24).Contains("SUCCESSFUL")) Then
                                        If Tirksess.GetString(3, 54, 56).Equals("PLD") Then
                                            'Tirksess.SendString(3, 54, "PLD")
                                            Tirksess.SendString(1, 11, "        ")
                                            Tirksess.SendString(1, 11, "CAN")
                                            Tirksess.SendKeys("@E")
                                            If Tirksess.GetString(24).Contains("SUCCESSFUL") Then
                                                objordets.WFAI_JSTAT = "CAN"
                                                objordets.Ticket_Status = "CANCELLED"
                                            Else
                                                objordets.Ticket_Status = "NOT CANCELLED"
                                                objordets.MSG_ERROR = Tirksess.GetString(24)
                                            End If


                                        ElseIf (Tirksess.GetString(3, 54, 56)).Trim.Equals("PRE") Then
                                            objCPEWFADOProcess.OpenScreen(Tirksess, "DOISWR")
                                            Tirksess.SendString(2, 9, "           ") 'center
                                            Tirksess.SendString(2, 9, objordets.WFAO_CENTER)
                                            'Tirksess.SendString(4, 8, objordets.WFAO_CKTID)
                                            Tirksess.SendString(3, 8, "            ")
                                            Tirksess.SendString(3, 8, objordets.WFAO_JOBID)
                                            Tirksess.SendKeys("@1")
                                            System.Windows.Forms.Application.DoEvents()
                                            System.Threading.Thread.Sleep(1000)
                                            Tirksess.SendString(1, 73, "DOTLOG")
                                            Tirksess.SendKeys("@E")
                                            'code to remove the Job ID exactly
                                            If Tirksess.GetString(1).Contains("(DOTLOG)") Then
                                                Dim icount As Integer
                                                For icount = 8 To 20

                                                    If Tirksess.GetString(icount, 9, 19).Equals(objordets.WFAO_JOBID) Then
                                                        Tirksess.SendString(icount, 2, "d") 'center
                                                        Tirksess.SendKeys("@a")

                                                    End If
                                                    icount = icount + 1
                                                Next


                                                'Tirksess.SendString(8, 2, "d") 'center
                                                'Tirksess.SendKeys("@a") 'ALL WORK REQUESTS FOR TECHNICIAN HAVE BEEN
                                                If Tirksess.GetString(24).Contains("DELETE") Then
                                                    objCPEWFADOProcess.OpenScreen(Tirksess, "DOISWR")
                                                    If Tirksess.GetString(24).Contains("SUCCESSFUL") Then
                                                        Tirksess.SendString(2, 9, "           ") 'center
                                                        Tirksess.SendString(2, 9, objordets.WFAO_CENTER)
                                                        'Tirksess.SendString(4, 8, objordets.WFAO_CKTID)
                                                        Tirksess.SendString(3, 8, "            ")
                                                        Tirksess.SendString(3, 8, objordets.WFAO_JOBID)
                                                        Tirksess.SendKeys("@1")

                                                        Tirksess.SendString(1, 11, "        ")
                                                        Tirksess.SendString(1, 11, "CAN")
                                                        Tirksess.SendKeys("@E")
                                                        If Tirksess.GetString(24).Contains("SUCCESSFUL") Then
                                                            objordets.WFAI_JSTAT = "CAN"
                                                            objordets.Ticket_Status = "CANCELLED"
                                                        Else
                                                            objordets.Ticket_Status = "WFA_ERROR"
                                                            objordets.MSG_ERROR = Tirksess.GetString(24)
                                                        End If
                                                    End If
                                                End If
                                            End If

                                        ElseIf (Tirksess.GetString(3, 54, 56)).Trim.Equals("DSP") Then
                                            'SENDRESPONSE STATING ORDER HAS BEEN DISPATCHED
                                            objordets.WFAI_JSTAT = "DSP"
                                            objordets.Ticket_Status = "WFA_ERROR"
                                            objordets.MSG_ERROR = "TICKET HAS BEEN DISPATCHED"
                                        ElseIf (Tirksess.GetString(3, 54, 56)).Equals("CAN") Then
                                            objordets.WFAI_JSTAT = "CAN"
                                            objordets.Ticket_Status = "WFA_ERROR"
                                            objordets.MSG_ERROR = "TICKET ALREADY CANCELLED"
                                        ElseIf (Tirksess.GetString(3, 54, 56)).Equals("CMP") Then
                                            objordets.WFAI_JSTAT = "CMP"
                                            objordets.Ticket_Status = "WFA_ERROR"
                                            objordets.MSG_ERROR = "TICKET COMPLETED"
                                        End If
                                    Else
                                        objordets.Ticket_Status = "WFA_ERROR"
                                        objordets.MSG_ERROR = "TICKET NOT FOUND"
                                    End If
                                End If
                                'UpdateInputHeaderTask(objordets)
                            Else
                                objCPEWFADOProcess.OpenScreen(Tirksess, "DOMCWR")
                                If (Tirksess.GetString(1).Contains("(DOMCWR)")) Then
                                    'Tirksess.SendString(2, 9, objordets.WFAO_WC) 'centerid
                                    Tirksess.SendString(2, 9, "           ") 'center
                                    Tirksess.SendString(2, 9, objordets.WFAO_CENTER)
                                    'Tirksess.SendString(4, 8, objordets.WFAO_CKTID)
                                    Tirksess.SendString(3, 8, "            ")
                                    Tirksess.SendString(3, 8, objordets.WFAO_JOBID)
                                    Tirksess.SendKeys("@1")
                                    System.Windows.Forms.Application.DoEvents()
                                    System.Threading.Thread.Sleep(1000)

                                    If (Tirksess.GetString(24).Contains("SUCCESSFUL")) Then
                                        objordets.WFAO_JT = Tirksess.GetString(3, 56, 61)
                                        objordets.WFAI_JSTAT = Tirksess.GetString(3, 40, 42)
                                        If (Tirksess.GetString(3, 40, 42)).Equals("PLD") Then

                                            Tirksess.SendString(1, 11, "        ")
                                            Tirksess.SendString(1, 11, "CAN")
                                            Tirksess.SendKeys("@E")


                                            If Tirksess.GetString(24).Contains("SUCCESSFUL") Then
                                                objordets.WFAI_JSTAT = "CAN"
                                                objordets.Ticket_Status = "CANCELLED"
                                            Else
                                                objordets.Ticket_Status = "WFA_ERROR"
                                                objordets.MSG_ERROR = Tirksess.GetString(24)
                                            End If

                                        ElseIf (Tirksess.GetString(3, 40, 42)).Trim.Equals("PRE") Then
                                            Tirksess.SendString(1, 73, "DOTLOG")
                                            Tirksess.SendKeys("@E")
                                            'objCPEWFADOProcess.OpenScreen(Tirksess, "DOTLOG")
                                            If (Tirksess.GetString(1).Contains("(DOTLOG)")) Then

                                                Tirksess.SendString(8, 2, "d") 'center
                                                Tirksess.SendKeys("@a")

                                                If Tirksess.GetString(24).Contains("DELETED") Then
                                                    objCPEWFADOProcess.OpenScreen(Tirksess, "DOMCWR")
                                                    Tirksess.SendString(2, 9, "           ") 'center
                                                    Tirksess.SendString(2, 9, objordets.WFAO_CENTER)
                                                    Tirksess.SendString(4, 8, objordets.WFAO_CKTID)
                                                    Tirksess.SendString(3, 8, "            ")
                                                    Tirksess.SendString(3, 8, objordets.WFAO_JOBID)
                                                    Tirksess.SendKeys("@1")
                                                    If Tirksess.GetString(24).Contains("SUCCESSFUL") Then
                                                        Tirksess.SendString(1, 11, "        ")
                                                        Tirksess.SendString(1, 11, "CAN")
                                                        Tirksess.SendKeys("@E")

                                                        If Tirksess.GetString(24).Contains("SUCCESSFUL") Then
                                                            objordets.WFAI_JSTAT = "CAN"
                                                            objordets.Ticket_Status = "CANCELLED"
                                                        Else
                                                            objordets.Ticket_Status = "WFA_ERROR"
                                                            objordets.MSG_ERROR = Tirksess.GetString(24)
                                                        End If
                                                    End If
                                                End If
                                            End If
                                        ElseIf (Tirksess.GetString(3, 40, 42)).Equals("CAN") Then
                                            objordets.WFAI_JSTAT = "CAN"
                                            objordets.Ticket_Status = "WFA_ERROR"
                                            objordets.MSG_ERROR = "TICKET ALREADY CANCELLED"

                                        ElseIf (Tirksess.GetString(3, 40, 42)).Trim.Equals("DSP") Then
                                            objordets.WFAI_JSTAT = "DSP"
                                            objordets.Ticket_Status = "WFA_ERROR"
                                            objordets.MSG_ERROR = "TICKET DISPATCHED"
                                        ElseIf (Tirksess.GetString(3, 40, 42)).Trim.Equals("CMP") Then
                                            objordets.WFAI_JSTAT = "CMP"
                                            objordets.Ticket_Status = "WFA_ERROR"
                                            objordets.MSG_ERROR = "TICKET COMPLETED"
                                        End If
                                    Else
                                        objordets.Ticket_Status = "WFA_ERROR"
                                        objordets.MSG_ERROR = "TICKET NOT FOUND"

                                    End If

                                End If
                            End If
                            'UpdateInputHeader(objordets)
                            'cancel response
                            If objordets.Ticket_Status.Equals("CANCELLED") Then
                                sendResponse_Ticket(objordets, 5, "WFA_INTERFACE")
                            ElseIf objordets.Ticket_Status.Equals("WFA_ERROR") Then
                                If objordets.MSG_ERROR = "TICKET NOT FOUND" Then
                                    objordets.Ticket_Status = "CANCELLED"
                                End If
                                sendResponse_Ticket(objordets, -5, "WFA_INTERFACE")
                            End If

                        End If
                    Else
                        sendResponse_Ticket(objordets, -1, "WFA_INTERFACE")
                    End If
                    UpdateInputHeaderTask(objordets)
                    objordets = Nothing
                Next
            End If


            'TECH ASSIGNEMNT CHECK PROCESS


            Dosoi_Process(Tirksess)


            objordets = Nothing



            'Dosoi_Process(Tirksess)
        Catch ex As Exception
            p_objLogger.writenote("Exception: :-" & ex.ToString(), objordets.Task_Id, EventLogEntryType.Error)
        End Try
    End Function

    Function Debrief_Process(ByVal Tirksess As AxSmartRumba.AxSmartRumbaControl, ByRef objordets As OrderDetails)
        Try
            Dim objCPEWFADOProcess As New WFADOProcess
            If objordets.WFAO_JOBID.Contains("I") Then
                objCPEWFADOProcess.OpenScreen(Tirksess, "DOISWR")
                If Tirksess.GetString(1).Contains("WFADO: SS INST WORK REQUEST (DOISWR)") Then
                    Tirksess.SendString(2, 9, objordets.WFAO_CENTER) ' cntrID
                    Tirksess.SendString(3, 8, objordets.WFAO_JOBID)
                    Tirksess.SendKeys("@1")
                    System.Windows.Forms.Application.DoEvents()
                    System.Threading.Thread.Sleep(1000)
                    If Tirksess.GetString(24).Contains("SUCCESSFUL") Then
                        objordets.WFAI_JSTAT = Tirksess.GetString(3, 54, 56)
                        If objordets.WFAI_JSTAT.Contains("PRE") Then
                            objCPEWFADOProcess.OpenScreen(Tirksess, "DOLOG")
                            If Tirksess.GetString(1).Contains("WFADO: WORK REQUEST EVENT LOG (DOLOG)") Then
                                Tirksess.SendString(2, 10, objordets.WFAO_CENTER) ' cntrID
                                Tirksess.SendString(3, 9, objordets.WFAO_JOBID)
                                Tirksess.SendKeys("@1")
                                System.Windows.Forms.Application.DoEvents()
                                System.Threading.Thread.Sleep(1000)
                                If Not Tirksess.GetString(12, 2, 13) = objordets.Job_Started_Date Then ',chck
                                    If Tirksess.GetString(12, 43, 62).Contains("JOB STAT RETD TO PRE") Then
                                        'objordets.Job_Started = Tirksess.GetString(12, 2, 13).Trim

                                        objordets.Dolog_Comment = Tirksess.GetString(13).Trim
                                        objordets.Job_Started_Date = Tirksess.GetString(12, 2, 13)
                                        objCPEWFADOProcess.OpenScreen(Tirksess, "DOCOMP")
                                        Tirksess.SendString(2, 10, objordets.WFAO_CENTER) ' cntrID
                                        Tirksess.SendString(5, 9, objordets.WFAO_JOBID)
                                        Tirksess.SendKeys("@1")
                                        If Tirksess.GetString(1).Contains("(DOCOMP)") And Tirksess.GetString(24).Contains("SUCCESSFUL") Then

                                            objordets.Ticket_Status = "TECH ASSIGNED"
                                            'update input table
                                            Debrief_Input_Header(objordets)
                                            'insert debrief table
                                            objordets.D_WFAI_DOCOMP_ITEM = Tirksess.GetString(20, 15, 18)
                                            ' objordets.Dolog_Comment = Tirksess.GetString(18, 12, 80).Trim + "," + Tirksess.GetString(20, 19, 78).Trim
                                            Debrief_comment_manipulator(objordets)
                                            '' Debrief_Item(objordets)
                                            'Before inserting check it-Lakxmi_720
                                            'Insert_D_Table(objordets)

                                        End If
                                    End If
                                End If
                            End If
                        ElseIf objordets.WFAI_JSTAT.Contains("DSP") Then
                            objCPEWFADOProcess.OpenScreen(Tirksess, "DOLOG")
                            If Tirksess.GetString(1).Contains("WFADO: WORK REQUEST EVENT LOG (DOLOG)") Then
                                Tirksess.SendString(2, 10, "          ") ' cntrID
                                Tirksess.SendString(2, 10, objordets.WFAO_CENTER)
                                Tirksess.SendString(3, 9, "           ")
                                Tirksess.SendString(3, 9, objordets.WFAO_JOBID)
                                Tirksess.SendKeys("@1")
                                System.Windows.Forms.Application.DoEvents()
                                System.Threading.Thread.Sleep(1000)
                                If Tirksess.GetString(24).Contains("SUCCESSFUL") Then
                                    objordets.Job_Started_Date = Tirksess.GetString(12, 2, 13)
                                    objordets.Ticket_Status = "DISPATCHED"
                                End If
                            End If

                            Debrief_Input_Header(objordets)
                        ElseIf objordets.WFAI_JSTAT.Contains("CMP") Then
                            objCPEWFADOProcess.OpenScreen(Tirksess, "DOLOG")
                            If Tirksess.GetString(1).Contains("WFADO: WORK REQUEST EVENT LOG (DOLOG)") Then
                                Tirksess.SendString(2, 10, objordets.WFAO_CENTER) ' cntrID
                                Tirksess.SendString(3, 9, objordets.WFAO_JOBID)
                                Tirksess.SendKeys("@1")
                                System.Windows.Forms.Application.DoEvents()
                                System.Threading.Thread.Sleep(1000)
                                objordets.Dolog_Comment = Tirksess.GetString(13).Trim
                                'Lakxmi_720 not workin correctly  'Hari this is not job started obj
                                objordets.Job_Started_Date = Tirksess.GetString(12, 2, 13)

                                'Tirksess.SendKeys("@8")
lbl1:                           objCPEWFADOProcess.OpenScreen(Tirksess, "DOCOMP")
                                Tirksess.SendString(2, 10, objordets.WFAO_CENTER)
                                Tirksess.SendString(5, 9, objordets.WFAO_JOBID)
                                Tirksess.SendKeys("@1")
                                If Tirksess.GetString(1).Contains("(DOCOMP)") And Tirksess.GetString(24).Contains("SUCCESSFUL") Then
                                    objordets.D_WFAI_DOCOMP_ITEM = Tirksess.GetString(20, 15, 18).Trim
                                    objordets.D_WFAI_JOB_STRTD = Tirksess.GetString(7, 42, 55)  'this is job started
                                    objordets.Ticket_Status = "COMPLETED"
                                    objordets.WFAI_DEBRIEF_COMMENTS = Tirksess.GetString(10, 12, 80).Trim + Tirksess.GetString(11, 2, 70).Trim
                                ElseIf Tirksess.GetString(24).Contains("TECHNICIAN") Then
                                    'NO JOB CURRENTLY DISPATCHED TO THIS 
                                    GoTo lbl1
                                End If
                            End If
                            Dim StartDate As String
                            Dim StartDate1() As String
                            Dim s, s1, s2 As String
                            Dim t, t1, t2 As String
                            'START DATE CHANGE
                            StartDate1 = Split(objordets.D_WFAI_JOB_STRTD, " ") 'Job Started format
                            StartDate1(0) = StartDate1(0) + StartDate1(1) + StartDate1(2)
                            If StartDate1(0).Length = 6 Then
                                s = Mid(StartDate1(0), 1, 2)
                                s1 = Mid(StartDate1(0), 3, 2)
                                s2 = Mid(StartDate1(0), 5, 2)
                                StartDate1(0) = s + "/" + s1 + "/20" + s2
                            End If
                            If StartDate1(3).Length = 5 Then
                                t = Mid(StartDate1(3), 1, 2)
                                t1 = Mid(StartDate1(3), 3, 2)
                                t2 = Mid(StartDate1(3), 5, 1)
                                StartDate1(3) = t + ":" + t1 + ":" + "00" + " " + t2 + "M"
                                If StartDate1(3).Contains("P") Then
                                    If t <> "12" Then
                                        t = t + 12

                                    End If
                                    StartDate1(3) = t + ":" + t1 + ":" + "00" + " " + t2 + "M"
                                End If
                            End If

                            '10/14/2013 9:00:00 AM
                            objordets.D_WFAI_JOB_STRTD = StartDate1(0) + " " + StartDate1(3)
                            'update inputr header

                            Debrief_comment_manipulator(objordets)
                            Debrief_Input_Header(objordets)
                            'Debrief_Item(objordets)
                            ' Insert_D_Table(objordets)  'Hari I have made chnges for updating debrief,pls chk it
                            ''insert debrief table
                            ''send response
                            'sendResponse_Ticket(objordets, 7, "WFA_DEBRIEF")
                            'sendResponse_Ticket(objordets, 6, "WFA_INTERFACE")
                        End If
                    End If
                End If
            ElseIf objordets.WFAO_JOBID.Contains("R") Then
                objCPEWFADOProcess.OpenScreen(Tirksess, "DOMCWR")
                If Tirksess.GetString(1).Contains("(DOMCWR)") Then
                    'Tirksess.SendString(2, 9, "          ") ' cntrID

                    Tirksess.SendString(2, 9, objordets.WFAO_CENTER)
                    'Tirksess.SendString(3, 8, "           ")
                    'Tirksess.SendString(2, 9, objordets.WFAO_JOBID)
                    Tirksess.SendString(3, 8, objordets.WFAO_JOBID)
                    Tirksess.SendKeys("@1")
                    System.Windows.Forms.Application.DoEvents()
                    System.Threading.Thread.Sleep(1000)
                    'objCPEWFADOProcess.OpenScreen(Tirksess, "DOCOMP")
                    If Tirksess.GetString(24).Contains("SUCCESSFUL") Then
                        objordets.WFAI_JSTAT = Tirksess.GetString(3, 40, 42)
                        If objordets.WFAI_JSTAT.Contains("PRE") Then
                            objCPEWFADOProcess.OpenScreen(Tirksess, "DOLOG")
                            If Tirksess.GetString(1).Contains("WFADO: WORK REQUEST EVENT LOG (DOLOG)") Then
                                Tirksess.SendString(2, 10, "          ") ' cntrID
                                Tirksess.SendString(2, 10, objordets.WFAO_CENTER)
                                Tirksess.SendString(3, 9, "           ")
                                Tirksess.SendString(3, 9, objordets.WFAO_JOBID)
                                Tirksess.SendKeys("@1")
                                System.Windows.Forms.Application.DoEvents()
                                System.Threading.Thread.Sleep(1000)
                                If Not Tirksess.GetString(12, 2, 13) = objordets.Job_Started_Date Then
                                    If Tirksess.GetString(12, 30, 68).Contains("JOB STAT RETD TO PRE") Then
                                        objordets.Dolog_Comment = Tirksess.GetString(13)
                                        objordets.Job_Started_Date = Tirksess.GetString(12, 2, 13)
                                        'Tirksess.SendKeys("@8")
                                        objCPEWFADOProcess.OpenScreen(Tirksess, "DOCOMP")
                                        If Tirksess.GetString(1).Contains("WFADO: POTS INST COMPLETION (DOCOMP)") Then
                                            Tirksess.SendString(2, 10, "          ") ' cntrID
                                            Tirksess.SendString(2, 10, objordets.WFAO_CENTER)
                                            Tirksess.SendString(5, 9, "           ")
                                            Tirksess.SendString(5, 9, objordets.WFAO_JOBID)
                                            Tirksess.SendKeys("@1")
                                            System.Windows.Forms.Application.DoEvents()
                                            System.Threading.Thread.Sleep(1000)
                                            objordets.D_WFAI_DOCOMP_ITEM = Tirksess.GetString(21, 19, 78).Trim
                                            objordets.D_WFAI_JOB_STRTD = Tirksess.GetString(7, 42, 55)
                                            objordets.Dolog_Comment_Repair_L = Tirksess.GetString(18, 12, 78).Trim
                                            objordets.Dolog_Comment_Repair_E = Tirksess.GetString(20, 19, 78).Trim
                                            objordets.Ticket_Status = "TECH ASSIGNED"
                                            'update input table
                                            Debrief_Input_Header(objordets)
                                            'insert debrief table
                                            Debrief_comment_manipulator(objordets)
                                            Debrief_Item(objordets)
                                            Insert_D_Table(objordets)

                                        End If
                                    End If
                                End If
                            End If


                        ElseIf objordets.WFAI_JSTAT.Contains("DSP") Then
                            objCPEWFADOProcess.OpenScreen(Tirksess, "DOLOG")
                            If Tirksess.GetString(1).Contains("WFADO: WORK REQUEST EVENT LOG (DOLOG)") Then
                                Tirksess.SendString(2, 10, "          ") ' cntrID
                                Tirksess.SendString(2, 10, objordets.WFAO_CENTER)
                                Tirksess.SendString(3, 9, "           ")
                                Tirksess.SendString(3, 9, objordets.WFAO_JOBID)
                                Tirksess.SendKeys("@1")
                                System.Windows.Forms.Application.DoEvents()
                                System.Threading.Thread.Sleep(1000)
                                If Tirksess.GetString(24).Contains("SUCCESSFUL") Then
                                    objordets.Job_Started_Date = Tirksess.GetString(12, 2, 13)
                                    objordets.Ticket_Status = "DISPATCHED"
                                End If
                            End If

                            Debrief_Input_Header(objordets)
                            'update input table JSTAT='DSP' n TS='dsptched'
                            ' Debrief_Input_Header(objordets)
                        ElseIf objordets.WFAI_JSTAT.Contains("CMP") Then
                            objCPEWFADOProcess.OpenScreen(Tirksess, "DOCOMP")
                            Tirksess.SendString(2, 10, "          ") ' cntrID
                            Tirksess.SendString(2, 10, objordets.WFAO_CENTER)
                            Tirksess.SendString(5, 9, "           ")
                            Tirksess.SendString(5, 9, objordets.WFAO_JOBID)
                            Tirksess.SendKeys("@1")
                            If Tirksess.GetString(1).Contains("(DOCOMP)") Then
                                objordets.Dolog_Comment = Tirksess.GetString(18, 12, 80).Trim + "," + Tirksess.GetString(20, 19, 78).Trim + "," + Tirksess.GetString(21, 19, 78).Trim
                                objordets.Ret_Job_Nar = Tirksess.GetString(12, 25, 54)
                                objordets.Dolog_Comment_Repair_L = Tirksess.GetString(18, 12, 80).Trim
                                objordets.Dolog_Comment_Repair_E = Tirksess.GetString(20, 19, 78).Trim
                                objordets.Comments = Tirksess.GetString(13, 11, 80).Trim + Tirksess.GetString(14, 2, 72).Trim
                                objordets.D_WFAI_DOCOMP_ITEM = Tirksess.GetString(21, 19, 21)
                                objordets.Job_Stat = Tirksess.GetString(11, 38, 40)
                                objordets.WFAI_DEBRIEF_COMMENTS = Tirksess.GetString(13, 11, 80).Trim + "," + Tirksess.GetString(14, 2, 73).Trim
                                'Laksmi it is wroking FORMAT in DOCOMP 111513 	0100P
                                'Hari pls chk it now

                                objordets.D_WFAI_JOB_STRTD = Tirksess.GetString(10, 14, 25)
                                Dim StartDate As String
                                Dim StartDate1() As String
                                Dim s, s1, s2 As String
                                Dim t, t1, t2 As String
                                'START DATE CHANGE
                                StartDate1 = Split(objordets.D_WFAI_JOB_STRTD, " ") 'Job Started format
                                If StartDate1(0).Length = 6 Then
                                    s = Mid(StartDate1(0), 1, 2)
                                    s1 = Mid(StartDate1(0), 3, 2)
                                    s2 = Mid(StartDate1(0), 5, 2)
                                    StartDate1(0) = s + "/" + s1 + "/20" + s2
                                End If
                                If StartDate1(1).Length = 5 Then
                                    t = Mid(StartDate1(1), 1, 2)
                                    t1 = Mid(StartDate1(1), 3, 2)
                                    t2 = Mid(StartDate1(1), 5, 1)

                                    StartDate1(1) = t + ":" + t1 + ":" + "00" + " " + t2 + "M"
                                    If StartDate1(1).Contains("P") Then
                                        If t <> "12" Then
                                            t = t + 12

                                        End If
                                        StartDate1(1) = t + ":" + t1 + ":" + "00" + " " + t2 + "M"
                                    End If
                                End If
                                objordets.D_WFAI_JOB_STRTD = StartDate1(0) + " " + StartDate1(1)
                                objordets.Ticket_Status = "COMPLETED"
                                'Tirksess.SendString(2, 10, objordets.WFAO_CENTER) ' cntrID
                                'Tirksess.SendString(3, 9, objordets.WFAO_JOBID)
                                'Tirksess.SendKeys("@1")
                                System.Windows.Forms.Application.DoEvents()
                                System.Threading.Thread.Sleep(1000)
                                '     objordets.Dolog_Comment = Tirksess.GetString(13).Trim
                                'objordets.Job_Started_Date = Tirksess.GetString(12, 2, 13)
                                'objCPEWFADOProcess.OpenScreen(Tirksess, "DOCOMP")
                                'If Tirksess.GetString(1).Contains("WFADO: POTS INST COMPLETION (DOCOMP)") And Tirksess.GetString(24).Contains("SUCCESSFUL") Then
                                '    objordets.D_WFAI_DOCOMP_ITEM = Tirksess.GetString(20, 15, 17)
                                '    objordets.D_WFAI_JOB_STRTD = Tirksess.GetString(7, 42, 55)
                                '    objordets.Ticket_Status = "COMPLETED"
                                'End If

                                'update inputr header

                                Debrief_comment_manipulator(objordets)
                                Debrief_Input_Header(objordets)
                                '  Debrief_Item(objordets)
                                ' Insert_D_Table(objordets)
                                'insert debrief table
                                'send response
                                ' sendResponse_Ticket(objordets, 7, "WFA_DEBRIEF")
                            End If
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            p_objLogger.writenote("Exception: :-" & ex.ToString(), objordets.Task_Id, EventLogEntryType.Error)
        End Try
        Return Nothing
    End Function

    Function Debrief_Insert_Process(ByRef objordets As OrderDetails)
        Try
            Dim objDbutility As New DBUtilities.DBConnect
            objDbutility = SQLDBUtil()
            objDbutility.DB_SERVER_NAME = "CTOMASQL2SQL1\SQL_INSTANCE1,7115"
            Dim objInsert As New Object
            Dim ex1 As Exception = Nothing
            Dim e As Exception
            Dim strInputQuery As String
            Dim objQueryFleHndlr As New FileHandler.INIFileHandler(p_sCPE_NotifierIni)
            Dim irow As New DataSet
            objInsert = Array.CreateInstance(GetType(Object), 10)
            If Not objordets.Task_Id = Nothing Then
                If (objordets.Task_Id.ToString.Length = 0) Then
                    objordets.Task_Id = DBNull.Value.ToString
                End If
            Else
                objordets.Task_Id = DBNull.Value.ToString

            End If
            If Not objordets.D_WFAI_DOCOMP_STATUS = Nothing Then
                If (objordets.D_WFAI_DOCOMP_STATUS.ToString.Length = 0) Then
                    objordets.D_WFAI_DOCOMP_STATUS = DBNull.Value.ToString
                End If
            Else
                objordets.D_WFAI_DOCOMP_STATUS = DBNull.Value.ToString

            End If
            If Not objordets.D_WFAI_DOCOMP_REASON_CODE = Nothing Then
                If (objordets.D_WFAI_DOCOMP_REASON_CODE.ToString.Length = 0) Then
                    objordets.D_WFAI_DOCOMP_REASON_CODE = DBNull.Value.ToString
                End If
            Else
                objordets.D_WFAI_DOCOMP_HOURS = DBNull.Value.ToString

            End If
            If Not objordets.D_WFAI_DOCOMP_HOURS = Nothing Then
                If (objordets.D_WFAI_DOCOMP_HOURS.ToString.Length = 0) Then
                    objordets.D_WFAI_DOCOMP_HOURS = DBNull.Value.ToString
                End If
            Else
                objordets.D_WFAI_DOCOMP_HOURS = DBNull.Value.ToString

            End If
            If Not objordets.D_WFAI_DOCOMP_ITEM = Nothing Then
                If (objordets.D_WFAI_DOCOMP_ITEM.ToString.Length = 0) Then
                    objordets.D_WFAI_DOCOMP_ITEM = DBNull.Value.ToString
                End If
            Else
                objordets.D_WFAI_DOCOMP_ITEM = DBNull.Value.ToString

            End If
            If Not objordets.D_WFAI_DOCOMP_LAB_EXP = Nothing Then
                If (objordets.D_WFAI_DOCOMP_LAB_EXP.ToString.Length = 0) Then
                    objordets.D_WFAI_DOCOMP_LAB_EXP = DBNull.Value.ToString
                End If
            Else
                objordets.D_WFAI_DOCOMP_LAB_EXP = DBNull.Value.ToString

            End If
            If Not objordets.D_WFAI_DOCOMP_5 = Nothing Then
                If (objordets.D_WFAI_DOCOMP_5.ToString.Length = 0) Then
                    objordets.D_WFAI_DOCOMP_5 = DBNull.Value.ToString
                End If
            Else
                objordets.D_WFAI_DOCOMP_5 = DBNull.Value.ToString

            End If
            If Not objordets.D_WFAI_JOB_STRTD = Nothing Then
                If (objordets.D_WFAI_JOB_STRTD.ToString.Length = 0) Then
                    objordets.D_WFAI_JOB_STRTD = DBNull.Value.ToString
                End If
            Else
                objordets.D_WFAI_JOB_STRTD = DBNull.Value.ToString

            End If
            If Not objordets.D_MSG_STATUS = Nothing Then
                If (objordets.D_MSG_STATUS.ToString.Length = 0) Then
                    objordets.D_MSG_STATUS = DBNull.Value.ToString
                End If
            Else
                objordets.D_MSG_STATUS = DBNull.Value.ToString

            End If
            If Not objordets.D_MSG_ERROR = Nothing Then
                If (objordets.D_MSG_ERROR.ToString.Length = 0) Then
                    objordets.D_MSG_ERROR = DBNull.Value.ToString
                End If
            Else
                objordets.D_MSG_ERROR = DBNull.Value.ToString

            End If
            If Not objordets.D_WFAI_DEBRIEF_NUMBER = Nothing Then
                If (objordets.D_WFAI_DEBRIEF_NUMBER.ToString.Length = 0) Then
                    objordets.D_WFAI_DEBRIEF_NUMBER = DBNull.Value.ToString
                End If
            Else
                objordets.D_WFAI_DEBRIEF_NUMBER = DBNull.Value.ToString

            End If
            objInsert.SetValue(objordets.Task_Id, 0)
            objInsert.SetValue(objordets.D_WFAI_DOCOMP_STATUS, 1) 'have to add param
            objInsert.SetValue(objordets.D_WFAI_DOCOMP_REASON_CODE, 2) 'have to add param
            objInsert.SetValue(objordets.D_WFAI_DOCOMP_HOURS, 3)
            objInsert.SetValue(objordets.D_WFAI_DOCOMP_ITEM, 4)
            objInsert.SetValue(objordets.D_WFAI_DOCOMP_LAB_EXP, 5)
            objInsert.SetValue(objordets.D_WFAI_DOCOMP_5, 6)
            objInsert.SetValue(objordets.D_WFAI_JOB_STRTD, 7)
            objInsert.SetValue(objordets.D_MSG_STATUS, 8)
            objInsert.SetValue(objordets.D_MSG_ERROR, 9)
            objInsert.SetValue(objordets.D_WFAI_DEBRIEF_NUMBER, 10)
            strInputQuery = "INSERT INTO [OracleCPE].[dbo].[INPUT_HEADER_STAGE] ([TASK_ID],[WFAI_DOCOMP_STATUS],[WFAI_DOCOMP_REASON_CODE],[WFAI_DOCOMP_HOURS],[WFAI_DOCOMP_ITEM],[WFAI_DOCOMP_LAB_EXP],[WFAI_DOCOMP_5],[WFAI_JOB_STRTD],[MSG_STATUS],[MSG_ERROR],[WFAI_DEBRIEF_NUMBER]) values(?,?,?,?,?,?,?,?,?,?,?)"

            objDbutility.InsertQuery([Global].p_sCPE_NOTIFIERDB, strInputQuery, ex1, objInsert)
            If (ex1 Is Nothing) Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            p_objLogger.writenote("Exception: :-" & ex.ToString(), objordets.Task_Id, EventLogEntryType.Error)
        End Try
    End Function
    Function Docomm_Comment_Update(ByVal Tirksess As AxSmartRumba.AxSmartRumbaControl, ByRef objordets As OrderDetails)
        Try


            Dim objCPEWFADOProcess As New WFADOProcess
            Dim i As Integer
            objCPEWFADOProcess.OpenScreen(Tirksess, "DOCOMM")
            If Tirksess.GetString(1).Contains("WFADO: COMMENTS (DOCOMM)") Then
                Tirksess.SendString(2, 9, "           ")
                Tirksess.SendString(2, 9, objordets.WFAO_CENTER) ' cntrID
                Tirksess.SendString(3, 8, objordets.WFAO_JOBID)
                Tirksess.SendKeys("@1")
                System.Windows.Forms.Application.DoEvents()
                System.Threading.Thread.Sleep(1000)
                If Tirksess.GetString(24).Contains("SUCCESSFUL") Then
                    For i = 14 To 23
                        If Not Tirksess.GetString(i).Length = 0 Then
                            'New Change for SVY JOB's-Sep-04-2015 Hari
                            If objordets.WFAO_JT = "ICPSVY" Then
                                objordets.WFAO_COMMENTS_SUBJECT = objordets.WFAO_COMMENTS_SUBJECT.Replace("sitespoc@centurylink.com", " ")
                                objordets.WFAO_DOCOMM_1 = "sitespoc@centurylink.com  LCON " & objordets.WFAO_DOCOMM_1
                                Tirksess.SendString(i - 1, 11, "                                                                      ")
                                Tirksess.SendString(i - 1, 11, objordets.WFAO_COMMENTS_SUBJECT)
                                Tirksess.SendString(i, 11, objordets.WFAO_DOCOMM_1)
                                Tirksess.SendString(i + 1, 11, objordets.WFAO_DOCOMM_2)
                                Tirksess.SendString(i + 2, 11, objordets.WFAO_DOCOMM_3)
                            Else
                                Tirksess.SendString(i, 11, objordets.WFAO_DOCOMM_1)
                                Tirksess.SendString(i + 1, 11, objordets.WFAO_DOCOMM_2)
                                Tirksess.SendString(i + 2, 11, objordets.WFAO_DOCOMM_3)
                            End If

                            Tirksess.SendString(5, 13, "N")
                            Tirksess.SendKeys("@5")
                            If Tirksess.GetString(24).Contains("UPDATE SUCCESSFUL") Then
                                Exit For
                            Else
                                ' MessageBox.Show("NOT UPDATED")
                            End If
                        End If
                    Next
                End If
            End If
        Catch ex As Exception
            p_objLogger.writenote("Exception: :-" & ex.ToString(), objordets.Task_Id, EventLogEntryType.Error)
        End Try
        Return objordets
    End Function
    Function DoLog_Process(ByVal Tirksess As AxSmartRumba.AxSmartRumbaControl, ByRef objordets As OrderDetails)
        Try
            'Dim objLoginUtility As New Oracle_CPE.LoginUtility
            Dim objCPEWFADOProcess As New WFADOProcess(Tirksess)
            'myForm.SetWFADOScreen("CENTRAL", Tirksess, Nothing)
            'objLoginUtility.LoginWFA("CENTRAL", Tirksess, Nothing)
            objCPEWFADOProcess.moWFADOScreen = Tirksess
            objCPEWFADOProcess.OpenScreen(objCPEWFADOProcess.moWFADOScreen, "DOLOG")
            Tirksess.SendString(2, 10, "           ")
            Tirksess.SendString(2, 10, objordets.WFAO_CENTER) ' cntrID
            'Tirksess.SendString(4, 8, objordets.WFAO_CKTID)
            Tirksess.SendString(3, 9, objordets.WFAO_JOBID)
            Tirksess.SendKeys("@1")
            System.Windows.Forms.Application.DoEvents()
            System.Threading.Thread.Sleep(1000)

            If objordets.WFAI_JSTAT.Equals("PRE") Then


                'Check the database time
                Dim checktime As String = Tirksess.GetString(12, 2, 13)
                'If it does  exist in database 
                'Write function to check the datetime in databse
                If Tirksess.GetString(12, 30, 68).Contains("JOB STAT RETD TO PRE") Then
                    objordets.Dolog_Comment = Tirksess.GetString(13, 30, 61)
                    'Insert SQL DB
                End If

            End If
            objordets.Dolog_Comment = Tirksess.GetString(13, 30, 61)
            Dim GetInputValue() As String
            Dim GetVal As Object
            Dim respon As Integer
            GetVal = Tirksess.GetString(13, 30, 62)
            GetInputValue = Split(GetVal, ",")
            'objordets.D_WFAI_DOCOMP_REASON_CODE = GetInputValue(0)
            'objordets.D_WFAI_DOCOMP_LAB_EXP = GetInputValue(1)
            'objordets.D_WFAI_DOCOMP_ITEM = GetInputValue(2)
            If GetInputValue.Length = 1 Then


                Dim seperate_value() As String
                seperate_value = Split(GetInputValue(0), "-")
                objordets.D_WFAI_DOCOMP_LAB_EXP = seperate_value(0).Trim
                objordets.D_WFAI_DOCOMP_REASON_CODE = seperate_value(1).Trim
                objordets.D_WFAI_DOCOMP_HOURS = "0" + seperate_value(2).Substring(0, 2) + ":" + seperate_value(2).Substring(2, 2)
                'Single Response
                respon = 11

            ElseIf GetInputValue.Length = 2 Then
                Dim seperate_value() As String
                seperate_value = Split(GetInputValue(0), "-")
                objordets.D_WFAI_DOCOMP_LAB_EXP = seperate_value(0).Trim
                objordets.D_WFAI_DOCOMP_REASON_CODE = seperate_value(1).Trim
                objordets.D_WFAI_DOCOMP_HOURS = "0" + seperate_value(2).Substring(0, 2) + ":" + seperate_value(2).Substring(1, 2)
                seperate_value = Split(GetInputValue(1), "-")
                objordets.D_WFAI_DOCOMP_LAB_EXP_E = seperate_value(0).Trim
                objordets.D_WFAI_DOCOMP_REASON_CODE_E = seperate_value(1).Trim
                objordets.D_WFAI_DOCOMP_EXP_E = seperate_value(2).Trim
                'Single Response
                respon = 12

            ElseIf GetInputValue.Length = 3 Then
                Dim seperate_value() As String
                seperate_value = Split(GetInputValue(0), "-")
                objordets.D_WFAI_DOCOMP_LAB_EXP = seperate_value(0).Trim
                objordets.D_WFAI_DOCOMP_REASON_CODE = seperate_value(1).Trim
                objordets.D_WFAI_DOCOMP_HOURS = "0" + seperate_value(2).Substring(0, 2) + ":" + seperate_value(2).Substring(1, 2)
                seperate_value = Split(GetInputValue(1), "-")
                objordets.D_WFAI_DOCOMP_LAB_EXP_E = seperate_value(0).Trim
                objordets.D_WFAI_DOCOMP_REASON_CODE_E = seperate_value(1).Trim
                objordets.D_WFAI_DOCOMP_EXP_E = seperate_value(2).Trim
                If GetInputValue(3).Trim.ToString.Equals("BILL") Then
                    objordets.Expense_ITEM = "CTL BILLABLE EXPENSES"
                ElseIf GetInputValue(3).Trim.ToString.Equals("NBILL") Then
                    objordets.Expense_ITEM = "CTL NON BILLABLE EXPENSES"
                End If
                'Single Response.
                'Return True

                respon = 13
                'Insert Debrief TABle

            ElseIf GetInputValue.Length = 0 Or GetInputValue.Length = 4 Then
                'Error Response
                Return False
            End If

            sendResponse_Ticket(objordets, respon, "WFA_DEBRIEF")
        Catch ex As Exception
            p_objLogger.writenote("Exception: :-" & ex.ToString(), objordets.Task_Id, EventLogEntryType.Error)
        End Try

    End Function
    'Function Debrief_comment_manipulator(ByRef objordets)
    '    'objordets.Dolog_Comment = Tirksess.GetString(13, 30, 61)
    '    Try

    '        Dim GetInputValue() As String
    '        Dim GetVal As String
    '        Dim respon As String


    '        If objordets.WFAO_JOBID.contains("I") Then
    '            GetVal = objordets.Dolog_Comment
    '            'lABOR ONLY
    '            GetInputValue = Split(GetVal, ",")

    '            If GetInputValue.Length = 1 Then
    '                If (validate_Dolog_comment(GetInputValue(0))) Then

    '                    Dim seperate_value() As String
    '                    seperate_value = Split(GetInputValue(0), "-")
    '                    objordets.D_WFAI_DOCOMP_LAB_EXP = seperate_value(0).Trim
    '                    objordets.D_WFAI_DOCOMP_REASON_CODE = seperate_value(1).Trim
    '                    If objordets.D_WFAI_DOCOMP_LAB_EXP.Equals("E") Then
    '                        objordets.D_WFAI_DOCOMP_HOURS = seperate_value(2).ToString.Trim
    '                        If objordets.Dolog_Comment.Contains("NBILL") Then
    '                            objordets.D_WFAI_DOCOMP_ITEM = "CTL NON BILLABLE EXPENSES"
    '                        Else
    '                            objordets.D_WFAI_DOCOMP_ITEM = "CTL BILLABLE EXPENSES"
    '                        End If

    '                    ElseIf objordets.D_WFAI_DOCOMP_LAB_EXP.Equals("L") Then
    '                        objordets.D_WFAI_DOCOMP_HOURS = "0" + seperate_value(2).Substring(0, 2) + ":" + seperate_value(2).Substring(2, 2)
    '                    End If

    '                    'Inseret into internal Database
    '                    Debrief_Item(objordets)
    '                    Insert_D_Table(objordets)
    '                    'Sending Positive response IF JOB STAT +CMP
    '                    If objordets.WFAI_JSTAT = "CMP" Then
    '                        sendResponse_Ticket(objordets, 7, "WFA_DEBRIEF")
    '                        sendResponse_Ticket(objordets, 6, "WFA_INTERFACE")
    '                    End If
    '                Else
    '                    'Wrong DebriefResponse IF JOB STAT IS CMP
    '                    sendResponse_Ticket(objordets, -6, "WFA_INTERFACE")
    '                End If


    '            ElseIf GetInputValue.Length = 2 Then
    '                'Labor and Expense withou t BILL
    '                Dim seperate_value() As String
    '                For i As Integer = 0 To GetInputValue.Length - 1
    '                    If (validate_Dolog_comment(GetInputValue(i))) Then


    '                        seperate_value = Split(GetInputValue(i), "-")
    '                        If seperate_value.Length = 3 Then
    '                            objordets.D_WFAI_DOCOMP_LAB_EXP = seperate_value(0).Trim
    '                            objordets.D_WFAI_DOCOMP_REASON_CODE = seperate_value(1).Trim
    '                            If objordets.D_WFAI_DOCOMP_LAB_EXP.Equals("E") Then
    '                                objordets.D_WFAI_DOCOMP_HOURS = seperate_value(2).ToString.Trim
    '                                If objordets.Dolog_Comment.Contains("NBILL") Then
    '                                    objordets.D_WFAI_DOCOMP_ITEM = "CTL NON BILLABLE EXPENSES"
    '                                Else
    '                                    objordets.D_WFAI_DOCOMP_ITEM = "CTL BILLABLE EXPENSES"
    '                                End If
    '                            ElseIf objordets.D_WFAI_DOCOMP_LAB_EXP.Equals("L") Then
    '                                objordets.D_WFAI_DOCOMP_HOURS = "0" + seperate_value(2).Substring(0, 2) + ":" + seperate_value(2).Substring(2, 2)
    '                            End If
    '                            Insert_D_Table(objordets)
    '                            respon = "COMPLETED"

    '                        End If
    '                    Else
    '                        respon = "INVALID"
    '                        'Wrong Debrief

    '                    End If
    '                Next
    '                'Sending Positive response
    '                If objordets.WFAI_JSTAT = "CMP" And respon = "COMPLETED" Then
    '                    sendResponse_Ticket(objordets, 7, "WFA_DEBRIEF")
    '                    sendResponse_Ticket(objordets, 6, "WFA_INTERFACE")
    '                ElseIf objordets.WFAI_JSTAT = "CMP" And respon = "INVALID" Then
    '                    sendResponse_Ticket(objordets, -6, "WFA_INTERFACE")
    '                End If
    '                objordets.Debrief_Entries = "L+E"
    '            ElseIf GetInputValue.Length = 3 Then
    '                'Labor and Expense And BILL



    '                Dim seperate_value() As String
    '                Dim FLAG As Boolean = False
    '                For i As Integer = 0 To GetInputValue.Length - 1
    '                    If GetInputValue(i).Contains("BILL") Then

    '                        FLAG = True
    '                    ElseIf GetInputValue(i).Contains("NBILL") Then

    '                        FLAG = True
    '                    End If
    '                Next
    '                Dim count As Integer
    '                If FLAG = True Then
    '                    count = GetInputValue.Length - 1
    '                Else
    '                    count = GetInputValue.Length
    '                End If
    '                For i As Integer = 0 To count - 1
    '                    If (validate_Dolog_comment(GetInputValue(i))) Then


    '                        seperate_value = Split(GetInputValue(i), "-")
    '                        If seperate_value.Length = 3 Then
    '                            objordets.D_WFAI_DOCOMP_LAB_EXP = seperate_value(0).Trim
    '                            objordets.D_WFAI_DOCOMP_REASON_CODE = seperate_value(1).Trim
    '                            If objordets.D_WFAI_DOCOMP_LAB_EXP.Equals("E") Then
    '                                objordets.D_WFAI_DOCOMP_HOURS = seperate_value(2).ToString.Trim
    '                                If objordets.Dolog_Comment.Contains("NBILL") Then
    '                                    objordets.D_WFAI_DOCOMP_ITEM = "CTL NON BILLABLE EXPENSES"
    '                                Else
    '                                    objordets.D_WFAI_DOCOMP_ITEM = "CTL BILLABLE EXPENSES"
    '                                End If
    '                            ElseIf objordets.D_WFAI_DOCOMP_LAB_EXP.Equals("L") Then
    '                                objordets.D_WFAI_DOCOMP_HOURS = "0" + seperate_value(2).Substring(0, 2) + ":" + seperate_value(2).Substring(2, 2)
    '                            End If

    '                            'Insert into into database
    '                            Insert_D_Table(objordets)
    '                            'Sending Positive response
    '                            respon = "COMPLETED"
    '                        End If
    '                    Else
    '                        'Worng Debrief
    '                        respon = "INVALID"
    '                    End If

    '                Next
    '                If objordets.WFAI_JSTAT = "CMP" And respon = "COMPLETED" Then
    '                    sendResponse_Ticket(objordets, 7, "WFA_DEBRIEF")
    '                    sendResponse_Ticket(objordets, 6, "WFA_WFA_INTERFACE")
    '                ElseIf objordets.WFAI_JSTAT = "CMP" And respon = "INVALID" Then
    '                    sendResponse_Ticket(objordets, -6, "WFA_INTERFACE")
    '                End If



    '                respon = 13s
    '                'Insert Debrief TABle
    '                objordets.Debrief_Entries = "L+E+B"
    '            ElseIf (GetInputValue.Length = 0 Or GetInputValue.Length = 4) And objordets.WFAI_JSTAT = "CMP" Then
    '                'Error Response
    '                objordets.Debrief_Entries = "INVALID"

    '                sendResponse_Ticket(objordets, -6, "WFA_INTERFACE")
    '            End If
    '        ElseIf objordets.WFAO_JOBID.contains("R") Then
    '            If objordets.Dolog_Comment_Repair_L.trim.length > 0 Then
    '                GetInputValue = Split(objordets.Dolog_Comment_Repair_L, ",")
    '                For i As Integer = 0 To GetInputValue.Length - 1
    '                    If (validate_Dolog_comment(GetInputValue(i))) Then

    '                        Dim seperate_value() As String
    '                        seperate_value = Split(GetInputValue(i), "-")
    '                        If seperate_value.Length = 3 Then
    '                            objordets.D_WFAI_DOCOMP_LAB_EXP = seperate_value(0).Trim
    '                            objordets.D_WFAI_DOCOMP_REASON_CODE = seperate_value(1).Trim
    '                            If objordets.D_WFAI_DOCOMP_LAB_EXP.Equals("E") Then
    '                                objordets.D_WFAI_DOCOMP_HOURS = seperate_value(2).ToString.Trim
    '                                If objordets.Dolog_Comment.Contains("NBILL") Then
    '                                    objordets.D_WFAI_DOCOMP_ITEM = "CTL NON BILLABLE EXPENSES"
    '                                Else
    '                                    objordets.D_WFAI_DOCOMP_ITEM = "CTL BILLABLE EXPENSES"
    '                                End If
    '                            ElseIf objordets.D_WFAI_DOCOMP_LAB_EXP.Equals("L") Then
    '                                objordets.D_WFAI_DOCOMP_HOURS = "0" + seperate_value(2).Substring(0, 2) + ":" + seperate_value(2).Substring(2, 2)
    '                            End If
    '                            Insert_D_Table(objordets)
    '                            'Sending Positive response
    '                            'sendResponse_Ticket(objordets, 7, "WFA_DEBRIEF")
    '                            ' sendResponse_Ticket(objordets, 6, "WFA_WFA_INTERFACE")
    '                            respon = "COMPLETED"
    '                        End If
    '                    Else
    '                        respon = "INVALID"
    '                    End If

    '                Next
    '            Else
    '                respon = "INVALID"

    '            End If
    '            Dim flag As Boolean = False
    '            If objordets.Dolog_Comment_Repair_E.trim.length > 0 And (objordets.Dolog_Comment_Repair_E.contains(",") Or objordets.Dolog_Comment_Repair_E.contains("-")) Then
    '                GetInputValue = Split(objordets.Dolog_Comment_Repair_E, ",")
    '                For i As Integer = 0 To GetInputValue.Length - 1
    '                    If GetInputValue(i).Contains("BILL") Then
    '                        objordets.D_WFAI_DOCOMP_ITEM = "CTL BILLABLE EXPENSES"
    '                        flag = True
    '                    ElseIf GetInputValue(i).Contains("NBILL") Then
    '                        objordets.D_WFAI_DOCOMP_ITEM = "CTL NONBILLABLE EXPENSES"
    '                        flag = True
    '                    End If
    '                Next
    '                Dim count As Integer
    '                If flag = True Then
    '                    count = GetInputValue.Length - 1
    '                Else
    '                    count = GetInputValue.Length
    '                End If
    '                For i As Integer = 0 To count - 1
    '                    If (validate_Dolog_comment(GetInputValue(i))) Then


    '                        Dim seperate_value() As String
    '                        seperate_value = Split(GetInputValue(i), "-")
    '                        If seperate_value.Length = 3 Then
    '                            objordets.D_WFAI_DOCOMP_LAB_EXP = seperate_value(0).Trim
    '                            objordets.D_WFAI_DOCOMP_REASON_CODE = seperate_value(1).Trim
    '                            If objordets.D_WFAI_DOCOMP_LAB_EXP.Equals("E") Then
    '                                objordets.D_WFAI_DOCOMP_HOURS = seperate_value(2).ToString.Trim
    '                                If objordets.Dolog_Comment.Contains("NBILL") Then
    '                                    objordets.D_WFAI_DOCOMP_ITEM = "CTL NON BILLABLE EXPENSES"
    '                                Else
    '                                    objordets.D_WFAI_DOCOMP_ITEM = "CTL BILLABLE EXPENSES"
    '                                End If
    '                            ElseIf objordets.D_WFAI_DOCOMP_LAB_EXP.Equals("L") Then
    '                                objordets.D_WFAI_DOCOMP_HOURS = "0" + seperate_value(2).Substring(0, 2) + ":" + seperate_value(2).Substring(2, 2)
    '                            End If
    '                            If Insert_D_Table(objordets) Then
    '                                respon = "COMPLETED"
    '                            End If
    '                            'Sending Positive response


    '                        End If

    '                    Else
    '                        respon = "INVALID"
    '                    End If
    '                Next


    '            Else
    '                If objordets.WFAI_JSTAT = "CMP" And respon = "COMPLETED" Then
    '                    sendResponse_Ticket(objordets, 7, "WFA_DEBRIEF")
    '                    sendResponse_Ticket(objordets, 6, "WFA_INTERFACE")
    '                ElseIf objordets.WFAI_JSTAT = "CMP" And respon = "INVALID" Then
    '                    sendResponse_Ticket(objordets, -6, "WFA_INTERFACE")
    '                End If
    '            End If
    '        End If

    '        Return objordets
    '    Catch ex As Exception

    '    End Try

    'End Function
    Function Debrief_comment_manipulator(ByRef objordets)
        'objordets.Dolog_Comment = Tirksess.GetString(13, 30, 61)
        Try

            Dim GetInputValue() As String
            Dim GetVal As String
            Dim respon As String


            If objordets.WFAO_JOBID.contains("I") Then
                GetVal = objordets.Dolog_Comment
                'lABOR ONLY
                GetInputValue = Split(GetVal, ",")

                If GetInputValue.Length = 1 Then
                    If (validate_Dolog_comment(GetInputValue(0))) Then

                        Dim seperate_value() As String
                        seperate_value = Split(GetInputValue(0), "-")
                        objordets.D_WFAI_DOCOMP_LAB_EXP = seperate_value(0).Trim
                        objordets.D_WFAI_DOCOMP_REASON_CODE = seperate_value(1).Trim
                        If objordets.D_WFAI_DOCOMP_LAB_EXP.Equals("E") Then
                            objordets.D_WFAI_DOCOMP_HOURS = seperate_value(2).ToString.Trim
                            If objordets.Dolog_Comment.Contains("NBILL") Then
                                objordets.D_WFAI_DOCOMP_ITEM = "CTL NON BILLABLE EXPENSES"
                            Else
                                objordets.D_WFAI_DOCOMP_ITEM = "CTL BILLABLE EXPENSES"
                            End If

                        ElseIf objordets.D_WFAI_DOCOMP_LAB_EXP.Equals("L") Then
                            If seperate_value(2).Substring(3, 2) > 60 Then
                                Dim D_hours As Integer
                                Dim D_minutes As Integer
                                D_minutes = seperate_value(2).Substring(3, 2) - 60
                                D_hours = seperate_value(2).Substring(0, 2) + 1
                                seperate_value(2) = D_hours + D_minutes
                            End If

                            objordets.D_WFAI_DOCOMP_HOURS = "0" + seperate_value(2).Substring(0, 2) + ":" + seperate_value(2).Substring(2, 2)
                        End If

                        'Inseret into internal Database
                        Debrief_Item(objordets)
                        Insert_D_Table(objordets)
                        'Sending Positive response IF JOB STAT +CMP
                        respon = "COMPLETED"
                    Else
                        'Wrong DebriefResponse IF JOB STAT IS CMP
                        respon = "INVALID"
                    End If


                ElseIf GetInputValue.Length = 2 Then
                    'Labor and Expense withou t BILL
                    Dim seperate_value() As String
                    For i As Integer = 0 To GetInputValue.Length - 1
                        If (validate_Dolog_comment(GetInputValue(i))) Then


                            seperate_value = Split(GetInputValue(i), "-")
                            If seperate_value.Length = 3 Then
                                objordets.D_WFAI_DOCOMP_LAB_EXP = seperate_value(0).Trim
                                objordets.D_WFAI_DOCOMP_REASON_CODE = seperate_value(1).Trim
                                If objordets.D_WFAI_DOCOMP_LAB_EXP.Equals("E") Then
                                    objordets.D_WFAI_DOCOMP_HOURS = seperate_value(2).ToString.Trim
                                    If objordets.Dolog_Comment.Contains("NBILL") Then
                                        objordets.D_WFAI_DOCOMP_ITEM = "CTL NON BILLABLE EXPENSES"
                                    Else
                                        objordets.D_WFAI_DOCOMP_ITEM = "CTL BILLABLE EXPENSES"
                                    End If
                                ElseIf objordets.D_WFAI_DOCOMP_LAB_EXP.Equals("L") Then
                                    If seperate_value(2).Substring(3, 2) > 60 Then
                                        Dim D_hours As Integer
                                        Dim D_minutes As Integer
                                        D_minutes = seperate_value(2).Substring(3, 2) - 60
                                        D_hours = seperate_value(2).Substring(0, 2) + 1
                                        seperate_value(2) = D_hours + D_minutes
                                    End If

                                    objordets.D_WFAI_DOCOMP_HOURS = "0" + seperate_value(2).Substring(0, 2) + ":" + seperate_value(2).Substring(2, 2)
                                End If
                                Insert_D_Table(objordets)
                                respon = "COMPLETED"

                            End If
                        Else
                            respon = "INVALID"
                            'Wrong Debrief

                        End If
                    Next
                    'Sending Positive response
                    'If objordets.WFAI_JSTAT = "CMP" And respon = "COMPLETED" Then
                    '    sendResponse_Ticket(objordets, 7, "WFA_DEBRIEF")
                    '    sendResponse_Ticket(objordets, 6, "WFA_INTERFACE")
                    'ElseIf objordets.WFAI_JSTAT = "CMP" And respon = "INVALID" Then
                    '    sendResponse_Ticket(objordets, -6, "WFA_INTERFACE")
                    'End If
                    objordets.Debrief_Entries = "L+E"
                ElseIf GetInputValue.Length = 3 Then
                    'Labor and Expense And BILL



                    Dim seperate_value() As String
                    Dim FLAG As Boolean = False
                    For i As Integer = 0 To GetInputValue.Length - 1
                        If GetInputValue(i).Contains("BILL") Then

                            FLAG = True
                        ElseIf GetInputValue(i).Contains("NBILL") Then

                            FLAG = True
                        End If
                    Next
                    Dim count As Integer
                    If FLAG = True Then
                        count = GetInputValue.Length - 1
                    Else
                        count = GetInputValue.Length
                    End If
                    For i As Integer = 0 To count - 1
                        If (validate_Dolog_comment(GetInputValue(i))) Then


                            seperate_value = Split(GetInputValue(i), "-")
                            If seperate_value.Length = 3 Then
                                objordets.D_WFAI_DOCOMP_LAB_EXP = seperate_value(0).Trim
                                objordets.D_WFAI_DOCOMP_REASON_CODE = seperate_value(1).Trim
                                If objordets.D_WFAI_DOCOMP_LAB_EXP.Equals("E") Then
                                    objordets.D_WFAI_DOCOMP_HOURS = seperate_value(2).ToString.Trim
                                    If objordets.Dolog_Comment.Contains("NBILL") Then
                                        objordets.D_WFAI_DOCOMP_ITEM = "CTL NON BILLABLE EXPENSES"
                                    Else
                                        objordets.D_WFAI_DOCOMP_ITEM = "CTL BILLABLE EXPENSES"
                                    End If
                                ElseIf objordets.D_WFAI_DOCOMP_LAB_EXP.Equals("L") Then
                                    If seperate_value(2).Substring(3, 2) > 60 Then
                                        Dim D_hours As Integer
                                        Dim D_minutes As Integer
                                        D_minutes = seperate_value(2).Substring(3, 2) - 60
                                        D_hours = seperate_value(2).Substring(0, 2) + 1
                                        seperate_value(2) = D_hours + D_minutes
                                    End If

                                    objordets.D_WFAI_DOCOMP_HOURS = "0" + seperate_value(2).Substring(0, 2) + ":" + seperate_value(2).Substring(2, 2)
                                End If

                                'Insert into into database
                                Insert_D_Table(objordets)
                                'Sending Positive response
                                respon = "COMPLETED"
                            End If
                        Else
                            'Worng Debrief
                            respon = "INVALID"
                        End If

                    Next
                    'If objordets.WFAI_JSTAT = "CMP" And respon = "COMPLETED" Then
                    '    sendResponse_Ticket(objordets, 7, "WFA_DEBRIEF")
                    '    sendResponse_Ticket(objordets, 6, "WFA_WFA_INTERFACE")
                    'ElseIf objordets.WFAI_JSTAT = "CMP" And respon = "INVALID" Then
                    '    sendResponse_Ticket(objordets, -6, "WFA_INTERFACE")
                    'End If



                    respon = 13
                    'Insert Debrief TABle
                    objordets.Debrief_Entries = "L+E+B"
                ElseIf (GetInputValue.Length = 0 Or GetInputValue.Length = 4) And objordets.WFAI_JSTAT = "CMP" Then
                    'Error Response
                    objordets.Debrief_Entries = "INVALID"
                    respon = "INVALID"
                    ' sendResponse_Ticket(objordets, -6, "WFA_INTERFACE")
                End If
            ElseIf objordets.WFAO_JOBID.contains("R") Then
                If objordets.Dolog_Comment_Repair_L.trim.length > 0 Then
                    GetInputValue = Split(objordets.Dolog_Comment_Repair_L, ",")
                    For i As Integer = 0 To GetInputValue.Length - 1
                        If (validate_Dolog_comment(GetInputValue(i))) Then

                            Dim seperate_value() As String
                            seperate_value = Split(GetInputValue(i), "-")
                            If seperate_value.Length = 3 Then
                                objordets.D_WFAI_DOCOMP_LAB_EXP = seperate_value(0).Trim
                                objordets.D_WFAI_DOCOMP_REASON_CODE = seperate_value(1).Trim
                                If objordets.D_WFAI_DOCOMP_LAB_EXP.Equals("E") Then
                                    objordets.D_WFAI_DOCOMP_HOURS = seperate_value(2).ToString.Trim
                                    If objordets.Dolog_Comment.Contains("NBILL") Then
                                        objordets.D_WFAI_DOCOMP_ITEM = "CTL NON BILLABLE EXPENSES"
                                    Else
                                        objordets.D_WFAI_DOCOMP_ITEM = "CTL BILLABLE EXPENSES"
                                    End If
                                ElseIf objordets.D_WFAI_DOCOMP_LAB_EXP.Equals("L") Then
                                    If seperate_value(2).Substring(3, 2) > 60 Then
                                        Dim D_hours As Integer
                                        Dim D_minutes As Integer
                                        D_minutes = seperate_value(2).Substring(3, 2) - 60
                                        D_hours = seperate_value(2).Substring(0, 2) + 1
                                        seperate_value(2) = D_hours + D_minutes
                                    End If
                                    objordets.D_WFAI_DOCOMP_HOURS = "0" + seperate_value(2).Substring(0, 2) + ":" + seperate_value(2).Substring(2, 2)
                                End If
                                Insert_D_Table(objordets)
                                'Sending Positive response
                                'sendResponse_Ticket(objordets, 7, "WFA_DEBRIEF")
                                ' sendResponse_Ticket(objordets, 6, "WFA_WFA_INTERFACE")
                                respon = "COMPLETED"
                            End If
                        Else
                            respon = "INVALID_R"
                        End If

                    Next
                Else
                    respon = "INVALID_R"

                End If
                Dim flag As Boolean = False
                If objordets.Dolog_Comment_Repair_E.trim.length > 0 And (objordets.Dolog_Comment_Repair_E.contains(",") Or objordets.Dolog_Comment_Repair_E.contains("-")) Then
                    GetInputValue = Split(objordets.Dolog_Comment_Repair_E, ",")
                    For i As Integer = 0 To GetInputValue.Length - 1
                        If GetInputValue(i).Contains("BILL") Then
                            objordets.D_WFAI_DOCOMP_ITEM = "CTL BILLABLE EXPENSES"
                            flag = True
                        ElseIf GetInputValue(i).Contains("NBILL") Then
                            objordets.D_WFAI_DOCOMP_ITEM = "CTL NONBILLABLE EXPENSES"
                            flag = True
                        End If
                    Next
                    Dim count As Integer
                    If flag = True Then
                        count = GetInputValue.Length - 1
                    Else
                        count = GetInputValue.Length
                    End If
                    For i As Integer = 0 To count - 1
                        If (validate_Dolog_comment(GetInputValue(i))) Then


                            Dim seperate_value() As String
                            seperate_value = Split(GetInputValue(i), "-")
                            If seperate_value.Length = 3 Then
                                objordets.D_WFAI_DOCOMP_LAB_EXP = seperate_value(0).Trim
                                objordets.D_WFAI_DOCOMP_REASON_CODE = seperate_value(1).Trim
                                If objordets.D_WFAI_DOCOMP_LAB_EXP.Equals("E") Then
                                    objordets.D_WFAI_DOCOMP_HOURS = seperate_value(2).ToString.Trim
                                    If objordets.Dolog_Comment.Contains("NBILL") Then
                                        objordets.D_WFAI_DOCOMP_ITEM = "CTL NON BILLABLE EXPENSES"
                                    Else
                                        objordets.D_WFAI_DOCOMP_ITEM = "CTL BILLABLE EXPENSES"
                                    End If
                                ElseIf objordets.D_WFAI_DOCOMP_LAB_EXP.Equals("L") Then

                                    If seperate_value(2).Substring(3, 2) > 60 Then
                                        Dim D_hours As Integer
                                        Dim D_minutes As Integer
                                        D_minutes = seperate_value(2).Substring(3, 2) - 60
                                        D_hours = seperate_value(2).Substring(0, 2) + 1
                                        seperate_value(2) = D_hours + D_minutes
                                    End If
                                    objordets.D_WFAI_DOCOMP_HOURS = "0" + seperate_value(2).Substring(0, 2) + ":" + seperate_value(2).Substring(2, 2)
                                End If
                                If Insert_D_Table(objordets) Then
                                    respon = "COMPLETED"
                                End If
                                'Sending Positive response


                            End If

                        Else
                            respon = "INVALID EXPENSE"
                        End If
                    Next


                Else
                    respon = "INVALID EXPENSE"
                End If
            End If
            If objordets.WFAI_JSTAT = "CMP" And respon = "COMPLETED" Then
                sendResponse_Ticket(objordets, 7, "WFA_DEBRIEF")
                sendResponse_Ticket(objordets, 6, "WFA_INTERFACE")
            ElseIf objordets.WFAI_JSTAT = "CMP" And respon = "INVALID" Then
                sendResponse_Ticket(objordets, -6, "WFA_INTERFACE")
            End If
            Return objordets
        Catch ex As Exception
            p_objLogger.writenote("Exception: :-" & ex.ToString(), objordets.Task_Id, EventLogEntryType.Error)
        End Try

    End Function
    Function validate_Dolog_comment(ByVal comments As String) As Boolean
        Try
            'Validate based on L or E and Final letters are Numerical


            Dim seperate_value() As String
            seperate_value = Split(comments, "-")
            If seperate_value.Length = 3 Then
                If seperate_value(0).Trim = "L" Or seperate_value(0).Trim = "E" Then
                    If IsNumeric(seperate_value(2)) And seperate_value(2).Length = 4 Then
                        Return True
                    Else
                        Return False
                    End If
                End If
            End If

        Catch ex As Exception
            p_objLogger.writenote("Exception: :-" & ex.ToString(), objordets.Task_Id, EventLogEntryType.Error)
        End Try
    End Function
    Function Docomp_Process(ByVal Tirksess As AxSmartRumba.AxSmartRumbaControl)
        Try
            Dim objInsert As Object = Nothing
            objInsert = Array.CreateInstance(GetType(Object), 13)
            'Dim StroradbCmp As String = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=cpet2dbsg.dev.qintra.com)(PORT=1524)))(CONNECT_DATA=(SID=CPET2)));User Id=xxcpewfa;Password=xxcpewfa_0813;"
            'Dim conCmp As New OracleConnection(StroradbCmp)
            'Dim oadapter As OracleDataAdapter
            'Dim oreader As OracleDataReader
            Dim Docomp_ds As New DataSet
            Dim Update_ds As New DataSet
            Dim ex As New Exception
            'Dim StrSelectQuery As String
            Dim StrInsertQuery As String
            Dim objCPEWFADOProcess As New WFADOProcess(Tirksess)
            Dim objDbutility As New DBUtilities.DBConnect
            objDbutility = SQLDBUtil()
            Dim objLoginUtility As New Oracle_CPE.LoginUtility
            ' conCmp.Open()
            Dim StrSelectQuery As String = "Select * from [OracleCPE].[dbo].[INPUT_HEADER_STAGE] where [TICKET_STATUS]='TECH ASSIGNED' or [TICKET_STATUS]='DISPATCHED'  or [TICKET_STATUS]='UPDATED'"
            Docomp_ds = objDbutility.SelectQuery([Global].p_sCPE_NOTIFIERDB, StrSelectQuery, ex, Nothing)

            Dim i As Integer = 0
            If Docomp_ds.Tables(0).Rows.Count > 0 Then
                For i = 0 To Docomp_ds.Tables(0).Rows.Count - 1
                    Dim Objordets As New OrderDetails
                    Objordets.Task_Id = Docomp_ds.Tables(0).Rows(i)(0).ToString()
                    Objordets.Incident_Id = Docomp_ds.Tables(0).Rows(i)(1).ToString()
                    Objordets.Task_Number = Docomp_ds.Tables(0).Rows(i)(2).ToString()
                    Objordets.Incident_Number = Docomp_ds.Tables(0).Rows(i)(3).ToString()
                    Objordets.WFAO_CENTER = Docomp_ds.Tables(0).Rows(i)(4).ToString()
                    Objordets.WFAO_JOBID = Docomp_ds.Tables(0).Rows(i)(5).ToString()
                    Objordets.WFAI_JSTAT = Docomp_ds.Tables(0).Rows(i)(6).ToString()
                    Objordets.WFAO_JT = Docomp_ds.Tables(0).Rows(i)(7).ToString()
                    Objordets.WFAO_TASK_PRIORITY = Docomp_ds.Tables(0).Rows(i)(8).ToString()
                    Objordets.WFAO_SKILLS = Docomp_ds.Tables(0).Rows(i)(9).ToString()
                    Objordets.WFAO_CKTID = Docomp_ds.Tables(0).Rows(i)(10).ToString()
                    Objordets.WFAO_POM = Docomp_ds.Tables(0).Rows(i)(11).ToString()
                    Objordets.WFAO_PON = Docomp_ds.Tables(0).Rows(i)(12).ToString()
                    Objordets.WFAO_BILLNAME = Docomp_ds.Tables(0).Rows(i)(13).ToString()
                    Objordets.WFAO_BILLNAME = Objordets.WFAO_BILLNAME.Substring(0, 30)
                    Objordets.WFAO_TELEPHONE = Docomp_ds.Tables(0).Rows(i)(14).ToString()
                    Objordets.WFAO_WC = Docomp_ds.Tables(0).Rows(i)(15).ToString()
                    Objordets.WFAO_RTE = Docomp_ds.Tables(0).Rows(i)(16).ToString()
                    Objordets.WFAO_DAA = Docomp_ds.Tables(0).Rows(i)(17).ToString()
                    Objordets.WFAO_AA = Docomp_ds.Tables(0).Rows(i)(18).ToString()
                    Objordets.WFAO_ACT = Docomp_ds.Tables(0).Rows(i)(19).ToString()
                    Objordets.WFAO_CKLNAME = Docomp_ds.Tables(0).Rows(i)(20).ToString()
                    Objordets.WFAO_CKLNAME = Objordets.WFAO_CKLNAME.Substring(0, 30)
                    Objordets.WFAO_CKLADDR = Docomp_ds.Tables(0).Rows(i)(21).ToString()
                    Objordets.WFAO_LOC_CITY = Docomp_ds.Tables(0).Rows(i)(22).ToString()
                    Objordets.WFAO_LOC_STATE = Docomp_ds.Tables(0).Rows(i)(23).ToString()
                    Objordets.WFAO_COMM = Docomp_ds.Tables(0).Rows(i)(24).ToString()
                    Objordets.WFAO_START_DATE = Docomp_ds.Tables(0).Rows(i)(25).ToString()
                    Objordets.WFAO_ACC = Docomp_ds.Tables(0).Rows(i)(26).ToString()
                    Objordets.WFAO_A = Docomp_ds.Tables(0).Rows(i)(27).ToString()
                    Objordets.WFAO_B = Docomp_ds.Tables(0).Rows(i)(28).ToString()
                    Objordets.WFAO_DD = Docomp_ds.Tables(0).Rows(i)(29).ToString()
                    Objordets.WFAO_PRC = Docomp_ds.Tables(0).Rows(i)(30).ToString()
                    Objordets.WFAO_TPRC = Docomp_ds.Tables(0).Rows(i)(31).ToString()
                    Objordets.WFAO_ORD_ORIG = Docomp_ds.Tables(0).Rows(i)(32).ToString()
                    Objordets.WFAO_SVY = Docomp_ds.Tables(0).Rows(i)(33).ToString()
                    Objordets.WFAO_PST = Docomp_ds.Tables(0).Rows(i)(34).ToString()
                    Objordets.WFAO_COMMENTS_SUBJECT = Docomp_ds.Tables(0).Rows(i)(35).ToString()
                    Objordets.WFAO_COMMENTS_URGENCY = Docomp_ds.Tables(0).Rows(i)(36).ToString()
                    Objordets.WFAO_JOBPRI = Docomp_ds.Tables(0).Rows(i)(37).ToString()
                    Objordets.WFAO_FACILITY_LABEL = Docomp_ds.Tables(0).Rows(i)(38).ToString()
                    Objordets.WFAO_F1 = Docomp_ds.Tables(0).Rows(i)(39).ToString()
                    Objordets.WFAO_PR = Docomp_ds.Tables(0).Rows(i)(40).ToString()
                    Objordets.WFAO_JOB = Docomp_ds.Tables(0).Rows(i)(41).ToString()
                    Objordets.WFAO_SCRATCHPAD_TASK_DESC = Docomp_ds.Tables(0).Rows(i)(42).ToString()
                    Objordets.WFAO_DOCOMM_1 = Docomp_ds.Tables(0).Rows(i)(43).ToString()
                    Objordets.WFAO_DOCOMM_2 = Docomp_ds.Tables(0).Rows(i)(44).ToString()
                    Objordets.WFAO_DOCOMM_3 = Docomp_ds.Tables(0).Rows(i)(45).ToString()
                    Objordets.WFAO_DOCOMM_4 = Docomp_ds.Tables(0).Rows(i)(46).ToString()
                    Objordets.WFAO_DOCOMM_5 = Docomp_ds.Tables(0).Rows(i)(47).ToString()
                    Objordets.WFAO_DOCOMM_6 = Docomp_ds.Tables(0).Rows(i)(48).ToString()
                    Objordets.WFAO_DOCOMM_7 = Docomp_ds.Tables(0).Rows(i)(49).ToString()
                    Objordets.WFAI_DEBRIEF_COMMENTS = Docomp_ds.Tables(0).Rows(i)(50).ToString()
                    'objordets.sWFAI_JOB_STRD = Docomp_ds.Tables(0).Rows(i)(46).ToString()
                    Objordets.WFAI_JOB_RETURNED = Docomp_ds.Tables(0).Rows(i)(51).ToString()
                    Objordets.MSG_INS_UPDATE_CANCEL = Docomp_ds.Tables(0).Rows(i)(52).ToString()
                    Objordets.MSG_STATUS = Docomp_ds.Tables(0).Rows(i)(53).ToString()
                    Objordets.MSG_ERROR = Docomp_ds.Tables(0).Rows(i)(54).ToString()
                    Objordets.EXCEPTION_INFO = Docomp_ds.Tables(0).Rows(i)(55).ToString()
                    Objordets.DEBRIEF_COMMENT_HISTORY = Docomp_ds.Tables(0).Rows(i)(56).ToString()
                    Objordets.PREV_WFAI_JSTAT = Docomp_ds.Tables(0).Rows(i)(57).ToString()
                    Objordets.TASK_CREATED_BY = Docomp_ds.Tables(0).Rows(i)(58).ToString()
                    Objordets.SR_CREATED_BY = Docomp_ds.Tables(0).Rows(i)(59).ToString()
                    Objordets.CREATED_BY = Docomp_ds.Tables(0).Rows(i)(60).ToString()
                    Objordets.CREATION_DATE = Docomp_ds.Tables(0).Rows(i)(61).ToString()
                    Objordets.LAST_UPDATED_BY = Docomp_ds.Tables(0).Rows(i)(62).ToString()
                    Objordets.LAST_UPDATE_DATE = Docomp_ds.Tables(0).Rows(i)(63).ToString()
                    Objordets.LAST_UPDATE_LOGIN = Docomp_ds.Tables(0).Rows(i)(64).ToString()
                    Objordets.Job_Started_Date = Docomp_ds.Tables(0).Rows(i)(78).ToString()
                    Objordets.Ticket_Status = Docomp_ds.Tables(0).Rows(i)(79).ToString()
                    Objordets.Ticket_Created_Date = Docomp_ds.Tables(0).Rows(i)(80).ToString()
                    ' conCmp.Close()
                    Region = objCPEWFADOProcess.GetRegion(Objordets.WFAO_LOC_STATE)
                    myForm.SetWFADOScreen(Region, Tirksess, Nothing)
                    objLoginUtility.LoginWFA(Region, Tirksess, Nothing)
                    Debrief_Process(Tirksess, Objordets)  'test
                    'UpdateInputHeaderTask(Objordets)
                    'objCPEWFADOProcess.OpenScreen(Tirksess, "DOCOMP")
                    ''Tirksess.SendString(1, 73, "DOCOMP")
                    ''Debrief_Process(Tirksess, Objordets)   'test ''comment
                    ''Tirksess.SendKeys("@E")
                    ''Tirksess.SendKeys("@8")
                    'If Objordets.WFAO_JOBID.Contains("I") Then


                    '    If (Tirksess.GetString(1).Contains("WFADO: POTS INST COMPLETION (DOCOMP)")) Then
                    '        Tirksess.SendString(2, 10, "          ")
                    '        'Tirksess.SendKeys("@8")
                    '        Tirksess.SendString(2, 10, Objordets.WFAO_CENTER)
                    '        Tirksess.SendString(5, 9, Objordets.WFAO_JOBID)
                    '        Tirksess.SendKeys("@1")
                    '        If Tirksess.GetString(24).Contains("SUCCESSFUL") Then
                    '            If Tirksess.GetString(8, 38, 40).Contains("CMP") Then 'must check this
                    '                Objordets.Name = Tirksess.GetString(13, 7, 36)
                    '                Objordets.Address = Tirksess.GetString(14, 7, 48)
                    '                Objordets.Ret_Job_Nar = Tirksess.GetString(9, 16, 55)
                    '                Objordets.Comments = Tirksess.GetString(10) + Tirksess.GetString(11)
                    '                Objordets.C_Date = Tirksess.GetString(16, 15, 20)
                    '                Objordets.D_WFAI_DOCOMP_ITEM = Tirksess.GetString(20, 15, 32)
                    '                Objordets.OCB = Tirksess.GetString(21, 15, 17)
                    '                Objordets.Job_Stat = Tirksess.GetString(8, 38, 40)
                    '                Objordets.Comm_Date = Tirksess.GetString(6, 64, 77)
                    '                Objordets.Job_Assgn = Tirksess.GetString(7, 11, 31) '* 847
                    '                Objordets.Job_Returned = Tirksess.GetString(8, 15, 28)
                    '                Objordets.Job_Started = Tirksess.GetString(7, 42, 55)
                    '                Objordets.Ticket_Status = "COMPLETED"
                    '                Dim StartDate As String
                    '                Dim StartDate1() As String
                    '                Dim s, s1, s2 As String
                    '                Dim t, t1, t2 As String
                    '                StartDate1 = Split(Objordets.Job_Started, " ") 'Job Started format
                    '                If StartDate1(0).Length = 6 Then
                    '                    s = Mid(StartDate1(0), 1, 2)
                    '                    s1 = Mid(StartDate1(0), 3, 2)
                    '                    s2 = Mid(StartDate1(0), 5, 2)
                    '                    StartDate1(0) = s + "/" + s1 + "/" + s2
                    '                End If
                    '                If StartDate1(1).Length = 5 Then
                    '                    t = Mid(StartDate1(1), 1, 2)
                    '                    t1 = Mid(StartDate1(1), 3, 2)
                    '                    t2 = Mid(StartDate1(1), 5, 1)
                    '                    StartDate1(1) = t + ":" + t1 + ":" + "00" + " " + t2 + "M"
                    '                End If
                    '                StartDate = StartDate1(0) + " " + StartDate1(1)
                    '                'put ticketstatus=complete
                    '                'send response
                    '            ElseIf Tirksess.GetString(8, 38, 40).Contains("PRE") Then
                    '                Dim PRE_TIME As String = Tirksess.GetString(12, 2, 13)
                    '                'chek in database
                    '                'If not present hten
                    '                'Get Debrief Values
                    '                DoLog_Process(Tirksess, Objordets)
                    '                objInsert.SetValue(Objordets.Name, 0)
                    '                objInsert.SetValue(Objordets.Address, 1)
                    '                objInsert.SetValue(Objordets.Ret_Job_Nar, 2)
                    '                objInsert.SetValue(Objordets.Comments, 3)
                    '                objInsert.SetValue(Objordets.C_Date, 4)
                    '                objInsert.SetValue(Objordets.Test, 5)
                    '                objInsert.SetValue(Objordets.OCB, 6)
                    '                objInsert.SetValue(Objordets.Job_Stat, 7)
                    '                objInsert.SetValue(Objordets.Comm_Date, 8)
                    '                objInsert.SetValue(Objordets.Job_Assgn, 9)
                    '                objInsert.SetValue(Objordets.Job_Returned, 10)
                    '                objInsert.SetValue(Objordets.Job_Started, 11)
                    '                objInsert.setvalue(Objordets.Ticket_Status, 12)
                    '                StrInsertQuery = "INSERT INTO [OracleCPE].[dbo].[INPUT_HEADER_STAGE] ([Name],[Address],[Ret_Job_Nar],[Comments],[C_Date],[Test],[OCB],[Job_Stat],[Comm_Date],[Job_Assgn],[Job_Returned],[Job_Started],[Ticket_Status]) values(?,?,?,?,?,?,?,?,?,?,?,?,?)"
                    '                objDbutility.InsertQuery([Global].p_sCPE_NOTIFIERDB, StrInsertQuery, ex, objInsert)
                    '                'objordets = Nothing



                    '                objInsert = Nothing
                    '            End If

                    '        End If
                    '    End If
                    'ElseIf Objordets.WFAO_JOBID.Contains("R") Then
                    '    If (Tirksess.GetString(1).Contains(" COMPLETION (DOCOMP)")) Then
                    '        Tirksess.SendString(2, 9, "          ")
                    '        ' Tirksess.SendKeys("@8")
                    '        Tirksess.SendString(2, 9, Objordets.WFAO_CENTER)
                    '        Tirksess.SendString(5, 8, "           ")
                    '        Tirksess.SendString(5, 8, Objordets.WFAO_JOBID)

                    '        Tirksess.SendKeys("@1")
                    '        If Tirksess.GetString(24).Contains("SUCCESSFUL") Then
                    '            If Tirksess.GetString(11, 38, 40).Contains("CMP") Then 'must check this
                    '                'Objordets.Name = Tirksess.GetString(13, 7, 36)
                    '                'Objordets.Address = Tirksess.GetString(14, 7, 48)
                    '                Objordets.Dolog_Comment = Tirksess.GetString(18, 12, 80).Trim + Tirksess.GetString(20, 19, 78).Trim + Tirksess.GetString(21, 19, 78).Trim
                    '                Objordets.Ret_Job_Nar = Tirksess.GetString(12, 25, 54)
                    '                Objordets.Comments = Tirksess.GetString(13, 11, 80).Trim + Tirksess.GetString(14, 2, 72).Trim
                    '                ' Objordets.C_Date = Tirksess.GetString(16, 15, 20)
                    '                Objordets.D_WFAI_DOCOMP_ITEM = Tirksess.GetString(20, 19, 21)
                    '                'Objordets.OCB = Tirksess.GetString(21, 15, 17)
                    '                Objordets.Job_Stat = Tirksess.GetString(10, 14, 40)
                    '                ' Objordets.Comm_Date = Tirksess.GetString(6, 64, 77)
                    '                'Objordets.Job_Assgn = Tirksess.GetString(7, 11, 31) '* 847
                    '                'Objordets.Job_Returned = Tirksess.GetString(8, 15, 28)
                    '                Objordets.Job_Started = Tirksess.GetString(10, 14, 25)
                    '                Objordets.Ticket_Status = "COMPLETED"
                    '                'put ticketstatus=complete
                    '                'send response
                    '            ElseIf Tirksess.GetString(11, 38, 40).Contains("PRE") Then
                    '                'write Function to select datetime 
                    '                Objordets.Job_Started = Tirksess.GetString(12, 2, 13).Trim
                    '                objCPEWFADOProcess.OpenScreen(Tirksess, "DOLOG")
                    '                If Tirksess.GetString(12, 30, 70).Contains("JOB STAT RETD TO PRE") Then
                    '                    Objordets.Dolog_Comment = Tirksess.GetString(18, 12, 80).Trim + "," + Tirksess.GetString(20, 19, 78).Trim
                    '                    Debrief_comment_manipulator(Objordets)
                    '                    Insert_Debrief_Table(Objordets)
                    '                End If
                    '                Objordets.Ticket_Status = "INSERT DEBRIEF"
                    '            End If
                    '        End If


                    '    End If
                    'End If
                    'If Objordets.Ticket_Status = "COMPLETED" Then
                    '    If DoLog_Process(Tirksess, Objordets) Then
                    '        sendResponse_Ticket(Objordets, 8, "WFA_DEBREIF")
                    '        'final response
                    '        sendResponse_Ticket(Objordets, 6, "WFA_INTERFACE")
                    '    End If
                    'ElseIf Objordets.Ticket_Status = "INSERT DEBRIEF" Then
                    '    Insert_Debrief(Objordets)
                    'End If
                    Objordets = Nothing
                Next
            End If
        Catch ex As Exception
            p_objLogger.writenote("Exception: :-" & ex.ToString(), objordets.Task_Id, EventLogEntryType.Error)
        End Try
        'Return 0
    End Function

    Function Dosoi_Process(ByVal Tirksess As AxSmartRumba.AxSmartRumbaControl)
        Try

            Dim Dosoi_ds As New DataSet
            Dim Update_ds As New DataSet
            Dim ex As New Exception
            'Dim StrSelectQuery As String
            Dim StrUpdateQuery As String
            Dim objCPEWFADOProcess As New WFADOProcess(Tirksess)
            Dim objDbutility As New DBUtilities.DBConnect
            objDbutility = SQLDBUtil()
            Dim objLoginUtility As New Oracle_CPE.LoginUtility
            Dim StrSelectQuery As String

            'StrSelectQuery = "Select * from [OracleCPE].[dbo].[INPUT_HEADER_STAGE] where [TICKET_STATUS]='TICKET CREATED' or  [TICKET_STATUS]='Pending load'"
            StrSelectQuery = "Select * from [OracleCPE].[dbo].[INPUT_HEADER_STAGE] where WFAO_JOBID='CPEI1729092'" '"
            Dosoi_ds = objDbutility.SelectQuery([Global].p_sCPE_NOTIFIERDB, StrSelectQuery, ex, Nothing)
            'connNew.Open()
            'Dim strQuery As String = "select * from XXQST.XXQST_WFA_INTERFACE where msg_status='UPDATE COMPLETE'" 'ORACLE_READY
            'Dim objCommand As New OracleCommand(strQuery, connNew)
            'oreader = objCommand.ExecuteReader()
            'oadapter = New OracleDataAdapter(strQuery, connNew)
            'oadapter.Fill(Dosoi_ds)
            Dim i As Integer = 0

            If Dosoi_ds.Tables.Count > 0 Then
                If Dosoi_ds.Tables(0).Rows.Count > 0 Then
                    For i = 0 To Dosoi_ds.Tables(0).Rows.Count - 1
                        Dim Objordets As New OrderDetails
                        Objordets.Task_Id = Dosoi_ds.Tables(0).Rows(i)(0).ToString()
                        Objordets.Incident_Id = Dosoi_ds.Tables(0).Rows(i)(1).ToString()
                        Objordets.Task_Number = Dosoi_ds.Tables(0).Rows(i)(2).ToString()
                        Objordets.Incident_Number = Dosoi_ds.Tables(0).Rows(i)(3).ToString()
                        Objordets.WFAO_CENTER = Dosoi_ds.Tables(0).Rows(i)(4).ToString()
                        Objordets.WFAO_JOBID = Dosoi_ds.Tables(0).Rows(i)(5).ToString()
                        Objordets.WFAI_JSTAT = Dosoi_ds.Tables(0).Rows(i)(6).ToString()
                        Objordets.WFAO_JT = Dosoi_ds.Tables(0).Rows(i)(7).ToString()
                        Objordets.WFAO_TASK_PRIORITY = Dosoi_ds.Tables(0).Rows(i)(8).ToString()
                        Objordets.WFAO_SKILLS = Dosoi_ds.Tables(0).Rows(i)(9).ToString()
                        Objordets.WFAO_CKTID = Dosoi_ds.Tables(0).Rows(i)(10).ToString()
                        Objordets.WFAO_POM = Dosoi_ds.Tables(0).Rows(i)(11).ToString()
                        Objordets.WFAO_PON = Dosoi_ds.Tables(0).Rows(i)(12).ToString()
                        Objordets.WFAO_BILLNAME = Dosoi_ds.Tables(0).Rows(i)(13).ToString()
                        Objordets.WFAO_TELEPHONE = Dosoi_ds.Tables(0).Rows(i)(14).ToString()
                        Objordets.WFAO_WC = Dosoi_ds.Tables(0).Rows(i)(15).ToString()
                        Objordets.WFAO_RTE = Dosoi_ds.Tables(0).Rows(i)(16).ToString()
                        Objordets.WFAO_DAA = Dosoi_ds.Tables(0).Rows(i)(17).ToString()
                        Objordets.WFAO_AA = Dosoi_ds.Tables(0).Rows(i)(18).ToString()
                        Objordets.WFAO_ACT = Dosoi_ds.Tables(0).Rows(i)(19).ToString()
                        Objordets.WFAO_CKLNAME = Dosoi_ds.Tables(0).Rows(i)(20).ToString()
                        'Objordets.WFAO_CKLNAME = Objordets.WFAO_CKLNAME.Substring(0, 30)
                        Objordets.WFAO_CKLADDR = Dosoi_ds.Tables(0).Rows(i)(21).ToString()
                        Objordets.WFAO_LOC_CITY = Dosoi_ds.Tables(0).Rows(i)(22).ToString()
                        Objordets.WFAO_LOC_STATE = Dosoi_ds.Tables(0).Rows(i)(23).ToString()
                        Objordets.WFAO_COMM = Dosoi_ds.Tables(0).Rows(i)(24).ToString()
                        Objordets.WFAO_START_DATE = Dosoi_ds.Tables(0).Rows(i)(25).ToString()
                        Objordets.WFAO_ACC = Dosoi_ds.Tables(0).Rows(i)(26).ToString()
                        Objordets.WFAO_A = Dosoi_ds.Tables(0).Rows(i)(27).ToString()
                        Objordets.WFAO_B = Dosoi_ds.Tables(0).Rows(i)(28).ToString()
                        Objordets.WFAO_DD = Dosoi_ds.Tables(0).Rows(i)(29).ToString()
                        Objordets.WFAO_PRC = Dosoi_ds.Tables(0).Rows(i)(30).ToString()
                        Objordets.WFAO_TPRC = Dosoi_ds.Tables(0).Rows(i)(32).ToString()
                        Objordets.WFAO_ORD_ORIG = Dosoi_ds.Tables(0).Rows(i)(32).ToString()
                        Objordets.WFAO_SVY = Dosoi_ds.Tables(0).Rows(i)(33).ToString()
                        Objordets.WFAO_PST = Dosoi_ds.Tables(0).Rows(i)(34).ToString()
                        Objordets.WFAO_COMMENTS_SUBJECT = Dosoi_ds.Tables(0).Rows(i)(35).ToString()
                        Objordets.WFAO_COMMENTS_URGENCY = Dosoi_ds.Tables(0).Rows(i)(36).ToString()
                        Objordets.WFAO_JOBPRI = Dosoi_ds.Tables(0).Rows(i)(37).ToString()
                        Objordets.WFAO_FACILITY_LABEL = Dosoi_ds.Tables(0).Rows(i)(38).ToString()
                        Objordets.WFAO_F1 = Dosoi_ds.Tables(0).Rows(i)(39).ToString()
                        Objordets.WFAO_PR = Dosoi_ds.Tables(0).Rows(i)(40).ToString()
                        Objordets.WFAO_JOB = Dosoi_ds.Tables(0).Rows(i)(41).ToString()
                        Objordets.WFAO_SCRATCHPAD_TASK_DESC = Dosoi_ds.Tables(0).Rows(i)(42).ToString()
                        Objordets.WFAO_DOCOMM_1 = Dosoi_ds.Tables(0).Rows(i)(43).ToString()
                        Objordets.WFAO_DOCOMM_2 = Dosoi_ds.Tables(0).Rows(i)(44).ToString()
                        Objordets.WFAO_DOCOMM_3 = Dosoi_ds.Tables(0).Rows(i)(45).ToString()
                        Objordets.WFAO_DOCOMM_4 = Dosoi_ds.Tables(0).Rows(i)(46).ToString()
                        Objordets.WFAO_DOCOMM_5 = Dosoi_ds.Tables(0).Rows(i)(47).ToString()
                        Objordets.WFAO_DOCOMM_6 = Dosoi_ds.Tables(0).Rows(i)(48).ToString()
                        Objordets.WFAO_DOCOMM_7 = Dosoi_ds.Tables(0).Rows(i)(49).ToString()
                        Objordets.WFAI_DEBRIEF_COMMENTS = Dosoi_ds.Tables(0).Rows(i)(50).ToString()
                        'objordets.sWFAI_JOB_STRD = Dosoi_ds.Tables(0).Rows(i)(46).ToString()
                        Objordets.WFAI_JOB_RETURNED = Dosoi_ds.Tables(0).Rows(i)(51).ToString()
                        Objordets.MSG_INS_UPDATE_CANCEL = Dosoi_ds.Tables(0).Rows(i)(52).ToString()
                        Objordets.MSG_STATUS = Dosoi_ds.Tables(0).Rows(i)(53).ToString()
                        Objordets.MSG_ERROR = Dosoi_ds.Tables(0).Rows(i)(54).ToString()
                        Objordets.EXCEPTION_INFO = Dosoi_ds.Tables(0).Rows(i)(55).ToString()
                        Objordets.DEBRIEF_COMMENT_HISTORY = Dosoi_ds.Tables(0).Rows(i)(56).ToString()
                        Objordets.PREV_WFAI_JSTAT = Dosoi_ds.Tables(0).Rows(i)(57).ToString()
                        Objordets.TASK_CREATED_BY = Dosoi_ds.Tables(0).Rows(i)(58).ToString()
                        Objordets.SR_CREATED_BY = Dosoi_ds.Tables(0).Rows(i)(59).ToString()
                        Objordets.CREATED_BY = Dosoi_ds.Tables(0).Rows(i)(60).ToString()
                        Objordets.CREATION_DATE = Dosoi_ds.Tables(0).Rows(i)(61).ToString()
                        Objordets.LAST_UPDATED_BY = Dosoi_ds.Tables(0).Rows(i)(62).ToString()
                        Objordets.LAST_UPDATE_DATE = Dosoi_ds.Tables(0).Rows(i)(63).ToString()
                        Objordets.LAST_UPDATE_LOGIN = Dosoi_ds.Tables(0).Rows(i)(64).ToString()
                        Objordets.Ticket_Status = Dosoi_ds.Tables(0).Rows(i)(79).ToString()
                        If Dosoi_ds.Tables(0).Rows(i)(80).ToString.Length > 0 Then
                            Objordets.Ticket_Created_Date = Dosoi_ds.Tables(0).Rows(i)(80)
                        End If


                        Region = objCPEWFADOProcess.GetRegion(Objordets.WFAO_LOC_STATE)
                        myForm.SetWFADOScreen(Region, Tirksess, Nothing)
                        objLoginUtility.LoginWFA(Region, Tirksess, Nothing)
                        If Objordets.WFAO_JOBID.Contains("I") Then


                            objCPEWFADOProcess.OpenScreen(Tirksess, "DOSOI")

                            If (Tirksess.GetString(1).Contains(" (DOSOI)")) Then
                                Tirksess.SendString(2, 9, "           ")
                                Tirksess.SendString(2, 9, Objordets.WFAO_CENTER) ' cntrIDObjordets.WFAO_CENTER Objordets.WFAO_JOBID
                                Tirksess.SendString(3, 8, "           ")
                                Tirksess.SendString(3, 8, Objordets.WFAO_JOBID)
                                Tirksess.SendKeys("@1")
                                If Tirksess.GetString(24).Contains("SUCCESSFUL") Or Tirksess.GetString(3, 53, 55).Trim.Equals("PRE") Then
                                    Objordets.WFAO_CENTER_TECH = Tirksess.GetString(2, 9, 19)
                                    'CODE CHANGES FOR TECH 000
                                    If Objordets.WFAO_CENTER_TECH.Length = 0 Then
                                        Objordets.WFAO_CENTER_TECH = "000"
                                    End If
                                    System.Windows.Forms.Application.DoEvents()
                                    System.Threading.Thread.Sleep(1000)
                                    If Tirksess.GetString(3, 53, 55).Equals("CAN") Then
                                        Objordets.Ticket_Status = "CANCELLED"
                                        Objordets.WFAI_JSTAT = Tirksess.GetString(3, 53, 55)
                                    End If
                                    If Not (Tirksess.GetString(2, 30, 32).Trim).Length.Equals(0) Or Tirksess.GetString(3, 53, 55).Equals("PRE") Then
                                        Objordets.Tech_Ec = Tirksess.GetString(2, 30, 32)
                                        Objordets.Ticket_Status = "TECH ASSIGNED"
                                        Objordets.Comm_Date = Tirksess.GetString(5, 7, 18)
                                        Objordets.Job_Assgn = Tirksess.GetString(2, 40, 45)
                                        Objordets.WFAO_START_DATE = Tirksess.GetString(11, 69, 80)
                                        Objordets.WFAI_JSTAT = Tirksess.GetString(3, 53, 55)
                                        Objordets.WFAO_JT = Tirksess.GetString(3, 75, 80)
                                        objCPEWFADOProcess.OpenScreen(Tirksess, "DOLOG")
                                        If Tirksess.GetString(1).Contains("(DOLOG)") Then
                                            Tirksess.SendString(2, 10, Objordets.WFAO_CENTER) ' cntrID
                                            Tirksess.SendString(3, 9, Objordets.WFAO_JOBID)
                                            Tirksess.SendKeys("@1")
                                            System.Windows.Forms.Application.DoEvents()
                                            System.Threading.Thread.Sleep(1000)
                                            Objordets.Job_Started_Date = Tirksess.GetString(12, 2, 13)
                                        End If
                                    ElseIf Not Tirksess.GetString(3, 53, 55).Equals("CAN") Then
                                        Objordets.Ticket_Status = "TICKET CREATED" 'doubt tech not assigned or ticket created
                                    End If

                                    If Objordets.Ticket_Status = "TECH ASSIGNED" Then
                                        If Objordets.WFAO_CENTER_TECH = "000" Then
                                            Objordets.CUID = "Default"
                                            Objordets.Tech_Last_Name = "Default"
                                            Objordets.Tech_First_Name = "Default"
                                        Else
                                            getTechValues(Objordets)
                                        End If


                                        If Objordets.CUID = Nothing Then
                                            Objordets.WFAI_DEBRIEF_COMMENTS = "ASSIGNED TECH-" + Objordets.Tech_Ec + " TECH DETAILS NOT AVAILABLE IN DATABASE. TECH ASSIGNED DATE:" + Objordets.Job_Assgn.Trim + "  RESOLVE BY DATE:" + Objordets.Comm_Date + " SCHEDULED START DATE:" + Objordets.WFAO_START_DATE + ""
                                        Else
                                            Objordets.WFAI_DEBRIEF_COMMENTS = "ASSIGNED TECH-" + Objordets.Tech_Ec + " TECH CUID:" + Objordets.CUID + " FIRSTNAME:" + Objordets.Tech_First_Name + " LASTNAME:" + Objordets.Tech_Last_Name + " TECH ASSIGNED DATE:" + Objordets.Job_Assgn.Trim + "  RESOLVE BY DATE:" + Objordets.Comm_Date + " SCHEDULED START DATE:" + Objordets.WFAO_START_DATE + ""

                                        End If
                                        'If Objordets.WFAO_JOBID.Contains("I") Then
                                        '    Objordets.WFAI_DEBRIEF_COMMENTS = "ASSIGNED TECH-" + Objordets.Tech_Ec + " TECH CUID:" + Objordets.CUID + " FIRSTNAME:" + Objordets.Tech_First_Name + " LASTNAME:" + Objordets.Tech_Last_Name + " TECH ASSIGNED DATE:" + Objordets.Job_Assgn.Trim + "  RESOLVE BY DATE:" + Objordets.Comm_Date + " SCHEDULED START DATE:" + Objordets.WFAO_START_DATE + ""
                                        'Else
                                        '    Objordets.WFAI_DEBRIEF_COMMENTS = "ASSIGNED TECH-" + Objordets.Tech_Ec + " TECH CUID:" + Objordets.CUID + " FIRSTNAME:" + Objordets.Tech_First_Name + " LASTNAME:" + Objordets.Tech_Last_Name + " TECH ASSIGNED DATE:" + Objordets.Job_Assgn.Trim + "  RESOLVE BY DATE:" + Objordets.Comm_Date + ""
                                        'End If
                                        StrUpdateQuery = "UPDATE [OracleCPE].[dbo].[INPUT_HEADER_STAGE] set [Ticket_Status] = '" + Objordets.Ticket_Status + "',[Tech_Ec]='" + Objordets.Tech_Ec + "',[WFAO_CENTER]='" + Objordets.WFAO_CENTER + "',[WFAI_JSTAT]='" + Objordets.WFAI_JSTAT + "',[Job_Started_Date]='" + Objordets.Job_Started_Date + "',[WFAI_DEBRIEF_COMMENTS]='" + Objordets.WFAI_DEBRIEF_COMMENTS + "' where [WFAO_JOBID]='" + Objordets.WFAO_JOBID + "'"
                                        objDbutility.UpdateQuery([Global].p_sCPE_NOTIFIERDB, StrUpdateQuery, ex, Nothing)
                                        If Objordets.CUID = Nothing Then
                                            sendResponse_Ticket(Objordets, -3, "WFA_INTERFACE")
                                        Else
                                            sendResponse_Ticket(Objordets, 3, "WFA_INTERFACE")
                                        End If
                                    End If
                                End If
                            End If
                        Else

                            objCPEWFADOProcess.OpenScreen(Tirksess, "DOMCWR")


                            If (Tirksess.GetString(1).Contains("(DOMCWR)")) Then
                                Tirksess.SendString(2, 9, "           ")
                                Tirksess.SendString(2, 9, Objordets.WFAO_CENTER) ' cntrIDObjordets.WFAO_CENTER Objordets.WFAO_JOBID
                                Tirksess.SendString(3, 8, "           ")
                                Tirksess.SendString(3, 8, Objordets.WFAO_JOBID)
                                Tirksess.SendKeys("@1")
                                If Tirksess.GetString(24).Contains("SUCCESSFUL") And Tirksess.GetString(3, 53, 55).Equals("PRE") Then
                                    Objordets.WFAO_CENTER_TECH = Tirksess.GetString(2, 9, 19)
                                    'CODE CHANGES FOR TECH 000
                                    If Objordets.WFAO_CENTER_TECH.Length = 0 Then
                                        Objordets.WFAO_CENTER_TECH = "000"
                                    End If
                                    System.Windows.Forms.Application.DoEvents()
                                    System.Threading.Thread.Sleep(1000)

                                    If Not (Tirksess.GetString(9, 45, 47).Trim).Length.Equals(0) Then
                                        Objordets.Tech_Ec = Tirksess.GetString(9, 45, 47)
                                        Objordets.Ticket_Status = "TECH ASSIGNED"
                                        Objordets.Comm_Date = Tirksess.GetString(10, 7, 20)
                                        Objordets.Job_Assgn = Tirksess.GetString(9, 30, 35)
                                        Objordets.WFAI_JSTAT = Tirksess.GetString(3, 40, 42)
                                        Objordets.WFAO_JT = Tirksess.GetString(3, 56, 61)
                                        objCPEWFADOProcess.OpenScreen(Tirksess, "DOLOG")
                                        If Tirksess.GetString(1).Contains("(DOLOG)") Then
                                            Tirksess.SendString(2, 10, Objordets.WFAO_CENTER) ' cntrID
                                            Tirksess.SendString(3, 9, Objordets.WFAO_JOBID)
                                            Tirksess.SendKeys("@1")
                                            System.Windows.Forms.Application.DoEvents()
                                            System.Threading.Thread.Sleep(1000)
                                            Objordets.Job_Started_Date = Tirksess.GetString(12, 2, 13)
                                        End If
                                    Else
                                        Objordets.Ticket_Status = "TICKET CREATED"
                                    End If
                                    If Objordets.Ticket_Status = "TECH ASSIGNED" Then
                                        If Objordets.WFAO_CENTER_TECH = "000" Then
                                            Objordets.CUID = "Default"
                                            Objordets.Tech_Last_Name = "Default"
                                            Objordets.Tech_First_Name = "Default"
                                        Else
                                            getTechValues(Objordets)
                                        End If


                                        ' Objordets.WFAI_DEBRIEF_COMMENTS = "ASSIGNED TECH-" + Objordets.Tech_Ec + " TECH CUID:" + Objordets.CUID + " FIRSTNAME:" + Objordets.Tech_First_Name + " LASTNAME:" + Objordets.Tech_Last_Name + " TECH ASSIGNED DATE: " + Objordets.Job_Assgn.Trim + "RESOLVE BY DATE:" + Objordets.Comm_Date + ""
                                        If Objordets.CUID = Nothing Then
                                            Objordets.WFAI_DEBRIEF_COMMENTS = "ASSIGNED TECH-" & Objordets.Tech_Ec & " TECH  DETAILS NOT AVAILABLE IN DATABASE. TECH ASSIGNED DATE:" & Objordets.Job_Assgn.Trim & "  RESOLVE BY DATE:" & Objordets.Comm_Date & ""
                                        Else
                                            Objordets.WFAI_DEBRIEF_COMMENTS = "ASSIGNED TECH-" + Objordets.Tech_Ec + " TECH CUID:" + Objordets.CUID + " FIRSTNAME:" + Objordets.Tech_First_Name + " LASTNAME:" + Objordets.Tech_Last_Name + " TECH ASSIGNED DATE:" + Objordets.Job_Assgn.Trim + "  RESOLVE BY DATE:" + Objordets.Comm_Date + ""
                                        End If
                                        StrUpdateQuery = "UPDATE [OracleCPE].[dbo].[INPUT_HEADER_STAGE] set [Ticket_Status] = '" + Objordets.Ticket_Status + "',[Tech_Ec]='" + Objordets.Tech_Ec + "',[WFAO_CENTER]='" + Objordets.WFAO_CENTER + "',[WFAI_JSTAT]='" + Objordets.WFAI_JSTAT + "',[Job_Started_Date]='" + Objordets.Job_Started_Date + "' where [WFAO_JOBID]='" + Objordets.WFAO_JOBID + "'"
                                        objDbutility.UpdateQuery([Global].p_sCPE_NOTIFIERDB, StrUpdateQuery, ex, Nothing)

                                        If Objordets.CUID = Nothing Then
                                            sendResponse_Ticket(Objordets, -3, "WFA_INTERFACE")
                                        Else
                                            sendResponse_Ticket(Objordets, 3, "WFA_INTERFACE")
                                        End If


                                    End If
                                End If
                            End If

                        End If
                        UpdateInputHeaderTask(Objordets)

                        If Objordets.WFAI_JSTAT = "CAN" Then
                            sendResponse_Ticket(Objordets, 7, "WFA_INTERFACE")
                        End If
                        Objordets = Nothing
                    Next
                    'End If
                End If
            End If


        Catch ex As Exception
            p_objLogger.writenote("Exception: :-" & ex.ToString(), objordets.Task_Id, EventLogEntryType.Error)
        End Try
    End Function

    Function save_text(ByVal obj As OrderDetails, ByVal Tirksess As AxSmartRumba.AxSmartRumbaControl)
        Try

            ' Dim oradb As String = "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=prdstgdb.dev.qintra.com)(PORT=1529))(CONNECT_DATA=(SID=PRDSTG)));User Id=xxcpewfa;Password=cpewfa_1213;"
            ' Dim oradb As String = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=cpet2dbsg.dev.qintra.com)(PORT=1524)))(CONNECT_DATA=(SID=CPET2)));User Id=xxcpewfa;Password=xxcpewfa_0813;"
            ' Dim oradb As String = "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=cpepdb1.qintra.com)(PORT=1521))(CONNECT_DATA=(SID=CPEP)));User Id=xxcpewfa;Password=cpewfa_1213;"
            Dim oradb As String = System.Configuration.ConfigurationManager.ConnectionStrings("ConnStr").ConnectionString
            Dim conn As New OracleConnection(oradb)
            Dim oadapter2 As OracleDataAdapter
            Dim oreader2 As OracleDataReader
            Dim objDbutility As New DBUtilities.DBConnect
            objDbutility = SQLDBUtil()
            Dim objdataLogin As New Data.DataSet
            Dim objInsert() As Object = Nothing
            Dim ex As New Exception


            Dim objQueryFleHndlr As New FileHandler.INIFileHandler(p_sCPE_NotifierIni)
            Dim objLoginUtility As New Oracle_CPE.LoginUtility

            conn.Open()
            'case1
            'msg_status=ready and msg-Ins_upd_cancel=new
            Dim strQuery5 As String = "select * from XXQST_WFA_INTF_NOTES where task_ID='" + obj.Task_Id + "'"
            Dim objCommand As New OracleCommand(strQuery5, conn)
            oreader2 = objCommand.ExecuteReader()
            oadapter2 = New OracleDataAdapter(strQuery5, conn)
            Dim Input_ds As DataSet = New DataSet()
            oadapter2.Fill(Input_ds)

            Dim mylog As New Scripting.FileSystemObject



            Dim url As String = ""


            Dim c As Integer = 0
            For Each column As DataColumn In Input_ds.Tables(0).Columns
                'For c As Integer = 0 To Input_ds.Tables(0).Columns.Count - 5
                If c < 5 Then
                    System.IO.File.AppendAllText("\\velomp2s.corp.intranet\HICAPShare\SOPADBOX\ORACLECPE\ORACLE\" & obj.WFAO_JOBID & "_" & DateTime.Today.ToString("ddMMyyyy") & ".txt", column.ColumnName.ToString() + " : " + Input_ds.Tables(0).Rows(0)(c).ToString())
                    'System.IO.File.AppendAllText("\\10.6.68.180\d$\DSLPortRecovery\OracleCPE" & DateTime.Today.ToString("ddMMyyyy") & ".txt", vbNewLine)
                    System.IO.File.AppendAllText("\\velomp2s.corp.intranet\HICAPShare\SOPADBOX\ORACLECPE\ORACLE\" & obj.WFAO_JOBID & "_" & DateTime.Today.ToString("ddMMyyyy") & ".txt", vbNewLine)
                    c += 1
                End If
            Next
            objordets.DOSOI_URL = "\\velomp2s.corp.intranet\HICAPShare\SOPADBOX\ORACLECPE\ORACLE\" & obj.WFAO_JOBID & "_" & DateTime.Today.ToString("ddMMyyyy") & ".txt"


            Return objordets.DOSOI_URL

        Catch ex As Exception
            p_objLogger.writenote("Exception: :-" & ex.ToString(), objordets.Task_Id, EventLogEntryType.Error)
        End Try

    End Function
    Function BK_sendResponse_Ticket(ByVal objordet As OrderDetails, ByRef Response As String, ByVal tablename As String)
        Try

lbl:        Dim x As Exception
            Dim Ds As New DataSet()
            Dim Stop_Flag As Boolean = False
            Dim Oraclecon As New OleDbConnection("Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=cpet2dbsg.dev.qintra.com)(PORT=1524))(CONNECT_DATA=(SERVICE_NAME='CPET2')));Provider=OraOLEDB.Oracle;User Id=xxcpewfa;Password=xxcpewfa_0813;")

            'Oraclecon.ConnectionString = "Provider=MSDAORA;User ID=xxcpewfa;Password=xxcpewfa_0813;Data Source==(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=mssrpt.cte.net)" +
            '      "(PORT=1602))(CONNECT_DATA=(SERVICE_NAME='MSSPRD')));OLEDB.NET=true"
            Oraclecon.Open()
            Dim param1 As New OleDbParameter
            Dim param2 As New OleDbParameter
            Dim myCMD As New OleDbCommand()
            Dim xml_tag As String = ""
            myCMD.Connection = Oraclecon
            Dim Flag As Integer
            myCMD.CommandType = CommandType.StoredProcedure

            'xml_tag = "<ROWSET><ROW num='1'><TASK_ID>992397</TASK_ID><WFAI_JOB_RETURNED></WFAI_JOB_RETURNED><MSG_INS_<WFAI_DEBRIEF_COMMENTS></WFAI_DEBRIEF_COMMENTS><MSG_ERROR>NOTHING</MSG_ERROR><WFAI_JSTAT></WFAI_JSTAT><EXCEPTION_INFO>NOTHING</EXCEPTION_INFO><MSG_STATUS>ORACLE_READY</MSG_STATUS></ROW></ROWSET>"

            If tablename.Equals("WFA_INTERFACE") Then

                'FIRST RESPONSE
                If Response = 1 Then
                    xml_tag = "<ROWSET><ROW num='1'><TASK_ID>" + objordet.Task_Id + "</TASK_ID><MSG_STATUS>WFA_PICKED</MSG_STATUS></ROW></ROWSET>"
                    'xml_tag = "<ROWSET><ROW num='1'><TASK_ID>" + objordet.Task_Id + "</TASK_ID><WFAI_JSTAT>CMP</WFAI_JSTAT></ROW></ROWSET>"
                ElseIf Response = -1 Then
                    xml_tag = "<ROWSET><ROW num='1'><TASK_ID>" + objordet.Task_Id + "</TASK_ID><MSG_STATUS>WFA_ERROR</MSG_STATUS><MSG_ERROR>FIND FAILED, WORK REQUEST NOT FOUND</MSG_ERROR></ROW></ROWSET>"
                ElseIf Response = 2 Then

                    'Ticket Created 
                    xml_tag = "<ROWSET><ROW num='1'><TASK_ID>" + objordet.Task_Id + "</TASK_ID><WFAI_JOB_RETURNED>" + objordet.Job_Returned + "</WFAI_JOB_RETURNED><WFAI_JSTAT>PLD</WFAI_JSTAT><WFAI_DEBRIEF_COMMENTS>TICKET CREATED.TECH NEEDS TO BE ASSIGNED.</WFAI_DEBRIEF_COMMENTS><MSG_STATUS>ORACLE_READY</MSG_STATUS></ROW></ROWSET>"

                ElseIf Response = 3 Then
                    'Tech Details

                    If objordet.WFAO_JOBID.Contains("I") Then
                        xml_tag = "<ROWSET><ROW num='1'><TASK_ID>" + objordet.Task_Id + "</TASK_ID><WFAI_JOB_RETURNED>" + objordet.Job_Returned + "</WFAI_JOB_RETURNED><WFAI_JSTAT>" + objordet.WFAI_JSTAT + "</WFAI_JSTAT><WFAI_DEBRIEF_COMMENTS>ASSIGNED TECH-" + objordet.Tech_Ec + " TECH CUID:" + objordet.CUID + " FIRSTNAME:" + objordet.Tech_First_Name + " LASTNAME:" + objordet.Tech_Last_Name + " TECH ASSIGNED DATE:" + objordet.Job_Assgn.Trim + "  RESOLVE BY DATE:" + objordet.Comm_Date + " SCHEDULED START DATE:" + objordet.WFAO_START_DATE + "</WFAI_DEBRIEF_COMMENTS><MSG_STATUS>ORACLE_READY</MSG_STATUS></ROW></ROWSET>"
                    Else
                        xml_tag = "<ROWSET><ROW num='1'><TASK_ID>" + objordet.Task_Id + "</TASK_ID><WFAI_JOB_RETURNED>" + objordet.Job_Returned + "</WFAI_JOB_RETURNED><WFAI_JSTAT>" + objordet.WFAI_JSTAT + "</WFAI_JSTAT><WFAI_DEBRIEF_COMMENTS>ASSIGNED TECH-" + objordet.Tech_Ec + " TECH CUID:" + objordet.CUID + " FIRSTNAME:" + objordet.Tech_First_Name + " LASTNAME:" + objordet.Tech_Last_Name + " TECH ASSIGNED DATE: " + objordet.Job_Assgn.Trim + "  RESOLVE BY DATE:" + objordet.Comm_Date + "</WFAI_DEBRIEF_COMMENTS><MSG_STATUS>ORACLE_READY</MSG_STATUS></ROW></ROWSET>"
                    End If

                    'xml_tag = "<ROWSET><ROW num='1'><TASK_ID>" + objordet.Task_Id + "</TASK_ID><WFAI_JSTAT>" + objordet.WFAI_JSTAT + "</WFAI_JSTAT><WFAI_DEBRIEF_COMMENTS>ASSIGNED TECH-155 TECH DETAILS NOT AVAILABEL IN DATABASE. TECH ASSIGNED DATE: : 102213  RESOLVE BY DATE:110113 1159A SCHEDULED START DATE:102313 1159A</WFAI_DEBRIEF_COMMENTS></ROW></ROWSET>"

                    'xml_tag = "<ROWSET><ROW num='1'><TASK_ID>" + objordet.Task_Id + "</TASK_ID><WFAI_JOB_RETURNED>" + objordet.Job_Returned + " </WFAI_JOB_RETURNED><WFAI_JSTAT>CAN</WFAI_JSTAT><MSG_STATUS>ORACLE_READY</MSG_STATUS></ROW></ROWSET>"
                ElseIf Response = 4 Then
                    'Update Scduele date
                    xml_tag = "<ROWSET><ROW num='1'><TASK_ID>" + objordet.Task_Id + "</TASK_ID><WFAI_JSTAT>PRE</WFAI_JSTAT><WFAI_DEBRIEF_COMMENTS>UPDATE PROCESS COMPLETED.RESOLVE BY:102213 0330P</WFAI_DEBRIEF_COMMENTS><MSG_STATUS>ORACLE_READY</MSG_STATUS></ROW></ROWSET>"
                ElseIf Response = 5 Then
                    'cancel response
                    xml_tag = "<ROWSET><ROW num='1'><TASK_ID>" + objordet.Task_Id + "</TASK_ID><WFAI_JSTAT>CAN</WFAI_JSTAT><WFAI_DEBRIEF_COMMENTS></WFAI_DEBRIEF_COMMENTS><MSG_STATUS>ORACLE_READY</MSG_STATUS></ROW></ROWSET>"
                ElseIf Response = -5 Then
                    xml_tag = "<ROWSET><ROW num='1'><TASK_ID>" + objordet.Task_Id + "</TASK_ID><WFAI_JSTAT>CAN</WFAI_JSTAT><MSG_ERROR>INVALID TO CANCEL A CANCELLED WORK REQUEST</MSG_ERROR><MSG_STATUS>WFA_ERROR</MSG_STATUS></ROW></ROWSET>"
                ElseIf Response = 6 Then
                    'Final Response
                    xml_tag = "<ROWSET><ROW num='1'><TASK_ID>" + objordet.Task_Id + "</TASK_ID><WFAI_JSTAT>CMP</WFAI_JSTAT><MSG_STATUS>ORACLE_READY</MSG_STATUS><WFAI_DEBRIEF_COMMENTS>ASSIGNED TECH-155 TECH INFO NOT AVAILABLE IN DATABASE. TECH ASSIGNED DATE:102913  RESOLVE BY DATE:110113 1159A SCHEDULED START DATE:102913 1159A.NEEDS TO BE DEBRIEFED IN THE AFTERNOON TO TEST MILITARY TIME. 8005551234, MAIN CONTACT</WFAI_DEBRIEF_COMMENTS></ROW></ROWSET>"

                ElseIf Response = 9 Then
                    'CANNOT BE CANCELLED RESPONSE
                    xml_tag = "<ROWSET><ROW num='1'><TASK_ID>" + objordet.Task_Id + "</TASK_ID><WFAI_JSTAT></WFAI_JSTAT><MSG_ERROR>FIND FAILED, WORK REQUEST NOT FOUND</MSG_ERROR><MSG_STATUS>WFA_ERROR</MSG_STATUS></ROW></ROWSET>"
                ElseIf Response = 10 Then
                    'Invalid details for creating Tikcets
                    xml_tag = "<ROWSET><ROW num='1'><TASK_ID>" + objordet.Task_Id + "</TASK_ID><MSG_ERROR>INVALID DETAILS PROVIDED</MSG_ERROR><EXCEPTION_INFO>" + objordet.MSG_ERROR + "</EXCEPTION_INFO><MSG_STATUS>WFA_ERROR</MSG_STATUS></ROW></ROWSET>"
                ElseIf Response = 15 Then
                    'Ticket Already Exist
                    xml_tag = "<ROWSET><ROW num='1'><TASK_ID>" + objordet.Task_Id + "</TASK_ID><MSG_ERROR>ORDER ALREADY EXIST IN WFA.</MSG_ERROR><MSG_STATUS>WFA_ERROR</MSG_STATUS></ROW></ROWSET>"

                ElseIf Response = 16 Then
                    'Wrong Debreif 
                    xml_tag = "<ROWSET><ROW num='1'><TASK_ID>" + objordet.Task_Id + "</TASK_ID><MSG_ERROR>INVALID LAB_EXP ENTERED</MSG_ERROR><MSG_STATUS>WFA_ERROR</MSG_STATUS></ROW></ROWSET>"
                End If




            ElseIf (tablename.Equals("WFA_DEBREIF")) Then
                'objordet.Dolog_Comment = "L-DISP-200, E-LUNCH-50,INSTALL-CPE-IR1"


                If Response = 11 Then
                    'Response Only For Labour alone
                    xml_tag = "<ROWSET><ROW num='1'><TASK_ID>" + objordet.Task_Id + "</TASK_ID><WFAI_DEBRIEF_NUMBER>1</WFAI_DEBRIEF_NUMBER><WFAI_DOCOMP_STATUS>" + objordet.WFAI_JSTAT + "</WFAI_DOCOMP_STATUS><WFAI_DOCOMP_ITEM>" + objordet.D_WFAI_DOCOMP_ITEM + "</WFAI_DOCOMP_ITEM><WFAI_DOCOMP_LAB_EXP>" + objordet.D_WFAI_DOCOMP_LAB_EXP + "</WFAI_DOCOMP_LAB_EXP><WFAI_DOCOMP_HOURS>" + objordet.D_WFAI_DOCOMP_HOURS + "</WFAI_DOCOMP_HOURS><WFAI_DOCOMP_REASON_CODE>" + objordet.D_WFAI_DOCOMP_REASON_CODE + "</WFAI_DOCOMP_REASON_CODE><MSG_STATUS>ORACLE_READY</MSG_STATUS><WFAI_JOB_STRTD>" + objordet.Job_Returned + "</WFAI_JOB_STRTD></ROW></ROWSET>"
                    Stop_Flag = True
                End If
                If Response = 12 Then
                    'Response Only For Labour and Expense without BILLABLE 


                    If Flag = 1 Then
                        xml_tag = "<ROWSET><ROW num='1'><TASK_ID>" + objordet.Task_Id + "</TASK_ID><WFAI_DEBRIEF_NUMBER>4</WFAI_DEBRIEF_NUMBER><WFAI_DOCOMP_STATUS>CMP</WFAI_DOCOMP_STATUS><WFAI_DOCOMP_ITEM>" + objordet.D_WFAI_DOCOMP_ITEM + "</WFAI_DOCOMP_ITEM><WFAI_DOCOMP_LAB_EXP>" + objordet.D_WFAI_DOCOMP_LAB_EXP_E + "</WFAI_DOCOMP_LAB_EXP><WFAI_DOCOMP_HOURS>" + objordet.D_WFAI_DOCOMP_EXP_E + "</WFAI_DOCOMP_HOURS><WFAI_DOCOMP_REASON_CODE>" + objordet.D_WFAI_DOCOMP_REASON_CODE_E + "</WFAI_DOCOMP_REASON_CODE><MSG_STATUS>ORACLE_READY</MSG_STATUS><WFAI_JOB_STRTD>10/18/2013 14:00:00PM</WFAI_JOB_STRTD></ROW></ROWSET>"
                        'xml_tag = "<ROWSET><ROW num='1'><TASK_ID>" + objordet.Task_Id + "</TASK_ID><WFAI_DEBRIEF_NUMBER>4</WFAI_DEBRIEF_NUMBER><WFAI_DOCOMP_STATUS>CMP</WFAI_DOCOMP_STATUS><WFAI_DOCOMP_ITEM></WFAI_DOCOMP_ITEM><WFAI_DOCOMP_LAB_EXP></WFAI_DOCOMP_LAB_EXP><WFAI_DOCOMP_HOURS></WFAI_DOCOMP_HOURS><WFAI_DOCOMP_REASON_CODE></WFAI_DOCOMP_REASON_CODE><MSG_ERROR>INVALID LAB_EXP ENTERED</MSG_ERROR><MSG_STATUS>ORACLE_READY</MSG_STATUS><WFAI_JOB_STRTD>09/26/2013 10:26:00AM</WFAI_JOB_STRTD></ROW></ROWSET>"
                        Flag = 0
                        Stop_Flag = True
                    Else
                        'xml_tag = "<ROWSET><ROW num='1'><TASK_ID>" + objordet.Task_Id + "</TASK_ID><WFAI_DEBRIEF_NUMBER>4</WFAI_DEBRIEF_NUMBER></ROW></ROWSET>"
                        xml_tag = "<ROWSET><ROW num='1'><TASK_ID>" + objordet.Task_Id + "</TASK_ID><WFAI_DEBRIEF_NUMBER>2</WFAI_DEBRIEF_NUMBER><WFAI_DOCOMP_STATUS>CMP</WFAI_DOCOMP_STATUS><WFAI_DOCOMP_ITEM>" + objordet.D_WFAI_DOCOMP_ITEM + "</WFAI_DOCOMP_ITEM><WFAI_DOCOMP_LAB_EXP>" + objordet.D_WFAI_DOCOMP_LAB_EXP + "</WFAI_DOCOMP_LAB_EXP><WFAI_DOCOMP_HOURS>" + objordet.D_WFAI_DOCOMP_HOURS + "</WFAI_DOCOMP_HOURS><WFAI_DOCOMP_REASON_CODE>" + objordet.D_WFAI_DOCOMP_REASON_CODE + "</WFAI_DOCOMP_REASON_CODE><MSG_STATUS>ORACLE_READY</MSG_STATUS><WFAI_JOB_STRTD>10/22/2013 09:30:00 AM</WFAI_JOB_STRTD></ROW></ROWSET>"
                    End If
                End If
                If Response = 13 Then

                    'Response Only For Labour and Expense with BILLABLE  value
                    If Flag = 1 Then
                        xml_tag = "<ROWSET><ROW num='1'><TASK_ID>" + objordet.Task_Id + "</TASK_ID><WFAI_DEBRIEF_NUMBER>3</WFAI_DEBRIEF_NUMBER><WFAI_DOCOMP_STATUS>CMP</WFAI_DOCOMP_STATUS><WFAI_DOCOMP_ITEM>" + objordet.D_WFAI_DOCOMP_ITEM + "</WFAI_DOCOMP_ITEM><WFAI_DOCOMP_LAB_EXP>" + objordet.D_WFAI_DOCOMP_LAB_EXP_E + "</WFAI_DOCOMP_LAB_EXP><WFAI_DOCOMP_HOURS>" + objordet.D_WFAI_DOCOMP_EXP_E + "</WFAI_DOCOMP_HOURS><WFAI_DOCOMP_REASON_CODE>" + objordet.D_WFAI_DOCOMP_REASON_CODE_E + "</WFAI_DOCOMP_REASON_CODE><MSG_STATUS>ORACLE_READY</MSG_STATUS><WFAI_JOB_STRTD>10/22/2013 09:30:00AM</WFAI_JOB_STRTD></ROW></ROWSET>"
                        'xml_tag = "<ROWSET><ROW num='1'><TASK_ID>" + objordet.Task_Id + "</TASK_ID><WFAI_DEBRIEF_NUMBER>4</WFAI_DEBRIEF_NUMBER><WFAI_DOCOMP_STATUS>CMP</WFAI_DOCOMP_STATUS><WFAI_DOCOMP_ITEM></WFAI_DOCOMP_ITEM><WFAI_DOCOMP_LAB_EXP></WFAI_DOCOMP_LAB_EXP><WFAI_DOCOMP_HOURS></WFAI_DOCOMP_HOURS><WFAI_DOCOMP_REASON_CODE></WFAI_DOCOMP_REASON_CODE><MSG_ERROR>INVALID LAB_EXP ENTERED</MSG_ERROR><MSG_STATUS>ORACLE_READY</MSG_STATUS><WFAI_JOB_STRTD>09/26/2013 10:26:00AM</WFAI_JOB_STRTD></ROW></ROWSET>"
                        Flag = 0
                        Stop_Flag = True
                    Else
                        'xml_tag = "<ROWSET><ROW num='1'><TASK_ID>" + objordet.Task_Id + "</TASK_ID><WFAI_DEBRIEF_NUMBER>4</WFAI_DEBRIEF_NUMBER></ROW></ROWSET>"
                        xml_tag = "<ROWSET><ROW num='1'><TASK_ID>" + objordet.Task_Id + "</TASK_ID><WFAI_DEBRIEF_NUMBER>2</WFAI_DEBRIEF_NUMBER><WFAI_DOCOMP_STATUS>CMP</WFAI_DOCOMP_STATUS><WFAI_DOCOMP_ITEM>" + objordet.D_WFAI_DOCOMP_ITEM + "</WFAI_DOCOMP_ITEM><WFAI_DOCOMP_LAB_EXP>" + objordet.D_WFAI_DOCOMP_LAB_EXP + "</WFAI_DOCOMP_LAB_EXP><WFAI_DOCOMP_HOURS>" + objordet.D_WFAI_DOCOMP_HOURS + "</WFAI_DOCOMP_HOURS><WFAI_DOCOMP_REASON_CODE>" + objordet.D_WFAI_DOCOMP_REASON_CODE + "</WFAI_DOCOMP_REASON_CODE><MSG_STATUS>ORACLE_READY</MSG_STATUS><WFAI_JOB_STRTD>10/22/2013 09:30:00</WFAI_JOB_STRTD></ROW></ROWSET>"
                        'xml_tag = "<ROWSET><ROW num='1'><TASK_ID>" + objordet.Task_Id + "</TASK_ID><WFAI_DEBRIEF_NUMBER>1</WFAI_DEBRIEF_NUMBER><WFAI_JOB_STRTD>10/16/2013 01:00:00PM</WFAI_JOB_STRTD></ROW></ROWSET>"
                    End If
                End If


            End If



            param1.Value = xml_tag
            param1.ParameterName = "PS_XML_DATA"
            myCMD.Parameters.Add(param1)


            'param1.Value = xml_tag
            param2.ParameterName = "PS_XML_OUT_DATA"
            param2.Size = 500
            param2.Direction = ParameterDirection.Output
            myCMD.Parameters.Add(param2)
            myCMD.CommandText = "APPS.XXQST_WFA_XML_UPDATE_PKG.UPDATE_INS_WFA_DATA_WITH_XML"

            If (tablename.Equals("WFA_DEBREIF")) Then
                myCMD.Parameters.AddWithValue("ps_table", "XXQST_WFAU_INTF_DEBRIEF_CSTAT")
                myCMD.Parameters.AddWithValue("PS_INSERT_UPDATE", "INSERT")
            Else
                myCMD.Parameters.AddWithValue("ps_table", "XXQST_WFA_INTERFACE")
                myCMD.Parameters.AddWithValue("PS_INSERT_UPDATE", "UPDATE")
            End If

            Dim int As Integer = myCMD.ExecuteNonQuery()




            Oraclecon.Close()
            If tablename.Equals("WFA_DEBREIF") And Stop_Flag = False Then
                Flag = 1
                GoTo lbl
            End If
        Catch ex As Exception

            p_objLogger.writenote("Exception: :-" & ex.ToString(), objordets.Task_Id, EventLogEntryType.Error)
        End Try
    End Function
    Function sendResponse_Ticket(ByVal objordet As OrderDetails, ByRef Response As String, ByVal tablename As String)
        Try
            If (tablename.Equals("WFA_INTERFACE")) Then
                Dim x As Exception
                Dim Ds As New DataSet()
                Dim Stop_Flag As Boolean = False
                Dim Oraclecon As New OracleConnection("Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=cpepdb1.qintra.com)(PORT=1521))(CONNECT_DATA=(SID=CPEP)));User Id=xxcpewfa;Password=cpewfa_1213;")
                'Dim oradb As String = "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=cpepdb1.qintra.com)(PORT=1521))(CONNECT_DATA=(SID=CPEP)));User Id=xxcpewfa;Password=cpewfa_1213;"

                Oraclecon.Open()
                Dim param1 As New OracleParameter
                Dim param2 As New OracleParameter
                Dim myCMD As New OracleCommand()
                Dim xml_tag As String = ""
                myCMD.Connection = Oraclecon
                Dim Flag As Integer
                myCMD.CommandType = CommandType.StoredProcedure

                'WFA_INTERFACE
                If Response = 1 Then
                    xml_tag = "<ROWSET><ROW num='1'><TASK_ID>" + objordet.Task_Id + "</TASK_ID><MSG_STATUS>WFA_PICKED</MSG_STATUS></ROW></ROWSET>"
                    'xml_tag = "<ROWSET><ROW num='1'><TASK_ID>1010069</TASK_ID><WFAI_JSTAT>CMP</WFAI_JSTAT><MSG_STATUS>ORACLE_READY</MSG_STATUS><WFAI_DEBRIEF_COMMENTS>ASSIGNED TECH-112 TECH CUID:DESPERS FIRSTNAME:DANIEL LASTNAME:ESPERSON TECH ASSIGNED DATE:110713  RESOLVE BY DATE:111313 0500P SCHEDULED START DATE:111113 0500P.TEST TO INSTALL 3 SETS - T&M LABOR EST 1.5 HRS.8014668783, TRAVIS BRADFORD</WFAI_DEBRIEF_COMMENTS></ROW></ROWSET>"
                ElseIf Response = -1 Then
                    xml_tag = "<ROWSET><ROW num='1'><TASK_ID>" + objordet.Task_Id + "</TASK_ID><MSG_STATUS>WFA_ERROR</MSG_STATUS><MSG_ERROR>CENTER/WC NOT AVAILABLE</MSG_ERROR></ROW></ROWSET>"
                ElseIf Response = 2 Then

                    'Ticket Created 
                    xml_tag = "<ROWSET><ROW num='1'><TASK_ID>" + objordet.Task_Id + "</TASK_ID><WFAI_JSTAT>PLD</WFAI_JSTAT><WFAO_JT>" + objordet.WFAO_JT + "</WFAO_JT><WFAI_DEBRIEF_COMMENTS>TICKET CREATED.TECH NEEDS TO BE ASSIGNED.</WFAI_DEBRIEF_COMMENTS><MSG_STATUS>ORACLE_READY</MSG_STATUS></ROW></ROWSET>"
                ElseIf Response = -2 Then
                    'Unable to create Ticket 
                    xml_tag = "<ROWSET><ROW num='1'><TASK_ID>" + objordet.Task_Id + "</TASK_ID><MSG_STATUS>WFA_ERROR</MSG_STATUS><MSG_ERROR>" + objordets.MSG_ERROR + "</MSG_ERROR></ROW></ROWSET>"
                ElseIf Response = 3 Then
                    'Tech Details

                    If objordet.WFAO_JOBID.Contains("I") Then
                        xml_tag = "<ROWSET><ROW num='1'><TASK_ID>" + objordet.Task_Id + "</TASK_ID><WFAI_JSTAT>" + objordet.WFAI_JSTAT + "</WFAI_JSTAT><WFAI_DEBRIEF_COMMENTS>" + objordet.WFAI_DEBRIEF_COMMENTS + "</WFAI_DEBRIEF_COMMENTS><MSG_STATUS>ORACLE_READY</MSG_STATUS></ROW></ROWSET>"
                    Else
                        xml_tag = "<ROWSET><ROW num='1'><TASK_ID>" + objordet.Task_Id + "</TASK_ID><WFAI_JSTAT>" + objordet.WFAI_JSTAT + "</WFAI_JSTAT><WFAI_DEBRIEF_COMMENTS>" + objordet.WFAI_DEBRIEF_COMMENTS + "</WFAI_DEBRIEF_COMMENTS><MSG_STATUS>ORACLE_READY</MSG_STATUS></ROW></ROWSET>"
                    End If
                ElseIf Response = -3 Then
                    If objordet.WFAO_JOBID.Contains("I") Then
                        xml_tag = "<ROWSET><ROW num='1'><TASK_ID>" + objordet.Task_Id + "</TASK_ID><WFAI_JSTAT>" + objordet.WFAI_JSTAT + "</WFAI_JSTAT><WFAI_DEBRIEF_COMMENTS>" + objordet.WFAI_DEBRIEF_COMMENTS + "</WFAI_DEBRIEF_COMMENTS><MSG_STATUS>ORACLE_READY</MSG_STATUS></ROW></ROWSET>"
                    Else


                        xml_tag = "<ROWSET><ROW num='1'><TASK_ID>" + objordet.Task_Id + "</TASK_ID><WFAI_JSTAT>" + objordet.WFAI_JSTAT + "</WFAI_JSTAT><WFAI_DEBRIEF_COMMENTS>" + objordet.WFAI_DEBRIEF_COMMENTS + "</WFAI_DEBRIEF_COMMENTS><MSG_STATUS>ORACLE_READY</MSG_STATUS></ROW></ROWSET>"
                        ' xml_tag = "<ROWSET><ROW num='1'><TASK_ID>1010069</TASK_ID><WFAI_JSTAT>PRE</WFAI_JSTAT><MSG_STATUS>ORACLE_READY</MSG_STATUS></ROW></ROWSET>"
                    End If



                ElseIf Response = 4 Then
                    'Update Scduele date
                    If objordet.WFAO_JOBID.Contains("I") Then
                        xml_tag = "<ROWSET><ROW num='1'><TASK_ID>" + objordet.Task_Id + "</TASK_ID><WFAI_JSTAT>" + objordet.WFAI_JSTAT + "</WFAI_JSTAT><WFAI_DEBRIEF_COMMENTS>" + objordet.WFAI_DEBRIEF_COMMENTS + "</WFAI_DEBRIEF_COMMENTS><MSG_STATUS>ORACLE_READY</MSG_STATUS></ROW></ROWSET>"
                    Else

                        xml_tag = "<ROWSET><ROW num='1'><TASK_ID>" + objordet.Task_Id + "</TASK_ID><WFAI_JSTAT>" + objordet.WFAI_JSTAT + "</WFAI_JSTAT><WFAI_DEBRIEF_COMMENTS>" + objordets.WFAI_DEBRIEF_COMMENTS + "</WFAI_DEBRIEF_COMMENTS><MSG_STATUS>ORACLE_READY</MSG_STATUS></ROW></ROWSET>"
                    End If

                ElseIf Response = -4 Then
                    xml_tag = "<ROWSET><ROW num='1'><TASK_ID>" + objordet.Task_Id + "</TASK_ID><MSG_ERROR>" + objordets.MSG_ERROR + "</MSG_ERROR><WFAI_JSTAT>" + objordet.WFAI_JSTAT + "</WFAI_JSTAT><MSG_STATUS>WFA_ERROR</MSG_STATUS></ROW></ROWSET>"
                ElseIf Response = 5 Then
                    'cancel response
                    xml_tag = "<ROWSET><ROW num='1'><TASK_ID>" + objordet.Task_Id + "</TASK_ID><WFAI_JSTAT>CAN</WFAI_JSTAT><MSG_STATUS>ORACLE_READY</MSG_STATUS></ROW></ROWSET>"
                ElseIf Response = -5 Then
                    'CANNOT BE CANCELLED
                    xml_tag = "<ROWSET><ROW num='1'><TASK_ID>" + objordet.Task_Id + "</TASK_ID><MSG_ERROR>" + objordet.MSG_ERROR + "</MSG_ERROR><MSG_STATUS>WFA_ERROR</MSG_STATUS></ROW></ROWSET>"


                ElseIf Response = 6 Then


                    'Replacing the characters for debrief 

                    objordet.WFAI_DEBRIEF_COMMENTS = objordet.WFAI_DEBRIEF_COMMENTS.Replace("&", "&amp;")
                    objordet.WFAI_DEBRIEF_COMMENTS = objordet.WFAI_DEBRIEF_COMMENTS.Replace("<", "&lt;")
                    objordet.WFAI_DEBRIEF_COMMENTS = objordet.WFAI_DEBRIEF_COMMENTS.Replace(ControlChars.Quote, "&quot;")
                    objordet.WFAI_DEBRIEF_COMMENTS = objordet.WFAI_DEBRIEF_COMMENTS.Replace("'", "&apos;")

                    'Final Response
                    xml_tag = "<ROWSET><ROW num='1'><TASK_ID>" + objordet.Task_Id + "</TASK_ID><WFAI_JSTAT>CMP</WFAI_JSTAT><MSG_STATUS>ORACLE_READY</MSG_STATUS><WFAI_DEBRIEF_COMMENTS>" + objordet.WFAI_DEBRIEF_COMMENTS + "</WFAI_DEBRIEF_COMMENTS></ROW></ROWSET>"
                    'xml_tag = "<ROWSET><ROW num='1'><TASK_ID>1013409</TASK_ID><WFAI_JSTAT>CMP</WFAI_JSTAT><MSG_STATUS>ORACLE_READY</MSG_STATUS><WFAI_DEBRIEF_COMMENTS>PHONES MOVED               - URGENT FOR MON 11/18:  T&amp;M LABOR.  MOVE 2 PHONES 3034518001, RANDY WELLER</WFAI_DEBRIEF_COMMENTS></ROW></ROWSET>"
                ElseIf Response = -6 Then
                    xml_tag = "<ROWSET><ROW num='1'><TASK_ID>" + objordet.Task_Id + "</TASK_ID><WFAI_JSTAT>CMP</WFAI_JSTAT><MSG_STATUS>WFA_ERROR</MSG_STATUS><WFAI_DEBRIEF_COMMENTS>" + objordet.WFAI_DEBRIEF_COMMENTS + "</WFAI_DEBRIEF_COMMENTS><MSG_ERROR>INCORRECT DEBRIEF</MSG_ERROR></ROW></ROWSET>"
                ElseIf Response = 7 Then
                    xml_tag = "<ROWSET><ROW num='1'><TASK_ID>" + objordet.Task_Id + "</TASK_ID><WFAI_JSTAT>" + objordet.WFAI_JSTAT + "</WFAI_JSTAT><WFAI_DEBRIEF_COMMENTS>TICKET CANCELLED</WFAI_DEBRIEF_COMMENTS><MSG_STATUS>ORACLE_READY</MSG_STATUS></ROW></ROWSET>"
                End If

                'DEBRIEF



                param1.Value = xml_tag
                param1.ParameterName = "PS_XML_DATA"
                myCMD.Parameters.Add(param1)


                'param1.Value = xml_tag
                param2.ParameterName = "PS_XML_OUT_DATA"
                param2.Size = 500
                param2.Direction = ParameterDirection.Output
                myCMD.Parameters.Add(param2)
                myCMD.CommandText = "APPS.XXQST_WFA_XML_UPDATE_PKG.UPDATE_INS_WFA_DATA_WITH_XML"
                myCMD.Parameters.Add("ps_table", "XXQST_WFA_INTERFACE")
                myCMD.Parameters.Add("PS_INSERT_UPDATE", "UPDATE")
                Dim int As Integer = myCMD.ExecuteNonQuery()
                Oraclecon.Close()
                If int = 0 Then

                Else

                End If

            ElseIf (tablename.Equals("WFA_DEBRIEF")) And Response = 7 Then
                'objordet.Dolog_Comment = "L-DISP-200, E-LUNCH-50,INSTALL-CPE-IR1"
                'Selecet Debrief from INTERNAL DATABASE

                Dim Dedrief_ds As New DataSet

                Dim ex As New Exception
                Dim i As Integer = 0


                Dim objDbutility As New DBUtilities.DBConnect
                objDbutility = SQLDBUtil()
                Dim StrSelectQuery As String

                StrSelectQuery = "Select * from [OracleCPE].[dbo].[DEBRIEF_TABLE] where [TASK_ID]='" + objordet.Task_Id + "'"

                Dedrief_ds = objDbutility.SelectQuery([Global].p_sCPE_NOTIFIERDB, StrSelectQuery, ex, Nothing)

                If Dedrief_ds.Tables(0).Rows.Count > 0 Then
                    For i = 0 To Dedrief_ds.Tables(0).Rows.Count - 1
                        Dim x As Exception
                        Dim Ds As New DataSet()
                        Dim Stop_Flag As Boolean = False
                        'Dim Oraclecon As New OleDbConnection("Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=prdstgdb.dev.qintra.com)(PORT=1529))(CONNECT_DATA=(SID=PRDSTG)));Provider=OraOLEDB.Oracle;User Id=xxcpewfa;Password=cpewfa_1213;")
                        Dim Oraclecon As New OracleConnection("Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=cpepdb1.qintra.com)(PORT=1521))(CONNECT_DATA=(SID=CPEP)));User Id=xxcpewfa;Password=cpewfa_1213;")

                        Oraclecon.Open()
                        Dim param1 As New OracleParameter
                        Dim param2 As New OracleParameter
                        Dim myCMD As New OracleCommand()
                        Dim xml_tag As String = ""
                        myCMD.Connection = Oraclecon
                        Dim Flag As Integer
                        myCMD.CommandType = CommandType.StoredProcedure



                        ' xml_tag = "<ROWSET><ROW num='1'><TASK_ID>1010090</TASK_ID><WFAI_JSTAT>CMP</WFAI_JSTAT><MSG_STATUS>ORACLE_READY</MSG_STATUS><WFAI_DEBRIEF_COMMENTS>TEST TO INSTALL 3 SETS - T&M LABOR EST 1.5 HRS.8014668783,TRAVIS BRADFORD</WFAI_DEBRIEF_COMMENTS></ROW></ROWSET>"
                        xml_tag = "<ROWSET><ROW num='1'><TASK_ID>" & Dedrief_ds.Tables(0).Rows(i)(0) & "</TASK_ID><WFAI_DEBRIEF_NUMBER>" & Dedrief_ds.Tables(0).Rows(i)(10) & "</WFAI_DEBRIEF_NUMBER><WFAI_DOCOMP_STATUS>" & Dedrief_ds.Tables(0).Rows(i)(1) & "</WFAI_DOCOMP_STATUS><WFAI_DOCOMP_ITEM>" & Dedrief_ds.Tables(0).Rows(i)(4) & "</WFAI_DOCOMP_ITEM><WFAI_DOCOMP_LAB_EXP>" & Dedrief_ds.Tables(0).Rows(i)(5) & "</WFAI_DOCOMP_LAB_EXP><WFAI_DOCOMP_HOURS>" & Dedrief_ds.Tables(0).Rows(i)(3) & "</WFAI_DOCOMP_HOURS><WFAI_DOCOMP_REASON_CODE>" & Dedrief_ds.Tables(0).Rows(i)(2) & "</WFAI_DOCOMP_REASON_CODE><MSG_STATUS>ORACLE_READY</MSG_STATUS><WFAI_JOB_STRTD>" & Dedrief_ds.Tables(0).Rows(i)(7) & "</WFAI_JOB_STRTD></ROW></ROWSET>"
                        ' xml_tag = "<ROWSET><ROW num='1'><TASK_ID>1010090</TASK_ID><WFAI_DEBRIEF_NUMBER>1</WFAI_DEBRIEF_NUMBER><WFAI_DOCOMP_STATUS>CMP</WFAI_DOCOMP_STATUS><WFAI_DOCOMP_ITEM>INSTALL-CPE-IR1</WFAI_DOCOMP_ITEM><WFAI_DOCOMP_LAB_EXP>L</WFAI_DOCOMP_LAB_EXP><WFAI_DOCOMP_HOURS>008:00</WFAI_DOCOMP_HOURS><WFAI_DOCOMP_REASON_CODE>SITE</WFAI_DOCOMP_REASON_CODE><MSG_STATUS>ORACLE_READY</MSG_STATUS><WFAI_JOB_STRTD>11/11/2013 06:00:00 AM</WFAI_JOB_STRTD></ROW></ROWSET>"
                        param1.Value = xml_tag
                        param1.ParameterName = "PS_XML_DATA"
                        myCMD.Parameters.Add(param1)



                        param2.ParameterName = "PS_XML_OUT_DATA"
                        param2.Size = 500
                        param2.Direction = ParameterDirection.Output
                        myCMD.Parameters.Add(param2)
                        myCMD.CommandText = "APPS.XXQST_WFA_XML_UPDATE_PKG.UPDATE_INS_WFA_DATA_WITH_XML"


                        ' myCMD.Parameters.AddWithValue("ps_table", "XXQST_WFA_INTERFACE")
                        ' myCMD.Parameters.AddWithValue("PS_INSERT_UPDATE", "UPDATE")
                        myCMD.Parameters.Add("ps_table", "XXQST_WFAU_INTF_DEBRIEF_CSTAT")
                        myCMD.Parameters.Add("PS_INSERT_UPDATE", "INSERT")

                        Dim int As Integer = myCMD.ExecuteNonQuery()

                        Oraclecon.Close()

                    Next

                End If

            End If







        Catch ex As Exception

            p_objLogger.writenote("Exception: :-" & ex.ToString(), objordets.Task_Id, EventLogEntryType.Error)
        End Try
    End Function



    Function getTechValues(ByRef ObjOrdets As OrderDetails)
        Try


            Dim excep As Exception = Nothing
            Dim objQueryFleHndlr As New FileHandler.INIFileHandler(p_sCPE_NotifierIni)
            Dim param(1) As Object
            Dim strErrMsg As String = ""
            Dim oradb As String = System.Configuration.ConfigurationManager.ConnectionStrings("ConnstrWstor").ConnectionString
            Dim conn As New OracleConnection(oradb)
            Dim oadapter2 As OracleDataAdapter
            Dim oreader2 As OracleDataReader
            Dim ToAddress As String = ""

            conn.Open()
            'Dim strQuery5 As String = "select * from tech_id where center='' and tech_ec='C14'"
            Dim strQuery5 As String = "select * from tech_id where center='" + ObjOrdets.WFAO_CENTER_TECH.Trim + "' and tech_ec='" + ObjOrdets.Tech_Ec.Trim + "'"
            Dim objCommand As New OracleCommand(strQuery5, conn)
            oreader2 = objCommand.ExecuteReader()

            oadapter2 = New OracleDataAdapter(strQuery5, conn)
            Dim ds As DataSet = New DataSet()
            oadapter2.Fill(ds)

            If ds.Tables(0).Rows.Count > 0 Then
                If Not ds.Tables(0) Is Nothing Then
                    For rowindex As Integer = 0 To ds.Tables(0).Rows.Count - 1
                        ObjOrdets.CUID = ds.Tables(0).Rows(0)(3).ToString
                        ObjOrdets.Tech_Last_Name = ds.Tables(0).Rows(0)(4).ToString
                        ObjOrdets.Tech_First_Name = ds.Tables(0).Rows(0)(5).ToString
                    Next

                End If

            End If
            conn.Close()
            Return ObjOrdets
        Catch ex As Exception
            p_objLogger.writenote("Exception: :-" & ex.ToString(), ObjOrdets.Task_Id, EventLogEntryType.Error)
        End Try
    End Function

    Private Function Insert_Debrief_Table(ByVal objordets As Object)
        Try
            Dim objDbutility As New DBUtilities.DBConnect
            objDbutility = SQLDBUtil()

            Dim objInsert As New Object

            Dim ex1 As Exception = Nothing

            Dim e As Exception

            Dim strInputQuery As String
            Dim objQueryFleHndlr As New FileHandler.INIFileHandler(p_sCPE_NotifierIni)
            Dim irow As New DataSet
            'have to write based on the status of Debrief
            If objordets.Debrief_Entries = "L" Then
                'Insert one row
            ElseIf objordets.Debrief_Entries = "L+E" Then
                'Insert two rows

            ElseIf objordets.Debrief_Entries = "L+E+B" Then
                'Insert_Debrief two rows with billable value

            End If
            objInsert = Array.CreateInstance(GetType(Object), 11)
            If Not objordets.D_Task_ID = Nothing Then
                If (objordets.D_Task_ID.ToString.Length = 0) Then
                    objordets.D_Task_ID = DBNull.Value.ToString
                End If
            Else
                objordets.D_Task_ID = DBNull.Value.ToString

            End If
            If Not objordets.D_WFAI_DOCOMP_STATUS = Nothing Then
                If (objordets.D_WFAI_DOCOMP_STATUS.ToString.Length = 0) Then
                    objordets.D_WFAI_DOCOMP_STATUS = DBNull.Value.ToString
                End If
            Else
                objordets.D_WFAI_DOCOMP_STATUS = DBNull.Value.ToString

            End If
            If Not objordets.D_WFAI_DOCOMP_REASON_CODE = Nothing Then
                If (objordets.D_WFAI_DOCOMP_REASON_CODE.ToString.Length = 0) Then
                    objordets.D_WFAI_DOCOMP_REASON_CODE = DBNull.Value.ToString
                End If
            Else
                objordets.D_WFAI_DOCOMP_REASON_CODE = DBNull.Value.ToString

            End If
            If Not objordets.D_WFAI_DOCOMP_HOURS = Nothing Then
                If (objordets.D_WFAI_DOCOMP_HOURS.ToString.Length = 0) Then
                    objordets.D_WFAI_DOCOMP_HOURS = DBNull.Value.ToString
                End If
            Else
                objordets.D_WFAI_DOCOMP_HOURS = DBNull.Value.ToString

            End If
            If Not objordets.D_WFAI_DOCOMP_ITEM = Nothing Then
                If (objordets.D_WFAI_DOCOMP_ITEM.ToString.Length = 0) Then
                    objordets.D_WFAI_DOCOMP_ITEM = DBNull.Value.ToString
                End If
            Else
                objordets.D_WFAI_DOCOMP_ITEM = DBNull.Value.ToString

            End If
            If Not objordets.D_WFAI_DOCOMP_LAB_EXP = Nothing Then
                If (objordets.D_WFAI_DOCOMP_LAB_EXP.ToString.Length = 0) Then
                    objordets.D_WFAI_DOCOMP_LAB_EXP = DBNull.Value.ToString
                End If
            Else
                objordets.D_WFAI_DOCOMP_LAB_EXP = DBNull.Value.ToString

            End If
            If Not objordets.D_WFAI_DOCOMP_5 = Nothing Then
                If (objordets.D_WFAI_DOCOMP_5.ToString.Length = 0) Then
                    objordets.D_WFAI_DOCOMP_5 = DBNull.Value.ToString
                End If
            Else
                objordets.D_WFAI_DOCOMP_5 = DBNull.Value.ToString

            End If
            If Not objordets.D_WFAI_JOB_STRTD = Nothing Then
                If (objordets.D_WFAI_JOB_STRTD.ToString.Length = 0) Then
                    objordets.D_WFAI_JOB_STRTD = DBNull.Value.ToString
                End If
            Else
                objordets.D_WFAI_JOB_STRTD = DBNull.Value.ToString

            End If
            If Not objordets.D_MSG_STATUS = Nothing Then
                If (objordets.D_MSG_STATUS.ToString.Length = 0) Then
                    objordets.D_MSG_STATUS = DBNull.Value.ToString
                End If
            Else
                objordets.D_MSG_STATUS = DBNull.Value.ToString

            End If
            If Not objordets.D_MSG_ERROR = Nothing Then
                If (objordets.D_MSG_ERROR.ToString.Length = 0) Then
                    objordets.D_MSG_ERROR = DBNull.Value.ToString
                End If
            Else
                objordets.D_MSG_ERROR = DBNull.Value.ToString

            End If
            If Not objordets.D_WFAI_DEBRIEF_NUMBER = Nothing Then
                If (objordets.D_WFAI_DEBRIEF_NUMBER.ToString.Length = 0) Then
                    objordets.D_WFAI_DEBRIEF_NUMBER = DBNull.Value.ToString
                End If
            Else
                objordets.D_WFAI_DEBRIEF_NUMBER = DBNull.Value.ToString

            End If

            objInsert.SetValue(objordets.D_Task_ID, 0)
            objInsert.SetValue(objordets.D_WFAI_DOCOMP_STATUS, 1) 'have to add param
            objInsert.SetValue(objordets.D_WFAI_DOCOMP_REASON_CODE, 2) 'have to add param
            objInsert.SetValue(objordets.D_WFAI_DOCOMP_HOURS, 3)
            objInsert.SetValue(objordets.D_WFAI_DOCOMP_ITEM, 4)
            objInsert.SetValue(objordets.D_WFAI_DOCOMP_LAB_EXP, 5)
            objInsert.SetValue(objordets.D_WFAI_DOCOMP_5, 6)
            objInsert.SetValue(objordets.D_WFAI_JOB_STRTD, 7)
            objInsert.SetValue(objordets.D_MSG_STATUS, 8)
            objInsert.SetValue(objordets.D_MSG_ERROR, 9)
            objInsert.SetValue(objordets.D_WFAI_DEBRIEF_NUMBER, 10)
            strInputQuery = "INSERT INTO [OracleCPE].[dbo].[DEBRIEF_TABLE] ([TASK_ID],[WFAI_DOCOMP_STATUS],[WFAI_DOCOMP_REASON_CODE],[WFAI_DOCOMP_HOURS],[WFAI_DOCOMP_ITEM],[WFAI_DOCOMP_LAB_EXP],[WFAI_DOCOMP_5],[WFAI_JOB_STRTD],[MSG_STATUS],[MSG_ERROR],[WFAI_DEBRIEF_NUMBER]) values(?,?,?,?,?,?,?,?,?,?,?)"

            objDbutility.InsertQuery([Global].p_sCPE_NOTIFIERDB, strInputQuery, ex1, objInsert)
        Catch ex As Exception
            p_objLogger.writenote("Exception: :-" & ex.ToString(), objordets.Task_Id, EventLogEntryType.Error)
        End Try
    End Function
    Function BK_InsertInputHeader(ByVal objordets As Object)

        Try
            Dim objDbutility As New DBUtilities.DBConnect
            objDbutility = SQLDBUtil()
            objDbutility.DB_SERVER_NAME = "CTOMASQL2SQL1\SQL_INSTANCE1,7115"

            'Dim objInsert() As Object
            Dim objInsert As New Object
            'Dim objInsert As Object = Nothing
            Dim ex1 As Exception = Nothing
            'Dim ex1 As New Exception
            Dim e As Exception
            'Dim exp As Exception
            Dim strInputQuery As String
            Dim objQueryFleHndlr As New FileHandler.INIFileHandler(p_sCPE_NotifierIni)
            Dim irow As New DataSet
            objInsert = Array.CreateInstance(GetType(Object), 66)
            If Not objordets.Task_Id = Nothing Then
                If (objordets.Task_Id.ToString.Length = 0) Then
                    objordets.Task_Id = DBNull.Value.ToString
                End If
            Else
                objordets.Task_Id = DBNull.Value.ToString

            End If
            If Not objordets.Incident_Id = Nothing Then
                If (objordets.Incident_Id.ToString.Length = 0) Then
                    objordets.Incident_Id = DBNull.Value.ToString
                End If
            Else
                objordets.Incident_Id = DBNull.Value.ToString
            End If
            If Not objordets.Task_Number = Nothing Then
                If (objordets.Task_Number.ToString.Length = 0) Then
                    objordets.Task_Number = DBNull.Value.ToString
                End If
            Else
                objordets.Task_Number = DBNull.Value.ToString

            End If

            If Not objordets.Incident_Number = Nothing Then
                If (objordets.Incident_Number.Length = 0) Then
                    objordets.Incident_Number = DBNull.Value.ToString
                End If
            Else
                objordets.Incident_Number = DBNull.Value.ToString

            End If
            If Not objordets.WFAO_CENTER = Nothing Then
                If (objordets.WFAO_CENTER.ToString.Length = 0) Then
                    objordets.WFAO_CENTER = DBNull.Value.ToString
                End If
            Else
                objordets.WFAO_CENTER = DBNull.Value.ToString
            End If
            If Not objordets.WFAO_JOBID = Nothing Then
                If (objordets.WFAO_JOBID.ToString.Length = 0) Then
                    objordets.WFAO_JOBID = DBNull.Value.ToString
                End If
            Else
                objordets.WFAO_JOBID = DBNull.Value.ToString
            End If
            If Not objordets.WFAI_JSTAT = Nothing Then
                If (objordets.WFAI_JSTAT.ToString.Length = 0) Then
                    objordets.WFAI_JSTAT = DBNull.Value.ToString
                End If
            Else
                objordets.WFAI_JSTAT = DBNull.Value.ToString
            End If
            If Not objordets.WFAO_JT = Nothing Then

                If (objordets.WFAO_JT.ToString.Length = 0) Then
                    objordets.WFAO_JT = DBNull.Value.ToString
                End If
            Else
                objordets.WFAO_JT = DBNull.Value.ToString
            End If
            If Not objordets.WFAO_CKTID = Nothing Then
                If (objordets.WFAO_CKTID.ToString.Length = 0) Then
                    objordets.WFAO_CKTID = DBNull.Value.ToString
                End If
            Else
                objordets.WFAO_CKTID = DBNull.Value.ToString
            End If
            If Not objordets.WFAO_POM = Nothing Then
                If (objordets.WFAO_POM.ToString.Length = 0) Then
                    objordets.WFAO_POM = DBNull.Value.ToString
                End If
            Else
                objordets.WFAO_POM = DBNull.Value.ToString
            End If
            If Not objordets.WFAO_PON = Nothing Then
                If (objordets.WFAO_PON.ToString.Length = 0) Then
                    objordets.WFAO_PON = DBNull.Value.ToString
                End If
            Else
                objordets.WFAO_PON = DBNull.Value.ToString
            End If
            If Not objordets.WFAO_BILLNAME = Nothing Then
                If (objordets.WFAO_BILLNAME.ToString.Length = 0) Then
                    objordets.WFAO_BILLNAME = DBNull.Value.ToString
                End If
            Else
                objordets.WFAO_BILLNAME = DBNull.Value.ToString
            End If
            If Not objordets.WFAO_TELEPHONE = Nothing Then
                If (objordets.WFAO_TELEPHONE.ToString.Length = 0) Then
                    objordets.WFAO_TELEPHONE = DBNull.Value.ToString
                End If
            Else
                objordets.WFAO_TELEPHONE = DBNull.Value.ToString
            End If
            If Not objordets.WFAO_WC = Nothing Then
                If (objordets.WFAO_WC.ToString.Length = 0) Then
                    objordets.WFAO_WC = DBNull.Value.ToString
                End If
            Else
                objordets.WFAO_WC = DBNull.Value.ToString
            End If
            If Not objordets.WFAO_RTE = Nothing Then
                If (objordets.WFAO_RTE.ToString.Length = 0) Then
                    objordets.WFAO_RTE = DBNull.Value.ToString
                End If
            Else
                objordets.WFAO_RTE = DBNull.Value.ToString

            End If
            If Not objordets.WFAO_DAA = Nothing Then
                If (objordets.WFAO_DAA.ToString.Length = 0) Then
                    objordets.WFAO_DAA = DBNull.Value.ToString
                End If
            Else
                objordets.WFAO_DAA = DBNull.Value.ToString

            End If
            If Not objordets.WFAO_AA = Nothing Then
                If (objordets.WFAO_AA.ToString.Length = 0) Then
                    objordets.WFAO_AA = DBNull.Value.ToString
                End If
            Else
                objordets.WFAO_AA = DBNull.Value.ToString
            End If
            If Not objordets.WFAO_ACT = Nothing Then
                If (objordets.WFAO_ACT.ToString.Length = 0) Then
                    objordets.WFAO_ACT = DBNull.Value.ToString
                End If
            Else
                objordets.WFAO_ACT = DBNull.Value.ToString
            End If
            If Not objordets.WFAO_CKLNAME = Nothing Then
                If (objordets.WFAO_CKLNAME.ToString.Length = 0) Then
                    objordets.WFAO_CKLNAME = DBNull.Value.ToString
                End If
            Else
                objordets.WFAO_CKLNAME = DBNull.Value.ToString
            End If
            If Not objordets.WFAO_CKLADDR = Nothing Then
                If (objordets.WFAO_CKLADDR.ToString.Length = 0) Then
                    objordets.WFAO_CKLADDR = DBNull.Value.ToString
                End If
            Else
                objordets.WFAO_CKLADDR = DBNull.Value.ToString

            End If
            If Not objordets.WFAO_COMM = Nothing Then
                If (objordets.WFAO_COMM.ToString.Length = 0) Then
                    objordets.WFAO_COMM = DBNull.Value.ToString
                End If
            Else
                objordets.WFAO_COMM = DBNull.Value.ToString

            End If
            If Not objordets.WFAO_START_DATE = Nothing Then
                If (objordets.WFAO_START_DATE.ToString.Length = 0) Then
                    objordets.WFAO_START_DATE = DBNull.Value.ToString
                End If
            Else
                objordets.WFAO_START_DATE = DBNull.Value.ToString

            End If
            If Not objordets.WFAO_ACC = Nothing Then
                If (objordets.WFAO_ACC.ToString.Length = 0) Then
                    objordets.WFAO_ACC = DBNull.Value.ToString
                End If
            Else
                objordets.WFAO_ACC = DBNull.Value.ToString

            End If
            If Not objordets.WFAO_A = Nothing Then
                If (objordets.WFAO_A.ToString.Length = 0) Then
                    objordets.WFAO_A = DBNull.Value.ToString
                End If
            Else
                objordets.WFAO_A = DBNull.Value.ToString

            End If
            If Not objordets.WFAO_B = Nothing Then
                If (objordets.WFAO_B.ToString.Length = 0) Then
                    objordets.WFAO_B = DBNull.Value.ToString
                End If
            Else
                objordets.WFAO_B = DBNull.Value.ToString

            End If
            If Not objordets.WFAO_DD = Nothing Then
                If (objordets.WFAO_DD.ToString.Length = 0) Then
                    objordets.WFAO_DD = DBNull.Value.ToString
                End If
            Else
                objordets.WFAO_DD = DBNull.Value.ToString

            End If
            If Not objordets.WFAO_PRC = Nothing Then
                If (objordets.WFAO_PRC.ToString.Length = 0) Then
                    objordets.WFAO_PRC = DBNull.Value.ToString
                End If
            Else
                objordets.WFAO_PRC = DBNull.Value.ToString

            End If
            If Not objordets.WFAO_TPRC = Nothing Then
                If (objordets.WFAO_TPRC.ToString.Length = 0) Then
                    objordets.WFAO_TPRC = DBNull.Value.ToString
                End If
            Else
                objordets.WFAO_TPRC = DBNull.Value.ToString

            End If
            If Not objordets.WFAO_ORD_ORIG = Nothing Then
                If (objordets.WFAO_ORD_ORIG.ToString.Length = 0) Then
                    objordets.WFAO_ORD_ORIG = DBNull.Value.ToString
                End If
            Else
                objordets.WFAO_ORD_ORIG = DBNull.Value.ToString

                If Not objordets.WFAO_SVY = Nothing Then
                    If (objordets.WFAO_SVY.ToString.Length = 0) Then
                        objordets.WFAO_SVY = DBNull.Value.ToString
                    End If
                Else
                    objordets.WFAO_SVY = DBNull.Value.ToString

                    If Not objordets.WFAO_PST = Nothing Then
                        If (objordets.WFAO_PST.ToString.Length = 0) Then
                            objordets.WFAO_PST = DBNull.Value.ToString
                        End If
                    Else
                        objordets.WFAO_PST = DBNull.Value.ToString

                    End If
                    If Not objordets.WFAO_COMMENT_SUBJECT = Nothing Then
                        If (objordets.WFAO_COMMENT_SUBJECT.ToString.Length = 0) Then
                            objordets.WFAO_COMMENT_SUBJECT = DBNull.Value.ToString
                        End If
                    Else
                        objordets.WFAO_COMMENT_SUBJECT = DBNull.Value.ToString

                    End If
                    If Not objordets.WFAO_COMMENT_URGENCY = Nothing Then
                        If (objordets.WFAO_COMMENT_URGENCY.ToString.Length = 0) Then
                            objordets.WFAO_COMMENT_URGENCY = DBNull.Value.ToString
                        End If
                    Else
                        objordets.WFAO_COMMENT_URGENCY = DBNull.Value.ToString

                    End If
                    If Not objordets.WFAO_JOBPRI = Nothing Then
                        If (objordets.WFAO_JOBPRI.ToString.Length = 0) Then
                            objordets.WFAO_JOBPRI = DBNull.Value.ToString
                        End If
                    Else
                        objordets.WFAO_JOBPRI = DBNull.Value.ToString

                    End If
                    If Not objordets.WFAO_FACILITY_LABEL = Nothing Then
                        If (objordets.WFAO_FACILITY_LABEL.ToString.Length = 0) Then
                            objordets.WFAO_FACILITY_LABEL = DBNull.Value.ToString
                        End If
                    Else
                        objordets.WFAO_FACILITY_LABEL = DBNull.Value.ToString

                    End If
                    If Not objordets.WFAO_F1 = Nothing Then
                        If (objordets.WFAO_F1.ToString.Length = 0) Then
                            objordets.WFAO_F1 = DBNull.Value.ToString
                        End If
                    Else
                        objordets.WFAO_F1 = DBNull.Value.ToString

                    End If
                    If Not objordets.WFAO_PR = Nothing Then
                        If (objordets.WFAO_PR.ToString.Length = 0) Then
                            objordets.WFAO_PR = DBNull.Value.ToString
                        End If
                    Else
                        objordets.WFAO_PR = DBNull.Value.ToString

                    End If
                    If Not objordets.WFAO_JOB = Nothing Then
                        If (objordets.WFAO_JOB.ToString.Length = 0) Then
                            objordets.WFAO_JOB = DBNull.Value.ToString
                        End If
                    Else
                        objordets.WFAO_JOB = DBNull.Value.ToString

                        If Not objordets.WFAO_SCRACHPAD_TASK_DESC = Nothing Then
                            If (objordets.WFAO_SCRACHPAD_TASK_DESC.ToString.Length = 0) Then
                                objordets.WFAO_SCRACHPAD_TASK_DESC = DBNull.Value.ToString
                            End If
                        Else
                            objordets.WFAO_SCRACHPAD_TASK_DESC = DBNull.Value.ToString

                            If Not objordets.WFAO_DOCOMM_1 = Nothing Then
                                If (objordets.WFAO_DOCOMM_1.ToString.Length = 0) Then
                                    objordets.WFAO_DOCOMM_1 = DBNull.Value.ToString
                                End If
                            Else
                                objordets.WFAO_DOCOMM_1 = DBNull.Value.ToString

                            End If
                            If Not objordets.WFAO_DOCOMM_2 = Nothing Then
                                If (objordets.WFAO_DOCOMM_2.ToString.Length = 0) Then
                                    objordets.WFAO_DOCOMM_2 = DBNull.Value.ToString
                                End If
                            Else
                                objordets.WFAO_DOCOMM_2 = DBNull.Value.ToString

                            End If
                            If Not objordets.WFAO_DOCOMM_3 = Nothing Then
                                If (objordets.WFAO_DOCOMM_3.ToString.Length = 0) Then
                                    objordets.WFAO_DOCOMM_3 = DBNull.Value.ToString
                                End If
                            Else
                                objordets.WFAO_DOCOMM_3 = DBNull.Value.ToString

                            End If
                            If Not objordets.WFAO_DOCOMM_4 = Nothing Then
                                If (objordets.WFAO_DOCOMM_4.ToString.Length = 0) Then
                                    objordets.WFAO_DOCOMM_4 = DBNull.Value.ToString
                                End If
                            Else
                                objordets.WFAO_DOCOMM_4 = DBNull.Value.ToString

                            End If
                            If Not objordets.WFAO_DOCOMM_5 = Nothing Then
                                If (objordets.WFAO_DOCOMM_5.ToString.Length = 0) Then
                                    objordets.WFAO_DOCOMM_5 = DBNull.Value.ToString
                                End If
                            Else
                                objordets.WFAO_DOCOMM_5 = DBNull.Value.ToString

                            End If
                            If Not objordets.WFAO_DOCOMM_6 = Nothing Then
                                If (objordets.WFAO_DOCOMM_6.ToString.Length = 0) Then
                                    objordets.WFAO_DOCOMM_6 = DBNull.Value.ToString
                                End If
                            Else
                                objordets.WFAO_DOCOMM_6 = DBNull.Value.ToString

                            End If
                            If Not objordets.WFAO_DOCOMM_7 = Nothing Then
                                If (objordets.WFAO_DOCOMM_7.ToString.Length = 0) Then
                                    objordets.WFAO_DOCOMM_7 = DBNull.Value.ToString
                                End If
                            Else
                                objordets.WFAO_DOCOMM_7 = DBNull.Value.ToString

                            End If
                            If Not objordets.WFAI_DEBRIEF_COMMENTS = Nothing Then
                                If (objordets.WFAI_DEBRIEF_COMMENTS.ToString.Length = 0) Then
                                    objordets.WFAI_DEBRIEF_COMMENTS = DBNull.Value.ToString
                                End If
                            Else
                                objordets.WFAI_DEBRIEF_COMMENTS = DBNull.Value.ToString

                            End If
                            If Not objordets.WFAI_JOB_RETURNED = Nothing Then
                                If (objordets.WFAI_JOB_RETURNED.ToString.Length = 0) Then
                                    objordets.WFAI_JOB_RETURNED = DBNull.Value.ToString
                                End If
                            Else
                                objordets.WFAI_JOB_RETURNED = DBNull.Value.ToString

                            End If
                            If Not objordets.MSG_INS_UPDATE_CANCEL = Nothing Then
                                If (objordets.MSG_INS_UPDATE_CANCEL.ToString.Length = 0) Then
                                    objordets.MSG_INS_UPDATE_CANCEL = DBNull.Value.ToString
                                End If
                            Else
                                objordets.MSG_INS_UPDATE_CANCEL = DBNull.Value.ToString

                            End If
                            If Not objordets.MSG_STATUS = Nothing Then
                                If (objordets.MSG_STATUS.ToString.Length = 0) Then
                                    objordets.MSG_STATUS = DBNull.Value.ToString
                                End If
                            Else
                                objordets.MSG_STATUS = DBNull.Value.ToString

                            End If
                            If Not objordets.MSG_ERROR = Nothing Then
                                If (objordets.MSG_ERROR.ToString.Length = 0) Then
                                    objordets.MSG_ERROR = DBNull.Value.ToString
                                End If
                            Else
                                objordets.MSG_ERROR = DBNull.Value.ToString

                            End If
                            If Not objordets.EXCEPTION_INFO = Nothing Then
                                If (objordets.EXCEPTION_INFO.ToString.Length = 0) Then
                                    objordets.EXCEPTION_INFO = DBNull.Value.ToString
                                End If
                            Else
                                objordets.EXCEPTION_INFO = DBNull.Value.ToString

                            End If
                            If Not objordets.CREATED_BY = Nothing Then
                                If (objordets.CREATED_BY.ToString.Length = 0) Then
                                    objordets.CREATED_BY = DBNull.Value.ToString
                                End If
                            Else
                                objordets.CREATED_BY = DBNull.Value.ToString

                            End If
                            If Not objordets.CREATION_DATE = Nothing Then
                                If (objordets.CREATION_DATE.ToString.Length = 0) Then
                                    objordets.CREATION_DATE = DBNull.Value.ToString
                                End If
                            Else
                                objordets.CREATION_DATE = DBNull.Value.ToString

                            End If
                            If Not objordets.LAST_UPDATED_BY = Nothing Then
                                If (objordets.LAST_UPDATED_BY.ToString.Length = 0) Then
                                    objordets.LAST_UPDATED_BY = DBNull.Value.ToString
                                End If
                            Else
                                objordets.LAST_UPDATED_BY = DBNull.Value.ToString

                            End If
                            If Not objordets.LAST_UPDATE_DATE = Nothing Then
                                If (objordets.LAST_UPDATE_DATE.ToString.Length = 0) Then
                                    objordets.LAST_UPDATE_DATE = DBNull.Value.ToString
                                End If
                            Else
                                objordets.LAST_UPDATE_DATE = DBNull.Value.ToString

                            End If
                            If Not objordets.LAST_UPDATE_LOGIN = Nothing Then
                                If (objordets.LAST_UPDATE_LOGIN.ToString.Length = 0) Then
                                    objordets.LAST_UPDATE_LOGIN = DBNull.Value.ToString
                                End If
                            Else
                                objordets.LAST_UPDATE_LOGIN = DBNull.Value.ToString

                            End If
                            If Not objordets.Ticket_Status = Nothing Then
                                If (objordets.Ticket_Status.ToString.Length = 0) Then
                                    objordets.Ticket_Status = DBNull.Value.ToString
                                End If
                            Else
                                objordets.Ticket_Status = DBNull.Value.ToString

                            End If
                            If Not objordets.WFAO_LOC_CITY = Nothing Then
                                If (objordets.WFAO_LOC_CITY.ToString.Length = 0) Then
                                    objordets.WFAO_LOC_CITY = DBNull.Value.ToString
                                End If
                            Else
                                objordets.WFAO_LOC_CITY = DBNull.Value.ToString

                            End If
                            If Not objordets.WFAO_LOC_STATE = Nothing Then
                                If (objordets.WFAO_LOC_STATE.ToString.Length = 0) Then
                                    objordets.WFAO_LOC_STATE = DBNull.Value.ToString
                                End If
                            Else
                                objordets.WFAO_LOC_STATE = DBNull.Value.ToString

                            End If
                            If Not objordets.WFAO_TASK_PRIORITY = Nothing Then
                                If (objordets.WFAO_TASK_PRIORITY.ToString.Length = 0) Then
                                    objordets.WFAO_TASK_PRIORITY = DBNull.Value.ToString
                                End If
                            Else
                                objordets.WFAO_TASK_PRIORITY = DBNull.Value.ToString

                            End If
                            If Not objordets.WFAO_SKILLS = Nothing Then
                                If (objordets.WFAO_SKILLS.ToString.Length = 0) Then
                                    objordets.WFAO_SKILLS = DBNull.Value.ToString
                                End If
                            Else
                                objordets.WFAO_SKILLS = DBNull.Value.ToString

                            End If
                            If Not objordets.WFAO_PON = Nothing Then
                                If (objordets.WFAO_PON.ToString.Length = 0) Then
                                    objordets.WFAO_PON = DBNull.Value.ToString
                                End If
                            Else
                                objordets.WFAO_PON = DBNull.Value.ToString

                            End If
                            If Not objordets.DEBRIEF_COMMENT_HISTORY = Nothing Then
                                If (objordets.DEBRIEF_COMMENT_HISTORY.ToString.Length = 0) Then
                                    objordets.DEBRIEF_COMMENT_HISTORY = DBNull.Value.ToString
                                End If
                            Else
                                objordets.DEBRIEF_COMMENT_HISTORY = DBNull.Value.ToString

                            End If
                            If Not objordets.PREV_WFAI_JSTAT = Nothing Then
                                If (objordets.PREV_WFAI_JSTAT.ToString.Length = 0) Then
                                    objordets.PREV_WFAI_JSTAT = DBNull.Value.ToString
                                End If
                            Else
                                objordets.PREV_WFAI_JSTAT = DBNull.Value.ToString

                            End If
                            If Not objordets.TASK_CREATED_BY = Nothing Then
                                If (objordets.TASK_CREATED_BY.ToString.Length = 0) Then
                                    objordets.TASK_CREATED_BY = DBNull.Value.ToString
                                End If
                            Else
                                objordets.TASK_CREATED_BY = DBNull.Value.ToString

                            End If
                            If Not objordets.SR_CREATED_BY = Nothing Then
                                If (objordets.SR_CREATED_BY.ToString.Length = 0) Then
                                    objordets.SR_CREATED_BY = DBNull.Value.ToString
                                End If
                            Else
                                objordets.SR_CREATED_BY = DBNull.Value.ToString

                            End If
                        End If
                    End If
                End If
            End If
            objInsert.SetValue(objordets.Task_Id, 0)
            objInsert.SetValue(objordets.Incident_Id, 1) 'have to add param
            objInsert.SetValue(objordets.Task_Number, 2) 'have to add param
            objInsert.SetValue(objordets.Incident_Number, 3)
            objInsert.SetValue(objordets.WFAO_CENTER, 4)
            objInsert.SetValue(objordets.WFAO_JOBID, 5)
            objInsert.SetValue(objordets.WFAI_JSTAT, 6)
            objInsert.SetValue(objordets.WFAO_JT, 7)
            objInsert.SetValue(objordets.WFAO_TASK_PRIORITY, 8)
            objInsert.SetValue(objordets.WFAO_SKILLS, 9)
            objInsert.SetValue(objordets.WFAO_CKTID, 10)
            objInsert.SetValue(objordets.WFAO_POM, 11)
            objInsert.SetValue(objordets.WFAO_PON, 12)
            objInsert.SetValue(objordets.WFAO_BILLNAME, 13)
            objInsert.SetValue(objordets.WFAO_TELEPHONE, 14)
            objInsert.SetValue(objordets.WFAO_WC, 15)
            objInsert.setvalue(objordets.WFAO_RTE, 16)
            objInsert.SetValue(objordets.WFAO_DAA, 17)
            objInsert.SetValue(objordets.WFAO_AA, 18)
            objInsert.SetValue(objordets.WFAO_ACT, 19)
            objInsert.SetValue(objordets.WFAO_CKLNAME, 20)
            objInsert.SetValue(objordets.WFAO_CKLADDR, 21)
            objInsert.SetValue(objordets.WFAO_LOC_CITY, 22)
            objInsert.SetValue(objordets.WFAO_LOC_STATE, 23)
            objInsert.SetValue(objordets.WFAO_COMM, 24)
            objInsert.SetValue(objordets.WFAO_START_DATE, 25)
            objInsert.SetValue(objordets.WFAO_ACC, 26)
            objInsert.SetValue(objordets.WFAO_A, 27)
            objInsert.SetValue(objordets.WFAO_B, 28)
            objInsert.SetValue(objordets.WFAO_DD, 29)
            objInsert.SetValue(objordets.WFAO_PRC, 30)
            objInsert.SetValue(objordets.WFAO_TPRC, 31)
            objInsert.SetValue(objordets.WFAO_ORD_ORIG, 32)
            objInsert.SetValue(objordets.WFAO_SVY, 33)
            objInsert.SetValue(objordets.WFAO_PST, 34)
            objInsert.SetValue(objordets.WFAO_COMMENTS_SUBJECT, 35)
            objInsert.SetValue(objordets.WFAO_COMMENTS_URGENCY, 36)
            objInsert.SetValue(objordets.WFAO_JOBPRI, 37)
            objInsert.SetValue(objordets.WFAO_FACILITY_LABEL, 38)
            objInsert.SetValue(objordets.WFAO_F1, 39)
            objInsert.SetValue(objordets.WFAO_PR, 40)
            objInsert.SetValue(objordets.WFAO_JOB, 41)
            objInsert.SetValue(objordets.WFAO_SCRATCHPAD_TASK_DESC, 42)
            objInsert.SetValue(objordets.WFAO_DOCOMM_1, 43)
            objInsert.SetValue(objordets.WFAO_DOCOMM_2, 44)
            objInsert.SetValue(objordets.WFAO_DOCOMM_3, 45)
            objInsert.SetValue(objordets.WFAO_DOCOMM_4, 46)
            objInsert.SetValue(objordets.WFAO_DOCOMM_5, 47)
            objInsert.SetValue(objordets.WFAO_DOCOMM_6, 48)
            objInsert.SetValue(objordets.WFAO_DOCOMM_7, 49)
            objInsert.SetValue(objordets.WFAI_DEBRIEF_COMMENTS, 50)
            objInsert.SetValue(objordets.WFAI_JOB_RETURNED, 51)
            objInsert.SetValue(objordets.MSG_INS_UPDATE_CANCEL, 52)
            objInsert.SetValue(objordets.MSG_STATUS, 53)
            objInsert.SetValue(objordets.MSG_ERROR, 54)
            objInsert.SetValue(objordets.EXCEPTION_INFO, 55)
            objInsert.SetValue(objordets.DEBRIEF_COMMENT_HISTORY, 56)
            objInsert.SetValue(objordets.PREV_WFAI_JSTAT, 57)
            objInsert.SetValue(objordets.TASK_CREATED_BY, 58)
            objInsert.SetValue(objordets.SR_CREATED_BY, 59)
            objInsert.SetValue(objordets.CREATED_BY, 60)
            objInsert.SetValue(objordets.CREATION_DATE, 61)
            objInsert.SetValue(objordets.LAST_UPDATED_BY, 62)
            objInsert.SetValue(objordets.LAST_UPDATE_DATE, 63)
            objInsert.SetValue(objordets.LAST_UPDATE_LOGIN, 64)
            objInsert.SetValue(objordets.Ticket_Status, 65)



            strInputQuery = "INSERT INTO [OracleCPE].[dbo].[INPUT_HEADER_STAGE] ([TASK_ID],[INCIDENT_ID],[TASK_NUMBER],[INCIDENT_NUMBER],[WFAO_CENTER],[WFAO_JOBID],[WFAI_JSTAT],[WFAO_JT],[WFAO_TASK_PRIORITY],[WFAO_SKILLS],[WFAO_CKTID],[WFAO_POM],[WFAO_PON],[WFAO_BILLNAME],[WFAO_TELEPHONE],[WFAO_WC],[WFAO_RTE],[WFAO_DAA],[WFAO_AA],[WFAO_ACT],[WFAO_CKLNAME],[WFAO_CKLADDR],[WFAO_LOC_CITY],[WFAO_LOC_STATE],[WFAO_COMM],[WFAO_START_DATE],[WFAO_ACC],[WFAO_A],[WFAO_B] ,[WFAO_DD],[WFAO_PRC],[WFAO_TPRC],[WFAO_ORD_ORIG],[WFAO_SVY],[WFAO_PST],[WFAO_COMMENTS_SUBJECT],[WFAO_COMMENTS_URGENCY],[WFAO_JOBPRI],[WFAO_FACILITY_LABEL],[WFAO_F1],[WFAO_PR],[WFAO_JOB],[WFAO_SCRATCHPAD_TASK_DESC],[WFAO_DOCOMM_1],[WFAO_DOCOMM_2],[WFAO_DOCOMM_3],[WFAO_DOCOMM_4],[WFAO_DOCOMM_5],[WFAO_DOCOMM_6],[WFAO_DOCOMM_7],[WFAI_DEBRIEF_COMMENTS],[WFAI_JOB_RETURNED],[MSG_INS_UPDATE_CANCEL],[MSG_STATUS],[MSG_ERROR],[EXCEPTION_INFO],[DEBRIEF_COMMENT_HISTORY],[PREV_WFAI_JSTAT],[TASK_CREATED_BY],[SR_CREATED_BY],[CREATED_BY],[CREATION_DATE],[LAST_UPDATED_BY],[LAST_UPDATE_DATE],[LAST_UPDATE_LOGIN],[Ticket_Status]) values(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)"

            objDbutility.InsertQuery([Global].p_sCPE_NOTIFIERDB, strInputQuery, ex1, objInsert)
            If (ex1 Is Nothing) Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            p_objLogger.writenote("Exception: :-" & ex.ToString(), objordets.Task_Id, EventLogEntryType.Error)
        End Try
    End Function
    Function InsertInputHeader(ByVal objordets As Object)

        Try
            Dim objDbutility As New DBUtilities.DBConnect
            objDbutility = SQLDBUtil()
            objDbutility.DB_SERVER_NAME = "CTOMASQL2SQL1\SQL_INSTANCE1,7115"

            'Dim objInsert() As Object
            Dim objInsert As New Object
            'Dim objInsert As Object = Nothing
            Dim ex1 As Exception = Nothing
            'Dim ex1 As New Exception
            Dim e As Exception
            'Dim exp As Exception
            Dim strInputQuery As String
            Dim objQueryFleHndlr As New FileHandler.INIFileHandler(p_sCPE_NotifierIni)
            Dim irow As New DataSet
            objInsert = Array.CreateInstance(GetType(Object), 66)
            If Not objordets.Task_Id = Nothing Then
                If (objordets.Task_Id.ToString.Length = 0) Then
                    objordets.Task_Id = DBNull.Value.ToString
                End If
            Else
                objordets.Task_Id = DBNull.Value.ToString

            End If
            If Not objordets.Incident_Id = Nothing Then
                If (objordets.Incident_Id.ToString.Length = 0) Then
                    objordets.Incident_Id = DBNull.Value.ToString
                End If
            Else
                objordets.Incident_Id = DBNull.Value.ToString
            End If
            If Not objordets.Task_Number = Nothing Then
                If (objordets.Task_Number.ToString.Length = 0) Then
                    objordets.Task_Number = DBNull.Value.ToString
                End If
            Else
                objordets.Task_Number = DBNull.Value.ToString

            End If

            If Not objordets.Incident_Number = Nothing Then
                If (objordets.Incident_Number.Length = 0) Then
                    objordets.Incident_Number = DBNull.Value.ToString
                End If
            Else
                objordets.Incident_Number = DBNull.Value.ToString

            End If
            If Not objordets.WFAO_CENTER = Nothing Then
                If (objordets.WFAO_CENTER.ToString.Length = 0) Then
                    objordets.WFAO_CENTER = DBNull.Value.ToString
                End If
            Else
                objordets.WFAO_CENTER = DBNull.Value.ToString
            End If
            If Not objordets.WFAO_JOBID = Nothing Then
                If (objordets.WFAO_JOBID.ToString.Length = 0) Then
                    objordets.WFAO_JOBID = DBNull.Value.ToString
                End If
            Else
                objordets.WFAO_JOBID = DBNull.Value.ToString
            End If
            If Not objordets.WFAI_JSTAT = Nothing Then
                If (objordets.WFAI_JSTAT.ToString.Length = 0) Then
                    objordets.WFAI_JSTAT = DBNull.Value.ToString
                End If
            Else
                objordets.WFAI_JSTAT = DBNull.Value.ToString
            End If
            If Not objordets.WFAO_JT = Nothing Then

                If (objordets.WFAO_JT.ToString.Length = 0) Then
                    objordets.WFAO_JT = DBNull.Value.ToString
                End If
            Else
                objordets.WFAO_JT = DBNull.Value.ToString
            End If
            If Not objordets.WFAO_CKTID = Nothing Then
                If (objordets.WFAO_CKTID.ToString.Length = 0) Then
                    objordets.WFAO_CKTID = DBNull.Value.ToString
                End If
            Else
                objordets.WFAO_CKTID = DBNull.Value.ToString
            End If
            If Not objordets.WFAO_POM = Nothing Then
                If (objordets.WFAO_POM.ToString.Length = 0) Then
                    objordets.WFAO_POM = DBNull.Value.ToString
                End If
            Else
                objordets.WFAO_POM = DBNull.Value.ToString
            End If
            If Not objordets.WFAO_PON = Nothing Then
                If (objordets.WFAO_PON.ToString.Length = 0) Then
                    objordets.WFAO_PON = DBNull.Value.ToString
                End If
            Else
                objordets.WFAO_PON = DBNull.Value.ToString
            End If
            If Not objordets.WFAO_BILLNAME = Nothing Then
                If (objordets.WFAO_BILLNAME.ToString.Length = 0) Then
                    objordets.WFAO_BILLNAME = DBNull.Value.ToString
                End If
            Else
                objordets.WFAO_BILLNAME = DBNull.Value.ToString
            End If
            If Not objordets.WFAO_TELEPHONE = Nothing Then
                If (objordets.WFAO_TELEPHONE.ToString.Length = 0) Then
                    objordets.WFAO_TELEPHONE = DBNull.Value.ToString
                End If
            Else
                objordets.WFAO_TELEPHONE = DBNull.Value.ToString
            End If
            If Not objordets.WFAO_WC = Nothing Then
                If (objordets.WFAO_WC.ToString.Length = 0) Then
                    objordets.WFAO_WC = DBNull.Value.ToString
                End If
            Else
                objordets.WFAO_WC = DBNull.Value.ToString
            End If
            If Not objordets.WFAO_RTE = Nothing Then
                If (objordets.WFAO_RTE.ToString.Length = 0) Then
                    objordets.WFAO_RTE = DBNull.Value.ToString
                End If
            Else
                objordets.WFAO_RTE = DBNull.Value.ToString

            End If
            If Not objordets.WFAO_DAA = Nothing Then
                If (objordets.WFAO_DAA.ToString.Length = 0) Then
                    objordets.WFAO_DAA = DBNull.Value.ToString
                End If
            Else
                objordets.WFAO_DAA = DBNull.Value.ToString

            End If
            If Not objordets.WFAO_AA = Nothing Then
                If (objordets.WFAO_AA.ToString.Length = 0) Then
                    objordets.WFAO_AA = DBNull.Value.ToString
                End If
            Else
                objordets.WFAO_AA = DBNull.Value.ToString
            End If
            If Not objordets.WFAO_ACT = Nothing Then
                If (objordets.WFAO_ACT.ToString.Length = 0) Then
                    objordets.WFAO_ACT = DBNull.Value.ToString
                End If
            Else
                objordets.WFAO_ACT = DBNull.Value.ToString
            End If
            If Not objordets.WFAO_CKLNAME = Nothing Then
                If (objordets.WFAO_CKLNAME.ToString.Length = 0) Then
                    objordets.WFAO_CKLNAME = DBNull.Value.ToString
                End If
            Else
                objordets.WFAO_CKLNAME = DBNull.Value.ToString
            End If
            If Not objordets.WFAO_CKLADDR = Nothing Then
                If (objordets.WFAO_CKLADDR.ToString.Length = 0) Then
                    objordets.WFAO_CKLADDR = DBNull.Value.ToString
                End If
            Else
                objordets.WFAO_CKLADDR = DBNull.Value.ToString

            End If
            If Not objordets.WFAO_COMM = Nothing Then
                If (objordets.WFAO_COMM.ToString.Length = 0) Then
                    objordets.WFAO_COMM = DBNull.Value.ToString
                End If
            Else
                objordets.WFAO_COMM = DBNull.Value.ToString

            End If
            If Not objordets.WFAO_START_DATE = Nothing Then
                If (objordets.WFAO_START_DATE.ToString.Length = 0) Then
                    objordets.WFAO_START_DATE = DBNull.Value.ToString
                End If
            Else
                objordets.WFAO_START_DATE = DBNull.Value.ToString

            End If
            If Not objordets.WFAO_ACC = Nothing Then
                If (objordets.WFAO_ACC.ToString.Length = 0) Then
                    objordets.WFAO_ACC = DBNull.Value.ToString
                End If
            Else
                objordets.WFAO_ACC = DBNull.Value.ToString

            End If
            If Not objordets.WFAO_A = Nothing Then
                If (objordets.WFAO_A.ToString.Length = 0) Then
                    objordets.WFAO_A = DBNull.Value.ToString
                End If
            Else
                objordets.WFAO_A = DBNull.Value.ToString

            End If
            If Not objordets.WFAO_B = Nothing Then
                If (objordets.WFAO_B.ToString.Length = 0) Then
                    objordets.WFAO_B = DBNull.Value.ToString
                End If
            Else
                objordets.WFAO_B = DBNull.Value.ToString

            End If
            If Not objordets.WFAO_DD = Nothing Then
                If (objordets.WFAO_DD.ToString.Length = 0) Then
                    objordets.WFAO_DD = DBNull.Value.ToString
                End If
            Else
                objordets.WFAO_DD = DBNull.Value.ToString

            End If
            If Not objordets.WFAO_PRC = Nothing Then
                If (objordets.WFAO_PRC.ToString.Length = 0) Then
                    objordets.WFAO_PRC = DBNull.Value.ToString
                End If
            Else
                objordets.WFAO_PRC = DBNull.Value.ToString

            End If
            If Not objordets.WFAO_TPRC = Nothing Then
                If (objordets.WFAO_TPRC.ToString.Length = 0) Then
                    objordets.WFAO_TPRC = DBNull.Value.ToString
                End If
            Else
                objordets.WFAO_TPRC = DBNull.Value.ToString

            End If
            If Not objordets.WFAO_ORD_ORIG = Nothing Then
                If (objordets.WFAO_ORD_ORIG.ToString.Length = 0) Then
                    objordets.WFAO_ORD_ORIG = DBNull.Value.ToString
                End If
            Else
                objordets.WFAO_ORD_ORIG = DBNull.Value.ToString

                If Not objordets.WFAO_SVY = Nothing Then
                    If (objordets.WFAO_SVY.ToString.Length = 0) Then
                        objordets.WFAO_SVY = DBNull.Value.ToString
                    End If
                Else
                    objordets.WFAO_SVY = DBNull.Value.ToString

                    If Not objordets.WFAO_PST = Nothing Then
                        If (objordets.WFAO_PST.ToString.Length = 0) Then
                            objordets.WFAO_PST = DBNull.Value.ToString
                        End If
                    Else
                        objordets.WFAO_PST = DBNull.Value.ToString

                    End If
                    If Not objordets.WFAO_COMMENT_SUBJECT = Nothing Then
                        If (objordets.WFAO_COMMENT_SUBJECT.ToString.Length = 0) Then
                            objordets.WFAO_COMMENT_SUBJECT = DBNull.Value.ToString
                        End If
                    Else
                        objordets.WFAO_COMMENT_SUBJECT = DBNull.Value.ToString

                    End If
                    If Not objordets.WFAO_COMMENT_URGENCY = Nothing Then
                        If (objordets.WFAO_COMMENT_URGENCY.ToString.Length = 0) Then
                            objordets.WFAO_COMMENT_URGENCY = DBNull.Value.ToString
                        End If
                    Else
                        objordets.WFAO_COMMENT_URGENCY = DBNull.Value.ToString

                    End If
                    If Not objordets.WFAO_JOBPRI = Nothing Then
                        If (objordets.WFAO_JOBPRI.ToString.Length = 0) Then
                            objordets.WFAO_JOBPRI = DBNull.Value.ToString
                        End If
                    Else
                        objordets.WFAO_JOBPRI = DBNull.Value.ToString

                    End If
                    If Not objordets.WFAO_FACILITY_LABEL = Nothing Then
                        If (objordets.WFAO_FACILITY_LABEL.ToString.Length = 0) Then
                            objordets.WFAO_FACILITY_LABEL = DBNull.Value.ToString
                        End If
                    Else
                        objordets.WFAO_FACILITY_LABEL = DBNull.Value.ToString

                    End If
                    If Not objordets.WFAO_F1 = Nothing Then
                        If (objordets.WFAO_F1.ToString.Length = 0) Then
                            objordets.WFAO_F1 = DBNull.Value.ToString
                        End If
                    Else
                        objordets.WFAO_F1 = DBNull.Value.ToString

                    End If
                    If Not objordets.WFAO_PR = Nothing Then
                        If (objordets.WFAO_PR.ToString.Length = 0) Then
                            objordets.WFAO_PR = DBNull.Value.ToString
                        End If
                    Else
                        objordets.WFAO_PR = DBNull.Value.ToString

                    End If
                    If Not objordets.WFAO_JOB = Nothing Then
                        If (objordets.WFAO_JOB.ToString.Length = 0) Then
                            objordets.WFAO_JOB = DBNull.Value.ToString
                        End If
                    Else
                        objordets.WFAO_JOB = DBNull.Value.ToString

                        If Not objordets.WFAO_SCRACHPAD_TASK_DESC = Nothing Then
                            If (objordets.WFAO_SCRACHPAD_TASK_DESC.ToString.Length = 0) Then
                                objordets.WFAO_SCRACHPAD_TASK_DESC = DBNull.Value.ToString
                            End If
                        Else
                            objordets.WFAO_SCRACHPAD_TASK_DESC = DBNull.Value.ToString

                            If Not objordets.WFAO_DOCOMM_1 = Nothing Then
                                If (objordets.WFAO_DOCOMM_1.ToString.Length = 0) Then
                                    objordets.WFAO_DOCOMM_1 = DBNull.Value.ToString
                                End If
                            Else
                                objordets.WFAO_DOCOMM_1 = DBNull.Value.ToString

                            End If
                            If Not objordets.WFAO_DOCOMM_2 = Nothing Then
                                If (objordets.WFAO_DOCOMM_2.ToString.Length = 0) Then
                                    objordets.WFAO_DOCOMM_2 = DBNull.Value.ToString
                                End If
                            Else
                                objordets.WFAO_DOCOMM_2 = DBNull.Value.ToString

                            End If
                            If Not objordets.WFAO_DOCOMM_3 = Nothing Then
                                If (objordets.WFAO_DOCOMM_3.ToString.Length = 0) Then
                                    objordets.WFAO_DOCOMM_3 = DBNull.Value.ToString
                                End If
                            Else
                                objordets.WFAO_DOCOMM_3 = DBNull.Value.ToString

                            End If
                            If Not objordets.WFAO_DOCOMM_4 = Nothing Then
                                If (objordets.WFAO_DOCOMM_4.ToString.Length = 0) Then
                                    objordets.WFAO_DOCOMM_4 = DBNull.Value.ToString
                                End If
                            Else
                                objordets.WFAO_DOCOMM_4 = DBNull.Value.ToString

                            End If
                            If Not objordets.WFAO_DOCOMM_5 = Nothing Then
                                If (objordets.WFAO_DOCOMM_5.ToString.Length = 0) Then
                                    objordets.WFAO_DOCOMM_5 = DBNull.Value.ToString
                                End If
                            Else
                                objordets.WFAO_DOCOMM_5 = DBNull.Value.ToString

                            End If
                            If Not objordets.WFAO_DOCOMM_6 = Nothing Then
                                If (objordets.WFAO_DOCOMM_6.ToString.Length = 0) Then
                                    objordets.WFAO_DOCOMM_6 = DBNull.Value.ToString
                                End If
                            Else
                                objordets.WFAO_DOCOMM_6 = DBNull.Value.ToString

                            End If
                            If Not objordets.WFAO_DOCOMM_7 = Nothing Then
                                If (objordets.WFAO_DOCOMM_7.ToString.Length = 0) Then
                                    objordets.WFAO_DOCOMM_7 = DBNull.Value.ToString
                                End If
                            Else
                                objordets.WFAO_DOCOMM_7 = DBNull.Value.ToString

                            End If
                            If Not objordets.WFAI_DEBRIEF_COMMENTS = Nothing Then
                                If (objordets.WFAI_DEBRIEF_COMMENTS.ToString.Length = 0) Then
                                    objordets.WFAI_DEBRIEF_COMMENTS = DBNull.Value.ToString
                                End If
                            Else
                                objordets.WFAI_DEBRIEF_COMMENTS = DBNull.Value.ToString

                            End If
                            If Not objordets.WFAI_JOB_RETURNED = Nothing Then
                                If (objordets.WFAI_JOB_RETURNED.ToString.Length = 0) Then
                                    objordets.WFAI_JOB_RETURNED = DBNull.Value.ToString
                                End If
                            Else
                                objordets.WFAI_JOB_RETURNED = DBNull.Value.ToString

                            End If
                            If Not objordets.MSG_INS_UPDATE_CANCEL = Nothing Then
                                If (objordets.MSG_INS_UPDATE_CANCEL.ToString.Length = 0) Then
                                    objordets.MSG_INS_UPDATE_CANCEL = DBNull.Value.ToString
                                End If
                            Else
                                objordets.MSG_INS_UPDATE_CANCEL = DBNull.Value.ToString

                            End If
                            If Not objordets.MSG_STATUS = Nothing Then
                                If (objordets.MSG_STATUS.ToString.Length = 0) Then
                                    objordets.MSG_STATUS = DBNull.Value.ToString
                                End If
                            Else
                                objordets.MSG_STATUS = DBNull.Value.ToString

                            End If
                            If Not objordets.MSG_ERROR = Nothing Then
                                If (objordets.MSG_ERROR.ToString.Length = 0) Then
                                    objordets.MSG_ERROR = DBNull.Value.ToString
                                End If
                            Else
                                objordets.MSG_ERROR = DBNull.Value.ToString

                            End If
                            If Not objordets.EXCEPTION_INFO = Nothing Then
                                If (objordets.EXCEPTION_INFO.ToString.Length = 0) Then
                                    objordets.EXCEPTION_INFO = DBNull.Value.ToString
                                End If
                            Else
                                objordets.EXCEPTION_INFO = DBNull.Value.ToString

                            End If
                            If Not objordets.CREATED_BY = Nothing Then
                                If (objordets.CREATED_BY.ToString.Length = 0) Then
                                    objordets.CREATED_BY = DBNull.Value.ToString
                                End If
                            Else
                                objordets.CREATED_BY = DBNull.Value.ToString

                            End If
                            If Not objordets.CREATION_DATE = Nothing Then
                                If (objordets.CREATION_DATE.ToString.Length = 0) Then
                                    objordets.CREATION_DATE = DBNull.Value.ToString
                                End If
                            Else
                                objordets.CREATION_DATE = DBNull.Value.ToString

                            End If
                            If Not objordets.LAST_UPDATED_BY = Nothing Then
                                If (objordets.LAST_UPDATED_BY.ToString.Length = 0) Then
                                    objordets.LAST_UPDATED_BY = DBNull.Value.ToString
                                End If
                            Else
                                objordets.LAST_UPDATED_BY = DBNull.Value.ToString

                            End If
                            If Not objordets.LAST_UPDATE_DATE = Nothing Then
                                If (objordets.LAST_UPDATE_DATE.ToString.Length = 0) Then
                                    objordets.LAST_UPDATE_DATE = DBNull.Value.ToString
                                End If
                            Else
                                objordets.LAST_UPDATE_DATE = DBNull.Value.ToString

                            End If
                            If Not objordets.LAST_UPDATE_LOGIN = Nothing Then
                                If (objordets.LAST_UPDATE_LOGIN.ToString.Length = 0) Then
                                    objordets.LAST_UPDATE_LOGIN = DBNull.Value.ToString
                                End If
                            Else
                                objordets.LAST_UPDATE_LOGIN = DBNull.Value.ToString

                            End If
                            If Not objordets.Ticket_Status = Nothing Then
                                If (objordets.Ticket_Status.ToString.Length = 0) Then
                                    objordets.Ticket_Status = DBNull.Value.ToString
                                End If
                            Else
                                objordets.Ticket_Status = DBNull.Value.ToString

                            End If
                            If Not objordets.WFAO_LOC_CITY = Nothing Then
                                If (objordets.WFAO_LOC_CITY.ToString.Length = 0) Then
                                    objordets.WFAO_LOC_CITY = DBNull.Value.ToString
                                End If
                            Else
                                objordets.WFAO_LOC_CITY = DBNull.Value.ToString

                            End If
                            If Not objordets.WFAO_LOC_STATE = Nothing Then
                                If (objordets.WFAO_LOC_STATE.ToString.Length = 0) Then
                                    objordets.WFAO_LOC_STATE = DBNull.Value.ToString
                                End If
                            Else
                                objordets.WFAO_LOC_STATE = DBNull.Value.ToString

                            End If
                            If Not objordets.WFAO_TASK_PRIORITY = Nothing Then
                                If (objordets.WFAO_TASK_PRIORITY.ToString.Length = 0) Then
                                    objordets.WFAO_TASK_PRIORITY = DBNull.Value.ToString
                                End If
                            Else
                                objordets.WFAO_TASK_PRIORITY = DBNull.Value.ToString

                            End If
                            If Not objordets.WFAO_SKILLS = Nothing Then
                                If (objordets.WFAO_SKILLS.ToString.Length = 0) Then
                                    objordets.WFAO_SKILLS = DBNull.Value.ToString
                                End If
                            Else
                                objordets.WFAO_SKILLS = DBNull.Value.ToString

                            End If
                            If Not objordets.WFAO_PON = Nothing Then
                                If (objordets.WFAO_PON.ToString.Length = 0) Then
                                    objordets.WFAO_PON = DBNull.Value.ToString
                                End If
                            Else
                                objordets.WFAO_PON = DBNull.Value.ToString

                            End If
                            If Not objordets.DEBRIEF_COMMENT_HISTORY = Nothing Then
                                If (objordets.DEBRIEF_COMMENT_HISTORY.ToString.Length = 0) Then
                                    objordets.DEBRIEF_COMMENT_HISTORY = DBNull.Value.ToString
                                End If
                            Else
                                objordets.DEBRIEF_COMMENT_HISTORY = DBNull.Value.ToString

                            End If
                            If Not objordets.PREV_WFAI_JSTAT = Nothing Then
                                If (objordets.PREV_WFAI_JSTAT.ToString.Length = 0) Then
                                    objordets.PREV_WFAI_JSTAT = DBNull.Value.ToString
                                End If
                            Else
                                objordets.PREV_WFAI_JSTAT = DBNull.Value.ToString

                            End If
                            If Not objordets.TASK_CREATED_BY = Nothing Then
                                If (objordets.TASK_CREATED_BY.ToString.Length = 0) Then
                                    objordets.TASK_CREATED_BY = DBNull.Value.ToString
                                End If
                            Else
                                objordets.TASK_CREATED_BY = DBNull.Value.ToString

                            End If
                            If Not objordets.SR_CREATED_BY = Nothing Then
                                If (objordets.SR_CREATED_BY.ToString.Length = 0) Then
                                    objordets.SR_CREATED_BY = DBNull.Value.ToString
                                End If
                            Else
                                objordets.SR_CREATED_BY = DBNull.Value.ToString

                            End If
                        End If
                    End If
                End If
            End If
            objInsert.SetValue(objordets.Task_Id, 0)
            objInsert.SetValue(objordets.Incident_Id, 1) 'have to add param
            objInsert.SetValue(objordets.Task_Number, 2) 'have to add param
            objInsert.SetValue(objordets.Incident_Number, 3)
            objInsert.SetValue(objordets.WFAO_CENTER, 4)
            objInsert.SetValue(objordets.WFAO_JOBID, 5)
            objInsert.SetValue(objordets.WFAI_JSTAT, 6)
            objInsert.SetValue(objordets.WFAO_JT, 7)
            objInsert.SetValue(objordets.WFAO_TASK_PRIORITY, 8)
            objInsert.SetValue(objordets.WFAO_SKILLS, 9)
            objInsert.SetValue(objordets.WFAO_CKTID, 10)
            objInsert.SetValue(objordets.WFAO_POM, 11)
            objInsert.SetValue(objordets.WFAO_PON, 12)
            objInsert.SetValue(objordets.WFAO_BILLNAME, 13)
            objInsert.SetValue(objordets.WFAO_TELEPHONE, 14)
            objInsert.SetValue(objordets.WFAO_WC, 15)
            objInsert.setvalue(objordets.WFAO_RTE, 16)
            objInsert.SetValue(objordets.WFAO_DAA, 17)
            objInsert.SetValue(objordets.WFAO_AA, 18)
            objInsert.SetValue(objordets.WFAO_ACT, 19)
            objInsert.SetValue(objordets.WFAO_CKLNAME, 20)
            objInsert.SetValue(objordets.WFAO_CKLADDR, 21)
            objInsert.SetValue(objordets.WFAO_LOC_CITY, 22)
            objInsert.SetValue(objordets.WFAO_LOC_STATE, 23)
            objInsert.SetValue(objordets.WFAO_COMM, 24)
            objInsert.SetValue(objordets.WFAO_START_DATE, 25)
            objInsert.SetValue(objordets.WFAO_ACC, 26)
            objInsert.SetValue(objordets.WFAO_A, 27)
            objInsert.SetValue(objordets.WFAO_B, 28)
            objInsert.SetValue(objordets.WFAO_DD, 29)
            objInsert.SetValue(objordets.WFAO_PRC, 30)
            objInsert.SetValue(objordets.WFAO_TPRC, 31)
            objInsert.SetValue(objordets.WFAO_ORD_ORIG, 32)
            objInsert.SetValue(objordets.WFAO_SVY, 33)
            objInsert.SetValue(objordets.WFAO_PST, 34)
            objInsert.SetValue(objordets.WFAO_COMMENTS_SUBJECT, 35)
            objInsert.SetValue(objordets.WFAO_COMMENTS_URGENCY, 36)
            objInsert.SetValue(objordets.WFAO_JOBPRI, 37)
            objInsert.SetValue(objordets.WFAO_FACILITY_LABEL, 38)
            objInsert.SetValue(objordets.WFAO_F1, 39)
            objInsert.SetValue(objordets.WFAO_PR, 40)
            objInsert.SetValue(objordets.WFAO_JOB, 41)
            objInsert.SetValue(objordets.WFAO_SCRATCHPAD_TASK_DESC, 42)
            objInsert.SetValue(objordets.WFAO_DOCOMM_1, 43)
            objInsert.SetValue(objordets.WFAO_DOCOMM_2, 44)
            objInsert.SetValue(objordets.WFAO_DOCOMM_3, 45)
            objInsert.SetValue(objordets.WFAO_DOCOMM_4, 46)
            objInsert.SetValue(objordets.WFAO_DOCOMM_5, 47)
            objInsert.SetValue(objordets.WFAO_DOCOMM_6, 48)
            objInsert.SetValue(objordets.WFAO_DOCOMM_7, 49)
            objInsert.SetValue(objordets.WFAI_DEBRIEF_COMMENTS, 50)
            objInsert.SetValue(objordets.WFAI_JOB_RETURNED, 51)
            objInsert.SetValue(objordets.MSG_INS_UPDATE_CANCEL, 52)
            objInsert.SetValue(objordets.MSG_STATUS, 53)
            objInsert.SetValue(objordets.MSG_ERROR, 54)
            objInsert.SetValue(objordets.EXCEPTION_INFO, 55)
            objInsert.SetValue(objordets.DEBRIEF_COMMENT_HISTORY, 56)
            objInsert.SetValue(objordets.PREV_WFAI_JSTAT, 57)
            objInsert.SetValue(objordets.TASK_CREATED_BY, 58)
            objInsert.SetValue(objordets.SR_CREATED_BY, 59)
            objInsert.SetValue(objordets.CREATED_BY, 60)
            objInsert.SetValue(objordets.CREATION_DATE, 61)
            objInsert.SetValue(objordets.LAST_UPDATED_BY, 62)
            objInsert.SetValue(objordets.LAST_UPDATE_DATE, 63)
            objInsert.SetValue(objordets.LAST_UPDATE_LOGIN, 64)
            objInsert.SetValue(objordets.Ticket_Status, 65)



            strInputQuery = "INSERT INTO [OracleCPE].[dbo].[INPUT_HEADER_STAGE] ([TASK_ID],[INCIDENT_ID],[TASK_NUMBER],[INCIDENT_NUMBER],[WFAO_CENTER],[WFAO_JOBID],[WFAI_JSTAT],[WFAO_JT],[WFAO_TASK_PRIORITY],[WFAO_SKILLS],[WFAO_CKTID],[WFAO_POM],[WFAO_PON],[WFAO_BILLNAME],[WFAO_TELEPHONE],[WFAO_WC],[WFAO_RTE],[WFAO_DAA],[WFAO_AA],[WFAO_ACT],[WFAO_CKLNAME],[WFAO_CKLADDR],[WFAO_LOC_CITY],[WFAO_LOC_STATE],[WFAO_COMM],[WFAO_START_DATE],[WFAO_ACC],[WFAO_A],[WFAO_B] ,[WFAO_DD],[WFAO_PRC],[WFAO_TPRC],[WFAO_ORD_ORIG],[WFAO_SVY],[WFAO_PST],[WFAO_COMMENTS_SUBJECT],[WFAO_COMMENTS_URGENCY],[WFAO_JOBPRI],[WFAO_FACILITY_LABEL],[WFAO_F1],[WFAO_PR],[WFAO_JOB],[WFAO_SCRATCHPAD_TASK_DESC],[WFAO_DOCOMM_1],[WFAO_DOCOMM_2],[WFAO_DOCOMM_3],[WFAO_DOCOMM_4],[WFAO_DOCOMM_5],[WFAO_DOCOMM_6],[WFAO_DOCOMM_7],[WFAI_DEBRIEF_COMMENTS],[WFAI_JOB_RETURNED],[MSG_INS_UPDATE_CANCEL],[MSG_STATUS],[MSG_ERROR],[EXCEPTION_INFO],[DEBRIEF_COMMENT_HISTORY],[PREV_WFAI_JSTAT],[TASK_CREATED_BY],[SR_CREATED_BY],[CREATED_BY],[CREATION_DATE],[LAST_UPDATED_BY],[LAST_UPDATE_DATE],[LAST_UPDATE_LOGIN],[Ticket_Status]) values(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)"

            objDbutility.InsertQuery([Global].p_sCPE_NOTIFIERDB, strInputQuery, ex1, objInsert)
            If (ex1 Is Nothing) Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            p_objLogger.writenote("Exception: :-" & ex.ToString(), objordets.Task_Id, EventLogEntryType.Error)
        End Try
    End Function
    Function UpdateInputHeaderTask(ByVal objordets As OrderDetails)
        Try
            Dim objDbutility As New DBUtilities.DBConnect
            objDbutility = SQLDBUtil()
            objDbutility.DB_SERVER_NAME = "CTOMASQL2SQL1\SQL_INSTANCE1,7115"

            'Dim objInsert() As Object
            Dim objInsert As New Object
            'Dim objInsert As Object = Nothing
            Dim ex1 As Exception = Nothing
            'Dim ex1 As New Exception
            Dim e As Exception
            'Dim exp As Exception
            Dim strUpdateQuery As String
            Dim objQueryFleHndlr As New FileHandler.INIFileHandler(p_sCPE_NotifierIni)
            Dim irow As New DataSet

            If Not objordets.Task_Id = Nothing Then
                If (objordets.Task_Id.ToString.Length = 0) Then
                    objordets.Task_Id = DBNull.Value.ToString
                End If
            Else
                objordets.Task_Id = DBNull.Value.ToString

            End If
            If Not objordets.Incident_Id = Nothing Then
                If (objordets.Incident_Id.ToString.Length = 0) Then
                    objordets.Incident_Id = DBNull.Value.ToString
                End If
            Else
                objordets.Incident_Id = DBNull.Value.ToString
            End If
            If Not objordets.Task_Number = Nothing Then
                If (objordets.Task_Number.ToString.Length = 0) Then
                    objordets.Task_Number = DBNull.Value.ToString
                End If
            Else
                objordets.Task_Number = DBNull.Value.ToString

            End If

            If Not objordets.Incident_Number = Nothing Then
                If (objordets.Incident_Number.Length = 0) Then
                    objordets.Incident_Number = DBNull.Value.ToString
                End If
            Else
                objordets.Incident_Number = DBNull.Value.ToString

            End If
            ''If Not objordets.WFAO_CENTER = Nothing Then
            ''    If (objordets.WFAO_CENTER.ToString.Length = 0) Then
            ''        objordets.WFAO_CENTER = DBNull.Value.ToString
            ''    End If
            ''Else
            ''    objordets.WFAO_CENTER = DBNull.Value.ToString
            ''End If
            If Not objordets.WFAO_JOBID = Nothing Then
                If (objordets.WFAO_JOBID.ToString.Length = 0) Then
                    objordets.WFAO_JOBID = DBNull.Value.ToString
                End If
            Else
                objordets.WFAO_JOBID = DBNull.Value.ToString
            End If
            If Not objordets.WFAI_JSTAT = Nothing Then
                If (objordets.WFAI_JSTAT.ToString.Length = 0) Then
                    objordets.WFAI_JSTAT = DBNull.Value.ToString
                End If
            Else
                objordets.WFAI_JSTAT = DBNull.Value.ToString
            End If
            If Not objordets.WFAO_JT = Nothing Then

                If (objordets.WFAO_JT.ToString.Length = 0) Then
                    objordets.WFAO_JT = DBNull.Value.ToString
                End If
            Else
                objordets.WFAO_JT = DBNull.Value.ToString
            End If
            If Not objordets.WFAO_CKTID = Nothing Then
                If (objordets.WFAO_CKTID.ToString.Length = 0) Then
                    objordets.WFAO_CKTID = DBNull.Value.ToString
                End If
            Else
                objordets.WFAO_CKTID = DBNull.Value.ToString
            End If
            If Not objordets.WFAO_POM = Nothing Then
                If (objordets.WFAO_POM.ToString.Length = 0) Then
                    objordets.WFAO_POM = DBNull.Value.ToString
                End If
            Else
                objordets.WFAO_POM = DBNull.Value.ToString
            End If
            If Not objordets.WFAO_PON = Nothing Then
                If (objordets.WFAO_PON.ToString.Length = 0) Then
                    objordets.WFAO_PON = DBNull.Value.ToString
                End If
            Else
                objordets.WFAO_PON = DBNull.Value.ToString
            End If
            If Not objordets.WFAO_BILLNAME = Nothing Then
                If (objordets.WFAO_BILLNAME.ToString.Length = 0) Then
                    objordets.WFAO_BILLNAME = DBNull.Value.ToString
                End If
            Else
                objordets.WFAO_BILLNAME = DBNull.Value.ToString
            End If
            If Not objordets.WFAO_TELEPHONE = Nothing Then
                If (objordets.WFAO_TELEPHONE.ToString.Length = 0) Then
                    objordets.WFAO_TELEPHONE = DBNull.Value.ToString
                End If
            Else
                objordets.WFAO_TELEPHONE = DBNull.Value.ToString
            End If
            If Not objordets.WFAO_WC = Nothing Then
                If (objordets.WFAO_WC.ToString.Length = 0) Then
                    objordets.WFAO_WC = DBNull.Value.ToString
                End If
            Else
                objordets.WFAO_WC = DBNull.Value.ToString
            End If
            If Not objordets.WFAO_RTE = Nothing Then
                If (objordets.WFAO_RTE.ToString.Length = 0) Then
                    objordets.WFAO_RTE = DBNull.Value.ToString
                End If
            Else
                objordets.WFAO_RTE = DBNull.Value.ToString

            End If
            If Not objordets.WFAO_DAA = Nothing Then
                If (objordets.WFAO_DAA.ToString.Length = 0) Then
                    objordets.WFAO_DAA = DBNull.Value.ToString
                End If
            Else
                objordets.WFAO_DAA = DBNull.Value.ToString

            End If
            If Not objordets.WFAO_AA = Nothing Then
                If (objordets.WFAO_AA.ToString.Length = 0) Then
                    objordets.WFAO_AA = DBNull.Value.ToString
                End If
            Else
                objordets.WFAO_AA = DBNull.Value.ToString
            End If
            If Not objordets.WFAO_ACT = Nothing Then
                If (objordets.WFAO_ACT.ToString.Length = 0) Then
                    objordets.WFAO_ACT = DBNull.Value.ToString
                End If
            Else
                objordets.WFAO_ACT = DBNull.Value.ToString
            End If
            If Not objordets.WFAO_CKLNAME = Nothing Then
                If (objordets.WFAO_CKLNAME.ToString.Length = 0) Then
                    objordets.WFAO_CKLNAME = DBNull.Value.ToString
                End If
            Else
                objordets.WFAO_CKLNAME = DBNull.Value.ToString
            End If
            If Not objordets.WFAO_CKLADDR = Nothing Then
                If (objordets.WFAO_CKLADDR.ToString.Length = 0) Then
                    objordets.WFAO_CKLADDR = DBNull.Value.ToString
                End If
            Else
                objordets.WFAO_CKLADDR = DBNull.Value.ToString

            End If
            If Not objordets.WFAO_COMM = Nothing Then
                If (objordets.WFAO_COMM.ToString.Length = 0) Then
                    objordets.WFAO_COMM = DBNull.Value.ToString
                End If
            Else
                objordets.WFAO_COMM = DBNull.Value.ToString

            End If
            If Not objordets.WFAO_START_DATE = Nothing Then
                If (objordets.WFAO_START_DATE.ToString.Length = 0) Then
                    objordets.WFAO_START_DATE = DBNull.Value.ToString
                End If
            Else
                objordets.WFAO_START_DATE = DBNull.Value.ToString

            End If
            If Not objordets.WFAO_ACC = Nothing Then
                If (objordets.WFAO_ACC.ToString.Length = 0) Then
                    objordets.WFAO_ACC = DBNull.Value.ToString
                End If
            Else
                objordets.WFAO_ACC = DBNull.Value.ToString

            End If
            If Not objordets.WFAO_A = Nothing Then
                If (objordets.WFAO_A.ToString.Length = 0) Then
                    objordets.WFAO_A = DBNull.Value.ToString
                End If
            Else
                objordets.WFAO_A = DBNull.Value.ToString

            End If
            If Not objordets.WFAO_B = Nothing Then
                If (objordets.WFAO_B.ToString.Length = 0) Then
                    objordets.WFAO_B = DBNull.Value.ToString
                End If
            Else
                objordets.WFAO_B = DBNull.Value.ToString

            End If
            If Not objordets.WFAO_DD = Nothing Then
                If (objordets.WFAO_DD.ToString.Length = 0) Then
                    objordets.WFAO_DD = DBNull.Value.ToString
                End If
            Else
                objordets.WFAO_DD = DBNull.Value.ToString

            End If
            If Not objordets.WFAO_PRC = Nothing Then
                If (objordets.WFAO_PRC.ToString.Length = 0) Then
                    objordets.WFAO_PRC = DBNull.Value.ToString
                End If
            Else
                objordets.WFAO_PRC = DBNull.Value.ToString

            End If
            If Not objordets.WFAO_TPRC = Nothing Then
                If (objordets.WFAO_TPRC.ToString.Length = 0) Then
                    objordets.WFAO_TPRC = DBNull.Value.ToString
                End If
            Else
                objordets.WFAO_TPRC = DBNull.Value.ToString

            End If
            If Not objordets.WFAO_ORD_ORIG = Nothing Then
                If (objordets.WFAO_ORD_ORIG.ToString.Length = 0) Then
                    objordets.WFAO_ORD_ORIG = DBNull.Value.ToString
                End If
            Else
                objordets.WFAO_ORD_ORIG = DBNull.Value.ToString
            End If
            If Not objordets.WFAO_SVY = Nothing Then
                If (objordets.WFAO_SVY.ToString.Length = 0) Then
                    objordets.WFAO_SVY = DBNull.Value.ToString
                End If
            Else
                objordets.WFAO_SVY = DBNull.Value.ToString
            End If
            If Not objordets.WFAO_PST = Nothing Then
                If (objordets.WFAO_PST.ToString.Length = 0) Then
                    objordets.WFAO_PST = DBNull.Value.ToString
                End If
            Else
                objordets.WFAO_PST = DBNull.Value.ToString

            End If

            If Not objordets.WFAO_JOBPRI = Nothing Then
                If (objordets.WFAO_JOBPRI.ToString.Length = 0) Then
                    objordets.WFAO_JOBPRI = DBNull.Value.ToString
                End If
            Else
                objordets.WFAO_JOBPRI = DBNull.Value.ToString

            End If
            If Not objordets.WFAO_FACILITY_LABEL = Nothing Then
                If (objordets.WFAO_FACILITY_LABEL.ToString.Length = 0) Then
                    objordets.WFAO_FACILITY_LABEL = DBNull.Value.ToString
                End If
            Else
                objordets.WFAO_FACILITY_LABEL = DBNull.Value.ToString

            End If
            If Not objordets.WFAO_F1 = Nothing Then
                If (objordets.WFAO_F1.ToString.Length = 0) Then
                    objordets.WFAO_F1 = DBNull.Value.ToString
                End If
            Else
                objordets.WFAO_F1 = DBNull.Value.ToString

            End If
            If Not objordets.WFAO_PR = Nothing Then
                If (objordets.WFAO_PR.ToString.Length = 0) Then
                    objordets.WFAO_PR = DBNull.Value.ToString
                End If
            Else
                objordets.WFAO_PR = DBNull.Value.ToString

            End If
            If Not objordets.WFAO_JOB = Nothing Then
                If (objordets.WFAO_JOB.ToString.Length = 0) Then
                    objordets.WFAO_JOB = DBNull.Value.ToString
                End If
            Else
                objordets.WFAO_JOB = DBNull.Value.ToString
            End If
            If Not objordets.WFAO_DOCOMM_1 = Nothing Then
                If (objordets.WFAO_DOCOMM_1.ToString.Length = 0) Then
                    objordets.WFAO_DOCOMM_1 = DBNull.Value.ToString
                End If
            Else
                objordets.WFAO_DOCOMM_1 = DBNull.Value.ToString

            End If
            If Not objordets.WFAO_DOCOMM_2 = Nothing Then
                If (objordets.WFAO_DOCOMM_2.ToString.Length = 0) Then
                    objordets.WFAO_DOCOMM_2 = DBNull.Value.ToString
                End If
            Else
                objordets.WFAO_DOCOMM_2 = DBNull.Value.ToString

            End If
            If Not objordets.WFAO_DOCOMM_3 = Nothing Then
                If (objordets.WFAO_DOCOMM_3.ToString.Length = 0) Then
                    objordets.WFAO_DOCOMM_3 = DBNull.Value.ToString
                End If
            Else
                objordets.WFAO_DOCOMM_3 = DBNull.Value.ToString

            End If
            If Not objordets.WFAO_DOCOMM_4 = Nothing Then
                If (objordets.WFAO_DOCOMM_4.ToString.Length = 0) Then
                    objordets.WFAO_DOCOMM_4 = DBNull.Value.ToString
                End If
            Else
                objordets.WFAO_DOCOMM_4 = DBNull.Value.ToString

            End If
            If Not objordets.WFAO_DOCOMM_5 = Nothing Then
                If (objordets.WFAO_DOCOMM_5.ToString.Length = 0) Then
                    objordets.WFAO_DOCOMM_5 = DBNull.Value.ToString
                End If
            Else
                objordets.WFAO_DOCOMM_5 = DBNull.Value.ToString

            End If
            If Not objordets.WFAO_DOCOMM_6 = Nothing Then
                If (objordets.WFAO_DOCOMM_6.ToString.Length = 0) Then
                    objordets.WFAO_DOCOMM_6 = DBNull.Value.ToString
                End If
            Else
                objordets.WFAO_DOCOMM_6 = DBNull.Value.ToString

            End If
            If Not objordets.WFAO_DOCOMM_7 = Nothing Then
                If (objordets.WFAO_DOCOMM_7.ToString.Length = 0) Then
                    objordets.WFAO_DOCOMM_7 = DBNull.Value.ToString
                End If
            Else
                objordets.WFAO_DOCOMM_7 = DBNull.Value.ToString

            End If
            If Not objordets.WFAI_DEBRIEF_COMMENTS = Nothing Then
                If (objordets.WFAI_DEBRIEF_COMMENTS.ToString.Length = 0) Then
                    objordets.WFAI_DEBRIEF_COMMENTS = DBNull.Value.ToString
                End If
            Else
                objordets.WFAI_DEBRIEF_COMMENTS = DBNull.Value.ToString

            End If
            If Not objordets.WFAI_JOB_RETURNED = Nothing Then
                If (objordets.WFAI_JOB_RETURNED.ToString.Length = 0) Then
                    objordets.WFAI_JOB_RETURNED = DBNull.Value.ToString
                End If
            Else
                objordets.WFAI_JOB_RETURNED = DBNull.Value.ToString

            End If
            If Not objordets.MSG_INS_UPDATE_CANCEL = Nothing Then
                If (objordets.MSG_INS_UPDATE_CANCEL.ToString.Length = 0) Then
                    objordets.MSG_INS_UPDATE_CANCEL = DBNull.Value.ToString
                End If
            Else
                objordets.MSG_INS_UPDATE_CANCEL = DBNull.Value.ToString

            End If
            If Not objordets.MSG_STATUS = Nothing Then
                If (objordets.MSG_STATUS.ToString.Length = 0) Then
                    objordets.MSG_STATUS = DBNull.Value.ToString
                End If
            Else
                objordets.MSG_STATUS = DBNull.Value.ToString

            End If
            If Not objordets.MSG_ERROR = Nothing Then
                If (objordets.MSG_ERROR.ToString.Length = 0) Then
                    objordets.MSG_ERROR = DBNull.Value.ToString
                End If
            Else
                objordets.MSG_ERROR = DBNull.Value.ToString

            End If
            If Not objordets.EXCEPTION_INFO = Nothing Then
                If (objordets.EXCEPTION_INFO.ToString.Length = 0) Then
                    objordets.EXCEPTION_INFO = DBNull.Value.ToString
                End If
            Else
                objordets.EXCEPTION_INFO = DBNull.Value.ToString

            End If
            If Not objordets.CREATED_BY = Nothing Then
                If (objordets.CREATED_BY.ToString.Length = 0) Then
                    objordets.CREATED_BY = DBNull.Value.ToString
                End If
            Else
                objordets.CREATED_BY = DBNull.Value.ToString

            End If
            If Not objordets.CREATION_DATE = Nothing Then
                If (objordets.CREATION_DATE.ToString.Length = 0) Then
                    objordets.CREATION_DATE = DBNull.Value.ToString
                End If
            Else
                objordets.CREATION_DATE = DBNull.Value.ToString

            End If
            If Not objordets.LAST_UPDATED_BY = Nothing Then
                If (objordets.LAST_UPDATED_BY.ToString.Length = 0) Then
                    objordets.LAST_UPDATED_BY = DBNull.Value.ToString
                End If
            Else
                objordets.LAST_UPDATED_BY = DBNull.Value.ToString

            End If
            If Not objordets.LAST_UPDATE_DATE = Nothing Then
                If (objordets.LAST_UPDATE_DATE.ToString.Length = 0) Then
                    objordets.LAST_UPDATE_DATE = DBNull.Value.ToString
                End If
            Else
                objordets.LAST_UPDATE_DATE = DBNull.Value.ToString

            End If
            If Not objordets.LAST_UPDATE_LOGIN = Nothing Then
                If (objordets.LAST_UPDATE_LOGIN.ToString.Length = 0) Then
                    objordets.LAST_UPDATE_LOGIN = DBNull.Value.ToString
                End If
            Else
                objordets.LAST_UPDATE_LOGIN = DBNull.Value.ToString

            End If
            If Not objordets.Ticket_Status = Nothing Then
                If (objordets.Ticket_Status.ToString.Length = 0) Then
                    objordets.Ticket_Status = DBNull.Value.ToString
                End If
            Else
                objordets.Ticket_Status = DBNull.Value.ToString

            End If
            If Not objordets.WFAO_LOC_CITY = Nothing Then
                If (objordets.WFAO_LOC_CITY.ToString.Length = 0) Then
                    objordets.WFAO_LOC_CITY = DBNull.Value.ToString
                End If
            Else
                objordets.WFAO_LOC_CITY = DBNull.Value.ToString

            End If
            If Not objordets.WFAO_LOC_STATE = Nothing Then
                If (objordets.WFAO_LOC_STATE.ToString.Length = 0) Then
                    objordets.WFAO_LOC_STATE = DBNull.Value.ToString
                End If
            Else
                objordets.WFAO_LOC_STATE = DBNull.Value.ToString

            End If
            If Not objordets.WFAO_TASK_PRIORITY = Nothing Then
                If (objordets.WFAO_TASK_PRIORITY.ToString.Length = 0) Then
                    objordets.WFAO_TASK_PRIORITY = DBNull.Value.ToString
                End If
            Else
                objordets.WFAO_TASK_PRIORITY = DBNull.Value.ToString

            End If
            If Not objordets.WFAO_SKILLS = Nothing Then
                If (objordets.WFAO_SKILLS.ToString.Length = 0) Then
                    objordets.WFAO_SKILLS = DBNull.Value.ToString
                End If
            Else
                objordets.WFAO_SKILLS = DBNull.Value.ToString

            End If
            If Not objordets.WFAO_PON = Nothing Then
                If (objordets.WFAO_PON.ToString.Length = 0) Then
                    objordets.WFAO_PON = DBNull.Value.ToString
                End If
            Else
                objordets.WFAO_PON = DBNull.Value.ToString

            End If
            If Not objordets.DEBRIEF_COMMENT_HISTORY = Nothing Then
                If (objordets.DEBRIEF_COMMENT_HISTORY.ToString.Length = 0) Then
                    objordets.DEBRIEF_COMMENT_HISTORY = DBNull.Value.ToString
                End If
            Else
                objordets.DEBRIEF_COMMENT_HISTORY = DBNull.Value.ToString

            End If
            If Not objordets.PREV_WFAI_JSTAT = Nothing Then
                If (objordets.PREV_WFAI_JSTAT.ToString.Length = 0) Then
                    objordets.PREV_WFAI_JSTAT = DBNull.Value.ToString
                End If
            Else
                objordets.PREV_WFAI_JSTAT = DBNull.Value.ToString

            End If
            If Not objordets.TASK_CREATED_BY = Nothing Then
                If (objordets.TASK_CREATED_BY.ToString.Length = 0) Then
                    objordets.TASK_CREATED_BY = DBNull.Value.ToString
                End If
            Else
                objordets.TASK_CREATED_BY = DBNull.Value.ToString

            End If
            If Not objordets.SR_CREATED_BY = Nothing Then
                If (objordets.SR_CREATED_BY.ToString.Length = 0) Then
                    objordets.SR_CREATED_BY = DBNull.Value.ToString
                End If
            Else
                objordets.SR_CREATED_BY = DBNull.Value.ToString

            End If
            If Not objordets.Ticket_Created_Date = Nothing Then
                If (objordets.Ticket_Created_Date.ToString.Length = 0) Then
                    objordets.Ticket_Created_Date = DBNull.Value.ToString
                End If
            Else
                objordets.Ticket_Created_Date = DBNull.Value.ToString

            End If
            ' End If
            'End If
            ' End If
            If objordets.Ticket_Status = "TICKET CREATED" Then
                objInsert = Array.CreateInstance(GetType(Object), 66)

                objInsert.SetValue(objordets.Task_Id, 0)
                objInsert.SetValue(objordets.Incident_Id, 1) 'have to add param
                objInsert.SetValue(objordets.Task_Number, 2) 'have to add param
                objInsert.SetValue(objordets.Incident_Number, 3)
                'objInsert.SetValue(objordets.WFAO_CENTER, 4)
                objInsert.SetValue(objordets.WFAO_JOBID, 4)
                objInsert.SetValue(objordets.WFAI_JSTAT, 5)
                objInsert.SetValue(objordets.WFAO_JT, 6)
                objInsert.SetValue(objordets.WFAO_TASK_PRIORITY, 7)
                objInsert.SetValue(objordets.WFAO_SKILLS, 8)
                objInsert.SetValue(objordets.WFAO_CKTID, 9)
                objInsert.SetValue(objordets.WFAO_POM, 10)
                objInsert.SetValue(objordets.WFAO_PON, 11)
                objInsert.SetValue(objordets.WFAO_BILLNAME, 12)
                objInsert.SetValue(objordets.WFAO_TELEPHONE, 13)
                objInsert.SetValue(objordets.WFAO_WC, 14)
                objInsert.setvalue(objordets.WFAO_RTE, 15)
                objInsert.SetValue(objordets.WFAO_DAA, 16)
                objInsert.SetValue(objordets.WFAO_AA, 17)
                objInsert.SetValue(objordets.WFAO_ACT, 18)
                objInsert.SetValue(objordets.WFAO_CKLNAME, 19)
                objInsert.SetValue(objordets.WFAO_CKLADDR, 20)
                objInsert.SetValue(objordets.WFAO_LOC_CITY, 21)
                objInsert.SetValue(objordets.WFAO_LOC_STATE, 22)
                objInsert.SetValue(objordets.WFAO_COMM, 23)
                objInsert.SetValue(objordets.WFAO_START_DATE, 24)
                objInsert.SetValue(objordets.WFAO_ACC, 25)
                objInsert.SetValue(objordets.WFAO_A, 26)
                objInsert.SetValue(objordets.WFAO_B, 27)
                objInsert.SetValue(objordets.WFAO_DD, 28)
                objInsert.SetValue(objordets.WFAO_PRC, 29)
                objInsert.SetValue(objordets.WFAO_TPRC, 30)
                objInsert.SetValue(objordets.WFAO_ORD_ORIG, 31)
                objInsert.SetValue(objordets.WFAO_SVY, 32)
                objInsert.SetValue(objordets.WFAO_PST, 33)
                objInsert.SetValue(objordets.WFAO_COMMENTS_SUBJECT, 34)
                objInsert.SetValue(objordets.WFAO_COMMENTS_URGENCY, 35)
                objInsert.SetValue(objordets.WFAO_JOBPRI, 36)
                objInsert.SetValue(objordets.WFAO_FACILITY_LABEL, 37)
                objInsert.SetValue(objordets.WFAO_F1, 38)
                objInsert.SetValue(objordets.WFAO_PR, 39)
                objInsert.SetValue(objordets.WFAO_JOB, 40)
                objInsert.SetValue(objordets.WFAO_SCRATCHPAD_TASK_DESC, 41)
                objInsert.SetValue(objordets.WFAO_DOCOMM_1, 42)
                objInsert.SetValue(objordets.WFAO_DOCOMM_2, 43)
                objInsert.SetValue(objordets.WFAO_DOCOMM_3, 44)
                objInsert.SetValue(objordets.WFAO_DOCOMM_4, 45)
                objInsert.SetValue(objordets.WFAO_DOCOMM_5, 46)
                objInsert.SetValue(objordets.WFAO_DOCOMM_6, 47)
                objInsert.SetValue(objordets.WFAO_DOCOMM_7, 48)
                objInsert.SetValue(objordets.WFAI_DEBRIEF_COMMENTS, 49)
                objInsert.SetValue(objordets.WFAI_JOB_RETURNED, 50)
                objInsert.SetValue(objordets.MSG_INS_UPDATE_CANCEL, 51)
                objInsert.SetValue(objordets.MSG_STATUS, 52)
                objInsert.SetValue(objordets.MSG_ERROR, 53)
                objInsert.SetValue(objordets.EXCEPTION_INFO, 54)
                objInsert.SetValue(objordets.DEBRIEF_COMMENT_HISTORY, 55)
                objInsert.SetValue(objordets.PREV_WFAI_JSTAT, 56)
                objInsert.SetValue(objordets.TASK_CREATED_BY, 57)
                objInsert.SetValue(objordets.SR_CREATED_BY, 58)
                objInsert.SetValue(objordets.CREATED_BY, 59)
                objInsert.SetValue(objordets.CREATION_DATE, 60)
                objInsert.SetValue(objordets.LAST_UPDATED_BY, 61)
                objInsert.SetValue(objordets.LAST_UPDATE_DATE, 62)
                objInsert.SetValue(objordets.LAST_UPDATE_LOGIN, 63)
                objInsert.SetValue(objordets.Ticket_Status, 64)
                objInsert.SetValue(objordets.Ticket_Created_Date, 65)

                strUpdateQuery = "UPDATE [OracleCPE].[dbo].[INPUT_HEADER_STAGE] SET [TASK_ID] = ?,[INCIDENT_ID] = ?,[TASK_NUMBER] = ?,[INCIDENT_NUMBER] = ?,[WFAO_JOBID] = ?,[WFAI_JSTAT] = ?,[WFAO_JT] = ?,[WFAO_TASK_PRIORITY] = ?,[WFAO_SKILLS] = ?,[WFAO_CKTID] = ?,[WFAO_POM] = ?,[WFAO_PON] = ?,[WFAO_BILLNAME] = ?,[WFAO_TELEPHONE] = ?,[WFAO_WC] = ?,[WFAO_RTE] = ?,[WFAO_DAA] = ?,[WFAO_AA] = ?,[WFAO_ACT] = ?,[WFAO_CKLNAME] = ?,[WFAO_CKLADDR] = ?,[WFAO_LOC_CITY] = ?,[WFAO_LOC_STATE] = ?,[WFAO_COMM] = ?,[WFAO_START_DATE] = ?,[WFAO_ACC] = ?,[WFAO_A] = ?,[WFAO_B] = ?,[WFAO_DD] = ?,[WFAO_PRC] = ?,[WFAO_TPRC] = ?,[WFAO_ORD_ORIG] = ?,[WFAO_SVY] = ?,[WFAO_PST] = ?,[WFAO_COMMENTS_SUBJECT] = ?,[WFAO_COMMENTS_URGENCY] = ?,[WFAO_JOBPRI] = ?,[WFAO_FACILITY_LABEL] = ?,[WFAO_F1] = ?   ,[WFAO_PR] = ?,[WFAO_JOB] = ?,[WFAO_SCRATCHPAD_TASK_DESC] = ?,[WFAO_DOCOMM_1] = ?,[WFAO_DOCOMM_2] = ?,[WFAO_DOCOMM_3] = ?,[WFAO_DOCOMM_4] = ? ,[WFAO_DOCOMM_5] = ?,[WFAO_DOCOMM_6] = ?,[WFAO_DOCOMM_7] = ?,[WFAI_DEBRIEF_COMMENTS] = ?,[WFAI_JOB_RETURNED] = ?,[MSG_INS_UPDATE_CANCEL] = ?,[MSG_STATUS] = ?,[MSG_ERROR] = ?,[EXCEPTION_INFO] = ?,[DEBRIEF_COMMENT_HISTORY] = ?,[PREV_WFAI_JSTAT] = ?,[TASK_CREATED_BY] = ?,[SR_CREATED_BY] = ?,[CREATED_BY] = ?,[CREATION_DATE] = ?,[LAST_UPDATED_BY] = ?,[LAST_UPDATE_DATE] = ?,[LAST_UPDATE_LOGIN] = ?,[TICKET_STATUS] = ?,[Ticket_Created_Date]=? WHERE [TASK_ID]='" + objordets.Task_Id + "'"
                objDbutility.UpdateQuery([Global].p_sCPE_NOTIFIERDB, strUpdateQuery, ex1, objInsert)
            Else
                objInsert = Array.CreateInstance(GetType(Object), 65)

                objInsert.SetValue(objordets.Task_Id, 0)
                objInsert.SetValue(objordets.Incident_Id, 1) 'have to add param
                objInsert.SetValue(objordets.Task_Number, 2) 'have to add param
                objInsert.SetValue(objordets.Incident_Number, 3)
                'objInsert.SetValue(objordets.WFAO_CENTER, 4)
                objInsert.SetValue(objordets.WFAO_JOBID, 4)
                objInsert.SetValue(objordets.WFAI_JSTAT, 5)
                objInsert.SetValue(objordets.WFAO_JT, 6)
                objInsert.SetValue(objordets.WFAO_TASK_PRIORITY, 7)
                objInsert.SetValue(objordets.WFAO_SKILLS, 8)
                objInsert.SetValue(objordets.WFAO_CKTID, 9)
                objInsert.SetValue(objordets.WFAO_POM, 10)
                objInsert.SetValue(objordets.WFAO_PON, 11)
                objInsert.SetValue(objordets.WFAO_BILLNAME, 12)
                objInsert.SetValue(objordets.WFAO_TELEPHONE, 13)
                objInsert.SetValue(objordets.WFAO_WC, 14)
                objInsert.setvalue(objordets.WFAO_RTE, 15)
                objInsert.SetValue(objordets.WFAO_DAA, 16)
                objInsert.SetValue(objordets.WFAO_AA, 17)
                objInsert.SetValue(objordets.WFAO_ACT, 18)
                objInsert.SetValue(objordets.WFAO_CKLNAME, 19)
                objInsert.SetValue(objordets.WFAO_CKLADDR, 20)
                objInsert.SetValue(objordets.WFAO_LOC_CITY, 21)
                objInsert.SetValue(objordets.WFAO_LOC_STATE, 22)
                objInsert.SetValue(objordets.WFAO_COMM, 23)
                objInsert.SetValue(objordets.WFAO_START_DATE, 24)
                objInsert.SetValue(objordets.WFAO_ACC, 25)
                objInsert.SetValue(objordets.WFAO_A, 26)
                objInsert.SetValue(objordets.WFAO_B, 27)
                objInsert.SetValue(objordets.WFAO_DD, 28)
                objInsert.SetValue(objordets.WFAO_PRC, 29)
                objInsert.SetValue(objordets.WFAO_TPRC, 30)
                objInsert.SetValue(objordets.WFAO_ORD_ORIG, 31)
                objInsert.SetValue(objordets.WFAO_SVY, 32)
                objInsert.SetValue(objordets.WFAO_PST, 33)
                objInsert.SetValue(objordets.WFAO_COMMENTS_SUBJECT, 34)
                objInsert.SetValue(objordets.WFAO_COMMENTS_URGENCY, 35)
                objInsert.SetValue(objordets.WFAO_JOBPRI, 36)
                objInsert.SetValue(objordets.WFAO_FACILITY_LABEL, 37)
                objInsert.SetValue(objordets.WFAO_F1, 38)
                objInsert.SetValue(objordets.WFAO_PR, 39)
                objInsert.SetValue(objordets.WFAO_JOB, 40)
                objInsert.SetValue(objordets.WFAO_SCRATCHPAD_TASK_DESC, 41)
                objInsert.SetValue(objordets.WFAO_DOCOMM_1, 42)
                objInsert.SetValue(objordets.WFAO_DOCOMM_2, 43)
                objInsert.SetValue(objordets.WFAO_DOCOMM_3, 44)
                objInsert.SetValue(objordets.WFAO_DOCOMM_4, 45)
                objInsert.SetValue(objordets.WFAO_DOCOMM_5, 46)
                objInsert.SetValue(objordets.WFAO_DOCOMM_6, 47)
                objInsert.SetValue(objordets.WFAO_DOCOMM_7, 48)
                objInsert.SetValue(objordets.WFAI_DEBRIEF_COMMENTS, 49)
                objInsert.SetValue(objordets.WFAI_JOB_RETURNED, 50)
                objInsert.SetValue(objordets.MSG_INS_UPDATE_CANCEL, 51)
                objInsert.SetValue(objordets.MSG_STATUS, 52)
                objInsert.SetValue(objordets.MSG_ERROR, 53)
                objInsert.SetValue(objordets.EXCEPTION_INFO, 54)
                objInsert.SetValue(objordets.DEBRIEF_COMMENT_HISTORY, 55)
                objInsert.SetValue(objordets.PREV_WFAI_JSTAT, 56)
                objInsert.SetValue(objordets.TASK_CREATED_BY, 57)
                objInsert.SetValue(objordets.SR_CREATED_BY, 58)
                objInsert.SetValue(objordets.CREATED_BY, 59)
                objInsert.SetValue(objordets.CREATION_DATE, 60)
                objInsert.SetValue(objordets.LAST_UPDATED_BY, 61)
                objInsert.SetValue(objordets.LAST_UPDATE_DATE, 62)
                objInsert.SetValue(objordets.LAST_UPDATE_LOGIN, 63)
                objInsert.SetValue(objordets.Ticket_Status, 64)
                'objInsert.SetValue(objordets.Ticket_Created_Date, 65)

                strUpdateQuery = "UPDATE [OracleCPE].[dbo].[INPUT_HEADER_STAGE] SET [TASK_ID] = ?,[INCIDENT_ID] = ?,[TASK_NUMBER] = ?,[INCIDENT_NUMBER] = ?,[WFAO_JOBID] = ?,[WFAI_JSTAT] = ?,[WFAO_JT] = ?,[WFAO_TASK_PRIORITY] = ?,[WFAO_SKILLS] = ?,[WFAO_CKTID] = ?,[WFAO_POM] = ?,[WFAO_PON] = ?,[WFAO_BILLNAME] = ?,[WFAO_TELEPHONE] = ?,[WFAO_WC] = ?,[WFAO_RTE] = ?,[WFAO_DAA] = ?,[WFAO_AA] = ?,[WFAO_ACT] = ?,[WFAO_CKLNAME] = ?,[WFAO_CKLADDR] = ?,[WFAO_LOC_CITY] = ?,[WFAO_LOC_STATE] = ?,[WFAO_COMM] = ?,[WFAO_START_DATE] = ?,[WFAO_ACC] = ?,[WFAO_A] = ?,[WFAO_B] = ?,[WFAO_DD] = ?,[WFAO_PRC] = ?,[WFAO_TPRC] = ?,[WFAO_ORD_ORIG] = ?,[WFAO_SVY] = ?,[WFAO_PST] = ?,[WFAO_COMMENTS_SUBJECT] = ?,[WFAO_COMMENTS_URGENCY] = ?,[WFAO_JOBPRI] = ?,[WFAO_FACILITY_LABEL] = ?,[WFAO_F1] = ?   ,[WFAO_PR] = ?,[WFAO_JOB] = ?,[WFAO_SCRATCHPAD_TASK_DESC] = ?,[WFAO_DOCOMM_1] = ?,[WFAO_DOCOMM_2] = ?,[WFAO_DOCOMM_3] = ?,[WFAO_DOCOMM_4] = ? ,[WFAO_DOCOMM_5] = ?,[WFAO_DOCOMM_6] = ?,[WFAO_DOCOMM_7] = ?,[WFAI_DEBRIEF_COMMENTS] = ?,[WFAI_JOB_RETURNED] = ?,[MSG_INS_UPDATE_CANCEL] = ?,[MSG_STATUS] = ?,[MSG_ERROR] = ?,[EXCEPTION_INFO] = ?,[DEBRIEF_COMMENT_HISTORY] = ?,[PREV_WFAI_JSTAT] = ?,[TASK_CREATED_BY] = ?,[SR_CREATED_BY] = ?,[CREATED_BY] = ?,[CREATION_DATE] = ?,[LAST_UPDATED_BY] = ?,[LAST_UPDATE_DATE] = ?,[LAST_UPDATE_LOGIN] = ?,[TICKET_STATUS] = ? WHERE [TASK_ID]='" + objordets.Task_Id + "'"
                objDbutility.UpdateQuery([Global].p_sCPE_NOTIFIERDB, strUpdateQuery, ex1, objInsert)
            End If
            If (ex1 Is Nothing) Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            p_objLogger.writenote("Exception: :-" & ex.ToString(), objordets.Task_Id, EventLogEntryType.Error)
        End Try
    End Function
    Function UpdateInputHeader(ByVal objordets As Object)

        Try
            'Dim objQueryFleHndlr As New FileHandler.INIFileHandler(p_sCPE_NotifierIni)
            Dim objDbutility As New DBUtilities.DBConnect
            objDbutility = SQLDBUtil()
            Dim objInsert As New Object
            Dim ex1 As Exception = Nothing
            Dim StrUpdateQuery As String
            objInsert = Array.CreateInstance(GetType(Object), 4)
            If Not objordets.WFAO_CENTER = Nothing Then
                If (objordets.WFAO_CENTER.ToString.Length = 0) Then
                    objordets.WFAO_CENTER = DBNull.Value.ToString
                End If
            Else
                objordets.WFAO_CENTER = DBNull.Value.ToString
            End If
            If Not objordets.Ticket_Status = Nothing Then
                If (objordets.Ticket_Status.ToString.Length = 0) Then
                    objordets.Ticket_Status = DBNull.Value.ToString
                End If
            Else
                objordets.Ticket_Status = DBNull.Value.ToString
            End If
            If Not objordets.WFAI_JSTAT = Nothing Then
                If (objordets.WFAI_JSTAT.ToString.Length = 0) Then
                    objordets.WFAI_JSTAT = DBNull.Value.ToString
                End If
            Else
                objordets.WFAI_JSTAT = DBNull.Value.ToString
            End If

            If Not objordets.WFAO_WC = Nothing Then
                If (objordets.WFAO_WC.ToString.Length = 0) Then
                    objordets.WFAO_WC = DBNull.Value.ToString
                End If
            Else
                objordets.WFAO_WC = DBNull.Value.ToString
            End If
            objInsert.SetValue(objordets.WFAO_CENTER, 0)
            objInsert.SetValue(objordets.WFAO_WC, 1)
            objInsert.setvalue(objordets.Ticket_Status, 2)
            objInsert.setvalue(objordets.WFAI_JSTAT, 3)
            StrUpdateQuery = "UPDATE [OracleCPE].[dbo].[INPUT_HEADER_STAGE] set [WFAO_CENTER]=?,[WFAO_WC]=?,[TICKET_STATUS]=?,[WFAI_JSTAT]=? where [TASK_ID]='" + objordets.Task_Id + "'"
            objDbutility.UpdateQuery([Global].p_sCPE_NOTIFIERDB, StrUpdateQuery, ex1, objInsert)
            'strInputQuery = "INSERT INTO [OracleCPE].[dbo].[INPUT_HEADER_STAGE] ([TASK_ID],[INCIDENT_ID],[TASK_NUMBER],[INCIDENT_NUMBER],[WFAO_CENTER],[WFAO_JOBID],[WFAI_JSTAT],[WFAO_JT],[WFAO_CKTID],[WFAO_POM],[WFAO_BILLNAME],[WFAO_TELEPHONE],[WFAO_WC],[WFAO_RTE],[WFAO_DAA],[WFAO_AA],[WFAO_ACT],[WFAO_CKLNAME],[WFAO_CKLADDR],[WFAO_COMM],[WFAO_START_DATE],[WFAO_ACC] ,[WFAO_A],[WFAO_B] ,[WFAO_DD],[WFAO_PRC],[WFAO_TPRC],[WFAO_ORD_ORIG],[WFAO_SVY],[WFAO_PST],[WFAO_COMMENTS_SUBJECT],[WFAO_COMMENTS_URGENCY],[WFAO_JOBPRI],[WFAO_FACILITY_LABEL],[WFAO_F1],[WFAO_PR],[WFAO_JOB],[WFAO_SCRATCHPAD_TASK_DESC],[WFAO_DOCOMM_1],[WFAO_DOCOMM_2],[WFAO_DOCOMM_3],[WFAO_DOCOMM_4],[WFAO_DOCOMM_5],[WFAO_DOCOMM_6],[WFAO_DOCOMM_7],[WFAI_DEBRIEF_COMMENTS],[WFAI_JOB_RETURNED],[MSG_INS_UPDATE_CANCEL],[MSG_STATUS],[MSG_ERROR],[EXCEPTION_INFO],[CREATED_BY],[CREATION_DATE],[LAST_UPDATED_BY],[LAST_UPDATE_DATE],[LAST_UPDATE_LOGIN],[WFAO_LOC_CITY],[WFAO_LOC_STATE],[Ticket_Status]) values(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)"
            'objDbutility.InsertQuery([Global].p_sCPE_NOTIFIERDB, strInputQuery, ex1, objInsert)
            If (ex1 Is Nothing) Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            p_objLogger.writenote("Exception: :-" & ex.ToString(), objordets.Task_Id, EventLogEntryType.Error)
        End Try
    End Function
    Function Debrief_Input_Header(ByVal objordets As OrderDetails)
        Try
            Dim objDbutility As New DBUtilities.DBConnect
            objDbutility = SQLDBUtil()
            Dim objInsert As New Object
            Dim ex1 As Exception = Nothing
            Dim StrUpdateQuery As String
            objInsert = Array.CreateInstance(GetType(Object), 3)
            If Not objordets.WFAI_JSTAT = Nothing Then
                If (objordets.WFAI_JSTAT.ToString.Length = 0) Then
                    objordets.WFAI_JSTAT = DBNull.Value.ToString
                End If
            Else
                objordets.WFAI_JSTAT = DBNull.Value.ToString
            End If
            If Not objordets.Ticket_Status = Nothing Then
                If (objordets.Ticket_Status.ToString.Length = 0) Then
                    objordets.Ticket_Status = DBNull.Value.ToString
                End If
            Else
                objordets.Ticket_Status = DBNull.Value.ToString
            End If

            If Not objordets.Job_Started_Date = Nothing Then
                If (objordets.Job_Started_Date.ToString.Length = 0) Then
                    objordets.Job_Started_Date = DBNull.Value.ToString
                End If
            Else
                objordets.Job_Started_Date = DBNull.Value.ToString
            End If
            objInsert.SetValue(objordets.WFAI_JSTAT, 0)
            objInsert.SetValue(objordets.Job_Started_Date, 1)
            objInsert.SetValue(objordets.Ticket_Status, 2)
            StrUpdateQuery = "UPDATE [OracleCPE].[dbo].[INPUT_HEADER_STAGE] set [WFAI_JSTAT]=?,[Job_Started_Date]=?,[TICKET_STATUS]=? where [TASK_ID]='" + objordets.Task_Id + "'"
            objDbutility.UpdateQuery([Global].p_sCPE_NOTIFIERDB, StrUpdateQuery, ex1, objInsert)
        Catch ex As Exception
            p_objLogger.writenote("Exception: :-" & ex.ToString(), objordets.Task_Id, EventLogEntryType.Error)
        End Try
    End Function

    Function Insert_D_Table(ByVal objOrdets As OrderDetails)
        Try
            Dim objDbutility As New DBUtilities.DBConnect
            objDbutility = SQLDBUtil()
            Dim objInsert As New Object
            Dim ObjInsertE As New Object
            Dim ex1 As Exception = Nothing
            Dim StrUpdateQuery As String
            Dim strInputQuery As String
            ObjInsertE = Array.CreateInstance(GetType(Object), 11)
            objInsert = Array.CreateInstance(GetType(Object), 11)
            If Not objOrdets.Task_Id = Nothing Then
                If (objOrdets.Task_Id.ToString.Length = 0) Then
                    objOrdets.Task_Id = DBNull.Value.ToString
                End If
            Else
                objOrdets.Task_Id = DBNull.Value.ToString

            End If
            If Not objOrdets.WFAI_JSTAT = Nothing Then
                If (objOrdets.WFAI_JSTAT.ToString.Length = 0) Then
                    objOrdets.WFAI_JSTAT = DBNull.Value.ToString
                End If
            Else
                objOrdets.WFAI_JSTAT = DBNull.Value.ToString

            End If
            If Not objOrdets.D_WFAI_DOCOMP_REASON_CODE = Nothing Then
                If (objOrdets.D_WFAI_DOCOMP_REASON_CODE.ToString.Length = 0) Then
                    objOrdets.D_WFAI_DOCOMP_REASON_CODE = DBNull.Value.ToString
                End If
            Else
                objOrdets.D_WFAI_DOCOMP_REASON_CODE = DBNull.Value.ToString

            End If
            If Not objOrdets.D_WFAI_DOCOMP_HOURS = Nothing Then
                If (objOrdets.D_WFAI_DOCOMP_HOURS.ToString.Length = 0) Then
                    objOrdets.D_WFAI_DOCOMP_HOURS = DBNull.Value.ToString
                End If
            Else
                objOrdets.D_WFAI_DOCOMP_HOURS = DBNull.Value.ToString

            End If
            If Not objOrdets.D_WFAI_DOCOMP_ITEM = Nothing Then
                If (objOrdets.D_WFAI_DOCOMP_ITEM.ToString.Length = 0) Then
                    objOrdets.D_WFAI_DOCOMP_ITEM = DBNull.Value.ToString
                End If
            Else
                objOrdets.D_WFAI_DOCOMP_ITEM = DBNull.Value.ToString

            End If
            If Not objOrdets.D_WFAI_DOCOMP_LAB_EXP = Nothing Then
                If (objOrdets.D_WFAI_DOCOMP_LAB_EXP.ToString.Length = 0) Then
                    objOrdets.D_WFAI_DOCOMP_LAB_EXP = DBNull.Value.ToString
                End If
            Else
                objOrdets.D_WFAI_DOCOMP_LAB_EXP = DBNull.Value.ToString

            End If
            If Not objOrdets.D_WFAI_DOCOMP_5 = Nothing Then
                If (objOrdets.D_WFAI_DOCOMP_5.ToString.Length = 0) Then
                    objOrdets.D_WFAI_DOCOMP_5 = DBNull.Value.ToString
                End If
            Else
                objOrdets.D_WFAI_DOCOMP_5 = DBNull.Value.ToString

            End If
            If Not objOrdets.D_WFAI_JOB_STRTD = Nothing Then
                If (objOrdets.D_WFAI_JOB_STRTD.ToString.Length = 0) Then
                    objOrdets.D_WFAI_JOB_STRTD = DBNull.Value.ToString
                End If
            Else
                objOrdets.D_WFAI_JOB_STRTD = DBNull.Value.ToString

            End If
            If Not objOrdets.D_MSG_STATUS = Nothing Then
                If (objOrdets.D_MSG_STATUS.ToString.Length = 0) Then
                    objOrdets.D_MSG_STATUS = DBNull.Value.ToString
                End If
            Else
                objOrdets.D_MSG_STATUS = DBNull.Value.ToString

            End If
            If Not objOrdets.D_MSG_ERROR = Nothing Then
                If (objOrdets.D_MSG_ERROR.ToString.Length = 0) Then
                    objOrdets.D_MSG_ERROR = DBNull.Value.ToString
                End If
            Else
                objOrdets.D_MSG_ERROR = DBNull.Value.ToString

            End If
            If Not objOrdets.D_WFAI_DEBRIEF_NUMBER = Nothing Then
                If (objOrdets.D_WFAI_DEBRIEF_NUMBER.ToString.Length = 0) Then
                    objOrdets.D_WFAI_DEBRIEF_NUMBER = DBNull.Value.ToString
                End If
            Else
                objOrdets.D_WFAI_DEBRIEF_NUMBER = DBNull.Value.ToString
            End If
            If Not objOrdets.D_WFAI_DOCOMP_EXP_E = Nothing Then
                If (objOrdets.D_WFAI_DOCOMP_EXP_E.ToString.Length = 0) Then
                    objOrdets.D_WFAI_DOCOMP_EXP_E = DBNull.Value.ToString
                End If
            Else
                objOrdets.D_WFAI_DOCOMP_EXP_E = DBNull.Value.ToString
            End If
            If Not objOrdets.D_WFAI_DOCOMP_EXP_E = Nothing Then
                If (objOrdets.D_WFAI_DOCOMP_EXP_E.ToString.Length = 0) Then
                    objOrdets.D_WFAI_DOCOMP_EXP_E = DBNull.Value.ToString
                End If
            Else
                objOrdets.D_WFAI_DOCOMP_EXP_E = DBNull.Value.ToString
            End If
            If Not objOrdets.D_WFAI_DOCOMP_LAB_EXP_E = Nothing Then
                If (objOrdets.D_WFAI_DOCOMP_LAB_EXP_E.ToString.Length = 0) Then
                    objOrdets.D_WFAI_DOCOMP_LAB_EXP_E = DBNull.Value.ToString
                End If
            Else
                objOrdets.D_WFAI_DOCOMP_LAB_EXP_E = DBNull.Value.ToString
            End If
            If Not objOrdets.D_WFAI_DOCOMP_REASON_CODE_E = Nothing Then
                If (objOrdets.D_WFAI_DOCOMP_REASON_CODE_E.ToString.Length = 0) Then
                    objOrdets.D_WFAI_DOCOMP_REASON_CODE_E = DBNull.Value.ToString
                End If
            Else
                objOrdets.D_WFAI_DOCOMP_REASON_CODE_E = DBNull.Value.ToString
            End If
            Debrief_Item(objOrdets)
            objInsert.SetValue(objOrdets.Task_Id, 0)
            objInsert.SetValue(objOrdets.WFAI_JSTAT, 1) 'have to add param
            objInsert.SetValue(objOrdets.D_WFAI_DOCOMP_REASON_CODE, 2) 'have to add param
            objInsert.SetValue(objOrdets.D_WFAI_DOCOMP_HOURS, 3)
            objInsert.SetValue(objOrdets.D_WFAI_DOCOMP_ITEM, 4)
            objInsert.SetValue(objOrdets.D_WFAI_DOCOMP_LAB_EXP, 5)
            objInsert.SetValue(objOrdets.D_WFAI_DOCOMP_5, 6)
            objInsert.SetValue(objOrdets.D_WFAI_JOB_STRTD, 7)
            objInsert.SetValue("ORACLE_READY", 8)
            objInsert.SetValue(objOrdets.D_MSG_ERROR, 9)
            objInsert.SetValue(objOrdets.D_WFAI_DEBRIEF_NUMBER, 10)
            strInputQuery = "INSERT INTO [OracleCPE].[dbo].[DEBRIEF_TABLE] ([TASK_ID],[WFAI_DOCOMP_STATUS],[WFAI_DOCOMP_REASON_CODE],[WFAI_DOCOMP_HOURS],[WFAI_DOCOMP_ITEM],[WFAI_DOCOMP_LAB_EXP],[WFAI_DOCOMP_5],[WFAI_JOB_STRTD],[MSG_STATUS],[MSG_ERROR],[WFAI_DEBRIEF_NUMBER]) values(?,?,?,?,?,?,?,?,?,?,?)"
            objDbutility.InsertQuery([Global].p_sCPE_NOTIFIERDB, strInputQuery, ex1, objInsert)


            If objOrdets.WFAI_JSTAT = "CMP" Then
                Dim Cmpds As New DataSet
                Dim StrSelectQuery As String
                Dim i As Integer = 0
                Dim j As Integer = 0

                StrSelectQuery = "Select * from [OracleCPE].[dbo].[DEBRIEF_TABLE] where [TASK_ID]='" + objOrdets.Task_Id + "'"
                Cmpds = objDbutility.SelectQuery([Global].p_sCPE_NOTIFIERDB, StrSelectQuery, ex1, Nothing)
                If Cmpds.Tables(0).Rows.Count > 0 Then
                    For i = 0 To Cmpds.Tables(0).Rows.Count - 1

                        j = i + 1
                        objInsert.SetValue(j, 0)
                        objInsert.SetValue(objOrdets.Task_Id, 1)
                        'j = +1
                        'StrUpdateQuery = "UPDATE [OracleCPE].[dbo].[DEBRIEF_TABLE] SET [WFAI_DEBRIEF_NUMBER] ='" + CInt(j) + "' WHERE task_id='10069'"
                        StrUpdateQuery = "UPDATE [OracleCPE].[dbo].[DEBRIEF_TABLE] set [WFAI_DEBRIEF_NUMBER]='" & j & ",[WFAI_JOB_STRTD]='" + objOrdets.D_WFAI_JOB_STRTD + ",WFAI_DOCOMP_ITEM=" + objOrdets.D_WFAI_DOCOMP_ITEM + " where [TASK_ID]='" & Cmpds.Tables(0).Rows(i)(0) & "' and [WFAI_JOB_STRTD]='" & Cmpds.Tables(0).Rows(i)(7) & "' and [WFAI_DOCOMP_STATUS]='" & Cmpds.Tables(0).Rows(i)(1) & "' and [WFAI_DOCOMP_REASON_CODE]='" & Cmpds.Tables(0).Rows(i)(2) & "' and [WFAI_DOCOMP_HOURS]='" & Cmpds.Tables(0).Rows(i)(3) & "' and [WFAI_DOCOMP_ITEM]='" & Cmpds.Tables(0).Rows(i)(4) & "' and [WFAI_DOCOMP_LAB_EXP]='" & Cmpds.Tables(0).Rows(i)(5) & "'"
                        objDbutility.UpdateQuery([Global].p_sCPE_NOTIFIERDB, StrUpdateQuery, ex1, Nothing)
                    Next

                End If

            End If
            If ex1 Is Nothing Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            p_objLogger.writenote("Exception: :-" & ex.ToString(), objOrdets.Task_Id, EventLogEntryType.Error)
        End Try
        Return True
    End Function
    Function Send_mail(ByVal objordets As OrderDetails)
        Try

            Dim mailmessage As MailMessage = New MailMessage()
            Dim objfromaddress As MailAddress = New MailAddress("ccthdt1@centurylink.com")
            Dim objtoaddress As MailAddress = New MailAddress("anjanadevi.chitikineni@centurylink.com")
            Dim objtoaddress1 As MailAddress = New MailAddress("zlandon@centurylink.com")
            Dim objtoaddress2 As MailAddress = New MailAddress("gowthamraj.a@centurylink.com")
            Dim objtoaddress3 As MailAddress = New MailAddress("jbiggio@centurylink.com")
            Dim objtoaddress4 As MailAddress = New MailAddress("LANEWBY@centurylink.com")
            Dim objtoaddress5 As MailAddress = New MailAddress("Donovan.Trevarrow@centurylink.com")
            Dim objSmtpClient As SmtpClient = New SmtpClient()
            Dim body As String
            mailmessage.Subject = "JOB Error Notification " + objordets.WFAO_JOBID
            mailmessage.From = objfromaddress
            mailmessage.To.Add(objtoaddress)
            mailmessage.To.Add(objtoaddress1)
            mailmessage.To.Add(objtoaddress2)
            mailmessage.To.Add(objtoaddress3)
            mailmessage.To.Add(objtoaddress4)
            mailmessage.To.Add(objtoaddress5)
            ' body = "The JOBID " + objordets.WFAO_JOBID + " has been Errored due to " + objordets.MAIL_ERROR_MSG '"private carriage order is received ordernumber is : " & OrderObject.BasicDetails.OrderNo

            body = "<html><body><table><tr><td>Hi All,</td></tr></table></br></br><table><tr><td>The JOBID " + objordets.WFAO_JOBID + " , WFAO Center :" + objordets.WFAO_CENTER + " has been errored due to " + objordets.MAIL_ERROR_MSG + "</td></tr></table></br><table><tr><td>Thanks,</td></tr></table><table><tr><td>Oracle CPE Team</td></tr></table></body></html>"
            mailmessage.Body = body
            objSmtpClient.Host = "mailgate.uswc.uswest.com"
            mailmessage.IsBodyHtml = True
            objSmtpClient.Send(mailmessage)
        Catch ex As Exception
            p_objLogger.writenote("Exception: :-" & ex.ToString(), objordets.Task_Id, EventLogEntryType.Error)
        End Try
    End Function
    Function Debrief_Item(ByVal objordets As OrderDetails)
        Try
            Dim objDbutility As New DBUtilities.DBConnect
            objDbutility = SQLDBUtil()
            Dim Cmpds As New DataSet
            Dim StrSelectQuery As String
            Dim ex1 As Exception = Nothing
            Dim objInsert As Object = Nothing
            StrSelectQuery = "SELECT [ITEM],[DESCRIPTION] FROM [OracleCPE].[dbo].[MAPPING_ITEM] where [WFA_VALUE]='" + objordets.D_WFAI_DOCOMP_ITEM + "'"
            Cmpds = objDbutility.SelectQuery([Global].p_sCPE_NOTIFIERDB, StrSelectQuery, ex1, objInsert)
            If Cmpds.Tables(0).Rows.Count > 0 Then
                If objordets.WFAO_JOBID.Contains("I") Then
                    objordets.D_WFAI_DOCOMP_ITEM = Cmpds.Tables(0).Rows(0)(0)
                ElseIf objordets.WFAO_JOBID.Contains("R") Then
                    objordets.D_WFAI_DOCOMP_ITEM = Cmpds.Tables(0).Rows(1)(0)
                End If
            End If
        Catch ex As Exception
            p_objLogger.writenote("Exception: :-" & ex.ToString(), objordets.Task_Id, EventLogEntryType.Error)
        End Try
        Return objordets
    End Function
End Class
