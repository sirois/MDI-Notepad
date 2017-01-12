Imports System.Windows.Forms

Public Class MDIParent1

    Private Sub ShowNewForm(ByVal sender As Object, ByVal e As EventArgs) Handles NewToolStripMenuItem.Click, NewToolStripButton.Click, NewWindowToolStripMenuItem.Click
        ' Create a new instance of the child form.
        ''Dim ChildForm As New System.Windows.Forms.Form
        Dim ChildForm As New Form1
        ' Make it a child of this MDI form before showing it.
        ChildForm.MdiParent = Me

        m_ChildFormNumber += 1
        ChildForm.Text = "Window " & m_ChildFormNumber

        ChildForm.Show()
    End Sub

    Private Sub OpenFile(ByVal sender As Object, ByVal e As EventArgs) Handles OpenToolStripMenuItem.Click, OpenToolStripButton.Click
        Dim OpenFileDialog As New OpenFileDialog
        OpenFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        OpenFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"
        If (OpenFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            Dim FileName As String = OpenFileDialog.FileName
            ' TODO: Add code here to open the file.
            Dim ChildForm As New Form1
            ChildForm.MdiParent = Me
            ''m_ChildFormNumber += 1
            ChildForm.Text = FileName
            ChildForm.TextBox.Text = My.Computer.FileSystem.ReadAllText(FileName)
            ChildForm.Tag = FileName
            ChildForm.Show()
            Me.ToolStripStatusLabel.Text = "Opened " + FileName
            Me.ToolStripProgressBar1.Value = 100
        End If
    End Sub




    Private Sub ExitToolsStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub CutToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CutToolStripMenuItem.Click
        ' Use My.Computer.Clipboard to insert the selected text or images into the clipboard
    End Sub

    Private Sub CopyToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CopyToolStripMenuItem.Click
        ' Use My.Computer.Clipboard to insert the selected text or images into the clipboard
    End Sub

    Private Sub PasteToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles PasteToolStripMenuItem.Click
        'Use My.Computer.Clipboard.GetText() or My.Computer.Clipboard.GetData to retrieve information from the clipboard.
    End Sub

    Private Sub ToolBarToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ToolBarToolStripMenuItem.Click
        Me.ToolStrip.Visible = Me.ToolBarToolStripMenuItem.Checked
    End Sub

    Private Sub StatusBarToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles StatusBarToolStripMenuItem.Click
        Me.StatusStrip.Visible = Me.StatusBarToolStripMenuItem.Checked
    End Sub

    Private Sub CascadeToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CascadeToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.Cascade)
    End Sub

    Private Sub TileVerticalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles TileVerticalToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.TileVertical)
    End Sub

    Private Sub TileHorizontalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles TileHorizontalToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.TileHorizontal)
    End Sub

    Private Sub ArrangeIconsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ArrangeIconsToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.ArrangeIcons)
    End Sub

    Private Sub CloseAllToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CloseAllToolStripMenuItem.Click
        ' Close all child forms of the parent.
        For Each ChildForm As Form In Me.MdiChildren
            ChildForm.Close()
        Next
    End Sub

    Private m_ChildFormNumber As Integer


    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click, SaveToolStripButton.Click
        Dim tempChild As Form1 = Me.ActiveMdiChild
        SaveRoutine(tempChild.Tag)
    End Sub

    Private Sub SaveAsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles SaveAsToolStripMenuItem.Click
        SaveRoutine("")
    End Sub
    Private Sub SaveRoutine(fileName As String)
        Dim tempChild As Form1 = Me.ActiveMdiChild

        If (String.IsNullOrEmpty(fileName)) Then
            Dim SaveFileDialog As New SaveFileDialog
            If (String.IsNullOrEmpty(tempChild.Tag)) Then
                SaveFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
                SaveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"
            Else
                SaveFileDialog.InitialDirectory = tempChild.Tag
                SaveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"
            End If
            If (SaveFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
                    fileName = SaveFileDialog.FileName
                    ' TODO: Add code here to save the current contents of the form to a file.
                    tempChild.TextBox.SaveFile(fileName, RichTextBoxStreamType.PlainText)
                    tempChild.Tag = fileName
                    tempChild.Text = fileName

                End If
            Else
                tempChild.TextBox.SaveFile(fileName, RichTextBoxStreamType.PlainText)
            tempChild.Tag = fileName
            tempChild.Text = fileName
        End If

        Me.ToolStripStatusLabel.Text = "Saved " + fileName
        Me.ToolStripProgressBar1.Value = 100

    End Sub



    Private Sub MDIParent1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.ToolStripStatusLabel.Text = ""
        Me.ToolStripProgressBar1.Value = 0
    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        Dim aboutModule As New AboutBox1
        aboutModule.Show()
    End Sub
End Class
