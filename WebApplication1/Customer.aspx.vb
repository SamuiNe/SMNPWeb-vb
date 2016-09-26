Public Class Customer
    Inherits System.Web.UI.Page
    Dim ExistingCustomerPreloaded As Boolean

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub rblCustomerChoice_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rblCustomerChoice.SelectedIndexChanged
        If rblCustomerChoice.SelectedValue = 1 Then
            lblExistingCustomer.Visible = False
            lblExistingCustomerInside.Visible = False
            ddlExistingCustomer.Visible = False

            lblCustomerID.Text = "-"
            txtCustomerName.Text = ""
            txtCustomerPhone.Text = ""
            txtCustomerAddress.Text = ""
            txtCustomerEmail.Text = ""

        Else
            If ddlExistingCustomer.SelectedIndex = -1 Then
                ExistingCustomerPreloaded = False
            Else
                ExistingCustomerPreloaded = True
            End If

            If ExistingCustomerPreloaded = False Then

                lblExistingCustomer.Visible = True
                lblExistingCustomerInside.Visible = True
                ddlExistingCustomer.Visible = True

                Dim dbCustomer As New db_class
                Dim CustomerData As New DataSet

                Dim sql As String = "SELECT * FROM customer_info"

                CustomerData = dbCustomer.execute_fill_dataset(sql)

                lblCustomerID.Text = CustomerData.Tables(0).Rows(0).ItemArray(0).ToString
                txtCustomerName.Text = CustomerData.Tables(0).Rows(0).ItemArray(1).ToString
                txtCustomerPhone.Text = CustomerData.Tables(0).Rows(0).ItemArray(2).ToString
                txtCustomerAddress.Text = CustomerData.Tables(0).Rows(0).ItemArray(3).ToString
                txtCustomerEmail.Text = CustomerData.Tables(0).Rows(0).ItemArray(4).ToString

                dbCustomer.clear_connection_nonquery()
            Else
                lblExistingCustomer.Visible = True
                lblExistingCustomerInside.Visible = True
                ddlExistingCustomer.Visible = True

                Dim dbCustomer As New db_class
                Dim CustomerData As New DataSet

                Dim sql As String = "SELECT * FROM customer_info"

                CustomerData = dbCustomer.execute_fill_dataset(sql)


                lblCustomerID.Text = CustomerData.Tables(0).Rows(ddlExistingCustomer.SelectedIndex).ItemArray(0).ToString
                txtCustomerName.Text = CustomerData.Tables(0).Rows(ddlExistingCustomer.SelectedIndex).ItemArray(1).ToString
                txtCustomerPhone.Text = CustomerData.Tables(0).Rows(ddlExistingCustomer.SelectedIndex).ItemArray(2).ToString
                txtCustomerAddress.Text = CustomerData.Tables(0).Rows(ddlExistingCustomer.SelectedIndex).ItemArray(3).ToString
                txtCustomerEmail.Text = CustomerData.Tables(0).Rows(ddlExistingCustomer.SelectedIndex).ItemArray(4).ToString

                dbCustomer.clear_connection_nonquery()
            End If
        End If
    End Sub

    Protected Sub btnConsumerApply_Click(sender As Object, e As EventArgs) Handles btnConsumerApply.Click
        Dim CustomerRadioButtonChoice As Integer = rblCustomerChoice.SelectedValue
        Dim ErrorCheck As Boolean = True

        If Convert.ToInt64(txtCustomerPhone.Text) > 9999999999 Or Convert.ToInt64(txtCustomerPhone.Text) < 1000000000 Then
            ErrorCheck = False
            lblConsumerStatus.Text = "Error 100 - Input error detected at Customer Phone, or something wrong has happened."
        End If
        If ErrorCheck = True Then
            Select Case CustomerRadioButtonChoice
                Case 1
                    Dim dbCustomerInsert As New db_class
                    Dim CustomerDataInsert As New DataSet

                    Dim sqlCustomerDataInsert As String
                    sqlCustomerDataInsert = "INSERT INTO customer_info (CustomerName, CustomerPhone, CustomerAddress, CustomerEmail) VALUES ('" + txtCustomerName.Text + "', '" + txtCustomerPhone.Text + "', '" + txtCustomerAddress.Text + "', '" + txtCustomerEmail.Text + "')"

                    Try
                        dbCustomerInsert.execute_non_query(sqlCustomerDataInsert)
                    Catch ex As Exception
                        lblConsumerStatus.Text = "Error 110 - Error while inserting database record."
                    Finally
                        lblConsumerStatus.Text = "Customer information for " + txtCustomerName.Text + " has successfully added."
                        dbCustomerInsert.clear_connection_nonquery()

                        ddlExistingCustomer.DataBind()
                        lblCustomerID.Text = "-"
                        txtCustomerName.Text = ""
                        txtCustomerPhone.Text = ""
                        txtCustomerAddress.Text = ""
                        txtCustomerEmail.Text = ""
                    End Try
                Case 2
                    Dim dbCustomerUpdate As New db_class
                    Dim CustomerDataUpdate As New DataSet
                    Dim DataPointer As Integer

                    Dim sqlDataRetrieve As String = "SELECT * FROM customer_info"
                    CustomerDataUpdate = dbCustomerUpdate.execute_fill_dataset(sqlDataRetrieve)
                    DataPointer = CustomerDataUpdate.Tables(0).Rows(ddlExistingCustomer.SelectedIndex).ItemArray(0)

                    Dim sqlCustomerDataUpdate As String
                    sqlCustomerDataUpdate = "UPDATE customer_info SET CustomerName='" + txtCustomerName.Text + "', CustomerPhone='" + txtCustomerPhone.Text + "', CustomerAddress='" + txtCustomerAddress.Text + "', CustomerEmail='" + txtCustomerEmail.Text + "' WHERE CustomerID=" + DataPointer.ToString + ";"

                    Try
                        dbCustomerUpdate.execute_non_query(sqlCustomerDataUpdate)
                    Catch ex As Exception
                        lblConsumerStatus.Text = "Error 120 - Error while updating database record."
                    Finally
                        lblConsumerStatus.Text = "Customer information for " + txtCustomerName.Text + " has successfully updated."
                        dbCustomerUpdate.clear_connection_nonquery()

                        ddlExistingCustomer.DataBind()
                        lblCustomerID.Text = "-"
                        txtCustomerName.Text = ""
                        txtCustomerPhone.Text = ""
                        txtCustomerAddress.Text = ""
                        txtCustomerEmail.Text = ""
                        rblCustomerChoice.SelectedIndex = 0
                    End Try
                Case 3
                    Dim dbCustomerRemove As New db_class
                    Dim CustomerDataRemove As New DataSet
                    Dim DataPointer As Integer

                    Dim sqlDataRetrieve As String = "SELECT * FROM customer_info"
                    CustomerDataRemove = dbCustomerRemove.execute_fill_dataset(sqlDataRetrieve)
                    DataPointer = CustomerDataRemove.Tables(0).Rows(ddlExistingCustomer.SelectedIndex).ItemArray(0)

                    Dim sqlCustomerDataRemove As String
                    sqlCustomerDataRemove = "DELETE FROM customer_info WHERE CustomerID=" + DataPointer.ToString + ";"

                    Try
                        dbCustomerRemove.execute_non_query(sqlCustomerDataRemove)
                    Catch ex As Exception
                        lblConsumerStatus.Text = "Error 130 - Error while removing database record."
                    Finally
                        lblConsumerStatus.Text = "Customer information for " + txtCustomerName.Text + " has successfully removed."
                        dbCustomerRemove.clear_connection_nonquery()

                        ddlExistingCustomer.DataBind()
                        lblCustomerID.Text = "-"
                        txtCustomerName.Text = ""
                        txtCustomerPhone.Text = ""
                        txtCustomerAddress.Text = ""
                        txtCustomerEmail.Text = ""
                        rblCustomerChoice.SelectedIndex = 0
                    End Try
            End Select
        End If
    End Sub

    Protected Sub ddlExistingCustomer_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlExistingCustomer.SelectedIndexChanged
        Dim dbCustomer As New db_class
        Dim CustomerData As New DataSet

        Dim sqlDataRetrieve As String = "SELECT * FROM customer_info"

        CustomerData = dbCustomer.execute_fill_dataset(sqlDataRetrieve)

        lblCustomerID.Text = CustomerData.Tables(0).Rows(ddlExistingCustomer.SelectedIndex).ItemArray(0).ToString
        txtCustomerName.Text = CustomerData.Tables(0).Rows(ddlExistingCustomer.SelectedIndex).ItemArray(1).ToString
        txtCustomerPhone.Text = CustomerData.Tables(0).Rows(ddlExistingCustomer.SelectedIndex).ItemArray(2).ToString
        txtCustomerAddress.Text = CustomerData.Tables(0).Rows(ddlExistingCustomer.SelectedIndex).ItemArray(3).ToString
        txtCustomerEmail.Text = CustomerData.Tables(0).Rows(ddlExistingCustomer.SelectedIndex).ItemArray(4).ToString

        dbCustomer.clear_connection_nonquery()
    End Sub
End Class