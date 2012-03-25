Public Class ThisAddIn
    Private WithEvents SearchTaskPane As Microsoft.Office.Tools.CustomTaskPane
    Private ctp As Microsoft.Office.Tools.CustomTaskPane
    Private ctpWindow As Word.Window
    Private SearchDisplayed As Boolean = False
    Private HostServer As String = "http://findnwrite.com/memento/"

    Public Function getHost() As String
        Return HostServer
    End Function

    Public ReadOnly Property isSearchTaskPaneDisplayed() As Boolean
        Get
            Return SearchDisplayed
        End Get
    End Property

    Public Sub ChangeAllSearchTaskPaneVisibility(ByVal isVisible As Boolean)
        If Globals.ThisAddIn.Application.Documents.Count > 0 Then
            If Me.Application.ShowWindowsInTaskbar Then
                For Each _doc As Word.Document In Me.Application.Documents
                    ChangeSearchTaskPaneVisibility(_doc, isVisible)
                Next
            Else
                ChangeSearchTaskPaneVisibility(Me.Application.ActiveDocument, isVisible)
            End If
            SearchDisplayed = isVisible
        End If
    End Sub
    Public Sub ChangeSearchTaskPaneVisibility(ByVal doc As Word.Document, ByVal isVisible As Boolean)
        If Globals.ThisAddIn.Application.Documents.Count > 0 Then
            For i As Integer = Me.CustomTaskPanes.Count To 1 Step -1
                ctp = Me.CustomTaskPanes.Item(i - 1)
                If ctp.Title = "Memento Search" Then
                    ctp.Visible = isVisible
                End If
            Next
            SearchDisplayed = isVisible
        End If
    End Sub

    Public Sub AddAllSearchTaskPane()
        If Globals.ThisAddIn.Application.Documents.Count > 0 Then
            If Me.Application.ShowWindowsInTaskbar Then
                For Each _doc As Word.Document In Me.Application.Documents
                    AddSearchTaskPane(_doc)
                Next
            Else
                If Not SearchDisplayed Then
                    AddSearchTaskPane(Me.Application.ActiveDocument)
                End If
            End If
            SearchDisplayed = True
        End If
    End Sub



    Public Sub AddSearchTaskPane(ByVal doc As Word.Document)
        SearchTaskPane = Me.CustomTaskPanes.Add( _
            New MementoUserControl(), "Memento Search", doc.ActiveWindow)
        SearchTaskPane.Visible = True
    End Sub

    Public Sub RemoveAllSearchTaskPanes()
        If Globals.ThisAddIn.Application.Documents.Count > 0 Then
            For i As Integer = Me.CustomTaskPanes.Count To 1 Step -1
                ctp = Me.CustomTaskPanes.Item(i - 1)
                If ctp.Title = "Memento Search" Then
                    Me.CustomTaskPanes.RemoveAt(i - 1)
                End If
            Next
            SearchDisplayed = False
        End If
    End Sub


    Public Sub RemoveSearchTaskPane(ByVal _doc As Word.Document)
        For Each _ctp As Microsoft.Office.Tools.CustomTaskPane In _
            Me.CustomTaskPanes
            ctpWindow = CType(_ctp.Window, Word.Window)
            If _ctp.Title = "Memento Search" And _
                ctpWindow Is _doc.ActiveWindow Then
                Me.CustomTaskPanes.Remove(_ctp)
                Exit For
            End If
        Next
        SearchDisplayed = False
    End Sub

    Private Sub RemoveOrphanedTaskPanes()
        For i As Integer = Me.CustomTaskPanes.Count To 1 Step -1
            ctp = Me.CustomTaskPanes.Item(i - 1)
            If ctp.Window Is Nothing Then
                Me.CustomTaskPanes.Remove(ctp)
            End If
        Next
    End Sub

    Private Sub Application_DocumentChange() Handles Application.DocumentChange
        RemoveOrphanedTaskPanes()
    End Sub

    Private Sub Application_NewDocument(ByVal Doc As Microsoft.Office.Interop.Word.Document) Handles Application.NewDocument
        If SearchDisplayed And Me.Application.ShowWindowsInTaskbar Then
            AddSearchTaskPane(Doc)
        End If
    End Sub

    Private Sub Application_DocumentOpen(ByVal Doc As Microsoft.Office.Interop.Word.Document) Handles Application.DocumentOpen
        RemoveOrphanedTaskPanes()
        If SearchDisplayed And Me.Application.ShowWindowsInTaskbar Then
            AddSearchTaskPane(Doc)
        End If
    End Sub

    Private Sub ThisAddIn_Startup(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Startup
    End Sub

    Private Sub ThisAddIn_Shutdown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shutdown
        RemoveAllSearchTaskPanes()
    End Sub

End Class
