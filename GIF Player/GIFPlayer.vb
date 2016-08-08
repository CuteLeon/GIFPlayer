Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Image
Imports System.Drawing.Imaging
Imports System.Threading
Public Class GIFPlayer


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim FormGraphics As Graphics = Me.CreateGraphics
        Dim GIFBitmap As Bitmap = My.Resources.Resource.GIFTest
        Dim GIFFrame As Guid()
        GIFFrame = GIFBitmap.FrameDimensionsList()
        Dim TempFrame As New FrameDimension(GIFFrame(0))
        Dim FrameCount As Integer = GIFBitmap.GetFrameCount(TempFrame)
        Dim PropertyIndex As Integer = 0
        Dim IntervalBytes(3) As Byte
        Dim TimeInterval As Integer
        Dim IntervalProperty As PropertyItem = Nothing
        For Index As Integer = 0 To FrameCount - 1
            GIFBitmap.SelectActiveFrame(TempFrame, Index)
            For PropertyIndex = 0 To GIFBitmap.PropertyIdList.Length - 1
                If GIFBitmap.PropertyIdList.GetValue(PropertyIndex) = 20736 Then 'ID为20736的属性保存的是时间间隔
                    IntervalProperty = GIFBitmap.PropertyItems.GetValue(PropertyIndex)
                    IntervalBytes(0) = IntervalProperty.Value(0 + Index * 4)
                    IntervalBytes(1) = IntervalProperty.Value(1 + Index * 4)
                    IntervalBytes(2) = IntervalProperty.Value(2 + Index * 4)
                    IntervalBytes(3) = IntervalProperty.Value(3 + Index * 4)
                    TimeInterval = BitConverter.ToInt32(IntervalBytes, 0) * 10
                    Exit For
                End If
            Next
            FormGraphics.DrawImage(GIFBitmap, 0, 0)
            '经过Graphics.DrawImage后的就是GIF的分解帧
            'TimeInterval是每一帧的时间间隔
            Me.Refresh()
            Threading.Thread.Sleep(TimeInterval)
        Next
        Debug.Print("3")
    End Sub

End Class