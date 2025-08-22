<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。  
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.制作按钮 = New System.Windows.Forms.Button()
        Me.新客户端路径框 = New System.Windows.Forms.TextBox()
        Me.旧客户端路径框 = New System.Windows.Forms.TextBox()
        Me.制作选择差分包 = New System.Windows.Forms.Button()
        Me.制作选择新客户端 = New System.Windows.Forms.Button()
        Me.制作选择旧客户端按钮 = New System.Windows.Forms.Button()
        Me.差分包保存路径框 = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.BackgroundWorker2 = New System.ComponentModel.BackgroundWorker()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(496, 90)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(150, 23)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "开始合并"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(31, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(77, 12)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "客户端路径："
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(114, 36)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(376, 21)
        Me.TextBox1.TabIndex = 3
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(114, 8)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(376, 21)
        Me.TextBox2.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(7, 39)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(101, 12)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "游戏差分包路径："
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(114, 63)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(376, 21)
        Me.TextBox3.TabIndex = 6
        '
        'TextBox4
        '
        Me.TextBox4.Location = New System.Drawing.Point(14, 167)
        Me.TextBox4.Multiline = True
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.ReadOnly = True
        Me.TextBox4.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextBox4.Size = New System.Drawing.Size(656, 287)
        Me.TextBox4.TabIndex = 8
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(631, 66)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(15, 14)
        Me.CheckBox1.TabIndex = 9
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(496, 9)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(46, 20)
        Me.Button2.TabIndex = 10
        Me.Button2.Text = "选择"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(496, 37)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(46, 20)
        Me.Button3.TabIndex = 11
        Me.Button3.Text = "选择"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(496, 64)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(46, 20)
        Me.Button4.TabIndex = 12
        Me.Button4.Text = "选择"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(7, 68)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(101, 12)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "语音差分包路径："
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(548, 37)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(77, 20)
        Me.Button5.TabIndex = 14
        Me.Button5.Text = "选择压缩包"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(548, 62)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(77, 20)
        Me.Button6.TabIndex = 15
        Me.Button6.Text = "选择压缩包"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 152)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(41, 12)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "日志："
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(12, 3)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(658, 146)
        Me.TabControl1.TabIndex = 17
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.Button1)
        Me.TabPage1.Controls.Add(Me.Button6)
        Me.TabPage1.Controls.Add(Me.TextBox1)
        Me.TabPage1.Controls.Add(Me.Button5)
        Me.TabPage1.Controls.Add(Me.TextBox2)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.Button4)
        Me.TabPage1.Controls.Add(Me.TextBox3)
        Me.TabPage1.Controls.Add(Me.Button3)
        Me.TabPage1.Controls.Add(Me.CheckBox1)
        Me.TabPage1.Controls.Add(Me.Button2)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(650, 120)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "合并"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.制作按钮)
        Me.TabPage2.Controls.Add(Me.新客户端路径框)
        Me.TabPage2.Controls.Add(Me.旧客户端路径框)
        Me.TabPage2.Controls.Add(Me.制作选择差分包)
        Me.TabPage2.Controls.Add(Me.制作选择新客户端)
        Me.TabPage2.Controls.Add(Me.制作选择旧客户端按钮)
        Me.TabPage2.Controls.Add(Me.差分包保存路径框)
        Me.TabPage2.Controls.Add(Me.Label7)
        Me.TabPage2.Controls.Add(Me.Label6)
        Me.TabPage2.Controls.Add(Me.Label5)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(650, 120)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "制作"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        '制作按钮
        '
        Me.制作按钮.Location = New System.Drawing.Point(519, 89)
        Me.制作按钮.Name = "制作按钮"
        Me.制作按钮.Size = New System.Drawing.Size(125, 25)
        Me.制作按钮.TabIndex = 9
        Me.制作按钮.Text = "开始制作"
        Me.制作按钮.UseVisualStyleBackColor = True
        '
        '新客户端路径框
        '
        Me.新客户端路径框.Location = New System.Drawing.Point(110, 36)
        Me.新客户端路径框.Name = "新客户端路径框"
        Me.新客户端路径框.Size = New System.Drawing.Size(454, 21)
        Me.新客户端路径框.TabIndex = 15
        '
        '旧客户端路径框
        '
        Me.旧客户端路径框.Location = New System.Drawing.Point(110, 9)
        Me.旧客户端路径框.Name = "旧客户端路径框"
        Me.旧客户端路径框.Size = New System.Drawing.Size(454, 21)
        Me.旧客户端路径框.TabIndex = 16
        '
        '制作选择差分包
        '
        Me.制作选择差分包.Location = New System.Drawing.Point(570, 63)
        Me.制作选择差分包.Name = "制作选择差分包"
        Me.制作选择差分包.Size = New System.Drawing.Size(74, 21)
        Me.制作选择差分包.TabIndex = 8
        Me.制作选择差分包.Text = "选择"
        Me.制作选择差分包.UseVisualStyleBackColor = True
        '
        '制作选择新客户端
        '
        Me.制作选择新客户端.Location = New System.Drawing.Point(570, 36)
        Me.制作选择新客户端.Name = "制作选择新客户端"
        Me.制作选择新客户端.Size = New System.Drawing.Size(74, 21)
        Me.制作选择新客户端.TabIndex = 7
        Me.制作选择新客户端.Text = "选择"
        Me.制作选择新客户端.UseVisualStyleBackColor = True
        '
        '制作选择旧客户端按钮
        '
        Me.制作选择旧客户端按钮.Location = New System.Drawing.Point(570, 9)
        Me.制作选择旧客户端按钮.Name = "制作选择旧客户端按钮"
        Me.制作选择旧客户端按钮.Size = New System.Drawing.Size(74, 21)
        Me.制作选择旧客户端按钮.TabIndex = 6
        Me.制作选择旧客户端按钮.Text = "选择"
        Me.制作选择旧客户端按钮.UseVisualStyleBackColor = True
        '
        '差分包保存路径框
        '
        Me.差分包保存路径框.Location = New System.Drawing.Point(110, 63)
        Me.差分包保存路径框.Name = "差分包保存路径框"
        Me.差分包保存路径框.Size = New System.Drawing.Size(454, 21)
        Me.差分包保存路径框.TabIndex = 18
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 69)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(101, 12)
        Me.Label7.TabIndex = 2
        Me.Label7.Text = "差分包保存路径："
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(18, 42)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(89, 12)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "新客户端路径："
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(18, 15)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(89, 12)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "旧客户端路径："
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(684, 466)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TextBox4)
        Me.Name = "Form1"
        Me.Text = "差分包工具"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Button1 As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents TextBox4 As TextBox
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents Button5 As Button
    Friend WithEvents Button6 As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents 制作按钮 As Button
    Friend WithEvents 新客户端路径框 As TextBox
    Friend WithEvents 旧客户端路径框 As TextBox
    Friend WithEvents 制作选择差分包 As Button
    Friend WithEvents 制作选择新客户端 As Button
    Friend WithEvents 制作选择旧客户端按钮 As Button
    Friend WithEvents 差分包保存路径框 As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Private WithEvents TabPage1 As TabPage
    Friend WithEvents BackgroundWorker2 As System.ComponentModel.BackgroundWorker
End Class
