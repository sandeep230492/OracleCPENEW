Public Class OracleCPENew
    Friend WithEvents srcWFADO_Eastern As AxSmartRumba.AxSmartRumbaControl
    Friend WithEvents srcWFADO_Western As AxSmartRumba.AxSmartRumbaControl
    Friend WithEvents lbl_Process_RMK As System.Windows.Forms.Label
    Friend WithEvents lbl_TicketNo As System.Windows.Forms.Label
    Friend WithEvents lbl_WFADO_System As System.Windows.Forms.Label

    Public Sub SetWFADOScreen(ByVal Region As String, ByRef WFAScreen As AxSmartRumba.AxSmartRumbaControl, Optional ByVal TicketNo As String = "", Optional ByVal SystemName As String = "")
        Try
            Select Case UCase(Region.ToString.Trim)
                Case Is = "C", "CENTRAL"  '' Central"
                    'lbl_WFADO_System.Text = "System :IM043"
                    srcWFADO_Central.BringToFront()
                    WFAScreen = srcWFADO_Central

                Case Is = "E", "EASTERN" ''Eastern
                    'lbl_WFADO_System.Text = "System : IM067"
                    srcWFADO_Eastern1.BringToFront()
                    WFAScreen = srcWFADO_Eastern1

                Case Is = "W", "WESTERN" ''Western
                    'lbl_WFADO_System.Text = "System : IM010"
                    srcWFADO_Western1.BringToFront()
                    WFAScreen = srcWFADO_Western1
            End Select

            '    If SystemName <> "" Then
            '        lbl_WFADO_System.Text = "System : " & SystemName
            '    End If

            '    lbl_TicketNo.Text = "Clli : " & TicketNo.Trim
        Catch ex As Exception
            p_objLogger.writenote("Exception: :-" & ex.ToString(), objordets.Task_Id, EventLogEntryType.Error)
        End Try
    End Sub
    'HARI+Private Sub AxSmartRumbaControl3_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AxSmartRumbaControl3.Enter, srcWFADO_Central.Enter

    'End Sub

    Private Sub OracleCPENew_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class