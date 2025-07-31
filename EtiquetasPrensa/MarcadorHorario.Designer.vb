<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MarcadorHorario
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.PulsaMas = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.UltimaMarca = New System.Windows.Forms.Label()
        Me.TextoDia = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.HoraEntra1 = New System.Windows.Forms.Label()
        Me.HoraSale1 = New System.Windows.Forms.Label()
        Me.HoraEntra2 = New System.Windows.Forms.Label()
        Me.HoraSale2 = New System.Windows.Forms.Label()
        Me.Horario = New System.Windows.Forms.GroupBox()
        Me.TimerVentana = New System.Windows.Forms.Timer(Me.components)
        Me.Reloj = New System.Windows.Forms.Timer(Me.components)
        Me.Hora = New System.Windows.Forms.Label()
        Me.NomOperario = New System.Windows.Forms.Label()
        Me.DataGridHoras = New System.Windows.Forms.DataGridView()
        Me.Semana = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Dia = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Marca = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.HoraIO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Retraso = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Horario.SuspendLayout()
        CType(Me.DataGridHoras, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PulsaMas
        '
        Me.PulsaMas.BackColor = System.Drawing.Color.Silver
        Me.PulsaMas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PulsaMas.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.PulsaMas.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PulsaMas.Location = New System.Drawing.Point(466, 383)
        Me.PulsaMas.Name = "PulsaMas"
        Me.PulsaMas.Size = New System.Drawing.Size(226, 70)
        Me.PulsaMas.TabIndex = 7
        Me.PulsaMas.Text = "Pulsar + para volver a marcar"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(40, 652)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(63, 20)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Label5"
        '
        'UltimaMarca
        '
        Me.UltimaMarca.AutoSize = True
        Me.UltimaMarca.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltimaMarca.Location = New System.Drawing.Point(40, 628)
        Me.UltimaMarca.Name = "UltimaMarca"
        Me.UltimaMarca.Size = New System.Drawing.Size(72, 24)
        Me.UltimaMarca.TabIndex = 5
        Me.UltimaMarca.Text = "Label5"
        '
        'TextoDia
        '
        Me.TextoDia.AutoSize = True
        Me.TextoDia.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextoDia.Location = New System.Drawing.Point(242, 9)
        Me.TextoDia.Name = "TextoDia"
        Me.TextoDia.Size = New System.Drawing.Size(450, 29)
        Me.TextoDia.TabIndex = 4
        Me.TextoDia.Text = "Miercoles 22 de Septiembtre de 2012"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 33)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(125, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Hora entrada :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(31, 57)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(110, 20)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Hora salida :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(16, 81)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(125, 20)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Hora entrada :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(31, 105)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(110, 20)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Hora salida :"
        '
        'HoraEntra1
        '
        Me.HoraEntra1.AutoSize = True
        Me.HoraEntra1.Location = New System.Drawing.Point(147, 33)
        Me.HoraEntra1.Name = "HoraEntra1"
        Me.HoraEntra1.Size = New System.Drawing.Size(79, 20)
        Me.HoraEntra1.TabIndex = 4
        Me.HoraEntra1.Text = "00:00:00"
        '
        'HoraSale1
        '
        Me.HoraSale1.AutoSize = True
        Me.HoraSale1.Location = New System.Drawing.Point(147, 57)
        Me.HoraSale1.Name = "HoraSale1"
        Me.HoraSale1.Size = New System.Drawing.Size(63, 20)
        Me.HoraSale1.TabIndex = 5
        Me.HoraSale1.Text = "Label6"
        '
        'HoraEntra2
        '
        Me.HoraEntra2.AutoSize = True
        Me.HoraEntra2.Location = New System.Drawing.Point(147, 81)
        Me.HoraEntra2.Name = "HoraEntra2"
        Me.HoraEntra2.Size = New System.Drawing.Size(63, 20)
        Me.HoraEntra2.TabIndex = 6
        Me.HoraEntra2.Text = "Label7"
        '
        'HoraSale2
        '
        Me.HoraSale2.AutoSize = True
        Me.HoraSale2.Location = New System.Drawing.Point(147, 105)
        Me.HoraSale2.Name = "HoraSale2"
        Me.HoraSale2.Size = New System.Drawing.Size(63, 20)
        Me.HoraSale2.TabIndex = 7
        Me.HoraSale2.Text = "Label8"
        '
        'Horario
        '
        Me.Horario.BackColor = System.Drawing.Color.Transparent
        Me.Horario.Controls.Add(Me.HoraSale2)
        Me.Horario.Controls.Add(Me.HoraEntra2)
        Me.Horario.Controls.Add(Me.HoraSale1)
        Me.Horario.Controls.Add(Me.HoraEntra1)
        Me.Horario.Controls.Add(Me.Label4)
        Me.Horario.Controls.Add(Me.Label3)
        Me.Horario.Controls.Add(Me.Label2)
        Me.Horario.Controls.Add(Me.Label1)
        Me.Horario.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Horario.Location = New System.Drawing.Point(445, 115)
        Me.Horario.Name = "Horario"
        Me.Horario.Size = New System.Drawing.Size(247, 141)
        Me.Horario.TabIndex = 3
        Me.Horario.TabStop = False
        Me.Horario.Text = "Horario : GrupoTM4"
        '
        'TimerVentana
        '
        Me.TimerVentana.Interval = 10000
        '
        'Reloj
        '
        Me.Reloj.Enabled = True
        Me.Reloj.Interval = 1000
        '
        'Hora
        '
        Me.Hora.AutoSize = True
        Me.Hora.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Hora.Location = New System.Drawing.Point(520, 52)
        Me.Hora.Name = "Hora"
        Me.Hora.Size = New System.Drawing.Size(172, 42)
        Me.Hora.TabIndex = 1
        Me.Hora.Text = "12:12:12"
        '
        'NomOperario
        '
        Me.NomOperario.AutoSize = True
        Me.NomOperario.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NomOperario.Location = New System.Drawing.Point(22, 60)
        Me.NomOperario.Name = "NomOperario"
        Me.NomOperario.Size = New System.Drawing.Size(254, 33)
        Me.NomOperario.TabIndex = 0
        Me.NomOperario.Text = "Pedro Fernandez"
        '
        'DataGridHoras
        '
        Me.DataGridHoras.AllowUserToAddRows = False
        Me.DataGridHoras.AllowUserToDeleteRows = False
        Me.DataGridHoras.AllowUserToResizeColumns = False
        Me.DataGridHoras.AllowUserToResizeRows = False
        Me.DataGridHoras.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridHoras.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridHoras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridHoras.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Semana, Me.Dia, Me.Marca, Me.HoraIO, Me.Retraso})
        Me.DataGridHoras.Location = New System.Drawing.Point(44, 115)
        Me.DataGridHoras.Name = "DataGridHoras"
        Me.DataGridHoras.ReadOnly = True
        Me.DataGridHoras.RowHeadersVisible = False
        Me.DataGridHoras.Size = New System.Drawing.Size(345, 491)
        Me.DataGridHoras.TabIndex = 11
        '
        'Semana
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.Semana.DefaultCellStyle = DataGridViewCellStyle2
        Me.Semana.HeaderText = "Semana"
        Me.Semana.Name = "Semana"
        Me.Semana.ReadOnly = True
        Me.Semana.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Semana.Width = 50
        '
        'Dia
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.Dia.DefaultCellStyle = DataGridViewCellStyle3
        Me.Dia.HeaderText = "Dia"
        Me.Dia.Name = "Dia"
        Me.Dia.ReadOnly = True
        Me.Dia.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Dia.Width = 40
        '
        'Marca
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.Marca.DefaultCellStyle = DataGridViewCellStyle4
        Me.Marca.HeaderText = "Marca"
        Me.Marca.Name = "Marca"
        Me.Marca.ReadOnly = True
        Me.Marca.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Marca.Width = 80
        '
        'HoraIO
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.HoraIO.DefaultCellStyle = DataGridViewCellStyle5
        Me.HoraIO.HeaderText = "HoraIO"
        Me.HoraIO.Name = "HoraIO"
        Me.HoraIO.ReadOnly = True
        Me.HoraIO.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.HoraIO.Width = 80
        '
        'Retraso
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.Retraso.DefaultCellStyle = DataGridViewCellStyle6
        Me.Retraso.HeaderText = "Retraso"
        Me.Retraso.Name = "Retraso"
        Me.Retraso.ReadOnly = True
        Me.Retraso.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Retraso.Width = 90
        '
        'MarcadorHorario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(704, 678)
        Me.ControlBox = False
        Me.Controls.Add(Me.DataGridHoras)
        Me.Controls.Add(Me.PulsaMas)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.UltimaMarca)
        Me.Controls.Add(Me.TextoDia)
        Me.Controls.Add(Me.Horario)
        Me.Controls.Add(Me.Hora)
        Me.Controls.Add(Me.NomOperario)
        Me.Name = "MarcadorHorario"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Tag = "11"
        Me.Horario.ResumeLayout(False)
        Me.Horario.PerformLayout()
        CType(Me.DataGridHoras, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PulsaMas As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents UltimaMarca As System.Windows.Forms.Label
    Friend WithEvents TextoDia As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents HoraEntra1 As System.Windows.Forms.Label
    Friend WithEvents HoraSale1 As System.Windows.Forms.Label
    Friend WithEvents HoraEntra2 As System.Windows.Forms.Label
    Friend WithEvents HoraSale2 As System.Windows.Forms.Label
    Friend WithEvents Horario As System.Windows.Forms.GroupBox
    Friend WithEvents TimerVentana As System.Windows.Forms.Timer
    Friend WithEvents Reloj As System.Windows.Forms.Timer
    Friend WithEvents Hora As System.Windows.Forms.Label
    Friend WithEvents NomOperario As System.Windows.Forms.Label
    Friend WithEvents DataGridHoras As System.Windows.Forms.DataGridView
    Friend WithEvents Semana As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Dia As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Marca As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents HoraIO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Retraso As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
