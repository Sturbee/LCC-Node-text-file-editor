Imports System.IO

Public Class FrmMenuMain

    Private Property MyPortLines As Integer
    Private Property MyLogicCells As Integer
    Private Property MyMasts As Integer
    Private Property MyTrackReceivers
    Private Property MyTrackTransmitters
    Private Property MyLamps As Integer

    Private Sub FrmMenuMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Call Me.CheckUserPreferences()

    End Sub

    Private Sub CheckUserPreferences()

        Dim clsU As New ClsUserPrefs

        If clsU.CheckUserFileDirectories > -1 Then

            Dim frm As New FrmUserJMRIfiles

            Call Me.CheckFormAndOpen(frm)

        End If

    End Sub

    Private Sub CheckFormAndOpen(frm As Form)

        If Me.OwnedForms.Length = 0 Then
            ' do nothing
        Else
            For count = 0 To Me.OwnedForms.Length - 1
                If Me.OwnedForms(count).Name = frm.Name Then
                    Beep()
                    Exit Sub
                End If
            Next
        End If

        Me.AddOwnedForm(frm)
        frm.Show()

    End Sub

    Private Sub FileProcessToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FileProcessToolStripMenuItem.Click

        Dim frm As New FrmFileBackup
        Call Me.CheckFormAndOpen(frm)

    End Sub

    Private Sub FileEditToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FileEditToolStripMenuItem.Click

        Dim frm As New FrmFileXml
        Call Me.CheckFormAndOpen(frm)

    End Sub

    Private Sub FileRestoreToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FileRestoreToolStripMenuItem.Click

        Dim frm As New FrmFileRestore
        Call Me.CheckFormAndOpen(frm)

    End Sub

    Private Sub NodeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NodeToolStripMenuItem.Click

        Dim frm As New FrmNode
        Call Me.CheckFormAndOpen(frm)

    End Sub

    Private Sub PwrMonitorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PwrMonitorToolStripMenuItem.Click

        Dim frm As New FrmPowerMonitor
        Call Me.CheckFormAndOpen(frm)

    End Sub

    Private Sub PortToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PortToolStripMenuItem.Click

        Dim frm As New FrmPorts With {
            .MyLines = Me.MyPortLines
        }
        Call Me.CheckFormAndOpen(frm)

    End Sub

    Private Sub LogicToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LogicToolStripMenuItem.Click

        Dim frm As New FrmLogics With {
            .MyLogicCells = Me.MyLogicCells
        }
        Call Me.CheckFormAndOpen(frm)

    End Sub

    Private Sub MastToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MastToolStripMenuItem.Click

        Dim frm As New FrmMasts With {
            .MyMasts = Me.MyMasts
        }
        Call Me.CheckFormAndOpen(frm)

    End Sub

    Private Sub TrackReceiversToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TrackReceiversToolStripMenuItem.Click

        Dim frm As New FrmTrackReceivers With {
            .MyTrackCircuits = Me.MyTrackReceivers
        }
        Call Me.CheckFormAndOpen(frm)

    End Sub

    Private Sub TrackTransmittersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TrackTransmittersToolStripMenuItem.Click

        Dim frm As New FrmTrackTransmitters With {
            .MyTrackCircuits = Me.MyTrackTransmitters
        }
        Call Me.CheckFormAndOpen(frm)

    End Sub

    Private Sub LampToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LampToolStripMenuItem.Click

        Dim frm As New FrmLamps With {
            .MyLamps = Me.MyLamps
        }
        Call Me.CheckFormAndOpen(frm)

    End Sub

    Private Sub UserFilesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UserFilesToolStripMenuItem.Click

        Dim frm As New FrmUserJMRIfiles
        Call Me.CheckFormAndOpen(frm)

    End Sub

    Private Sub UserTrackSpeedsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UserTrackSpeedsToolStripMenuItem.Click

        Dim frm As New FrmUserTrackSpeed
        Call Me.CheckFormAndOpen(frm)

    End Sub

    Private Sub FrmMenuMain_Activated(sender As Object, e As EventArgs) Handles Me.Activated

        If Me.Tag = Nothing Then
            ' no file selected
            Me.FileToolStripMenuItem.Visible = True
            Me.NodeToolStripMenuItem.Visible = False
            Me.PwrMonitorToolStripMenuItem.Visible = False
            Me.PortToolStripMenuItem.Visible = False
            Me.LogicToolStripMenuItem.Visible = False
            Me.MastToolStripMenuItem.Visible = False
            Me.TrackReceiversToolStripMenuItem.Visible = False
            Me.TrackTransmittersToolStripMenuItem.Visible = False
            Me.LampToolStripMenuItem.Visible = False
            Me.UserToolStripMenuItem.Visible = True

        Else
            ' read the file to read and edit
            Dim newText As String = "Main Menu > Selected file " + Path.GetFileName(Me.Tag)
            If Me.Text = newText Then
                ' do nothing
            Else
                Me.Text = newText
                ' get node type
                ' disable menu selections by node type

                Dim MyExportXml As New ExportXml
                MyExportXml.ReadXml(Me.Tag)
                Dim rowNode As ExportXml.NodeRow = MyExportXml.Node.FindByNodeID(0)

                Dim clsR As New ClsReport
                Dim row As Rpt.NodeTypeRow = clsR.MyReport.NodeType.FindByvalue(rowNode.NodeType)

                If row.node > 0 Then
                    Me.NodeToolStripMenuItem.Visible = True
                Else
                    Me.NodeToolStripMenuItem.Visible = False
                End If

                If row.pwrMonitor > 0 Then
                    Me.PwrMonitorToolStripMenuItem.Visible = True
                Else
                    Me.PwrMonitorToolStripMenuItem.Visible = False
                End If

                If row.port > 0 Then
                    Me.PortToolStripMenuItem.Visible = True
                Else
                    Me.PortToolStripMenuItem.Visible = False
                End If
                Me.MyPortLines = row.port

                If row.logic > 0 Then
                    Me.LogicToolStripMenuItem.Visible = True
                Else
                    Me.LogicToolStripMenuItem.Visible = False
                End If
                Me.MyLogicCells = row.logic

                If row.mast > 0 Then
                    Me.MastToolStripMenuItem.Visible = True
                Else
                    Me.MastToolStripMenuItem.Visible = False
                End If
                Me.MyMasts = row.mast

                If row.trackCircuitRec > 0 Then
                    Me.TrackReceiversToolStripMenuItem.Visible = True
                Else
                    Me.TrackReceiversToolStripMenuItem.Visible = False
                End If
                Me.MyTrackReceivers = row.trackCircuitRec

                If row.trackCircuitTran > 0 Then
                    Me.TrackTransmittersToolStripMenuItem.Visible = True
                Else
                    Me.TrackTransmittersToolStripMenuItem.Visible = False
                End If
                Me.MyTrackTransmitters = row.trackCircuitTran

                If row.lamp > 0 Then
                    Me.LampToolStripMenuItem.Visible = True
                Else
                    Me.LampToolStripMenuItem.Visible = False
                End If
                Me.MyLamps = row.lamp

            End If

        End If

    End Sub

End Class