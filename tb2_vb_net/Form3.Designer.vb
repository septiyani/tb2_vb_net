<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Dashboard
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Dashboard))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.MonotingKarywanaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RumahSakitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ProsedurToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MonotingKarywanaToolStripMenuItem, Me.RumahSakitToolStripMenuItem, Me.ProsedurToolStripMenuItem, Me.ExitToolStripMenuItem})
        resources.ApplyResources(Me.MenuStrip1, "MenuStrip1")
        Me.MenuStrip1.Name = "MenuStrip1"
        '
        'MonotingKarywanaToolStripMenuItem
        '
        resources.ApplyResources(Me.MonotingKarywanaToolStripMenuItem, "MonotingKarywanaToolStripMenuItem")
        Me.MonotingKarywanaToolStripMenuItem.Name = "MonotingKarywanaToolStripMenuItem"
        '
        'RumahSakitToolStripMenuItem
        '
        resources.ApplyResources(Me.RumahSakitToolStripMenuItem, "RumahSakitToolStripMenuItem")
        Me.RumahSakitToolStripMenuItem.Name = "RumahSakitToolStripMenuItem"
        '
        'ProsedurToolStripMenuItem
        '
        resources.ApplyResources(Me.ProsedurToolStripMenuItem, "ProsedurToolStripMenuItem")
        Me.ProsedurToolStripMenuItem.Name = "ProsedurToolStripMenuItem"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        resources.ApplyResources(Me.ExitToolStripMenuItem, "ExitToolStripMenuItem")
        '
        'Dashboard
        '
        Me.AllowDrop = True
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CausesValidation = False
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Dashboard"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents MonotingKarywanaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RumahSakitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ProsedurToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
