Imports System.Net
Imports System.Web.Script.Serialization
Public Class Form2

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim Request As HttpWebRequest = HttpWebRequest.Create("https://api.kawalcorona.com/indonesia")
        Request.Proxy = Nothing
        Request.UserAgent = "Test"

        Dim Response As HttpWebResponse = Request.GetResponse
        Dim ResponseStream As System.IO.Stream = Response.GetResponseStream

        Dim StreamHeader As New System.IO.StreamReader(ResponseStream)
        Dim Data As String = StreamHeader.ReadToEnd
        StreamHeader.Close()
        Dim playerA As player = New player()

        Dim ser As JavaScriptSerializer = New JavaScriptSerializer()
        System.Console.WriteLine(Data)
        Data = Data.Replace("[", "").Replace("]", "")

        Try
            playerA = ser.Deserialize(Of player)(Data)
            Label2.Text = playerA.positif
            Label4.Text = playerA.dirawat
            Label6.Text = playerA.sembuh
            Label7.Text = playerA.meninggal



        Catch ex As Exception
            System.Console.WriteLine(Data)
        End Try
    End Sub
End Class

Class player
    Public Property name As String
    Public Property positif As String
    Public Property sembuh As String
    Public Property meninggal As String
    Public Property dirawat As String


End Class