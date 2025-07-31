Public Class DatosSacoModel
    Private SacosTotalPedido As Integer
    Private SacosFabricados As Integer
    Private SacosPorFabricar As Integer
    Private SacosPrensados As Integer
    Private SacosNoPrensados As Integer

    Public Property SacosTotalPedido1 As Integer
        Get
            Return SacosTotalPedido
        End Get
        Set(value As Integer)
            SacosTotalPedido = value
        End Set
    End Property

    Public Property SacosFabricados1 As Integer
        Get
            Return SacosFabricados
        End Get
        Set(value As Integer)
            SacosFabricados = value
        End Set
    End Property

    Public Property SacosPorFabricar1 As Integer
        Get
            Return SacosPorFabricar
        End Get
        Set(value As Integer)
            SacosPorFabricar = value
        End Set
    End Property

    Public Property SacosPrensados1 As Integer
        Get
            Return SacosPrensados
        End Get
        Set(value As Integer)
            SacosPrensados = value
        End Set
    End Property

    Public Property SacosNoPrensados1 As Integer
        Get
            Return SacosNoPrensados
        End Get
        Set(value As Integer)
            SacosNoPrensados = value
        End Set
    End Property
End Class
