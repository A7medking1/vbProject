Imports System.Data.SqlClient

Public Class admin
    Dim connection As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\a7med\OneDrive\المستندات\supermarket.mdf;Integrated Security=True;Connect Timeout=30")
    Public Sub populate()
        connection.Open()
        Dim sql = "select * from tableAdmin"
        Dim adapter As SqlDataAdapter
        adapter = New SqlDataAdapter(sql, connection)
        Dim builder As SqlCommandBuilder
        builder = New SqlCommandBuilder(adapter)
        Dim des As DataSet
        des = New DataSet
        adapter.Fill(des)
        adminGrid.DataSource = des.Tables(0)
        connection.Close()
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        connection.Open()
        Dim query As String = "insert into tableAdmin values (" & adminID.Text & "  ,'" & adminName.Text & "' ,'" & adminPass.Text & "')"
        Dim cmd As SqlCommand
        cmd = New SqlCommand(query, connection)
        cmd.ExecuteNonQuery()
        MsgBox("admin added successfully")
        connection.Close()
        populate()
    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        populate()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        adminID.Text = ""
        adminName.Text = ""
        adminPass.Text = ""
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If adminID.Text = "" Then
            MsgBox("select the admin to delete")
        Else
            connection.Open()
            Dim query As String = "delete from tableAdmin where adminID = " & adminID.Text & " "
            Dim cmd As SqlCommand
            cmd = New SqlCommand(query, connection)
            cmd.ExecuteNonQuery()
            MsgBox("admin deleted successfully")
            connection.Close()
            populate()
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If adminID.Text = "" Or adminName.Text = "" Or adminPass.Text = "" Then
            MsgBox("missing information")
        Else
            connection.Open()
            Dim query As String = "update  tableAdmin set adminName = '" & adminName.Text & "' , adminPass = '" & adminPass.Text & "' where adminID = " & adminID.Text & ""
            Dim cmd As SqlCommand
            cmd = New SqlCommand(query, connection)
            cmd.ExecuteNonQuery()
            MsgBox("admin updated successfully")
            connection.Close()
            populate()
        End If
    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click
        Dim prod = New product
        prod.Show()
        Me.Hide()
    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click
        Dim CAT = New category
        CAT.Show()
        Me.Hide()
    End Sub
End Class