<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Richiesto da Progettazione Windows Form
    Private components As System.ComponentModel.IContainer

    'NOTA: la procedura che segue è richiesta da Progettazione Windows Form
    'Può essere modificata in Progettazione Windows Form.  
    'Non modificarla nell'editor del codice.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenXAPKToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CloseXAPKToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExportIconToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExtractAPKOBBToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.WToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.XAPKViewerGitHubPageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TreeView1 = New System.Windows.Forms.TreeView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.ExtractXAPK = New System.ComponentModel.BackgroundWorker()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.ToolStripMenuItem1})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(968, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenXAPKToolStripMenuItem, Me.CloseXAPKToolStripMenuItem, Me.ToolStripSeparator1, Me.ExportIconToolStripMenuItem, Me.ExtractAPKOBBToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'OpenXAPKToolStripMenuItem
        '
        Me.OpenXAPKToolStripMenuItem.Name = "OpenXAPKToolStripMenuItem"
        Me.OpenXAPKToolStripMenuItem.Size = New System.Drawing.Size(171, 22)
        Me.OpenXAPKToolStripMenuItem.Text = "Open XAPK..."
        '
        'CloseXAPKToolStripMenuItem
        '
        Me.CloseXAPKToolStripMenuItem.Enabled = False
        Me.CloseXAPKToolStripMenuItem.Name = "CloseXAPKToolStripMenuItem"
        Me.CloseXAPKToolStripMenuItem.Size = New System.Drawing.Size(171, 22)
        Me.CloseXAPKToolStripMenuItem.Text = "Close XAPK"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(168, 6)
        '
        'ExportIconToolStripMenuItem
        '
        Me.ExportIconToolStripMenuItem.Enabled = False
        Me.ExportIconToolStripMenuItem.Name = "ExportIconToolStripMenuItem"
        Me.ExportIconToolStripMenuItem.Size = New System.Drawing.Size(171, 22)
        Me.ExportIconToolStripMenuItem.Text = "Extract Icon"
        '
        'ExtractAPKOBBToolStripMenuItem
        '
        Me.ExtractAPKOBBToolStripMenuItem.Enabled = False
        Me.ExtractAPKOBBToolStripMenuItem.Name = "ExtractAPKOBBToolStripMenuItem"
        Me.ExtractAPKOBBToolStripMenuItem.Size = New System.Drawing.Size(171, 22)
        Me.ExtractAPKOBBToolStripMenuItem.Text = "Extract APK + OBB"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AboutToolStripMenuItem, Me.WToolStripMenuItem, Me.XAPKViewerGitHubPageToolStripMenuItem})
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(24, 20)
        Me.ToolStripMenuItem1.Text = "?"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(211, 22)
        Me.AboutToolStripMenuItem.Text = "About"
        '
        'WToolStripMenuItem
        '
        Me.WToolStripMenuItem.Name = "WToolStripMenuItem"
        Me.WToolStripMenuItem.Size = New System.Drawing.Size(211, 22)
        Me.WToolStripMenuItem.Text = "What is an XAPK file?"
        '
        'XAPKViewerGitHubPageToolStripMenuItem
        '
        Me.XAPKViewerGitHubPageToolStripMenuItem.Name = "XAPKViewerGitHubPageToolStripMenuItem"
        Me.XAPKViewerGitHubPageToolStripMenuItem.Size = New System.Drawing.Size(211, 22)
        Me.XAPKViewerGitHubPageToolStripMenuItem.Text = "XAPK Viewer GitHub Page"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 24)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label3)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TreeView1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label1)
        Me.SplitContainer1.Panel2.Controls.Add(Me.RichTextBox1)
        Me.SplitContainer1.Size = New System.Drawing.Size(968, 523)
        Me.SplitContainer1.SplitterDistance = 474
        Me.SplitContainer1.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(3, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(90, 18)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "File Explorer"
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(110, 5)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(361, 23)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "   "
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TreeView1
        '
        Me.TreeView1.AllowDrop = True
        Me.TreeView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TreeView1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TreeView1.Location = New System.Drawing.Point(0, 30)
        Me.TreeView1.Name = "TreeView1"
        Me.TreeView1.ShowRootLines = False
        Me.TreeView1.Size = New System.Drawing.Size(474, 490)
        Me.TreeView1.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(3, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(180, 18)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "View XAPK's Manifest File"
        '
        'RichTextBox1
        '
        Me.RichTextBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RichTextBox1.Font = New System.Drawing.Font("Consolas", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RichTextBox1.Location = New System.Drawing.Point(0, 31)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.ReadOnly = True
        Me.RichTextBox1.Size = New System.Drawing.Size(490, 486)
        Me.RichTextBox1.TabIndex = 0
        Me.RichTextBox1.Text = ""
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.Filter = "Extended Android Package|*.xapk"
        '
        'ExtractXAPK
        '
        '
        'Form1
        '
        Me.AllowDrop = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(968, 547)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "XAPK Viewer"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenXAPKToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CloseXAPKToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents RichTextBox1 As System.Windows.Forms.RichTextBox
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents ExtractXAPK As System.ComponentModel.BackgroundWorker
    Friend WithEvents TreeView1 As System.Windows.Forms.TreeView
    Friend WithEvents ExportIconToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ExtractAPKOBBToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents WToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents XAPKViewerGitHubPageToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
