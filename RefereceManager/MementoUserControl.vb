Imports System.Windows.Forms
Imports Microsoft.Office.Interop.Word

Public Class MementoUserControl
    Private table As Data.DataTable


    Private header() As String = New String() {"id", "title", "author", "year", "abstract", "journal", "publisher"}
    Private id As Integer = 0
    Private title As Integer = 1
    Private author As Integer = 2
    Private year As Integer = 3
    Private abstract As Integer = 4
    Private journal As Integer = 5
    Private publisher As Integer = 6

    'Constructor
    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        makeTable()

    End Sub

    Public Sub makeTable()
        'Create Table
        table = New Data.DataTable()
        Dim column As Data.DataColumn

        For i = 0 To header.Length - 1
            column = New Data.DataColumn()
            column.DataType = System.Type.GetType("System.String")
            column.ColumnName = header.GetValue(i).ToString
            table.Columns.Add(column)
        Next

        'Create Data Grid View
        lstRecords.DataSource = table
        lstRecords.Columns().Item(id).Visible = False
        lstRecords.Columns().Item(author).Visible = False
        lstRecords.Columns().Item(year).Visible = False
        lstRecords.Columns().Item(abstract).Visible = False
        lstRecords.Columns().Item(journal).Visible = False
        lstRecords.Columns().Item(publisher).Visible = False
        lstRecords.Columns().Item(title).Resizable = DataGridViewTriState.True
        lstRecords.Columns().Item(title).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        lstRecords.DefaultCellStyle.WrapMode = DataGridViewTriState.True
        lstRecords.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        lstRecords.MultiSelect = True
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        search()
    End Sub

    Private Sub lstRecords_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles lstRecords.CellContentClick
        Dim row As DataGridViewRow = lstRecords.SelectedRows().Item(lstRecords.SelectedRows().Count - 1)
        rtbPreview.Clear()
        Dim preview(0 To 8) As String

        preview(0) = "Title: " + row.Cells.Item(title).Value.ToString
        preview(1) = "Author: " + row.Cells.Item(author).Value.ToString
        preview(2) = ""
        preview(3) = "Abstract: " + row.Cells.Item(abstract).Value.ToString
        preview(4) = ""
        preview(5) = "Year: " + row.Cells.Item(year).Value.ToString
        preview(6) = "Journal: " + row.Cells.Item(journal).Value.ToString
        preview(7) = "Publisher: " + row.Cells.Item(publisher).Value.ToString
        preview(8) = "URL: " + Globals.ThisAddIn.getHost + "articles/details/" + row.Cells.Item(id).Value.ToString
        rtbPreview.Lines = preview
    End Sub

    Private Sub btnImport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImport.Click
        Dim count As Integer = lstRecords.SelectedRows.Count
        Dim response As New MSXML2.DOMDocument
        Dim request As New MSXML2.XMLHTTP
        Dim records As MSXML2.IXMLDOMNodeList
        Dim details As MSXML2.IXMLDOMNodeList
        Dim query As String
        Dim row As Data.DataRow

        If count = 0 Then
            MsgBox("Please select atleast one article to import")
            Exit Sub
        End If

        Dim ids(0 To count - 1) As String

        For i = 0 To count - 1
            Dim r As DataGridViewRow = lstRecords.SelectedRows.Item(i)
            ids(i) = r.Cells().Item(0).Value.ToString
        Next

        query = Globals.ThisAddIn.getHost + "exports/export/type:OFFICE2007XML/article:" + Trim(String.Join(",", ids))

        request.open("GET", query, False)
        request.send()
        response.loadXML(Trim(request.responseText))

        records = response.selectNodes("//b:Source")
        On Error Resume Next
        Dim active As Document = Globals.ThisAddIn.Application.ActiveDocument()
        For i = 0 To records.length - 1
            active.Bibliography.Sources.Add(records.item(i).xml)
        Next i
        MsgBox("Successfully imported selections")
        lstRecords.ClearSelection()
    End Sub


    Private Sub search()
        lblMessage.Text = "Searching...."
        lblMessage.Visible = True
        lblMessage.Refresh()
        Dim response As New MSXML2.DOMDocument
        Dim request As New MSXML2.XMLHTTP
        Dim records As MSXML2.IXMLDOMNodeList
        Dim details As MSXML2.IXMLDOMNodeList
        Dim query As String
        Dim row As Data.DataRow

        If txtSearch.Text = "" Then
            MsgBox("Please enter search term")
            Exit Sub
        End If

        query = Globals.ThisAddIn.getHost + "search/personal.xml?by=" + cmbType.SelectedItem.ToString + "&query=" + txtSearch.Text

        request.open("GET", query, False)
        request.send()
        If response.loadXML(Trim(request.responseText)) = True Then
            lblMessage.Text = "loading result..."
            lblMessage.Refresh()
        Else
            lblMessage.Text = "failed to load result"
            lblMessage.Refresh()
            Exit Sub

        End If

        records = response.selectNodes("//Article")
        If records.length = 0 Then
            lblMessage.Visible = False
            MsgBox("No result found")
            Exit Sub
        End If

        table.Clear()


        On Error Resume Next
        For i = 0 To records.length - 1
            row = table.NewRow()
            Dim node As MSXML2.IXMLDOMNode = records.item(i)
            row("id") = node.attributes().getNamedItem("id").text
            row("title") = node.attributes().getNamedItem("title").text
            row("abstract") = node.selectSingleNode("Abstract").text
            row("Journal") = node.selectSingleNode("Journal").text
            row("publisher") = node.selectSingleNode("Publisher").text
            row("author") = node.selectSingleNode("Author").text
            row("year") = node.selectSingleNode("Year").text
            table.Rows.Add(row)
        Next

        lblMessage.Visible = False
        lblMessage.Refresh()
    End Sub

    Public p As New System.Diagnostics.Process
    Private Sub rtbPreview_LinkClicked(ByVal sender As Object, ByVal e As System.Windows.Forms.LinkClickedEventArgs) Handles rtbPreview.LinkClicked
        p = System.Diagnostics.Process.Start(e.LinkText)
    End Sub

    Public Sub StopWebProcess()
        p.Kill()
    End Sub

End Class
