Imports System.Windows.Forms
Imports MySql.Data.MySqlClient

Public Class zmain

    Private Sub SALIRToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SALIRToolStripMenuItem.Click

        Me.Close()
        End

    End Sub

    Private Sub Zmain_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Call ConectarDB()
        Call ObtengoNtmp()
        'Call ImportarExcel()

    End Sub

    Private Sub CLIENTESToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CLIENTESToolStripMenuItem.Click

        ClientesList.Show()

    End Sub

    Private Sub ARTICULOSToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ARTICULOSToolStripMenuItem.Click

        ArticulosList.Show()

    End Sub

    Private Sub REMITOSToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles REMITOSToolStripMenuItem.Click

        RemitosList.Show()

    End Sub
End Class