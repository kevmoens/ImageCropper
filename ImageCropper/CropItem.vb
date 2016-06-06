Public Class CropItem
    Public Sub New(InFileName As String)
        _FileName = InFileName
        _TempFileName = GetWorkingDirectory() & "Temp\" & New IO.FileInfo(_FileName).Name
        If Not IO.Directory.Exists(GetWorkingDirectory() & "Temp") Then
            IO.Directory.CreateDirectory(GetWorkingDirectory() & "Temp")
        End If
        If Not IO.File.Exists(_TempFileName) Then
            IO.File.Copy(_FileName, _TempFileName)
        End If
        Dim InImage As Image = Nothing
        Dim oFileInfo As IO.FileInfo

        oFileInfo = New IO.FileInfo(TempFileName)
        Dim oImageOpen = Image.FromStream(OpenFileReadOnlyIntoMemoryStream(TempFileName))
        Dim oTiffImage = oImageOpen.Clone
        oImageOpen.Dispose()
        oImageOpen = Nothing
        InImage = oTiffImage

        Dim size As Integer = ImageSize
        Image = InImage

        Dim imageViewer As New ImageViewer()
        imageViewer.Dock = DockStyle.Bottom
        imageViewer.Width = size
        imageViewer.Height = size
        imageViewer.IsThumbnail = True
        imageViewer.CropItem = Me
        'imageViewer.SelectedColor = g_appColor.ImageViewSelectedColor
        _ImageViewer = imageViewer
        ImageRotationAngle = 0

        'AddHandler imageViewer.MouseClick, AddressOf imageViewer_MouseClick
        'AddHandler imageViewer.DoubleClick, AddressOf imageViewer_DoubleClick
        'AddHandler imageViewer.RequestPopup, AddressOf GroupItem_RequestPopup

        AddHandler Me.OnImageSizeChanged, New ThumbnailImageEventHandler(AddressOf imageViewer.ImageSizeChanged)

        SaveImageToTempFile()
        imageViewer.LoadImage(TempFileName, 256, 256)

        imageViewer.IsActive = True

        If m_ImageDialog Is Nothing OrElse m_ImageDialog.IsDisposed Then
            m_ImageDialog = New ImageDialog()
        End If
        m_ImageDialog.CropItem = Me
        If Not m_ImageDialog.Visible Then
            m_ImageDialog.Show()
            m_ImageDialog.WindowState = FormWindowState.Normal
        Else
            If m_ImageDialog.WindowState = FormWindowState.Maximized Then
                m_ImageDialog.WindowState = FormWindowState.Normal
            End If
        End If
        m_ImageDialog.BringToFront()

        m_ImageDialog.SetImage(imageViewer) 'm_ActiveImageViewer)
    End Sub
    Private _Image As Image
    Public Property Image() As Image
        Get
            Return _Image
        End Get
        Set(ByVal value As Image)
            _Image = value
        End Set
    End Property

    Private _FileName As String
    Public Property FileName() As String
        Get
            Return _FileName
        End Get
        Set(ByVal value As String)
            _FileName = value
        End Set
    End Property

    Private _TempFileName As String
    Public Property TempFileName() As String
        Get
            Return _TempFileName
        End Get
        Set(ByVal value As String)
            _TempFileName = value
        End Set
    End Property

    Private _ImageViewer As ImageViewer
    Public Property ImageViewer() As ImageViewer
        Get
            Return _ImageViewer
        End Get
        Set(ByVal value As ImageViewer)
            _ImageViewer = value
        End Set
    End Property

    Private _ImageRotationAngle As Integer
    Public Property ImageRotationAngle() As Integer
        Get
            Return _ImageRotationAngle
        End Get
        Set(ByVal value As Integer)
            If Math.Abs(value) = 360 Then
                _ImageRotationAngle = 0
            Else
                _ImageRotationAngle = value
            End If
        End Set
    End Property


    Public Sub SaveImageToTempFile()
        _TempFileName = GetWorkingDirectory() & New IO.FileInfo(_FileName).Name
        Try
            _TempFileName = _TempFileName '& ".tif"

            _Image.Save(_TempFileName, System.Drawing.Imaging.ImageFormat.Jpeg)

        Catch
            _Image.Save(_TempFileName, System.Drawing.Imaging.ImageFormat.Jpeg)
        End Try

        _Image.Dispose()
    End Sub

#Region "ThumbnailImageEventHandler"
    Public Delegate Sub ThumbnailImageEventHandler(ByVal sender As Object, ByVal e As ThumbnailImageEventArgs)

    Public Event OnImageSizeChanged As ThumbnailImageEventHandler


    Public m_ImageDialog As ImageDialog

    Protected m_ActiveImageViewer As ImageViewer

    Private _TrackBarSize As Integer = 3
    Public Property TrackBarSize() As Integer
        Get
            Return _TrackBarSize
        End Get
        Set(ByVal value As Integer)
            _TrackBarSize = value
        End Set
    End Property

    Public ReadOnly Property ImageSize() As Integer
        Get
            'Return (64 * (ParentForm.trackBarSize.Value + 1))
            Return (64 * (_TrackBarSize + 1))
        End Get
    End Property

    Public Sub RaiseOnImageSizeChanged(ByVal sender As Object, ByVal e As ThumbnailImageEventArgs)
        RaiseEvent OnImageSizeChanged(sender, e)
    End Sub
    Public Sub trackBarSize_ValueChanged(ByVal sender As Object, ByVal e As EventArgs)
        _TrackBarSize = sender.value
        RaiseOnImageSizeChanged(Me, New ThumbnailImageEventArgs(ImageSize))
    End Sub
#End Region
End Class
