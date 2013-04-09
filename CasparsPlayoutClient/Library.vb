﻿''' <summary>
''' Represents the media library of the casparCG Server.
''' Allows to get items of given type, all items or filterd matches.
''' </summary>
''' <remarks></remarks>
Public Class Library

    Private media As Dictionary(Of String, CasparCGMedia)
    Private controller As ServerController

    Public Sub New(ByVal controller As ServerController)
        Me.controller = controller
        media = New Dictionary(Of String, CasparCGMedia)
    End Sub

    Public Function getCasparCGMedia() As IEnumerable(Of CasparCGMedia)
        Return media.Values
    End Function

    Public Function getItemsOfType(ByVal type As CasparCGMedia.MediaType) As List(Of CasparCGMedia)
        Dim items As New List(Of CasparCGMedia)
        For Each item In media.Values
            If item.getMediaType = type Then
                items.Add(item)
            End If
        Next
        Return items
    End Function

    Public Function getItem(ByVal name As String) As CasparCGMedia
        If media.ContainsKey(name) Then
            Return media.Item(name)
        Else
            Return Nothing
        End If
    End Function

    ''' <summary>
    ''' Rereads the Server List of Mediafiles and refreshs the Library.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub refreshLibrary()
        '' todo
        media = controller.getMedia()
    End Sub
End Class
