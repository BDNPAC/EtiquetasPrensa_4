Imports System.IO.Ports
Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing.Graphics
Imports System.Drawing.Imaging
Imports ControlesFrancesc.Etiqueta
Imports System.Security
Imports AForge.Video
Imports AForge.Video.DirectShow
Imports ZXing

Public Delegate Sub AddReceiveStringPuertoLectorTagTeclado(ByVal str1 As String)
Public Delegate Sub AddReceiveStringPuertoLectorTagSacosDer(ByVal str1 As String)
Public Delegate Sub AddReceiveStringPuertoLectorTagSacosIzq(ByVal str1 As String)
Public Class AltaTAG
#Region "====================================== Puertos serie ============================="
#Region "====================================== Delegados ============================="

    'Declaramos una variable pública del tipo del delagado.

    Public DelegadoLectorTagTeclado As New AddReceiveStringPuertoLectorTagTeclado(AddressOf InvocarPuertoLectorTagTeclado)
    Public DelegadoLectorTagSacosDer As New AddReceiveStringPuertoLectorTagSacosDer(AddressOf InvocarPuertoLectorTagSacoDer)
    Public DelegadoLectorTagSacosIzq As New AddReceiveStringPuertoLectorTagSacosIzq(AddressOf InvocarPuertoLectorTagSacoIzq)
#End Region
    'Dim FUENTES As FilterInfoCollection 'CAMARAS DISPONIBLES
    'Dim WithEvents FUENTE As VideoCaptureDevice 'CAMARA 
    'Dim IMAGEN As Bitmap 'IMAGENES CAMARA

    Public NoPalet As String
    Public RefArti As String
    Public RefColor As String
    Public MetrosPalet As String
    Public ComLectorTagTeclado As String
    Public ComLectorTagSacoDer As String
    Public ComLectorTagSacoIzq As String
    Public PosEntraDatos As Integer = 0
    Public Direccionlogo = "\\Serversala\SIE\Img\"
    Dim Etiqueta As ControlesFrancesc.Etiqueta
    Dim EtiqIzq As ControlesFrancesc.Etiqueta
    Dim EtiqDer As ControlesFrancesc.Etiqueta
    Dim Lector As Integer = 0
    Dim ConnectToServerSala As SqlConnection
    Dim Connect1ToServerSala As SqlConnection
    Dim Metros As Integer
    Dim MetrosItem As String
    Dim SalaPrensa As Integer = 2
    Dim MetrosCaja As Integer
    Dim NoCajas As Integer
    Dim Paquete As Double
    Dim EtiquetaActiva As Boolean
    Dim IdSacoTAG As String
    Public CadenaConexion As String = "Persist Security Info=False; " &
   "User ID=sa; " &
   "Initial Catalog=Produccion; " &
   "Data Source=SERVERSALA "

    Dim Tamany As Integer = 1
    Dim Tipo As Integer = 1
    Dim HayPedido As Boolean
    Dim TAgujeros As String
    Dim Agujeros As Integer
    Dim Cabezal As Integer
    Dim Posicion As Integer
    Dim Nota As String
    Dim CambiaModoImpresion As Boolean = False
    Dim TeclaControl As Boolean = False
    Dim TextoEtiqueta As String

    Dim MRef(1) As String
    Dim MColor(1) As String
    Dim MMetrosItem(1) As String
    Dim MPaquete(1) As String
    Dim MCabezal(1) As String
    Dim MPosicion(1) As String
    Dim MTAgujeros(1) As String
    Dim MNota(1) As String
    Dim MTextoEtiqueta(1) As String
    Dim Index As Integer
#Region "====================================== InvocaTextBox ============================="
    Public Sub InvocarPuertoLectorTagTeclado(ByVal str1 As String)

        If (Asc(Mid(str1, 2, 1)) > 47 And Asc(Mid(str1, 2, 1)) < 59) Or (Asc(Mid(str1, 2, 1)) > 64 And Asc(Mid(str1, 2, 1)) < 71) Then

            EsperaIzq.Visible = True
            Application.DoEvents()
            Lector = 0
            BuscaTAG(Mid(str1, 2, 10))
        End If

        PuertoLectorTAGTeclado.ReadExisting()
    End Sub
    Public Sub InvocarPuertoLectorTagSacoDer(ByVal str1 As String)

        If (Asc(Mid(str1, 2, 1)) > 47 And Asc(Mid(str1, 2, 1)) < 59) Or (Asc(Mid(str1, 2, 1)) > 64 And Asc(Mid(str1, 2, 1)) < 71) Then

            EsperaIzq.Visible = True
            Application.DoEvents()
            Lector = 1
            BuscaTAG(Mid(str1, 2, 10))
        End If
        PuertoLectorTAGSacoDer.ReadExisting()
    End Sub
    Public Sub InvocarPuertoLectorTagSacoIzq(ByVal str1 As String)

        If (Asc(Mid(str1, 2, 1)) > 47 And Asc(Mid(str1, 2, 1)) < 59) Or (Asc(Mid(str1, 2, 1)) > 64 And Asc(Mid(str1, 2, 1)) < 71) Then

            EsperaDer.Visible = True
            Application.DoEvents()
            Lector = 2
            BuscaTAG(Mid(str1, 2, 10))
        End If
        PuertoLectorTAGSacoIzq.ReadExisting()
    End Sub
