Imports System.Collections
Imports System.Collections.Specialized
Partial Class BreadCrumb
    Inherits System.Web.UI.UserControl
    Private _tailName As String
    'Variable holding the level of the page
    Private _level As Short
    'The pagecrumb object of the current page
    Private _pageCrumb As New PageCrumb
    'We will use a sorted list as we can use the level as key 
    Private _crumbList As SortedList



    'Each page has a level. The page should declare its level
    Public Property Level() As Short
        ' TO DO : We can check for some constraints here
        Get
            Return _level
        End Get
        Set(ByVal Value As Short)
            _level = Value
        End Set
    End Property


    'Each page needs a meaningful name of it. Let them declare it
    Public Property TailName() As String
        ' TO DO : We can check for some constraints here
        Get
            Return _tailName
        End Get
        Set(ByVal Value As String)
            _tailName = Value
        End Set
    End Property

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'We are not disabling viewstate
        If Not (Page.IsPostBack) Then

            'Minimum level is 1
            If (_level <= 0) Then
                _level = 1
            End If

            'If no friendly name gives Untitled as default
            If (_tailName = "") Then
                _tailName = "Untitled"
            End If

            'Create a Crumb object based on the properties of this page
            _pageCrumb = New PageCrumb(_level, Request.RawUrl, _tailName)

            'Check our Crumb is there in the session...if not create and add it...else get it    
            If Session.Item("HASH_OF_CRUMPS") Is Nothing Then
                _crumbList = New SortedList
                Session.Add("HASH_OF_CRUMPS", _crumbList)
            Else
                _crumbList = Session.Item("HASH_OF_CRUMPS")
            End If

            'Now modify the List of the breadcrumb
            ModifyList()
            ' Put the breadcrumb from the session of sortlist
            PutBreadCrumbs()
        End If


    End Sub

    Private Sub ModifyList()
        'Remove all Entries from the list which is higher or equal in level
        'Because at a level there can be max 1 entry in the list
        RemoveLowerLevelCrumbs()
        'If level is 1 set the Crumb as home
        If _pageCrumb.Level = 1 Then
            _crumbList.Clear()
            _crumbList.Add(CType(1, Short), New PageCrumb(1, "ControlPanel/ControlPanelhomeList.aspx", "Home"))

        Else
            'If nothing in the list adds the home link first
            If _crumbList.Count = 0 Then
                _crumbList.Add(CType(1, Short), New PageCrumb(1, "ControlPanel/ControlPanelhomeList.aspx", "Home"))
            End If
            'Now add the present list also no other check is required here as we have cleaned up the 
            'List at the start of the function
            _crumbList.Add(_level, _pageCrumb)
        End If
    End Sub

    'Function will remove all the entries from the list which is higher or equal to the
    'present level
    Private Sub RemoveLowerLevelCrumbs()

        Dim level As Short
        Dim removalList As New ArrayList(_crumbList.Count)
        For Each level In _crumbList.Keys
            If (level >= _level) Then
                removalList.Add(level)
            End If
        Next
        'Now remove all keys in the list
        For Each level In removalList
            _crumbList.Remove(level)
        Next
    End Sub


    Private Sub PutBreadCrumbs()
        Dim linkString As New StringBuilder

        Dim pageCrumb As New PageCrumb
        Dim index As Integer

        For index = 0 To _crumbList.Count - 2
            pageCrumb = _crumbList.GetByIndex(index)
            linkString.Append(String.Format("<a href = {0} >{1} </a>", pageCrumb.Url, pageCrumb.LinkName))
            linkString.Append(" > ")
        Next index
        'Add the tail also
        pageCrumb = _crumbList.GetByIndex(index)
        linkString.Append("<Span class='p'>" + pageCrumb.LinkName + "</span>")

        lblTrail.Text = linkString.ToString()

    End Sub

    Private Sub BreadCrumb_DataBinding(sender As Object, e As EventArgs) Handles Me.DataBinding

    End Sub

    Private Sub BreadCrumb_AbortTransaction(sender As Object, e As EventArgs) Handles Me.AbortTransaction

    End Sub

    Private Sub lblTrail_Load(sender As Object, e As EventArgs) Handles lblTrail.Load

    End Sub
End Class
