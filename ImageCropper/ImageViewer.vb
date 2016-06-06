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
Imports System.Drawing
Imports System.Data
Imports System.Text
Imports System.Windows.Forms
Imports System.Drawing.Drawing2D
Imports System.Drawing.Text

Partial Public Class ImageViewer
    Inherits Panel
    Private m_Image As Image
    Private m_ImageLocation As String
    Public Event RequestPopup As MouseEventHandler

    Private m_IsThumbnail As Boolean
    Private m_IsActive As Boolean

    Public Sub New()
        m_IsThumbnail = False
        m_IsActive = False

        Try
            Me.BackColor = Me.Parent.BackColor ' Color.Transparent
        Catch ex As Exception

        End Try
        InitializeComponent()
    End Sub

    Private _SelectedColor As Color
    Public Property SelectedColor() As Color
        Get
            Return _SelectedColor
        End Get
        Set(ByVal value As Color)
            _SelectedColor = value
        End Set
    End Property

    Public Property Image() As Image
        Get
            Return m_Image
        End Get
        Set(ByVal value As Image)
            m_Image = value
        End Set
    End Property

    Public Property ImageLocation() As String
        Get
            Return m_ImageLocation
        End Get
        Set(ByVal value As String)
            m_ImageLocation = value
        End Set
    End Property

    Public Property IsActive() As Boolean
        Get
            Return m_IsActive
        End Get
        Set(ByVal value As Boolean)
            m_IsActive = value
            Me.Refresh()
        End Set
    End Property

    Public Property IsThumbnail() As Boolean
        Get
            Return m_IsThumbnail
        End Get
        Set(ByVal value As Boolean)
            m_IsThumbnail = value
        End Set
    End Property

    Private _SourceImage As Image
    Public Property SourceImage() As Image
        Get
            Return _SourceImage
        End Get
        Set(ByVal value As Image)
            _SourceImage = value
        End Set
    End Property

    Private _CropItem As CropItem
    Public Property CropItem() As CropItem
        Get
            Return _CropItem
        End Get
        Set(ByVal value As CropItem)
            _CropItem = value
        End Set
    End Property

    'Private _MassItem As MassItem
    'Public Property MassItem() As MassItem
    '    Get
    '        Return _MassItem
    '    End Get
    '    Set(ByVal value As MassItem)
    '        _MassItem = value
    '    End Set
    'End Property

    Public Sub ImageSizeChanged(ByVal sender As Object, ByVal e As ThumbnailImageEventArgs)
        Me.Width = e.Size
        Me.Height = e.Size
        Me.Refresh()
    End Sub

    Public Sub LoadImage(ByVal imageFilename As String, ByVal width As Integer, ByVal height As Integer)
        Dim tempImage As Image
        Try
            tempImage = Image.FromStream(OpenFileReadOnlyIntoMemoryStream(imageFilename))
        Catch
            Exit Sub
        End Try
        m_ImageLocation = imageFilename

        Dim dw As Integer = tempImage.Width
        Dim dh As Integer = tempImage.Height
        Dim tw As Integer = width * 2
        Dim th As Integer = height * 2
        Dim zw As Double = (tw / CDbl(dw))
        Dim zh As Double = (th / CDbl(dh))
        Dim z As Double = If((zw <= zh), zw, zh)
        dw = CInt(Math.Truncate(dw * z))
        dh = CInt(Math.Truncate(dh * z))

        m_Image = New Bitmap(dw, dh)
        Dim g As Graphics = Graphics.FromImage(m_Image)
        g.InterpolationMode = InterpolationMode.HighQualityBicubic
        g.DrawImage(tempImage, 0, 0, dw, dh)
        g.Dispose()
        _SourceImage = m_Image.Clone()
        tempImage.Dispose()
    End Sub

    Public Sub LoadImage(ByVal InImage As Image, ByVal width As Integer, ByVal height As Integer)
        Dim tempImage As Image = InImage  'Image.FromFile(imageFilename)
        m_ImageLocation = ""

        'Dim dw As Integer = tempImage.Width
        'Dim dh As Integer = tempImage.Height
        'Dim tw As Integer = width
        'Dim th As Integer = height
        'Dim zw As Double = (tw / CDbl(dw))
        'Dim zh As Double = (th / CDbl(dh))
        'Dim z As Double = If((zw <= zh), zw, zh)
        'dw = CInt(Math.Truncate(dw * z))
        'dh = CInt(Math.Truncate(dh * z))

        'm_Image = New Bitmap(dw, dh)
        'Dim g As Graphics = Graphics.FromImage(m_Image)
        'g.InterpolationMode = InterpolationMode.HighQualityBicubic
        'g.DrawImage(tempImage, 0, 0, dw, dh)
        'g.Dispose()
        m_Image = InImage
        'tempImage.Dispose()
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        Dim g As Graphics = e.Graphics
        If g Is Nothing Then
            Return
        End If
        If m_Image Is Nothing Then
            Return
        End If
        Dim intDescriptionTextHeight As Integer = 12
        Dim dw As Integer = m_Image.Width
        Dim dh As Integer = m_Image.Height
        Dim tw As Integer = Me.Width - 12
        ' remove border, 4*4 
        Dim th As Integer = Me.Height - 12 - intDescriptionTextHeight
        ' remove border, 4*4 
        Dim zw As Double = (tw / CDbl(dw))
        Dim zh As Double = (th / CDbl(dh))
        Dim z As Double = If((zw <= zh), zw, zh)

        dw = CInt(Math.Truncate(dw * z))
        dh = CInt(Math.Truncate(dh * z))
        Dim dl As Integer = 4 + (tw - dw) \ 2
        ' add border 2*2
        Dim dt As Integer = 4 + (th - dh) \ 2
        ' add border 2*2

        g.FillRectangle(New SolidBrush(Me.Parent.BackColor), New RectangleF(0, 0, Me.Width, Me.Height))

        g.DrawRectangle(New Pen(Color.Gray), dl, dt, dw, dh)

        If m_IsThumbnail Then
            For j As Integer = 0 To 1
                'Horizontal
                g.DrawLine(New Pen(Color.DarkGray), New Point(dl + 3, dt + dh + 1 + j), New Point(dl + dw + 2, dt + dh + 1 + j))
                'If MassItem.PageCount > 1 Then
                '    g.DrawLine(New Pen(Color.FromArgb(255, 140, 140, 140)), New Point(dl + 8, dt + dh + 1 + j + 4), New Point(dl + dw + 6, dt + dh + 1 + j + 4))
                '    g.DrawLine(New Pen(Color.FromArgb(255, 140, 140, 140)), New Point(dl + 8, dt + dh + 1 + j + 4), New Point(dl + dw + 6, dt + dh + 1 + j + 4))
                'End If
                'Vertical
                g.DrawLine(New Pen(Color.DarkGray), New Point(dl + dw + 1 + j, dt + 3), New Point(dl + dw + 1 + j, dt + dh + 2))
                'If MassItem.PageCount > 1 Then
                '    g.DrawLine(New Pen(Color.FromArgb(255, 140, 140, 140)), New Point(dl + dw + 1 + j + 4, dt + 8), New Point(dl + dw + 1 + j + 4, dt + dh + 6))
                '    g.DrawLine(New Pen(Color.FromArgb(255, 140, 140, 140)), New Point(dl + dw + 1 + j + 4, dt + 8), New Point(dl + dw + 1 + j + 4, dt + dh + 6))
                'End If
            Next
        End If

        g.DrawImage(m_Image, dl, dt, dw, dh)

        'If m_IsActive Then
        If Me.BackColor <> Me.Parent.BackColor Then
            g.DrawRectangle(New Pen(Color.White, 1), dl, dt, dw, dh)
            g.DrawRectangle(New Pen(Me.BackColor, 2), dl - 2, dt - 2, dw + 4, dh + 4)
        End If
        If Me.BackColor.R = 51 And Me.BackColor.G = 153 And Me.BackColor.B = 255 Then 'Selected 
            g.DrawRectangle(New Pen(Me.SelectedColor, 2), dl - 2, dt - 2, dw + 4, dh + 4)
        End If

        'Description Text
        Dim rectMultiPage As New Rectangle(dl + dw - 28, Height - 25 - intDescriptionTextHeight - 10, 25, 25)
        Dim rectDesc As New RectangleF(0, Height - intDescriptionTextHeight, Width, intDescriptionTextHeight)
        Dim f As New StringFormat()
        Dim ofntCnt = New Font("Arial", 18, FontStyle.Bold, GraphicsUnit.Pixel)
        Dim ofntDesc = New Font("Arial", 12, FontStyle.Regular, GraphicsUnit.Pixel)
        f.Alignment = StringAlignment.Center
        f.LineAlignment = StringAlignment.Center
        Dim oStringSize As SizeF
        Dim strDescText As String

        'If MassItem.IsUnposted Then
        '    strDescText = MassItem.GetStatusMainText
        'Else
        '    If MassItem.GetMassItemGroups.Count > 1 Then
        '        'strDescText = MassItem.Stack.description & " (" & MassItem.GetMassItemGroups.Count.ToString & " " & GetString("sLCDTMatches") & ")"
        '        strDescText = MassItem.Stack.description & " (" & MassItem.GetMassItemGroups.Count.ToString & " " & "Matches" & ")"
        '    Else
        '        strDescText = MassItem.Stack.description
        '    End If
        'End If

        oStringSize = g.MeasureString(strDescText, ofntDesc, New SizeF(rectDesc.Width, rectDesc.Height), f)

        If Me.BackColor.R = 51 And Me.BackColor.G = 153 And Me.BackColor.B = 255 Then 'Selected 
            Dim intSelX As Integer = 0
            Dim intSelWidth As Integer = Width
            If oStringSize.Width < Width Then
                intSelX = CInt(Math.Truncate((Width - oStringSize.Width) / 2))
                intSelWidth = oStringSize.Width
            End If
            g.FillRectangle(New SolidBrush(Color.FromArgb(128, Me.SelectedColor.R, Me.SelectedColor.G, Me.SelectedColor.B)), New Rectangle(intSelX, Height - intDescriptionTextHeight + 1, intSelWidth, intDescriptionTextHeight - 1))
        End If

        g.DrawString(strDescText, ofntDesc, Brushes.Black, rectDesc, f)
    End Sub
    Protected Overrides Sub OnKeyDown(ByVal e As System.Windows.Forms.KeyEventArgs)
        MyBase.OnKeyDown(e)
    End Sub
    Protected Overrides Sub OnClick(ByVal e As EventArgs)
        'Me.Focus() 'Fixes Scrolling in Flow Layout Panel
        Me.Parent.Focus()
        MyBase.OnClick(e)
    End Sub


    'Private Sub ImageViewer_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseClick
    '    If e.Button = Windows.Forms.MouseButtons.Right Then
    '        RaiseEvent RequestPopup(_MassItem, e)
    '    End If
    'End Sub


    Private Sub HighlightTextBox(ByVal g As Graphics, ByVal InText As String, ByVal InFont As Font, ByVal InRectangle As Rectangle, ByVal InOutlineColor As System.Drawing.Color, ByVal InFaceColor As System.Drawing.Color, ByVal InBackColorTop As System.Drawing.Color, ByVal InBackColorBottom As System.Drawing.Color)
        Try
            'Set the Graphics Buffer

            Dim f As StringFormat = StringFormat.GenericTypographic
            f.Alignment = StringAlignment.Center
            f.LineAlignment = StringAlignment.Center
            'Dim bBack As New SolidBrush(InBackColor)
            Dim bBack As New Drawing2D.LinearGradientBrush(InRectangle, InBackColorTop, InBackColorBottom, LinearGradientMode.ForwardDiagonal)
            g.FillRectangle(bBack, InRectangle)
            ''==== EDGE/FACE ==========================
            Dim pth As New GraphicsPath
            g.TextRenderingHint = TextRenderingHint.AntiAlias
            g.SmoothingMode = SmoothingMode.AntiAlias
            pth.AddString(InText, InFont.FontFamily, FontStyle.Regular, InFont.Size, InRectangle, f)
            'pen size is the size of the edge
            Dim P As New Pen(InOutlineColor, 1)
            'Draw the face
            Dim bFace As New SolidBrush(InFaceColor)
            g.FillPath(bFace, pth)
            'Draw the edge
            g.DrawPath(P, pth)
            'Clean(up)
            pth.Dispose()

        Catch MyError As Exception
        Finally
        End Try
    End Sub
End Class
