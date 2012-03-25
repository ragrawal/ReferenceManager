Imports System.Web
Imports System.Net
Imports System.IO
Imports System.Windows.Forms
Imports Microsoft.Office.Interop.Word




Public Class Client

    Dim defaultUri As Uri = Nothing
    Dim message As String = Nothing

    Public Sub New()
        defaultUri = New Uri(Globals.ThisAddIn.getHost + "services/convert.xml")
    End Sub

    Public Function GetErrorMessage() As String
        Return message
    End Function

    Public Function ImportFromURL(ByVal url As String) As Boolean
        Dim data As Dictionary(Of String, String) = New Dictionary(Of String, String)
        data.Add("input", "site")
        data.Add("value", url)
        data.Add("output", "OFFICE2007XML")
        Return Import(data)
    End Function

    Public Function ImportFromText(ByVal inputFormat As String, ByVal ref As String) As Boolean
        Dim data As Dictionary(Of String, String) = New Dictionary(Of String, String)
        data.Add("input", inputFormat)
        data.Add("value", ref)
        data.Add("output", "OFFICE2007XML")

        'If Input Format is already in Office2007XML,
        'then there is no need to call the server
        'just add the references to the bibliography
        If inputFormat = "OFFICE2007XML" Then
            Dim response As New MSXML2.DOMDocument
            If response.loadXML(Trim(ref)) = False Then
                message = "Error: Unable to Create XML Object"
                Return False
            End If
            Return AddReferences(response)
        End If

        Return Import(data)
    End Function


    Public Function SendRequest(ByVal uri As Uri, ByVal Parameters As Dictionary(Of String, String)) As StreamReader
        'Define variables
        Dim postStream As Stream = Nothing
        Dim response As HttpWebResponse = Nothing

        ' Create the web request  
        Dim request As HttpWebRequest = DirectCast(WebRequest.Create(uri), HttpWebRequest)

        ' Set type to POST  
        request.Method = "POST"
        request.ContentType = "application/x-www-form-urlencoded"

        ' Create the data we want to send
        Dim data(Parameters.Count) As String
        Dim index As Integer = 0
        For Each kvp As KeyValuePair(Of String, String) In Parameters
            data(index) = kvp.Key + "=" + HttpUtility.UrlEncode(kvp.Value)
            index += 1
        Next

        ' Create a byte array of the data we want to send  
        Dim byteData() As Byte = UTF8Encoding.UTF8.GetBytes(Join(data, "&"))

        ' Set the content length in the request headers
        request.ContentLength = byteData.Length

        'Write Data
        postStream = request.GetRequestStream()
        postStream.Write(byteData, 0, byteData.Length)

        'Get Response
        response = DirectCast(request.GetResponse(), HttpWebResponse)

        'Return Response
        Return New StreamReader(response.GetResponseStream)


        'Finally
        'If Not response Is Nothing Then response.Close()
        'End Try

    End Function

    


    Private Function Import(ByVal data As Dictionary(Of String, String)) As Boolean
        Try
            'Send Request
            Dim reader As StreamReader = SendRequest(defaultUri, data)
            If reader Is Nothing Then
                message = "Unable to get response from server"
                Return False
            End If

            'Get Response
            Dim response As New MSXML2.DOMDocument
            If response.loadXML(Trim(reader.ReadToEnd)) = False Then
                message = "Unable to Parse XML"
                Return False
            End If

            'Check if server returned any error
            Dim errorNode As MSXML2.IXMLDOMNode = response.selectSingleNode("//error")
            If errorNode IsNot Nothing Then
                message = errorNode.text
                Return False
            End If

            Return AddReferences(response)

        Catch ex As Exception
            message = "An unexpected error occured: Please contact developer with the following error message: " + ex.Message
            Return False

        End Try

        Return True

    End Function

    Private Function AddReferences(ByVal Response As MSXML2.DOMDocument) As Boolean

        Try
            'Process XML
            Dim records As MSXML2.IXMLDOMNodeList = Response.selectNodes("//b:Source")
            If records Is Nothing Then
                message = "Sorry unable to create word reference"
                Return False
            End If

            'Make sure there are any records
            If records.length = 0 Then
                message = "Error: Unable to find any record"
                Return False
            End If
            'Add Source to Bibliography
            Dim bibSources As Sources = Globals.ThisAddIn.Application.ActiveDocument.Bibliography.Sources
            For i = 0 To records.length - 1
                bibSources.Add(records.item(i).xml)
            Next i
            Return True
        Catch ex As Exception
            message = "Exception occurred while adding references. Exception Message: " + ex.Message
            Return False
        End Try

        Return True
    End Function



End Class
