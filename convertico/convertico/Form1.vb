Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs)
        'Dim open As New OpenFileDialog
        'open.Filter = "Chọn ảnh bạn cần thêm (*.jpg;*.png;*.gif)|*.jpg;*.png;*.gif"
        'If open.ShowDialog = DialogResult.OK Then
        '    PictureBox1.Image = Image.FromFile(open.FileName)
        'End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Dim oOpenFileDialog As OpenFileDialog
            Dim oSaveFileDialog As SaveFileDialog
            Dim oBitmap As Bitmap
            Dim HIcon As IntPtr
            Dim newIcon As Icon
        Dim oFileStream As IO.FileStream


        oOpenFileDialog = New OpenFileDialog
            oOpenFileDialog.Filter = "Chọn ảnh bạn cần thêm (*.jpg;*.png;*.gif)|*.jpg;*.png;*.gif"
            If oOpenFileDialog.ShowDialog = Windows.Forms.DialogResult.OK Then
                TextBox1.Text = oOpenFileDialog.FileName

                ' Create a Bitmap object from an image file.
                oBitmap = New Bitmap(oOpenFileDialog.FileName)

                ' Get an Hicon for myBitmap.
                HIcon = oBitmap.GetHicon()

                ' Create a new icon from the handle.
                newIcon = System.Drawing.Icon.FromHandle(HIcon)

                ' Set the form Icon attribute to the new icon.
                Me.Icon = newIcon
            Try
                'Save the bitmap to new file
                oSaveFileDialog = New SaveFileDialog
                oSaveFileDialog.Filter = "Định dạng icon (*.ico)|*.ico"
                'oSaveFileDialog.AddExtension = True
                If oSaveFileDialog.ShowDialog = Windows.Forms.DialogResult.OK Then
                    oFileStream = New IO.FileStream(oSaveFileDialog.FileName, IO.FileMode.CreateNew)
                    newIcon.Save(oFileStream)
                    oFileStream.Close()
                    'MsgBox("Đã lưu tệp ico thành công")
                    Label2.Text = "Bạn đã lưu thành công định dạng ICO"

                End If
            Catch ex As Exception
                MessageBox.Show("Có lỗi xảy ra với đường dẫn hoặc trùng tên ảnh, xin kiểm tra lại" &
    vbNewLine & "Dưới đây là mã lỗi: " & vbNewLine & String.Format("Error: {0}", ex.Message))
            End Try
        End If

    End Sub

End Class

