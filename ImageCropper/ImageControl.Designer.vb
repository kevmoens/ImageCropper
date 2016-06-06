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
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ImageControl
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.VScrollBar1 = New System.Windows.Forms.VScrollBar
        Me.HScrollBar1 = New System.Windows.Forms.HScrollBar
        Me.DrawingBoard1 = New DrawingBoard
        Me.SuspendLayout()
        '
        'VScrollBar1
        '
        Me.VScrollBar1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.VScrollBar1.Enabled = False
        Me.VScrollBar1.LargeChange = 20
        Me.VScrollBar1.Location = New System.Drawing.Point(199, 0)
        Me.VScrollBar1.Name = "VScrollBar1"
        Me.VScrollBar1.Size = New System.Drawing.Size(17, 137)
        Me.VScrollBar1.TabIndex = 1
        '
        'HScrollBar1
        '
        Me.HScrollBar1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.HScrollBar1.Enabled = False
        Me.HScrollBar1.LargeChange = 20
        Me.HScrollBar1.Location = New System.Drawing.Point(0, 137)
        Me.HScrollBar1.Name = "HScrollBar1"
        Me.HScrollBar1.Size = New System.Drawing.Size(200, 17)
        Me.HScrollBar1.TabIndex = 2
        '
        'DrawingBoard1
        '
        Me.DrawingBoard1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DrawingBoard1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DrawingBoard1.Image = Nothing
        Me.DrawingBoard1.initialimage = Nothing
        Me.DrawingBoard1.Location = New System.Drawing.Point(0, -1)
        Me.DrawingBoard1.Name = "DrawingBoard1"
        Me.DrawingBoard1.Origin = New System.Drawing.Point(0, 0)
        Me.DrawingBoard1.PanButton = System.Windows.Forms.MouseButtons.Left
        Me.DrawingBoard1.Size = New System.Drawing.Size(200, 138)
        Me.DrawingBoard1.TabIndex = 0
        Me.DrawingBoard1.ZoomFactor = 1
        Me.DrawingBoard1.ZoomOnMouseWheel = True
        '
        'ImageControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.HScrollBar1)
        Me.Controls.Add(Me.VScrollBar1)
        Me.Controls.Add(Me.DrawingBoard1)
        Me.Name = "ImageControl"
        Me.Size = New System.Drawing.Size(217, 155)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DrawingBoard1 As DrawingBoard
    Friend WithEvents VScrollBar1 As System.Windows.Forms.VScrollBar
    Friend WithEvents HScrollBar1 As System.Windows.Forms.HScrollBar

End Class
