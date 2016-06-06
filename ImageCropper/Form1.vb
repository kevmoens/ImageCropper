Imports System.IO
Imports System.Windows.Media.Imaging
Imports Windows.Globalization
Imports System.Runtime.InteropServices.WindowsRuntime
Imports Windows.Graphics.Imaging
Imports Tesseract

Public Class Form1
    Dim _OcrEngine As Windows.Media.Ocr.OcrEngine
    Dim _InputFiles As New List(Of FileInfo)
    Dim _OcrFiles As New List(Of FileInfo)

    <System.Runtime.InteropServices.DllImport("gdi32.dll")>
    Public Shared Function DeleteObject(hObject As IntPtr) As Boolean
    End Function

    Private Sub btnLoad_Click(sender As Object, e As EventArgs) Handles btnLoad.Click
        FolderBrowserDialog1.SelectedPath = "C:\Users\KevinDell\Downloads\2014-09-18 oostberg"
        If FolderBrowserDialog1.ShowDialog = DialogResult.OK Then
            lblFolder.Text = FolderBrowserDialog1.SelectedPath
            Dim oDir As New DirectoryInfo(FolderBrowserDialog1.SelectedPath)
            _InputFiles = oDir.GetFiles().ToList
        End If
        DataGridView1.DataSource = _InputFiles
    End Sub


    Private Sub DataGridView1_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentDoubleClick
        'MessageBox.Show(CType(DataGridView1.Rows(e.RowIndex).DataBoundItem, FileInfo).Name)
        Dim oCropItem As New CropItem(CType(DataGridView1.Rows(e.RowIndex).DataBoundItem, FileInfo).FullName)

    End Sub

    Private Sub DataGridView2_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellContentDoubleClick
        ''MessageBox.Show(CType(DataGridView1.Rows(e.RowIndex).DataBoundItem, FileInfo).Name)
        '_OcrEngine = Windows.Media.Ocr.OcrEngine.TryCreateFromLanguage(New Language("en"))

        '' Extract text from image.

        ''Dim bmp As Windows.Graphics.Imaging.SoftwareBitmap = Windows.Graphics.Imaging.SoftwareBitmap.
        'Dim stream As MemoryStream = OpenFileReadOnlyIntoMemoryStream(CType(DataGridView2.Rows(e.RowIndex).DataBoundItem, FileInfo).FullName)
        'Dim bmp = Bitmap.FromStream(stream)
        'Dim sfbmp As SoftwareBitmap
        'Dim bf As Windows.Storage.Streams.IBuffer = stream.GetBuffer().AsBuffer()
        'sfbmp = SoftwareBitmap.CreateCopyFromBuffer(bf, BitmapPixelFormat.Unknown, bmp.Width, bmp.Height)
        'Dim result As Windows.Media.Ocr.OcrResult = _OcrEngine.RecognizeAsync(sfbmp).GetResults

        '' Display recognized text.
        'MessageBox.Show(result.Text)

        Dim strFullName As String = "C:\Code\HomeCode\ImageCropper\ImageCropper\phototest.jpg"
        strFullName = CType(DataGridView2.Rows(e.RowIndex).DataBoundItem, FileInfo).FullName
        Using engine = New TesseractEngine(Application.StartupPath & "\tessdata", "eng", EngineMode.Default)
            Using img = Pix.LoadFromFile(strFullName)
                Using Page = engine.Process(img, strFullName, PageSegMode.Auto)
                    Dim Text = Page.GetText()
                    'Const string expectedText =                           "This is another test\n\n"; 
                    Debug.Print(Text)
                    If Text.Trim <> "" Then
                        MessageBox.Show(Text)
                    End If

                End Using
            End Using
        End Using


    End Sub


    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        Dim oDir As New DirectoryInfo(GetWorkingDirectory)
        _OcrFiles = oDir.GetFiles().ToList
        DataGridView2.DataSource = _OcrFiles
    End Sub
End Class
