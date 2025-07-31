Imports System.Data
Imports System.Data.SqlClient
Public Class MarcadorHorario
    Public NTAG As String
    Public NCP As Integer
    Dim NoMarcar As Integer = 0
    Dim Causa As Integer
    Dim Hoy As Date

    Private Sub MarcadorHorario_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        'Circulares.Timer1.Stop()
    End Sub

    Private Sub MarcadorHorario_Deactivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Deactivate
        'Circulares.Timer1.Start()
    End Sub

    Private Sub MarcadorHorario_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        'Func.ControlTeclado(e.KeyCode, 11)
        If (e.KeyCode = Keys.Escape) Then
            Me.Close()
        End If
        If (e.KeyCode = Keys.Add) And (NoMarcar = 1) Then
            Marcado(NTAG, IIf(Causa = 1, 2, 1))
            NoMarcar += 1
        End If
        TimerVentana.Stop()
        TimerVentana.Start()
    End Sub

    Private Sub MarcadorHorario_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Hoy = Now
        Me.KeyPreview = True
        Hora.Text = DateTime.Now.ToString("T")
        TextoDia.Text = StrConv(WeekdayName(IIf(Date.Now.DayOfWeek = 0, 7, Date.Now.DayOfWeek)), VbStrConv.ProperCase) & ", " & Date.Now.Day & " de " & StrConv(MonthName(Date.Now.Month), VbStrConv.ProperCase) & " de " & Date.Now.Year
        PulsaMas.Visible = False
        TimerVentana.Start()
        BuscaNombreYCalendario(NTAG)
        BuscaMarcasHorario(NTAG)
        BuscaUltimaEntradaSalida(NTAG)
        'Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
    End Sub

    Private Sub TimerVentana_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerVentana.Tick
        Me.Close()
    End Sub
    'Private Sub BuscaMarcasHorario(ByVal NTAG As String)
    '    If IsNothing(NTAG) Then Exit Sub
    '    Dim Columna As Integer
    '    Dim Fila As Integer
    '    DataGridHoras.Rows.Clear()
    '    'Dim cnn As New SqlConnection("Data Source=80.37.184.226,1433;Network Library=DBMSSOCN; Initial Catalog=Produccion;User ID=sa;")
    '    Dim strSQL As SqlCommand
    '    Dim rs As SqlDataReader
    '    Dim cnn As New SqlConnection(AltaTAG.CadenaConexionProduccion)
    '    strSQL = New SqlCommand
    '    strSQL.Connection = cnn
    '    strSQL.CommandType = CommandType.StoredProcedure
    '    strSQL.CommandText = "HorasSemanaOperario"
    '    strSQL.Parameters.Add(New SqlParameter("@NTAG", SqlDbType.VarChar, 12))
    '    strSQL.Parameters("@NTAG").Value = NTAG
    '    strSQL.Parameters.Add(New SqlParameter("@Semana", SqlDbType.Int))
    '    strSQL.Parameters("@Semana").Value = DatePart(DateInterval.WeekOfYear, Now, FirstDayOfWeek.Monday, FirstWeekOfYear.Jan1)
    '    strSQL.Parameters.Add(New SqlParameter("Año", SqlDbType.Int))
    '    strSQL.Parameters("Año").Value = Date.Now.Year

    '    Try
    '        cnn.Open()
    '        rs = strSQL.ExecuteReader
    '        DataGridHoras.DefaultCellStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, CType((System.Drawing.FontStyle.Regular Or System.Drawing.FontStyle.Regular), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))

    '        Dim ColorFila As Color
    '        Dim Retraso As Integer
    '        While rs.Read
    '            Dim Causa As Integer = IIf(IsDBNull(rs("Causa")), 0, rs("Causa"))
    '            If Causa = 1 Then
    '                ColorFila = IIf(ColorFila = Color.Aqua, Color.White, Color.Aqua)
    '            End If
    '            DataGridHoras.Rows.Add()
    '            DataGridHoras.Rows(Fila).DefaultCellStyle.BackColor = ColorFila
    '            DataGridHoras.Rows(Fila).Cells(Columna).Value = rs("Semana")
    '            DataGridHoras.Item(Columna, Fila).Style.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))

    '            Columna += 1
    '            DataGridHoras.Rows(Fila).Cells(Columna).Value = rs("Dia")
    '            DataGridHoras.Item(Columna, Fila).Style.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))

    '            Columna += 1
    '            DataGridHoras.Rows(Fila).Cells(Columna).Value = rs("Marca")
    '            Columna += 1

    '            If (Fila > 1) AndAlso (DataGridHoras.Rows(Fila - 2).Cells(1).Value Is DataGridHoras.Rows(Fila).Cells(1).Value) Then
    '                DataGridHoras.Rows(Fila).Cells(Columna).Value = rs("Hora1IO")
    '            Else
    '                DataGridHoras.Rows(Fila).Cells(Columna).Value = rs("HoraIO")
    '            End If

    '            Columna += 1
    '            'If (rs("Retraso") < 59) And (rs("Causa") = 1) Then

    '            'DataGridHoras.Rows(Fila).Cells(Columna).Value = -1 * Int(rs("Retraso") / 60) & " min."
    '            'DataGridHoras.Item(Columna, Fila).Style.BackColor = Color.Red
    '            'DataGridHoras.Item(Columna, Fila).Style.ForeColor = Color.White
    '            'DataGridHoras.Item(Columna, Fila).Style.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    '            'Else
    '            'DataGridHoras.Item(Columna, Fila).Style.BackColor = Color.White
    '            'End If
    '            Causa = IIf(IsDBNull(rs("Causa")), 0, rs("Causa"))
    '            If Causa = 1 Then
    '                Retraso = DateDiff("s", Convert.ToDateTime(DataGridHoras.Rows(Fila).Cells(2).Value), Convert.ToDateTime(DataGridHoras.Rows(Fila).Cells(3).Value))
    '            Else
    '                Retraso = DateDiff("s", Convert.ToDateTime(DataGridHoras.Rows(Fila).Cells(3).Value), Convert.ToDateTime(DataGridHoras.Rows(Fila).Cells(2).Value))
    '            End If
    '            If Retraso < -59 Then
    '                DataGridHoras.Rows(Fila).Cells(Columna).Value = -1 * (1 + Int(Retraso / 60)) & " min."
    '                DataGridHoras.Item(Columna, Fila).Style.BackColor = Color.Red
    '                DataGridHoras.Item(Columna, Fila).Style.ForeColor = Color.White
    '                DataGridHoras.Item(Columna, Fila).Style.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    '            Else
    '                DataGridHoras.Rows(Fila).Cells(Columna).Value = " "
    '                DataGridHoras.Item(Columna, Fila).Style.BackColor = Color.White
    '            End If
    '            Fila += 1
    '            Columna = 0
    '        End While
    '        DataGridHoras.Size = New System.Drawing.Size(345, IIf((20 + (Fila * 22)) > 490, 490, (20 + (Fila * 22))))
    '        rs.Close() 'TODO lector
    '        cnn.Dispose()
    '    Catch ex As Exception
    '        AltaTAG.ExecuteSqlTransactionRegistroError(My.Computer.Name & ". ERROR EtiquetaPrensa. Error en MarcadorHorario --> BuscaMarcasHorario(). Error:" + ex.Message.ToString()) 'TODO try cath
    '        'DataGridHoras.Visible = False
    '        'Horario.Visible = False
    '        'NomOperario.Text = "Número operario: "
    '        'NCP = ""
    '    End Try

    'End Sub

    Private Sub BuscaMarcasHorario(ByVal NTAG As String)
        If String.IsNullOrEmpty(NTAG) Then Exit Sub

        DataGridHoras.Rows.Clear()

        Using cnn As New SqlConnection(AltaTAG.CadenaConexionProduccion)
            Using strSQL As New SqlCommand("HorasSemanaOperario", cnn)
                strSQL.CommandType = CommandType.StoredProcedure
                strSQL.Parameters.Add(New SqlParameter("@NTAG", SqlDbType.VarChar, 12)).Value = NTAG
                strSQL.Parameters.Add(New SqlParameter("@Semana", SqlDbType.Int)).Value = DatePart(DateInterval.WeekOfYear, Now, FirstDayOfWeek.Monday, FirstWeekOfYear.Jan1)
                strSQL.Parameters.Add(New SqlParameter("@Año", SqlDbType.Int)).Value = Date.Now.Year

                Try
                    cnn.Open()
                    Using rs As SqlDataReader = strSQL.ExecuteReader()
                        DataGridHoras.DefaultCellStyle.Font = New Font("Microsoft Sans Serif", 10.0!, FontStyle.Regular, GraphicsUnit.Point)

                        Dim fila As Integer = 0
                        Dim colorFila As Color = Color.White

                        While rs.Read()
                            Dim causa As Integer = If(IsDBNull(rs("Causa")), 0, CInt(rs("Causa")))
                            If causa = 1 Then colorFila = If(colorFila = Color.Aqua, Color.White, Color.Aqua)

                            DataGridHoras.Rows.Add()
                            Dim currentRow = DataGridHoras.Rows(fila)
                            currentRow.DefaultCellStyle.BackColor = colorFila

                            currentRow.Cells(0).Value = rs("Semana")
                            currentRow.Cells(1).Value = rs("Dia")
                            currentRow.Cells(2).Value = rs("Marca")
                            currentRow.Cells(3).Value = If(fila > 1 AndAlso DataGridHoras.Rows(fila - 2).Cells(1).Value.Equals(currentRow.Cells(1).Value), rs("Hora1IO"), rs("HoraIO"))

                            Dim retraso As Integer = If(causa = 1,
                                DateDiff(DateInterval.Second, Convert.ToDateTime(currentRow.Cells(2).Value), Convert.ToDateTime(currentRow.Cells(3).Value)),
                                DateDiff(DateInterval.Second, Convert.ToDateTime(currentRow.Cells(3).Value), Convert.ToDateTime(currentRow.Cells(2).Value)))

                            Dim retrasoCell = currentRow.Cells(4)
                            If retraso < -59 Then
                                retrasoCell.Value = $"{-1 * (1 + retraso \ 60)} min."
                                retrasoCell.Style.BackColor = Color.Red
                                retrasoCell.Style.ForeColor = Color.White
                                retrasoCell.Style.Font = New Font("Microsoft Sans Serif", 12.0!, FontStyle.Bold Or FontStyle.Italic, GraphicsUnit.Point)
                            Else
                                retrasoCell.Value = " "
                                retrasoCell.Style.BackColor = Color.White
                            End If

                            fila += 1
                        End While

                        DataGridHoras.Size = New Size(345, Math.Min(490, 20 + (fila * 22)))
                    End Using
                Catch ex As Exception
                    AltaTAG.ExecuteSqlTransactionRegistroError($"{My.Computer.Name}. ERROR SALACIRCULARES. Error en MarcadorHorario --> BuscaMarcasHorario(). Error: {ex.Message}")
                End Try
            End Using
        End Using
    End Sub
    Private Sub XBuscaMarcasHorario(ByVal NTAG As String)

        Dim Columna As Integer
        Dim Fila As Integer
        DataGridHoras.Rows.Clear()
        'Dim cnn As New SqlConnection("Data Source=80.37.184.226,1433;Network Library=DBMSSOCN; Initial Catalog=Produccion;User ID=sa;")
        Dim strSQL As SqlCommand
        Dim rs As SqlDataReader
        Dim cnn As New SqlConnection(AltaTAG.CadenaConexionProduccion)
        strSQL = New SqlCommand
        strSQL.Connection = cnn
        strSQL.CommandType = CommandType.StoredProcedure
        strSQL.CommandText = "HorasSemanaOperario"
        strSQL.Parameters.Add(New SqlParameter("@NTAG", SqlDbType.VarChar, 12))
        strSQL.Parameters("@NTAG").Value = NTAG
        strSQL.Parameters.Add(New SqlParameter("@Semana", SqlDbType.Int))
        strSQL.Parameters("@Semana").Value = DatePart(DateInterval.WeekOfYear, Now, FirstDayOfWeek.Monday, FirstWeekOfYear.Jan1)
        strSQL.Parameters.Add(New SqlParameter("Año", SqlDbType.Int))
        strSQL.Parameters("Año").Value = Date.Now.Year
        Try
            cnn.Open()

            rs = strSQL.ExecuteReader
            Dim Retraso As Integer = 0
            Dim Causa As Integer = 0
            While rs.Read
                DataGridHoras.Rows.Add()
                DataGridHoras.Rows(Fila).Cells(Columna).Value = rs("Semana")
                Columna += 1
                DataGridHoras.Rows(Fila).Cells(Columna).Value = rs("Dia")
                Columna += 1
                DataGridHoras.Rows(Fila).Cells(Columna).Value = rs("Marca")
                Columna += 1
                DataGridHoras.Rows(Fila).Cells(Columna).Value = rs("HoraIO")
                Columna += 1
                Retraso = IIf(IsDBNull(rs("Retraso")), 0, rs("Retraso"))
                Causa = IIf(IsDBNull(rs("Causa")), 0, rs("Causa"))
                If (Retraso < 59) And (Causa = 1) Then

                    DataGridHoras.Rows(Fila).Cells(Columna).Value = -1 * Int(Retraso / 60) & " minutos"

                End If

                Fila += 1
                Columna = 0
            End While
            DataGridHoras.Size = New System.Drawing.Size(392, 20 + (Fila * 22))
            rs.Close() 'TODO lector
            cnn.Dispose()
        Catch ex As Exception
            AltaTAG.ExecuteSqlTransactionRegistroError(My.Computer.Name & ". ERROR EtiquetaPrensa. Error en MarcadorHorario --> XBuscaMarcasHorario(). Error:" + ex.Message.ToString()) 'TODO try cath
        End Try
    End Sub
    'Private Sub BuscaNombreYCalendario(ByVal NTAG As String)
    '    If IsNothing(NTAG) Then Exit Sub
    '    Dim strSQL As SqlCommand
    '    Dim rs As SqlDataReader
    '    Dim cnn As New SqlConnection(AltaTAG.CadenaConexionProduccion)
    '    strSQL = New SqlCommand
    '    strSQL.Connection = cnn
    '    strSQL.CommandType = CommandType.StoredProcedure
    '    strSQL.CommandText = "TAG_NombreOperario"
    '    strSQL.Parameters.Add(New SqlParameter("@NTAG", SqlDbType.VarChar, 12))
    '    strSQL.Parameters("@NTAG").Value = NTAG
    '    Try
    '        cnn.Open()
    '        rs = strSQL.ExecuteReader
    '        rs.Read()
    '        Dim Calendario As String = IIf(IsDBNull(rs("Calendario")), "", rs("Calendario"))
    '        NomOperario.Text = rs("Nombre")
    '        Horario.Text = "Horario : " & Calendario
    '        HoraEntra1.Text = rs("HoraEntra1")
    '        HoraSale1.Text = rs("HoraSale1")
    '        HoraEntra2.Text = rs("HoraEntra2")
    '        HoraSale2.Text = rs("HoraSale2")

    '        If HoraEntra1.Text = HoraEntra2.Text Then
    '            Label3.Visible = False
    '            Label4.Visible = False
    '            HoraEntra2.Visible = False
    '            HoraSale2.Visible = False
    '            Horario.Size = New System.Drawing.Size(247, 92)

    '        Else
    '            Label3.Visible = True
    '            Label4.Visible = True
    '            HoraEntra2.Visible = True
    '            HoraSale2.Visible = True
    '            Horario.Size = New System.Drawing.Size(247, 141)
    '        End If
    '        rs.Close() 'TODO lector
    '        cnn.Dispose()
    '    Catch ex As Exception
    '        AltaTAG.ExecuteSqlTransactionRegistroError(My.Computer.Name & ". ERROR EtiquetaPrensa. Error en MarcadorHorario --> BuscaNombreYCalendario(). Error:" + ex.Message.ToString()) 'TODO try cath
    '    End Try

    'End Sub

    Private Sub BuscaNombreYCalendario(ByVal NTAG As String)
        If String.IsNullOrEmpty(NTAG) Then Exit Sub

        Using cnn As New SqlConnection(AltaTAG.CadenaConexionProduccion)
            Using strSQL As New SqlCommand("TAG_NombreOperario", cnn)
                strSQL.CommandType = CommandType.StoredProcedure
                strSQL.Parameters.Add(New SqlParameter("@NTAG", SqlDbType.VarChar, 12)).Value = NTAG

                Try
                    cnn.Open()
                    Using rs As SqlDataReader = strSQL.ExecuteReader()
                        If rs.Read() Then
                            Dim calendario As String = If(IsDBNull(rs("Calendario")), String.Empty, rs("Calendario").ToString())
                            NomOperario.Text = rs("Nombre").ToString()
                            Horario.Text = $"Horario : {calendario}"
                            HoraEntra1.Text = rs("HoraEntra1").ToString()
                            HoraSale1.Text = rs("HoraSale1").ToString()
                            HoraEntra2.Text = rs("HoraEntra2").ToString()
                            HoraSale2.Text = rs("HoraSale2").ToString()

                            Dim isSingleShift As Boolean = HoraEntra1.Text = HoraEntra2.Text
                            Label3.Visible = Not isSingleShift
                            Label4.Visible = Not isSingleShift
                            HoraEntra2.Visible = Not isSingleShift
                            HoraSale2.Visible = Not isSingleShift
                            Horario.Size = New System.Drawing.Size(247, If(isSingleShift, 92, 141))
                        End If
                    End Using
                Catch ex As Exception
                    AltaTAG.ExecuteSqlTransactionRegistroError($"{My.Computer.Name}. ERROR SALACIRCULARES. Error en MarcadorHorario --> BuscaNombreYCalendario(). Error: {ex.Message}")
                End Try
            End Using
        End Using
    End Sub
    'Private Sub BuscaUltimaEntradaSalida(ByVal NTAG As String)

    '    Dim strSQL As SqlCommand
    '    Dim rs As SqlDataReader
    '    Dim cnn As New SqlConnection(AltaTAG.CadenaConexionProduccion)
    '    UltimaMarca.Text = ""
    '    strSQL = New SqlCommand
    '    strSQL.Connection = cnn
    '    strSQL.CommandType = CommandType.StoredProcedure
    '    strSQL.CommandText = "UltimaEntrada_Salida"
    '    strSQL.Parameters.Add(New SqlParameter("@NTAG", SqlDbType.VarChar, 12))
    '    strSQL.Parameters("@NTAG").Value = NTAG
    '    Try
    '        cnn.Open()

    '        rs = strSQL.ExecuteReader

    '        If rs.Read() Then
    '            Dim FechaInOut As Date
    '            'FechaInOut = New Date
    '            FechaInOut = rs("DiaHora")
    '            Causa = rs("Causa")
    '            Dim DiaMesAno As String = FechaInOut.ToString("dd/mm/yyyy")
    '            Dim DiaMesAnoT As String = FechaInOut.ToString("T")
    '            UltimaMarca.Text = IIf(Causa = 1, "Ultima entrada el dia: ", "Ultima salida el dia: ")
    '            UltimaMarca.Text = UltimaMarca.Text & DiaMesAno & " a las " & DiaMesAnoT
    '            rs.Close() 'TODO lector
    '            cnn.Dispose()

    '            If Val(DateDiff(DateInterval.Minute, FechaInOut, Now())) < 60 Then

    '                Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
    '                Label5.Text = "Has marcado hace: " & DateDiff(DateInterval.Minute, FechaInOut, Now()) & " minutos"
    '                Label5.Visible = True
    '                NoMarcar += 1
    '                PulsaMas.Visible = True

    '            Else
    '                Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
    '                Label5.Visible = False
    '                PulsaMas.Visible = False
    '                NoMarcar = 0
    '                Marcado(NTAG, IIf(Causa = 1, 2, 1))
    '            End If
    '        Else
    '            Me.BackColor = System.Drawing.Color.Fuchsia
    '            Label5.Visible = False
    '            PulsaMas.Visible = False
    '            NoMarcar = 0
    '            Marcado(NTAG, 1)
    '        End If
    '    Catch ex As Exception
    '        AltaTAG.ExecuteSqlTransactionRegistroError(My.Computer.Name & ". ERROR EtiquetaPrensa. Error en MarcadorHorario --> BuscaUltimaEntradaSalida(). Error:" + ex.Message.ToString()) 'TODO try cath
    '    End Try
    'End Sub

    Private Sub BuscaUltimaEntradaSalida(ByVal NTAG As String)
        UltimaMarca.Text = ""
        Me.BackColor = System.Drawing.Color.Fuchsia
        Label5.Visible = False
        PulsaMas.Visible = False
        NoMarcar = 0

        Using cnn As New SqlConnection(AltaTAG.CadenaConexionProduccion)
            Using strSQL As New SqlCommand("UltimaEntrada_Salida", cnn)
                strSQL.CommandType = CommandType.StoredProcedure
                strSQL.Parameters.Add(New SqlParameter("@NTAG", SqlDbType.VarChar, 12)).Value = NTAG

                Try
                    cnn.Open()
                    Using rs As SqlDataReader = strSQL.ExecuteReader()
                        If rs.Read() Then
                            Dim FechaInOut As Date = rs("DiaHora")
                            Causa = rs("Causa")
                            UltimaMarca.Text = $"{If(Causa = 1, "Ultima entrada el dia: ", "Ultima salida el dia: ")}{FechaInOut:dd/MM/yyyy} a las {FechaInOut:T}"

                            Dim minutosTranscurridos = DateDiff(DateInterval.Minute, FechaInOut, Now())
                            If minutosTranscurridos < 60 Then
                                Me.BackColor = System.Drawing.Color.FromArgb(255, 128, 128)
                                Label5.Text = $"Has marcado hace: {minutosTranscurridos} minutos"
                                Label5.Visible = True
                                NoMarcar += 1
                                PulsaMas.Visible = True
                            Else
                                Me.BackColor = System.Drawing.Color.FromArgb(128, 255, 128)
                                Marcado(NTAG, If(Causa = 1, 2, 1))
                            End If
                        Else
                            Marcado(NTAG, 1)
                        End If
                    End Using
                Catch ex As Exception
                    AltaTAG.ExecuteSqlTransactionRegistroError($"{My.Computer.Name}. ERROR SALACIRCULARES. Error en MarcadorHorario --> BuscaUltimaEntradaSalida(). Error: {ex.Message}")
                End Try
            End Using
        End Using
    End Sub

    'Private Sub Marcado(ByVal NTAG As String, ByVal Causa As Integer)
    '    Dim strSQL As SqlCommand
    '    Dim cnn As New SqlConnection(AltaTAG.CadenaConexionProduccion)
    '    strSQL = New SqlCommand
    '    strSQL.Connection = cnn
    '    strSQL.CommandType = CommandType.StoredProcedure
    '    strSQL.CommandText = "MarcaInOut"

    '    strSQL.Parameters.Add(New SqlParameter("@NTAG", SqlDbType.VarChar, 12))
    '    strSQL.Parameters("@NTAG").Value = NTAG

    '    strSQL.Parameters.Add(New SqlParameter("@Causa", SqlDbType.VarChar, 12))
    '    strSQL.Parameters("@Causa").Value = Causa

    '    strSQL.Parameters.Add(New SqlParameter("@Sala", SqlDbType.VarChar, 12))
    '    strSQL.Parameters("@Sala").Value = 2
    '    Try
    '        cnn.Open()
    '        strSQL.ExecuteNonQuery()
    '        cnn.Dispose()
    '    Catch ex As Exception
    '        AltaTAG.ExecuteSqlTransactionRegistroError(My.Computer.Name & ". ERROR EtiquetaPrensa. Error en MarcadorHorario --> Marcado(). Error:" + ex.Message.ToString()) 'TODO try cath
    '    End Try
    '    BuscaMarcasHorario(NTAG)
    'End Sub

    'Private Sub Marcado(ByVal NTAG As String, ByVal Causa As Integer)
    '    Dim hostName As String = ""
    '    hostName = My.Computer.Name.Trim
    '    Dim strSQL As SqlCommand
    '    Dim cnn As New SqlConnection(AltaTAG.CadenaConexionProduccion)
    '    strSQL = New SqlCommand
    '    strSQL.Connection = cnn
    '    strSQL.CommandType = CommandType.StoredProcedure
    '    strSQL.CommandText = "MarcaInOutMOD"

    '    strSQL.Parameters.Add(New SqlParameter("@NTAG", SqlDbType.VarChar, 12))
    '    strSQL.Parameters("@NTAG").Value = NTAG

    '    strSQL.Parameters.Add(New SqlParameter("@Causa", SqlDbType.VarChar, 12))
    '    strSQL.Parameters("@Causa").Value = Causa

    '    strSQL.Parameters.Add(New SqlParameter("@Sala", SqlDbType.VarChar, 12))
    '    strSQL.Parameters("@Sala").Value = 2

    '    strSQL.Parameters.Add(New SqlParameter("@HostName", SqlDbType.VarChar, 50))
    '    strSQL.Parameters("@HostName").Value = hostName
    '    Try
    '        cnn.Open()
    '        strSQL.ExecuteNonQuery()
    '        cnn.Dispose()
    '    Catch ex As Exception
    '        AltaTAG.ExecuteSqlTransactionRegistroError(My.Computer.Name & ". ERROR EtiquetaPrensa. Error en MarcadorHorario --> Marcado(). Error:" + ex.Message.ToString()) 'TODO try cath
    '    End Try
    '    BuscaMarcasHorario(NTAG)
    'End Sub

    Private Sub Marcado(ByVal NTAG As String, ByVal Causa As Integer)
        Dim hostName As String = My.Computer.Name.Trim()

        Using cnn As New SqlConnection(AltaTAG.CadenaConexionProduccion)
            Using strSQL As New SqlCommand("MarcaInOutMOD", cnn)
                strSQL.CommandType = CommandType.StoredProcedure
                strSQL.Parameters.Add(New SqlParameter("@NTAG", SqlDbType.VarChar, 12)).Value = NTAG
                strSQL.Parameters.Add(New SqlParameter("@Causa", SqlDbType.VarChar, 12)).Value = Causa
                strSQL.Parameters.Add(New SqlParameter("@Sala", SqlDbType.VarChar, 12)).Value = 2
                strSQL.Parameters.Add(New SqlParameter("@HostName", SqlDbType.VarChar, 50)).Value = hostName

                Try
                    cnn.Open()
                    strSQL.ExecuteNonQuery()
                Catch ex As Exception
                    AltaTAG.ExecuteSqlTransactionRegistroError($"{My.Computer.Name}. ERROR EtiquetaPrensa. Error en MarcadorHorario --> Marcado(). Error: {ex.Message}")
                End Try
            End Using
        End Using

        BuscaMarcasHorario(NTAG)
    End Sub
    Private Sub DataGridHoras_CellPainting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles DataGridHoras.CellPainting
        'el e.columnindex son las columnas que checara para ver si se pueden combinar las celdas iguales

        If e.ColumnIndex = 0 Or e.ColumnIndex = 1 Or e.ColumnIndex = 4 AndAlso e.RowIndex <> -1 Then

            Using gridBrush As Brush = New SolidBrush(Me.DataGridHoras.GridColor), backColorBrush As Brush = New SolidBrush(e.CellStyle.BackColor)

                Using gridLinePen As Pen = New Pen(gridBrush)
                    e.Graphics.FillRectangle(backColorBrush, e.CellBounds)

                    If e.RowIndex < DataGridHoras.Rows.Count - 2 AndAlso DataGridHoras.Rows(e.RowIndex + 1).Cells(e.ColumnIndex).Value.ToString() <> e.Value.ToString() Then
                        e.Graphics.DrawLine(gridLinePen, e.CellBounds.Left, e.CellBounds.Bottom - 1, e.CellBounds.Right - 1, e.CellBounds.Bottom - 1)
                    End If

                    e.Graphics.DrawLine(gridLinePen, e.CellBounds.Right - 1, e.CellBounds.Top, e.CellBounds.Right - 1, e.CellBounds.Bottom)

                    If Not e.Value Is Nothing Then
                        If e.RowIndex > 0 AndAlso DataGridHoras.Rows(e.RowIndex - 1).Cells(e.ColumnIndex).Value.ToString() = e.Value.ToString() Then
                        Else
                            e.Graphics.DrawString(CType(e.Value, String), e.CellStyle.Font, Brushes.Black, e.CellBounds.X + 2, e.CellBounds.Y, StringFormat.GenericDefault)
                        End If
                    End If

                    e.Handled = True
                End Using
            End Using
        End If
    End Sub
    Private Sub Reloj_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Reloj.Tick
        Hora.Text = DateTime.Now.ToString("T")
    End Sub
   
End Class