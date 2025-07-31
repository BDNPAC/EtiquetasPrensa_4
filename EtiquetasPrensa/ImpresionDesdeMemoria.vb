
Imports System
    Imports System.Windows.Forms
    Imports System.Drawing
    Imports System.Drawing.Printing
    Imports System.Drawing.Graphics
    Imports System.Drawing.Imaging
Imports System.Runtime.InteropServices
Imports ControlesFrancesc.Etiqueta

Public Class ImpresionDesdeMemoria
    'Inherits Form
    Private WithEvents printDocument1 As New PrintDocument
    Dim pkSource As PaperSource
    Dim memoryImage As Bitmap
    Dim Etiqueta As ControlesFrancesc.Etiqueta


    Private Sub printDocument1_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles printDocument1.PrintPage
        Dim R As Rectangle
        Dim Rm As Rectangle
        Dim myGraphics As Graphics = Panel1.CreateGraphics()
        Dim s As Size = Panel1.Size

        R = New Rectangle(0, 0, s.Width, s.Height)
        'Rm = New Rectangle(0, 0, R.Width / 2, R.Height / 2)
        Rm = New Rectangle(0, 0, R.Width, R.Height)
        memoryImage = New Bitmap(s.Width, s.Height, myGraphics)
        Panel1.DrawToBitmap(memoryImage, R)
        e.Graphics.DrawImage(memoryImage, Rm)
    End Sub

    Public Sub ImprimeCaja()

        printDocument1.DefaultPageSettings.PaperSource = printDocument1.PrinterSettings.PaperSources.Item(0) ' 0 Frontal ,1 Trasera
        printDocument1.Print()
    End Sub


    Private Sub ImpresionEtiquetaCajaAntigua_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Etiqueta = New ControlesFrancesc.Etiqueta
        Panel1.Controls.Add(Etiqueta)
        Etiqueta.Location = New Point(10, 0)
        'Etiqueta.Tipo(0.5, 1)
        Etiqueta.DatosEtiquetaImpresion(AltaTAG.LabPedido.Text, 1, AltaTAG.CadenaConexionProduccion)
        Etiqueta.SumaCaja(AltaTAG.LabPedido.Text)
        Etiqueta.Refresh()
        printDocument1 = New Printing.PrintDocument
        comboPaperSource.DisplayMember = "SourceName"

        For i = 0 To printDocument1.PrinterSettings.PaperSources.Count - 1
            pkSource = printDocument1.PrinterSettings.PaperSources.Item(i)
            comboPaperSource.Items.Add(pkSource)
        Next

    End Sub



End Class
