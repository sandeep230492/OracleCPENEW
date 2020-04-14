Public Class OrderDetails

    Public sTask_Id As String
    Public sIncident_Id As String
    Public sTask_Number As String
    Public sIncident_Number As String
    Public sWFAO_CENTER As String
    Public sWFAO_JOBID As String
    Public sWFAO_CENTER_TECH As String
    Public sWFAI_JSTAT As String
    Public sWFAO_JT As String
    Public sWFAO_CKTID As String
    Public sWFAO_POM As String
    Public sWFAO_BILLNAME As String
    Public sWFAO_TELEPHONE As String
    Public sWFAO_WC As String
    Public sWFAO_RTE As String
    Public sWFAO_DAA As String
    Public sWFAO_AA As String
    Public sWFAO_ACT As String
    Public sWFAO_CKLNAME As String
    Public sWFAO_CKLADDR As String
    Public sWFAO_COMM As String
    Public sWFAO_START_DATE As String
    Public sWFAO_ACC As String
    Public sWFAO_A As String
    Public sWFAO_B As String
    Public sWFAO_DD As String
    Public sWFAO_PRC As String
    Public sWFAO_TPRC As String
    Public sWFAO_ORD_ORIG As String
    Public sWFAO_SVY As String
    Public sWFAO_PST As String
    Public sWFAO_COMMENTS_SUBJECT As String
    Public sWFAO_COMMENTS_URGENCY As String
    Public sWFAO_JOBPRI As String
    Public sWFAO_FACILITY_LABEL As String
    Public sWFAO_F1 As String
    Public sWFAO_PR As String
    Public sWFAO_JOB As String
    Public sWFAO_SCRATCHPAD_TASK_DESC As String
    Public sWFAO_DOCOMM_1 As String
    Public sWFAO_DOCOMM_2 As String
    Public sWFAO_DOCOMM_3 As String
    Public sWFAO_DOCOMM_4 As String
    Public sWFAO_DOCOMM_5 As String
    Public sWFAO_DOCOMM_6 As String
    Public sWFAO_DOCOMM_7 As String
    Public sWFAI_DEBRIEF_COMMENTS As String
    'Public sWFAI_JOB_STRD As String
    Public sWFAI_JOB_RETURNED As String
    Public sMSG_INS_UPDATE_CANCEL As String
    Public sMSG_STATUS As String
    Public sMSG_ERROR As String
    Public sEXCEPTION_INFO As String
    Public sCREATED_BY As String
    Public sCREATION_DATE As String
    Public sLAST_UPDATED_BY As String
    Public sLAST_UPDATE_DATE As String
    Public sLAST_UPDATE_LOGIN As String
    Public sTech_Ec As String
    Public sTech_First_Name As String
    Public sTech_Last_Name As String
    Public sCUID As String
    Public sTicket_Status As String
    Public sName As String
    Public sAddr As String
    Public sRet_Job_Nar As String
    Public sComments As String
    Public sC_Date As String
    Public sTest As String
    Public sOCB As String
    Public sJ_Stat As String
    Public sComm_Date As String
    Public sJob_Assgn As String
    Public sJob_Returned As String
    Public sJob_Started As String
    Public dTask_Id As String
    Public dWFAI_DOCOMP_STATUS As String
    Public dWFAI_DOCOMP_REASON_CODE As String
    Public dWFAI_DOCOMP_HOURS As String
    Public dWFAI_DOCOMP_ITEM As String
    Public dWFAI_DOCOMP_LAB_EXP As String
    Public dWFAI_DOCOMP_5 As String
    Public dWFAI_JOB_STRTD As String
    Public dMSG_STATUS As String
    Public dMSG_ERROR As String
    Public dWFAI_DEBRIEF_NUMBER As String
    Public sWFAO_LOC_CITY As String
    Public sDOSOI_URL As String
    Public sWFAO_LOC_STATE As String
    Public sWFAI_DOCOMP_LAB_EXP_E As String
    Public sWFAI_DOCOMP_REASON_CODE_E As String
    Public sWFAI_DOCOMP_EXP_E As String
    Public sDolog_Comment As String
    Public sDolog_Comment_R_L As String
    Public sDolog_Comment_R_E As String
    Public sDebrief_Comment_History As String
    Public sWFAO_TASK_PRIORITY As String
    Public sWFAO_PON As String
    Public sWFAO_SKILLS As String
    Public sPREV_WFAI_JSTAT As String
    Public sTASK_CREATED_BY As String
    Public sSR_CREATED_BY As String
    Public sExpense_Item As String
    Public sJob_Started_Date As String
    Public sDebrief_Entries As String
    Public sTicket_Created_Date As String
    Public sMAIL_ERROR_MSG As String

    Public Property Expense_ITEM() As String
        Get
            Return sExpense_Item
        End Get
        Set(ByVal pExpense_Item As String)
            sExpense_Item = pExpense_Item
        End Set
    End Property
    Public Property MAIL_ERROR_MSG() As String
        Get
            Return sMAIL_ERROR_MSG
        End Get
        Set(ByVal pMAIL_ERROR_MSG As String)
            sMAIL_ERROR_MSG = pMAIL_ERROR_MSG
        End Set
    End Property


    Public Property Task_Id() As String
        Get
            Return sTask_Id
        End Get
        Set(ByVal pTask_Id As String)
            sTask_Id = pTask_Id
        End Set
    End Property
    Public Property Incident_Id() As String
        Get
            Return sIncident_Id
        End Get
        Set(ByVal pIncident_Id As String)
            sIncident_Id = pIncident_Id
        End Set
    End Property
    Public Property Task_Number() As String
        Get
            Return sTask_Number
        End Get
        Set(ByVal pTask_Number As String)
            sTask_Number = pTask_Number
        End Set
    End Property
    Public Property Incident_Number() As String
        Get
            Return sIncident_Number
        End Get
        Set(ByVal pIncident_Number As String)
            sIncident_Number = pIncident_Number
        End Set
    End Property

    Public Property WFAO_CENTER() As String
        Get
            Return sWFAO_CENTER
        End Get
        Set(ByVal pWFAO_CENTER As String)
            sWFAO_CENTER = pWFAO_CENTER
        End Set
    End Property
    Public Property WFAO_CENTER_TECH() As String
        Get
            Return sWFAO_CENTER_TECH
        End Get
        Set(ByVal pWFAO_CENTER_TECH As String)
            sWFAO_CENTER_TECH = pWFAO_CENTER_TECH
        End Set
    End Property
    Public Property WFAO_JOBID() As String
        Get
            Return sWFAO_JOBID
        End Get
        Set(ByVal pWFAO_JOBID As String)
            sWFAO_JOBID = pWFAO_JOBID
        End Set
    End Property
    Public Property WFAI_JSTAT() As String
        Get
            Return sWFAI_JSTAT
        End Get
        Set(ByVal pWFAI_JSTAT As String)
            sWFAI_JSTAT = pWFAI_JSTAT
        End Set
    End Property
    Public Property WFAO_CKTID() As String
        Get
            Return sWFAO_CKTID
        End Get
        Set(ByVal pWFAO_CKTID As String)
            sWFAO_CKTID = pWFAO_CKTID
        End Set
    End Property
    Public Property WFAO_JT() As String
        Get
            Return sWFAO_JT
        End Get
        Set(ByVal pWFAO_JT As String)
            sWFAO_JT = pWFAO_JT
        End Set
    End Property
    Public Property WFAO_POM() As String
        Get
            Return sWFAO_POM
        End Get
        Set(ByVal pWFAO_POM As String)
            sWFAO_POM = pWFAO_POM
        End Set
    End Property
    Public Property WFAO_BILLNAME() As String
        Get
            Return sWFAO_BILLNAME
        End Get
        Set(ByVal pWFAO_BILLNAME As String)
            sWFAO_BILLNAME = pWFAO_BILLNAME
        End Set
    End Property
    Public Property WFAO_TELEPHONE() As String
        Get
            Return sWFAO_TELEPHONE
        End Get
        Set(ByVal pWFAO_TELEPHONE As String)
            sWFAO_TELEPHONE = pWFAO_TELEPHONE
        End Set
    End Property
    Public Property WFAO_WC() As String
        Get
            Return sWFAO_WC
        End Get
        Set(ByVal pWFAO_WC As String)
            sWFAO_WC = pWFAO_WC
        End Set
    End Property
    Public Property WFAO_RTE() As String
        Get
            Return sWFAO_RTE
        End Get
        Set(ByVal pWFAO_RTE As String)
            sWFAO_RTE = pWFAO_RTE
        End Set
    End Property
    Public Property WFAO_DAA() As String
        Get
            Return sWFAO_DAA
        End Get
        Set(ByVal pWFAO_DAA As String)
            sWFAO_DAA = pWFAO_DAA
        End Set
    End Property
    Public Property WFAO_AA() As String
        Get
            Return sWFAO_DAA
        End Get
        Set(ByVal pWFAO_DAA As String)
            sWFAO_DAA = pWFAO_DAA
        End Set
    End Property
    Public Property WFAO_ACT() As String
        Get
            Return sWFAO_ACT
        End Get
        Set(ByVal pWFAO_ACT As String)
            sWFAO_ACT = pWFAO_ACT
        End Set
    End Property
    Public Property WFAO_CKLNAME() As String
        Get
            Return sWFAO_CKLNAME
        End Get
        Set(ByVal pWFAO_CKLNAME As String)
            sWFAO_CKLNAME = pWFAO_CKLNAME
        End Set
    End Property
    Public Property WFAO_CKLADDR() As String
        Get
            Return sWFAO_CKLADDR
        End Get
        Set(ByVal pWFAO_CKLADDR As String)
            sWFAO_CKLADDR = pWFAO_CKLADDR
        End Set
    End Property
    Public Property WFAO_COMM() As String
        Get
            Return sWFAO_COMM
        End Get
        Set(ByVal pWFAO_COMM As String)
            sWFAO_COMM = pWFAO_COMM
        End Set
    End Property
    Public Property WFAO_START_DATE() As String
        Get
            Return sWFAO_START_DATE
        End Get
        Set(ByVal pWFAO_START_DATE As String)
            sWFAO_START_DATE = pWFAO_START_DATE
        End Set
    End Property
    Public Property WFAO_ACC() As String
        Get
            Return sWFAO_ACC
        End Get
        Set(ByVal pWFAO_ACC As String)
            sWFAO_ACC = pWFAO_ACC
        End Set
    End Property
    Public Property WFAO_A() As String
        Get
            Return sWFAO_A
        End Get
        Set(ByVal pWFAO_A As String)
            sWFAO_A = pWFAO_A
        End Set
    End Property
    Public Property WFAO_B() As String
        Get
            Return sWFAO_B
        End Get
        Set(ByVal pWFAO_B As String)
            sWFAO_B = pWFAO_B
        End Set
    End Property
    Public Property WFAO_DD() As String
        Get
            Return sWFAO_DD
        End Get
        Set(ByVal pWFAO_DD As String)
            sWFAO_DD = pWFAO_DD
        End Set
    End Property
    Public Property WFAO_PRC() As String
        Get
            Return sWFAO_PRC
        End Get
        Set(ByVal pWFAO_PRC As String)
            sWFAO_PRC = pWFAO_PRC
        End Set
    End Property
    Public Property WFAO_TPRC() As String
        Get
            Return sWFAO_TPRC
        End Get
        Set(ByVal pWFAO_TPRC As String)
            sWFAO_TPRC = pWFAO_TPRC
        End Set
    End Property
    Public Property WFAO_ORD_ORIG() As String
        Get
            Return sWFAO_ORD_ORIG
        End Get
        Set(ByVal pWFAO_ORD_ORIG As String)
            sWFAO_ORD_ORIG = pWFAO_ORD_ORIG
        End Set
    End Property
    Public Property WFAO_SVY() As String
        Get
            Return sWFAO_SVY
        End Get
        Set(ByVal pWFAO_SVY As String)
            sWFAO_SVY = pWFAO_SVY
        End Set
    End Property
    Public Property WFAO_PST() As String
        Get
            Return sWFAO_PST
        End Get
        Set(ByVal pWFAO_PST As String)
            sWFAO_PST = pWFAO_PST
        End Set
    End Property
    Public Property WFAO_COMMENTS_SUBJECT() As String
        Get
            Return sWFAO_COMMENTS_SUBJECT
        End Get
        Set(ByVal pWFAO_COMMENTS_SUBJECT As String)
            sWFAO_COMMENTS_SUBJECT = pWFAO_COMMENTS_SUBJECT
        End Set
    End Property
    Public Property WFAO_COMMENTS_URGENCY() As String
        Get
            Return sWFAO_COMMENTS_URGENCY
        End Get
        Set(ByVal pWFAO_COMMENTS_URGENCY As String)
            sWFAO_COMMENTS_URGENCY = pWFAO_COMMENTS_URGENCY
        End Set
    End Property
    Public Property WFAO_JOBPRI() As String
        Get
            Return sWFAO_JOBPRI
        End Get
        Set(ByVal pWFAO_JOBPRI As String)
            sWFAO_JOBPRI = pWFAO_JOBPRI
        End Set
    End Property
    Public Property WFAO_FACILITY_LABEL() As String
        Get
            Return sWFAO_FACILITY_LABEL
        End Get
        Set(ByVal pWFAO_FACILITY_LABLE As String)
            sWFAO_FACILITY_LABEL = pWFAO_FACILITY_LABLE
        End Set
    End Property
    Public Property WFAO_F1() As String
        Get
            Return sWFAO_F1
        End Get
        Set(ByVal pWFAO_F1 As String)
            sWFAO_F1 = pWFAO_F1
        End Set
    End Property
    Public Property WFAO_PR() As String
        Get
            Return sWFAO_PR
        End Get
        Set(ByVal pWFAO_PR As String)
            sWFAO_PR = pWFAO_PR
        End Set
    End Property
    Public Property WFAO_JOB() As String
        Get
            Return sWFAO_JOB
        End Get
        Set(ByVal pWFAO_JOB As String)
            sWFAO_JOB = pWFAO_JOB
        End Set
    End Property
    Public Property WFAO_SCRATCHPAD_TASK_DESC() As String
        Get
            Return sWFAO_SCRATCHPAD_TASK_DESC
        End Get
        Set(ByVal pWFAO_SCRATCHPAD_TASK_DESC As String)
            sWFAO_SCRATCHPAD_TASK_DESC = pWFAO_SCRATCHPAD_TASK_DESC
        End Set
    End Property
    Public Property WFAO_DOCOMM_1() As String
        Get
            Return sWFAO_DOCOMM_1
        End Get
        Set(ByVal pWFAO_DOCOMM_1 As String)
            sWFAO_DOCOMM_1 = pWFAO_DOCOMM_1
        End Set
    End Property
    Public Property WFAO_DOCOMM_2() As String
        Get
            Return sWFAO_DOCOMM_2
        End Get
        Set(ByVal pWFAO_DOCOMM_2 As String)
            sWFAO_DOCOMM_2 = pWFAO_DOCOMM_2
        End Set
    End Property
    Public Property WFAO_DOCOMM_3() As String
        Get
            Return sWFAO_DOCOMM_3
        End Get
        Set(ByVal pWFAO_DOCOMM_3 As String)
            sWFAO_DOCOMM_3 = pWFAO_DOCOMM_3
        End Set
    End Property
    Public Property WFAO_DOCOMM_4() As String
        Get
            Return sWFAO_DOCOMM_4
        End Get
        Set(ByVal pWFAO_DOCOMM_4 As String)
            sWFAO_DOCOMM_4 = pWFAO_DOCOMM_4
        End Set
    End Property
    Public Property WFAO_DOCOMM_5() As String
        Get
            Return sWFAO_DOCOMM_5
        End Get
        Set(ByVal pWFAO_DOCOMM_5 As String)
            sWFAO_DOCOMM_5 = pWFAO_DOCOMM_5
        End Set
    End Property
    Public Property WFAO_DOCOMM_6() As String
        Get
            Return sWFAO_DOCOMM_6
        End Get
        Set(ByVal pWFAO_DOCOMM_6 As String)
            sWFAO_DOCOMM_6 = pWFAO_DOCOMM_6
        End Set
    End Property
    Public Property WFAO_DOCOMM_7() As String
        Get
            Return sWFAO_DOCOMM_7
        End Get
        Set(ByVal pWFAO_DOCOMM_7 As String)
            sWFAO_DOCOMM_7 = pWFAO_DOCOMM_7
        End Set
    End Property
    Public Property WFAI_DEBRIEF_COMMENTS() As String
        Get
            Return sWFAI_DEBRIEF_COMMENTS
        End Get
        Set(ByVal pWFAI_DEBRIEF_COMMENTS As String)
            sWFAI_DEBRIEF_COMMENTS = pWFAI_DEBRIEF_COMMENTS
        End Set
    End Property
    'Public Property WFAI_JOB_STRD() As String
    '    Get
    '        Return sWFAI_JOB_STRD
    '    End Get
    '    Set(ByVal pWFAI_JOB_STRD As String)
    '        sWFAI_JOB_STRD = pWFAI_JOB_STRD
    '    End Set
    'End Property
    Public Property WFAI_JOB_RETURNED() As String
        Get
            Return sWFAI_JOB_RETURNED
        End Get
        Set(ByVal pWFAI_JOB_RETURNED As String)
            sWFAI_JOB_RETURNED = pWFAI_JOB_RETURNED
        End Set
    End Property
    Public Property MSG_INS_UPDATE_CANCEL() As String
        Get
            Return sMSG_INS_UPDATE_CANCEL
        End Get
        Set(ByVal pMSG_INS_UPDATE_CANCEL As String)
            sMSG_INS_UPDATE_CANCEL = pMSG_INS_UPDATE_CANCEL
        End Set
    End Property
    Public Property MSG_STATUS() As String
        Get
            Return sMSG_STATUS
        End Get
        Set(ByVal pMSG_STATUS As String)
            sMSG_STATUS = pMSG_STATUS
        End Set
    End Property
    Public Property MSG_ERROR() As String
        Get
            Return sMSG_ERROR
        End Get
        Set(ByVal pMSG_ERROR As String)
            sMSG_ERROR = pMSG_ERROR
        End Set
    End Property
    Public Property EXCEPTION_INFO() As String
        Get
            Return sEXCEPTION_INFO
        End Get
        Set(ByVal pEXCEPTION_INFO As String)
            sEXCEPTION_INFO = pEXCEPTION_INFO
        End Set
    End Property
    Public Property CREATED_BY() As String
        Get
            Return sCREATED_BY
        End Get
        Set(ByVal pCREATED_BY As String)
            sCREATED_BY = pCREATED_BY
        End Set
    End Property
    Public Property CREATION_DATE() As String
        Get
            Return sCREATION_DATE
        End Get
        Set(ByVal pCREATION_DATE As String)
            sCREATION_DATE = pCREATION_DATE
        End Set
    End Property
    Public Property LAST_UPDATED_BY() As String
        Get
            Return sLAST_UPDATED_BY
        End Get
        Set(ByVal pLAST_UPDATED_BY As String)
            sLAST_UPDATED_BY = pLAST_UPDATED_BY
        End Set
    End Property
    Public Property LAST_UPDATE_DATE() As String
        Get
            Return sLAST_UPDATE_DATE
        End Get
        Set(ByVal pLAST_UPDATE_DATE As String)
            sLAST_UPDATE_DATE = pLAST_UPDATE_DATE
        End Set
    End Property
    Public Property LAST_UPDATE_LOGIN() As String
        Get
            Return sLAST_UPDATE_LOGIN
        End Get
        Set(ByVal pLAST_UPDATE_LOGIN As String)
            sLAST_UPDATE_LOGIN = pLAST_UPDATE_LOGIN
        End Set
    End Property
    Public Property Tech_Ec() As String
        Get
            Return sTech_Ec
        End Get
        Set(ByVal pTech_Ec As String)
            sTech_Ec = pTech_Ec
        End Set
    End Property
    Public Property Tech_First_Name() As String
        Get
            Return sTech_First_Name
        End Get
        Set(ByVal pTech_First_Name As String)
            sTech_First_Name = pTech_First_Name
        End Set
    End Property
    Public Property Tech_Last_Name() As String
        Get
            Return sTech_Last_Name
        End Get
        Set(ByVal pTech_Last_Name As String)
            sTech_Last_Name = pTech_Last_Name
        End Set
    End Property
    Public Property CUID() As String
        Get
            Return sCUID
        End Get
        Set(ByVal pCUID As String)
            sCUID = pCUID
        End Set
    End Property
    Public Property Ticket_Status() As String
        Get
            Return sTicket_Status

        End Get
        Set(ByVal pTicket_status As String)
            sTicket_Status = pTicket_status
        End Set
    End Property
    Public Property Name() As String
        Get
            Return sName
        End Get
        Set(ByVal pName As String)
            sName = pName
        End Set
    End Property
    Public Property Address() As String
        Get
            Return sAddr
        End Get
        Set(ByVal pAddr As String)
            sAddr = pAddr
        End Set
    End Property
    Public Property Ret_Job_Nar() As String
        Get
            Return sRet_Job_Nar
        End Get
        Set(ByVal pRet_Job_Nar As String)
            sRet_Job_Nar = pRet_Job_Nar
        End Set
    End Property
    Public Property Comments() As String
        Get
            Return sComments
        End Get
        Set(ByVal pComments As String)
            sComments = pComments
        End Set
    End Property
    Public Property C_Date() As String
        Get
            Return sC_Date
        End Get
        Set(ByVal pC_Date As String)
            sC_Date = pC_Date
        End Set
    End Property
    Public Property Test() As String
        Get
            Return sTest
        End Get
        Set(ByVal pTest As String)
            sTest = pTest
        End Set
    End Property
    Public Property OCB() As String
        Get
            Return sOCB
        End Get
        Set(ByVal pOCB As String)
            sOCB = pOCB
        End Set
    End Property
    Public Property Job_Stat() As String
        Get
            Return sJ_Stat
        End Get
        Set(ByVal pJ_Stat As String)
            sJ_Stat = pJ_Stat
        End Set
    End Property
    Public Property Comm_Date() As String
        Get
            Return sComm_Date
        End Get
        Set(ByVal pComm_Date As String)
            sComm_Date = pComm_Date
        End Set
    End Property
    Public Property Job_Assgn() As String
        Get
            Return sJob_Assgn
        End Get
        Set(ByVal pJob_Assgn As String)
            sJob_Assgn = pJob_Assgn
        End Set
    End Property
    Public Property Job_Returned() As String
        Get
            Return sJob_Returned
        End Get
        Set(ByVal pJob_Returned As String)
            sJob_Returned = pJob_Returned
        End Set
    End Property
    Public Property Job_Started() As String
        Get
            Return sJob_Started
        End Get
        Set(ByVal pJob_Started As String)
            sJob_Started = pJob_Started
        End Set
    End Property
    Public Property D_WFAI_DEBRIEF_NUMBER() As String
        Get
            Return dWFAI_DEBRIEF_NUMBER
        End Get
        Set(ByVal eWFAI_DEBRIEF_NUMBER As String)
            dWFAI_DEBRIEF_NUMBER = eWFAI_DEBRIEF_NUMBER
        End Set
    End Property
    Public Property D_Task_ID() As String
        Get
            Return dTask_Id
        End Get
        Set(ByVal eTask_Id As String)
            dTask_Id = eTask_Id
        End Set
    End Property
    Public Property D_WFAI_DOCOMP_STATUS() As String
        Get
            Return dWFAI_DOCOMP_STATUS
        End Get
        Set(ByVal eWFAI_DOCOMP_STATUS As String)
            dWFAI_DOCOMP_STATUS = eWFAI_DOCOMP_STATUS
        End Set
    End Property
    Public Property D_WFAI_DOCOMP_REASON_CODE() As String
        Get
            Return dWFAI_DOCOMP_REASON_CODE
        End Get
        Set(ByVal eWFAI_DOCOMP_REASON_CODE As String)
            dWFAI_DOCOMP_REASON_CODE = eWFAI_DOCOMP_REASON_CODE
        End Set
    End Property
    Public Property D_WFAI_DOCOMP_HOURS() As String
        Get
            Return dWFAI_DOCOMP_HOURS
        End Get
        Set(ByVal eWFAI_DOCOMP_HOURS As String)
            dWFAI_DOCOMP_HOURS = eWFAI_DOCOMP_HOURS
        End Set
    End Property
    Public Property D_WFAI_DOCOMP_ITEM() As String
        Get
            Return dWFAI_DOCOMP_ITEM
        End Get
        Set(ByVal eWFAI_DOCOMP_ITEM As String)
            dWFAI_DOCOMP_ITEM = eWFAI_DOCOMP_ITEM
        End Set
    End Property
    Public Property D_WFAI_DOCOMP_LAB_EXP() As String
        Get
            Return dWFAI_DOCOMP_LAB_EXP
        End Get
        Set(ByVal eWFAI_DOCOMP_LAB_EXP As String)
            dWFAI_DOCOMP_LAB_EXP = eWFAI_DOCOMP_LAB_EXP
        End Set
    End Property
    Public Property D_WFAI_DOCOMP_5() As String
        Get
            Return dWFAI_DOCOMP_5
        End Get
        Set(ByVal eWFAI_DOCOMP_5 As String)
            dWFAI_DOCOMP_5 = eWFAI_DOCOMP_5
        End Set
    End Property
    Public Property D_WFAI_JOB_STRTD() As String
        Get
            Return dWFAI_JOB_STRTD
        End Get
        Set(ByVal eWFAI_JOB_STRTD As String)
            dWFAI_JOB_STRTD = eWFAI_JOB_STRTD
        End Set
    End Property
    Public Property D_MSG_STATUS() As String
        Get
            Return dMSG_STATUS
        End Get
        Set(ByVal eMSG_STATUS As String)
            dMSG_STATUS = eMSG_STATUS
        End Set
    End Property
    Public Property D_MSG_ERROR() As String
        Get
            Return dMSG_ERROR
        End Get
        Set(ByVal eMSG_ERROR As String)
            dMSG_ERROR = eMSG_ERROR
        End Set

    End Property
    Public Property WFAO_LOC_CITY() As String
        Get
            Return sWFAO_LOC_CITY
        End Get
        Set(ByVal pWFAO_LOC_CITY As String)
            sWFAO_LOC_CITY = pWFAO_LOC_CITY
        End Set
    End Property
    Public Property DOSOI_URL() As String
        Get
            Return sDOSOI_URL
        End Get
        Set(ByVal pDOSOI_URL As String)
            sDOSOI_URL = pDOSOI_URL
        End Set
    End Property
    Public Property WFAO_LOC_STATE() As String
        Get
            Return sWFAO_LOC_STATE
        End Get
        Set(ByVal pWFAO_LOC_STATE As String)
            sWFAO_LOC_STATE = pWFAO_LOC_STATE
        End Set
    End Property

    Public Property D_WFAI_DOCOMP_LAB_EXP_E() As String
        Get
            Return sWFAI_DOCOMP_LAB_EXP_E
        End Get
        Set(ByVal pWFAI_DOCOMP_LAB_EXP_E As String)
            sWFAI_DOCOMP_LAB_EXP_E = pWFAI_DOCOMP_LAB_EXP_E
        End Set
    End Property

    Property D_WFAI_DOCOMP_REASON_CODE_E As String
        Get
            Return sWFAI_DOCOMP_REASON_CODE_E
        End Get
        Set(ByVal pWFAI_DOCOMP_REASON_CODE_E As String)
            sWFAI_DOCOMP_REASON_CODE_E = pWFAI_DOCOMP_REASON_CODE_E
        End Set
    End Property
    Property D_WFAI_DOCOMP_EXP_E As String
        Get
            Return sWFAI_DOCOMP_EXP_E
        End Get
        Set(ByVal pWFAI_DOCOMP_EXP_E As String)
            sWFAI_DOCOMP_EXP_E = pWFAI_DOCOMP_EXP_E
        End Set
    End Property
    Property Dolog_Comment As String
        Get
            Return sDolog_Comment
        End Get
        Set(ByVal pDolog_Comment As String)
            sDolog_Comment = pDolog_Comment
        End Set
    End Property
    Property Dolog_Comment_Repair_L As String
        Get
            Return sDolog_Comment_R_L
        End Get
        Set(ByVal pDolog_Comment_R_L As String)
            sDolog_Comment_R_L = pDolog_Comment_R_L
        End Set
    End Property
    Property Dolog_Comment_Repair_E As String
        Get
            Return sDolog_Comment_R_E
        End Get
        Set(ByVal pDolog_Comment_R_E As String)
            sDolog_Comment_R_E = pDolog_Comment_R_E
        End Set
    End Property
    Property DEBRIEF_COMMENT_HISTORY As String
        Get
            Return sDebrief_Comment_History
        End Get
        Set(ByVal pDEBRIEF_COMMENT_HISTORY As String)
            sDebrief_Comment_History = pDEBRIEF_COMMENT_HISTORY
        End Set
    End Property
    Property WFAO_TASK_PRIORITY As String
        Get
            Return sWFAO_TASK_PRIORITY
        End Get
        Set(ByVal pWFAO_TASK_PRIORITY As String)
            sWFAO_TASK_PRIORITY = pWFAO_TASK_PRIORITY
        End Set
    End Property
    Property WFAO_PON As String
        Get
            Return sWFAO_PON
        End Get
        Set(ByVal pWFAO_PON As String)
            sWFAO_PON = pWFAO_PON
        End Set
    End Property
    Property WFAO_SKILLS As String
        Get
            Return sWFAO_SKILLS
        End Get
        Set(ByVal pWFAO_SKILLS As String)
            sWFAO_SKILLS = pWFAO_SKILLS
        End Set
    End Property
    Property PREV_WFAI_JSTAT As String
        Get
            Return sPREV_WFAI_JSTAT
        End Get
        Set(ByVal pPREV_WFAI_JSTAT As String)
            sPREV_WFAI_JSTAT = pPREV_WFAI_JSTAT
        End Set
    End Property
    Property TASK_CREATED_BY As String
        Get
            Return sTASK_CREATED_BY
        End Get
        Set(ByVal pTASK_CREATED_BY As String)
            sTASK_CREATED_BY = pTASK_CREATED_BY
        End Set
    End Property
    Property SR_CREATED_BY As String
        Get
            Return sSR_CREATED_BY
        End Get
        Set(ByVal pSR_CREATED_BY As String)
            sSR_CREATED_BY = pSR_CREATED_BY
        End Set
    End Property
    Property Job_Started_Date As String
        Get
            Return sJob_Started_Date
        End Get
        Set(ByVal pJob_Started_Date As String)
            sJob_Started_Date = pJob_Started_Date
        End Set
    End Property
    Property Debrief_Entries As String
        Get
            Return sDebrief_Entries
        End Get
        Set(ByVal pDebrief_Entries As String)
            sDebrief_Entries = pDebrief_Entries
        End Set
    End Property
    Property Ticket_Created_Date As String
        Get
            Return sTicket_Created_Date
        End Get
        Set(ByVal pTicket_Created_Date As String)
            sTicket_Created_Date = pTicket_Created_Date
        End Set
    End Property
End Class

