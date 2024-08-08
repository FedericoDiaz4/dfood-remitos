<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class InformeEncabezadoRemitos
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
        Me.DtpHasta = New System.Windows.Forms.DateTimePicker()
        Me.DtpDesde = New System.Windows.Forms.DateTimePicker()
        Me.label2 = New System.Windows.Forms.Label()
        Me.label5 = New System.Windows.Forms.Label()
        Me.cmdOk = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'DtpHasta
        '
        Me.DtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtpHasta.Location = New System.Drawing.Point(165, 34)
        Me.DtpHasta.Margin = New System.Windows.Forms.Padding(4)
        Me.DtpHasta.Name = "DtpHasta"
        Me.DtpHasta.Size = New System.Drawing.Size(145, 34)
        Me.DtpHasta.TabIndex = 27
        '
        'DtpDesde
        '
        Me.DtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtpDesde.Location = New System.Drawing.Point(13, 34)
        Me.DtpDesde.Margin = New System.Windows.Forms.Padding(4)
        Me.DtpDesde.Name = "DtpDesde"
        Me.DtpDesde.Size = New System.Drawing.Size(144, 34)
        Me.DtpDesde.TabIndex = 26
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(161, 9)
        Me.label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(57, 21)
        Me.label2.TabIndex = 25
        Me.label2.Text = "Hasta"
        '
        'label5
        '
        Me.label5.AutoSize = True
        Me.label5.Location = New System.Drawing.Point(13, 9)
        Me.label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(62, 21)
        Me.label5.TabIndex = 24
        Me.label5.Text = "Desde"
        '
        'cmdOk
        '
        Me.cmdOk.Font = New System.Drawing.Font("Lucida Sans Unicode", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdOk.Image = Global.BsAsRemitos.My.Resources.Resources.play_16
        Me.cmdOk.Location = New System.Drawing.Point(318, 34)
        Me.cmdOk.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.Size = New System.Drawing.Size(45, 35)
        Me.cmdOk.TabIndex = 23
        Me.cmdOk.UseVisualStyleBackColor = True
        '
        'InformeEncabezadoRemitos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 21.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(393, 91)
        Me.Controls.Add(Me.DtpHasta)
        Me.Controls.Add(Me.DtpDesde)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.label5)
        Me.Controls.Add(Me.cmdOk)
        Me.Font = New System.Drawing.Font("Lucida Sans Unicode", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "InformeEncabezadoRemitos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "InformeEncabezadoRemitos"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents DtpHasta As DateTimePicker
    Private WithEvents DtpDesde As DateTimePicker
    Private WithEvents label2 As Label
    Private WithEvents label5 As Label
    Friend WithEvents cmdOk As Button
End Class
