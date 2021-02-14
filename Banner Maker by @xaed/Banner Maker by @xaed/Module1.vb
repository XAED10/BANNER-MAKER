Imports System.Net, System.Console, System.Threading
Module Module1
    Dim finalban As String
    Dim bantext As String
    Dim ban As String = "                              ____          _   _ _   _ ______ _____    __  __          _  ________ _____  
                             |  _ \   /\   | \ | | \ | |  ____|  __ \  |  \/  |   /\   | |/ /  ____|  __ \ 
                             | |_) | /  \  |  \| |  \| | |__  | |__) | | \  / |  /  \  | ' /| |__  | |__) |
         instagram.com/xaed  |  _ < / /\ \ | . ` | . ` |  __| |  _  /  | |\/| | / /\ \ |  < |  __| |  _  / 
                             | |_) / ____ \| |\  | |\  | |____| | \ \  | |  | |/ ____ \| . \| |____| | \ \ 
                             |____/_/    \_\_| \_|_| \_|______|_|  \_\ |_|  |_/_/    \_\_|\_\______|_|  \_\"
    'Programmed By XAED
    Sub Main()
        Title = "Banner Maker By @xaed"
        Write(ban)
        Thread.Sleep(500)
        Console.BackgroundColor = ForegroundColor = ConsoleColor.Green
        Write(vbNewLine & "Text : ")
        bantext = ReadLine()
        makeban(bantext)
        Console.Clear()
        Console.ForegroundColor = ConsoleColor.Blue
        Write(finalban)
        Console.ForegroundColor = ConsoleColor.Green
        My.Computer.FileSystem.WriteAllText(bantext & " banner.txt", finalban + vbNewLine + "Made By XAED BANNER MAKER , FOLLOW ME ON INSTAGRAM => instagram.com/xaed or @xaed", False)
        MsgBox("DONE !" + vbNewLine + "I MADE THE BANNER : " & bantext + vbNewLine + "File Name : " & bantext & " banner.txt", MsgBoxStyle.OkOnly, "DONE SUCCESSFULLY")
        Write(vbNewLine & "Press Enter To Exit ...")
        ReadLine()
        Environment.Exit(0)
    End Sub
    Sub makeban(bn As String)
        Try

            Dim Encoding As New Text.UTF8Encoding
            Dim Bytes As Byte() = Encoding.GetBytes("")
            Dim AJ As Net.HttpWebRequest = DirectCast(Net.WebRequest.Create("http://artii.herokuapp.com/make?text=" & bn), Net.HttpWebRequest)
            With AJ
                .Method = "GET"
                .Proxy = Nothing
                .Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9"
                .AutomaticDecompression = Net.DecompressionMethods.Deflate Or Net.DecompressionMethods.GZip
                .Headers.Add("Accept-Language: en-US,en;q=0.9")
                .KeepAlive = True
                .Host = "artii.herokuapp.com"
                .Headers.Add("Upgrade-Insecure-Requests: 1")
                .UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/87.0.4280.141 Safari/537.36"
            End With
            Dim Response As Net.HttpWebResponse = DirectCast(AJ.GetResponse, Net.HttpWebResponse)
            Dim reader As New IO.StreamReader(Response.GetResponseStream)
            Dim text1 As String = reader.ReadToEnd
            finalban = text1
            reader.Dispose()
            reader.Close()
            Response.Dispose()
            Response.Close()
        Catch ex As WebException
        End Try
    End Sub
End Module
