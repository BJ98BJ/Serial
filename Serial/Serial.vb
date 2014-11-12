Imports System
Imports System.IO.Ports
Imports System.Threading
Imports System.Threading.Thread

Public Class Serial

    Dim WithEvents COMport As New SerialPort
    Dim RXbyte As Byte
    Dim CurrentCom As Integer = 1
    Dim dist As Integer
    Dim entf As Integer
    Dim count As Integer
    Dim currdist As Integer

    Private Sub Serial_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    'Function ReceiveSerialData(Port As Integer) As String
    '    ' Receive strings from a serial port.
    '    Dim returnStr As String = ""

    '    Dim com1 As IO.Ports.SerialPort = Nothing
    '    Try
    '        com1 = My.Computer.Ports.OpenSerialPort("COM" & Port)
    '        com1.ReadTimeout = 10000
    '        Do
    '            Dim Incoming As String = com1.ReadLine()
    '            If Incoming Is Nothing Then
    '                Exit Do
    '            Else
    '                returnStr &= Incoming & vbCrLf
    '            End If
    '        Loop
    '    Catch ex As TimeoutException
    '        returnStr = "Error: Serial Port read timed out."
    '    Catch exx As Exception
    '        returnStr = "Keine Daten vorhanden."
    '    Finally
    '        If com1 IsNot Nothing Then com1.Close()
    '    End Try

    '    Return returnStr
    'End Function

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        TextBox1.Text = entf
        TextBox2.Text = currdist
        If entf < 50 And Not entf = 0 Then
            Timer2.Enabled = True
            Me.BackColor = Color.Red
            If CheckBox1.Checked = True Then
                Process.Start(TextBox3.Text)
            End If
        Else
            Timer2.Enabled = False
            My.Computer.Audio.Stop()
            Me.BackColor = Color.DarkGreen
        End If
        'TextBox1.Text = ReceiveSerialData(NumericUpDown1.Value)
    End Sub

    Public Sub New()

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        COMport.PortName = "COM4"
        COMport.BaudRate = 9600
        COMport.Open()
    End Sub

    Private Sub NumericUpDown1_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown1.ValueChanged
        COMport.PortName = "COM" & NumericUpDown1.Value
    End Sub

    'Private Sub Receiver(ByVal sender As Object, ByVal e As SerialDataReceivedEventArgs) Handles COMport.DataReceived
    '    RXbyte = COMport.ReadByte
    '    Me.Invoke(New MethodInvoker(AddressOf Display))

    'End Sub

    Private Sub COMport_DataReceived(sender As Object, e As SerialDataReceivedEventArgs) Handles COMport.DataReceived
        Dim lese As Integer = COMport.ReadLine()
        If count = 5 Then
            count = 0
            entf = dist / 5
            dist = 0
        Else
            dist = dist + lese
            count = count + 1
        End If
        currdist = lese
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Form1.Show()
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        My.Computer.Audio.Play(My.Resources.SIREN2, AudioPlayMode.Background)
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged

    End Sub
End Class
