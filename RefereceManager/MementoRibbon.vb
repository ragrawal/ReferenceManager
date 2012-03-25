Imports Microsoft.Office.Tools.Ribbon

Public Class MementoRibbon
    Private ImportUrlDialog As DialogImportUrl
    Private ImportTextDialog As DialogImportText
    Private ExportDialog As DialogExport
    Private Sub MementoRibbon_Load(ByVal sender As System.Object, ByVal e As RibbonUIEventArgs) Handles MyBase.Load

    End Sub
    Private Sub SearchToggleButton_Click(ByVal sender As System.Object, ByVal e As Microsoft.Office.Tools.Ribbon.RibbonControlEventArgs) Handles SearchToggleButton.Click
        If Not Globals.ThisAddIn.isSearchTaskPaneDisplayed Then
            Globals.ThisAddIn.AddAllSearchTaskPane()
        Else
            Globals.ThisAddIn.RemoveAllSearchTaskPanes()
        End If
    End Sub
    Private Sub btnImportUrl_Click(ByVal sender As System.Object, ByVal e As Microsoft.Office.Tools.Ribbon.RibbonControlEventArgs) Handles btnImportUrl.Click
        ImportUrlDialog = New DialogImportUrl()
        ImportUrlDialog.Show()
    End Sub
    Private Sub btnImportText_Click(ByVal sender As System.Object, ByVal e As Microsoft.Office.Tools.Ribbon.RibbonControlEventArgs) Handles btnImportText.Click
        ImportTextDialog = New DialogImportText()
        ImportTextDialog.Show()
    End Sub

    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As Microsoft.Office.Tools.Ribbon.RibbonControlEventArgs) Handles btnExport.Click
        ExportDialog = New DialogExport()
        ExportDialog.Show()
    End Sub
End Class
