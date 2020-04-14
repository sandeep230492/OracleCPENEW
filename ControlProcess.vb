Imports System.Net.Mail

Module ControlProcess
    Public objordets As New OrderDetails
    Private objWFADOScreen As New AxSmartRumba.AxSmartRumbaControl





    Sub main()

        myForm.Show()
        [Global].ReadLocalINI()

        'getInput
        Try
            Call GlobalVariables.SetGlobalVariables()
            Dim objectWFADOProcess As New WFADOProcess

            objectWFADOProcess.doProcess(objWFADOScreen, objordets)
        Catch ex As Exception
            p_objLogger.writenote("Exception: :-" & ex.ToString(), "Main", EventLogEntryType.Error)
        End Try
      

        Application.Exit()

    End Sub
End Module

