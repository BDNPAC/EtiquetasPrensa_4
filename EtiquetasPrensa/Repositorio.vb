Imports System.Data.SqlClient

Public Class Repositorio
    Dim auxArticulo As String
    Dim auxColor As String
    Dim auxMetros As Integer
    Dim cnn As SqlConnection
    'Dim query As String = "SELECT  dbo.CajasStockQR.Articulo, dbo.CajasStockQR.Color, dbo.CajasStockQR.metrosSaco, dbo.CajasStockQR.metrosCaja, dbo.PaletsStockQR.Posicion " &
    '    "FROM dbo.CajasStockQR INNER JOIN  dbo.PaletsStockQR ON dbo.CajasStockQR.PaletId = dbo.PaletsStockQR.Id " &
    '    "WHERE (dbo.CajasStockQR.Articulo = '" & auxArticulo & "') AND (dbo.CajasStockQR.Color = '" & auxColor & "') AND (dbo.CajasStockQR.metrosSaco = " & auxMetros & ")"

    'Dim cadenaConexion As String = "Persist Security Info=False;User ID=sa;Initial Catalog=Produccion; Data Source=SERVERSALA; "

    'Public Function comprobarPedido(Articulo As String, Colore As String, Metros As Integer) As List(Of CajaStockModel)
    '    Dim strSQL As SqlCommand
    '    Dim rs As SqlDataReader
    '    Dim caja As CajaStockModel
    '    Dim list = New List(Of CajaStockModel)
    '    auxArticulo = Articulo
    '    auxColor = Colore
    '    auxMetros = Metros
    '    Using cnn As New SqlConnection(AltaTAG.CadenaConexionProduccion)
    '        Try
    '            cnn.Open()
    '            strSQL = New SqlCommand("SELECT dbo.CajasStockQR.Id, dbo.CajasStockQR.Articulo, dbo.CajasStockQR.Color, dbo.CajasStockQR.metrosSaco, dbo.CajasStockQR.metrosCaja, dbo.PaletsStockQR.Posicion " &
    '    "FROM dbo.CajasStockQR INNER JOIN  dbo.PaletsStockQR ON dbo.CajasStockQR.PaletId = dbo.PaletsStockQR.Id " &
    '    "WHERE (dbo.CajasStockQR.Articulo = '" & auxArticulo & "') AND (dbo.CajasStockQR.Color = '" & auxColor & "') AND (dbo.CajasStockQR.metrosSaco = " & auxMetros & ") AND (dbo.CajasStockQR.visible = 1) Order by dbo.PaletsStockQR.Posicion", cnn)
    '            rs = strSQL.ExecuteReader
    '            While rs.Read()
    '                caja = New CajaStockModel()
    '                caja.Id1 = rs("Id")
    '                caja.Articulo1 = rs("Articulo")
    '                caja.Colore1 = rs("Color")
    '                caja.Metros1 = rs("metrosSaco")
    '                caja.MetrosCaja1 = rs("metrosCaja")
    '                caja.PosicionPalet1 = rs("Posicion")
    '                list.Add(caja)
    '            End While
    '            rs.Close() 'TODO lector
    '            Return list
    '        Catch ex As Exception
    '            AltaTAG.ExecuteSqlTransactionRegistroError(My.Computer.Name & ". ERROR EtiquetaPrensa. Error en Repositorio --> comprobarPedido(). Error:" + ex.Message.ToString()) 'TODO try cath
    '            MsgBox("Error: Procedimiento. En el query APP FichaCircular (repositorio)." & vbCrLf + ex.Message)
    '        End Try
    '    End Using
    'End Function
    'Public Function obtenerParametrosFromPedido(Pedido As String) As AuxCajaStockModel
    '    Dim strSQL As SqlCommand
    '    Dim rs As SqlDataReader
    '    Dim auxCaja As AuxCajaStockModel

    '    Using cnn As New SqlConnection(AltaTAG.CadenaConexionProduccion)
    '        Try
    '            cnn.Open()
    '            strSQL = New SqlCommand("SELECT dbo.Pedidos.MetrosSaco, dbo.Pedidos.MetrosCaja, dbo.Articulos.Color" +
    '                                    ", dbo.Articulos.Articulo FROM dbo.Articulos INNER JOIN dbo.Pedidos ON " +
    '                                    "dbo.Articulos.IdPedido = dbo.Pedidos.IdPedido WHERE dbo.Pedidos.IdPedido = " & "'" & Pedido & "'", cnn)
    '            rs = strSQL.ExecuteReader
    '            While rs.Read()
    '                auxCaja = New AuxCajaStockModel()
    '                auxCaja.Articulo1 = rs("Articulo")
    '                auxCaja.Colore1 = rs("Color")
    '                auxCaja.Metros1 = rs("metrosSaco")
    '                auxCaja.MetrosCaja1 = rs("metrosCaja")
    '            End While
    '            rs.Close() 'TODO lector
    '            Return auxCaja
    '        Catch ex As Exception
    '            AltaTAG.ExecuteSqlTransactionRegistroError(My.Computer.Name & ". ERROR EtiquetaPrensa. Error en Repositorio --> obtenerParametrosFromPedido(). Error:" + ex.Message.ToString()) 'TODO try cath
    '            MsgBox("Error: Procedimiento. En el query obtener AuxCajaStock (repositorio)." & vbCrLf + ex.Message)
    '        End Try
    '    End Using
    'End Function
    Public Function comprobarPedido(Articulo As String, Colore As String, Metros As Integer) As List(Of CajaStockModel)
        Dim lista As New List(Of CajaStockModel)()

        ' Usar parámetros para evitar SQL Injection y mejorar el rendimiento del plan de ejecución
        Dim query As String = "SELECT c.Id, c.Articulo, c.Color, c.metrosSaco, c.metrosCaja, p.Posicion " &
                          "FROM dbo.CajasStockQR c INNER JOIN dbo.PaletsStockQR p ON c.PaletId = p.Id " &
                          "WHERE c.Articulo = @Articulo AND c.Color = @Color AND c.metrosSaco = @Metros AND c.visible = 1 " &
                          "ORDER BY p.Posicion"

        Using cnn As New SqlConnection(AltaTAG.CadenaConexionProduccion)
            Try
                cnn.Open()
                Using cmd As New SqlCommand(query, cnn)
                    cmd.Parameters.AddWithValue("@Articulo", Articulo)
                    cmd.Parameters.AddWithValue("@Color", Colore)
                    cmd.Parameters.AddWithValue("@Metros", Metros)

                    Using rs As SqlDataReader = cmd.ExecuteReader()
                        While rs.Read()
                            Dim caja As New CajaStockModel() With {
                            .Id1 = rs("Id"),
                            .Articulo1 = rs("Articulo"),
                            .Colore1 = rs("Color"),
                            .Metros1 = rs("metrosSaco"),
                            .MetrosCaja1 = rs("metrosCaja"),
                            .PosicionPalet1 = rs("Posicion")
                        }
                            lista.Add(caja)
                        End While
                    End Using
                End Using
                Return lista
            Catch ex As Exception
                AltaTAG.ExecuteSqlTransactionRegistroError(My.Computer.Name & ". ERROR EtiquetaPrensa. Error en Repositorio --> comprobarPedido(). Error:" + ex.Message)
                MsgBox("Error: Procedimiento. En el query APP FichaCircular (repositorio)." & vbCrLf & ex.Message)
                Return lista
            End Try
        End Using
    End Function

    Public Function obtenerParametrosFromPedido(Pedido As String) As AuxCajaStockModel
        Dim auxCaja As AuxCajaStockModel = Nothing

        ' Usar parámetros para evitar SQL Injection y mejorar el rendimiento del plan de ejecución
        Dim query As String = "SELECT p.MetrosSaco, p.MetrosCaja, a.Color, a.Articulo " &
                          "FROM dbo.Articulos a INNER JOIN dbo.Pedidos p ON a.IdPedido = p.IdPedido " &
                          "WHERE p.IdPedido = @Pedido"

        Using cnn As New SqlConnection(AltaTAG.CadenaConexionProduccion)
            Try
                cnn.Open()
                Using cmd As New SqlCommand(query, cnn)
                    cmd.Parameters.AddWithValue("@Pedido", Pedido)
                    Using rs As SqlDataReader = cmd.ExecuteReader()
                        If rs.Read() Then
                            auxCaja = New AuxCajaStockModel() With {
                            .Articulo1 = rs("Articulo"),
                            .Colore1 = rs("Color"),
                            .Metros1 = rs("metrosSaco"),
                            .MetrosCaja1 = rs("metrosCaja")
                        }
                        End If
                    End Using
                End Using
                Return auxCaja
            Catch ex As Exception
                AltaTAG.ExecuteSqlTransactionRegistroError(My.Computer.Name & ". ERROR EtiquetaPrensa. Error en Repositorio --> obtenerParametrosFromPedido(). Error:" + ex.Message)
                MsgBox("Error: Procedimiento. En el query obtener AuxCajaStock (repositorio)." & vbCrLf & ex.Message)
                Return Nothing
            End Try
        End Using
    End Function

    'Public Function actualizarNCPEnlacePrensa(ncp As Integer, numeroPrensaUno As Integer, numeroPrensaDos As Integer)
    '    Dim query As String = "UPDATE [dbo].[EnlacePrensas] SET [NCP] = " & ncp & " WHERE [Posicion] = '" & numeroPrensaUno & "' OR [Posicion] = '" & numeroPrensaDos & "'"

    '    Using cnn As New SqlConnection(AltaTAG.CadenaConexionProduccion)
    '        Try
    '            cnn.Open()
    '            Using command As SqlCommand = New SqlCommand(query, cnn)
    '                command.ExecuteNonQuery()
    '            End Using

    '        Catch ex As Exception
    '            AltaTAG.ExecuteSqlTransactionRegistroError(My.Computer.Name & ". ERROR EtiquetaPrensa. Error en Repositorio --> actualizarNCPEnlacePrensaA(). Error:" + ex.Message.ToString()) 'TODO try cath
    '            MsgBox("Error: Procedimiento. En el metodo actualizarNCPEnlacePrensa." & vbCrLf + ex.Message)
    '        End Try
    '    End Using
    'End Function

    'Public Function actualizarNCPEnlacePrensa(ncp As Integer, numeroPrensaUno As Integer, numeroPrensaDos As Integer, numeroPrensaTres As Integer)

    '    Dim query As String = "UPDATE [dbo].[EnlacePrensas] SET [NCP] = " & ncp & " WHERE [Posicion] = '" & numeroPrensaUno & "' OR [Posicion] = '" & numeroPrensaDos & "' OR [Posicion] = '" & numeroPrensaTres & "'"

    '    Using cnn As New SqlConnection(AltaTAG.CadenaConexionProduccion)
    '        Try
    '            cnn.Open()
    '            Using command As SqlCommand = New SqlCommand(query, cnn)
    '                command.ExecuteNonQuery()
    '            End Using
    '        Catch ex As Exception
    '            AltaTAG.ExecuteSqlTransactionRegistroError(My.Computer.Name & ". ERROR EtiquetaPrensa. Error en Repositorio --> actualizarNCPEnlacePrensaB(). Error:" + ex.Message.ToString()) 'TODO try cath
    '            MsgBox("Error: Procedimiento. En el metodo actualizarNCPEnlacePrensa." & vbCrLf + ex.Message)
    '        End Try
    '    End Using
    'End Function

    Public Function actualizarNCPEnlacePrensa(ncp As Integer, numeroPrensaUno As Integer, numeroPrensaDos As Integer) As Boolean
        Dim query As String = "UPDATE [dbo].[EnlacePrensas] SET [NCP] = @NCP WHERE [Posicion] = @Pos1 OR [Posicion] = @Pos2"

        Using cnn As New SqlConnection(AltaTAG.CadenaConexionProduccion)
            Try
                cnn.Open()
                Using command As New SqlCommand(query, cnn)
                    command.Parameters.AddWithValue("@NCP", ncp)
                    command.Parameters.AddWithValue("@Pos1", numeroPrensaUno)
                    command.Parameters.AddWithValue("@Pos2", numeroPrensaDos)
                    command.ExecuteNonQuery()
                End Using
                Return True
            Catch ex As Exception
                AltaTAG.ExecuteSqlTransactionRegistroError(My.Computer.Name & ". ERROR EtiquetaPrensa. Error en Repositorio --> actualizarNCPEnlacePrensaA(). Error:" & ex.Message)
                MsgBox("Error: Procedimiento. En el metodo actualizarNCPEnlacePrensa." & vbCrLf & ex.Message)
                Return False
            End Try
        End Using
    End Function

    Public Function actualizarNCPEnlacePrensa(ncp As Integer, numeroPrensaUno As Integer, numeroPrensaDos As Integer, numeroPrensaTres As Integer) As Boolean
        Dim query As String = "UPDATE [dbo].[EnlacePrensas] SET [NCP] = @NCP WHERE [Posicion] = @Pos1 OR [Posicion] = @Pos2 OR [Posicion] = @Pos3"

        Using cnn As New SqlConnection(AltaTAG.CadenaConexionProduccion)
            Try
                cnn.Open()
                Using command As New SqlCommand(query, cnn)
                    command.Parameters.AddWithValue("@NCP", ncp)
                    command.Parameters.AddWithValue("@Pos1", numeroPrensaUno)
                    command.Parameters.AddWithValue("@Pos2", numeroPrensaDos)
                    command.Parameters.AddWithValue("@Pos3", numeroPrensaTres)
                    command.ExecuteNonQuery()
                End Using
                Return True
            Catch ex As Exception
                AltaTAG.ExecuteSqlTransactionRegistroError(My.Computer.Name & ". ERROR EtiquetaPrensa. Error en Repositorio --> actualizarNCPEnlacePrensaB(). Error:" & ex.Message)
                MsgBox("Error: Procedimiento. En el metodo actualizarNCPEnlacePrensa." & vbCrLf & ex.Message)
                Return False
            End Try
        End Using
    End Function

    'Public Function obtenerDatosSacos(Pedido As String) As DatosSacoModel
    '    Dim aux As DatosSacoModel
    '    aux = New DatosSacoModel()
    '    Using cnn As New SqlConnection(AltaTAG.CadenaConexionProduccion)
    '        Try
    '            cnn.Open()
    '            Using command As SqlCommand = New SqlCommand("SELECT Count(*) as Total FROM dbo.Sacos INNER JOIN dbo.Articulos ON dbo.Sacos.IdNumFicha = dbo.Articulos.NumFicha WHERE dbo.Articulos.IdPedido = " & "'" & Pedido & "'", cnn)
    '                Using rs As SqlDataReader = command.ExecuteReader()
    '                    While rs.Read()
    '                        aux.SacosFabricados1 = rs("Total")
    '                    End While
    '                End Using
    '            End Using
    '        Catch ex As Exception
    '            AltaTAG.ExecuteSqlTransactionRegistroError(My.Computer.Name & ". ERROR EtiquetaPrensa. Error en Repositorio --> obtenerDatosSacosA(). Error:" + ex.Message.ToString()) 'TODO try cath
    '            MsgBox("Error: Procedimiento. En el query obtener SacosFabricados (repositorio)." & vbCrLf + ex.Message)
    '        End Try
    '    End Using
    '    Using cnn As New SqlConnection(AltaTAG.CadenaConexionProduccion)
    '        Try
    '            cnn.Open()
    '            Using command As SqlCommand = New SqlCommand("SELECT Count(*) as Total FROM dbo.Sacos INNER JOIN dbo.Articulos ON dbo.Sacos.IdNumFicha = dbo.Articulos.NumFicha WHERE dbo.Articulos.IdPedido = " & "'" & Pedido & "' AND (dbo.Sacos.NCPPrensa IS NOT NULL)", cnn)
    '                Using rs As SqlDataReader = command.ExecuteReader()
    '                    While rs.Read()
    '                        aux.SacosPrensados1 = rs("Total")
    '                    End While
    '                End Using
    '            End Using
    '        Catch ex As Exception
    '            AltaTAG.ExecuteSqlTransactionRegistroError(My.Computer.Name & ". ERROR EtiquetaPrensa. Error en Repositorio --> obtenerDatosSacosB(). Error:" + ex.Message.ToString()) 'TODO try cath
    '            MsgBox("Error: Procedimiento. En el query obtener SacosPrensados (repositorio)." & vbCrLf + ex.Message)
    '        End Try
    '    End Using
    '    Using cnn As New SqlConnection(AltaTAG.CadenaConexionProduccion)
    '        Try
    '            cnn.Open()
    '            Using command As SqlCommand = New SqlCommand("SELECT Count(*) as Total FROM dbo.Sacos INNER JOIN dbo.Articulos ON dbo.Sacos.IdNumFicha = dbo.Articulos.NumFicha WHERE dbo.Articulos.IdPedido = " & "'" & Pedido & "' AND (dbo.Sacos.NCPPrensa IS NULL)", cnn)
    '                Using rs As SqlDataReader = command.ExecuteReader()
    '                    While rs.Read()
    '                        aux.SacosNoPrensados1 = rs("Total")
    '                    End While
    '                End Using
    '            End Using
    '        Catch ex As Exception
    '            AltaTAG.ExecuteSqlTransactionRegistroError(My.Computer.Name & ". ERROR EtiquetaPrensa. Error en Repositorio --> obtenerDatosSacosC(). Error:" + ex.Message.ToString()) 'TODO try cath
    '            MsgBox("Error: Procedimiento. En el query obtener SacosNoPrensados (repositorio)." & vbCrLf + ex.Message)
    '        End Try
    '    End Using
    '    Using cnn As New SqlConnection(AltaTAG.CadenaConexionProduccion)
    '        Try
    '            cnn.Open()
    '            Using command As SqlCommand = New SqlCommand("SELECT MetrosTotal / MetrosSaco as Total FROM dbo.Pedidos WHERE IdPedido = " & "'" & Pedido & "'", cnn)
    '                Using rs As SqlDataReader = command.ExecuteReader()
    '                    While rs.Read()
    '                        aux.SacosTotalPedido1 = rs("Total")
    '                    End While
    '                End Using
    '            End Using
    '        Catch ex As Exception
    '            AltaTAG.ExecuteSqlTransactionRegistroError(My.Computer.Name & ". ERROR EtiquetaPrensa. Error en Repositorio --> obtenerDatosSacosD(). Error:" + ex.Message.ToString()) 'TODO try cath
    '            MsgBox("Error: Procedimiento. En el query obtener SacosTotalPedido (repositorio)." & vbCrLf + ex.Message)
    '        End Try
    '    End Using

    '    aux.SacosPorFabricar1 = aux.SacosTotalPedido1 - aux.SacosFabricados1

    '    Return aux
    'End Function

    Public Function obtenerDatosSacos(Pedido As String) As DatosSacoModel
        Dim aux As New DatosSacoModel()

        ' Consulta única para obtener todos los datos necesarios en una sola llamada a la base de datos
        Dim query As String = "
            SELECT
                COUNT(*) AS SacosFabricados,
                SUM(CASE WHEN s.NCPPrensa IS NOT NULL THEN 1 ELSE 0 END) AS SacosPrensados,
                SUM(CASE WHEN s.NCPPrensa IS NULL THEN 1 ELSE 0 END) AS SacosNoPrensados
            FROM dbo.Sacos s
            INNER JOIN dbo.Articulos a ON s.IdNumFicha = a.NumFicha
            WHERE a.IdPedido = @Pedido;

            SELECT CAST(MetrosTotal AS FLOAT) / NULLIF(MetrosSaco, 0) AS SacosTotalPedido
            FROM dbo.Pedidos
            WHERE IdPedido = @Pedido;
        "

        Using cnn As New SqlConnection(AltaTAG.CadenaConexionProduccion)
            Try
                cnn.Open()
                Using cmd As New SqlCommand(query, cnn)
                    cmd.Parameters.AddWithValue("@Pedido", Pedido)

                    Using rs As SqlDataReader = cmd.ExecuteReader()
                        If rs.Read() Then
                            aux.SacosFabricados1 = If(IsDBNull(rs("SacosFabricados")), 0, Convert.ToInt32(rs("SacosFabricados")))
                            aux.SacosPrensados1 = If(IsDBNull(rs("SacosPrensados")), 0, Convert.ToInt32(rs("SacosPrensados")))
                            aux.SacosNoPrensados1 = If(IsDBNull(rs("SacosNoPrensados")), 0, Convert.ToInt32(rs("SacosNoPrensados")))
                        End If

                        ' Avanzar al segundo resultado
                        If rs.NextResult() AndAlso rs.Read() Then
                            aux.SacosTotalPedido1 = If(IsDBNull(rs("SacosTotalPedido")), 0, Convert.ToInt32(Math.Floor(Convert.ToDouble(rs("SacosTotalPedido")))))
                        End If
                    End Using
                End Using
            Catch ex As Exception
                AltaTAG.ExecuteSqlTransactionRegistroError(My.Computer.Name & ". ERROR EtiquetaPrensa. Error en Repositorio --> obtenerDatosSacos(). Error:" & ex.Message)
                MsgBox("Error: Procedimiento. En el query obtenerDatosSacos (repositorio)." & vbCrLf & ex.Message)
            End Try
        End Using

        aux.SacosPorFabricar1 = aux.SacosTotalPedido1 - aux.SacosFabricados1

        Return aux
    End Function

    'Public Function obtenerDatosTAGSacoPrensado(ByVal idSaco As Double) As DatosSacoTagModel
    '    Dim strSQL As SqlCommand
    '    Dim rs As SqlDataReader
    '    Dim aux As DatosSacoTagModel

    '    Using cnn As New SqlConnection(AltaTAG.CadenaConexionProduccion)
    '        Try
    '            cnn.Open()
    '            strSQL = New SqlCommand("SELECT dbo.Sacos.Tira, dbo.Sacos.Peso, dbo.Sacos.Agujeros, dbo.Sacos.DiaPesa, dbo.Sacos.NombrePeso, dbo.PosNueva.NoPosicion
    '                                     FROM dbo.Sacos INNER JOIN dbo.Articulos ON dbo.Sacos.IdNumFicha = dbo.Articulos.NumFicha INNER JOIN
    '                                     dbo.PosNueva ON dbo.Articulos.SalaPos = dbo.PosNueva.Posicion WHERE (dbo.Sacos.IdSaco = N'" & idSaco & "')", cnn)
    '            rs = strSQL.ExecuteReader
    '            While rs.Read()
    '                aux = New DatosSacoTagModel()
    '                aux.Tira1 = rs("Tira")
    '                aux.Peso1 = rs("Peso")
    '                aux.Agujeros1 = rs("Agujeros")
    '                aux.DiaPesa1 = rs("DiaPesa")
    '                aux.NombrePesa1 = rs("NombrePeso")
    '                aux.Posicion1 = rs("NoPosicion")
    '            End While
    '            rs.Close() 'TODO lector
    '            Return aux
    '        Catch ex As Exception
    '            AltaTAG.ExecuteSqlTransactionRegistroError(My.Computer.Name & ". ERROR EtiquetaPrensa. Error en Repositorio --> obtenerDatosTAGSacoPrensado(). Error:" + ex.Message.ToString()) 'TODO try cath
    '            MsgBox("Error: Procedimiento. En la función  obtenerDatosTAGSacoPrensado (repositorio)." & vbCrLf + ex.Message)
    '        End Try

    '    End Using
    'End Function

    'Public Function obtenerObservacionesPedido(ByVal pedido As String) As String
    '    Dim strSQL As SqlCommand
    '    Dim rs As SqlDataReader
    '    Dim aux As String = ""

    '    Using cnn As New SqlConnection(AltaTAG.CadenaConexionProduccion)
    '        Try
    '            cnn.Open()
    '            strSQL = New SqlCommand("SELECT Observaciones FROM dbo.Pedidos WHERE (IdPedido = '" & pedido & "')", cnn)
    '            rs = strSQL.ExecuteReader
    '            If rs.Read() Then
    '                aux = rs("Observaciones")
    '                If aux.Equals("                                                                                                                                                                                                                                                                                                                                                                                                                ") Then
    '                    aux = "Sin observaciones."
    '                End If
    '            End If
    '            Return aux
    '        Catch ex As Exception
    '            MsgBox("Error: Procedimiento. En la función  obtenerObservacionesPedido (repositorio)." & vbCrLf + ex.Message)
    '        End Try
    '    End Using
    'End Function

    Public Function obtenerDatosTAGSacoPrensado(ByVal idSaco As Double) As DatosSacoTagModel
        Dim aux As DatosSacoTagModel = Nothing

        ' Usar parámetros para evitar SQL Injection y mejorar el rendimiento
        Dim query As String = "SELECT s.Tira, s.Peso, s.Agujeros, s.DiaPesa, s.NombrePeso, p.NoPosicion " &
                              "FROM dbo.Sacos s " &
                              "INNER JOIN dbo.Articulos a ON s.IdNumFicha = a.NumFicha " &
                              "INNER JOIN dbo.PosNueva p ON a.SalaPos = p.Posicion " &
                              "WHERE s.IdSaco = @IdSaco"

        Using cnn As New SqlConnection(AltaTAG.CadenaConexionProduccion)
            Try
                cnn.Open()
                Using cmd As New SqlCommand(query, cnn)
                    cmd.Parameters.AddWithValue("@IdSaco", idSaco)
                    Using rs As SqlDataReader = cmd.ExecuteReader()
                        If rs.Read() Then
                            aux = New DatosSacoTagModel() With {
                                .Tira1 = rs("Tira"),
                                .Peso1 = rs("Peso"),
                                .Agujeros1 = rs("Agujeros"),
                                .DiaPesa1 = rs("DiaPesa"),
                                .NombrePesa1 = rs("NombrePeso"),
                                .Posicion1 = rs("NoPosicion")
                            }
                        End If
                    End Using
                End Using
                Return aux
            Catch ex As Exception
                AltaTAG.ExecuteSqlTransactionRegistroError(My.Computer.Name & ". ERROR EtiquetaPrensa. Error en Repositorio --> obtenerDatosTAGSacoPrensado(). Error:" & ex.Message)
                MsgBox("Error: Procedimiento. En la función obtenerDatosTAGSacoPrensado (repositorio)." & vbCrLf & ex.Message)
                Return Nothing
            End Try
        End Using
    End Function

    Public Function obtenerObservacionesPedido(ByVal pedido As String) As String
        Dim aux As String = ""

        ' Usar parámetros para evitar SQL Injection y mejorar el rendimiento
        Dim query As String = "SELECT Observaciones FROM dbo.Pedidos WHERE IdPedido = @Pedido"

        Using cnn As New SqlConnection(AltaTAG.CadenaConexionProduccion)
            Try
                cnn.Open()
                Using cmd As New SqlCommand(query, cnn)
                    cmd.Parameters.AddWithValue("@Pedido", pedido)
                    Using rs As SqlDataReader = cmd.ExecuteReader()
                        If rs.Read() Then
                            aux = If(IsDBNull(rs("Observaciones")), "", rs("Observaciones").ToString())
                            If String.IsNullOrWhiteSpace(aux) OrElse aux.Trim().Length = 0 Then
                                aux = "Sin observaciones."
                            End If
                        End If
                    End Using
                End Using
                Return aux
            Catch ex As Exception
                MsgBox("Error: Procedimiento. En la función obtenerObservacionesPedido (repositorio)." & vbCrLf & ex.Message)
                Return ""
            End Try
        End Using
    End Function
End Class
