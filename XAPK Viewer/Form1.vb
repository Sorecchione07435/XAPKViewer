Imports System.IO.Compression
Imports System.IO

Public Class Form1
    Dim XAPKPath As String
    Dim XAPKLoaded As Boolean = False

    Private Sub OpenXAPKToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenXAPKToolStripMenuItem.Click
        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            XAPKPath = OpenFileDialog1.FileName
            ExtractXAPK.RunWorkerAsync()
            Me.Enabled = False
            Extracting.Show()
        End If
    End Sub

    Private Sub ExtractXAPK_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles ExtractXAPK.DoWork
        MkDir(System.IO.Path.GetTempPath & "\" & IO.Path.GetFileNameWithoutExtension(XAPKPath))
        ZipFile.ExtractToDirectory(XAPKPath, System.IO.Path.GetTempPath & "\" & IO.Path.GetFileNameWithoutExtension(XAPKPath))
    End Sub


    Private Sub ExtractXAPK_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles ExtractXAPK.RunWorkerCompleted
        Me.Enabled = True
        Extracting.Hide()
        ListDirectory(TreeView1, System.IO.Path.GetTempPath & "\" & IO.Path.GetFileNameWithoutExtension(XAPKPath))
        TreeView1.ExpandAll()
        XAPKLoaded = True
        CloseXAPKToolStripMenuItem.Enabled = True
        ExportOBBFilesToolStripMenuItem.Enabled = True
        ExportAPKToolStripMenuItem.Enabled = True
        ExportIconToolStripMenuItem.Enabled = True
        ExtractAPKOBBToolStripMenuItem.Enabled = True

        If My.Computer.FileSystem.FileExists(System.IO.Path.GetTempPath & "\" & IO.Path.GetFileNameWithoutExtension(XAPKPath) & "\manifest.json") = True Then
            RichTextBox1.Text = System.IO.File.ReadAllText(System.IO.Path.GetTempPath & "\" & IO.Path.GetFileNameWithoutExtension(XAPKPath) & "\manifest.json")
        Else
            RichTextBox1.ForeColor = Color.Red
            RichTextBox1.Text = "No manifest.json founded inside the XAPK"
        End If

        Label2.Text = IO.Path.GetFileName(XAPKPath)
    End Sub

    Private Sub Form1_DragDrop(sender As Object, e As DragEventArgs) Handles Me.DragDrop
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            Dim MyFile As String


            ' Assign the files to an array.
            MyFile = e.Data.GetData(DataFormats.FileDrop)
            'If there are more than one file, set first only
            'If you want another restrictment, please edit this.
            XAPKPath = MyFile(0)


            ExtractXAPK.RunWorkerAsync()
            Extracting.Show()
        End If

    End Sub


    Private Sub Form1_DragEnter(sender As Object, e As DragEventArgs) Handles Me.DragEnter
        '  If e.Data.GetDataPresent(DataFormats.FileDrop) Then
        e.Effect = DragDropEffects.Copy
        ' End If

    End Sub

    

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If XAPKLoaded = True Then
            

            My.Computer.FileSystem.DeleteDirectory(System.IO.Path.GetTempPath & "\" & IO.Path.GetFileNameWithoutExtension(XAPKPath), FileIO.DeleteDirectoryOption.DeleteAllContents)
            TreeView1.Nodes.Clear()
            XAPKLoaded = False
            XAPKPath = ""
            CloseXAPKToolStripMenuItem.Enabled = False
            ExportOBBFilesToolStripMenuItem.Enabled = False
            ExportAPKToolStripMenuItem.Enabled = False
            ExportIconToolStripMenuItem.Enabled = False
            ExtractAPKOBBToolStripMenuItem.Enabled = False
            RichTextBox1.Clear()

            Label2.Text = Nothing
        End If
     
    End Sub

    Private Sub ListDirectory(ByVal treeView As TreeView, ByVal path As String)
        treeView.Nodes.Clear()
        Dim rootDirectoryInfo = New DirectoryInfo(path)
        treeView.Nodes.Add(CreateDirectoryNode(rootDirectoryInfo))
    End Sub

    Private Shared Function CreateDirectoryNode(ByVal directoryInfo As DirectoryInfo) As TreeNode
        Dim directoryNode = New TreeNode(directoryInfo.Name)

        For Each directory In directoryInfo.GetDirectories()
            directoryNode.Nodes.Add(CreateDirectoryNode(directory))
        Next

        For Each file In directoryInfo.GetFiles()
            directoryNode.Nodes.Add(New TreeNode(file.Name))
        Next

        Return directoryNode
    End Function



    Private Sub CloseXAPKToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CloseXAPKToolStripMenuItem.Click
        

        My.Computer.FileSystem.DeleteDirectory(System.IO.Path.GetTempPath & "\" & IO.Path.GetFileNameWithoutExtension(XAPKPath), FileIO.DeleteDirectoryOption.DeleteAllContents)
        TreeView1.Nodes.Clear()
        XAPKLoaded = False
        XAPKPath = ""
        CloseXAPKToolStripMenuItem.Enabled = False
        ExportOBBFilesToolStripMenuItem.Enabled = False
        ExportAPKToolStripMenuItem.Enabled = False
        ExportIconToolStripMenuItem.Enabled = False
        ExtractAPKOBBToolStripMenuItem.Enabled = False
        RichTextBox1.Clear()

        Label2.Text = Nothing
    End Sub

    Private Sub ExportAPKToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExportAPKToolStripMenuItem.Click
        For Each f In Directory.GetFiles((System.IO.Path.GetTempPath & "\" & IO.Path.GetFileNameWithoutExtension(XAPKPath)), "*.apk", SearchOption.AllDirectories)
            If File.Exists(f) Then
                Dim FBD As New FolderBrowserDialog
                '  SFD.Filter = "Android Package|*.apk"
                'FBD.t = "Export APK files Directory..."
                If FBD.ShowDialog = Windows.Forms.DialogResult.OK Then
                    File.Copy(f, Path.Combine(FBD.SelectedPath, Path.GetFileName(f)), True)
                End If

            End If
        Next
    End Sub

    Private Sub ExportIconToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExportIconToolStripMenuItem.Click
        For Each f In Directory.GetFiles((System.IO.Path.GetTempPath & "\" & IO.Path.GetFileNameWithoutExtension(XAPKPath)), "*.png", SearchOption.AllDirectories)
            If File.Exists(f) Then
                Dim FBD As New FolderBrowserDialog
                ' SFD.Filter = "PNG Image|*.png"
                'SFD.Title = "Export PNG Icons files..."
                If FBD.ShowDialog = Windows.Forms.DialogResult.OK Then
                    File.Copy(f, Path.Combine(FBD.SelectedPath, Path.GetFileName(f)), True)
                End If

            End If
        Next
    End Sub

    Private Sub ExportOBBFilesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExportOBBFilesToolStripMenuItem.Click
        Dim PackageNamePrompt = InputBox("Type the application package here.")

        If My.Computer.FileSystem.DirectoryExists(System.IO.Path.GetTempPath & "\" & IO.Path.GetFileNameWithoutExtension(XAPKPath) & "\Android\obb\" & PackageNamePrompt) = True Then


            For Each f In Directory.GetFiles((System.IO.Path.GetTempPath & "\" & IO.Path.GetFileNameWithoutExtension(XAPKPath) & "\Android\obb\" & PackageNamePrompt & "\"), "*.obb", SearchOption.AllDirectories)
                If File.Exists(f) Then
                    Dim FBD As New FolderBrowserDialog
                    ' SFD.Filter = "Opacque Blob Binary File|*.obb"
                    ' SFD.Title = "Export OBB files..."
                    If FBD.ShowDialog = Windows.Forms.DialogResult.OK Then
                        File.Copy(f, Path.Combine(FBD.SelectedPath, Path.GetFileName(f)), True)
                    End If

                End If
            Next
            PackageNamePrompt = Nothing
        Else
            MsgBox("Invalid Package Name!")
            PackageNamePrompt = Nothing
        End If

      
    End Sub

    Private Sub ExtractAPKOBBToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExtractAPKOBBToolStripMenuItem.Click
        Dim FBD As New FolderBrowserDialog
        '  SFD.Filter = "Android Package|*.apk"
        'FBD.t = "Export APK files Directory..."
        If FBD.ShowDialog = Windows.Forms.DialogResult.OK Then
            MkDir(FBD.SelectedPath & "\" & IO.Path.GetFileNameWithoutExtension(XAPKPath))
            For Each f In Directory.GetFiles((System.IO.Path.GetTempPath & "\" & IO.Path.GetFileNameWithoutExtension(XAPKPath)), "*.apk", SearchOption.AllDirectories)
                If File.Exists(f) Then
                    File.Copy(f, Path.Combine(FBD.SelectedPath & "\" & IO.Path.GetFileNameWithoutExtension(XAPKPath), Path.GetFileName(f)), True)
                End If
            Next

            Dim PackageNamePrompt = InputBox("Type the application package here.")

            If My.Computer.FileSystem.DirectoryExists(System.IO.Path.GetTempPath & "\" & IO.Path.GetFileNameWithoutExtension(XAPKPath) & "\Android\obb\" & PackageNamePrompt) = True Then


                For Each f In Directory.GetFiles((System.IO.Path.GetTempPath & "\" & IO.Path.GetFileNameWithoutExtension(XAPKPath) & "\Android\obb\" & PackageNamePrompt & "\"), "*.obb", SearchOption.AllDirectories)
                    If File.Exists(f) Then

                        ' SFD.Filter = "Opacque Blob Binary File|*.obb"
                        ' SFD.Title = "Export OBB files..."

                        File.Copy(f, Path.Combine(FBD.SelectedPath & "\" & IO.Path.GetFileNameWithoutExtension(XAPKPath), Path.GetFileName(f)), True)


                    End If
                Next
                PackageNamePrompt = Nothing
            Else
                MsgBox("Invalid Package Name!")
                PackageNamePrompt = Nothing
            End If

        End If


     

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        AboutBox.Show()
    End Sub

    Private Sub WToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles WToolStripMenuItem.Click
        Process.Start("https://github.com/Sorecchione07435/XAPKFileFormat/tree/main")
    End Sub

    Private Sub XAPKViewerGitHubPageToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles XAPKViewerGitHubPageToolStripMenuItem.Click
        Process.Start("https://github.com/Sorecchione07435/XAPKViewer/tree/main")
    End Sub
End Class
