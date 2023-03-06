<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class zmain
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.MenuStrip = New System.Windows.Forms.MenuStrip()
        Me.PARAMETROSToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CLIENTESToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ARTICULOSToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.REMITOSToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SALIRToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.MenuStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip
        '
        Me.MenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PARAMETROSToolStripMenuItem, Me.REMITOSToolStripMenuItem, Me.SALIRToolStripMenuItem})
        Me.MenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip.Name = "MenuStrip"
        Me.MenuStrip.Padding = New System.Windows.Forms.Padding(7, 2, 0, 2)
        Me.MenuStrip.Size = New System.Drawing.Size(737, 24)
        Me.MenuStrip.TabIndex = 5
        Me.MenuStrip.Text = "MenuStrip"
        '
        'PARAMETROSToolStripMenuItem
        '
        Me.PARAMETROSToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CLIENTESToolStripMenuItem, Me.ARTICULOSToolStripMenuItem})
        Me.PARAMETROSToolStripMenuItem.Name = "PARAMETROSToolStripMenuItem"
        Me.PARAMETROSToolStripMenuItem.Size = New System.Drawing.Size(93, 20)
        Me.PARAMETROSToolStripMenuItem.Text = "&PARAMETROS"
        '
        'CLIENTESToolStripMenuItem
        '
        Me.CLIENTESToolStripMenuItem.Name = "CLIENTESToolStripMenuItem"
        Me.CLIENTESToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.CLIENTESToolStripMenuItem.Text = "&CLIENTES"
        '
        'ARTICULOSToolStripMenuItem
        '
        Me.ARTICULOSToolStripMenuItem.Name = "ARTICULOSToolStripMenuItem"
        Me.ARTICULOSToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.ARTICULOSToolStripMenuItem.Text = "&ARTICULOS"
        '
        'REMITOSToolStripMenuItem
        '
        Me.REMITOSToolStripMenuItem.Name = "REMITOSToolStripMenuItem"
        Me.REMITOSToolStripMenuItem.Size = New System.Drawing.Size(66, 20)
        Me.REMITOSToolStripMenuItem.Text = "&REMITOS"
        '
        'SALIRToolStripMenuItem
        '
        Me.SALIRToolStripMenuItem.Name = "SALIRToolStripMenuItem"
        Me.SALIRToolStripMenuItem.Size = New System.Drawing.Size(49, 20)
        Me.SALIRToolStripMenuItem.Text = "&SALIR"
        '
        'zmain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDark
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(737, 558)
        Me.Controls.Add(Me.MenuStrip)
        Me.Font = New System.Drawing.Font("Lucida Sans Unicode", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "zmain"
        Me.Text = " Buenos Aires Cheff - Remitos"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip.ResumeLayout(False)
        Me.MenuStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents MenuStrip As System.Windows.Forms.MenuStrip
    Friend WithEvents SALIRToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PARAMETROSToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CLIENTESToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ARTICULOSToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents REMITOSToolStripMenuItem As ToolStripMenuItem
End Class
