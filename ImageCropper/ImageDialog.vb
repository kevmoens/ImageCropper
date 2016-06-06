#Region "Copyright"
'Copyright © The Lake Companies, Inc. 2004 – 2012 - All Rights Reserved
'
'Use, duplication, or disclosure by the Government is subject to restrictions
'as set forth in subparagraph (c)(1)(ii) of the Rights in Technical Data and
'Computer Software clause at DFARS 252.227-7013, and Rights in Data-General at
'FAR 52.227.14, as applicable.
'
'Name of Contractor: The Lake Companies, Inc., 2980 Walker Dr, Green Bay,
'WI 54311 USA
'
'Unless customer maintains a license to source code, customer shall not:
'(i) copy, modify or otherwise update the code contained within this file or
'(ii) merge such code with other computer programs.
'
'Provided customer maintains a license to source code, then customer may modify
'or otherwise update the code contained within this file or merge such code with
'other computer programs subject to the following: (i) customer shall maintain
'the source code as the trade secret and confidential information of The Lake
'Companies, Inc., (LakeCo); (ii) the source code may only be used for so long as 
'customer maintains a license to source code pursuant to a separately executed 
'license agreement, and only for the purpose of developing and supporting 
'customer specific modifications to the source code, and not for the purpose of
'substituting or replacing software support provided by LakeCo; (iii) LakeCo
'will have no responsibility to provide software support for any customer
'specific modifications developed by or for the customer, including those
'developed by LakeCo, unless otherwise agreed to by LakeCo on a time and
'materials basis pursuant to a separately executed services agreement;
'(iv) LakeCo exclusively retains ownership to all intellectual property rights
'associated with the source code, and any derivative works thereof;
'(v) upon any expiration or termination of the license agreement, or upon
'customer's termination of software support, customer's license to the source
'code will immediately terminate and customer shall return the source code to
'LakeCo or prepare and send to LakeCo a written affidavit certifying destruction
'of the source code within ten (10) days following the expiration or termination
'of customer's license right to the source code; (vi) customer shall and shall 
'obligate all employees of customer or subcontractors of customer that have
'access to the source code to maintain the source code as the trade secret
'and confidential information of LakeCo and to protect the source code from 
'disclosure to any third parties, including employees of customer or 
'subcontractors of customer that are not under an obligation to maintain 
'the confidentiality of the source code; (vii) LakeCo may immediately terminate
'a source code license in the event that LakeCo becomes aware of a breach 
'of these provisions or if, in the commercially reasonable discretion of LakeCo, 
'a breach is probable; (viii) any breach by customer of its confidentiality 
'obligations hereunder may cause irreparable damage for which LakeCo may
'have no adequate remedy at law, and that LakeCo may exercise all available
'equitable remedies, including seeking injunctive relief, without having to post
'a bond; and, (ix) if Customer becomes aware of a breach or if a breach is 
'probable, customer will promptly notify LakeCo, and will provide assistance
'and cooperation as is necessary to remedy a breach that has already 
'occurred or to prevent a threatened breach.
'
'All other product or brand names used in this code may be trademarks,
'registered trademarks, or trade names of their respective owners.*/
'
#End Region
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports System.Threading

