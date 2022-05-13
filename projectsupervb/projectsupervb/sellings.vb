Imports System.Data.SqlClient

Public Class sellings

    Dim connection As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\a7med\OneDrive\المستندات\supermarket.mdf;Integrated Security=True;Connect Timeout=30")
    Private Sub fillCombo()
        connection.Open()
        Dim sql = "select * from tableProduct"
        Dim cmd As New SqlCommand(sql, connection)
        Dim adapter As New SqlDataAdapter(cmd)
        Dim Tbl As New DataTable()
        adapter.Fill(Tbl)
        prodNameCb.DataSource = Tbl
        prodNameCb.DisplayMember = "productName"
        prodNameCb.ValueMember = "productName"
        connection.Close()
    End Sub
    Dim price = 0
    Private Sub fetchPrice()
        connection.Open()
        Dim sql = "select * from tableProduct where productName = '" & prodNameCb.SelectedValue.ToString() & "'"
        Dim cmd As New SqlCommand(sql, connection)
        Dim Rdr As SqlDataReader
        Dim Tbl As New DataTable()
        Rdr = cmd.ExecuteReader()

        While Rdr.Read
            price = Rdr(2)
            productPriceCb.Text = price
        End While
        connection.Close()
    End Sub
    Private Sub sellings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        fillCombo()
    End Sub
    Dim i = 0, gridTotal = 0
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If productPriceCb.Text = "" Or quantityCb.Text = "" Then
            MsgBox("enter the quantity")
        ElseIf price = 0 Then
            MsgBox("select the product")
        Else
            Dim rnum = billGrid.Rows.Add()
            i = i + 1
            billGrid.Rows.Item(rnum).Cells("column1").Value = i
            billGrid.Rows.Item(rnum).Cells("column2").Value = prodNameCb.SelectedValue.ToString()
            billGrid.Rows.Item(rnum).Cells("column3").Value = price
            billGrid.Rows.Item(rnum).Cells("column4").Value = quantityCb.Text
            billGrid.Rows.Item(rnum).Cells("column5").Value = price * Integer.Parse(quantityCb.Text)
            gridTotal = gridTotal + (price * Integer.Parse(quantityCb.Text))
            gridTotalLib.Text = "$  " + gridTotal.ToString()


        End If
    End Sub

    Private Sub prodNameCb_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles prodNameCb.SelectionChangeCommitted
        fetchPrice()
    End Sub
End Class