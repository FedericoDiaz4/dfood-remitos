<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RemitosList
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
        Me.frmBuscar = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboCliente = New System.Windows.Forms.ComboBox()
        Me.txtCodCliente = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboTipoComprobante = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Flex = New System.Windows.Forms.DataGridView()
        Me.frmBotones = New System.Windows.Forms.GroupBox()
        Me.CmdEliminar = New System.Windows.Forms.Button()
        Me.cmdModificar = New System.Windows.Forms.Button()
        Me.cmdSalir = New System.Windows.Forms.Button()
        Me.cmdNuevo = New System.Windows.Forms.Button()
        Me.frmBuscar.SuspendLayout()
        CType(Me.Flex, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.frmBotones.SuspendLayout()
        Me.SuspendLayout()
        '
        'frmBuscar
        '
        Me.frmBuscar.Controls.Add(Me.Label3)
        Me.frmBuscar.Controls.Add(Me.cboCliente)
        Me.frmBuscar.Controls.Add(Me.txtCodCliente)
        Me.frmBuscar.Controls.Add(Me.Label1)
        Me.frmBuscar.Controls.Add(Me.cboTipoComprobante)
        Me.frmBuscar.Controls.Add(Me.Label2)
        Me.frmBuscar.Location = New System.Drawing.Point(12, 1)
        Me.frmBuscar.Name = "frmBuscar"
        Me.frmBuscar.Size = New System.Drawing.Size(836, 76)
        Me.frmBuscar.TabIndex = 3
        Me.frmBuscar.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(320, 23)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(106, 16)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Nombre Cliente"
        '
        'cboCliente
        '
        Me.cboCliente.BackColor = System.Drawing.SystemColors.Window
        Me.cboCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCliente.FormattingEnabled = True
        Me.cboCliente.Items.AddRange(New Object() {"NOMBRE"})
        Me.cboCliente.Location = New System.Drawing.Point(323, 42)
        Me.cboCliente.Name = "cboCliente"
        Me.cboCliente.Size = New System.Drawing.Size(507, 24)
        Me.cboCliente.TabIndex = 8
        '
        'txtCodCliente
        '
        Me.txtCodCliente.Location = New System.Drawing.Point(216, 42)
        Me.txtCodCliente.Multiline = True
        Me.txtCodCliente.Name = "txtCodCliente"
        Me.txtCodCliente.Size = New System.Drawing.Size(101, 24)
        Me.txtCodCliente.TabIndex = 7
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(213, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(101, 16)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Código Cliente"
        '
        'cboTipoComprobante
        '
        Me.cboTipoComprobante.BackColor = System.Drawing.SystemColors.Window
        Me.cboTipoComprobante.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoComprobante.FormattingEnabled = True
        Me.cboTipoComprobante.Items.AddRange(New Object() {"NOMBRE"})
        Me.cboTipoComprobante.Location = New System.Drawing.Point(6, 42)
        Me.cboTipoComprobante.Name = "cboTipoComprobante"
        Me.cboTipoComprobante.Size = New System.Drawing.Size(204, 24)
        Me.cboTipoComprobante.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 23)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(125, 16)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Tipo Comprobante"
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
        Me.frmBotones.Controls.Add(Me.CmdEliminar)
        Me.frmBotones.Controls.Add(Me.cmdModificar)
        Me.frmBotones.Controls.Add(Me.cmdSalir)
        Me.frmBotones.Controls.Add(Me.cmdNuevo)
        Me.frmBotones.Location = New System.Drawing.Point(553, 414)
        Me.frmBotones.Name = "frmBotones"
        Me.frmBotones.Size = New System.Drawing.Size(295, 72)
        Me.frmBotones.TabIndex = 5
        Me.frmBotones.TabStop = False
        '
        'CmdEliminar
        '
        Me.CmdEliminar.Font = New System.Drawing.Font("Lucida Sans Unicode", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdEliminar.Image = Global.BsAsRemitos.My.Resources.Resources.del_16
        Me.CmdEliminar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.CmdEliminar.Location = New System.Drawing.Point(150, 23)
        Me.CmdEliminar.Name = "CmdEliminar"
        Me.CmdEliminar.Size = New System.Drawing.Size(66, 40)
        Me.CmdEliminar.TabIndex = 7
        Me.CmdEliminar.Text = "&Eliminar"
        Me.CmdEliminar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.CmdEliminar.UseVisualStyleBackColor = True
        '
        'cmdModificar
        '
        Me.cmdModificar.Font = New System.Drawing.Font("Lucida Sans Unicode", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdModificar.Image = Global.BsAsRemitos.My.Resources.Resources.edit_16
        Me.cmdModificar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdModificar.Location = New System.Drawing.Point(78, 23)
        Me.cmdModificar.Name = "cmdModificar"
        Me.cmdModificar.Size = New System.Drawing.Size(66, 40)
        Me.cmdModificar.TabIndex = 4
        Me.cmdModificar.Text = "&Modificar"
        Me.cmdModificar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdModificar.UseVisualStyleBackColor = True
        '
        'cmdSalir
        '
        Me.cmdSalir.Font = New System.Drawing.Font("Lucida Sans Unicode", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSalir.Image = Global.BsAsRemitos.My.Resources.Resources._exit
        Me.cmdSalir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdSalir.Location = New System.Drawing.Point(222, 23)
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
        Me.cmdNuevo.Image = Global.BsAsRemitos.My.Resources.Resources.add_16
        Me.cmdNuevo.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdNuevo.Location = New System.Drawing.Point(6, 23)
        Me.cmdNuevo.Name = "cmdNuevo"
        Me.cmdNuevo.Size = New System.Drawing.Size(66, 40)
        Me.cmdNuevo.TabIndex = 3
        Me.cmdNuevo.Text = "&Nuevo"
        Me.cmdNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdNuevo.UseVisualStyleBackColor = True
        '
        'RemitosList
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
        Me.Name = "RemitosList"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Remitos"
        Me.frmBuscar.ResumeLayout(False)
        Me.frmBuscar.PerformLayout()
        CType(Me.Flex, System.ComponentModel.ISupportInitialize).EndInit()
        Me.frmBotones.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents frmBuscar As GroupBox
    Friend WithEvents frmBotones As GroupBox
    Friend WithEvents cmdNuevo As Button
    Friend WithEvents cmdModificar As Button
    Private WithEvents Flex As DataGridView
    Friend WithEvents cmdSalir As Button
    Friend WithEvents cboTipoComprobante As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents txtCodCliente As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents cboCliente As ComboBox
    Friend WithEvents CmdEliminar As Button
End Class
