Public Class menusClass

    Private _menuName As String
    Private _menuText As String


    Public Property MenuName as String
        Get
            return _menuName
        End Get
        Set
            _menuName = value
        End Set
    End Property

    Public Property MenuText as String
        Get
            return _menuText
        End Get
        Set
            _menuText = value
        End Set
    End Property


End Class
