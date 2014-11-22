Imports System
Imports System.IO.Ports
Imports System.Threading
Imports System.Threading.Thread


Public Class LED_Leiste

    Dim curr As Boolean
    Dim WithEvents COMport As New SerialPort

    Private Sub LED_Leiste_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        COMport.Close()
    End Sub

    Private Sub LED_Leiste_Load(sender As Object, e As EventArgs) Handles Me.Load
        COMport.Open()
        Button1.Left = Me.Size.Width / 2 - Button1.Width / 2
        Button1.Top = Me.Size.Height / 2 - Button1.Height / 2
        curr = False
        COMport.Write(0)
        Me.BackColor = Color.Black
        Button1.BackColor = Color.White
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If curr = False Then
            COMport.Write(1)
            Me.BackColor = Color.White
            Button1.BackColor = Color.Black
            curr = True

        Else
            COMport.Write(0)
            Me.BackColor = Color.Black
            Button1.BackColor = Color.White
            curr = False
        End If

        Button1.Left = Me.Size.Width / 2 - Button1.Width / 2
        Button1.Top = Me.Size.Height / 2 - Button1.Height / 2
    End Sub

    Public Sub New()
        InitializeComponent()

        COMport.PortName = "COM4"
        COMport.BaudRate = 9600

    End Sub

    Private Sub NumericUpDown1_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown1.ValueChanged
        COMport.PortName = "COM" & NumericUpDown1.Value
    End Sub

    Private Sub LED_Leiste_SizeChanged(sender As Object, e As EventArgs) Handles Me.SizeChanged
        Button1.Left = Me.Size.Width / 2 - Button1.Width / 2
        Button1.Top = Me.Size.Height / 2 - Button1.Height / 2
    End Sub
End Class