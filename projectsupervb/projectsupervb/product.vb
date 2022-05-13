Imports System.Data.SqlClient
Public Class product

    Dim connection As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\a7med\OneDrive\المستندات\supermarket.mdf;Integrated Security=True;Connect Timeout=30")
    Public Sub populate()
        connection.Open()
        Dim sql = "select * from tableproduct"
        Dim adapter As SqlDataAdapter
        adapter = New SqlDataAdapter(sql, connection)
        Dim builder As SqlCommandBuilder
        builder = New SqlCommandBuilder(adapter)
        Dim des As DataSet
        des = New DataSet
        adapter.Fill(des)
        productGrid.DataSource = des.Tables(0)
        connection.Close()
    End Sub
    Private Sub fillCombo()
        connection.Open()
        Dim sql = "select * from tableCategory"
        Dim cmd As New SqlCommand(sql, connection)
        Dim adapter As New SqlDataAdapter(cmd)
        Dim Tbl As New DataTable()
        adapter.Fill(Tbl)
        category.DataSource = Tbl
        category.DisplayMember = "catName"
        category.ValueMember = "catName"
        connection.Close()
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        connection.Open()
        Dim query As String = "insert into tableproduct values (" & productID.Text & "  ,'" & productName.Text & "' ," & productPrice.Text & ",' " & category.SelectedValue.ToString() & "')"
        Dim cmd As SqlCommand
        cmd = New SqlCommand(query, connection)
        cmd.ExecuteNonQuery()
        MsgBox("product added successfully")
        connection.Close()
        populate()
    End Sub

    Private Sub product_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        populate()
        fillCombo()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If productID.Text = "" Then
            MsgBox("select the product to delete")
        Else
            connection.Open()
            Dim query As String = "delete from tableproduct where productID = " & productID.Text & " "
            Dim cmd As SqlCommand
            cmd = New SqlCommand(query, connection)
            cmd.ExecuteNonQuery()
            MsgBox("product deleted successfully")
            connection.Close()
            populate()
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        productID.Text = ""
        productName.Text = ""
        productPrice.Text = ""

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If productID.Text = "" Or productName.Text = "" Or productPrice.Text = "" Then
            MsgBox("missing information")
        Else
            connection.Open()
            Dim query As String = "update  tableproduct set productName = '" & productName.Text & "' , productPrice = " & productPrice.Text & ", productCategory = '" & category.SelectedValue.ToString() & "' where productID = " & productID.Text & "  "
            Dim cmd As SqlCommand
            cmd = New SqlCommand(query, connection)
            cmd.ExecuteNonQuery()
            MsgBox("product updated successfully")
            connection.Close()
            populate()
        End If
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click
        Dim CAT = New category
        CAT.Show()
        Me.Hide()
    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click
        Dim ad = New admin
        admin.Show()
        Me.Hide()
    End Sub
End Class