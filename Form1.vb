Imports System.IO
Imports System.Text.Json
Imports System.Text.Json.Nodes
Imports SharpCompress.Archives

Public Class Form1
    Delegate Sub 写入日志框委托(text As String)

    Private 客户端路径 As String
    Private 差分包路径 As String
    Private 语音差分包路径 As String

    Private 差分包是否压缩包 As Boolean = False
    Private 语音差分包是否压缩包 As Boolean = False

    Private hpatchzExe As String

    Private Sub 写入日志框(text As String)
        If TextBox4.InvokeRequired Then
            TextBox4.Invoke(New 写入日志框委托(AddressOf 写入日志框), text)
        Else
            TextBox4.AppendText(text & Environment.NewLine)
            TextBox4.ScrollToCaret()
        End If
    End Sub

    Private Sub 执行CMD(cmd As String)
        Dim p As New Process()
        p.StartInfo.FileName = cmd
        p.StartInfo.RedirectStandardOutput = True
        p.StartInfo.UseShellExecute = False
        p.StartInfo.CreateNoWindow = True
        p.Start()

        Dim output As String = p.StandardOutput.ReadToEnd()
        p.WaitForExit()
        写入日志框(output)
    End Sub

    Private Sub 删除只读属性(path As String)
        For Each file As String In Directory.GetFiles(path, "*", SearchOption.AllDirectories)
            Dim fileInfo As New FileInfo(file)
            fileInfo.Attributes = FileAttributes.Normal
        Next
    End Sub

    Public Function 检查压缩包中的文件(zipFilePath As String, fileName As String) As Boolean
        Try
            Using archive As IArchive = ArchiveFactory.Open(zipFilePath)
                For Each entry In archive.Entries
                    If entry.Key.Equals(fileName, StringComparison.OrdinalIgnoreCase) Then
                        Return True
                    End If
                Next
            End Using
        Catch ex As Exception
            写入日志框("读取压缩包时出错：" & ex.Message)
        End Try
        Return False
    End Function

    Public Sub 解压压缩包(zipFilePath As String, extractTo As String)
        Dim 压缩包 As IArchive = ArchiveFactory.Open(zipFilePath)
        压缩包.ExtractToDirectory(extractTo)
        压缩包.Dispose()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Not File.Exists("hpatchz.exe") Then
            MessageBox.Show("hpatchz.exe 文件不存在于程序路径下！", "错误：", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        客户端路径 = TextBox2.Text
        差分包路径 = TextBox1.Text
        语音差分包路径 = TextBox3.Text
        hpatchzExe = Path.Combine(Application.StartupPath, "hpatchz.exe")

        If String.IsNullOrEmpty(客户端路径) OrElse String.IsNullOrEmpty(差分包路径) OrElse (CheckBox1.Checked AndAlso String.IsNullOrEmpty(语音差分包路径)) Then
            MessageBox.Show("路径不能为空！", "错误：", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        If Not 差分包是否压缩包 Then
            If Not File.Exists(Path.Combine(差分包路径, "deletefiles.txt")) OrElse Not File.Exists(Path.Combine(差分包路径, "hdifffiles.txt")) Then
                MessageBox.Show("差分包文件不存在！", "错误：", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If
        Else
            If Not 检查压缩包中的文件(差分包路径, "hdifffiles.txt") OrElse Not 检查压缩包中的文件(差分包路径, "deletefiles.txt") Then
                MessageBox.Show("差分包文件不存在或不正确！", "错误：", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If
        End If

        If Not 语音差分包是否压缩包 Then
            If CheckBox1.Checked AndAlso Not File.Exists(Path.Combine(语音差分包路径, "hdifffiles.txt")) OrElse Not File.Exists(Path.Combine(差分包路径, "deletefiles.txt")) Then
                MessageBox.Show("语音差分包文件不存在！", "错误：", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If
        Else
            If CheckBox1.Checked AndAlso Not 检查压缩包中的文件(语音差分包路径, "hdifffiles.txt") OrElse Not 检查压缩包中的文件(差分包路径, "deletefiles.txt") Then
                MessageBox.Show("语音差分包文件不存在或不正确！", "错误：", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If
        End If

        If CheckBox1.Checked Then
            Dim result As DialogResult = MessageBox.Show("请确认你所填的路径是否正确：" & vbCrLf & vbCrLf & "客户端路径：" & 客户端路径 & vbCrLf & "游戏差分包路径：" & 差分包路径 & vbCrLf & "语音差分包路径：" & 语音差分包路径 & vbCrLf & vbCrLf & "填写不正确的路径会导致合并失败，合并失败只能重新解压重来！", "警告：", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning)
            If result = DialogResult.Cancel Then Return
        Else
            Dim result As DialogResult = MessageBox.Show("请确认你所填的路径是否正确：" & vbCrLf & vbCrLf & "客户端路径：" & 客户端路径 & vbCrLf & "游戏差分包路径：" & 差分包路径 & vbCrLf & vbCrLf & "填写不正确的路径会导致合并失败，合并失败只能重新解压重来！", "警告：", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning)
            If result = DialogResult.Cancel Then Return
        End If

        Button1.Enabled = False
        BackgroundWorker1.RunWorkerAsync()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not CheckBox1.Checked Then
            Button4.Enabled = False
            TextBox3.Enabled = False
            Label3.Enabled = False
            Button6.Enabled = False
        End If

        AddHandler BackgroundWorker1.DoWork, AddressOf BackgroundWorker1_DoWork
        AddHandler BackgroundWorker1.RunWorkerCompleted, AddressOf BackgroundWorker1_RunWorkerCompleted
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs)
        Try
            If 差分包是否压缩包 Then
                Dim 压缩文件目录 As String = Path.GetDirectoryName(差分包路径)
                Dim 压缩文件名 As String = Path.GetFileNameWithoutExtension(差分包路径)
                Dim 压缩文件路径 As String = 差分包路径
                差分包路径 = 压缩文件目录 & “\” & 压缩文件名
                If Directory.Exists(差分包路径) Then Directory.Delete(差分包路径, True)
                写入日志框("解压：" & 压缩文件路径)
                解压压缩包(压缩文件路径, 差分包路径)
            End If

            If CheckBox1.Checked AndAlso 语音差分包是否压缩包 Then
                Dim 压缩文件目录 As String = Path.GetDirectoryName(语音差分包路径)
                Dim 压缩文件名 As String = Path.GetFileNameWithoutExtension(语音差分包路径)
                Dim 压缩文件路径 As String = 语音差分包路径
                语音差分包路径 = 压缩文件目录 & “\” & 压缩文件名
                If Directory.Exists(语音差分包路径) Then Directory.Delete(语音差分包路径, True)
                写入日志框("解压：" & 压缩文件路径)
                解压压缩包(压缩文件路径, 语音差分包路径)
            End If

            Dim deleteFiles As List(Of String) = File.ReadLines(Path.Combine(差分包路径, "deletefiles.txt")).ToList()
            Dim deleteFilesAudio As List(Of String) = If(CheckBox1.Checked, File.ReadLines(Path.Combine(语音差分包路径, "deletefiles.txt")).ToList(), New List(Of String)())
            Dim hdiffFiles As List(Of String) = File.ReadLines(Path.Combine(差分包路径, "hdifffiles.txt")).ToList()
            Dim hdiffFilesAudio As List(Of String) = If(CheckBox1.Checked, File.ReadLines(Path.Combine(语音差分包路径, "hdifffiles.txt")).ToList(), New List(Of String)())

            删除只读属性(客户端路径)
            删除只读属性(差分包路径)
            If CheckBox1.Checked Then 删除只读属性(语音差分包路径)

            删除文件(客户端路径, deleteFiles)
            If CheckBox1.Checked Then 删除文件(客户端路径, deleteFilesAudio)

            Dim temp目录 As String = Path.Combine(客户端路径, "temp")
            Directory.CreateDirectory(temp目录)

            应用补丁(hdiffFiles, 客户端路径, 差分包路径, temp目录)
            If CheckBox1.Checked Then 应用补丁(hdiffFilesAudio, 客户端路径, 语音差分包路径, temp目录)
            移动文件(差分包路径, 客户端路径)
            If CheckBox1.Checked Then 移动文件(语音差分包路径, 客户端路径)

            Directory.Delete(差分包路径, True)
            If CheckBox1.Checked Then Directory.Delete(语音差分包路径, True)

            写入日志框("合并完成!")
        Catch ex As Exception
            写入日志框(ex.ToString())
        End Try
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs)
        Button1.Enabled = True

        If e.Error IsNot Nothing Then
            MessageBox.Show("合并过程中发生错误，请检查日志！", "错误：", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            MessageBox.Show("合并操作成功完成！", "信息：", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub 应用补丁(hdiffFiles As List(Of String), 客户端目录 As String, 差分包目录 As String, 临时目录 As String)
        For Each line As String In hdiffFiles
            Dim patchInfo As JsonObject = JsonSerializer.Deserialize(Of JsonObject)(line)
            Dim remoteName As String = patchInfo("remoteName").ToString()
            Dim baseName As String = Path.GetFileName(remoteName)

            写入日志框($"合并：{baseName}...")

            Dim 源文件 As String = Path.Combine(客户端目录, remoteName)
            Dim hdiff文件 As String = Path.Combine(差分包目录, remoteName & ".hdiff")
            Dim 目标文件 As String = Path.Combine(临时目录, baseName)

            Dim cmd As String = $"""{hpatchzExe}"" ""{源文件}"" ""{hdiff文件}"" ""{目标文件}"""
            执行CMD(cmd)

            If File.Exists(源文件) Then File.Delete(源文件)
            If File.Exists(hdiff文件) Then File.Delete(hdiff文件)
            File.Move(目标文件, 源文件)
        Next
    End Sub

    Private Sub 删除文件(文件路径 As String, 文件列表 As List(Of String))
        For Each df As String In 文件列表
            Dim filePath As String = Path.Combine(文件路径, df.Trim())
            If File.Exists(filePath) Then
                File.Delete(filePath)
                写入日志框($"删除：{filePath}")
            End If
        Next
    End Sub

    Private Sub 移动文件(源路径 As String, 目标路径 As String)
        For Each 源文件 As String In Directory.GetFiles(源路径, "*", SearchOption.AllDirectories)
            Dim 相对路径 As String = 源文件.Substring(源路径.Length + 1)
            Dim 目标文件 As String = Path.Combine(目标路径, 相对路径)
            Dim 目的文件夹 As String = Path.GetDirectoryName(目标文件)
            If Not Directory.Exists(目的文件夹) Then
                Directory.CreateDirectory(目的文件夹)
            End If
            写入日志框($"移动：{源文件} -> {目标文件}...")
            If File.Exists(目标文件) Then File.Delete(目标文件)
            File.Move(源文件, 目标文件)
        Next
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim fbd As New FolderBrowserDialog()
        If fbd.ShowDialog() = DialogResult.OK Then
            Dim fp As String = fbd.SelectedPath
            TextBox2.Text = fp
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim fbd As New FolderBrowserDialog()
        If fbd.ShowDialog() = DialogResult.OK Then
            Dim fp As String = fbd.SelectedPath
            差分包是否压缩包 = False
            TextBox1.Text = fp
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim fbd As New FolderBrowserDialog()
        If fbd.ShowDialog() = DialogResult.OK Then
            Dim fp As String = fbd.SelectedPath
            语音差分包是否压缩包 = False
            TextBox3.Text = fp
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked Then
            Button4.Enabled = True
            TextBox3.Enabled = True
            Label3.Enabled = True
            Button6.Enabled = True
        Else
            Button4.Enabled = False
            TextBox3.Enabled = False
            Label3.Enabled = False
            Button6.Enabled = False
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim ofd As New OpenFileDialog()
        ofd.Multiselect = False
        ofd.Filter = "压缩包文件 (*.zip) (*.7z)|*.zip;*.7z|Zip 文件 (*.zip)|*.zip|7Zip 文件 (*.7z)|*.7z|所有文件 (*.*)|*.*"

        If ofd.ShowDialog() = DialogResult.OK Then
            Dim fp As String = ofd.FileName
            差分包是否压缩包 = True
            TextBox1.Text = fp
        End If
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim ofd As New OpenFileDialog()
        ofd.Multiselect = False
        ofd.Filter = "压缩包文件 (*.zip) (*.7z)|*.zip;*.7z|Zip 文件 (*.zip)|*.zip|7Zip 文件 (*.7z)|*.7z|所有文件 (*.*)|*.*"

        If ofd.ShowDialog() = DialogResult.OK Then
            Dim fp As String = ofd.FileName
            语音差分包是否压缩包 = True
            TextBox3.Text = fp
        End If
    End Sub
End Class
