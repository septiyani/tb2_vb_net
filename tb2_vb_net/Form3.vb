Imports System.Net
Imports System.Web.Script.Serialization


Public Class Dashboard
    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Form2.MdiParent = Me
        Form2.Show()
        Form2.Focus()
    End Sub
    Private Sub RumahSakitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RumahSakitToolStripMenuItem.Click
        RumahSakit.MdiParent = Me
        RumahSakit.Show()
        RumahSakit.Focus()
        Form2.Close()
    End Sub

    Private Sub MonotingKarywanaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MonotingKarywanaToolStripMenuItem.Click
        Form2.MdiParent = Me
        Form2.Show()
        Form2.Focus()
    End Sub
End Class

