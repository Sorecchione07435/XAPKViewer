Imports System.IO.Compression
Imports System.IO

Public Class Form1
    Dim XAPKPath As String
    Dim XAPKLoaded As Boolean = False
    ' Dim XAPKError As Boolean = False

    Private Sub OpenXAPKToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenXAPKToolStripMenuItem.Click


        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            XAPKPath = OpenFileDialog1.FileName
            ExtractXAPK.RunWorkerAsync()
            Me.Enabled = False
            Extracting.Show()
        End If
    End Sub

    Private Sub ExtractXAPK_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles ExtractXAPK.DoWork
        Try
            MkDir(System.IO.Path.GetTempPath & "\" & IO.Path.GetFileNameWithoutExtension(XAPKPath))
            ZipFile.ExtractToDirectory(XAPKPath, System.IO.Path.GetTempPath & "\" & IO.Path.GetFileNameWithoutExtension(XAPKPath))
        Catch ex As Exception
            MsgBox("An unhandled exception occurred:" & vbCrLf & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    
    End Sub


    Private Sub ExtractXAPK_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles ExtractXAPK.RunWorkerCompleted
        Me.Enabled = True
        Extracting.Hide()
        ListDirectory(TreeView1, System.IO.Path.GetTempPath & "\" & IO.Path.GetFileNameWithoutExtension(XAPKPath))
        TreeView1.ExpandAll()
        XAPKLoaded = True
        CloseXAPKToolStripMenuItem.Enabled = True
        ExportIconToolStripMenuItem.Enabled = True
        ExtractAPKOBBToolStripMenuItem.Enabled = True

        Dim paths() As String = IO.Directory.GetFiles(System.IO.Path.GetTempPath & "\" & IO.Path.GetFileNameWithoutExtension(XAPKPath), "*.apk")
        If paths.Length > 1 Then
            CloseXAPKToolStripMenuItem.PerformClick()
            RichTextBox1.ForeColor = Color.Red
            RichTextBox1.Text = RichTextBox1.Text & vbCrLf & vbCrLf & "XAPK Viewer does not support XAPK files with split APK sets" & vbCrLf & "Only XAPK files with OBB expansions are supported"
            Exit Sub
        End If

        If My.Computer.FileSystem.FileExists(System.IO.Path.GetTempPath & "\" & IO.Path.GetFileNameWithoutExtension(XAPKPath) & "\manifest.json") = True Then
            RichTextBox1.ForeColor = Color.Black
            RichTextBox1.Text = System.IO.File.ReadAllText(System.IO.Path.GetTempPath & "\" & IO.Path.GetFileNameWithoutExtension(XAPKPath) & "\manifest.json")
        Else
            RichTextBox1.ForeColor = Color.Red

            CloseXAPKToolStripMenuItem.PerformClick()

            RichTextBox1.Text = RichTextBox1.Text & vbCrLf & vbCrLf & "No manifest.json founded inside the XAPK" & vbCrLf & "Consequently, the XAPK file cannot be opened" & vbCrLf & vbCrLf & "If you want to open this XAPK file add a manifest.json with the respective application information"
            '  XAPKError = True
            Exit Sub
        End If

        Dim paths2() As String = IO.Directory.GetFiles(System.IO.Path.GetTempPath & "\" & IO.Path.GetFileNameWithoutExtension(XAPKPath), "*.apk")
        If Not paths2.Length > 0 Then
            CloseXAPKToolStripMenuItem.PerformClick()
            RichTextBox1.ForeColor = Color.Red
            RichTextBox1.Text = RichTextBox1.Text & vbCrLf & vbCrLf & "No APK file was found within the XAPK" & vbCrLf & "Consequently, the XAPK file cannot be opened" & vbCrLf & vbCrLf & "check if the file is not corrupted or an invalid XAPK file"
            'XAPKError = True
            Exit Sub
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
        ExportIconToolStripMenuItem.Enabled = False
        ExtractAPKOBBToolStripMenuItem.Enabled = False
        RichTextBox1.Clear()

        Label2.Text = Nothing
    End Sub

    Private Sub ExportAPKToolStripMenuItem_Click(sender As Object, e As EventArgs)

        Dim paths() As String = IO.Directory.GetFiles(System.IO.Path.GetTempPath & "\" & IO.Path.GetFileNameWithoutExtension(XAPKPath), "*.apk")
        If paths.Length > 1 Then
            MsgBox("Extracting more than one APK file into an XAPK file with Split APKs is currently not supported", MsgBoxStyle.Critical, "Error") : Exit Sub
        End If

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

    Private Sub ExportOBBFilesToolStripMenuItem_Click(sender As Object, e As EventArgs)
        If My.Computer.FileSystem.DirectoryExists(System.IO.Path.GetTempPath & "\" & IO.Path.GetFileNameWithoutExtension(XAPKPath) & "\Android") = False Then
            MsgBox("This XAPK file does not contain any OBB files", MsgBoxStyle.Critical, "Error") : Exit Sub
        End If

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


            For Each oDir In (New DirectoryInfo(System.IO.Path.GetTempPath & "\" & IO.Path.GetFileNameWithoutExtension(XAPKPath) & "\Android\obb")).GetDirectories()
                My.Computer.FileSystem.CopyDirectory(oDir.FullName, FBD.SelectedPath & "\" & IO.Path.GetFileNameWithoutExtension(XAPKPath), overwrite:=True)
            Next oDir
            ' 0  Dim Package
        End If






    End Sub

    Public Sub CopyDirectory(ByVal sourcePath As String, ByVal destinationPath As String)
        Dim sourceDirectoryInfo As New System.IO.DirectoryInfo(sourcePath)

        ' If the destination folder don't exist then create it
        If Not System.IO.Directory.Exists(destinationPath) Then
            System.IO.Directory.CreateDirectory(destinationPath)
        End If

        Dim fileSystemInfo As System.IO.FileSystemInfo
        For Each fileSystemInfo In sourceDirectoryInfo.GetFileSystemInfos
            Dim destinationFileName As String =
                System.IO.Path.Combine(destinationPath, fileSystemInfo.Name)

            ' Now check whether its a file or a folder and take action accordingly
            If TypeOf fileSystemInfo Is System.IO.FileInfo Then
                System.IO.File.Copy(fileSystemInfo.FullName, destinationFileName, True)
            Else
                ' Recursively call the mothod to copy all the neste folders
                CopyDirectory(fileSystemInfo.FullName, destinationFileName)
            End If
        Next
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