#End Region
#Region "====================================== Configuracion puertos serie ============================="
    Private Sub ConfiguraPuertosSerie()

        Dim PuertoLectorTagTeclado As SerialPort = New SerialPort()
        Dim PuertoLectorTAGSacoDer As SerialPort = New SerialPort()
        Dim PuertoLectorTAGSacoIzq As SerialPort = New SerialPort()


        'ComLectorTagTeclado = "COM5"    'PC-Sala33

        ComLectorTagTeclado = "COM1"   'PC-Francesc
        ComLectorTagSacoDer = "COM6"
        ComLectorTagSacoIzq = "COM5"

        With PuertoLectorTagTeclado
            .PortName = ComLectorTagTeclado
            .BaudRate = 9600
            .Parity = 0
            .DataBits = 8
            .StopBits = 1
            .ReadBufferSize = 1
            .WriteBufferSize = 1
            .ParityReplace = 0
        End With
        With PuertoLectorTAGSacoDer
            .PortName = ComLectorTagSacoDer
            .BaudRate = 9600
            .Parity = 0
            .DataBits = 8
            .StopBits = 1
            .ReadBufferSize = 1
            .WriteBufferSize = 1
            .ParityReplace = 0
        End With
        With PuertoLectorTAGSacoIzq
            .PortName = ComLectorTagSacoIzq
            .BaudRate = 9600
            .Parity = 0
            .DataBits = 8
            .StopBits = 1
            .ReadBufferSize = 1
            .WriteBufferSize = 1
            .ParityReplace = 0
        End With

    End Sub
    'Por último controlamos el evento DataReceived del serial port: 

    Private Sub PuertoLectorTagTeclado_DataReceived(ByVal sender As Object, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs) Handles PuertoLectorTAGTeclado.DataReceived
        PuertoLectorTAGTeclado.BaudRate = 9600
        Dim Valor As String = ""
        'Try
        Valor = PuertoLectorTAGTeclado.ReadTo(vbCr)
        LectorTagTecladoTextBox.Invoke(DelegadoLectorTagTeclado, New Object() {Valor})

        'Catch ex As Exception

        'End Try

    End Sub
    Private Sub PuertoLectorTagTecladoConectar()
        'Try
        PuertoLectorTAGTeclado = My.Computer.Ports.OpenSerialPort(ComLectorTagTeclado)
        'Catch ex As Exception

        'End Try
    End Sub
    Private Sub PuertoLectorTagSacoDer_DataReceived(ByVal sender As Object, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs) Handles PuertoLectorTAGSacoDer.DataReceived
        PuertoLectorTAGSacoDer.BaudRate = 9600
        Dim Valor As String = ""
        'Try
        Valor = PuertoLectorTAGSacoDer.ReadTo(vbCr)
        LectorTagSacoDerTextBox.Invoke(DelegadoLectorTagSacosDer, New Object() {Valor})
        'Catch ex As Exception

        'End Try
    End Sub
    Private Sub PuertoLectorTagsacoDerConectar()
        'Try
        PuertoLectorTAGSacoDer = My.Computer.Ports.OpenSerialPort(ComLectorTagSacoDer)
        'Catch ex As Exception

        'End Try
    End Sub
    Private Sub PuertoLectorTagsacoIzq_DataReceived(ByVal sender As Object, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs) Handles PuertoLectorTAGSacoIzq.DataReceived
        PuertoLectorTAGSacoIzq.BaudRate = 9600
        Dim Valor As String = ""
        '   Try
        Valor = PuertoLectorTAGSacoIzq.ReadTo(vbCr)
        LectorTagSacoIzqTextBox.Invoke(DelegadoLectorTagSacosIzq, New Object() {Valor})

        '    Catch ex As Exception

        '   End Try
    End Sub
    Private Sub PuertoLectorTagsacoIzqConectar()
        'Try
        PuertoLectorTAGSacoIzq = My.Computer.Ports.OpenSerialPort(ComLectorTagSacoIzq)
        'Catch ex As Exception

        'End Try
    End Sub
#End Region

#End Region
#Region "Imprimir-------"

    Private Sub ImprimirDesdeMemoria()
        ImpresionDesdeMemoria.Show()
        ImpresionDesdeMemoria.ImprimeCaja()
        Timer6.Start()
    End Sub
    Private Sub Timer6_Tick(sender As Object, e As EventArgs) Handles Timer6.Tick
        'ImpresionDesdeMemoria.ImprimeCaja()
        ImpresionDesdeMemoria.Dispose()
        Timer6.Stop()
    End Sub

