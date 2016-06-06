Imports System.IO

Module modImageCropper
    Public g_GetWorkingDirectory As String
    Public g_WorkingSession As String = Guid.NewGuid.ToString
    Public g_Sequence As Integer
    Public Function OpenFileReadOnlyIntoMemoryStream(ByVal InPath As String) As MemoryStream
        Dim ms As New MemoryStream

        If Not File.Exists(InPath) Then
            Dim info As Byte() = New System.Text.UTF8Encoding(True).GetBytes("File Doesn't Exist")
            ms.Write(info, 0, info.Length)
        Else
            Using fs As FileStream = File.Open(InPath, FileMode.Open, FileAccess.Read)
                ms.SetLength(fs.Length)
                fs.Read(ms.GetBuffer(), 0, CInt(Fix(fs.Length)))
            End Using
        End If
        Return ms
    End Function

    Public Function GetWorkingDirectory() As String
        If g_GetWorkingDirectory <> "" Then
            Return g_GetWorkingDirectory
        Else
            Dim strPath As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
            If strPath.ToLower.EndsWith("application data") Then
                strPath = strPath.Substring(0, strPath.Length - 16) & "Temp\"
            End If
            If Not strPath.EndsWith("\") Then strPath &= "\"
            If Directory.Exists(strPath & "LakeCo") Then
                If Directory.Exists(strPath & "LakeCo\DTMassScan") Then
                    'Already Exists
                    If Directory.Exists(strPath & "LakeCo\DTMassScan\" & g_WorkingSession) Then
                        'Already Exists
                    Else
                        Directory.CreateDirectory(strPath & "LakeCo\DTMassScan\" & g_WorkingSession)
                    End If
                Else
                    Directory.CreateDirectory(strPath & "LakeCo\DTMassScan\" & g_WorkingSession)
                End If
            Else
                Directory.CreateDirectory(strPath & "LakeCo")
                Directory.CreateDirectory(strPath & "LakeCo\DTMassScan")
                Directory.CreateDirectory(strPath & "LakeCo\DTMassScan\" & g_WorkingSession)
            End If
            g_GetWorkingDirectory = strPath & "LakeCo\DTMassScan\" & g_WorkingSession & "\"
            Return g_GetWorkingDirectory
        End If
    End Function

    Private _TrackBarSize As Integer = 3
    Public Property g_TrackBarSize() As Integer
        Get
            Return _TrackBarSize
        End Get
        Set(ByVal value As Integer)
            _TrackBarSize = value
        End Set
    End Property

    Public ReadOnly Property ImageSize() As Integer
        Get
            'Return (64 * (ParentForm.trackBarSize.Value + 1))
            Return (64 * (_TrackBarSize + 1))
        End Get
    End Property
End Module
