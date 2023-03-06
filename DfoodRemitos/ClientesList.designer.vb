<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ClientesList
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ClientesList))
        Me.frmBuscar = New System.Windows.Forms.GroupBox()
        Me.txtBuscar = New System.Windows.Forms.TextBox()
        Me.cboBuscar = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Flex = New System.Windows.Forms.DataGridView()
        Me.frmBotones = New System.Windows.Forms.GroupBox()
        Me.cmdModificar = New System.Windows.Forms.Button()
        Me.cmdEliminar = New System.Windows.Forms.Button()
        Me.cmdSalir = New System.Windows.Forms.Button()
        Me.cmdNuevo = New System.Windows.Forms.Button()
        Me.frmBuscar.SuspendLayout()
        CType(Me.Flex, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.frmBotones.SuspendLayout()
        Me.SuspendLayout()
        '
        'frmBuscar
        '
        Me.frmBuscar.Controls.Add(Me.txtBuscar)
        Me.frmBuscar.Controls.Add(Me.cboBuscar)
        Me.frmBuscar.Controls.Add(Me.Label1)
        Me.frmBuscar.Location = New System.Drawing.Point(12, 1)
        Me.frmBuscar.Name = "frmBuscar"
        Me.frmBuscar.Size = New System.Drawing.Size(836, 76)
        Me.frmBuscar.TabIndex = 3
        Me.frmBuscar.TabStop = False
        '
        'txtBuscar
        '
        Me.txtBuscar.Location = New System.Drawing.Point(123, 42)
        Me.txtBuscar.Multiline = True
        Me.txtBuscar.Name = "txtBuscar"
        Me.txtBuscar.Size = New System.Drawing.Size(403, 24)
        Me.txtBuscar.TabIndex = 1
        '
        'cboBuscar
        '
        Me.cboBuscar.BackColor = System.Drawing.SystemColors.Window
        Me.cboBuscar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBuscar.FormattingEnabled = True
        Me.cboBuscar.Items.AddRange(New Object() {"NOMBRE"})
        Me.cboBuscar.Location = New System.Drawing.Point(6, 42)
        Me.cboBuscar.Name = "cboBuscar"
        Me.cboBuscar.Size = New System.Drawing.Size(111, 24)
        Me.cboBuscar.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 16)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Buscar"
        '
        'Flex
        '
        Me.Flex.AllowUserToAddRows = False
        Me.Flex.AllowUserToDeleteRows = False
        Me.Flex.AllowUserToResizeColumns = False
        Me.Flex.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Lucida Sans Unicode", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White
        Me.Flex.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.Flex.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken
        Me.Flex.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable
        Me.Flex.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Lucida Sans Unicode", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Flex.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.Flex.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Flex.EnableHeadersVisualStyles = False
        Me.Flex.Location = New System.Drawing.Point(12, 83)
        Me.Flex.MultiSelect = False
        Me.Flex.Name = "Flex"
        Me.Flex.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Lucida Sans Unicode", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Flex.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.Flex.RowHeadersVisible = False
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        Me.Flex.RowsDefaultCellStyle = DataGridViewCellStyle4
        Me.Flex.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Lucida Sans", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Flex.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.Flex.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight
        Me.Flex.RowTemplate.ReadOnly = True
        Me.Flex.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Flex.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Flex.ShowCellErrors = False
        Me.Flex.ShowEditingIcon = False
        Me.Flex.ShowRowErrors = False
        Me.Flex.Size = New System.Drawing.Size(836, 325)
        Me.Flex.TabIndex = 2
        '
        'frmBotones
        '
        Me.frmBotones.Controls.Add(Me.cmdModificar)
        Me.frmBotones.Controls.Add(Me.cmdEliminar)
        Me.frmBotones.Controls.Add(Me.cmdSalir)
        Me.frmBotones.Controls.Add(Me.cmdNuevo)
        Me.frmBotones.Location = New System.Drawing.Point(551, 414)
        Me.frmBotones.Name = "frmBotones"
        Me.frmBotones.Size = New System.Drawing.Size(297, 72)
        Me.frmBotones.TabIndex = 5
        Me.frmBotones.TabStop = False
        '
        'cmdModificar
        '
        Me.cmdModificar.Font = New System.Drawing.Font("Lucida Sans Unicode", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdModificar.Image = CType(resources.GetObject("cmdModificar.Image"), System.Drawing.Image)
        Me.cmdModificar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdModificar.Location = New System.Drawing.Point(81, 23)
        Me.cmdModificar.Name = "cmdModificar"
        Me.cmdModificar.Size = New System.Drawing.Size(66, 40)
        Me.cmdModificar.TabIndex = 4
        Me.cmdModificar.Text = "&Modificar"
        Me.cmdModificar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdModificar.UseVisualStyleBackColor = True
        '
        'cmdEliminar
        '
        Me.cmdEliminar.Font = New System.Drawing.Font("Lucida Sans Unicode", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdEliminar.Image = CType(resources.GetObject("cmdEliminar.Image"), System.Drawing.Image)
        Me.cmdEliminar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdEliminar.Location = New System.Drawing.Point(153, 23)
        Me.cmdEliminar.Name = "cmdEliminar"
        Me.cmdEliminar.Size = New System.Drawing.Size(66, 40)
        Me.cmdEliminar.TabIndex = 5
        Me.cmdEliminar.Text = "&Eliminar"
        Me.cmdEliminar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdEliminar.UseVisualStyleBackColor = True
        '
        'cmdSalir
        '
        Me.cmdSalir.Font = New System.Drawing.Font("Lucida Sans Unicode", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSalir.Image = CType(resources.GetObject("cmdSalir.Image"), System.Drawing.Image)
        Me.cmdSalir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdSalir.Location = New System.Drawing.Point(225, 23)
        Me.cmdSalir.Name = "cmdSalir"
        Me.cmdSalir.Size = New System.Drawing.Size(66, 40)
        Me.cmdSalir.TabIndex = 6
        Me.cmdSalir.Text = "&Salir"
        Me.cmdSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdSalir.UseVisualStyleBackColor = True
        '
        'cmdNuevo
        '
        Me.cmdNuevo.Font = New System.Drawing.Font("Lucida Sans Unicode", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdNuevo.Image = CType(resources.GetObject("cmdNuevo.Image"), System.Drawing.Image)
        Me.cmdNuevo.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdNuevo.Location = New System.Drawing.Point(9, 23)
        Me.cmdNuevo.Name = "cmdNuevo"
        Me.cmdNuevo.Size = New System.Drawing.Size(66, 40)
        Me.cmdNuevo.TabIndex = 3
        Me.cmdNuevo.Text = "&Nuevo"
        Me.cmdNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdNuevo.UseVisualStyleBackColor = True
        '
        'ClientesList
        '
        Me.AllowDrop = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(860, 489)
        Me.Controls.Add(Me.frmBotones)
        Me.Controls.Add(Me.Flex)
        Me.Controls.Add(Me.frmBuscar)
        Me.Font = New System.Drawing.Font("Lucida Sans Unicode", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "ClientesList"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Clientes"
        Me.frmBuscar.ResumeLayout(False)
        Me.frmBuscar.PerformLayout()
        CType(Me.Flex, System.ComponentModel.ISupportInitialize).EndInit()
        Me.frmBotones.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents frmBuscar As GroupBox
    Friend WithEvents txtBuscar As TextBox
    Friend WithEvents cboBuscar As ComboBox
    Friend WithEvents frmBotones As GroupBox
    Friend WithEvents cmdNuevo As Button
    Friend WithEvents cmdModificar As Button
    Friend WithEvents cmdEliminar As Button
    Private WithEvents Label1 As Label
    Private WithEvents Flex As DataGridView
    Friend WithEvents cmdSalir As Button
End Class
