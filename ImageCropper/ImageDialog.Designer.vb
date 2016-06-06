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

Partial Class ImageDialog
    ''' <summary>
    ''' Required designer variable.
    ''' </summary>
    Private components As System.ComponentModel.IContainer = Nothing

    ''' <summary>
    ''' Clean up any resources being used.
    ''' </summary>
    ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso (components IsNot Nothing) Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

#Region "Windows Form Designer generated code"

    ''' <summary>
    ''' Required method for Designer support - do not modify
    ''' the contents of this method with the code editor.
    ''' </summary>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ImageDialog))
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.btnRotateRight = New System.Windows.Forms.Button()
        Me.btnRotateLeft = New System.Windows.Forms.Button()
        Me.TrackBar1 = New System.Windows.Forms.TrackBar()
        Me.tipDisplayBarcodeRecognitionRectangle = New System.Windows.Forms.ToolTip(Me.components)
        Me.tipBarcodeInformation = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnPanMode = New System.Windows.Forms.Button()
        Me.btnZoom = New System.Windows.Forms.Button()
        Me.imageViewerFull = New ImageCropper.ImageControl()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.TrackBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.imageViewerFull)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnZoom)
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnPanMode)
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnRotateRight)
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnRotateLeft)
        Me.SplitContainer1.Panel2.Controls.Add(Me.TrackBar1)
        Me.SplitContainer1.Size = New System.Drawing.Size(887, 577)
        Me.SplitContainer1.SplitterDistance = 535
        Me.SplitContainer1.TabIndex = 0
        '
        'btnRotateRight
        '
        Me.btnRotateRight.BackgroundImage = Global.ImageCropper.My.Resources.Resources.RotateRight
        Me.btnRotateRight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnRotateRight.Location = New System.Drawing.Point(38, 3)
        Me.btnRotateRight.Name = "btnRotateRight"
        Me.btnRotateRight.Size = New System.Drawing.Size(20, 20)
        Me.btnRotateRight.TabIndex = 2
        Me.btnRotateRight.UseVisualStyleBackColor = True
        '
        'btnRotateLeft
        '
        Me.btnRotateLeft.BackgroundImage = Global.ImageCropper.My.Resources.Resources.RotateLeft
        Me.btnRotateLeft.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnRotateLeft.Image = Global.ImageCropper.My.Resources.Resources.RotateLeft
        Me.btnRotateLeft.Location = New System.Drawing.Point(12, 3)
        Me.btnRotateLeft.Name = "btnRotateLeft"
        Me.btnRotateLeft.Size = New System.Drawing.Size(20, 20)
        Me.btnRotateLeft.TabIndex = 1
        Me.btnRotateLeft.UseVisualStyleBackColor = True
        '
        'TrackBar1
        '
        Me.TrackBar1.LargeChange = 3
        Me.TrackBar1.Location = New System.Drawing.Point(90, 3)
        Me.TrackBar1.Maximum = 15
        Me.TrackBar1.Minimum = -10
        Me.TrackBar1.Name = "TrackBar1"
        Me.TrackBar1.Size = New System.Drawing.Size(104, 45)
        Me.TrackBar1.TabIndex = 0
        Me.TrackBar1.TickStyle = System.Windows.Forms.TickStyle.None
        '
        'btnPanMode
        '
        Me.btnPanMode.BackColor = System.Drawing.Color.Red
        Me.btnPanMode.Location = New System.Drawing.Point(201, 4)
        Me.btnPanMode.Name = "btnPanMode"
        Me.btnPanMode.Size = New System.Drawing.Size(44, 23)
        Me.btnPanMode.TabIndex = 3
        Me.btnPanMode.Text = "Pan"
        Me.btnPanMode.UseVisualStyleBackColor = False
        '
        'btnZoom
        '
        Me.btnZoom.BackColor = System.Drawing.Color.Red
        Me.btnZoom.Location = New System.Drawing.Point(258, 4)
        Me.btnZoom.Name = "btnZoom"
        Me.btnZoom.Size = New System.Drawing.Size(44, 23)
        Me.btnZoom.TabIndex = 4
        Me.btnZoom.Text = "Zoom"
        Me.btnZoom.UseVisualStyleBackColor = False
        '
        'imageViewerFull
        '
        Me.imageViewerFull.AutoZoom = False
        Me.imageViewerFull.Dock = System.Windows.Forms.DockStyle.Fill
        Me.imageViewerFull.Image = Nothing
        Me.imageViewerFull.initialimage = Nothing
        Me.imageViewerFull.Location = New System.Drawing.Point(0, 0)
        Me.imageViewerFull.Name = "imageViewerFull"
        Me.imageViewerFull.Origin = New System.Drawing.Point(0, 0)
        Me.imageViewerFull.PanButton = System.Windows.Forms.MouseButtons.Left
        Me.imageViewerFull.PanCursor = System.Windows.Forms.Cursors.Default
        Me.imageViewerFull.PanMode = True
        Me.imageViewerFull.ScrollbarsVisible = True
        Me.imageViewerFull.Size = New System.Drawing.Size(887, 535)
        Me.imageViewerFull.StretchImageToFit = False
        Me.imageViewerFull.TabIndex = 0
        Me.imageViewerFull.ZoomFactor = 1.0R
        Me.imageViewerFull.ZoomOnMouseWheel = True
        '
        'ImageDialog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(887, 577)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "ImageDialog"
        Me.ShowIcon = False
        Me.Text = "Image Viewer"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.TrackBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents TrackBar1 As System.Windows.Forms.TrackBar
    Friend WithEvents imageViewerFull As ImageControl
    Friend WithEvents btnRotateLeft As System.Windows.Forms.Button
    Friend WithEvents btnRotateRight As System.Windows.Forms.Button
    Friend WithEvents tipDisplayBarcodeRecognitionRectangle As System.Windows.Forms.ToolTip
    Friend WithEvents tipBarcodeInformation As System.Windows.Forms.ToolTip
    Friend WithEvents btnPanMode As Button
    Friend WithEvents btnZoom As Button

#End Region

End Class
