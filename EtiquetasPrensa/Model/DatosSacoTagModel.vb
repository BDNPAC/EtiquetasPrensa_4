Public Class DatosSacoTagModel
    Private Tira As Integer
    Private Peso As Double
    Private Agujeros As Integer
    Private DiaPesa As DateTime
    Private NombrePesa As String
    Private Posicion As Integer

    Public Property Tira1 As Integer
        Get
            Return Tira
        End Get
        Set(value As Integer)
            Tira = value
        End Set
    End Property

    Public Property Peso1 As Double
        Get
            Return Peso
        End Get
        Set(value As Double)
            Peso = value
        End Set
    End Property

    Public Property Agujeros1 As Integer
        Get
            Return Agujeros
        End Get
        Set(value As Integer)
            Agujeros = value
        End Set
    End Property

    Public Property DiaPesa1 As Date
        Get
            Return DiaPesa
        End Get
        Set(value As Date)
            DiaPesa = value
        End Set
    End Property

    Public Property NombrePesa1 As String
        Get
            Return NombrePesa
        End Get
        Set(value As String)
            NombrePesa = value
        End Set
    End Property

    Public Property Posicion1 As Integer
        Get
            Return Posicion
        End Get
        Set(value As Integer)
            Posicion = value
        End Set
    End Property
End Class
