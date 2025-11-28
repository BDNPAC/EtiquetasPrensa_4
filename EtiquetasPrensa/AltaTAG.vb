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
Imports System.Runtime.InteropServices
Imports System.IO
Imports ControlesFrancesc
Imports System.Text
Imports System.Security.Cryptography
Imports Telerik.WinControls.Zip

'Public Delegate Sub AddReceiveStringPuertoLectorTagTeclado(ByVal str1 As String)
Public Delegate Sub AddReceiveStringPuertoLectorTagSacosDer(ByVal str1 As String)
Public Delegate Sub AddReceiveStringPuertoLectorTagSacosIzq(ByVal str1 As String)
Public Class AltaTAG
#Region "====================================== Puertos serie ============================="
#Region "====================================== Delegados ============================="

    'Declaramos una variable pública del tipo del delagado.

    'Public DelegadoLectorTagTeclado As New AddReceiveStringPuertoLectorTagTeclado(AddressOf InvocarPuertoLectorTagTeclado)
    Public DelegadoLectorTagSacosDer As New AddReceiveStringPuertoLectorTagSacosDer(AddressOf InvocarPuertoLectorTagSacoDer)
    Public DelegadoLectorTagSacosIzq As New AddReceiveStringPuertoLectorTagSacosIzq(AddressOf InvocarPuertoLectorTagSacoIzq)
#End Region
    'Dim FUENTES As FilterInfoCollection 'CAMARAS DISPONIBLES
    'Dim WithEvents FUENTE As VideoCaptureDevice 'CAMARA 
    'Dim IMAGEN As Bitmap 'IMAGENES CAMARAj

    Public NoPalet As String
    Public RefArti As String
    Public RefColor As String
    Public MetrosPalet As String
    'Public ComLectorTagTeclado As String
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
    Dim operarioNCP As String 'Mostrar NCP en etiqueta saco''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ' Public CadenaConexion As String = "Persist Security Info=False; " &
    '"User ID=sa; " &
    '"Initial Catalog=Produccion; " &
    '"Data Source=SERVERSALA "
    Public Shared CadenaConexionProduccion As String
    Dim Tamany As Integer = 1
    Dim Tipo As Integer = 1
    Dim TipoEtiqueta As Integer = 0 'MOD''''''''''''''''''''''''''''''''''''''''''''''''''''''''
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

    Dim Repositorio_ As Repositorio
    Dim DatosSacosProduccion As DatosSacoModel
    Dim DatosSacoTagModel_Izq As DatosSacoTagModel
    Dim DatosSacoTagModel_Der As DatosSacoTagModel

    Dim infoSystem As ControlesFrancesc.SystemInfo

    Dim auxTAG As String 'TODO 
#Region "====================================== InvocaTextBox ============================="
    'Public Sub InvocarPuertoLectorTagTeclado(ByVal str1 As String)

    '    If (Asc(Mid(str1, 2, 1)) > 47 And Asc(Mid(str1, 2, 1)) < 59) Or (Asc(Mid(str1, 2, 1)) > 64 And Asc(Mid(str1, 2, 1)) < 71) Then

    '        EsperaIzq.Visible = True
    '        Application.DoEvents()
    '        Lector = 0
    '        BuscaTAG(Mid(str1, 2, 10))
    '    End If

    '    PuertoLectorTAGTeclado.ReadExisting()
    'End Sub
    Public Sub InvocarPuertoLectorTagSacoDer(ByVal str1 As String)
        Dim tagSinChecksum As String = str1.Substring(1, 10)
        Dim codigoVerificaCheckSum = str1.Substring(11, 2)
        Repositorio_ = New Repositorio()
        If (Asc(Mid(str1, 2, 1)) > 47 And Asc(Mid(str1, 2, 1)) < 58) Or (Asc(Mid(str1, 2, 1)) > 64 And Asc(Mid(str1, 2, 1)) < 71) Then
            If ChecksumHelp.isCheckSum(tagSinChecksum, codigoVerificaCheckSum) Then
                EsperaIzq.Visible = True
                Application.DoEvents()
                Lector = 1
                BuscaTAG(Mid(str1, 2, 10))
                DatosSacoTagModel_Der = Repositorio_.obtenerDatosTAGSacoPrensado(Paquete)
                mostrarDatosSaco(DatosSacoTagModel_Der)
            End If
        End If
        PuertoLectorTAGSacoDer.ReadExisting()
    End Sub
    Public Sub InvocarPuertoLectorTagSacoIzq(ByVal str1 As String)
        Dim tagSinChecksum As String = str1.Substring(1, 10)
        Dim codigoVerificaCheckSum = str1.Substring(11, 2)
        Repositorio_ = New Repositorio()

        If (Asc(Mid(str1, 2, 1)) > 47 And Asc(Mid(str1, 2, 1)) < 58) Or (Asc(Mid(str1, 2, 1)) > 64 And Asc(Mid(str1, 2, 1)) < 71) Then
            If ChecksumHelp.isCheckSum(tagSinChecksum, codigoVerificaCheckSum) Then
                EsperaDer.Visible = True
                Application.DoEvents()
                Lector = 2
                BuscaTAG(Mid(str1, 2, 10))
                DatosSacoTagModel_Izq = Repositorio_.obtenerDatosTAGSacoPrensado(Paquete)
                mostrarDatosSaco(DatosSacoTagModel_Izq)
            End If
        End If
        PuertoLectorTAGSacoIzq.ReadExisting()
    End Sub
