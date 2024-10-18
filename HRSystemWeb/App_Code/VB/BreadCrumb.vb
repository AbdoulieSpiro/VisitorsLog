Public Structure PageCrumb

    Private _level As Short
    Private _url As String
    Private _linkName As String



    Public Sub New(ByVal level As Short, ByVal url As String, ByVal linkName As String)

        _level = level
        _url = url
        _linkName = LinkName
    End Sub


    Public ReadOnly Property Level() As Short
        Get
            Return _level
        End Get
    End Property

    Public ReadOnly Property Url() As String
        Get
            Return _url
        End Get
    End Property

    Public ReadOnly Property LinkName() As String
        Get
            Return _linkName
        End Get
    End Property
End Structure
