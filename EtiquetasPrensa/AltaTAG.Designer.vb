<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class AltaTAG
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
        Dim PieSeries1 As Telerik.WinControls.UI.PieSeries = New Telerik.WinControls.UI.PieSeries()
        Dim PieDataPoint1 As Telerik.Charting.PieDataPoint = New Telerik.Charting.PieDataPoint()
        Dim PieDataPoint2 As Telerik.Charting.PieDataPoint = New Telerik.Charting.PieDataPoint()
        Dim PieDataPoint3 As Telerik.Charting.PieDataPoint = New Telerik.Charting.PieDataPoint()
        Dim PieDataPoint4 As Telerik.Charting.PieDataPoint = New Telerik.Charting.PieDataPoint()
        Dim PieDataPoint5 As Telerik.Charting.PieDataPoint = New Telerik.Charting.PieDataPoint()
        Dim PieSeries2 As Telerik.WinControls.UI.PieSeries = New Telerik.WinControls.UI.PieSeries()
        Dim PieDataPoint6 As Telerik.Charting.PieDataPoint = New Telerik.Charting.PieDataPoint()
        Dim PieDataPoint7 As Telerik.Charting.PieDataPoint = New Telerik.Charting.PieDataPoint()
        Dim PieDataPoint8 As Telerik.Charting.PieDataPoint = New Telerik.Charting.PieDataPoint()
        Dim PieDataPoint9 As Telerik.Charting.PieDataPoint = New Telerik.Charting.PieDataPoint()
        Dim PieDataPoint10 As Telerik.Charting.PieDataPoint = New Telerik.Charting.PieDataPoint()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lbNNoHayPedido = New System.Windows.Forms.Label()
        Me.LabCopias = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.LabNEtiquetas = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.LabPedido = New System.Windows.Forms.Label()
        Me.PuertoLectorTAGSacoDer = New System.IO.Ports.SerialPort(Me.components)
        Me.PuertoLectorTAGSacoIzq = New System.IO.Ports.SerialPort(Me.components)
        Me.LectorTagSacoIzqTextBox = New System.Windows.Forms.TextBox()
        Me.LectorTagSacoDerTextBox = New System.Windows.Forms.TextBox()
        Me.LectorTagTecladoTextBox = New System.Windows.Forms.TextBox()
        Me.Timer3 = New System.Windows.Forms.Timer(Me.components)
        Me.tmrOnParpadeo = New System.Windows.Forms.Timer(Me.components)
        Me.TimerAjusteHora = New System.Windows.Forms.Timer(Me.components)
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.lbCajasc_u = New System.Windows.Forms.Label()
        Me.lbPalet = New System.Windows.Forms.Label()
        Me.lbCaja = New System.Windows.Forms.Label()
        Me.lbApa = New System.Windows.Forms.Label()
        Me.pbPalet = New System.Windows.Forms.PictureBox()
        Me.pbCaja = New System.Windows.Forms.PictureBox()
        Me.pbApa = New System.Windows.Forms.PictureBox()
        Me.tmrParpadeo = New System.Windows.Forms.Timer(Me.components)
        Me.Timer6 = New System.Windows.Forms.Timer(Me.components)
        Me.PuertoLectorTAGTeclado = New System.IO.Ports.SerialPort(Me.components)
        Me.EsperaIzq = New System.Windows.Forms.Label()
        Me.pnPaqueteIzq = New System.Windows.Forms.Panel()
        Me.lbControlIzq = New System.Windows.Forms.Label()
        Me.lbPaqueteIzq = New System.Windows.Forms.Label()
        Me.lbMetrosIzq = New System.Windows.Forms.Label()
        Me.lbColorIzq = New System.Windows.Forms.Label()
        Me.lbReferenciaIzq = New System.Windows.Forms.Label()
        Me.lbAgujerosIzq = New System.Windows.Forms.Label()
        Me.pnPaqueteDer = New System.Windows.Forms.Panel()
        Me.lbControlDer = New System.Windows.Forms.Label()
        Me.lbPaqueteDer = New System.Windows.Forms.Label()
        Me.lbMetrosDer = New System.Windows.Forms.Label()
        Me.lbColorDer = New System.Windows.Forms.Label()
        Me.lbReferenciaDer = New System.Windows.Forms.Label()
        Me.lbAgujerosDer = New System.Windows.Forms.Label()
        Me.EsperaDer = New System.Windows.Forms.Label()
        Me.lbAuxPedido = New System.Windows.Forms.Label()
        Me.lbRef = New System.Windows.Forms.Label()
        Me.pnEtiqIzq = New System.Windows.Forms.Panel()
        Me.pnEtiqDer = New System.Windows.Forms.Panel()
        Me.lbImpIzq = New System.Windows.Forms.Label()
        Me.lbImpDer = New System.Windows.Forms.Label()
        Me.lbErrImpIzq = New System.Windows.Forms.Label()
        Me.lbErrImpDer = New System.Windows.Forms.Label()
        Me.tmrImpIzq = New System.Windows.Forms.Timer(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.LabNombre = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.LabNCP = New System.Windows.Forms.Label()
        Me.TmrInicio = New System.Windows.Forms.Timer(Me.components)
        Me.Label7 = New System.Windows.Forms.Label()
        Me.dgSacos = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.tmrImpDer = New System.Windows.Forms.Timer(Me.components)
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Timer4 = New System.Windows.Forms.Timer(Me.components)
        Me.ImagenVideo = New System.Windows.Forms.PictureBox()
        Me.TmrCamera = New System.Windows.Forms.Timer(Me.components)
        Me.Label15 = New System.Windows.Forms.Label()
        Me.TmrCamera1 = New System.Windows.Forms.Timer(Me.components)
        Me.lblResultadoCajasStockPedido = New System.Windows.Forms.Label()
        Me.lblEnProduccion = New System.Windows.Forms.Label()
        Me.lblPosicionesFabricacion = New System.Windows.Forms.Label()
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.pnlSacos = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblPosicion = New System.Windows.Forms.Label()
        Me.lblNombrePesa = New System.Windows.Forms.Label()
        Me.lblDiaPesa = New System.Windows.Forms.Label()
        Me.lblAgujeros = New System.Windows.Forms.Label()
        Me.lblPeso = New System.Windows.Forms.Label()
        Me.lblTira = New System.Windows.Forms.Label()
        Me.lblTotalSacos = New System.Windows.Forms.Label()
        Me.RadChartView2 = New Telerik.WinControls.UI.RadChartView()
        Me.RadChartView1 = New Telerik.WinControls.UI.RadChartView()
        Me.TimerActualizaTrazabilidad = New System.Windows.Forms.Timer(Me.components)
        Me.lblErrorPedido = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.pbPalet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbCaja, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbApa, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnPaqueteIzq.SuspendLayout()
        Me.pnPaqueteDer.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgSacos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ImagenVideo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlSacos.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.RadChartView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadChartView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'Timer2
        '
        Me.Timer2.Interval = 1000
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lbNNoHayPedido)
        Me.GroupBox1.Controls.Add(Me.LabCopias)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.LabNEtiquetas)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.LabPedido)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(7, 232)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(335, 214)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Pedido"
        '
        'lbNNoHayPedido
        '
        Me.lbNNoHayPedido.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lbNNoHayPedido.Font = New System.Drawing.Font("Microsoft Sans Serif", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbNNoHayPedido.ForeColor = System.Drawing.Color.White
        Me.lbNNoHayPedido.Location = New System.Drawing.Point(4, 130)
        Me.lbNNoHayPedido.Name = "lbNNoHayPedido"
        Me.lbNNoHayPedido.Size = New System.Drawing.Size(327, 78)
        Me.lbNNoHayPedido.TabIndex = 182
        Me.lbNNoHayPedido.Text = "Nº pedido?"
        Me.lbNNoHayPedido.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LabCopias
        '
        Me.LabCopias.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabCopias.Location = New System.Drawing.Point(261, 80)
        Me.LabCopias.Name = "LabCopias"
        Me.LabCopias.Size = New System.Drawing.Size(47, 31)
        Me.LabCopias.TabIndex = 10
        Me.LabCopias.Text = "0"
        Me.LabCopias.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(6, 80)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(204, 31)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "/ Nº Etiquetas:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LabNEtiquetas
        '
        Me.LabNEtiquetas.BackColor = System.Drawing.Color.White
        Me.LabNEtiquetas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LabNEtiquetas.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.LabNEtiquetas.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabNEtiquetas.Location = New System.Drawing.Point(209, 79)
        Me.LabNEtiquetas.Name = "LabNEtiquetas"
        Me.LabNEtiquetas.Size = New System.Drawing.Size(48, 32)
        Me.LabNEtiquetas.TabIndex = 8
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(5, 37)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(113, 31)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Pedido:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LabPedido
        '
        Me.LabPedido.BackColor = System.Drawing.Color.White
        Me.LabPedido.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LabPedido.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.LabPedido.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabPedido.Location = New System.Drawing.Point(119, 36)
        Me.LabPedido.Name = "LabPedido"
        Me.LabPedido.Size = New System.Drawing.Size(148, 32)
        Me.LabPedido.TabIndex = 0
        '
        'PuertoLectorTAGSacoDer
        '
        '
        'PuertoLectorTAGSacoIzq
        '
        '
        'LectorTagSacoIzqTextBox
        '
        Me.LectorTagSacoIzqTextBox.Location = New System.Drawing.Point(569, 242)
        Me.LectorTagSacoIzqTextBox.Name = "LectorTagSacoIzqTextBox"
        Me.LectorTagSacoIzqTextBox.Size = New System.Drawing.Size(34, 20)
        Me.LectorTagSacoIzqTextBox.TabIndex = 11
        Me.LectorTagSacoIzqTextBox.Visible = False
        '
        'LectorTagSacoDerTextBox
        '
        Me.LectorTagSacoDerTextBox.Location = New System.Drawing.Point(533, 242)
        Me.LectorTagSacoDerTextBox.Name = "LectorTagSacoDerTextBox"
        Me.LectorTagSacoDerTextBox.Size = New System.Drawing.Size(30, 20)
        Me.LectorTagSacoDerTextBox.TabIndex = 10
        Me.LectorTagSacoDerTextBox.Visible = False
        '
        'LectorTagTecladoTextBox
        '
        Me.LectorTagTecladoTextBox.Location = New System.Drawing.Point(497, 242)
        Me.LectorTagTecladoTextBox.Name = "LectorTagTecladoTextBox"
        Me.LectorTagTecladoTextBox.Size = New System.Drawing.Size(30, 20)
        Me.LectorTagTecladoTextBox.TabIndex = 9
        Me.LectorTagTecladoTextBox.Visible = False
        '
        'Timer3
        '
        Me.Timer3.Interval = 5000
        '
        'tmrOnParpadeo
        '
        Me.tmrOnParpadeo.Interval = 3000
        '
        'TimerAjusteHora
        '
        Me.TimerAjusteHora.Enabled = True
        Me.TimerAjusteHora.Interval = 86400000
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.lbCajasc_u)
        Me.GroupBox4.Controls.Add(Me.lbPalet)
        Me.GroupBox4.Controls.Add(Me.lbCaja)
        Me.GroupBox4.Controls.Add(Me.lbApa)
        Me.GroupBox4.Controls.Add(Me.pbPalet)
        Me.GroupBox4.Controls.Add(Me.pbCaja)
        Me.GroupBox4.Controls.Add(Me.pbApa)
        Me.GroupBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.Location = New System.Drawing.Point(685, 11)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(587, 362)
        Me.GroupBox4.TabIndex = 23
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Packaging"
        '
        'lbCajasc_u
        '
        Me.lbCajasc_u.BackColor = System.Drawing.Color.Red
        Me.lbCajasc_u.Font = New System.Drawing.Font("Microsoft Sans Serif", 33.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbCajasc_u.ForeColor = System.Drawing.Color.White
        Me.lbCajasc_u.Location = New System.Drawing.Point(324, 306)
        Me.lbCajasc_u.Name = "lbCajasc_u"
        Me.lbCajasc_u.Size = New System.Drawing.Size(257, 55)
        Me.lbCajasc_u.TabIndex = 178
        Me.lbCajasc_u.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbPalet
        '
        Me.lbPalet.AutoSize = True
        Me.lbPalet.BackColor = System.Drawing.Color.White
        Me.lbPalet.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbPalet.Location = New System.Drawing.Point(384, 33)
        Me.lbPalet.MaximumSize = New System.Drawing.Size(212, 0)
        Me.lbPalet.Name = "lbPalet"
        Me.lbPalet.Size = New System.Drawing.Size(51, 24)
        Me.lbPalet.TabIndex = 174
        Me.lbPalet.Text = "Palet"
        '
        'lbCaja
        '
        Me.lbCaja.AutoSize = True
        Me.lbCaja.BackColor = System.Drawing.Color.White
        Me.lbCaja.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbCaja.Location = New System.Drawing.Point(201, 34)
        Me.lbCaja.MaximumSize = New System.Drawing.Size(212, 0)
        Me.lbCaja.Name = "lbCaja"
        Me.lbCaja.Size = New System.Drawing.Size(73, 24)
        Me.lbCaja.TabIndex = 173
        Me.lbCaja.Text = "Envase"
        '
        'lbApa
        '
        Me.lbApa.AutoSize = True
        Me.lbApa.BackColor = System.Drawing.Color.White
        Me.lbApa.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbApa.Location = New System.Drawing.Point(5, 33)
        Me.lbApa.Name = "lbApa"
        Me.lbApa.Size = New System.Drawing.Size(124, 24)
        Me.lbApa.TabIndex = 172
        Me.lbApa.Text = "Abrir por aqui"
        '
        'pbPalet
        '
        Me.pbPalet.Location = New System.Drawing.Point(391, 110)
        Me.pbPalet.Name = "pbPalet"
        Me.pbPalet.Size = New System.Drawing.Size(192, 192)
        Me.pbPalet.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbPalet.TabIndex = 171
        Me.pbPalet.TabStop = False
        '
        'pbCaja
        '
        Me.pbCaja.Location = New System.Drawing.Point(197, 110)
        Me.pbCaja.Name = "pbCaja"
        Me.pbCaja.Size = New System.Drawing.Size(192, 192)
        Me.pbCaja.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbCaja.TabIndex = 170
        Me.pbCaja.TabStop = False
        '
        'pbApa
        '
        Me.pbApa.Location = New System.Drawing.Point(3, 110)
        Me.pbApa.Name = "pbApa"
        Me.pbApa.Size = New System.Drawing.Size(192, 192)
        Me.pbApa.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbApa.TabIndex = 169
        Me.pbApa.TabStop = False
        '
        'tmrParpadeo
        '
        Me.tmrParpadeo.Interval = 250
        '
        'Timer6
        '
        Me.Timer6.Interval = 2000
        '
        'EsperaIzq
        '
        Me.EsperaIzq.AutoSize = True
        Me.EsperaIzq.BackColor = System.Drawing.Color.Orange
        Me.EsperaIzq.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EsperaIzq.Location = New System.Drawing.Point(368, 504)
        Me.EsperaIzq.Name = "EsperaIzq"
        Me.EsperaIzq.Size = New System.Drawing.Size(217, 25)
        Me.EsperaIzq.TabIndex = 27
        Me.EsperaIzq.Text = "Tarjeta leida. Espere!"
        Me.EsperaIzq.Visible = False
        '
        'pnPaqueteIzq
        '
        Me.pnPaqueteIzq.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnPaqueteIzq.Controls.Add(Me.lbControlIzq)
        Me.pnPaqueteIzq.Controls.Add(Me.lbPaqueteIzq)
        Me.pnPaqueteIzq.Controls.Add(Me.lbMetrosIzq)
        Me.pnPaqueteIzq.Controls.Add(Me.lbColorIzq)
        Me.pnPaqueteIzq.Controls.Add(Me.lbReferenciaIzq)
        Me.pnPaqueteIzq.Controls.Add(Me.lbAgujerosIzq)
        Me.pnPaqueteIzq.Location = New System.Drawing.Point(349, 532)
        Me.pnPaqueteIzq.Name = "pnPaqueteIzq"
        Me.pnPaqueteIzq.Size = New System.Drawing.Size(255, 374)
        Me.pnPaqueteIzq.TabIndex = 178
        '
        'lbControlIzq
        '
        Me.lbControlIzq.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbControlIzq.Location = New System.Drawing.Point(9, 232)
        Me.lbControlIzq.Name = "lbControlIzq"
        Me.lbControlIzq.Size = New System.Drawing.Size(236, 42)
        Me.lbControlIzq.TabIndex = 5
        Me.lbControlIzq.Text = "BDF55-56/5"
        Me.lbControlIzq.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbPaqueteIzq
        '
        Me.lbPaqueteIzq.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbPaqueteIzq.Location = New System.Drawing.Point(8, 190)
        Me.lbPaqueteIzq.Name = "lbPaqueteIzq"
        Me.lbPaqueteIzq.Size = New System.Drawing.Size(236, 42)
        Me.lbPaqueteIzq.TabIndex = 4
        Me.lbPaqueteIzq.Text = "BDF55-56/5"
        Me.lbPaqueteIzq.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbMetrosIzq
        '
        Me.lbMetrosIzq.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbMetrosIzq.Location = New System.Drawing.Point(8, 148)
        Me.lbMetrosIzq.Name = "lbMetrosIzq"
        Me.lbMetrosIzq.Size = New System.Drawing.Size(236, 42)
        Me.lbMetrosIzq.TabIndex = 3
        Me.lbMetrosIzq.Text = "BDF55-56/5"
        Me.lbMetrosIzq.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbColorIzq
        '
        Me.lbColorIzq.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbColorIzq.Location = New System.Drawing.Point(8, 106)
        Me.lbColorIzq.Name = "lbColorIzq"
        Me.lbColorIzq.Size = New System.Drawing.Size(236, 42)
        Me.lbColorIzq.TabIndex = 2
        Me.lbColorIzq.Text = "BDF55-56/5"
        Me.lbColorIzq.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbReferenciaIzq
        '
        Me.lbReferenciaIzq.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbReferenciaIzq.Location = New System.Drawing.Point(8, 64)
        Me.lbReferenciaIzq.Name = "lbReferenciaIzq"
        Me.lbReferenciaIzq.Size = New System.Drawing.Size(236, 42)
        Me.lbReferenciaIzq.TabIndex = 1
        Me.lbReferenciaIzq.Text = "BDF55-56/5"
        Me.lbReferenciaIzq.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbAgujerosIzq
        '
        Me.lbAgujerosIzq.BackColor = System.Drawing.Color.Red
        Me.lbAgujerosIzq.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbAgujerosIzq.Location = New System.Drawing.Point(7, 275)
        Me.lbAgujerosIzq.Name = "lbAgujerosIzq"
        Me.lbAgujerosIzq.Size = New System.Drawing.Size(240, 41)
        Me.lbAgujerosIzq.TabIndex = 0
        Me.lbAgujerosIzq.Text = "Agujeros : 0"
        Me.lbAgujerosIzq.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnPaqueteDer
        '
        Me.pnPaqueteDer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnPaqueteDer.Controls.Add(Me.lbControlDer)
        Me.pnPaqueteDer.Controls.Add(Me.lbPaqueteDer)
        Me.pnPaqueteDer.Controls.Add(Me.lbMetrosDer)
        Me.pnPaqueteDer.Controls.Add(Me.lbColorDer)
        Me.pnPaqueteDer.Controls.Add(Me.lbReferenciaDer)
        Me.pnPaqueteDer.Controls.Add(Me.lbAgujerosDer)
        Me.pnPaqueteDer.Location = New System.Drawing.Point(1009, 532)
        Me.pnPaqueteDer.Name = "pnPaqueteDer"
        Me.pnPaqueteDer.Size = New System.Drawing.Size(255, 363)
        Me.pnPaqueteDer.TabIndex = 179
        '
        'lbControlDer
        '
        Me.lbControlDer.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbControlDer.Location = New System.Drawing.Point(9, 232)
        Me.lbControlDer.Name = "lbControlDer"
        Me.lbControlDer.Size = New System.Drawing.Size(236, 42)
        Me.lbControlDer.TabIndex = 11
        Me.lbControlDer.Text = "BDF55-56/5"
        Me.lbControlDer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbPaqueteDer
        '
        Me.lbPaqueteDer.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbPaqueteDer.Location = New System.Drawing.Point(8, 190)
        Me.lbPaqueteDer.Name = "lbPaqueteDer"
        Me.lbPaqueteDer.Size = New System.Drawing.Size(236, 42)
        Me.lbPaqueteDer.TabIndex = 10
        Me.lbPaqueteDer.Text = "BDF55-56/5"
        Me.lbPaqueteDer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbMetrosDer
        '
        Me.lbMetrosDer.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbMetrosDer.Location = New System.Drawing.Point(8, 148)
        Me.lbMetrosDer.Name = "lbMetrosDer"
        Me.lbMetrosDer.Size = New System.Drawing.Size(236, 42)
        Me.lbMetrosDer.TabIndex = 9
        Me.lbMetrosDer.Text = "BDF55-56/5"
        Me.lbMetrosDer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbColorDer
        '
        Me.lbColorDer.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbColorDer.Location = New System.Drawing.Point(8, 106)
        Me.lbColorDer.Name = "lbColorDer"
        Me.lbColorDer.Size = New System.Drawing.Size(236, 42)
        Me.lbColorDer.TabIndex = 8
        Me.lbColorDer.Text = "BDF55-56/5"
        Me.lbColorDer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbReferenciaDer
        '
        Me.lbReferenciaDer.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbReferenciaDer.Location = New System.Drawing.Point(8, 64)
        Me.lbReferenciaDer.Name = "lbReferenciaDer"
        Me.lbReferenciaDer.Size = New System.Drawing.Size(236, 42)
        Me.lbReferenciaDer.TabIndex = 7
        Me.lbReferenciaDer.Text = "BDF55-56/5"
        Me.lbReferenciaDer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbAgujerosDer
        '
        Me.lbAgujerosDer.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.lbAgujerosDer.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbAgujerosDer.Location = New System.Drawing.Point(7, 275)
        Me.lbAgujerosDer.Name = "lbAgujerosDer"
        Me.lbAgujerosDer.Size = New System.Drawing.Size(240, 41)
        Me.lbAgujerosDer.TabIndex = 6
        Me.lbAgujerosDer.Text = "Agujeros : 0"
        Me.lbAgujerosDer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'EsperaDer
        '
        Me.EsperaDer.AutoSize = True
        Me.EsperaDer.BackColor = System.Drawing.Color.Orange
        Me.EsperaDer.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EsperaDer.Location = New System.Drawing.Point(1031, 504)
        Me.EsperaDer.Name = "EsperaDer"
        Me.EsperaDer.Size = New System.Drawing.Size(217, 25)
        Me.EsperaDer.TabIndex = 180
        Me.EsperaDer.Text = "Tarjeta leida. Espere!"
        Me.EsperaDer.Visible = False
        '
        'lbAuxPedido
        '
        Me.lbAuxPedido.AutoSize = True
        Me.lbAuxPedido.Location = New System.Drawing.Point(905, 940)
        Me.lbAuxPedido.Name = "lbAuxPedido"
        Me.lbAuxPedido.Size = New System.Drawing.Size(54, 13)
        Me.lbAuxPedido.TabIndex = 182
        Me.lbAuxPedido.Text = "Nº pedido"
        Me.lbAuxPedido.Visible = False
        '
        'lbRef
        '
        Me.lbRef.AutoSize = True
        Me.lbRef.Location = New System.Drawing.Point(905, 953)
        Me.lbRef.Name = "lbRef"
        Me.lbRef.Size = New System.Drawing.Size(59, 13)
        Me.lbRef.TabIndex = 183
        Me.lbRef.Text = "Referencia"
        Me.lbRef.Visible = False
        '
        'pnEtiqIzq
        '
        Me.pnEtiqIzq.Location = New System.Drawing.Point(368, 555)
        Me.pnEtiqIzq.Name = "pnEtiqIzq"
        Me.pnEtiqIzq.Size = New System.Drawing.Size(232, 332)
        Me.pnEtiqIzq.TabIndex = 186
        '
        'pnEtiqDer
        '
        Me.pnEtiqDer.Location = New System.Drawing.Point(1032, 528)
        Me.pnEtiqDer.Name = "pnEtiqDer"
        Me.pnEtiqDer.Size = New System.Drawing.Size(232, 332)
        Me.pnEtiqDer.TabIndex = 187
        '
        'lbImpIzq
        '
        Me.lbImpIzq.BackColor = System.Drawing.Color.Orange
        Me.lbImpIzq.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbImpIzq.Location = New System.Drawing.Point(354, 471)
        Me.lbImpIzq.Name = "lbImpIzq"
        Me.lbImpIzq.Size = New System.Drawing.Size(240, 33)
        Me.lbImpIzq.TabIndex = 188
        Me.lbImpIzq.Text = "No imprimir"
        Me.lbImpIzq.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbImpDer
        '
        Me.lbImpDer.BackColor = System.Drawing.Color.Orange
        Me.lbImpDer.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbImpDer.Location = New System.Drawing.Point(1020, 471)
        Me.lbImpDer.Name = "lbImpDer"
        Me.lbImpDer.Size = New System.Drawing.Size(240, 33)
        Me.lbImpDer.TabIndex = 189
        Me.lbImpDer.Text = "No imprimir"
        Me.lbImpDer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbErrImpIzq
        '
        Me.lbErrImpIzq.BackColor = System.Drawing.Color.Red
        Me.lbErrImpIzq.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbErrImpIzq.Location = New System.Drawing.Point(354, 438)
        Me.lbErrImpIzq.Name = "lbErrImpIzq"
        Me.lbErrImpIzq.Size = New System.Drawing.Size(240, 33)
        Me.lbErrImpIzq.TabIndex = 190
        Me.lbErrImpIzq.Text = "Error impresora"
        Me.lbErrImpIzq.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lbErrImpIzq.Visible = False
        '
        'lbErrImpDer
        '
        Me.lbErrImpDer.BackColor = System.Drawing.Color.Red
        Me.lbErrImpDer.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbErrImpDer.Location = New System.Drawing.Point(1020, 438)
        Me.lbErrImpDer.Name = "lbErrImpDer"
        Me.lbErrImpDer.Size = New System.Drawing.Size(240, 33)
        Me.lbErrImpDer.TabIndex = 191
        Me.lbErrImpDer.Text = "Error impresora"
        Me.lbErrImpDer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lbErrImpDer.Visible = False
        '
        'tmrImpIzq
        '
        Me.tmrImpIzq.Interval = 600
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(747, 953)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 13)
        Me.Label1.TabIndex = 192
        Me.Label1.Text = "Label1"
        Me.Label1.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(691, 953)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(50, 13)
        Me.Label3.TabIndex = 193
        Me.Label3.Text = "KeyCode"
        Me.Label3.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(694, 979)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(78, 13)
        Me.Label5.TabIndex = 194
        Me.Label5.Text = "PosEntraDatos"
        Me.Label5.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(778, 981)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(39, 13)
        Me.Label6.TabIndex = 195
        Me.Label6.Text = "Label6"
        Me.Label6.Visible = False
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.PaleGreen
        Me.GroupBox2.Controls.Add(Me.LabNombre)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.LabNCP)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(7, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(335, 214)
        Me.GroupBox2.TabIndex = 196
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Operario"
        '
        'LabNombre
        '
        Me.LabNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabNombre.Location = New System.Drawing.Point(7, 123)
        Me.LabNombre.Name = "LabNombre"
        Me.LabNombre.Size = New System.Drawing.Size(321, 31)
        Me.LabNombre.TabIndex = 10
        Me.LabNombre.Text = "-"
        Me.LabNombre.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(6, 80)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(125, 31)
        Me.Label9.TabIndex = 9
        Me.Label9.Text = "Nombre:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(35, 37)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(84, 31)
        Me.Label11.TabIndex = 1
        Me.Label11.Text = "NCP:"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LabNCP
        '
        Me.LabNCP.BackColor = System.Drawing.Color.White
        Me.LabNCP.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LabNCP.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.LabNCP.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabNCP.Location = New System.Drawing.Point(119, 36)
        Me.LabNCP.Name = "LabNCP"
        Me.LabNCP.Size = New System.Drawing.Size(66, 32)
        Me.LabNCP.TabIndex = 0
        '
        'TmrInicio
        '
        Me.TmrInicio.Interval = 600
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(910, 979)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(39, 13)
        Me.Label7.TabIndex = 197
        Me.Label7.Text = "Label7"
        Me.Label7.Visible = False
        '
        'dgSacos
        '
        Me.dgSacos.AllowUserToAddRows = False
        Me.dgSacos.AllowUserToDeleteRows = False
        Me.dgSacos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgSacos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2})
        Me.dgSacos.Enabled = False
        Me.dgSacos.Location = New System.Drawing.Point(7, 478)
        Me.dgSacos.Name = "dgSacos"
        Me.dgSacos.ReadOnly = True
        Me.dgSacos.RowHeadersWidth = 10
        Me.dgSacos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgSacos.Size = New System.Drawing.Size(335, 428)
        Me.dgSacos.TabIndex = 198
        '
        'Column1
        '
        Me.Column1.HeaderText = "Saco"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 200
        '
        'Column2
        '
        Me.Column2.HeaderText = "Aguj"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 50
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(11, 450)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(274, 24)
        Me.Label8.TabIndex = 199
        Me.Label8.Text = "Sacos sin TAG y sin prensar"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(691, 933)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(39, 13)
        Me.Label10.TabIndex = 200
        Me.Label10.Text = "KeyUp"
        Me.Label10.Visible = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(747, 933)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(45, 13)
        Me.Label12.TabIndex = 201
        Me.Label12.Text = "Label12"
        Me.Label12.Visible = False
        '
        'tmrImpDer
        '
        Me.tmrImpDer.Interval = 600
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(12, 909)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(55, 16)
        Me.Label13.TabIndex = 202
        Me.Label13.Text = "Label13"
        Me.Label13.Visible = False
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(12, 938)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(55, 16)
        Me.Label14.TabIndex = 203
        Me.Label14.Text = "Label14"
        Me.Label14.Visible = False
        '
        'Timer4
        '
        Me.Timer4.Interval = 5000
        '
        'ImagenVideo
        '
        Me.ImagenVideo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ImagenVideo.Location = New System.Drawing.Point(385, 383)
        Me.ImagenVideo.Name = "ImagenVideo"
        Me.ImagenVideo.Size = New System.Drawing.Size(200, 49)
        Me.ImagenVideo.TabIndex = 204
        Me.ImagenVideo.TabStop = False
        Me.ImagenVideo.Visible = False
        '
        'TmrCamera
        '
        Me.TmrCamera.Enabled = True
        Me.TmrCamera.Interval = 50
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(0, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(45, 13)
        Me.Label15.TabIndex = 205
        Me.Label15.Text = "Label15"
        '
        'TmrCamera1
        '
        Me.TmrCamera1.Interval = 2000
        '
        'lblResultadoCajasStockPedido
        '
        Me.lblResultadoCajasStockPedido.AutoSize = True
        Me.lblResultadoCajasStockPedido.BackColor = System.Drawing.Color.Red
        Me.lblResultadoCajasStockPedido.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblResultadoCajasStockPedido.ForeColor = System.Drawing.Color.White
        Me.lblResultadoCajasStockPedido.Location = New System.Drawing.Point(12, 925)
        Me.lblResultadoCajasStockPedido.Name = "lblResultadoCajasStockPedido"
        Me.lblResultadoCajasStockPedido.Size = New System.Drawing.Size(14, 18)
        Me.lblResultadoCajasStockPedido.TabIndex = 207
        Me.lblResultadoCajasStockPedido.Text = "-"
        '
        'lblEnProduccion
        '
        Me.lblEnProduccion.BackColor = System.Drawing.Color.Yellow
        Me.lblEnProduccion.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEnProduccion.ForeColor = System.Drawing.Color.Black
        Me.lblEnProduccion.Location = New System.Drawing.Point(350, 229)
        Me.lblEnProduccion.Name = "lblEnProduccion"
        Me.lblEnProduccion.Size = New System.Drawing.Size(331, 42)
        Me.lblEnProduccion.TabIndex = 211
        Me.lblEnProduccion.Text = "En produccion"
        Me.lblEnProduccion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblEnProduccion.Visible = False
        '
        'lblPosicionesFabricacion
        '
        Me.lblPosicionesFabricacion.BackColor = System.Drawing.Color.Yellow
        Me.lblPosicionesFabricacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPosicionesFabricacion.ForeColor = System.Drawing.Color.Black
        Me.lblPosicionesFabricacion.Location = New System.Drawing.Point(350, 272)
        Me.lblPosicionesFabricacion.Name = "lblPosicionesFabricacion"
        Me.lblPosicionesFabricacion.Size = New System.Drawing.Size(331, 42)
        Me.lblPosicionesFabricacion.TabIndex = 210
        Me.lblPosicionesFabricacion.Text = "Fabricado en: "
        Me.lblPosicionesFabricacion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblPosicionesFabricacion.Visible = False
        '
        'PrintDocument1
        '
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Location = New System.Drawing.Point(612, 375)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(386, 531)
        Me.Panel1.TabIndex = 212
        '
        'pnlSacos
        '
        Me.pnlSacos.BackColor = System.Drawing.Color.White
        Me.pnlSacos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlSacos.Controls.Add(Me.Panel2)
        Me.pnlSacos.Controls.Add(Me.lblTotalSacos)
        Me.pnlSacos.Controls.Add(Me.RadChartView2)
        Me.pnlSacos.Controls.Add(Me.RadChartView1)
        Me.pnlSacos.Location = New System.Drawing.Point(1278, 23)
        Me.pnlSacos.Name = "pnlSacos"
        Me.pnlSacos.Size = New System.Drawing.Size(609, 883)
        Me.pnlSacos.TabIndex = 214
        Me.pnlSacos.Visible = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.lblPosicion)
        Me.Panel2.Controls.Add(Me.lblNombrePesa)
        Me.Panel2.Controls.Add(Me.lblDiaPesa)
        Me.Panel2.Controls.Add(Me.lblAgujeros)
        Me.Panel2.Controls.Add(Me.lblPeso)
        Me.Panel2.Controls.Add(Me.lblTira)
        Me.Panel2.Location = New System.Drawing.Point(3, 4)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(601, 139)
        Me.Panel2.TabIndex = 5
        '
        'lblPosicion
        '
        Me.lblPosicion.AutoSize = True
        Me.lblPosicion.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPosicion.Location = New System.Drawing.Point(475, 32)
        Me.lblPosicion.Name = "lblPosicion"
        Me.lblPosicion.Size = New System.Drawing.Size(75, 21)
        Me.lblPosicion.TabIndex = 5
        Me.lblPosicion.Text = "Posición"
        '
        'lblNombrePesa
        '
        Me.lblNombrePesa.AutoSize = True
        Me.lblNombrePesa.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombrePesa.Location = New System.Drawing.Point(19, 78)
        Me.lblNombrePesa.Name = "lblNombrePesa"
        Me.lblNombrePesa.Size = New System.Drawing.Size(113, 21)
        Me.lblNombrePesa.TabIndex = 4
        Me.lblNombrePesa.Text = "Nombre Peso"
        '
        'lblDiaPesa
        '
        Me.lblDiaPesa.AutoSize = True
        Me.lblDiaPesa.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDiaPesa.Location = New System.Drawing.Point(19, 32)
        Me.lblDiaPesa.Name = "lblDiaPesa"
        Me.lblDiaPesa.Size = New System.Drawing.Size(76, 21)
        Me.lblDiaPesa.TabIndex = 3
        Me.lblDiaPesa.Text = "Día Peso"
        '
        'lblAgujeros
        '
        Me.lblAgujeros.AutoSize = True
        Me.lblAgujeros.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAgujeros.Location = New System.Drawing.Point(475, 78)
        Me.lblAgujeros.Name = "lblAgujeros"
        Me.lblAgujeros.Size = New System.Drawing.Size(78, 21)
        Me.lblAgujeros.TabIndex = 2
        Me.lblAgujeros.Text = "Agujeros"
        '
        'lblPeso
        '
        Me.lblPeso.AutoSize = True
        Me.lblPeso.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPeso.Location = New System.Drawing.Point(309, 32)
        Me.lblPeso.Name = "lblPeso"
        Me.lblPeso.Size = New System.Drawing.Size(46, 21)
        Me.lblPeso.TabIndex = 1
        Me.lblPeso.Text = "Peso"
        '
        'lblTira
        '
        Me.lblTira.AutoSize = True
        Me.lblTira.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTira.Location = New System.Drawing.Point(309, 78)
        Me.lblTira.Name = "lblTira"
        Me.lblTira.Size = New System.Drawing.Size(39, 21)
        Me.lblTira.TabIndex = 0
        Me.lblTira.Text = "Tira"
        '
        'lblTotalSacos
        '
        Me.lblTotalSacos.BackColor = System.Drawing.Color.White
        Me.lblTotalSacos.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalSacos.Location = New System.Drawing.Point(13, 141)
        Me.lblTotalSacos.Name = "lblTotalSacos"
        Me.lblTotalSacos.Size = New System.Drawing.Size(581, 40)
        Me.lblTotalSacos.TabIndex = 3
        Me.lblTotalSacos.Text = "Total sacos"
        Me.lblTotalSacos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'RadChartView2
        '
        Me.RadChartView2.AreaType = Telerik.WinControls.UI.ChartAreaType.Pie
        Me.RadChartView2.Location = New System.Drawing.Point(84, 530)
        Me.RadChartView2.Name = "RadChartView2"
        PieSeries1.BackColor = System.Drawing.Color.FromArgb(CType(CType(104, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(230, Byte), Integer))
        PieSeries1.BorderColor = System.Drawing.Color.FromArgb(CType(CType(104, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(230, Byte), Integer))
        PieDataPoint1.Label = 0.26031746031746034R
        PieDataPoint1.LegendTitle = "0,26031746031746"
        PieDataPoint1.OffsetFromCenter = 0R
        PieDataPoint1.RadiusAspectRatio = 1.0!
        PieDataPoint1.Value = 82.0R
        PieDataPoint2.Label = 0.14285714285714285R
        PieDataPoint2.LegendTitle = "0,142857142857143"
        PieDataPoint2.OffsetFromCenter = 0R
        PieDataPoint2.RadiusAspectRatio = 1.0!
        PieDataPoint2.Value = 45.0R
        PieDataPoint3.Label = 0.12063492063492064R
        PieDataPoint3.LegendTitle = "0,120634920634921"
        PieDataPoint3.OffsetFromCenter = 0R
        PieDataPoint3.RadiusAspectRatio = 1.0!
        PieDataPoint3.Value = 38.0R
        PieDataPoint4.Label = 0.1873015873015873R
        PieDataPoint4.LegendTitle = "0,187301587301587"
        PieDataPoint4.OffsetFromCenter = 0R
        PieDataPoint4.RadiusAspectRatio = 1.0!
        PieDataPoint4.Value = 59.0R
        PieDataPoint5.Label = 0.28888888888888886R
        PieDataPoint5.LegendTitle = "0,288888888888889"
        PieDataPoint5.OffsetFromCenter = 0R
        PieDataPoint5.RadiusAspectRatio = 1.0!
        PieDataPoint5.Value = 91.0R
        PieSeries1.DataPoints.AddRange(New Telerik.Charting.DataPoint() {PieDataPoint1, PieDataPoint2, PieDataPoint3, PieDataPoint4, PieDataPoint5})
        Me.RadChartView2.Series.AddRange(New Telerik.WinControls.UI.ChartSeries() {PieSeries1})
        Me.RadChartView2.ShowGrid = False
        Me.RadChartView2.Size = New System.Drawing.Size(454, 341)
        Me.RadChartView2.TabIndex = 1
        '
        'RadChartView1
        '
        Me.RadChartView1.AreaType = Telerik.WinControls.UI.ChartAreaType.Pie
        Me.RadChartView1.Location = New System.Drawing.Point(84, 185)
        Me.RadChartView1.Name = "RadChartView1"
        PieSeries2.BackColor = System.Drawing.Color.FromArgb(CType(CType(63, Byte), Integer), CType(CType(81, Byte), Integer), CType(CType(181, Byte), Integer))
        PieSeries2.BorderColor = System.Drawing.Color.FromArgb(CType(CType(63, Byte), Integer), CType(CType(81, Byte), Integer), CType(CType(181, Byte), Integer))
        PieDataPoint6.Label = 0.35319148936170214R
        PieDataPoint6.LegendTitle = "0,353191489361702"
        PieDataPoint6.OffsetFromCenter = 0R
        PieDataPoint6.RadiusAspectRatio = 1.0!
        PieDataPoint6.Value = 83.0R
        PieDataPoint7.Label = 0.08085106382978724R
        PieDataPoint7.LegendTitle = "0,0808510638297872"
        PieDataPoint7.OffsetFromCenter = 0R
        PieDataPoint7.RadiusAspectRatio = 1.0!
        PieDataPoint7.Value = 19.0R
        PieDataPoint8.Label = 0.39148936170212767R
        PieDataPoint8.LegendTitle = "0,391489361702128"
        PieDataPoint8.OffsetFromCenter = 0R
        PieDataPoint8.RadiusAspectRatio = 1.0!
        PieDataPoint8.Value = 92.0R
        PieDataPoint9.Label = 0.11914893617021277R
        PieDataPoint9.LegendTitle = "0,119148936170213"
        PieDataPoint9.OffsetFromCenter = 0R
        PieDataPoint9.RadiusAspectRatio = 1.0!
        PieDataPoint9.Value = 28.0R
        PieDataPoint10.Label = 0.055319148936170209R
        PieDataPoint10.LegendTitle = "0,0553191489361702"
        PieDataPoint10.OffsetFromCenter = 0R
        PieDataPoint10.RadiusAspectRatio = 1.0!
        PieDataPoint10.Value = 13.0R
        PieSeries2.DataPoints.AddRange(New Telerik.Charting.DataPoint() {PieDataPoint6, PieDataPoint7, PieDataPoint8, PieDataPoint9, PieDataPoint10})
        Me.RadChartView1.Series.AddRange(New Telerik.WinControls.UI.ChartSeries() {PieSeries2})
        Me.RadChartView1.ShowGrid = False
        Me.RadChartView1.ShowPanZoom = True
        Me.RadChartView1.ShowToolTip = True
        Me.RadChartView1.ShowTrackBall = True
        Me.RadChartView1.Size = New System.Drawing.Size(454, 341)
        Me.RadChartView1.TabIndex = 0
        '
        'TimerActualizaTrazabilidad
        '
        Me.TimerActualizaTrazabilidad.Interval = 60000
        '
        'lblErrorPedido
        '
        Me.lblErrorPedido.BackColor = System.Drawing.Color.Red
        Me.lblErrorPedido.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblErrorPedido.Font = New System.Drawing.Font("Microsoft Sans Serif", 48.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblErrorPedido.ForeColor = System.Drawing.Color.White
        Me.lblErrorPedido.Location = New System.Drawing.Point(163, 121)
        Me.lblErrorPedido.Name = "lblErrorPedido"
        Me.lblErrorPedido.Size = New System.Drawing.Size(1436, 687)
        Me.lblErrorPedido.TabIndex = 216
        Me.lblErrorPedido.Text = "ERROR ARTICULO DIFERENTE"
        Me.lblErrorPedido.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblErrorPedido.Visible = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label16)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(344, 11)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(335, 214)
        Me.GroupBox3.TabIndex = 217
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Observaciones"
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.White
        Me.Label16.Location = New System.Drawing.Point(4, 27)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(327, 187)
        Me.Label16.TabIndex = 182
        Me.Label16.Text = "Observaciones......"
        '
        'AltaTAG
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1899, 994)
        Me.ControlBox = False
        Me.Controls.Add(Me.lblErrorPedido)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.lblEnProduccion)
        Me.Controls.Add(Me.lblPosicionesFabricacion)
        Me.Controls.Add(Me.lblResultadoCajasStockPedido)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.ImagenVideo)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.dgSacos)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lbErrImpDer)
        Me.Controls.Add(Me.lbErrImpIzq)
        Me.Controls.Add(Me.lbImpDer)
        Me.Controls.Add(Me.lbImpIzq)
        Me.Controls.Add(Me.lbRef)
        Me.Controls.Add(Me.lbAuxPedido)
        Me.Controls.Add(Me.EsperaDer)
        Me.Controls.Add(Me.pnPaqueteDer)
        Me.Controls.Add(Me.pnPaqueteIzq)
        Me.Controls.Add(Me.EsperaIzq)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.LectorTagSacoIzqTextBox)
        Me.Controls.Add(Me.LectorTagSacoDerTextBox)
        Me.Controls.Add(Me.LectorTagTecladoTextBox)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.pnEtiqDer)
        Me.Controls.Add(Me.pnEtiqIzq)
        Me.Controls.Add(Me.pnlSacos)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "AltaTAG"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.pbPalet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbCaja, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbApa, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnPaqueteIzq.ResumeLayout(False)
        Me.pnPaqueteDer.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.dgSacos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ImagenVideo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlSacos.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.RadChartView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadChartView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Timer2 As System.Windows.Forms.Timer
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents LabPedido As System.Windows.Forms.Label
    Friend WithEvents PuertoLectorTAGSacoDer As System.IO.Ports.SerialPort
    Friend WithEvents PuertoLectorTAGSacoIzq As System.IO.Ports.SerialPort
    Friend WithEvents LectorTagSacoIzqTextBox As System.Windows.Forms.TextBox
    Friend WithEvents LectorTagSacoDerTextBox As System.Windows.Forms.TextBox
    Friend WithEvents LectorTagTecladoTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Timer3 As System.Windows.Forms.Timer
    Friend WithEvents tmrOnParpadeo As System.Windows.Forms.Timer
    Friend WithEvents TimerAjusteHora As System.Windows.Forms.Timer
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents lbPalet As System.Windows.Forms.Label
    Friend WithEvents lbCaja As System.Windows.Forms.Label
    Friend WithEvents lbApa As System.Windows.Forms.Label
    Friend WithEvents pbPalet As System.Windows.Forms.PictureBox
    Friend WithEvents pbCaja As System.Windows.Forms.PictureBox
    Friend WithEvents pbApa As System.Windows.Forms.PictureBox
    'Private WithEvents ColorEtiqueta As PowerPacks.RectangleShape
    Friend WithEvents tmrParpadeo As Timer
    Friend WithEvents Timer6 As Timer
    Friend WithEvents PuertoLectorTAGTeclado As IO.Ports.SerialPort
    Friend WithEvents Label4 As Label
    Friend WithEvents LabNEtiquetas As Label
    Friend WithEvents LabCopias As Label
    Friend WithEvents EsperaIzq As Label
    Friend WithEvents pnPaqueteIzq As Panel
    Friend WithEvents lbReferenciaIzq As Label
    Friend WithEvents lbAgujerosIzq As Label
    Friend WithEvents pnPaqueteDer As Panel
    Friend WithEvents EsperaDer As Label
    Friend WithEvents lbCajasc_u As Label
    Friend WithEvents lbColorIzq As Label
    Friend WithEvents lbMetrosIzq As Label
    Friend WithEvents lbPaqueteIzq As Label
    Friend WithEvents lbControlIzq As Label
    Friend WithEvents lbControlDer As Label
    Friend WithEvents lbPaqueteDer As Label
    Friend WithEvents lbMetrosDer As Label
    Friend WithEvents lbColorDer As Label
    Friend WithEvents lbReferenciaDer As Label
    Friend WithEvents lbAgujerosDer As Label
    Friend WithEvents lbAuxPedido As Label
    Friend WithEvents lbRef As Label
    Friend WithEvents pnEtiqIzq As Panel
    Friend WithEvents pnEtiqDer As Panel
    Friend WithEvents lbImpIzq As Label
    Friend WithEvents lbImpDer As Label
    Friend WithEvents lbErrImpIzq As Label
    Friend WithEvents lbErrImpDer As Label
    Friend WithEvents tmrImpIzq As Timer
    Friend WithEvents lbNNoHayPedido As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents LabNombre As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents LabNCP As Label
    Friend WithEvents TmrInicio As Timer
    Friend WithEvents Label7 As Label
    Friend WithEvents dgSacos As DataGridView
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Label8 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents tmrImpDer As Timer
    Friend WithEvents Label13 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Timer4 As Timer
    Friend WithEvents ImagenVideo As PictureBox
    Friend WithEvents TmrCamera As Timer
    Friend WithEvents Label15 As Label
    Friend WithEvents TmrCamera1 As Timer
    Friend WithEvents lblResultadoCajasStockPedido As Label
    Friend WithEvents lblEnProduccion As Label
    Friend WithEvents lblPosicionesFabricacion As Label
    Friend WithEvents PrintDocument1 As Printing.PrintDocument
    Friend WithEvents Panel1 As Panel
    Friend WithEvents pnlSacos As Panel
    Friend WithEvents lblTotalSacos As Label
    Friend WithEvents RadChartView2 As Telerik.WinControls.UI.RadChartView
    Friend WithEvents RadChartView1 As Telerik.WinControls.UI.RadChartView
    Friend WithEvents TimerActualizaTrazabilidad As Timer
    Friend WithEvents Panel2 As Panel
    Friend WithEvents lblPosicion As Label
    Friend WithEvents lblNombrePesa As Label
    Friend WithEvents lblDiaPesa As Label
    Friend WithEvents lblAgujeros As Label
    Friend WithEvents lblPeso As Label
    Friend WithEvents lblTira As Label
    Friend WithEvents lblErrorPedido As Label
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents Label16 As Label
End Class
