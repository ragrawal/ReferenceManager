Imports System.Windows.Forms
Imports System.Net

Public Class DialogImportUrl

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        If Len(Me.txtURL.Text) = 0 Then
            MessageBox.Show("Please enter url", "Missing Value", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Dim client As Client = New Client()
        Dim value As Boolean = client.ImportFromURL(Me.txtURL.Text.ToString)
        If value = False Then
            MessageBox.Show(client.GetErrorMessage)
        End If
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

End Class
