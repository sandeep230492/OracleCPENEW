Public Class Oracle_CPEObjects
#Region "LoginDetails Class definition"
    Public Class LoginDetails

        Dim g_sLegacySystem As String
        Dim g_sLoginId As String
        Dim g_sLoginPwd As String
        Dim g_sLoginEntity As String
        Dim mstrSignOnName As String
        Dim mstrSignOnId As String
        Dim mstrSignOnPassword As String

        Public Property LegacySystem() As String
            Get
                Return g_sLegacySystem
            End Get
            Set(ByVal sLegacySystem As String)
                g_sLegacySystem = sLegacySystem
            End Set
        End Property
        Public Property LoginId() As String
            Get
                Return g_sLoginId
            End Get
            Set(ByVal sLoginId As String)
                g_sLoginId = sLoginId
            End Set
        End Property
        Public Property LoginPwd() As String
            Get
                Return g_sLoginPwd
            End Get
            Set(ByVal sLoginPwd As String)
                g_sLoginPwd = sLoginPwd
            End Set
        End Property
        Public Property LoginEntity() As String
            Get
                Return g_sLoginEntity
            End Get
            Set(ByVal sLoginEntity As String)
                g_sLoginEntity = sLoginEntity
            End Set
        End Property
        Public Property SubSystemName() As String
            Set(ByVal Value As String)
                mstrSignOnName = Value
            End Set
            Get
                Return mstrSignOnName
            End Get
        End Property
        Public Property SubSystemLoginId() As String
            Set(ByVal Value As String)
                mstrSignOnId = Value
            End Set
            Get
                Return mstrSignOnId
            End Get
        End Property
        Public Property SubSystemLoginPwd() As String
            Set(ByVal Value As String)
                mstrSignOnPassword = Value
            End Set
            Get
                Return mstrSignOnPassword
            End Get
        End Property
    End Class
#End Region
End Class
