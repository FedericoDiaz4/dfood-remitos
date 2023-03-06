<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Comprobante
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Visor = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.crComprobante1 = New BsAsRemitos.crComprobante()
        Me.SuspendLayout()
        '
        'Visor
        '
        Me.Visor.ActiveViewIndex = -1
        Me.Visor.AutoSize = True
        Me.Visor.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Visor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Visor.Cursor = System.Windows.Forms.Cursors.Default
        Me.Visor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Visor.EnableRefresh = False
        Me.Visor.Location = New System.Drawing.Point(0, 0)
        Me.Visor.Name = "Visor"
        Me.Visor.ShowCloseButton = False
        Me.Visor.ShowCopyButton = False
        Me.Visor.ShowExportButton = False
        Me.Visor.ShowGotoPageButton = False
        Me.Visor.ShowGroupTreeButton = False
        Me.Visor.ShowLogo = False
        Me.Visor.ShowParameterPanelButton = False
        Me.Visor.ShowRefreshButton = False
        Me.Visor.ShowTextSearchButton = False
        Me.Visor.ShowZoomButton = False
        Me.Visor.Size = New System.Drawing.Size(860, 489)
        Me.Visor.TabIndex = 0
        Me.Visor.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        '
        'Comprobante
        '
        Me.AllowDrop = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(860, 489)
        Me.Controls.Add(Me.Visor)
        Me.Font = New System.Drawing.Font("Lucida Sans Unicode", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "Comprobante"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Comprobante"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Visor As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents crComprobante1 As crComprobante
End Class
