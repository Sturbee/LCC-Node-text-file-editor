Imports System.IO

Public Class FrmMenuMain


    Private Sub FrmMenuMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Call Me.CheckUserPreferences()

    End Sub

    Private Sub CheckUserPreferences()

        Dim clsU As New ClsUserPrefs

        If clsU.CheckUserFileDirectories > -1 Then

            Dim frm As New FrmUserPrefs

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

    Private Sub JMRIfilesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles JMRIfilesToolStripMenuItem.Click

        ' check to see if form already opened

        Dim frm As New FrmUserPrefs

        Call Me.CheckFormAndOpen(frm)

    End Sub

    Private Sub TrackSpeedsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TrackSpeedsToolStripMenuItem.Click

        Dim frm As New FrmTrackSpeed

        Call Me.CheckFormAndOpen(frm)

    End Sub

    Private Sub LampToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LampToolStripMenuItem.Click

        If Me.Tag = Nothing Then
            Beep()
        Else
            Dim frm As New FrmLamp With {
                .MyLampID = 2
            }
            Call Me.CheckFormAndOpen(frm)
        End If

    End Sub

    Private Sub ProcessToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProcessToolStripMenuItem.Click

        Dim frm As New FrmExportXml

        Call Me.CheckFormAndOpen(frm)

    End Sub

    Private Sub EditToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditToolStripMenuItem.Click

        Dim frm As New FrmEditXml

        Call Me.CheckFormAndOpen(frm)

    End Sub

    Private Sub RestoreToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RestoreToolStripMenuItem.Click

        Beep()

    End Sub

    Private Sub NodeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NodeToolStripMenuItem.Click

        If Me.Tag = Nothing Then
            Beep()
        Else
            Dim frm As New FrmNode
            Call Me.CheckFormAndOpen(frm)
        End If

    End Sub

    Private Sub PwrMonitorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PwrMonitorToolStripMenuItem.Click

        If Me.Tag = Nothing Then
            Beep()
        Else
            Dim frm As New FrmPowerMonitor
            Call Me.CheckFormAndOpen(frm)
        End If

    End Sub

    Private Sub FrmMenuMain_Activated(sender As Object, e As EventArgs) Handles Me.Activated

        If Me.Tag = Nothing Then
            ' do nothing
        Else
            ' read the file to read and edit
            Dim newText As String = "Main Menu > Selected file " + Path.GetFileName(Me.Tag)
            If Me.Text = newText Then
                ' do nothing
            Else
                Me.Text = newText
                ' get node type
                ' disable menu selections by node type
                Dim clsE As New ClsExportXML
                clsE.ExportXmlRead(Me.Tag)
                Dim rowNode As ExportXml.NodeRow = clsE.MyExportXML.Node.FindByNodeID(0)

                Dim clsR As New ClsReport
                Dim row As Rpt.NodeTypeRow = clsR.MyReport.NodeType.FindByvalue(rowNode.NodeType)
                Me.LampToolStripMenuItem.Visible = row.lamp

            End If

        End If

    End Sub
End Class