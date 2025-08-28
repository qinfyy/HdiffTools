Public Class 自动调整控件大小
    Private 控件队列_初始化 As Queue(Of Control)
    Private 控件信息列表_初始化 As List(Of 控件信息)
    Private 主窗体高_初始 As Integer
    Private 主窗体宽_初始 As Integer
    Private 主窗体高_当前 As Integer
    Private 主窗体宽_当前 As Integer

    Private Class 控件信息
        Public 控件名称 As String
        Public 高度 As Integer
        Public 宽度 As Integer
        Public 位置_X As Integer
        Public 位置_Y As Integer

        Public Sub New(名称 As String, 高 As Integer, 宽 As Integer, x As Integer, y As Integer)
            控件名称 = 名称
            高度 = 高
            宽度 = 宽
            位置_X = x
            位置_Y = y
        End Sub
    End Class

    Public Sub New()
        控件队列_初始化 = New Queue(Of Control)()
        控件信息列表_初始化 = New List(Of 控件信息)()
    End Sub

    Private Sub 遍历控件列表(控件 As Control)
        For i As Integer = 0 To 控件.Controls.Count - 1
            If 控件.Controls(i).HasChildren Then
                遍历控件列表(控件.Controls(i))
            End If

            Dim 当前控件 As Control = 控件.Controls(i)
            Dim 信息节点 As New 控件信息(
                当前控件.Name,
                当前控件.Height,
                当前控件.Width,
                当前控件.Location.X,
                当前控件.Location.Y
            )

            控件信息列表_初始化.Add(信息节点)
            控件队列_初始化.Enqueue(当前控件)
        Next
    End Sub

    Private Sub 获取主窗体初始尺寸(窗体 As Form)
        主窗体高_初始 = 窗体.Height
        主窗体宽_初始 = 窗体.Width
    End Sub

    Private Sub 获取主窗体当前尺寸(窗体 As Form)
        主窗体高_当前 = 窗体.Height
        主窗体宽_当前 = 窗体.Width
    End Sub

    Public Sub 注册窗体控件(窗体 As Form)
        遍历控件列表(窗体)
        获取主窗体初始尺寸(窗体)
    End Sub

    Public Sub 调整窗体控件大小(窗体 As Form)
        获取主窗体当前尺寸(窗体)

        Dim 控件队列 As New Queue(Of Control)(控件队列_初始化)
        Dim 控件数量 As Integer = 控件队列.Count

        For i As Integer = 0 To 控件数量 - 1
            Dim 当前控件 As Control = 控件队列.Dequeue()
            Dim 信息节点 As 控件信息 = 控件信息列表_初始化(i)

            当前控件.Height = CInt(信息节点.高度 * (主窗体高_当前 / 主窗体高_初始))
            当前控件.Width = CInt(信息节点.宽度 * (主窗体宽_当前 / 主窗体宽_初始))
            当前控件.Location = New Point(
                CInt(信息节点.位置_X * (主窗体宽_当前 / 主窗体宽_初始)),
                CInt(信息节点.位置_Y * (主窗体高_当前 / 主窗体高_初始))
            )
        Next
    End Sub
End Class
