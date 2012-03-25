Imports System.Windows.Forms
Imports Microsoft.Office.Interop.Word
Imports System.IO


Public Class DialogExport
    Dim client As Client

    Sub Main()

    End Sub
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        'Get Selected Sources
        Try
            Dim row As DataGridViewRow
            Dim citations As String
            citations = ""
            For Each row In dgvRef.SelectedRows
                citations += row.Cells.Item("SourceCol").Value
            Next

            Dim value As String
            value = "<?xml version=""1.0"" encoding=""UTF-8"" ?>"
            value += "<b:Sources xmlns:b=""http://schemas.openxmlformats.org/officeDocument/2006/bibliography"" xmlns=""http://schemas.openxmlformats.org/officeDocument/2006/bibliography"">"
            value += citations
            value += "</b:Sources>"

            'Create Data Dictionary
            Dim data As Dictionary(Of String, String) = New Dictionary(Of String, String)
            Dim outputFormat As String = Me.cmbExportOption.SelectedItem.ToString
            data.Add("input", "OFFICE2007XML")
            data.Add("value", value)
            data.Add("output", outputFormat)

            'Create URI
            Dim uri As Uri = New Uri(Globals.ThisAddIn.getHost + "services/convert.text")


            'Create Client
            Dim client As Client = New Client()
            Dim reader As StreamReader = client.SendRequest(uri, data)

            'Sanity Check
            If reader Is Nothing Then
                MessageBox.Show(client.GetErrorMessage)
            Else
                'Display response
                Dim txt As String = reader.ReadLine
                txtBoxExport.Text = ""
                While txt IsNot Nothing
                    'AppendText is slow
                    'Todo: Use StringBuilder to build a string and 
                    ' then put in the text box
                    txtBoxExport.AppendText(Environment.NewLine)
                    txtBoxExport.AppendText(txt)
                    txt = reader.ReadLine
                End While

            End If

            'Catch any unanticipated errors
        Catch ex As Exception
            MessageBox.Show("Unexpected Error occured")
            Me.Close()
        End Try

    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvRef.CellContentClick

    End Sub

    Private Sub DialogExport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.cmbExportOption.SelectedIndex = 0

        Dim sources As Sources = Globals.ThisAddIn.Application.ActiveDocument.Bibliography.Sources

        Dim objSource As Source

        On Error Resume Next
        For Each objSource In sources
            Dim index As Integer = dgvRef.Rows.Add()
            dgvRef.Item("AuthorCol", index).Value = objSource.Field("Author")
            dgvRef.Item("TitleCol", index).Value = objSource.Field("Title")
            dgvRef.Item("YearCol", index).Value = objSource.Field("Year")
            'dgvRef.Item("JournalCol", index).Value = objSource.Field("Publisher")
            dgvRef.Item("SourceCol", index).Value = objSource.XML
        Next
    End Sub
End Class
