Imports System
Imports System.Xml

Public Class clsParser

    Private Shared Function readXML(url As String) As Dictionary(Of String, String)
        Dim result As New Dictionary(Of String, String)
        Dim doc As New XmlDocument()

        Try
            doc.Load(url)
        Catch ex As Exception
            Return result
        End Try

        Dim child As XmlNode = doc.SelectSingleNode("/root/child")
        If Not (child Is Nothing) Then
            Dim nr As New XmlNodeReader(child)
            While nr.Read()
                Console.WriteLine(nr.Value)
                'result.Add("name", XmlReader.ReadString)
            End While
        End If

        Return result
    End Function

    Public Shared Sub refreshCache(url As String)
        Dim result As New Dictionary(Of String, String)
        result = readXML(url)

        Throw New Exception("Cannot parse result")
    End Sub

    Public Shared Function readCache() As Dictionary(Of String, String)

    End Function
End Class
