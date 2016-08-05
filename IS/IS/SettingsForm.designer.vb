<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SettingsForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SettingsForm))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnBSave = New System.Windows.Forms.Button()
        Me.btnBEdit = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtTitle = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnUSave = New System.Windows.Forms.Button()
        Me.btnUEdit = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtUsername = New System.Windows.Forms.TextBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtRetypePass = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtNewPass = New System.Windows.Forms.TextBox()
        Me.btnPSave = New System.Windows.Forms.Button()
        Me.btnPEdit = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtCurrentPass = New System.Windows.Forms.TextBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.btnCSave = New System.Windows.Forms.Button()
        Me.btnCEdit = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtCritical = New System.Windows.Forms.TextBox()
        Me.Button9 = New System.Windows.Forms.Button()
        Me.btnNew = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnBSave)
        Me.GroupBox1.Controls.Add(Me.btnBEdit)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtTitle)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(330, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(292, 133)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Current Title"
        '
        'btnBSave
        '
        Me.btnBSave.Enabled = False
        Me.btnBSave.Location = New System.Drawing.Point(156, 86)
        Me.btnBSave.Name = "btnBSave"
        Me.btnBSave.Size = New System.Drawing.Size(129, 35)
        Me.btnBSave.TabIndex = 3
        Me.btnBSave.TabStop = False
        Me.btnBSave.Text = "Save"
        Me.btnBSave.UseVisualStyleBackColor = True
        Me.btnBSave.Visible = False
        '
        'btnBEdit
        '
        Me.btnBEdit.Location = New System.Drawing.Point(20, 86)
        Me.btnBEdit.Name = "btnBEdit"
        Me.btnBEdit.Size = New System.Drawing.Size(129, 35)
        Me.btnBEdit.TabIndex = 2
        Me.btnBEdit.TabStop = False
        Me.btnBEdit.Text = "Edit"
        Me.btnBEdit.UseVisualStyleBackColor = True
        Me.btnBEdit.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(35, 38)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 17)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Business Title:"
        '
        'txtTitle
        '
        Me.txtTitle.Enabled = False
        Me.txtTitle.Location = New System.Drawing.Point(153, 35)
        Me.txtTitle.Name = "txtTitle"
        Me.txtTitle.Size = New System.Drawing.Size(132, 26)
        Me.txtTitle.TabIndex = 0
        Me.txtTitle.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnUSave)
        Me.GroupBox2.Controls.Add(Me.btnUEdit)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.txtUsername)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(292, 133)
        Me.GroupBox2.TabIndex = 4
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Current Username"
        '
        'btnUSave
        '
        Me.btnUSave.Enabled = False
        Me.btnUSave.Location = New System.Drawing.Point(157, 86)
        Me.btnUSave.Name = "btnUSave"
        Me.btnUSave.Size = New System.Drawing.Size(129, 35)
        Me.btnUSave.TabIndex = 3
        Me.btnUSave.TabStop = False
        Me.btnUSave.Text = "Save"
        Me.btnUSave.UseVisualStyleBackColor = True
        '
        'btnUEdit
        '
        Me.btnUEdit.Location = New System.Drawing.Point(18, 86)
        Me.btnUEdit.Name = "btnUEdit"
        Me.btnUEdit.Size = New System.Drawing.Size(129, 35)
        Me.btnUEdit.TabIndex = 2
        Me.btnUEdit.TabStop = False
        Me.btnUEdit.Text = "Edit"
        Me.btnUEdit.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(46, 38)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(81, 17)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Username :"
        '
        'txtUsername
        '
        Me.txtUsername.Enabled = False
        Me.txtUsername.Location = New System.Drawing.Point(153, 35)
        Me.txtUsername.Name = "txtUsername"
        Me.txtUsername.Size = New System.Drawing.Size(132, 26)
        Me.txtUsername.TabIndex = 0
        Me.txtUsername.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.txtRetypePass)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.txtNewPass)
        Me.GroupBox3.Controls.Add(Me.btnPSave)
        Me.GroupBox3.Controls.Add(Me.btnPEdit)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.txtCurrentPass)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(12, 160)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(292, 205)
        Me.GroupBox3.TabIndex = 5
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Current Password"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(7, 105)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(126, 17)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "Retype Password :"
        '
        'txtRetypePass
        '
        Me.txtRetypePass.Enabled = False
        Me.txtRetypePass.Location = New System.Drawing.Point(154, 99)
        Me.txtRetypePass.Name = "txtRetypePass"
        Me.txtRetypePass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtRetypePass.Size = New System.Drawing.Size(132, 26)
        Me.txtRetypePass.TabIndex = 6
        Me.txtRetypePass.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(26, 70)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(108, 17)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "New Password :"
        '
        'txtNewPass
        '
        Me.txtNewPass.Enabled = False
        Me.txtNewPass.Location = New System.Drawing.Point(153, 67)
        Me.txtNewPass.Name = "txtNewPass"
        Me.txtNewPass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtNewPass.Size = New System.Drawing.Size(132, 26)
        Me.txtNewPass.TabIndex = 4
        Me.txtNewPass.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnPSave
        '
        Me.btnPSave.Enabled = False
        Me.btnPSave.Location = New System.Drawing.Point(157, 153)
        Me.btnPSave.Name = "btnPSave"
        Me.btnPSave.Size = New System.Drawing.Size(129, 35)
        Me.btnPSave.TabIndex = 3
        Me.btnPSave.TabStop = False
        Me.btnPSave.Text = "Save"
        Me.btnPSave.UseVisualStyleBackColor = True
        '
        'btnPEdit
        '
        Me.btnPEdit.Location = New System.Drawing.Point(18, 153)
        Me.btnPEdit.Name = "btnPEdit"
        Me.btnPEdit.Size = New System.Drawing.Size(129, 35)
        Me.btnPEdit.TabIndex = 2
        Me.btnPEdit.TabStop = False
        Me.btnPEdit.Text = "Edit"
        Me.btnPEdit.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(7, 38)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(128, 17)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Current Password :"
        '
        'txtCurrentPass
        '
        Me.txtCurrentPass.Enabled = False
        Me.txtCurrentPass.Location = New System.Drawing.Point(153, 35)
        Me.txtCurrentPass.Name = "txtCurrentPass"
        Me.txtCurrentPass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtCurrentPass.Size = New System.Drawing.Size(132, 26)
        Me.txtCurrentPass.TabIndex = 0
        Me.txtCurrentPass.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.btnCSave)
        Me.GroupBox4.Controls.Add(Me.btnCEdit)
        Me.GroupBox4.Controls.Add(Me.Label6)
        Me.GroupBox4.Controls.Add(Me.txtCritical)
        Me.GroupBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.Location = New System.Drawing.Point(330, 160)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(292, 122)
        Me.GroupBox4.TabIndex = 4
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Current Critical Alert "
        '
        'btnCSave
        '
        Me.btnCSave.Enabled = False
        Me.btnCSave.Location = New System.Drawing.Point(157, 70)
        Me.btnCSave.Name = "btnCSave"
        Me.btnCSave.Size = New System.Drawing.Size(129, 35)
        Me.btnCSave.TabIndex = 3
        Me.btnCSave.TabStop = False
        Me.btnCSave.Text = "Save"
        Me.btnCSave.UseVisualStyleBackColor = True
        Me.btnCSave.Visible = False
        '
        'btnCEdit
        '
        Me.btnCEdit.Location = New System.Drawing.Point(17, 70)
        Me.btnCEdit.Name = "btnCEdit"
        Me.btnCEdit.Size = New System.Drawing.Size(129, 35)
        Me.btnCEdit.TabIndex = 2
        Me.btnCEdit.TabStop = False
        Me.btnCEdit.Text = "Edit"
        Me.btnCEdit.UseVisualStyleBackColor = True
        Me.btnCEdit.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(35, 38)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(96, 17)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "Critical Level :"
        '
        'txtCritical
        '
        Me.txtCritical.Enabled = False
        Me.txtCritical.Location = New System.Drawing.Point(153, 35)
        Me.txtCritical.Name = "txtCritical"
        Me.txtCritical.Size = New System.Drawing.Size(132, 26)
        Me.txtCritical.TabIndex = 0
        Me.txtCritical.Text = "10"
        Me.txtCritical.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Button9
        '
        Me.Button9.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button9.Location = New System.Drawing.Point(493, 313)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(129, 35)
        Me.Button9.TabIndex = 8
        Me.Button9.TabStop = False
        Me.Button9.Text = "Done"
        Me.Button9.UseVisualStyleBackColor = True
        '
        'btnNew
        '
        Me.btnNew.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNew.Location = New System.Drawing.Point(347, 313)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(129, 35)
        Me.btnNew.TabIndex = 9
        Me.btnNew.TabStop = False
        Me.btnNew.Text = "Add/Remove"
        Me.btnNew.UseVisualStyleBackColor = True
        Me.btnNew.Visible = False
        '
        'SettingsForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(634, 375)
        Me.Controls.Add(Me.btnNew)
        Me.Controls.Add(Me.Button9)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "SettingsForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Settings"
        Me.TopMost = True
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnBSave As System.Windows.Forms.Button
    Friend WithEvents btnBEdit As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtTitle As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnUSave As System.Windows.Forms.Button
    Friend WithEvents btnUEdit As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtUsername As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtRetypePass As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtNewPass As System.Windows.Forms.TextBox
    Friend WithEvents btnPSave As System.Windows.Forms.Button
    Friend WithEvents btnPEdit As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtCurrentPass As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents btnCSave As System.Windows.Forms.Button
    Friend WithEvents btnCEdit As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtCritical As System.Windows.Forms.TextBox
    Friend WithEvents Button9 As System.Windows.Forms.Button
    Friend WithEvents btnNew As System.Windows.Forms.Button

End Class
