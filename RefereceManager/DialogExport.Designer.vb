<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DialogExport
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.OK_Button = New System.Windows.Forms.Button
        Me.Cancel_Button = New System.Windows.Forms.Button
        Me.cmbExportOption = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.dgvRef = New System.Windows.Forms.DataGridView
        Me.Label2 = New System.Windows.Forms.Label
        Me.AuthorCol = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TitleCol = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.YearCol = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.JournalCol = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SourceCol = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.txtBoxExport = New System.Windows.Forms.TextBox
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.dgvRef, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(489, 425)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(146, 36)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Location = New System.Drawing.Point(3, 6)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(67, 23)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "OK"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(76, 6)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(67, 23)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "Cancel"
        '
        'cmbExportOption
        '
        Me.cmbExportOption.FormattingEnabled = True
        Me.cmbExportOption.Items.AddRange(New Object() {"BIBTEX ", "LATEX ", "EndNote ", "OFFICE2007XML ", "RDF ", "APA ", "BMJ ", "CHICAGO ", "HARVARD ", "IEEE ", "MLA ", "TURABIAN "})
        Me.cmbExportOption.Location = New System.Drawing.Point(116, 425)
        Me.cmbExportOption.Name = "cmbExportOption"
        Me.cmbExportOption.Size = New System.Drawing.Size(121, 21)
        Me.cmbExportOption.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(36, 430)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(74, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Output Format"
        '
        'dgvRef
        '
        Me.dgvRef.AllowUserToAddRows = False
        Me.dgvRef.AllowUserToDeleteRows = False
        Me.dgvRef.AllowUserToOrderColumns = True
        Me.dgvRef.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvRef.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.AuthorCol, Me.TitleCol, Me.YearCol, Me.JournalCol, Me.SourceCol})
        Me.dgvRef.Location = New System.Drawing.Point(13, 36)
        Me.dgvRef.Name = "dgvRef"
        Me.dgvRef.ReadOnly = True
        Me.dgvRef.Size = New System.Drawing.Size(627, 380)
        Me.dgvRef.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(15, 13)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(144, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Select References To Export"
        '
        'AuthorCol
        '
        Me.AuthorCol.HeaderText = "Primary Author"
        Me.AuthorCol.Name = "AuthorCol"
        Me.AuthorCol.ReadOnly = True
        '
        'TitleCol
        '
        Me.TitleCol.HeaderText = "Title"
        Me.TitleCol.Name = "TitleCol"
        Me.TitleCol.ReadOnly = True
        '
        'YearCol
        '
        Me.YearCol.HeaderText = "Year"
        Me.YearCol.Name = "YearCol"
        Me.YearCol.ReadOnly = True
        '
        'JournalCol
        '
        Me.JournalCol.HeaderText = "Journal"
        Me.JournalCol.Name = "JournalCol"
        Me.JournalCol.ReadOnly = True
        '
        'SourceCol
        '
        Me.SourceCol.HeaderText = "Source"
        Me.SourceCol.Name = "SourceCol"
        Me.SourceCol.ReadOnly = True
        Me.SourceCol.Visible = False
        '
        'txtBoxExport
        '
        Me.txtBoxExport.Location = New System.Drawing.Point(13, 469)
        Me.txtBoxExport.Multiline = True
        Me.txtBoxExport.Name = "txtBoxExport"
        Me.txtBoxExport.Size = New System.Drawing.Size(627, 131)
        Me.txtBoxExport.TabIndex = 5
        '
        'DialogExport
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(647, 612)
        Me.Controls.Add(Me.txtBoxExport)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.dgvRef)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmbExportOption)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DialogExport"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Export References"
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.dgvRef, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents cmbExportOption As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dgvRef As System.Windows.Forms.DataGridView
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents AuthorCol As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TitleCol As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents YearCol As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents JournalCol As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SourceCol As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtBoxExport As System.Windows.Forms.TextBox

End Class
