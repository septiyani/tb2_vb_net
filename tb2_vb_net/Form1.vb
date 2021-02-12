Imports System.Data.Odbc
Imports MySql.Data.MySqlClient
Imports System.Web.Script.Serialization
Imports System.Net

Public Class RumahSakit
    Dim myCommand As New MySqlCommand
    Public da As MySqlDataAdapter
    Public dt As DataTable
    Dim filter_search As String
    Dim jarak As String
    Dim Langi As String
    Dim Longi As String



    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call conecDB()      'Open the connection to database
        Call initCMD()      'Initialize the sqlclient command object
        Call LoadDataWilayah()
        Call LoadRumahSakit()
        Call LoadTypeRS()
        Call LoadLongLang()
    End Sub
    Private Sub LoadDataWilayah()
        Try
            'Tampilkan User Akses Group Pada Combo Box
            SQL = "SELECT DISTINCT WILAYAH FROM  rs_rujukan order by wilayah asc "

            With comDB
                .CommandText = SQL
                .ExecuteNonQuery()
            End With
            rdDB = comDB.ExecuteReader
            If rdDB.HasRows = True Then
                ComboBox1.Items.Clear()

                While rdDB.Read()
                    ComboBox1.Items.Add(rdDB("wilayah"))
                End While
            End If
            rdDB.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub LoadTypeRS()
        Try
            'Tampilkan User Akses Group Pada Combo Box
            SQL = "SELECT DISTINCT tipe FROM  rs_rujukan ORDER BY tipe asc  "

            With comDB
                .CommandText = SQL
                .ExecuteNonQuery()
            End With
            rdDB = comDB.ExecuteReader
            If rdDB.HasRows = True Then
                ComboBox2.Items.Clear()
                ComboBox2.Items.Add("")
                While rdDB.Read()
                    ComboBox2.Items.Add(rdDB("tipe"))
                End While
            End If
            rdDB.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Public Sub LoadRumahSakit()
        Try
            Call conecDB()
            dt = New DataTable 'Kosongkan table
            da = New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT id as No, kode_rs AS Kode, nama_rs as Nama, wilayah as Wilayah," &
                                                             "tipe as Type, telepon as Telepon, alamat as Alamat FROM rs_rujukan", connDB)
            comBuilderDB = New MySql.Data.MySqlClient.MySqlCommandBuilder(da) 'untuk bisa edit datagridview
            da.Fill(dt)
            DGView.DataSource = dt

            'Zebra Table
            Me.DGView.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue
            Me.DGView.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        rdDB.Close()
    End Sub


    Private Sub Cari_Click(sender As Object, e As EventArgs) Handles Cari.Click
        Try
            Call conecDB()

            If TextBox1.Text <> "" Then
                filter_search += "AND nama_rs like '%" & TextBox1.Text & "%'"
            ElseIf ComboBox1.Text <> "" Then
                filter_search += "AND wilayah like '%" & ComboBox1.Text & "%'"
            ElseIf ComboBox2.Text <> "" Then
                filter_search += "AND tipe like '%" & ComboBox2.Text & "%'"
            Else
                filter_search += ""
            End If


            SQL = "SELECT * FROM  rs_rujukan where 1=1 " & filter_search & ""


            With comDB
                .CommandText = SQL
                .ExecuteNonQuery()
            End With
            rdDB = comDB.ExecuteReader
            If rdDB.HasRows = True Then
                rdDB.Close()
                dt = New DataTable 'Kosongkan table
                da = New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT id as No, kode_rs AS Kode, nama_rs as Nama, wilayah as Wilayah," &
                                                                 "tipe as Type, telepon as Telepon, alamat as Alamat FROM rs_rujukan where 1=1 " & filter_search & "", connDB)
                comBuilderDB = New MySql.Data.MySqlClient.MySqlCommandBuilder(da) 'untuk bisa edit datagridview
                da.Fill(dt)
                DGView.DataSource = dt

                'Zebra Table
                Me.DGView.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue
                Me.DGView.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        rdDB.Close()
    End Sub

    Private Sub Reset_Click(sender As Object, e As EventArgs) Handles Reset.Click
        TextBox1.Text = ""
        TextBox2.Text = ""
        ComboBox1.SelectedIndex = 0
        ComboBox2.SelectedIndex = 0
        Call LoadDataWilayah()
        Call LoadRumahSakit()
        Call LoadTypeRS()
    End Sub

    Private Sub LoadLongLang()
        Dim Request As HttpWebRequest = HttpWebRequest.Create("http://api.ipinfodb.com/v3/ip-city/?key=dfcb907768fe5a702b74dab0931606afff4b215c8fda9e19ff1358a6baa1ae3f&ip=" & GetIP() & "&format=json")
        Request.Proxy = Nothing
        Request.UserAgent = "Test"

        Dim Response As HttpWebResponse = Request.GetResponse
        Dim ResponseStream As System.IO.Stream = Response.GetResponseStream

        Dim StreamHeader As New System.IO.StreamReader(ResponseStream)
        Dim Data As String = StreamHeader.ReadToEnd
        StreamHeader.Close()
        Dim mapA As map = New map()

        Dim ser As JavaScriptSerializer = New JavaScriptSerializer()
       
        System.Console.WriteLine(Data)


        Try
            mapA = ser.Deserialize(Of map)(Data)
            Langi = mapA.latitude
            Longi = mapA.longitude


        Catch ex As Exception
            System.Console.WriteLine(Data)
        End Try
    End Sub
    Function GetIP() As String
        Dim Request As HttpWebRequest = HttpWebRequest.Create("https://api.ipify.org")
        Request.Proxy = Nothing
        Request.UserAgent = "Test"

        Dim Response As HttpWebResponse = Request.GetResponse
        Dim ResponseStream As System.IO.Stream = Response.GetResponseStream

        Dim StreamHeader As New System.IO.StreamReader(ResponseStream)
        Dim Data As String = StreamHeader.ReadToEnd
        StreamHeader.Close()
        Dim mapA As map = New map()

        Dim ser As JavaScriptSerializer = New JavaScriptSerializer()
        Return Data
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Call conecDB()
            jarak = "10"
            If TextBox2.Text <> "" Then
                jarak = TextBox2.Text
            End If
            SQL = "SELECT id as No,m.kode_rs AS Kode, m.nama_rs as Nama, m.wilayah as Wilayah, m.tipe as Type, m.telepon as Telepon, alamat as Alamat " &
                    "FROM rs_rujukan AS m " &
                    "JOIN ( " &
                    "      SELECT " & Langi & " AS latpoint, " & Longi & " AS longpoint, " &
                    "             " & jarak & " AS radius, 111.045 AS distance_unit " &
                    "     ) AS p ON 1=1 " &
                    "WHERE m.lan " &
                    "BETWEEN p.latpoint  - (p.radius / p.distance_unit) " &
                    "    AND p.latpoint  + (p.radius / p.distance_unit) " &
                    "    AND m.lon BETWEEN p.longpoint - (p.radius / (p.distance_unit * COS(RADIANS(p.latpoint)))) " &
                    "    AND p.longpoint + (p.radius / (p.distance_unit * COS(RADIANS(p.latpoint)))) "


            With comDB
                .CommandText = SQL
                .ExecuteNonQuery()
            End With
            rdDB = comDB.ExecuteReader
            If rdDB.HasRows = True Then
                rdDB.Close()
                dt = New DataTable 'Kosongkan table
               
                da = New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT id as No, m.kode_rs AS Kode, m.nama_rs as Nama, m.wilayah as Wilayah, m.tipe as Type, m.telepon as Telepon, alamat as Alamat " &
                    "FROM rs_rujukan AS m " &
                    "JOIN ( " &
                   "      SELECT " & Langi & " AS latpoint, " & Longi & " AS longpoint, " &
                    "              " & jarak & " AS radius, 111.045 AS distance_unit " &
                    "     ) AS p ON 1=1 " &
                    "WHERE m.lan " &
                    "BETWEEN p.latpoint  - (p.radius / p.distance_unit) " &
                    "    AND p.latpoint  + (p.radius / p.distance_unit) " &
                    "    AND m.lon BETWEEN p.longpoint - (p.radius / (p.distance_unit * COS(RADIANS(p.latpoint)))) " &
                    "    AND p.longpoint + (p.radius / (p.distance_unit * COS(RADIANS(p.latpoint))))", connDB)
                
                comBuilderDB = New MySql.Data.MySqlClient.MySqlCommandBuilder(da) 'untuk bisa edit datagridview
                da.Fill(dt)
                DGView.DataSource = dt

                'Zebra Table
                Me.DGView.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue
                Me.DGView.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        rdDB.Close()
    End Sub
End Class
Class map
    Public Property latitude As String
    Public Property longitude As String


End Class

