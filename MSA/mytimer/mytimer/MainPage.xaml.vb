' The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

''' <summary>
''' An empty page that can be used on its own or navigated to within a Frame.
''' </summary>
Public NotInheritable Class MainPage
    Inherits Page
    Private timer As DispatcherTimer
    Private CountDown As Integer
    Private Hours As Integer
    Private Minutes As Integer
    Private Seconds As Integer


    Private Sub btnCountDown_Click(sender As Object, e As RoutedEventArgs) Handles btnCountDown.Click

        Hours = Hour.Text
        Minutes = Min.Text
        Seconds = Sec.Text
        CountDown = Hours * 60 * 60 + Minutes * 60 + Seconds
        timer = New DispatcherTimer
        timer.Interval = TimeSpan.FromSeconds(1)
        AddHandler timer.Tick, AddressOf timer_Tick
        timer.Start()
    End Sub

    Private Sub timer_Tick(sender As Object, e As Object)
        CountDown -= 1
        lblCountDown1.Text = CountDown
        If CountDown <= 0 Then
            MediaTool.Play()
            timer.Stop()
        End If
    End Sub

    Private Sub btnCountDown_Copy_Click(sender As Object, e As RoutedEventArgs) Handles btnCountDown_Copy.Click
        lblCountDown1.Text = 0
        timer.Stop()
    End Sub

    Private Sub Hour_DataContextChanged(sender As FrameworkElement, args As DataContextChangedEventArgs) Handles Hour.DataContextChanged
        If String.IsNullOrEmpty(Hour.Text) Then Hour.Text = 0
    End Sub

    Private Sub Min_DataContextChanged(sender As FrameworkElement, args As DataContextChangedEventArgs) Handles Min.DataContextChanged
        If String.IsNullOrEmpty(Min.Text) Then Min.Text = 0
    End Sub

    Private Sub Sec_DataContextChanged(sender As FrameworkElement, args As DataContextChangedEventArgs) Handles Sec.DataContextChanged
        If String.IsNullOrEmpty(Sec.Text) Then Sec.Text = 0
    End Sub
End Class