#End Region
    Private Sub tmrImpIzq_Tick(sender As Object, e As EventArgs) Handles tmrImpIzq.Tick
        If lbImpIzq.Text = "Imprimir" Then
            lbImpIzq.Text = "No imprimir"
            lbImpIzq.BackColor = Color.Orange
            lbErrImpIzq.Visible = False
        Else
            lbImpIzq.Text = "Imprimir"
            lbImpIzq.BackColor = Color.LawnGreen
        End If
        tmrImpIzq.Stop()

        'Timer4.Stop()
        'CambiaModoImpresion = False
    End Sub
    Private Sub tmrImpDer_Tick(sender As Object, e As EventArgs) Handles tmrImpDer.Tick
        If lbImpDer.Text = "Imprimir" Then
            lbImpDer.Text = "No imprimir"
            lbImpDer.BackColor = Color.Orange
            lbErrImpDer.Visible = False
        Else
            lbImpDer.Text = "Imprimir"
            lbImpDer.BackColor = Color.LawnGreen
        End If
        tmrImpDer.Stop()
    End Sub
    Private Sub AltaTAG_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Label12.Text = e.KeyCode
        Select Case e.KeyCode
            Case 17 'Ctrl
                TmrInicio.Start()
            Case 18 'Alt
                tmrImpIzq.Start()
            Case Val(Keys.Back)
                tmrImpDer.Start()
        End Select
    End Sub
    Private Sub AltaTAG_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        Dim Copias As Integer = 1
        Dim Numeros As String = ""
        Dim TeclaNumero As Boolean = False
        Label1.Text = e.KeyCode
        Label6.Text = PosEntraDatos
        Select Case e.KeyCode
            Case 45, 96
                Numeros = "0"
                TeclaNumero = True
            Case 35, 97
                Numeros = "1"
                TeclaNumero = True
            Case 40, 98
                Numeros = "2"
                TeclaNumero = True
            Case 34, 99
                Numeros = "3"
                TeclaNumero = True
            Case 37, 100
                Numeros = "4"
                TeclaNumero = True
                Label14.Text = "tecla pulsada"
                If lbImpIzq.Text = "Imprimir" And Len(LabPedido.Text) = 8 And PosEntraDatos <> 2 Then
                    EtiquetaTermica()
                End If
                'If HayPedido And PosEntraDatos = 1 And LabNEtiquetas.Text = "" And CambiaModoImpresion Then
                '    If lbImpIzq.Text = "Imprimir" Then
                '        lbImpIzq.Text = "No imprimir"
                '        lbImpIzq.BackColor = Color.Orange
                '        lbErrImpIzq.Visible = False
                '    Else
                '        lbImpIzq.Text = "Imprimir"
                '        lbImpIzq.BackColor = Color.LawnGreen
                '    End If
                '    Timer4.Stop()
                '    CambiaModoImpresion = False
                'End If
                TeclaNumero = True
            Case 12, 101
                Numeros = "5"
                TeclaNumero = True
            Case 39, 102
                Numeros = "6"
                TeclaNumero = True
                Label13.Text = "tecla pulsada"
                If lbImpDer.Text = "Imprimir" And Len(LabPedido.Text) = 8 And PosEntraDatos <> 2 Then
                    EtiquetaTermica1()
                End If
                'If HayPedido And PosEntraDatos = 1 And LabNEtiquetas.Text = "" And CambiaModoImpresion Then
                '    If lbImpDer.Text = "Imprimir" Then
                '        lbImpDer.Text = "No imprimir"
                '        lbImpDer.BackColor = Color.Orange
                '        lbErrImpDer.Visible = False
                '    Else
                '        lbImpDer.Text = "Imprimir"
                '        lbImpDer.BackColor = Color.LawnGreen
                '    End If
                '    tmrImpIzq.Stop()
                '    CambiaModoImpresion = False
                'End If
                TeclaNumero = True
            Case 36, 103
                Numeros = "7"
                TeclaNumero = True
            Case 38, 104
                Numeros = "8"
                TeclaNumero = True
            Case 33, 105
                Numeros = "9"
                TeclaNumero = True
            Case Val(Keys.F2)
                End
            Case Val(Keys.Return)
                Select Case PosEntraDatos
                    Case 0
                        If LabNCP.Text <> "" Then
                            VerOperario(Val(LabNCP.Text))
                            If LabNombre.Text <> "-" And LabNombre.Text <> "Nulo" Then
                                PosEntraDatos = 1
                                SeleccionEntrada(PosEntraDatos)
                            End If
                        End If
                    Case 1
                        If Len(LabPedido.Text) = 8 Then
                            ImprimirDesdeMemoria()
                        End If
                    Case 2
                        If Len(LabPedido.Text) = 8 Then
                            If Val(LabNEtiquetas.Text) > 1 Then Copias = Val(LabNEtiquetas.Text) Else Copias = 1
                            If Copias > 50 Then Copias = 50
                            While Copias > 0
                                LabCopias.Text = Copias
                                Application.DoEvents()

                                ImprimirDesdeMemoria()
                                Copias -= 1
                            End While
                            LabCopias.Text = Copias
                            LabNEtiquetas.Text = ""
                            PosEntraDatos = 1
                            SeleccionEntrada(PosEntraDatos)
                        End If
                End Select

            Case Val(Keys.Add)
            Case Val(Keys.Subtract)
            Case Val(Keys.Multiply)
            Case Val(Keys.Divide)
                Select Case PosEntraDatos
                    Case 1
                        PosEntraDatos = 2
                        Label6.Text = PosEntraDatos
                        SeleccionEntrada(PosEntraDatos)
                End Select

            Case Val(Keys.Back)
                tmrImpDer.Stop()
            'If TeclaControl Then
            '    Label7.Text = "Back1"
            '    LabNCP.Text = ""
            '    LabNombre.Text = "-"
            '    Limpia()
            '    HayPedido = False
            '    PosEntraDatos = 0
            '    SeleccionEntrada(PosEntraDatos)
            '    TmrInicio.Stop()
            '    TeclaControl = False
            'End If
            'PosEntraDatos = IIf(PosEntraDatos >= 3, 0, PosEntraDatos + 1)
            'SeleccionEntrada(PosEntraDatos)
            Case 18 'Alt
                'Timer4.Start()
                'CambiaModoImpresion = True
                'Label7.Text = "Control"
                tmrImpIzq.Stop()
            Case 17 'Ctrl
                TmrInicio.Stop()
            'TmrInicio.Start()
            'TeclaControl = True
            Case Val(Keys.Escape)
                Select Case PosEntraDatos
                    Case 0
                        LabNCP.Text = ""
                        Limpia()
                        HayPedido = False
                    Case 1, 2
                        Limpia()
                        HayPedido = False
                        PosEntraDatos = 1
                        SeleccionEntrada(PosEntraDatos)
                End Select
            Case Else
        End Select
        If TeclaNumero Then
            Select Case PosEntraDatos
                Case 0
                    LabNCP.Text = IIf(Len(LabNCP.Text) < 2, LabNCP.Text & Numeros, LabNCP.Text)
                    If Len(LabNCP.Text) = 2 Then


                    End If
                Case 1
                    LabPedido.Text = IIf(Len(LabPedido.Text) < 8, LabPedido.Text & Numeros, LabPedido.Text)
                    If Len(LabPedido.Text) = 8 Then

                        Etiqueta.DatosEtiqueta(Val(LabPedido.Text), 1, CadenaConexion)
                        VerEtiquetaPedido(Val(LabPedido.Text))
                        CargaGrid(Val(LabPedido.Text))
                        PosEntraDatos = 1
                    End If
                Case 2
                    LabNEtiquetas.Text = IIf(Len(LabNEtiquetas.Text) < 2, LabNEtiquetas.Text & Numeros, LabNEtiquetas.Text)
                    If Val(LabNEtiquetas.Text) > 50 Then LabNEtiquetas.Text = "50"
            End Select
        End If
        'Label1.Text = PosEntraDatos
    End Sub
    Private Sub Limpia()
        EtiquetaActiva = False
        Etiqueta.Visible = False
        Etiqueta.Visible = False
        LabPedido.Text = ""
        LabNEtiquetas.Text = ""
        pbApa.Visible = False
        pbCaja.Visible = False
        pbPalet.Visible = False
        lbApa.Text = ""
        lbCaja.Text = ""
        lbPalet.Text = ""
        lbCajasc_u.Text = ""
        lbRef.Text = "Referencia"
        lbAuxPedido.Text = "Nº pedido"
        pnEtiqIzq.Visible = False
        pnEtiqDer.Visible = False
        pnPaqueteIzq.Visible = False
        pnPaqueteDer.Visible = False
        lbNNoHayPedido.Visible = True
        HayPedido = False
        dgSacos.Rows.Clear()
    End Sub
    Private Sub AltaTAG_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'FUENTES = New FilterInfoCollection(FilterCategory.VideoInputDevice)
        'If FUENTES.Count > 0 Then

        '    For i As Integer = 0 To FUENTES.Count - 1
        '        If FUENTES(i).Name.ToString = "USB2.0 PC CAMERA" Then
        '            Index = i
        '        End If
        '    Next
        'End If

        Etiqueta = New ControlesFrancesc.Etiqueta
        Me.Controls.Add(Etiqueta)
        EtiqIzq = New ControlesFrancesc.Etiqueta
        EtiqDer = New ControlesFrancesc.Etiqueta
        pnEtiqIzq.Controls.Add(EtiqIzq)
        pnEtiqDer.Controls.Add(EtiqDer)
        Me.KeyPreview = True
        pnPaqueteIzq.Visible = False
        pnPaqueteDer.Visible = False
        pnEtiqIzq.Visible = False
        pnEtiqDer.Visible = False
        pnEtiqIzq.Location = New Point(386, 555)
        pnEtiqDer.Location = New Point(1020, 555)
        ConnectToServerSala = New SqlConnection("Persist Security Info=False; " &
           "User ID=sa; " &
           "Initial Catalog=Produccion; " &
       "Data Source=SERVERSALA; ")
        Connect1ToServerSala = New SqlConnection("Persist Security Info=False; " &
           "User ID=sa; " &
           "Initial Catalog=Produccion; " &
       "Data Source=SERVERSALA; ")
        Etiqueta.Location = New Point(628, 442)
        Etiqueta.Tipo(Tamany, Tipo)

        LabPedido.Text = ""
        Etiqueta.Visible = False
        LabPedido.BackColor = Color.White
        LabNEtiquetas.BackColor = Color.LightGray
        ConfiguraPuertosSerie()
        PuertoLectorTagTecladoConectar()
        PuertoLectorTagsacoDerConectar()
        PuertoLectorTagsacoIzqConectar()
        lbImpIzq.Text = "No imprimir"
        lbImpDer.Text = "No imprimir"
        PosEntraDatos = 0
        SeleccionEntrada(PosEntraDatos)
        'FUENTE = New VideoCaptureDevice(FUENTES(Index).MonikerString)
        'AddHandler FUENTE.NewFrame, New NewFrameEventHandler(AddressOf video_NuevoFrame1)
        'FUENTE.Start()
    End Sub
    Private Sub BuscaTAG(ByVal NTAG As String)
        Dim strSQL As SqlCommand
        Dim rs As SqlDataReader
        Dim CodUtilidad As Integer = 0
        Try
            ConnectToServerSala.Open()
            'strSQL = New SqlCommand("SELECT * FROM TAGS where TAG = '" & NTAG & "'", ConnectToServerSala)
            strSQL = New SqlCommand("exec sp_EP_AltaTAG_ObtenerTodoDeTAG '" & NTAG & "'", ConnectToServerSala)

            rs = strSQL.ExecuteReader
            'Try
            If rs.Read() Then
                CodUtilidad = IIf(IsDBNull(rs("CodUtilidad")), 0, rs("CodUtilidad"))

                Select Case CodUtilidad
                    Case 1
                        Paquete = Trim(rs("Identificacion"))
                        If LabPedido.Text = "" Then
                            tmrParpadeo.Start()
                            tmrOnParpadeo.Start()
                        End If
                    Case 2
                        MarcadorHorario.Close()
                        MarcadorHorario.NTAG = rs("TAG")
                        MarcadorHorario.NCP = rs("Identificacion")
                        MarcadorHorario.Show()
                    Case 3
                        LabPedido.Text = Trim(rs("Identificacion"))
                End Select

            End If
        Catch ex As Exception
            MsgBox("Error: Procedimiento, sp_EP_AltaTAG_ObtenerTodoDeTAG." & vbCrLf + ex.Message)
        Finally
            ConnectToServerSala.Close()
            ConnectToServerSala.Dispose()
        End Try

        Select Case CodUtilidad
            Case 1
                'pnPaqueteIzq.Visible = False
                'pnPaqueteDer.Visible = False
                Etiqueta.Visible = False
                'Label13.Text = Paquete
                VerTAGIdSaco(Paquete, Lector)
                'Case 3
                '    Etiqueta.Visible = False
                '    Etiqueta.DatosEtiqueta(LabPedido.Text, 1, CadenaConexion)
                '    VerEtiquetaPedido(LabPedido.Text)
                '    Timer3.Start()
        End Select

        EsperaIzq.Visible = False
        EsperaDer.Visible = False
    End Sub
    Private Sub CargaGrid(ByVal IdPedido As Long)
        Dim strSQL As SqlCommand
        Dim Fila As Integer
        Dim Columna As Integer
        Dim rs As SqlDataReader
        Dim Dia As String
        Dim cnn As SqlConnection
        ConnectToServerSala.Open()
        dgSacos.Rows.Clear()
        Application.DoEvents()
        strSQL = New SqlCommand("exec GridSacosSinTAG " & IdPedido, ConnectToServerSala)
        rs = strSQL.ExecuteReader
        Fila = 0
        Columna = 0
        While rs.Read()
            dgSacos.Rows.Add()
            dgSacos.Rows(Fila).Cells(Columna).Value = rs("IdSaco")
            Columna += 1
            dgSacos.Rows(Fila).Cells(Columna).Value = rs("Agujeros")
            Fila += 1
            Columna = 0
        End While
        ConnectToServerSala.Close()


    End Sub
    Private Sub VerEtiquetaPedido(ByVal IdPedido As Long)
        Dim strSQL As SqlCommand
        Dim rs As SqlDataReader
        Etiqueta.Refresh()
        ConnectToServerSala.Open()
        strSQL = New SqlCommand("EXEC AbrePedidoPalet1 " & IdPedido, ConnectToServerSala)
        rs = strSQL.ExecuteReader
        If rs.Read() Then
            lbCajasc_u.Text = rs("Cajas") & " cajas"
            MetrosItem = rs("MtsItem")
            lbRef.Text = rs("Ref")
        End If
        ConnectToServerSala.Close()
        ConnectToServerSala.Open()
        Dim comando1 As New SqlCommand("exec ImagenesEnvasado " & IdPedido, ConnectToServerSala)
        Dim lector1 As SqlDataReader
        lector1 = comando1.ExecuteReader
        If lector1.Read() Then
            pbApa.Visible = True
            pbCaja.Visible = True
            pbPalet.Visible = True
            lbNNoHayPedido.Visible = False

            HayPedido = True

            pbApa.Image = Image.FromFile(Direccionlogo & lector1("ImgAPA"))
            'PbAPAA.Image = Image.FromFile(Direccionlogo & lector1("ImgAPA"))
            pbCaja.Image = Image.FromFile(Direccionlogo & lector1("ImgEnvase"))
            pbPalet.Image = Image.FromFile(Direccionlogo & lector1("ImgPalet"))
            lbApa.Text = "Idioma: " & vbCr & vbLf & Trim(lector1("Idioma"))
            lbCaja.Text = "Envase: " & vbCr & vbLf & Trim(lector1("Envase"))
            lbPalet.Text = "Palet: " & vbCr & vbLf & Trim(lector1("Palet"))
            TextoEtiqueta = lector1("TextoEtiqueta")
        End If

        ConnectToServerSala.Close()
    End Sub
    Private Sub VerOperario(ByVal NCP As Integer)
        Dim strSQL As SqlCommand
        Dim rs As SqlDataReader
        Try
            ConnectToServerSala.Open()
            'strSQL = New SqlCommand("SELECT top(1) Nombre FROM dbo.Operario WHERE NCP = " & NCP, ConnectToServerSala)
            strSQL = New SqlCommand("exec sp_EP_AltaTAG_NombreOperario " & NCP, ConnectToServerSala)
            rs = strSQL.ExecuteReader
            If rs.Read() Then
                LabNombre.Text = rs("Nombre")
            Else
                LabNombre.Text = "-"
            End If
        Catch ex As Exception
            MsgBox("Error: Procedimiento, sp_EP_AltaTAG_NombreOperario." & vbCrLf + ex.Message)

        Finally
            ConnectToServerSala.Close()
            ConnectToServerSala.Dispose()
        End Try
    End Sub

    Private Sub VerTAGIdSaco(ByVal Paquete As String, ByVal LectorX As Integer)
        Dim strSQL As SqlCommand
        Dim rs As SqlDataReader
        Dim ref As String = "Referencia"
        Try
            ConnectToServerSala.Open()
            '   strSQL = New SqlCommand("SELECT dbo.Articulos.IdPedido, dbo.Sacos.Tira, dbo.Sacos.Agujeros, 
            '       SUBSTRING(CAST(100 + dbo.PosNueva.NoPosicion AS char(3)), 2, 2) AS Posicion,
            '       dbo.Articulos.IdReferencia, dbo.Pedidos.Nota
            '       FROM dbo.Sacos INNER JOIN
            '           dbo.Articulos ON dbo.Sacos.IdNumFicha = dbo.Articulos.NumFicha INNER JOIN
            '           dbo.PosNueva ON 
            '           dbo.Articulos.Posicion + dbo.Articulos.Sala * 100 = dbo.PosNueva.Posicion INNER JOIN
            'dbo.Pedidos ON dbo.Articulos.IdPedido = dbo.Pedidos.IdPedido
            '       WHERE dbo.Sacos.IdSaco  = '" & Paquete & "'", ConnectToServerSala)
            strSQL = New SqlCommand("exec sp_EP_AltaTAG_VerTAGIdSaco '" & Paquete & "'", ConnectToServerSala)
            rs = strSQL.ExecuteReader

            If rs.Read() Then
                ref = rs("IdReferencia")
                lbAuxPedido.Text = rs("IdPedido")
                If LabPedido.Text = "" Or (lbRef.Text <> rs("IdReferencia")) Then
                    tmrParpadeo.Start()
                    tmrOnParpadeo.Start()
                    ConnectToServerSala.Close()
                    Etiqueta.Refresh()
                    Etiqueta.DatosEtiqueta(Val(LabPedido.Text), 1, CadenaConexion)
                    Select Case LectorX
                        Case 0

                        Case 1
                            pnEtiqIzq.Visible = True
                            pnPaqueteIzq.Visible = False
                            EtiqIzq.DatosEtiqueta(lbAuxPedido.Text, 4, CadenaConexion)
                        Case 2
                            pnEtiqDer.Visible = True
                            pnPaqueteDer.Visible = False
                            EtiqDer.DatosEtiqueta(lbAuxPedido.Text, 4, CadenaConexion)
                    End Select
                    Exit Sub
                End If

                Agujeros = rs("Agujeros")
                Select Case Agujeros
                    Case 0
                        TAgujeros = "O"
                    Case 1
                        TAgujeros = "I"
                    Case 2
                        TAgujeros = "Z"
                    Case 3
                        TAgujeros = "E"
                    Case Else
                        TAgujeros = "M"
                End Select
                Cabezal = rs("Tira")
                Posicion = rs("Posicion")
                Nota = rs("Nota")
                'If lbNNoHayPedido.Visible = False Then
                '    HayPedido = True
                'End If
            End If
        Catch ex As Exception
            MsgBox("Error: Procedimiento, sp_EP_AltaTAG_VerTAGIdSaco." & vbCrLf + ex.Message)
        Finally
            ConnectToServerSala.Close()
            ConnectToServerSala.Dispose()
        End Try

        If HayPedido Then
            Etiqueta.Refresh()
            Etiqueta.DatosEtiqueta(Val(LabPedido.Text), 1, CadenaConexion)
            VerEtiquetaPedido(Val(LabPedido.Text))

            Select Case LectorX
                Case 0

                Case 1
                    pnEtiqIzq.Visible = False
                    pnPaqueteIzq.Visible = True
                    lbReferenciaIzq.Text = Etiqueta.LabelRef.Text
                    lbColorIzq.Text = Etiqueta.LabelColor.Text
                    lbMetrosIzq.Text = MetrosItem
                    lbPaqueteIzq.Text = Paquete
                    lbControlIzq.Text = LabPedido.Text
                    Select Case Agujeros
                        Case 0
                            lbAgujerosIzq.BackColor = Color.Lime
                        Case 1
                            lbAgujerosIzq.BackColor = Color.Gold
                        Case 2
                            lbAgujerosIzq.BackColor = Color.Orange
                        Case > 2
                            lbAgujerosIzq.BackColor = Color.Red
                    End Select
                    lbAgujerosIzq.Text = "Agujeros: " & Agujeros
                    pnPaqueteIzq.BackColor = Color.LightGreen
                    pnPaqueteDer.BackColor = Color.LightPink

                    MRef(0) = Etiqueta.LabelRef.Text
                    MColor(0) = Etiqueta.LabelColor.Text
                    MMetrosItem(0) = MetrosItem
                    MPaquete(0) = Paquete
                    MCabezal(0) = Cabezal
                    MPosicion(0) = Posicion
                    MTAgujeros(0) = Agujeros
                    MNota(0) = Nota
                    MTextoEtiqueta(0) = TextoEtiqueta

                    If lbImpIzq.Text = "Imprimir" Then
                        EtiquetaTermica()
                        GuardaPrensa(Paquete)
                    End If
                Case 2
                    pnEtiqDer.Visible = False
                    pnPaqueteDer.Visible = True
                    lbReferenciaDer.Text = Etiqueta.LabelRef.Text
                    lbColorDer.Text = Etiqueta.LabelColor.Text
                    lbMetrosDer.Text = MetrosItem
                    lbPaqueteDer.Text = Paquete
                    lbControlDer.Text = LabPedido.Text
                    Select Case Agujeros
                        Case 0
                            lbAgujerosDer.BackColor = Color.Lime
                        Case 1
                            lbAgujerosDer.BackColor = Color.Gold
                        Case 2
                            lbAgujerosDer.BackColor = Color.Orange
                        Case > 2
                            lbAgujerosDer.BackColor = Color.Red
                    End Select
                    lbAgujerosDer.Text = "Agujeros: " & Agujeros
                    pnPaqueteDer.BackColor = Color.LightGreen
                    pnPaqueteIzq.BackColor = Color.LightPink

                    MRef(1) = Etiqueta.LabelRef.Text
                    MColor(1) = Etiqueta.LabelColor.Text
                    MMetrosItem(1) = MetrosItem
                    MPaquete(1) = Paquete
                    MCabezal(1) = Cabezal
                    MPosicion(1) = Posicion
                    MTAgujeros(1) = Agujeros
                    MNota(1) = Nota
                    MTextoEtiqueta(1) = TextoEtiqueta

                    If lbImpDer.Text = "Imprimir" Then
                        EtiquetaTermica1()
                        GuardaPrensa(Paquete)
                    End If
            End Select
            'If (lbRef.Text <> ref) Then
            '    Select Case LectorX
            '        Case 0

            '        Case 1
            '            pnEtiqIzq.Visible = True
            '            pnPaqueteIzq.Visible = False
            '            EtiqIzq.DatosEtiqueta(lbAuxPedido.Text, 4, CadenaConexion)
            '        Case 2
            '            pnEtiqDer.Visible = True
            '            pnPaqueteDer.Visible = False
            '            EtiqDer.DatosEtiqueta(lbAuxPedido.Text, 4, CadenaConexion)
            '    End Select
            'End If

        End If
        'HayPedido = False
    End Sub
    Private Sub GuardaPrensa(ByVal Paquete As String)
        Dim strSQL As SqlCommand
        Dim rs As SqlDataReader
        Etiqueta.Refresh()
        ConnectToServerSala.Open()
        strSQL = New SqlCommand("EXEC GuardaPrensa " & Paquete & "," & Val(LabNCP.Text), ConnectToServerSala)
        rs = strSQL.ExecuteReader
        ConnectToServerSala.Close()
    End Sub
    Private Sub SeleccionEntrada(ByVal Pos As Integer)
        Select Case Pos
            Case 0
                GroupBox2.BackColor = Color.PaleGreen
                GroupBox1.BackColor = Color.LemonChiffon
                LabNCP.BackColor = Color.White
                LabPedido.BackColor = Color.LightGray
                LabNEtiquetas.BackColor = Color.LightGray
            Case 1
                GroupBox1.BackColor = Color.PaleGreen
                GroupBox2.BackColor = Color.LemonChiffon
                LabNCP.BackColor = Color.LightGray
                LabPedido.BackColor = Color.White
                LabNEtiquetas.BackColor = Color.LightGray
            Case 2
                LabPedido.BackColor = Color.LightGray
                LabPedido.BackColor = Color.LightGray
                LabNEtiquetas.BackColor = Color.White
        End Select

    End Sub

    Private Sub EtiquetaTermica1()
        lbErrImpDer.Visible = False
        Try
            'Shell("C:\Users\Francesc\Documents\lbPrensa_Derecha.bat """ &
            Shell("C:\Users\sala\Documents\lbPrensa_Derecha.bat """ &
            MRef(1) & """ """ &
            MColor(1) & """ """ &
                  MMetrosItem(1) & """ """ &
                  MPaquete(1) & """ """ &
                  MCabezal(1) & """ """ &
                  MPosicion(1) & """ """ &
                  MTAgujeros(1) & """ """ &
                  MNota(1) & """ """ &
                  MTextoEtiqueta(1) & """ ")

            'Label14.Text = MRef(1) & """ """ &
            '      MColor(1) & """ """ &
            '      MMetrosItem(1) & """ """ &
            '      MPaquete(1) & """ """ &
            '      MCabezal(1) & """ """ &
            '      MPosicion(1) & """ """ &
            '      MTAgujeros(1) & """ """ &
            '      MNota(1) & """ """ &
            '      MTextoEtiqueta(1) & """ "

            'Timer4.Start()
        Catch
            lbErrImpDer.Visible = True
        End Try
    End Sub
    Private Sub Timer4_Tick(sender As Object, e As EventArgs) Handles Timer4.Tick
        Label13.Text = ""
        Label14.Text = ""
        Timer4.Stop()
    End Sub

    Private Sub EtiquetaTermica()
        lbErrImpIzq.Visible = False
        Try
            Shell("C:\Users\sala\Documents\lbPrensa_Izquierda.bat """ &
                   MRef(0) & """ """ &
                  MColor(0) & """ """ &
                  MMetrosItem(0) & """ """ &
                  MPaquete(0) & """ """ &
                  MCabezal(0) & """ """ &
                  MPosicion(0) & """ """ &
                  MTAgujeros(0) & """ """ &
                  MNota(0) & """ """ &
                  MTextoEtiqueta(0) & """ ")

            'Label13.Text = MRef(0) & """ """ &
            '      MColor(0) & """ """ &
            '      MMetrosItem(0) & """ """ &
            '      MPaquete(0) & """ """ &
            '      MCabezal(0) & """ """ &
            '      MPosicion(0) & """ """ &
            '      MTAgujeros(0) & """ """ &
            '      MNota(0) & """ """ &
            '      MTextoEtiqueta(0) & """ "
            'Timer4.Start()
        Catch
            lbErrImpIzq.Visible = True
        End Try
    End Sub
    'Private Sub EtiquetaTermica1()
    '    lbErrImpDer.Visible = False
    '    Try
    '        If Nota = "" Then
    '            Shell("C:\Users\sala\Documents\lbPrensa_Derecha.bat """ &
    '              Etiqueta.LabelRef.Text & """ """ &
    '              Etiqueta.LabelColor.Text & """ """ &
    '              MetrosItem & """ """ &
    '              Paquete & """ """ &
    '              Cabezal & """ """ &
    '              Posicion & """ """ &
    '              TAgujeros & """ ")
    '        Else
    '            Shell("C:\Users\sala\Documents\lbPrensa_corbata_Derecha.bat """ &
    '              Etiqueta.LabelRef.Text & """ """ &
    '              Etiqueta.LabelColor.Text & """ """ &
    '              MetrosItem & """ """ &
    '              Paquete & """ """ &
    '              Cabezal & """ """ &
    '              Posicion & """ """ &
    '              TAgujeros & """ """ &
    '              Nota & """ ")
    '        End If
    '    Catch
    '        lbErrImpDer.Visible = True
    '    End Try
    'End Sub
    'Private Sub EtiquetaTermica()
    '    lbErrImpIzq.Visible = False
    '    Try
    '        If Nota = "" Then
    '            Shell("C:\Users\sala\Documents\lbPrensa_Izquierda.bat """ &
    '              Etiqueta.LabelRef.Text & """ """ &
    '              Etiqueta.LabelColor.Text & """ """ &
    '              MetrosItem & """ """ &
    '              Paquete & """ """ &
    '              Cabezal & """ """ &
    '              Posicion & """ """ &
    '              TAgujeros & """ ")
    '        Else
    '            Shell("C:\Users\sala\Documents\lbPrensa_corbata_Izquierda.bat """ &
    '              Etiqueta.LabelRef.Text & """ """ &
    '              Etiqueta.LabelColor.Text & """ """ &
    '              MetrosItem & """ """ &
    '              Paquete & """ """ &
    '              Cabezal & """ """ &
    '              Posicion & """ """ &
    '              TAgujeros & """ """ &
    '              Nota & """ ")
    '        End If
    '    Catch
    '        lbErrImpIzq.Visible = True
    '    End Try
    'End Sub
    Private Sub tmrParpadeo_Tick(sender As Object, e As EventArgs) Handles tmrParpadeo.Tick
        If lbNNoHayPedido.Visible Then
            lbNNoHayPedido.Visible = False
        Else
            lbNNoHayPedido.Visible = True
        End If
    End Sub

    Private Sub tmrOnParpadeo_Tick(sender As Object, e As EventArgs) Handles tmrOnParpadeo.Tick
        tmrParpadeo.Stop()
        tmrOnParpadeo.Stop()
        lbNNoHayPedido.Visible = True

    End Sub

    Private Sub TmrInicio_Tick(sender As Object, e As EventArgs) Handles TmrInicio.Tick
        'TmrInicio.Stop()
        'TeclaControl = False
        'Label7.Text = "Espera"

        Label7.Text = "Back1"
        LabNCP.Text = ""
        LabNombre.Text = "-"
        Limpia()
        HayPedido = False
        PosEntraDatos = 0
        SeleccionEntrada(PosEntraDatos)
        TmrInicio.Stop()
        TeclaControl = False
    End Sub

    'Private Sub TmrCamera_Tick(sender As Object, e As EventArgs) Handles TmrCamera.Tick
    '    Dim Dato As String
    '    Try
    '        Dim DECODER As BarcodeReader = New BarcodeReader
    '        Dato = DECODER.Decode(IMAGEN).ToString
    '        VerTAGIdSaco(Dato, 2)
    '        TmrCamera.Stop()
    '        TmrCamera1.Start()
    '    Catch ex As Exception
    '    End Try
    'End Sub


    'Private Sub video_NuevoFrame1(sender As Object, eventArgs As NewFrameEventArgs)
    '    'PRESENTA LAS IMAGENES EN EL PICTUREBOX1
    '    IMAGEN = DirectCast(eventArgs.Frame.Clone(), Bitmap)
    '    Try
    '        ImagenVideo.Image = IMAGEN
    '    Catch
    '    End Try
    'End Sub

    'Private Sub TmrCamera1_Tick(sender As Object, e As EventArgs) Handles TmrCamera1.Tick
    '    TmrCamera1.Stop()
    '    TmrCamera.Start()
    'End Sub
End Class