Partial Public Class ImageDialog
    Inherits Form
    'Dim _ImageSeq As Integer = 0
    Dim _ZoomChanging As Boolean = False
    Public Sub New()
        InitializeComponent()
        'InitializeComponentPartials()
        TrackBar1.Maximum = 20
        TrackBar1.Minimum = -100
        imageViewerFull.AutoZoom = False
        imageViewerFull.PanMode = False
        'tipBarcodeInformation.SetToolTip(btnBarcodeInformation, GetString("sLCDTBarcodeInformation"))
        'tipDisplayBarcodeRecognitionRectangle.SetToolTip(btnDisplayBarcodeRecognitionRectangle, GetString("sLCDTDisplaySelectedArea"))

    End Sub
    Private _PrevOrigin As Point = Nothing
    Private _FirstTimeOpenned As Boolean = True
    Private _ImageViewer As ImageViewer
    Public Property ImageViewer() As ImageViewer
        Get
            Return _ImageViewer
        End Get
        Set(ByVal value As ImageViewer)
            _ImageViewer = value
        End Set
    End Property

    '_Images is used for Unposted (PDF and previously saved TIFF Files
    Private _Images As List(Of Image)
    Public Property Images() As List(Of Image)
        Get
            Return _Images
        End Get
        Set(ByVal value As List(Of Image))
            _Images = value
        End Set
    End Property

    'Private WithEvents _DocManager As LCWindowDocking.Docking.DockingManager
    'Public Property DocManager() As LCWindowDocking.Docking.DockingManager
    '    Get
    '        Return _DocManager
    '    End Get
    '    Set(ByVal value As LCWindowDocking.Docking.DockingManager)
    '        _DocManager = value
    '    End Set
    'End Property

    'Private _DocContent As LCWindowDocking.Docking.Content
    'Public Property DocContent() As LCWindowDocking.Docking.Content
    '    Get
    '        Return _DocContent
    '    End Get
    '    Set(ByVal value As LCWindowDocking.Docking.Content)
    '        _DocContent = value
    '    End Set
    'End Property
    Private _CropItem As CropItem
    Public Property CropItem() As CropItem
        Get
            Return _CropItem
        End Get
        Set(ByVal value As CropItem)
            _CropItem = value
        End Set
    End Property

    Public Sub SetImage(ByVal InImageViewer As ImageViewer)
        Dim blnSameImageViewerAsPrevious As Boolean
        Try
            blnSameImageViewerAsPrevious = _ImageViewer Is InImageViewer
        Catch ex As Exception
        End Try
        ImageViewer = InImageViewer
        If InImageViewer IsNot Nothing Then
            Dim dblScaleWidth As Double = 1
            Dim dblScaleHeight As Double = 1
            'btnDisplayBarcodeRecognitionRectangle.Visible = ImageViewer.MassItem.Stack.UseBarcode.ToBool
            'btnBarcodeInformation.Visible = ImageViewer.MassItem.Stack.UseBarcode.ToBool
            'btnRotateLeft.Enabled = Not InImageViewer.MassItem.IsUnposted
            'btnRotateRight.Enabled = Not InImageViewer.MassItem.IsUnposted
            'btnDeleteDoc.Enabled = Not InImageViewer.MassItem.IsMassGroupDeleted
            btnRotateLeft.Enabled = True
            btnRotateRight.Enabled = True
            Dim TempImage As Image = Nothing
            Try
                _PrevOrigin = imageViewerFull.Origin
            Catch
            End Try
            'If InImageViewer.MassItem.FileName = "" Then
            '    Me.imageViewerFull.Image = InImageViewer.MassItem.Image
            'Else
            Try
                '_ImageSeq = InImageViewer.MassItem.Sequence
                'If InImageViewer.MassItem.IsUnposted AndAlso InImageViewer.MassItem.Unposted.FromActivityID <> InImageViewer.MassItem.Unposted.ToActivityID Then
                '    Dim oFileInfo As New IO.FileInfo(InImageViewer.MassItem.Unposted.TempFileName)
                '    lblPageOf.Visible = True
                '    btnPrev.Visible = True
                '    btnNext.Visible = True
                '    btnPrev.Enabled = True
                '    btnNext.Enabled = True
                '    'If oFileInfo.Extension.ToUpper = ".PDF" Then
                '    '    If Not blnSameImageViewerAsPrevious Then 'Page Change
                '    '        _Images = New List(Of Image)
                '    '        Dim oPDFToTiff As New PDFtoTiff
                '    '        _Images = oPDFToTiff.GetPDFPages(InImageViewer.MassItem.Unposted.TempFileName, 90, GetWorkingDirectory())
                '    '        TempImage = _Images(InImageViewer.MassItem.CurrentPageIndex)
                '    '        Try
                '    '            InImageViewer.MassItem.Image = TempImage.Clone
                '    '        Catch
                '    '        End Try
                '    '    Else 'Load Up Page
                '    '        TempImage = _Images(InImageViewer.MassItem.CurrentPageIndex)
                '    '        Try
                '    '            InImageViewer.MassItem.Image = TempImage.Clone
                '    '        Catch
                '    '        End Try
                '    '    End If
                '    '    lblPageOf.Text = CStr(InImageViewer.MassItem.CurrentPageIndex + 1) & " of " & InImageViewer.MassItem.PageCount
                '    'Else
                '    _Images = New List(Of Image)
                '        TempImage = Image.FromStream(OpenFileReadOnlyIntoMemoryStream(InImageViewer.MassItem.Unposted.TempFileName)).Clone
                '        TempImage.SelectActiveFrame(System.Drawing.Imaging.FrameDimension.Page, InImageViewer.MassItem.CurrentPageIndex)
                '        _Images.Add(TempImage)
                '        lblPageOf.Text = CStr(InImageViewer.MassItem.CurrentPageIndex + 1) & " of " & InImageViewer.MassItem.PageCount
                '    'End If
                '    If InImageViewer.MassItem.CurrentPageIndex = 0 Then btnPrev.Enabled = False
                '    If InImageViewer.MassItem.CurrentPageIndex = InImageViewer.MassItem.PageCount - 1 Then btnNext.Enabled = False
                'Else
                _Images = New List(Of Image)
                TempImage = Image.FromStream(OpenFileReadOnlyIntoMemoryStream(InImageViewer.CropItem.TempFileName)).Clone
                _Images.Add(TempImage)
                'End If

                'If CInt(btnDisplayBarcodeRecognitionRectangle.Tag) = 1 Then
                '    Dim g As Graphics = Graphics.FromImage(TempImage)

                '    dblScaleWidth = TempImage.Size.Width / ImageViewer.MassItem.Stack.DocWidth
                '    dblScaleHeight = TempImage.Size.Height / ImageViewer.MassItem.Stack.DocHieght

                '    Dim oSelRec As New Rectangle(ImageViewer.MassItem.Stack.IdLeft * dblScaleWidth, ImageViewer.MassItem.Stack.IdTop * dblScaleHeight, ImageViewer.MassItem.Stack.IdWidth * dblScaleWidth, ImageViewer.MassItem.Stack.IdHeight * dblScaleHeight)
                '    Dim intPenSize As Integer
                '    If TempImage.Size.Height > TempImage.Size.Width Then
                '        intPenSize = CInt(TempImage.Size.Height / 1000)
                '    Else
                '        intPenSize = CInt(TempImage.Size.Width / 1000)
                '    End If
                '    If intPenSize < 0 Then intPenSize = 1
                '    Dim oSelPen As New Pen(Color.Red, intPenSize)
                '    g.DrawRectangle(oSelPen, oSelRec)
                'End If

                Me.imageViewerFull.Image = TempImage 'Image.FromFile(InImageViewer.MassItem.TempFileName)

            Catch
            End Try
            'End If
            If Not _PrevOrigin = Nothing Then
                Try
                    imageViewerFull.Origin = _PrevOrigin
                Catch
                End Try
            End If
            If _FirstTimeOpenned Then
                Try
                    'Resize Image On Screen
                    If imageViewerFull.ZoomFactor = 1 Then 'This should be true the first time
                        'Try to find the factor to make the image fit on the screen
                        Dim decWidthFactor = Me.imageViewerFull.Width / imageViewerFull.Image.Width
                        Dim decHeightFactor = Me.imageViewerFull.Height / imageViewerFull.Image.Height
                        If decWidthFactor > decHeightFactor Then
                            imageViewerFull.ZoomFactor = decHeightFactor
                        Else
                            imageViewerFull.ZoomFactor = decWidthFactor
                        End If
                        'TrackBar1_ValueChanged(TrackBar1, Nothing)
                    End If
                Catch
                    Me.Hide()
                End Try
                _FirstTimeOpenned = False
            End If
        Else
            Me.imageViewerFull.Image = New Bitmap(1, 1)
            Me.imageViewerFull.Refresh()
        End If
    End Sub

    Private Sub ImageDialog_Resize(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Resize
        If ImageViewer IsNot Nothing Then
            Me.imageViewerFull.Refresh()
        End If
    End Sub

    Private Sub TrackBar1_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TrackBar1.ValueChanged
        If ImageViewer IsNot Nothing Then
            If _ZoomChanging Then Exit Sub
            If TrackBar1.Value < 1 Then
                imageViewerFull.ZoomFactor = CDbl((TrackBar1.Value + 100) / 110.0)
            Else
                imageViewerFull.ZoomFactor = TrackBar1.Value
            End If
        End If
    End Sub

    Private Sub ImageDialog_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SplitContainer1.Panel2MinSize = 25
        SplitContainer1.IsSplitterFixed = True
        imageViewerFull.ZoomOnMouseWheel = True
        'Me.BackColor = g_appColor.ButtonPanelColor
        'ImageViewer.BackColor = g_appColor.ImageDialogBGColor
        'Me.BackColor = g_appColor.ImageDialogBGColor
    End Sub

    Private Sub imageViewerFull_ZoomFactorChanged(ByVal Factor As Double) Handles imageViewerFull.ZoomFactorChanged
        _ZoomChanging = True
        If Factor < 1 Then
            TrackBar1.Value = CInt((Factor * 110) - 100)
        Else
            TrackBar1.Value = Factor
        End If

        _ZoomChanging = False
    End Sub

    Private Sub btnRotateLeft_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRotateLeft.Click
        If ImageViewer IsNot Nothing Then
            RotateImage(Direction.Left)
            ImageViewer.Refresh()
            SetImage(ImageViewer)
            'ImageViewer.CropItem.StackSession.RotatedImageCollection.Add(New StackSession.MassItemRotateRequest(ImageViewer.MassItem, StackSession.MassItemRotateRequest.Direction.Left))
        End If
    End Sub

    Private Sub btnRotateRight_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRotateRight.Click
        If ImageViewer IsNot Nothing Then
            RotateImage(Direction.Right)
            ImageViewer.Refresh()
            SetImage(ImageViewer)
            'ImageViewer.CropItem.StackSession.RotatedImageCollection.Add(New StackSession.MassItemRotateRequest(ImageViewer.MassItem, StackSession.MassItemRotateRequest.Direction.Right))
        End If
    End Sub

    Public Enum Direction
        Right
        Left
    End Enum
    Public Sub RotateImage(InRotationDirection As Direction)

        Dim rotDirectionAngle As Integer = CInt(IIf(InRotationDirection = Direction.Left, -90, 90))
        Dim saveRotImage As Image = Nothing
        Dim tempSaveRotImage As Image = Nothing
        Dim fileName As String = String.Empty
        Dim tempFileName As IO.FileInfo = New IO.FileInfo(CropItem.TempFileName)
        Try
            CropItem.ImageRotationAngle += rotDirectionAngle
            CropItem.ImageViewer.Image = rotImageWork(CropItem.ImageViewer.SourceImage, CropItem.ImageRotationAngle)
            tempSaveRotImage = Image.FromStream(OpenFileReadOnlyIntoMemoryStream(CropItem.TempFileName))
            saveRotImage = rotImageWork(tempSaveRotImage, rotDirectionAngle)
            fileName = CropItem.TempFileName
            tempSaveRotImage.Dispose()
            tempFileName.Delete()
            saveRotImage.Save(fileName)
            CropItem.TempFileName = fileName
            saveRotImage.Dispose()
        Catch ex As Exception
        End Try
    End Sub

    Public Function rotImageWork(ByVal img As Image, ByVal rotAngle As Integer) As Image
        If img Is Nothing Then
            Throw New ArgumentNullException("image")
        End If

        Const pi2 As Double = Math.PI / 2.0

        Dim oldWidth As Double = CDbl(img.Width)
        Dim oldHeight As Double = CDbl(img.Height)

        ' Convert degrees to radians
        Dim theta As Double = CDbl(rotAngle) * Math.PI / 180.0
        Dim locked_theta As Double = theta

        ' Ensure theta is now [0, 2pi)
        While locked_theta < 0.0
            locked_theta += 2 * Math.PI
        End While

        Dim newWidth As Double, newHeight As Double
        Dim nWidth As Integer, nHeight As Integer

        Dim adjacentTop As Double, oppositeTop As Double
        Dim adjacentBottom As Double, oppositeBottom As Double

        ' We need to calculate the sides of the triangles based
        ' on how much rotation is being done to the bitmap.
        If (locked_theta >= 0.0 AndAlso locked_theta < pi2) OrElse (locked_theta >= Math.PI AndAlso locked_theta < (Math.PI + pi2)) Then
            adjacentTop = Math.Abs(Math.Cos(locked_theta)) * oldWidth
            oppositeTop = Math.Abs(Math.Sin(locked_theta)) * oldWidth

            adjacentBottom = Math.Abs(Math.Cos(locked_theta)) * oldHeight
            oppositeBottom = Math.Abs(Math.Sin(locked_theta)) * oldHeight
        Else
            adjacentTop = Math.Abs(Math.Sin(locked_theta)) * oldHeight
            oppositeTop = Math.Abs(Math.Cos(locked_theta)) * oldHeight

            adjacentBottom = Math.Abs(Math.Sin(locked_theta)) * oldWidth
            oppositeBottom = Math.Abs(Math.Cos(locked_theta)) * oldWidth
        End If

        newWidth = adjacentTop + oppositeBottom
        newHeight = adjacentBottom + oppositeTop

        nWidth = CInt(Math.Ceiling(newWidth))
        nHeight = CInt(Math.Ceiling(newHeight))

        Dim rotatedBmp As New Bitmap(nWidth, nHeight)

        Using g As Graphics = Graphics.FromImage(rotatedBmp)
            ' This array will be used to pass in the three points that 
            ' make up the rotated image
            Dim points As Point()
            If locked_theta >= 0.0 AndAlso locked_theta < pi2 Then

                points = New Point() {New Point(CInt(Math.Truncate(oppositeBottom)), 0), New Point(nWidth, CInt(Math.Truncate(oppositeTop))), New Point(0, CInt(Math.Truncate(adjacentBottom)))}
            ElseIf locked_theta >= pi2 AndAlso locked_theta < Math.PI Then
                points = New Point() {New Point(nWidth, CInt(Math.Truncate(oppositeTop))), New Point(CInt(Math.Truncate(adjacentTop)), nHeight), New Point(CInt(Math.Truncate(oppositeBottom)), 0)}
            ElseIf locked_theta >= Math.PI AndAlso locked_theta < (Math.PI + pi2) Then
                points = New Point() {New Point(CInt(Math.Truncate(adjacentTop)), nHeight), New Point(0, CInt(Math.Truncate(adjacentBottom))), New Point(nWidth, CInt(Math.Truncate(oppositeTop)))}
            Else
                points = New Point() {New Point(0, CInt(Math.Truncate(adjacentBottom))), New Point(CInt(Math.Truncate(oppositeBottom)), 0), New Point(CInt(Math.Truncate(adjacentTop)), nHeight)}
            End If

            g.DrawImage(img, points)
        End Using
        Return rotatedBmp
        img.Dispose()
        rotatedBmp.Dispose()
    End Function
    'Private Sub btnDeleteDoc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteDoc.Click
    '    If ImageViewer IsNot Nothing Then
    '        Dim result As MsgBoxResult
    '        'result = MsgBox(GetString("sLCDTRemoveImagesFromMscan"), MsgBoxStyle.YesNo, GetString("fLCDTmscan"))
    '        result = MsgBox("Remove Image", MsgBoxStyle.YesNo, "Mass Scanning")
    '        If result = MsgBoxResult.Yes Then
    '            Dim collMGIs As New List(Of MassGroupItem)
    '            Try
    '                collMGIs = ImageViewer.MassItem.StackSession.MassGroupItems.MassItems(ImageViewer.MassItem.Sequence)
    '            Catch
    '                Try
    '                    collMGIs.Add(New MassGroupItem(ImageViewer.MassItem.StackSession.MassGroups(MassGroup.DeletedGroupBarCode), ImageViewer.MassItem))
    '                Catch
    '                End Try
    '            End Try
    '            'ImageViewer.MassItem.StackSession.RaiseMassItems_Reassign(Nothing, New StackSession.MassItemsReassigningEventArgs(True, New MassItem() {ImageViewer.MassItem}.ToList))
    '            ImageViewer.MassItem.StackSession.RaiseMassItems_Reassign(Nothing, New StackSession.MassItemsReassigningEventArgs(True, collMGIs))
    '            btnDeleteDoc.Enabled = False
    '        End If
    '    End If
    'End Sub

    Private Sub btnDisplayBarcodeRecognitionRectangle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If ImageViewer IsNot Nothing Then
            'Try
            '    Dim db As New DTPDFInterface.DTPDFDataAccessInterface
            '    Dim strResults = db.ExecuteQueryAssembly("DTPDFDataAccess", "DTMassScanDataAccess", "GetStacksForUser", g_SLUser)
            '    g_DAErrorResult = strResults
            '    Dim oRefreshStack As DTStack = (From oStack As DTPDFDataAccess.lc_dt_scanning In CType(DTPDFDataAccess.ExecuteQueryResults.DeserializeType(strResults, GetType(List(Of DTPDFDataAccess.lc_dt_scanning))), List(Of DTPDFDataAccess.lc_dt_scanning)) Where oStack.stack_id = ImageViewer.MassItem.Stack.ID Select New DTStack(oStack)).FirstOrDefault
            '    g_DAErrorResult = ""
            '    If oRefreshStack IsNot Nothing Then
            '        ImageViewer.MassItem.Stack = oRefreshStack
            '        'If ImageViewer.MassItem.MassGroup.BarCode = "" Then

            '        'End If
            '    End If
            'Catch
            'End Try

            SetImage(ImageViewer)
        End If
    End Sub

    Private Sub btnPanMode_Click(sender As Object, e As EventArgs) Handles btnPanMode.Click
        imageViewerFull.PanMode = Not imageViewerFull.PanMode
        If imageViewerFull.PanMode Then
            btnPanMode.BackColor = Color.Green
        Else
            btnPanMode.BackColor = Color.Red
        End If
    End Sub

    Private Sub btnZoom_Click(sender As Object, e As EventArgs) Handles btnZoom.Click
        imageViewerFull.AutoZoom = Not imageViewerFull.AutoZoom
        If imageViewerFull.AutoZoom Then
            btnZoom.BackColor = Color.Green
        Else
            btnZoom.BackColor = Color.Red
        End If
    End Sub
End Class
