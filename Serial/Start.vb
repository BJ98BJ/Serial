Public Class Start

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Serial.ShowDialog()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        LED_Leiste.ShowDialog()
    End Sub

    Private Sub Start_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed

    End Sub
End Class