Partial Class MementoRibbon
    Inherits Microsoft.Office.Tools.Ribbon.OfficeRibbon

    <System.Diagnostics.DebuggerNonUserCode()> _
   Public Sub New(ByVal container As System.ComponentModel.IContainer)
        MyClass.New()

        'Required for Windows.Forms Class Composition Designer support
        If (container IsNot Nothing) Then
            container.Add(Me)
        End If

    End Sub

    <System.Diagnostics.DebuggerNonUserCode()> _
    Public Sub New()
        MyBase.New()

        'This call is required by the Component Designer.
        InitializeComponent()

    End Sub

    'Component overrides dispose to clean up the component list.
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

    'Required by the Component Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Component Designer
    'It can be modified using the Component Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.MementoTab = New Microsoft.Office.Tools.Ribbon.RibbonTab
        Me.Group1 = New Microsoft.Office.Tools.Ribbon.RibbonGroup
        Me.GroupImport = New Microsoft.Office.Tools.Ribbon.RibbonGroup
        Me.GroupExport = New Microsoft.Office.Tools.Ribbon.RibbonGroup
        Me.SearchToggleButton = New Microsoft.Office.Tools.Ribbon.RibbonToggleButton
        Me.btnImportUrl = New Microsoft.Office.Tools.Ribbon.RibbonButton
        Me.btnImportText = New Microsoft.Office.Tools.Ribbon.RibbonButton
        Me.btnExport = New Microsoft.Office.Tools.Ribbon.RibbonButton
        Me.MementoTab.SuspendLayout()
        Me.Group1.SuspendLayout()
        Me.GroupImport.SuspendLayout()
        Me.GroupExport.SuspendLayout()
        Me.SuspendLayout()
        '
        'MementoTab
        '
        Me.MementoTab.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office
        Me.MementoTab.Groups.Add(Me.Group1)
        Me.MementoTab.Groups.Add(Me.GroupImport)
        Me.MementoTab.Groups.Add(Me.GroupExport)
        Me.MementoTab.Label = "Memento"
        Me.MementoTab.Name = "MementoTab"
        '
        'Group1
        '
        Me.Group1.Items.Add(Me.SearchToggleButton)
        Me.Group1.Label = "Search"
        Me.Group1.Name = "Group1"
        '
        'GroupImport
        '
        Me.GroupImport.Items.Add(Me.btnImportUrl)
        Me.GroupImport.Items.Add(Me.btnImportText)
        Me.GroupImport.Label = "Import"
        Me.GroupImport.Name = "GroupImport"
        '
        'GroupExport
        '
        Me.GroupExport.Items.Add(Me.btnExport)
        Me.GroupExport.Label = "Export"
        Me.GroupExport.Name = "GroupExport"
        '
        'SearchToggleButton
        '
        Me.SearchToggleButton.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge
        Me.SearchToggleButton.Image = Global.RefereceManager.My.Resources.Resources._106
        Me.SearchToggleButton.Label = " "
        Me.SearchToggleButton.Name = "SearchToggleButton"
        Me.SearchToggleButton.ShowImage = True
        '
        'btnImportUrl
        '
        Me.btnImportUrl.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge
        Me.btnImportUrl.Image = Global.RefereceManager.My.Resources.Resources._61
        Me.btnImportUrl.Label = "From Website"
        Me.btnImportUrl.Name = "btnImportUrl"
        Me.btnImportUrl.ShowImage = True
        '
        'btnImportText
        '
        Me.btnImportText.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge
        Me.btnImportText.Image = Global.RefereceManager.My.Resources.Resources._1
        Me.btnImportText.Label = "From Text File"
        Me.btnImportText.Name = "btnImportText"
        Me.btnImportText.ShowImage = True
        '
        'btnExport
        '
        Me.btnExport.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge
        Me.btnExport.Image = Global.RefereceManager.My.Resources.Resources._19
        Me.btnExport.Label = "Export"
        Me.btnExport.Name = "btnExport"
        Me.btnExport.ShowImage = True
        '
        'MementoRibbon
        '
        Me.Name = "MementoRibbon"
        Me.RibbonType = "Microsoft.Word.Document"
        Me.Tabs.Add(Me.MementoTab)
        Me.MementoTab.ResumeLayout(False)
        Me.MementoTab.PerformLayout()
        Me.Group1.ResumeLayout(False)
        Me.Group1.PerformLayout()
        Me.GroupImport.ResumeLayout(False)
        Me.GroupImport.PerformLayout()
        Me.GroupExport.ResumeLayout(False)
        Me.GroupExport.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents MementoTab As Microsoft.Office.Tools.Ribbon.RibbonTab
    Friend WithEvents Group1 As Microsoft.Office.Tools.Ribbon.RibbonGroup
    Friend WithEvents SearchToggleButton As Microsoft.Office.Tools.Ribbon.RibbonToggleButton
    Friend WithEvents GroupImport As Microsoft.Office.Tools.Ribbon.RibbonGroup
    Friend WithEvents btnImportUrl As Microsoft.Office.Tools.Ribbon.RibbonButton
    Friend WithEvents btnImportText As Microsoft.Office.Tools.Ribbon.RibbonButton
    Friend WithEvents GroupExport As Microsoft.Office.Tools.Ribbon.RibbonGroup
    Friend WithEvents btnExport As Microsoft.Office.Tools.Ribbon.RibbonButton
End Class

Partial Class ThisRibbonCollection
    Inherits Microsoft.Office.Tools.Ribbon.RibbonReadOnlyCollection

    <System.Diagnostics.DebuggerNonUserCode()> _
    Friend ReadOnly Property MementoRibbon() As MementoRibbon
        Get
            Return Me.GetRibbon(Of MementoRibbon)()
        End Get
    End Property
End Class
