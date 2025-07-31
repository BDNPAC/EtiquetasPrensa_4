Imports Telerik.WinControls.UI
Imports Telerik.Charting

Public Class Grafica
    Public Sub CrearGrafica(grafica As Telerik.WinControls.UI.RadChartView, datoA As Integer, datoB As Integer, tituloDatoA As String, tituloDatoB As String, titulo As String)

        grafica.AreaType = ChartAreaType.Pie
        Dim series As New PieSeries()

        series.DataPoints.Add(New PieDataPoint(datoA, tituloDatoA & " " & datoA))
        series.DataPoints.Add(New PieDataPoint(datoB, tituloDatoB & " " & datoB))

        series.ShowLabels = False
        grafica.Series.Add(series)

        grafica.Title = titulo
        grafica.ShowTitle = True

        grafica.ShowLegend = True
        ' grafica.LegendTitle = "Legend"

        grafica.Controllers.Add(New SmartLabelsController())
        grafica.ShowSmartLabels = True

        grafica.Area.View.Palette = KnownPalette.Summer



        Dim point As PieDataPoint = TryCast(series.DataPoints(1), PieDataPoint)
        If point IsNot Nothing Then
            point.OffsetFromCenter = 0.1
        End If
    End Sub
End Class
