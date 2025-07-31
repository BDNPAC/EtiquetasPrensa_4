Public Class CajaStockModel
    Private Id As Integer
    Private Articulo As String
    Private Colore As String
    Private Metros As String
    Private MetrosCaja As String
    Private PosicionPalet As String
    Public Property Id1 As Integer
        Get
            Return Id
        End Get
        Set(value As Integer)
            Id = value
        End Set
    End Property
    Public Property Articulo1 As String
        Get
            Return Articulo
        End Get
        Set(value As String)
            Articulo = value
        End Set
    End Property

    Public Property Colore1 As String
        Get
            Return Colore
        End Get
        Set(value As String)
            Colore = value
        End Set
    End Property

    Public Property Metros1 As String
        Get
            Return Metros
        End Get
        Set(value As String)
            Metros = value
        End Set
    End Property

    Public Property PosicionPalet1 As String
        Get
            Return PosicionPalet
        End Get
        Set(value As String)
            PosicionPalet = value
        End Set
    End Property

    Public Property MetrosCaja1 As String
        Get
            Return MetrosCaja
        End Get
        Set(value As String)
            MetrosCaja = value
        End Set
    End Property
End Class
