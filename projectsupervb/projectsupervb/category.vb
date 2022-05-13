Imports System.Data.SqlClient

Public Class category
    Dim connection As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\a7med\OneDrive\المستندات\supermarket.mdf;Integrated Security=True;Connect Timeout=30")
    Public Sub populate()
        connection.Open()
        Dim sql = "select * from tableCategory"
        Dim adapter As SqlDataAdapter
        adapter = New SqlDataAdapter(sql, connection)
        Dim builder As SqlCommandBuilder
        builder = New SqlCommandBuilder(adapter)
        Dim des As DataSet
        des = New DataSet
        adapter.Fill(des)
        categoryGrid.DataSource = des.Tables(0)
        connection.Close()
    End Sub
    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        catDesc.Text = ""
        catID.Text = ""
        CatName.Text = ""
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        connection.Open()
        Dim query As String = "insert into tableCategory values (" & catID.Text & "  ,'" & CatName.Text & "' ,'" & catDesc.Text & "')"
        Dim cmd As SqlCommand
        cmd = New SqlCommand(query, connection)
        cmd.ExecuteNonQuery()
        MsgBox("category added successfully")
        connection.Close()
        populate()
    End Sub

    Private Sub category_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        populate()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If catID.Text = "" Then
            MsgBox("select the category to delete")
        Else
            connection.Open()
            Dim query As String = "delete from tableCategory where catID = " & catID.Text & " "
            Dim cmd As SqlCommand
            cmd = New SqlCommand(query, connection)
            cmd.ExecuteNonQuery()
            MsgBox("category deleted successfully")
            connection.Close()
            populate()
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If catID.Text = "" Or CatName.Text = "" Or catDesc.Text = "" Then
            MsgBox("missing information")
        Else
            connection.Open()
            Dim query As String = "update  tableCategory set catName = '" & CatName.Text & "' , catDesc = '" & catDesc.Text & "' where catID = " & catID.Text & ""
            Dim cmd As SqlCommand
            cmd = New SqlCommand(query, connection)
            cmd.ExecuteNonQuery()
            MsgBox("category updated successfully")
            connection.Close()
            populate()
        End If
    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click
        Dim prod = New product
        prod.Show()
        Me.Hide()
    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click
        Dim ad = New admin
        admin.Show()
        Me.Hide()
    End Sub
End Class