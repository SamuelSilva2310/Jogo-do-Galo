﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Vitoria
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
        Me.Voltar = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Voltar
        '
        Me.Voltar.Location = New System.Drawing.Point(131, 121)
        Me.Voltar.Name = "Voltar"
        Me.Voltar.Size = New System.Drawing.Size(100, 51)
        Me.Voltar.TabIndex = 0
        Me.Voltar.Text = "Voltar"
        Me.Voltar.UseVisualStyleBackColor = True
        '
        'Vitoria
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.Voltar)
        Me.Name = "Vitoria"
        Me.Text = "Vitoria"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Voltar As Button
End Class