#End Region
#Region "====================================== Configuracion puertos serie ============================="
    Private Sub ConfiguraPuertosSerie()

        'Dim PuertoLectorTagTeclado As SerialPort = New SerialPort()
        Dim PuertoLectorTAGSacoDer As SerialPort = New SerialPort()
        Dim PuertoLectorTAGSacoIzq As SerialPort = New SerialPort()


        'ComLectorTagTeclado = "COM5"    'PC-Sala33

        ' ComLectorTagTeclado = "COM1"   'PC-Francesc
        ComLectorTagSacoDer = "COM6"
        ComLectorTagSacoIzq = "COM5"

        'With PuertoLectorTagTeclado
        '    .PortName = ComLectorTagTeclado
        '    .BaudRate = 9600
        '    .Parity = 0
        '    .DataBits = 8
        '    .StopBits = 1
        '    .ReadBufferSize = 1
        '    .WriteBufferSize = 1
        '    .ParityReplace = 0
        'End With
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

    'Private Sub PuertoLectorTagTeclado_DataReceived(ByVal sender As Object, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs) Handles PuertoLectorTAGTeclado.DataReceived
    '    PuertoLectorTAGTeclado.BaudRate = 9600
    '    Dim Valor As String = ""
    '    'Try
    '    Valor = PuertoLectorTAGTeclado.ReadTo(vbCr)
    '    LectorTagTecladoTextBox.Invoke(DelegadoLectorTagTeclado, New Object() {Valor})

    '    'Catch ex As Exception

    '    'End Try

    'End Sub
    'Private Sub PuertoLectorTagTecladoConectar()
    '    'Try
    '    PuertoLectorTAGTeclado = My.Computer.Ports.OpenSerialPort(ComLectorTagTeclado)
    '    'Catch ex As Exception

    '    'End Try
    'End Sub
    Private Sub PuertoLectorTagSacoDer_DataReceived(ByVal sender As Object, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs) Handles PuertoLectorTAGSacoDer.DataReceived
        PuertoLectorTAGSacoDer.BaudRate = 9600
        Dim Valor As String = ""
        Try
            Valor = PuertoLectorTAGSacoDer.ReadTo(vbCr)
            If Valor <> String.Empty Then
                LectorTagSacoDerTextBox.Invoke(DelegadoLectorTagSacosDer, New Object() {Valor})
            End If
        Catch ex As Exception
            ExecuteSqlTransactionRegistroError(My.Computer.Name & ". ERROR EtiquetaPrensa. Error en AltaTag --> PuertoLectorTagSacoDer_DataReceived(). Error:" + ex.Message.ToString()) 'TODO try cath
        End Try
    End Sub
    Private Sub PuertoLectorTagsacoDerConectar()
        Try
            PuertoLectorTAGSacoDer = My.Computer.Ports.OpenSerialPort(ComLectorTagSacoDer)
        Catch ex As Exception
            ExecuteSqlTransactionRegistroError(My.Computer.Name & ". ERROR EtiquetaPrensa. Error en AltaTag --> PuertoLectorTagsacoDerConectar(). Error:" + ex.Message.ToString()) 'TODO try cath
        End Try
    End Sub
    Private Sub PuertoLectorTagsacoIzq_DataReceived(ByVal sender As Object, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs) Handles PuertoLectorTAGSacoIzq.DataReceived
        PuertoLectorTAGSacoIzq.BaudRate = 9600
        Dim Valor As String = ""
        Try
            Valor = PuertoLectorTAGSacoIzq.ReadTo(vbCr)
            If Valor <> String.Empty Then
                LectorTagSacoIzqTextBox.Invoke(DelegadoLectorTagSacosIzq, New Object() {Valor})
            End If
        Catch ex As Exception
            ExecuteSqlTransactionRegistroError(My.Computer.Name & ". ERROR EtiquetaPrensa. Error en AltaTag --> PuertoLectorTagsacoIzq_DataReceived(). Error:" + ex.Message.ToString()) 'TODO try cath
        End Try
    End Sub
    Private Sub PuertoLectorTagsacoIzqConectar()
        Try
            PuertoLectorTAGSacoIzq = My.Computer.Ports.OpenSerialPort(ComLectorTagSacoIzq)
        Catch ex As Exception
            ExecuteSqlTransactionRegistroError(My.Computer.Name & ". ERROR EtiquetaPrensa. Error en AltaTag --> PuertoLectorTagsacoIzqConectar(). Error:" + ex.Message.ToString()) 'TODO try cath
        End Try
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
                'TmrInicio.Start() '''''MODIFICADO
            Case 18 'Alt
                tmrImpIzq.Start()
            Case Val(Keys.Back)
                tmrImpDer.Start()
            Case Val(Keys.Multiply) '''''MODIFICADO
                TmrInicio.Start()
                lblErrorPedido.Visible = False 'TODO
                My.Computer.Audio.Stop() 'TODO AUDIO
        End Select

    End Sub
    Private Sub AltaTAG_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        Dim Copias As Integer = 1
        Dim Numeros As String = ""
        Dim TeclaNumero As Boolean = False
        Label1.Text = e.KeyCode
        Label6.Text = PosEntraDatos
        Dim auxCaja = New AuxCajaStockModel() '''''''''''''''''''''''''''''''''''''''''''
        Dim repo = New Repositorio() '''''''''''''''''''''''''''''''''''''''''''''''''''''''
        'Dim caja = New CajaStockModel()
        Dim listCajas = New List(Of CajaStockModel) ''''''''''''''''''''''''''''''''''''''''''

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
                                operarioNCP = LabNCP.Text.Trim 'Mostrar NCP en etiqueta saco''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                                'insertamos el NCP en la tabla enlacePrensa
                                Select Case My.Computer.Name
                                    Case "PC-SALA54"
                                        repo.actualizarNCPEnlacePrensa(operarioNCP, 1201, 1202)
                                    Case "PC-SALA55"
                                        repo.actualizarNCPEnlacePrensa(operarioNCP, 1203, 1204)
                                    Case "PC-SALA57"
                                        repo.actualizarNCPEnlacePrensa(operarioNCP, 1205, 1206, 1207)
                                End Select
                                PosEntraDatos = 1
                                SeleccionEntrada(PosEntraDatos)
                            End If
                        End If
                    Case 1
                        If Len(LabPedido.Text) = 8 Then
                            If TipoEtiqueta = 1 Then 'MOD
                                ImprimirDesdeMemoria()
                            Else
                                imprimirEtiquetaCaja()
                            End If
                        End If
                    Case 2
                        If Len(LabPedido.Text) = 8 Then
                            If Val(LabNEtiquetas.Text) > 1 Then Copias = Val(LabNEtiquetas.Text) Else Copias = 1
                            If Copias > 50 Then Copias = 50
                            While Copias > 0
                                LabCopias.Text = Copias
                                Application.DoEvents()
                                If TipoEtiqueta = 1 Then 'MOD
                                    ImprimirDesdeMemoria()
                                Else
                                    imprimirEtiquetaCaja()
                                End If
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
            Case Val(Keys.Multiply) ' PULSAMOS ASTERISCOS, BORRA EL NCP INTRODUCIDO
                Select Case My.Computer.Name
                    Case "PC-SALA54"
                        repo.actualizarNCPEnlacePrensa(0, 1201, 1202)
                    Case "PC-SALA55"
                        repo.actualizarNCPEnlacePrensa(0, 1203, 1204)
                    Case "PC-SALA57"
                        repo.actualizarNCPEnlacePrensa(0, 1205, 1206, 1207)
                End Select
                TmrInicio.Stop()'''''MODIFICADO
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
                'TmrInicio.Stop()'''''MODIFICADO
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
                        Label16.Text = ""
                        HayPedido = False
                        PosEntraDatos = 1
                        RadChartView1.Series.Clear()
                        RadChartView2.Series.Clear()
                        pnlSacos.Visible = False
                        SeleccionEntrada(PosEntraDatos)
                End Select
            Case Else
        End Select
        If TeclaNumero Then
            Select Case PosEntraDatos
                Case 0
                    LabNCP.Text = IIf(Len(LabNCP.Text) < 3, LabNCP.Text & Numeros, LabNCP.Text)
                'LabNCP.Text = IIf(Len(LabNCP.Text) < 2, LabNCP.Text & Numeros, LabNCP.Text)
                'If Len(LabNCP.Text) = 2 Then


                'End If
                Case 1
                    LabPedido.Text = IIf(Len(LabPedido.Text) < 8, LabPedido.Text & Numeros, LabPedido.Text)
                    If Len(LabPedido.Text) = 8 Then

                        auxCaja = repo.obtenerParametrosFromPedido(LabPedido.Text.Trim()) 'obtenemos los parametros del pedido''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        DatosSacosProduccion = repo.obtenerDatosSacos(LabPedido.Text.Trim())
                        Dim grafica1 As Grafica = New Grafica()
                        Dim grafica2 As Grafica = New Grafica()
                        RadChartView1.Series.Clear()
                        RadChartView2.Series.Clear()
                        grafica1.CrearGrafica(RadChartView1, DatosSacosProduccion.SacosPrensados1,
                                                DatosSacosProduccion.SacosNoPrensados1, "Sacos prensados", "Sacos sin prensar", "SACOS PRENSADOS")
                        grafica2.CrearGrafica(RadChartView2, DatosSacosProduccion.SacosFabricados1,
                                                DatosSacosProduccion.SacosPorFabricar1, "Sacos fabricados", "Sacos por fabricar", "SACOS FABRICADOS")
                        lblTotalSacos.Text = "CANTIDAD TOTAL DE SACOS DEL PEDIDO: " & DatosSacosProduccion.SacosTotalPedido1 & " SACOS"


                        pnlSacos.Visible = True
                        If auxCaja IsNot Nothing Then 'Añadida esta condición
                            If Not auxCaja.Articulo1.Equals("") Then
                                listCajas = repo.comprobarPedido(auxCaja.Articulo1, auxCaja.Colore1, auxCaja.Metros1) 'obtenemos las cajas o caja que hay en stock'''''''''''''''''''''''''''''''''''
                                If listCajas.Count > 0 Then
                                    mostrarCajasStockPedido(listCajas)
                                Else
                                    lblResultadoCajasStockPedido.Text = ""
                                End If

                            End If
                        End If
                        Panel1.Controls.Clear()
                        Etiqueta = New ControlesFrancesc.Etiqueta
                        Etiqueta.TipoImpresionCentrado(Tamany, Tipo) 'TODO mod_centrado_blanco
                        Panel1.Controls.Add(Etiqueta)
                        Etiqueta.DatosEtiquetaImpresion(Val(LabPedido.Text), 1, CadenaConexionProduccion) 'TODO mod_centrado_blanco
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
        If Etiqueta IsNot Nothing Then
            Etiqueta.Visible = False
        End If
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
        CadenaConexionProduccion = obtenerCadenaConexionProduccion()
        Etiqueta = New ControlesFrancesc.Etiqueta
        'Me.Controls.Add(Etiqueta)
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
        ConnectToServerSala = New SqlConnection(CadenaConexionProduccion)
        Connect1ToServerSala = New SqlConnection(CadenaConexionProduccion)
        Repositorio_ = New Repositorio

        Me.infoSystem = New SystemInfo
        Me.infoSystem.setHostName(My.Computer.Name)
        Me.infoSystem.setVerSoftware("Ver. " & File.GetLastWriteTime("\\192.168.0.22\AppSala\EtiquetasPrensaTAG\EtiquetasPrensa.application").ToString)
        Me.infoSystem.Location = New Point(7, 910)
        Me.Controls.Add(infoSystem)

        ' ConnectToServerSala = New SqlConnection("Persist Security Info=False; " &
        '    "User ID=sa; " &
        '    "Initial Catalog=Produccion; " &
        '"Data Source=SERVERSALA\NEXUS; ")
        ' Connect1ToServerSala = New SqlConnection("Persist Security Info=False; " &
        '    "User ID=sa; " &
        '    "Initial Catalog=Produccion; " &
        '"Data Source=SERVERSALA\NEXUS; ")
        'Etiqueta.Location = New Point(628, 442) MOD
        'Etiqueta.TipoImpresionCentrado(Tamany, Tipo) 'TODO mod_centrado_blanco
        'Panel1.Controls.Add(Etiqueta)
        LabPedido.Text = ""
        'Etiqueta.Visible = False
        LabPedido.BackColor = Color.White
        LabNEtiquetas.BackColor = Color.LightGray
        ConfiguraPuertosSerie()
        'PuertoLectorTagTecladoConectar()
        PuertoLectorTagsacoDerConectar()
        PuertoLectorTagsacoIzqConectar()
        lbImpIzq.Text = "No imprimir"
        lbImpDer.Text = "No imprimir"
        PosEntraDatos = 0
        SeleccionEntrada(PosEntraDatos)
        'FUENTE = New VideoCaptureDevice(FUENTES(Index).MonikerString)
        'AddHandler FUENTE.NewFrame, New NewFrameEventHandler(AddressOf video_NuevoFrame1)
        'FUENTE.Start()

        TimerActualizaTrazabilidad.Start()
    End Sub
    'Private Sub BuscaTAG(ByVal NTAG As String)
    '    Dim strSQL As SqlCommand
    '    Dim rs As SqlDataReader
    '    Dim CodUtilidad As Integer = 0
    '    Dim auxPerfilPuerta As Integer = 0
    '    Try
    '        ConnectToServerSala.Open()
    '        strSQL = New SqlCommand("SELECT * FROM TAGS where TAG = '" & NTAG & "'", ConnectToServerSala)

    '        rs = strSQL.ExecuteReader

    '        If rs.Read() Then
    '            CodUtilidad = IIf(IsDBNull(rs("CodUtilidad")), 0, rs("CodUtilidad"))
    '            auxPerfilPuerta = IIf(IsDBNull(rs("IdPerfilPuerta")), 0, rs("IdPerfilPuerta")) 'rs("IdPerfilPuerta")
    '            Select Case CodUtilidad
    '                Case 1
    '                    Paquete = Trim(IIf(IsDBNull(rs("Identificacion")), 0, rs("Identificacion"))) 'Trim(rs("Identificacion"))
    '                    If LabPedido.Text = "" Then
    '                        tmrParpadeo.Start()
    '                        tmrOnParpadeo.Start()
    '                    End If
    '                Case 2
    '                    If auxPerfilPuerta > 1 Then
    '                        MarcadorHorario.Close()
    '                        MarcadorHorario.NTAG = rs("TAG")
    '                        MarcadorHorario.NCP = rs("Identificacion")
    '                        MarcadorHorario.Show()
    '                    End If
    '                Case 3
    '                    LabPedido.Text = Trim(rs("Identificacion"))
    '            End Select
    '            auxTAG = NTAG 'TODO
    '        End If
    '        rs.Close() 'TODO lector
    '        ConnectToServerSala.Close()
    '    Catch ex As Exception
    '        ExecuteSqlTransactionRegistroError(My.Computer.Name & ". ERROR EtiquetaPrensa. Error en AltaTag --> BuscaTAG(). Error:" + ex.Message.ToString()) 'TODO try cath
    '    End Try

    '    Select Case CodUtilidad
    '        Case 1
    '            'pnPaqueteIzq.Visible = False
    '            'pnPaqueteDer.Visible = False
    '            Etiqueta.Visible = False
    '            'Label13.Text = Paquete
    '            VerTAGIdSaco(Paquete, Lector)
    '            'Case 3
    '            '    Etiqueta.Visible = False
    '            '    Etiqueta.DatosEtiqueta(LabPedido.Text, 1, CadenaConexion)
    '            '    VerEtiquetaPedido(LabPedido.Text)
    '            '    Timer3.Start()
    '    End Select

    '    EsperaIzq.Visible = False
    '    EsperaDer.Visible = False
    'End Sub

    Private Sub BuscaTAG(ByVal NTAG As String)
        Dim CodUtilidad As Integer = 0
        Dim auxPerfilPuerta As Integer = 0
        Dim identificacion As Object = Nothing
        Dim tagValue As Object = Nothing

        Try
            ConnectToServerSala.Open()
            Using strSQL As New SqlCommand("SELECT CodUtilidad, IdPerfilPuerta, Identificacion, TAG FROM TAGS WHERE TAG = @NTAG", ConnectToServerSala)
                strSQL.Parameters.AddWithValue("@NTAG", NTAG)
                Using rs As SqlDataReader = strSQL.ExecuteReader()
                    If rs.Read() Then
                        CodUtilidad = If(IsDBNull(rs("CodUtilidad")), 0, Convert.ToInt32(rs("CodUtilidad")))
                        auxPerfilPuerta = If(IsDBNull(rs("IdPerfilPuerta")), 0, Convert.ToInt32(rs("IdPerfilPuerta")))
                        identificacion = If(IsDBNull(rs("Identificacion")), 0, rs("Identificacion"))
                        tagValue = If(IsDBNull(rs("TAG")), "", rs("TAG"))
                        auxTAG = NTAG 'TODO
                        Select Case CodUtilidad
                            Case 1
                                Paquete = identificacion.ToString().Trim()
                                If LabPedido.Text = "" Then
                                    tmrParpadeo.Start()
                                    tmrOnParpadeo.Start()
                                End If
                            Case 2
                                If auxPerfilPuerta > 1 Then
                                    MarcadorHorario.Close()
                                    MarcadorHorario.NTAG = tagValue
                                    MarcadorHorario.NCP = identificacion
                                    MarcadorHorario.Show()
                                End If
                            Case 3
                                LabPedido.Text = identificacion.ToString().Trim()
                        End Select
                    End If
                End Using
            End Using
        Catch ex As Exception
            ExecuteSqlTransactionRegistroError(My.Computer.Name & ". ERROR EtiquetaPrensa. Error en AltaTag --> BuscaTAG(). Error:" + ex.Message.ToString())
        Finally
            If ConnectToServerSala.State = ConnectionState.Open Then
                ConnectToServerSala.Close()
            End If
        End Try

        If CodUtilidad = 1 Then
            If Etiqueta IsNot Nothing Then
                Etiqueta.Visible = False
            End If
            VerTAGIdSaco(Paquete, Lector)
        End If

        EsperaIzq.Visible = False
        EsperaDer.Visible = False
    End Sub
    'Private Sub CargaGrid(ByVal IdPedido As Long)
    '    Dim strSQL As SqlCommand
    '    Dim Fila As Integer
    '    Dim Columna As Integer
    '    Dim rs As SqlDataReader
    '    Dim Dia As String
    '    'Dim cnn As SqlConnection
    '    Using cnn As SqlConnection = New SqlConnection(CadenaConexionProduccion)
    '        Try
    '            cnn.Open()
    '            dgSacos.Rows.Clear()
    '            Application.DoEvents()
    '            strSQL = New SqlCommand("exec GridSacosSinTAG " & IdPedido, cnn)
    '            rs = strSQL.ExecuteReader
    '            Fila = 0
    '            Columna = 0
    '            While rs.Read()
    '                dgSacos.Rows.Add()
    '                dgSacos.Rows(Fila).Cells(Columna).Value = rs("IdSaco")
    '                Columna += 1
    '                dgSacos.Rows(Fila).Cells(Columna).Value = rs("Agujeros")
    '                Fila += 1
    '                Columna = 0
    '            End While
    '            rs.Close() 'TODO lector
    '        Catch ex As Exception
    '            ExecuteSqlTransactionRegistroError(My.Computer.Name & ". ERROR EtiquetaPrensa. Error en AltaTag --> CargaGrid(). Error:" + ex.Message.ToString()) 'TODO try cath
    '            MessageBox.Show("Error. CargaGrid --->" + vbCrLf + ex.Message)
    '        Finally
    '            cnn.Close()
    '        End Try
    '    End Using
    '    'Dim strSQL As SqlCommand
    '    'Dim Fila As Integer
    '    'Dim Columna As Integer
    '    'Dim rs As SqlDataReader
    '    'Dim Dia As String
    '    'Dim cnn As SqlConnection
    '    'ConnectToServerSala.Open()
    '    'dgSacos.Rows.Clear()
    '    'Application.DoEvents()
    '    'strSQL = New SqlCommand("exec GridSacosSinTAG " & IdPedido, ConnectToServerSala)
    '    'rs = strSQL.ExecuteReader
    '    'Fila = 0
    '    'Columna = 0
    '    'While rs.Read()
    '    '    dgSacos.Rows.Add()
    '    '    dgSacos.Rows(Fila).Cells(Columna).Value = rs("IdSaco")
    '    '    Columna += 1
    '    '    dgSacos.Rows(Fila).Cells(Columna).Value = rs("Agujeros")
    '    '    Fila += 1
    '    '    Columna = 0
    '    'End While
    '    'ConnectToServerSala.Close()


    'End Sub

    Private Sub CargaGrid(ByVal IdPedido As Long)
        ' Optimización: Evitar Application.DoEvents, minimizar acceso a la UI y uso de variables locales
        Try
            dgSacos.SuspendLayout() ' Mejora el rendimiento al agregar filas
            dgSacos.Rows.Clear()
            Using cnn As New SqlConnection(CadenaConexionProduccion)
                cnn.Open()
                Using strSQL As New SqlCommand("exec GridSacosSinTAG " & IdPedido, cnn)
                    Using rs As SqlDataReader = strSQL.ExecuteReader()
                        While rs.Read()
                            ' Agregar la fila y establecer ambos valores en una sola llamada
                            Dim idx As Integer = dgSacos.Rows.Add(rs("IdSaco"), rs("Agujeros"))
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            ExecuteSqlTransactionRegistroError(My.Computer.Name & ". ERROR EtiquetaPrensa. Error en AltaTag --> CargaGrid(). Error:" + ex.Message.ToString())
            MessageBox.Show("Error. CargaGrid --->" & vbCrLf & ex.Message)
        Finally
            dgSacos.ResumeLayout()
        End Try
    End Sub
    'Private Sub VerEtiquetaPedido(ByVal IdPedido As Long)
    '    Dim strSQL As SqlCommand
    '    Dim rs As SqlDataReader
    '    Etiqueta.Refresh()
    '    Using cnn As SqlConnection = New SqlConnection(CadenaConexionProduccion)
    '        Try
    '            cnn.Open()
    '            strSQL = New SqlCommand("EXEC AbrePedidoPalet1 " & IdPedido, cnn)
    '            rs = strSQL.ExecuteReader
    '            If rs.Read() Then
    '                lbCajasc_u.Text = rs("Cajas") & " cajas"
    '                MetrosItem = rs("MtsItem")
    '                lbRef.Text = rs("Ref")
    '                TipoEtiqueta = rs("TipoEtiqueta") 'MOD ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '            End If
    '            rs.Close() 'TODO lector
    '        Catch ex As Exception
    '            ExecuteSqlTransactionRegistroError(My.Computer.Name & ". ERROR EtiquetaPrensa. Error en AltaTag --> VerEtiquetaPedidoA(). Error:" + ex.Message.ToString()) 'TODO try cath
    '            MessageBox.Show("Error. VerEtiquetaPedido, procedimiento AbrePedidoPalet1 --->" + vbCrLf + ex.Message)
    '        Finally
    '            cnn.Close()
    '        End Try
    '    End Using
    '    Using cnn As SqlConnection = New SqlConnection(CadenaConexionProduccion)
    '        Try
    '            cnn.Open()
    '            Dim comando1 As New SqlCommand("exec ImagenesEnvasado " & IdPedido, cnn)
    '            Dim lector1 As SqlDataReader
    '            lector1 = comando1.ExecuteReader
    '            If lector1.Read() Then
    '                pbApa.Visible = True
    '                pbCaja.Visible = True
    '                pbPalet.Visible = True
    '                lbNNoHayPedido.Visible = False

    '                HayPedido = True

    '                pbApa.Image = Image.FromFile(Direccionlogo & lector1("ImgAPA"))
    '                'PbAPAA.Image = Image.FromFile(Direccionlogo & lector1("ImgAPA"))
    '                pbCaja.Image = Image.FromFile(Direccionlogo & lector1("ImgEnvase"))
    '                pbPalet.Image = Image.FromFile(Direccionlogo & lector1("ImgPalet"))
    '                lbApa.Text = "Idioma: " & vbCr & vbLf & Trim(lector1("Idioma"))
    '                lbCaja.Text = "Envase: " & vbCr & vbLf & Trim(lector1("Envase"))
    '                lbPalet.Text = "Palet: " & vbCr & vbLf & Trim(lector1("Palet"))
    '                TextoEtiqueta = lector1("TextoEtiqueta")
    '            End If
    '            lector1.Close() 'TODO lector
    '        Catch ex As Exception
    '            ExecuteSqlTransactionRegistroError(My.Computer.Name & ". ERROR EtiquetaPrensa. Error en AltaTag --> VerEtiquetaPedidoB(). Error:" + ex.Message.ToString()) 'TODO try cath
    '            MessageBox.Show("Error. VerEtiquetaPedido, procedimiento ImagenesEnvasado --->" + vbCrLf + ex.Message)
    '        Finally
    '            cnn.Close()
    '        End Try

    '    End Using
    'End Sub

    Private Sub VerEtiquetaPedido(ByVal IdPedido As Long)
        Etiqueta.Refresh()

        ' Usar una sola conexión para ambas consultas para reducir la sobrecarga
        Using cnn As New SqlConnection(CadenaConexionProduccion)
            Try
                cnn.Open()

                ' Primera consulta: AbrePedidoPalet1
                Using strSQL As New SqlCommand("EXEC AbrePedidoPalet1 " & IdPedido, cnn)
                    Using rs As SqlDataReader = strSQL.ExecuteReader()
                        If rs.Read() Then
                            lbCajasc_u.Text = rs("Cajas") & " cajas"
                            MetrosItem = rs("MtsItem")
                            lbRef.Text = rs("Ref")
                            TipoEtiqueta = rs("TipoEtiqueta")
                        End If
                    End Using
                End Using

                ' Segunda consulta: ImagenesEnvasado
                Using comando1 As New SqlCommand("exec ImagenesEnvasado " & IdPedido, cnn)
                    Using lector1 As SqlDataReader = comando1.ExecuteReader()
                        If lector1.Read() Then
                            pbApa.Visible = True
                            pbCaja.Visible = True
                            pbPalet.Visible = True
                            lbNNoHayPedido.Visible = False

                            HayPedido = True

                            ' Cargar imágenes solo si los archivos existen para evitar excepciones
                            Dim imgApaPath As String = Path.Combine(Direccionlogo, lector1("ImgAPA").ToString())
                            Dim imgEnvasePath As String = Path.Combine(Direccionlogo, lector1("ImgEnvase").ToString())
                            Dim imgPaletPath As String = Path.Combine(Direccionlogo, lector1("ImgPalet").ToString())

                            If File.Exists(imgApaPath) Then pbApa.Image = Image.FromFile(imgApaPath)
                            If File.Exists(imgEnvasePath) Then pbCaja.Image = Image.FromFile(imgEnvasePath)
                            If File.Exists(imgPaletPath) Then pbPalet.Image = Image.FromFile(imgPaletPath)

                            lbApa.Text = "Idioma: " & vbCr & vbLf & lector1("Idioma").ToString().Trim()
                            lbCaja.Text = "Envase: " & vbCr & vbLf & lector1("Envase").ToString().Trim()
                            lbPalet.Text = "Palet: " & vbCr & vbLf & lector1("Palet").ToString().Trim()
                            TextoEtiqueta = lector1("TextoEtiqueta").ToString()
                        End If
                    End Using
                End Using

            Catch ex As Exception
                ExecuteSqlTransactionRegistroError(My.Computer.Name & ". ERROR EtiquetaPrensa. Error en AltaTag --> VerEtiquetaPedido(). Error:" + ex.Message.ToString())
                MessageBox.Show("Error. VerEtiquetaPedido --->" & vbCrLf & ex.Message)
            End Try
        End Using
    End Sub
    'Private Sub VerOperario(ByVal NCP As Integer)
    '    Dim strSQL As SqlCommand
    '    Dim rs As SqlDataReader
    '    Try
    '        ConnectToServerSala.Open()
    '        strSQL = New SqlCommand("SELECT top(1) Nombre FROM dbo.Operario WHERE NCP = " & NCP, ConnectToServerSala)
    '        rs = strSQL.ExecuteReader
    '        If rs.Read() Then
    '            LabNombre.Text = rs("Nombre")
    '        Else
    '            LabNombre.Text = "-"
    '        End If
    '        rs.Close() 'TODO lector
    '        ConnectToServerSala.Close()
    '    Catch ex As Exception
    '        ExecuteSqlTransactionRegistroError(My.Computer.Name & ". ERROR EtiquetaPrensa. Error en AltaTag --> VerOperario(). Error:" + ex.Message.ToString()) 'TODO try cath
    '    End Try
    'End Sub

    Private Sub VerOperario(ByVal NCP As Integer)
        Try
            ConnectToServerSala.Open()
            Using strSQL As New SqlCommand("SELECT TOP 1 Nombre FROM dbo.Operario WHERE NCP = @NCP", ConnectToServerSala)
                strSQL.Parameters.AddWithValue("@NCP", NCP)
                Using rs As SqlDataReader = strSQL.ExecuteReader()
                    LabNombre.Text = If(rs.Read() AndAlso Not IsDBNull(rs("Nombre")), rs("Nombre").ToString(), "-")
                End Using
            End Using
        Catch ex As Exception
            ExecuteSqlTransactionRegistroError(My.Computer.Name & ". ERROR EtiquetaPrensa. Error en AltaTag --> VerOperario(). Error:" + ex.Message.ToString())
        Finally
            If ConnectToServerSala.State = ConnectionState.Open Then
                ConnectToServerSala.Close()
            End If
        End Try
    End Sub

    Private Sub VerTAGIdSaco(ByVal Paquete As String, ByVal LectorX As Integer)
        'Dim strSQL As SqlCommand
        'Dim rs As SqlDataReader
        'Dim ref As String = "Referencia"
        'Try
        '    ConnectToServerSala.Open()
        '    '   strSQL = New SqlCommand("SELECT dbo.Articulos.IdPedido, dbo.Sacos.Tira, dbo.Sacos.Agujeros, 
        '    '       SUBSTRING(CAST(100 + dbo.PosNueva.NoPosicion AS char(3)), 2, 2) AS Posicion,
        '    '       dbo.Articulos.IdReferencia, dbo.Pedidos.Nota
        '    '       FROM dbo.Sacos INNER JOIN
        '    '           dbo.Articulos ON dbo.Sacos.IdNumFicha = dbo.Articulos.NumFicha INNER JOIN
        '    '           dbo.PosNueva ON 
        '    '           dbo.Articulos.Posicion + dbo.Articulos.Sala * 100 = dbo.PosNueva.Posicion INNER JOIN
        '    'dbo.Pedidos ON dbo.Articulos.IdPedido = dbo.Pedidos.IdPedido
        '    '       WHERE dbo.Sacos.IdSaco  = '" & Paquete & "'", ConnectToServerSala)

        '    strSQL = New SqlCommand("SELECT dbo.Articulos.IdPedido, dbo.Sacos.Tira, dbo.Sacos.Agujeros, dbo.Articulos.IdReferencia, dbo.Pedidos.Nota, dbo.PosNueva.NoPosicion 
        '                        FROM dbo.Sacos INNER JOIN dbo.Articulos ON dbo.Sacos.IdNumFicha = dbo.Articulos.NumFicha INNER JOIN
        '                 dbo.Pedidos ON dbo.Articulos.IdPedido = dbo.Pedidos.IdPedido INNER JOIN
        '                 dbo.PosNueva ON dbo.Articulos.SalaPos = dbo.PosNueva.Posicion
        '                 WHERE dbo.Sacos.IdSaco = '" & Paquete & "'", ConnectToServerSala)
        '    rs = strSQL.ExecuteReader
        '    lblErrorPedido.Visible = False 'TODO error tag
        '    If rs.Read() Then
        '        ref = rs("IdReferencia").ToString.Trim
        '        lbAuxPedido.Text = rs("IdPedido")
        '        If LabPedido.Text = "" Or (lbRef.Text <> ref) Then
        '            If LabPedido.Text.Count > 0 Then
        '                lblErrorPedido.Text = "ERROR. ARTICULO DIFERENTE." & vbCrLf & vbCrLf & "مختلف مضامین کی خرابی۔" & vbCrLf & vbCrLf & vbCrLf & vbCrLf & "Pulsar * para cancelar alarma." & vbCrLf & "الارم کو منسوخ کرنے کے لیے * کو دبائیں۔"
        '                lblErrorPedido.Visible = True 'TODO error tag
        '                My.Computer.Audio.Play("\\192.168.0.22\AppSala\SoundAPP\ambul1.wav", AudioPlayMode.BackgroundLoop) 'TODO AUDIO Reproduce un sonido hasta
        '            End If
        '            tmrParpadeo.Start()
        '            tmrOnParpadeo.Start()
        '            ConnectToServerSala.Close()
        '            Etiqueta.Refresh()
        '            Etiqueta.DatosEtiquetaImpresion(Val(LabPedido.Text), 1, CadenaConexionProduccion) 'TODO mod_centrado_blanco
        '            Select Case LectorX
        '                Case 0

        '                Case 1
        '                    pnEtiqIzq.Visible = True
        '                    pnPaqueteIzq.Visible = False
        '                    EtiqIzq.DatosEtiqueta(lbAuxPedido.Text, 4, CadenaConexionProduccion)
        '                Case 2
        '                    pnEtiqDer.Visible = True
        '                    pnPaqueteDer.Visible = False
        '                    EtiqDer.DatosEtiqueta(lbAuxPedido.Text, 4, CadenaConexionProduccion)
        '            End Select
        '            If LabPedido.Text.Trim.Count = 8 And LabNCP.Text.Trim.Count > 0 Then 'TODO
        '                introduceRegistroSaco(LabPedido.Text.Trim, Paquete, LabNCP.Text.Trim, 0, auxTAG)
        '            End If
        '            Exit Sub
        '        End If

        '        Agujeros = IIf(IsDBNull(rs("Agujeros")), 0, rs("Agujeros")) 'rs("Agujeros")
        '        Select Case Agujeros
        '            Case 0
        '                TAgujeros = "O"
        '            Case 1
        '                TAgujeros = "I"
        '            Case 2
        '                TAgujeros = "Z"
        '            Case 3
        '                TAgujeros = "E"
        '            Case Else
        '                TAgujeros = "M"
        '        End Select
        '        Cabezal = rs("Tira")
        '        Posicion = rs("NoPosicion")
        '        Nota = rs("Nota")
        '        'If lbNNoHayPedido.Visible = False Then
        '        '    HayPedido = True
        '        'End If
        '    End If
        '    rs.Close() 'TODO lector
        '    ConnectToServerSala.Close()
        'Catch ex As Exception
        '    ExecuteSqlTransactionRegistroError(My.Computer.Name & ". ERROR EtiquetaPrensa. Error en AltaTag --> VerTAGIdSaco(). Error:" + ex.Message.ToString()) 'TODO try cath
        'End Try
        Dim ref As String = "Referencia"
        Try
            ConnectToServerSala.Open()
            Using strSQL As New SqlCommand("SELECT dbo.Articulos.IdPedido, dbo.Sacos.Tira, dbo.Sacos.Agujeros, dbo.Articulos.IdReferencia, dbo.Pedidos.Nota, dbo.PosNueva.NoPosicion 
                                            FROM dbo.Sacos 
                                            INNER JOIN dbo.Articulos ON dbo.Sacos.IdNumFicha = dbo.Articulos.NumFicha 
                                            INNER JOIN dbo.Pedidos ON dbo.Articulos.IdPedido = dbo.Pedidos.IdPedido 
                                            INNER JOIN dbo.PosNueva ON dbo.Articulos.SalaPos = dbo.PosNueva.Posicion
                                            WHERE dbo.Sacos.IdSaco = @Paquete", ConnectToServerSala)
                strSQL.Parameters.AddWithValue("@Paquete", Paquete)
                Using rs As SqlDataReader = strSQL.ExecuteReader()
                    lblErrorPedido.Visible = False 'TODO error tag
                    If rs.Read() Then
                        ref = rs("IdReferencia").ToString().Trim()
                        lbAuxPedido.Text = rs("IdPedido").ToString()
                        If String.IsNullOrEmpty(LabPedido.Text) OrElse (lbRef.Text <> ref) Then
                            If LabPedido.Text.Length > 0 Then
                                lblErrorPedido.Text = "ERROR. ARTICULO DIFERENTE." & vbCrLf & vbCrLf & "مختلف مضامین کی خرابی۔" & vbCrLf & vbCrLf & vbCrLf & vbCrLf & "Pulsar * para cancelar alarma." & vbCrLf & "الارم کو منسوخ کرنے کے لیے * کو دبائیں۔"
                                lblErrorPedido.Visible = True
                                My.Computer.Audio.Play("\\192.168.0.22\AppSala\SoundAPP\ambul1.wav", AudioPlayMode.BackgroundLoop)
                            End If
                            tmrParpadeo.Start()
                            tmrOnParpadeo.Start()
                            Etiqueta.Refresh()
                            Etiqueta.DatosEtiquetaImpresion(Val(LabPedido.Text), 1, CadenaConexionProduccion)
                            Select Case LectorX
                                Case 1
                                    pnEtiqIzq.Visible = True
                                    pnPaqueteIzq.Visible = False
                                    EtiqIzq.DatosEtiqueta(lbAuxPedido.Text, 4, CadenaConexionProduccion)
                                Case 2
                                    pnEtiqDer.Visible = True
                                    pnPaqueteDer.Visible = False
                                    EtiqDer.DatosEtiqueta(lbAuxPedido.Text, 4, CadenaConexionProduccion)
                            End Select
                            If LabPedido.Text.Trim().Length = 8 AndAlso LabNCP.Text.Trim().Length > 0 Then
                                introduceRegistroSaco(LabPedido.Text.Trim(), Paquete, LabNCP.Text.Trim(), 0, auxTAG)
                            End If
                            Exit Sub
                        End If

                        Agujeros = If(IsDBNull(rs("Agujeros")), 0, Convert.ToInt32(rs("Agujeros")))
                        Select Case Agujeros
                            Case 0 : TAgujeros = "O"
                            Case 1 : TAgujeros = "I"
                            Case 2 : TAgujeros = "Z"
                            Case 3 : TAgujeros = "E"
                            Case Else : TAgujeros = "M"
                        End Select
                        Cabezal = rs("Tira")
                        Posicion = rs("NoPosicion")
                        Nota = rs("Nota")
                    End If
                End Using
            End Using
        Catch ex As Exception
            ExecuteSqlTransactionRegistroError(My.Computer.Name & ". ERROR EtiquetaPrensa. Error en AltaTag --> VerTAGIdSaco(). Error:" & ex.Message)
        Finally
            If ConnectToServerSala.State = ConnectionState.Open Then
                ConnectToServerSala.Close()
            End If
        End Try
        If HayPedido Then
            Etiqueta.Refresh()
            Etiqueta.DatosEtiquetaImpresion(Val(LabPedido.Text), 1, CadenaConexionProduccion) 'TODO mod_centrado_blanco
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
                        If LabPedido.Text.Trim.Count = 8 And LabNCP.Text.Trim.Count > 0 Then 'TODO
                            introduceRegistroSaco(LabPedido.Text.Trim, Paquete, LabNCP.Text.Trim, 1, auxTAG)
                        End If
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
                        If LabPedido.Text.Trim.Count = 8 And LabNCP.Text.Trim.Count > 0 Then 'TODO
                            introduceRegistroSaco(LabPedido.Text.Trim, Paquete, LabNCP.Text.Trim, 1, auxTAG)
                        End If
                    End If
            End Select
            'If (lbRef.Text <> ref) Then
            '    Select Case LectorX
            '        Case 0

            '        Case 1
            '            pnEtiqIzq.Visible = True
            '            pnPaqueteIzq.Visible = False
            '            EtiqIzq.DatosEtiqueta(lbAuxPedido.Text, 4, CadenaConexionProduccion)
            '        Case 2
            '            pnEtiqDer.Visible = True
            '            pnPaqueteDer.Visible = False
            '            EtiqDer.DatosEtiqueta(lbAuxPedido.Text, 4, CadenaConexionProduccion)
            '    End Select
            'End If

        End If
        'HayPedido = False
    End Sub
    'Private Sub GuardaPrensa(ByVal Paquete As String)
    '    Dim strSQL As SqlCommand
    '    Dim rs As SqlDataReader
    '    Etiqueta.Refresh()
    '    Try
    '        ConnectToServerSala.Open()
    '        strSQL = New SqlCommand("EXEC GuardaPrensa " & Paquete & "," & Val(LabNCP.Text), ConnectToServerSala)
    '        rs = strSQL.ExecuteReader
    '        rs.Close() 'TODO lector
    '        ConnectToServerSala.Close()
    '    Catch ex As Exception
    '        ExecuteSqlTransactionRegistroError(My.Computer.Name & ". ERROR EtiquetaPrensa. Error en AltaTag --> GuardaPrensa(). Error:" + ex.Message.ToString()) 'TODO try cath
    '    End Try
    'End Sub
    Private Sub GuardaPrensa(ByVal Paquete As String)
        Etiqueta.Refresh()
        Try
            If ConnectToServerSala.State <> ConnectionState.Open Then
                ConnectToServerSala.Open()
            End If
            Using strSQL As New SqlCommand("EXEC GuardaPrensa @Paquete, @NCP", ConnectToServerSala)
                strSQL.Parameters.AddWithValue("@Paquete", Paquete)
                strSQL.Parameters.AddWithValue("@NCP", Val(LabNCP.Text))
                strSQL.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            ExecuteSqlTransactionRegistroError(My.Computer.Name & ". ERROR EtiquetaPrensa. Error en AltaTag --> GuardaPrensa(). Error:" & ex.Message)
        Finally
            If ConnectToServerSala.State = ConnectionState.Open Then
                ConnectToServerSala.Close()
            End If
        End Try
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

    'Private Sub EtiquetaTermica1()
    '    lbErrImpDer.Visible = False
    '    Try
    '        Shell("C:\Program Files (x86)\Godex\GoLabel\GoLabel.exe -f ""\\192.168.0.22\AppSala\ImpresoraGodex\Etiquetas\Prensa\lbPrensa_NCP.ezpx"" -i ""GodexDerecha"" -V00 """ &
    '              MRef(1) & """ " &
    '              " -V01 """ & MColor(1) & """ " &
    '              " -V02 """ & MMetrosItem(1) & """ " &
    '              " -V03 """ & MPaquete(1) & """ " &
    '              " -V04 """ & MCabezal(1) & """ " &
    '              " -V05 """ & MPosicion(1) & """ " &
    '              " -V06 """ & MTAgujeros(1) & """ " &
    '              " -V07 """ & MNota(1) & """ " &
    '              " -V08 """ & MTextoEtiqueta(1) & """ " &
    '              " -V09 """ & operarioNCP & """ ")
    '    Catch
    '        lbErrImpDer.Visible = True
    '    End Try
    'End Sub

    Private Sub EtiquetaTermica1()
        lbErrImpDer.Visible = False
        Try
            ' Construir el comando de forma eficiente usando StringBuilder para evitar concatenaciones costosas
            Dim sb As New StringBuilder(512)
            sb.Append("C:\Program Files (x86)\Godex\GoLabel\GoLabel.exe -f ""\\192.168.0.22\AppSala\ImpresoraGodex\Etiquetas\Prensa\lbPrensa_NCP.ezpx"" -i ""GodexDerecha""")
            sb.AppendFormat(" -V00 ""{0}""", MRef(1))
            sb.AppendFormat(" -V01 ""{0}""", MColor(1))
            sb.AppendFormat(" -V02 ""{0}""", MMetrosItem(1))
            sb.AppendFormat(" -V03 ""{0}""", MPaquete(1))
            sb.AppendFormat(" -V04 ""{0}""", MCabezal(1))
            sb.AppendFormat(" -V05 ""{0}""", MPosicion(1))
            sb.AppendFormat(" -V06 ""{0}""", MTAgujeros(1))
            sb.AppendFormat(" -V07 ""{0}""", MNota(1))
            sb.AppendFormat(" -V08 ""{0}""", MTextoEtiqueta(1))
            sb.AppendFormat(" -V09 ""{0}""", operarioNCP)

            Shell(sb.ToString())
        Catch
            lbErrImpDer.Visible = True
        End Try
    End Sub
    Private Sub Timer4_Tick(sender As Object, e As EventArgs) Handles Timer4.Tick
        Label13.Text = ""
        Label14.Text = ""
        Timer4.Stop()
    End Sub

    'Private Sub EtiquetaTermica()
    '    lbErrImpIzq.Visible = False
    '    Try
    '        Shell("C:\Program Files (x86)\Godex\GoLabel\GoLabel.exe -f ""\\192.168.0.22\AppSala\ImpresoraGodex\Etiquetas\Prensa\lbPrensa_NCP.ezpx"" -i ""GodexIzquierda"" -V00 """ &
    '              MRef(0) & """ " &
    '              " -V01 """ & MColor(0) & """ " &
    '              " -V02 """ & MMetrosItem(0) & """ " &
    '              " -V03 """ & MPaquete(0) & """ " &
    '              " -V04 """ & MCabezal(0) & """ " &
    '              " -V05 """ & MPosicion(0) & """ " &
    '              " -V06 """ & MTAgujeros(0) & """ " &
    '              " -V07 """ & MNota(0) & """ " &
    '              " -V08 """ & MTextoEtiqueta(0) & """ " &
    '              " -V09 """ & operarioNCP & """ ")
    '    Catch
    '        lbErrImpIzq.Visible = True
    '    End Try
    'End Sub

    Private Sub EtiquetaTermica()
        lbErrImpIzq.Visible = False
        Try
            ' Optimización: Usar StringBuilder para construir el comando de forma eficiente
            Dim sb As New System.Text.StringBuilder(512)
            sb.Append("C:\Program Files (x86)\Godex\GoLabel\GoLabel.exe -f ""\\192.168.0.22\AppSala\ImpresoraGodex\Etiquetas\Prensa\lbPrensa_NCP.ezpx"" -i ""GodexIzquierda""")
            sb.AppendFormat(" -V00 ""{0}""", MRef(0))
            sb.AppendFormat(" -V01 ""{0}""", MColor(0))
            sb.AppendFormat(" -V02 ""{0}""", MMetrosItem(0))
            sb.AppendFormat(" -V03 ""{0}""", MPaquete(0))
            sb.AppendFormat(" -V04 ""{0}""", MCabezal(0))
            sb.AppendFormat(" -V05 ""{0}""", MPosicion(0))
            sb.AppendFormat(" -V06 ""{0}""", MTAgujeros(0))
            sb.AppendFormat(" -V07 ""{0}""", MNota(0))
            sb.AppendFormat(" -V08 ""{0}""", MTextoEtiqueta(0))
            sb.AppendFormat(" -V09 ""{0}""", operarioNCP)
            Shell(sb.ToString())
        Catch
            lbErrImpIzq.Visible = True
        End Try
    End Sub

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

    Private Sub lbNNoHayPedido_Click(sender As Object, e As EventArgs) Handles lbNNoHayPedido.Click

    End Sub

    Private Sub AltaTAG_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        '' al cerrar el formulario, quitar el gancho del teclado
        'UnHookKeyB()
    End Sub

    Private Sub mostrarCajasStockPedido(listCajas As List(Of CajaStockModel)) '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim posicionPalet As String = ""
        Dim contador As Integer = 0
        posicionPalet = listCajas(0).PosicionPalet1
        For Index = 0 To listCajas.Count - 1
            If posicionPalet.Equals(listCajas(Index).PosicionPalet1) Then
                contador = contador + 1
            Else
                lblResultadoCajasStockPedido.Text += "En el palet número: " + listCajas(Index - 1).PosicionPalet1.ToString() + ", hay " + contador.ToString() + " caja/s del artículo: " + listCajas(Index - 1).Articulo1.ToString().Trim() + " y color: " + listCajas(Index - 1).Colore1.ToString().Trim() + "." + vbCrLf
                posicionPalet = listCajas(Index).PosicionPalet1
                contador = 1
            End If
            'lblResultadoBusqueda.Text += "En el palet número: " + listCajas(index).PosicionPalet1.ToString() + ", hay " + contador.ToString() + " caja/s del artículo: " + listCajas(index).Articulo1.ToString().Trim() + " y color: " + listCajas(index).Colore1.ToString().Trim() + "." + vbCrLf
        Next
        lblResultadoCajasStockPedido.Text += "En el palet número: " + listCajas(listCajas.Count() - 1).PosicionPalet1.ToString() + ", hay " + contador.ToString() + " caja/s del artículo: " + listCajas(listCajas.Count() - 1).Articulo1.ToString().Trim() + " y color: " + listCajas(listCajas.Count() - 1).Colore1.ToString().Trim() + "." + vbCrLf
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

    'Private Sub introduceRegistroSaco(ByVal Pedido As String, ByVal IdSaco As String, ByVal NCP As Integer, ByVal isOK As Int32, ByVal Tag As String) 'TODO
    '    Dim strSQL As SqlCommand
    '    Dim rs As SqlDataReader
    '    Dim query As String
    '    query = "INSERT INTO [dbo].[RegistroPrensaSaco] ([IdPedido],[IdSaco],[NCP],[isCorrecto],[Tag],[Prensa]) VALUES  ('" & Pedido & "', '" & IdSaco & "', " & NCP & ", " & isOK & ",'" & Tag & "','" & My.Computer.Name.ToString() & "')"
    '    Try
    '        ConnectToServerSala.Open()
    '        strSQL = New SqlCommand(query, ConnectToServerSala)
    '        rs = strSQL.ExecuteReader
    '        rs.Close() 'TODO lector
    '    Catch ex As Exception
    '        ExecuteSqlTransactionRegistroError(My.Computer.Name & ". ERROR EtiquetaPrensa. Error en AltaTag --> introduceRegistroSaco(). Error:" + ex.Message.ToString()) 'TODO try cath
    '        MessageBox.Show("Error al guardar registro del saco, en tabla RegistroPrensaSaco. Error --> introduceRegistroSaco" & ex.Message.ToString)
    '    Finally
    '        ConnectToServerSala.Close()
    '    End Try
    'End Sub

    Private Sub introduceRegistroSaco(ByVal Pedido As String, ByVal IdSaco As String, ByVal NCP As Integer, ByVal isOK As Int32, ByVal Tag As String)
        Try
            If ConnectToServerSala.State <> ConnectionState.Open Then
                ConnectToServerSala.Open()
            End If
            Using strSQL As New SqlCommand("INSERT INTO [dbo].[RegistroPrensaSaco] ([IdPedido],[IdSaco],[NCP],[isCorrecto],[Tag],[Prensa]) VALUES (@Pedido, @IdSaco, @NCP, @isOK, @Tag, @Prensa)", ConnectToServerSala)
                strSQL.Parameters.AddWithValue("@Pedido", Pedido)
                strSQL.Parameters.AddWithValue("@IdSaco", IdSaco)
                strSQL.Parameters.AddWithValue("@NCP", NCP)
                strSQL.Parameters.AddWithValue("@isOK", isOK)
                strSQL.Parameters.AddWithValue("@Tag", Tag)
                strSQL.Parameters.AddWithValue("@Prensa", My.Computer.Name.ToString())
                strSQL.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            ExecuteSqlTransactionRegistroError(My.Computer.Name & ". ERROR EtiquetaPrensa. Error en AltaTag --> introduceRegistroSaco(). Error:" & ex.Message)
            MessageBox.Show("Error al guardar registro del saco, en tabla RegistroPrensaSaco. Error --> introduceRegistroSaco" & ex.Message)
        Finally
            If ConnectToServerSala.State = ConnectionState.Open Then
                ConnectToServerSala.Close()
            End If
        End Try
    End Sub

#Region "Mostrar Posiciones de fabricación"
    Private Sub LabPedido_TextChanged(sender As Object, e As EventArgs) Handles LabPedido.TextChanged
        lblPosicionesFabricacion.Text = ""
        lblEnProduccion.Text = ""
        lblPosicionesFabricacion.Visible = False
        lblEnProduccion.Visible = False

        Dim listaposicionesFabricacion As List(Of Integer)
        Dim isProduccion As Boolean
        If Len(LabPedido.Text) = 8 Then
            'obtenemos los datos
            listaposicionesFabricacion = obtenerPosicionesFabricacion(LabPedido.Text)
            isProduccion = isEnProduccion(LabPedido.Text)

            Try
                Label16.Text = Repositorio_.obtenerObservacionesPedido(LabPedido.Text) 'ERROR
            Catch ex As Exception

            End Try

            If listaposicionesFabricacion.Count > 0 Then
                lblPosicionesFabricacion.Visible = True
                lblEnProduccion.Visible = True
                If isProduccion Then
                    lblEnProduccion.Text = "En producción"
                Else
                    lblEnProduccion.Text = "No esta en producción"
                End If
                lblPosicionesFabricacion.Text += "Fabricado en: "
                For Each Posicion In listaposicionesFabricacion
                    lblPosicionesFabricacion.Text += Posicion.ToString + " "
                Next

            End If
        End If
    End Sub

    'Function obtenerPosicionesFabricacion(ByVal pedido As String) As List(Of Integer)
    '    Dim query As String
    '    Dim listaposicionesFabricacion As List(Of Integer)
    '    Dim strSQL As SqlCommand
    '    Dim cnn As SqlConnection

    '    Try
    '        query = "SELECT dbo.PosNueva.NewPosicion FROM dbo.Pedidos INNER JOIN dbo.Articulos ON dbo.Pedidos.IdPedido = dbo.Articulos.IdPedido INNER JOIN dbo.PosNueva ON dbo.Articulos.SalaPos = dbo.PosNueva.Posicion WHERE dbo.Pedidos.IdPedido = "
    '        listaposicionesFabricacion = New List(Of Integer)
    '        cnn = New SqlConnection(CadenaConexionProduccion)
    '        strSQL = New SqlCommand(query & pedido, cnn)
    '        cnn.Open()
    '        Dim rs As SqlDataReader

    '        rs = strSQL.ExecuteReader

    '        While (rs.Read)
    '            Dim auxPosicion As Integer
    '            auxPosicion = 0
    '            auxPosicion = rs.GetInt32(0)
    '            listaposicionesFabricacion.Add(auxPosicion)
    '        End While
    '        Return listaposicionesFabricacion
    '        cnn.Close()
    '        rs.Close()
    '    Catch ex As Exception
    '        MsgBox("Error: Procedimiento, query en obtenerPosicionesFabricacion." & vbCrLf + ex.Message)
    '    End Try

    'End Function

    Function obtenerPosicionesFabricacion(ByVal pedido As String) As List(Of Integer)
        Dim listaPosiciones As New List(Of Integer)
        Dim query As String = "SELECT dbo.PosNueva.NewPosicion FROM dbo.Pedidos " &
                              "INNER JOIN dbo.Articulos ON dbo.Pedidos.IdPedido = dbo.Articulos.IdPedido " &
                              "INNER JOIN dbo.PosNueva ON dbo.Articulos.SalaPos = dbo.PosNueva.Posicion " &
                              "WHERE dbo.Pedidos.IdPedido = @pedido"
        Try
            Using cnn As New SqlConnection(CadenaConexionProduccion)
                Using cmd As New SqlCommand(query, cnn)
                    cmd.Parameters.AddWithValue("@pedido", pedido)
                    cnn.Open()
                    Using rs As SqlDataReader = cmd.ExecuteReader()
                        While rs.Read()
                            If Not rs.IsDBNull(0) Then
                                listaPosiciones.Add(rs.GetInt32(0))
                            End If
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MsgBox("Error: Procedimiento, query en obtenerPosicionesFabricacion." & vbCrLf & ex.Message)
        End Try
        Return listaPosiciones
    End Function

    'Function isEnProduccion(ByVal pedido As String) As Boolean
    '    Dim query As String
    '    Dim strSQL As SqlCommand
    '    Dim cnn As SqlConnection
    '    Dim aux As Boolean
    '    Try
    '        aux = False
    '        query = "SELECT dbo.Articulos.EnProduccion FROM dbo.Pedidos INNER JOIN dbo.Articulos ON dbo.Pedidos.IdPedido = dbo.Articulos.IdPedido INNER JOIN dbo.PosNueva ON dbo.Articulos.SalaPos = dbo.PosNueva.Posicion WHERE dbo.Pedidos.IdPedido ="
    '        cnn = New SqlConnection(CadenaConexionProduccion)
    '        strSQL = New SqlCommand(query & pedido, cnn)
    '        cnn.Open()
    '        Dim rs As SqlDataReader
    '        rs = strSQL.ExecuteReader

    '        If (rs.Read) Then
    '            aux = rs.GetBoolean(0)
    '        End If
    '        Return aux
    '        cnn.Close()
    '        rs.Close()
    '    Catch ex As Exception
    '        MsgBox("Error: Procedimiento, query en obtenerPosicionesFabricacion." & vbCrLf + ex.Message)
    '    End Try

    'End Function

    Function isEnProduccion(ByVal pedido As String) As Boolean
        Dim aux As Boolean = False
        Dim query As String = "SELECT TOP 1 dbo.Articulos.EnProduccion FROM dbo.Pedidos " &
                              "INNER JOIN dbo.Articulos ON dbo.Pedidos.IdPedido = dbo.Articulos.IdPedido " &
                              "WHERE dbo.Pedidos.IdPedido = @pedido"
        Try
            Using cnn As New SqlConnection(CadenaConexionProduccion)
                Using cmd As New SqlCommand(query, cnn)
                    cmd.Parameters.AddWithValue("@pedido", pedido)
                    cnn.Open()
                    Using rs As SqlDataReader = cmd.ExecuteReader()
                        If rs.Read() AndAlso Not rs.IsDBNull(0) Then
                            aux = rs.GetBoolean(0)
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MsgBox("Error: Procedimiento, query en isEnProduccion." & vbCrLf & ex.Message)
        End Try
        Return aux
    End Function

#Region "Imprimir etiquetas"
    Private Sub imprimirEtiquetaCaja()
        Dim doc As Drawing.Printing.PrintDocument = New Drawing.Printing.PrintDocument()
        AddHandler doc.PrintPage, AddressOf PrintDocument1_PrintPage
        doc.Print()
    End Sub

    Private Sub PrintDocument1_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Dim bmp As Bitmap = New Bitmap(Panel1.Width, Panel1.Height, Panel1.CreateGraphics())
        Panel1.DrawToBitmap(bmp, New Rectangle(0, 0, Panel1.Width, Panel1.Height))
        Dim bounds As RectangleF = e.PageSettings.PrintableArea
        Dim factor = CSng(bmp.Height) / CSng(bmp.Width)
        e.Graphics.DrawImage(bmp, bounds.Left, bounds.Top, bounds.Width, factor * bounds.Width)



        'Dim R As Rectangle
        'Dim Rm As Rectangle
        'Dim myGraphics As Graphics = Panel1.CreateGraphics()
        'Dim s As Size = Panel1.Size
        'Dim memoryImage As Bitmap

        'R = New Rectangle(0, 0, s.Width, s.Height)
        ''Rm = New Rectangle(0, 0, R.Width / 2, R.Height / 2)
        'Rm = New Rectangle(0, 0, R.Width, R.Height)
        'memoryImage = New Bitmap(s.Width, s.Height, myGraphics)
        'Panel1.DrawToBitmap(memoryImage, R)
        'e.Graphics.DrawImage(memoryImage, Rm)
    End Sub

    Private Sub TimerActualizaTrazabilidad_Tick(sender As Object, e As EventArgs) Handles TimerActualizaTrazabilidad.Tick
        If Not String.IsNullOrEmpty(LabPedido.Text) Then
            Dim repo = New Repositorio() '''''''''''''''''''''''''''''''''''''''''''''''''''''''
            DatosSacosProduccion = repo.obtenerDatosSacos(LabPedido.Text.Trim()) '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''MOD
            Dim grafica1 As Grafica = New Grafica()
            Dim grafica2 As Grafica = New Grafica()
            RadChartView1.Series.Clear()
            RadChartView2.Series.Clear()
            grafica1.CrearGrafica(RadChartView1, DatosSacosProduccion.SacosPrensados1,
                                    DatosSacosProduccion.SacosNoPrensados1, "Sacos prensados", "Sacos sin prensar", "SACOS PRENSADOS")
            grafica2.CrearGrafica(RadChartView2, DatosSacosProduccion.SacosFabricados1,
                                    DatosSacosProduccion.SacosPorFabricar1, "Sacos fabricados", "Sacos por fabricar", "SACOS FABRICADOS")
            lblTotalSacos.Text = "CANTIDAD TOTAL DE SACOS DEL PEDIDO: " & DatosSacosProduccion.SacosTotalPedido1 & " SACOS"
        End If
    End Sub

#End Region


#End Region

    Private Sub mostrarDatosSaco(saco As DatosSacoTagModel)
        If saco IsNot Nothing Then
            lblTira.Text = "Tira: " + saco.Tira1.ToString.Trim
            lblPeso.Text = "Peso: " + saco.Peso1.ToString.Trim + " Kg"
            lblAgujeros.Text = "Agujeros: " + saco.Agujeros1.ToString.Trim
            lblDiaPesa.Text = "Día pesa: " + saco.DiaPesa1.ToString.Trim
            lblNombrePesa.Text = "Nombre pesa: " + saco.NombrePesa1.ToString.Trim
            lblPosicion.Text = "Posicion: " + saco.Posicion1.ToString.Trim
        End If
    End Sub

    'Private Function obtenerCadenaConexionProduccion() As String
    '    Dim auxCadenaConexion As String = ""

    '    Try
    '        'Pass the file path and file name to the StreamReader constructor
    '        Dim sr As StreamReader = New StreamReader("\\SERVERSALA\SIE\ArchivosConexion\ArchivoConexionProduccion.txt")
    '        'Read the first line of text
    '        auxCadenaConexion = sr.ReadLine()
    '        'close the file
    '        sr.Close()

    '    Catch e As Exception
    '        MessageBox.Show("Error. No se ha podido cargar el archivo de conexión producción. --> " + e.Message.ToString())
    '    Finally
    '        'Console.WriteLine("Executing finally block.")
    '    End Try
    '    Return auxCadenaConexion
    'End Function

    Private Function obtenerCadenaConexionProduccion() As String
        Dim auxCadenaConexion As String = ""
        Dim sr As StreamReader = Nothing

        Try
            sr = New StreamReader("\\SERVERSALA\SIE\ArchivosConexion\ArchivoConexionProduccion.txt")
            auxCadenaConexion = sr.ReadLine()
        Catch ex As Exception
            MessageBox.Show("Error. No se ha podido cargar el archivo de conexión producción. --> " & ex.Message)
        Finally
            If sr IsNot Nothing Then
                sr.Dispose()
            End If
        End Try
        Return auxCadenaConexion
    End Function

    'CAPTURA ERRORES
    'Public Shared Function ExecuteSqlTransactionRegistroError(ByVal RegistroError As String)
    '    Using connection As SqlConnection = New SqlConnection(CadenaConexionProduccion)
    '        connection.Open()
    '        Dim command As SqlCommand = connection.CreateCommand()
    '        Dim transaction As SqlTransaction = Nothing
    '        command.Connection = connection
    '        command.Transaction = transaction
    '        Try
    '            RegistroError = RegistroError.Replace("'", "")

    '            command.CommandText = "Insert into [dbo].[RegistroErroresForms] (DescripcionError) VALUES ('" & RegistroError & "')"
    '            command.ExecuteNonQuery()

    '        Catch ex As Exception
    '            Console.WriteLine("Commit Exception Type: {0}", ex.[GetType]())
    '            Console.WriteLine("  Message: {0}", ex.Message)

    '            Try
    '                transaction.Rollback()
    '            Catch ex2 As Exception
    '                Console.WriteLine("Rollback Exception Type: {0}", ex2.[GetType]())
    '                Console.WriteLine("  Message: {0}", ex2.Message)
    '            End Try
    '        End Try
    '    End Using
    'End Function

    Public Shared Sub ExecuteSqlTransactionRegistroError(ByVal RegistroError As String)
        ' Optimización: Eliminar el uso innecesario de transacciones y simplificar el manejo de errores
        Try
            Using connection As New SqlConnection(CadenaConexionProduccion)
                connection.Open()
                Using command As New SqlCommand("INSERT INTO [dbo].[RegistroErroresForms] (DescripcionError) VALUES (@DescripcionError)", connection)
                    ' Evitar problemas de inyección y de comillas usando parámetros
                    command.Parameters.AddWithValue("@DescripcionError", RegistroError.Replace("'", ""))
                    command.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            ' Log en consola, pero sin intentar rollback (no hay transacción)
            Console.WriteLine("Error al registrar en RegistroErroresForms: {0}", ex.Message)
        End Try
    End Sub


End Class
