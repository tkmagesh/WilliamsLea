Module Module1

    Sub Main()
        Dim book = New Book With {.Id = 101, .Name = "C#", .Units = 100, .Cost = 10}

    End Sub

End Module

Public Class Book
    Public Property Id As Integer
    Public Property Name As String
    Public Property Cost As Decimal
    Public Property Units As Integer

End Class
