Imports System
Imports System.IO
Imports System.Net
Imports System.Xml

Public Class clsXML

    Public Shared Function WriteXML(ByVal nameStr As String, ByVal valueStr As String, ByVal path As String) As Boolean
        Try
            Dim doc As New XmlDocument
            Dim RootNode As XmlElement
            Dim mBound, i As Integer
            Dim isExit As Boolean = False
            doc.Load(path)
            '循环体遍历子节点
            RootNode = doc.DocumentElement
            mBound = RootNode.ChildNodes.Count - 1
            For i = 0 To mBound
                If RootNode.ChildNodes(i).Name = nameStr Then
                    RootNode.ChildNodes(i).InnerText = valueStr
                    isExit = True
                    Exit For
                End If
            Next
            '如果修改失败，则创建节点
            If isExit = False Then
                Dim xn As XmlNode = doc.CreateNode(XmlNodeType.Element, nameStr, "")
                RootNode.AppendChild(xn)
                xn.InnerText = valueStr
            End If
            doc.Save(path)
            Return True
        Catch ex As Exception
            Return False    '如果XML文件遭到破坏，则返回False
        End Try
    End Function

    Public Shared Function GetXML(ByVal nameStr As String, ByVal faultStr As String, ByVal path As String) As String
        '节点或XML不存在都会返回faultStr
        Try
            Dim valueStr As String = faultStr
            Dim xtr As XmlTextReader = New XmlTextReader(path)
            While xtr.Read
                If xtr.Name = nameStr Then
                    valueStr = xtr.ReadString
                    Exit While
                End If
            End While
            xtr.Close()
            Return valueStr
        Catch ex As Exception
            Return faultStr
        End Try
    End Function

    Public Shared Function ResetXML(ByVal path As String) As Boolean
        Try
            Dim xmlInit As String
            xmlInit = "<?xml version=" & Chr(34) & "1.0" & Chr(34) & " encoding=" & Chr(34) & "UTF-8" & Chr(34) & "?>" & vbCrLf _
             & "<config>" & vbCrLf _
             & "</config>"
            My.Computer.FileSystem.WriteAllText(path, xmlInit, False, System.Text.Encoding.Default)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Shared Function sourceParser() As Dictionary(Of String, String)
        Dim result As New Dictionary(Of String, String)
        Dim i, j As Integer

        Using reader As XmlReader = XmlReader.Create(Application.StartupPath + "\cache.xml")
            While reader.Read()
                If reader.IsStartElement() Then
                    ' See if perls element or article element.
                    If reader.Name = "emoji" Then
                        Console.WriteLine("Start <emoji> element.")
                    ElseIf reader.Name = "infoos" Then
                        Console.WriteLine("Start <infoos> element.")
                        i = 0
                    ElseIf reader.Name = "info" Then
                        Console.WriteLine("Start <info> element.")

                        If reader.Read() Then
                            If i = 0 Then
                                result.Add("Author", reader.Value.Trim())
                                i = 1
                            Else
                                result.Add("URL", reader.Value.Trim())
                                i = 0
                            End If
                        End If
                    ElseIf reader.Name = "category" Then
                        Console.WriteLine("Start <category> element.")

                        ' Get name attribute.
                        Dim attribute As String = reader("name")
                        If attribute IsNot Nothing Then
                            result.Add(i, j)
                            i = i + 1
                            Console.WriteLine("  Category" + CType(i, String), attribute)
                            result.Add(CType(i, String) + ":0", attribute)
                            j = 1
                        End If
                    ElseIf reader.Name = "string" Then
                        Console.WriteLine("Start <string> element.")

                        ' Text data.
                        If reader.Read() Then
                            Console.WriteLine("  String" + CType(j, String), reader.Value.Trim())
                            result.Add(CType(i, String) + ":" + CType(j, String), reader.Value.Trim())
                            j = j + 1
                        End If
                    End If

                End If
            End While
            result.Add(i, j)
            result(0) = i
        End Using

        Return result
    End Function

    Public Shared Function refreshCache(url As String) As Boolean
        Dim strFilePath As String = Application.StartupPath + "\cache.xml"
        Dim dl As New System.Net.WebClient()
        Try
            dl.DownloadFile(url, strFilePath)
            dl.Dispose()
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function
End Class
