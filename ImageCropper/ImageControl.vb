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
<System.Runtime.InteropServices.ComVisible(False)> _
Public Class ImageControl
    Public Event ZoomFactorChanged(ByVal Factor As Double)

    Private m_ScrollVisible As Boolean = True

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
    End Sub

#Region "Public Properties"

    Public Property PanMode() As Boolean
        Get
            Return DrawingBoard1.PanMode
        End Get
        Set(ByVal value As Boolean)
            DrawingBoard1.PanMode = value
        End Set
    End Property
    Public Property AutoZoom() As Boolean
        Get
            Return DrawingBoard1.AutoZoom
        End Get
        Set(ByVal value As Boolean)
            DrawingBoard1.AutoZoom = value
        End Set
    End Property
    Public Property PanCursor() As Cursor
        Get
            Return DrawingBoard1.Cursor
        End Get
        Set(ByVal value As Cursor)
            DrawingBoard1.Cursor = value
        End Set
    End Property
    Public Property PanButton() As System.Windows.Forms.MouseButtons
        Get
            Return DrawingBoard1.PanButton
        End Get
        Set(ByVal value As System.Windows.Forms.MouseButtons)
            DrawingBoard1.PanButton = value
        End Set
    End Property

    Public Property ZoomOnMouseWheel() As Boolean
        Get
            Return DrawingBoard1.ZoomOnMouseWheel
        End Get
        Set(ByVal value As Boolean)
            DrawingBoard1.ZoomOnMouseWheel = value
        End Set
    End Property

    Public Property ZoomFactor() As Double
        Get
            Return DrawingBoard1.ZoomFactor
        End Get
        Set(ByVal value As Double)
            DrawingBoard1.ZoomFactor = value
        End Set
    End Property

    Public Property Origin() As System.Drawing.Point
        Get
            Return DrawingBoard1.Origin
        End Get
        Set(ByVal value As System.Drawing.Point)
            DrawingBoard1.Origin = value
        End Set
    End Property

    Public Property StretchImageToFit() As Boolean
        Get
            Return Me.DrawingBoard1.StretchImageToFit
        End Get
        Set(ByVal value As Boolean)
            Me.DrawingBoard1.StretchImageToFit = value
        End Set
    End Property

    Public ReadOnly Property ApparentImageSize() As System.Drawing.Size
        Get
            Return DrawingBoard1.ApparentImageSize
        End Get
    End Property

    Public Sub fittoscreen()
        Me.DrawingBoard1.fittoscreen()
    End Sub

    Public Sub InvertColors()
        Me.DrawingBoard1.InvertColors()
    End Sub

    Public Sub ZoomIn()
        Me.DrawingBoard1.ZoomIn()
    End Sub

    Public Sub ZoomOut()
        Me.DrawingBoard1.ZoomOut()
    End Sub

    Public Property ScrollbarsVisible() As Boolean
        Get
            Return m_ScrollVisible
        End Get
        Set(ByVal value As Boolean)
            m_ScrollVisible = value
            Me.HScrollBar1.Visible = value
            Me.VScrollBar1.Visible = value
            If value = False Then
                Me.DrawingBoard1.Dock = DockStyle.Fill
            Else
                Me.DrawingBoard1.Dock = DockStyle.None
                Me.DrawingBoard1.Location = New Point(0, 0)
                Me.DrawingBoard1.Width = ClientSize.Width - VScrollBar1.Width
                Me.DrawingBoard1.Height = ClientSize.Height - HScrollBar1.Height

            End If
        End Set
    End Property

#End Region

#Region "Public/Private Shadows"
    Public Shadows Property Image() As System.Drawing.Image
        Get
            Return DrawingBoard1.Image
        End Get
        Set(ByVal Value As System.Drawing.Image)
            DrawingBoard1.Image = Value
            If Value Is Nothing Then
                HScrollBar1.Enabled = False
                VScrollBar1.Enabled = False
                Exit Property
            End If
        End Set
    End Property

    Public Shadows Property initialimage() As System.Drawing.Image
        Get
            Return DrawingBoard1.initialimage
        End Get
        Set(ByVal value As System.Drawing.Image)
            DrawingBoard1.initialimage = value
            If value Is Nothing Then
                HScrollBar1.Enabled = False
                VScrollBar1.Enabled = False
                Exit Property
            End If
        End Set
    End Property

    Public Shadows Property BackgroundImage() As System.Drawing.Image
        Get
            Return DrawingBoard1.BackgroundImage
        End Get
        Set(ByVal Value As System.Drawing.Image)
            DrawingBoard1.BackgroundImage = Value
            If Value Is Nothing Then
                HScrollBar1.Enabled = False
                VScrollBar1.Enabled = False
                Exit Property
            End If
        End Set
    End Property

#End Region

    Public Sub RotateFlip(ByVal RotateFlipType As System.Drawing.RotateFlipType)
        DrawingBoard1.RotateFlip(RotateFlipType)
    End Sub

    Private Sub DrawingBoard1_SetScrollPositions() Handles DrawingBoard1.SetScrollPositions

        Dim DrawingWidth As Integer = DrawingBoard1.Image.Width
        Dim DrawingHeight As Integer = DrawingBoard1.Image.Height
        Dim OriginX As Integer = DrawingBoard1.Origin.X
        Dim OriginY As Integer = DrawingBoard1.Origin.Y
        Dim FactoredCtrlWidth As Integer = DrawingBoard1.Width / DrawingBoard1.ZoomFactor
        Dim FactoredCtrlHeight As Integer = DrawingBoard1.Height / DrawingBoard1.ZoomFactor
        HScrollBar1.Maximum = Me.DrawingBoard1.Image.Width
        VScrollBar1.Maximum = Me.DrawingBoard1.Image.Height

        If FactoredCtrlWidth >= DrawingBoard1.Image.Width Or StretchImageToFit Then
            HScrollBar1.Enabled = False
            HScrollBar1.Value = 0
        Else
            HScrollBar1.LargeChange = FactoredCtrlWidth
            HScrollBar1.Enabled = True
            HScrollBar1.Value = OriginX
        End If

        If FactoredCtrlHeight >= DrawingBoard1.Image.Height Or StretchImageToFit Then
            VScrollBar1.Enabled = False
            VScrollBar1.Value = 0
        Else
            VScrollBar1.Enabled = True
            VScrollBar1.LargeChange = FactoredCtrlHeight
            VScrollBar1.Value = OriginY
        End If

    End Sub

    Private Sub ScrollBar_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles HScrollBar1.ValueChanged, VScrollBar1.ValueChanged
        Me.DrawingBoard1.Origin = New Point(HScrollBar1.Value, VScrollBar1.Value)
    End Sub

    Private Sub DrawingBoard1_ZoomFactorChanged(ByVal Factor As Double) Handles DrawingBoard1.ZoomFactorChanged
        RaiseEvent ZoomFactorChanged(Factor)
    End Sub
End Class
