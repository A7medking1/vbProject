Imports System.Data.SqlClient

Public Class login
    Dim connection As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\a7med\OneDrive\المستندات\supermarket.mdf;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If uidTbl.Text = "" Then
            MsgBox("enter admin id")
        ElseIf passTbl.Text = "" Then
            MsgBox("enter admin password")
        Else
            connection.Open()
            Dim query = "select * from tableAdmin where adminName = '" & uidTbl.Text & "' and adminPass = '" & passTbl.Text & "' "
            cmd = New SqlCommand(query, connection)
            Dim da As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim ds As DataSet = New DataSet()
            da.Fill(ds)
            Dim a As Integer
            a = ds.Tables(0).Rows.Count
            If a = 0 Then
                MsgBox("wrong admin name or password")
            Else
                Dim prod = New product
                prod.Show()
                Me.Hide()
            End If
            connection.Close()
        End If
    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click
        Dim selling = New sellings
        selling.Show()
        Me.Hide()
    End Sub
End Class