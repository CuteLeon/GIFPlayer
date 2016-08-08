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
        Debug.Print("1")
        GIFFrame = GIFBitmap.FrameDimensionsList()
        Dim TempFrame As New FrameDimension(GIFFrame(0))
        Dim FrameCount As Integer = GIFBitmap.GetFrameCount(TempFrame)
        Debug.Print("2")
        For Index As Integer = 0 To FrameCount - 1
            GIFBitmap.SelectActiveFrame(TempFrame, Index)
            FormGraphics.DrawImage(GIFBitmap, 0, 0)
            '经过Graphics.DrawImage后的就是GIF的分解帧
            Me.Refresh()
            Threading.Thread.Sleep(10)
        Next
        Debug.Print("3")
    End Sub

End Class