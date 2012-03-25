Imports System.Windows.Forms

Public Class DialogImportText

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        If Len(Me.txtReferences.Text) = 0 Then
            MessageBox.Show("Please enter text", "Missing Value", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Dim client As Client = New Client()
        Dim value As Boolean = client.ImportFromText(Me.cmbInputFormat.SelectedItem.ToString, Me.txtReferences.Text)
        If value = False Then
            MessageBox.Show(client.GetErrorMessage)
        End If
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub DialogImportText_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.cmbInputFormat.SelectedIndex = 0
    End Sub
End Class
