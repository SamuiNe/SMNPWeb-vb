Public Class Transactions
    Inherits System.Web.UI.Page
    Dim ExistingInvoiceInfoPreloaded As Boolean
    Dim ExistingInvoiceDetailPreloaded As Boolean

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub rblInvoiceInfo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rblInvoiceInfo.SelectedIndexChanged
        If rblInvoiceInfo.SelectedValue = 1 Then
            lblExistingInvoice.Visible = False
            lblExistingInvoiceInfoInside.Visible = False
            ddlInvoiceInfo.Visible = False

            ddlCustomerName.SelectedIndex = 0
            ddlEmployeeID.SelectedIndex = 0
            lblInvoiceSubtotal.Text = "-"
            lblInvoiceTotal.Text = "-"
            lblInvoiceDate.Text = "-"
            lblInvoiceUpdateDate.Text = "-"

        Else
            If ddlInvoiceInfo.SelectedIndex = -1 Then
                ExistingInvoiceInfoPreloaded = False
            Else
                ExistingInvoiceInfoPreloaded = True
            End If

            If ExistingInvoiceInfoPreloaded = False Then

                lblExistingInvoice.Visible = True
                lblExistingInvoiceInfoInside.Visible = True
                ddlInvoiceInfo.Visible = True

                Dim dbInvoiceInfo As New db_class
                Dim InvoiceInfoDataA As New DataSet
                Dim InvoiceInfoDataB As New DataSet
                Dim InvoiceInfoDataC As New DataSet

                Dim sql As String = "SELECT * FROM customer_info"

                InvoiceInfoDataA = dbInvoiceInfo.execute_fill_dataset(sql)

                lblCustomerID.Text = InvoiceInfoDataA.Tables(0).Rows(0).ItemArray(0).ToString
                ddlCustomerName.SelectedValue = InvoiceInfoDataA.Tables(0).Rows(0).ItemArray(0)
                lblCustomerPhone.Text = InvoiceInfoDataA.Tables(0).Rows(0).ItemArray(2).ToString
                lblCustomerAddress.Text = InvoiceInfoDataA.Tables(0).Rows(0).ItemArray(3).ToString
                lblCustomerEmail.Text = InvoiceInfoDataA.Tables(0).Rows(0).ItemArray(4).ToString

                sql = "SELECT EmployeeID FROM employee_info"

                InvoiceInfoDataB = dbInvoiceInfo.execute_fill_dataset(sql)

                ddlEmployeeID.SelectedValue = InvoiceInfoDataB.Tables(0).Rows(0).ItemArray(0)

                sql = "SELECT InvoiceID, InvoiceDate, InvoiceUpdateDate, InvoiceSubtotal, InvoiceTotal FROM invoice_info"

                InvoiceInfoDataC = dbInvoiceInfo.execute_fill_dataset(sql)

                Try
                    lblInvoiceID.Text = InvoiceInfoDataC.Tables(0).Rows(0).ItemArray(0)
                    lblInvoiceDate.Text = InvoiceInfoDataC.Tables(0).Rows(0).ItemArray(1).ToString
                    lblInvoiceUpdateDate.Text = InvoiceInfoDataC.Tables(0).Rows(0).ItemArray(2).ToString
                    lblInvoiceSubtotal.Text = InvoiceInfoDataC.Tables(0).Rows(0).ItemArray(3).ToString
                    lblInvoiceTotal.Text = InvoiceInfoDataC.Tables(0).Rows(0).ItemArray(4).ToString
                Catch
                    rblInvoiceInfo.SelectedValue = 1
                    lblTransactionStatus.Text = "Error 011 - There is no records at Invoice Info table."
                End Try

                dbInvoiceInfo.clear_connection_nonquery()
            Else

                lblExistingInvoice.Visible = True
                lblExistingInvoiceInfoInside.Visible = True
                ddlInvoiceInfo.Visible = True

                Dim dbInvoiceInfo As New db_class
                Dim InvoiceInfoDataA As New DataSet
                Dim InvoiceInfoDataB As New DataSet
                Dim InvoiceInfoDataC As New DataSet

                Dim sql As String = "SELECT * FROM customer_info"

                InvoiceInfoDataA = dbInvoiceInfo.execute_fill_dataset(sql)

                lblCustomerID.Text = InvoiceInfoDataA.Tables(0).Rows(ddlInvoiceInfo.SelectedIndex).ItemArray(0).ToString
                ddlCustomerName.SelectedValue = InvoiceInfoDataA.Tables(0).Rows(ddlInvoiceInfo.SelectedIndex).ItemArray(0)
                lblCustomerPhone.Text = InvoiceInfoDataA.Tables(0).Rows(ddlInvoiceInfo.SelectedIndex).ItemArray(2).ToString
                lblCustomerAddress.Text = InvoiceInfoDataA.Tables(0).Rows(ddlInvoiceInfo.SelectedIndex).ItemArray(3).ToString
                lblCustomerEmail.Text = InvoiceInfoDataA.Tables(0).Rows(ddlInvoiceInfo.SelectedIndex).ItemArray(4).ToString

                sql = "SELECT EmployeeID FROM employee_info"

                InvoiceInfoDataB = dbInvoiceInfo.execute_fill_dataset(sql)

                ddlEmployeeID.SelectedValue = InvoiceInfoDataB.Tables(0).Rows(ddlInvoiceInfo.SelectedIndex).ItemArray(0)

                sql = "SELECT InvoiceID, InvoiceDate, InvoiceUpdateDate, InvoiceSubtotal, InvoiceTotal FROM invoice_info"

                InvoiceInfoDataC = dbInvoiceInfo.execute_fill_dataset(sql)

                Try
                    lblInvoiceID.Text = InvoiceInfoDataC.Tables(0).Rows(0).ItemArray(0)
                    lblInvoiceDate.Text = InvoiceInfoDataC.Tables(0).Rows(0).ItemArray(1).ToString
                    lblInvoiceUpdateDate.Text = InvoiceInfoDataC.Tables(0).Rows(0).ItemArray(2).ToString
                    lblInvoiceSubtotal.Text = InvoiceInfoDataC.Tables(0).Rows(0).ItemArray(3).ToString
                    lblInvoiceTotal.Text = InvoiceInfoDataC.Tables(0).Rows(0).ItemArray(4).ToString
                Catch
                    rblInvoiceInfo.SelectedValue = 1
                    lblTransactionStatus.Text = "Error 011 - There is no records at Invoice Info table."
                End Try

                dbInvoiceInfo.clear_connection_nonquery()
            End If
        End If
    End Sub

    Protected Sub rblInvoiceDetail_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rblInvoiceDetail.SelectedIndexChanged
        If rblInvoiceDetail.SelectedValue = 1 Then
            lblExistingInvoiceDetail.Visible = False
            lblExistingInvoiceDetailInside.Visible = False
            ddlInvoiceDetails.Visible = False

            lblInvoiceDetailID.Text = "-"
            Try
                ddlInvoiceLink.SelectedIndex = 0
            Catch
            End Try
            lblLinkedInvoiceID.Text = "-"
            ddlInvoiceDetailItem.SelectedIndex = 0
            txtItemQuantity.Text = ""
            lblItemPriceTotal.Text = "-"

        Else
            If ddlInvoiceDetails.SelectedIndex = -1 Then
                ExistingInvoiceDetailPreloaded = False
            Else
                ExistingInvoiceDetailPreloaded = True
            End If

            If ExistingInvoiceDetailPreloaded = False Then

                lblExistingInvoiceDetail.Visible = True
                lblExistingInvoiceDetailInside.Visible = True
                ddlInvoiceDetails.Visible = True

                Dim dbInvoiceDetail As New db_class
                Dim InvoiceDetailDataA As New DataSet
                Dim InvoiceDetailDataB As New DataSet

                Dim sql As String = "SELECT * FROM invoice_details"

                Try
                    InvoiceDetailDataA = dbInvoiceDetail.execute_fill_dataset(sql)

                    lblInvoiceDetailID.Text = InvoiceDetailDataA.Tables(0).Rows(0).ItemArray(0).ToString
                    ddlInvoiceLink.SelectedValue = InvoiceDetailDataA.Tables(0).Rows(0).ItemArray(1)
                    lblLinkedInvoiceID.Text = InvoiceDetailDataA.Tables(0).Rows(0).ItemArray(1).ToString
                    ddlInvoiceDetailItem.SelectedValue = InvoiceDetailDataA.Tables(0).Rows(0).ItemArray(2)
                    txtItemQuantity.Text = InvoiceDetailDataA.Tables(0).Rows(0).ItemArray(3).ToString
                    lblItemPriceTotal.Text = InvoiceDetailDataA.Tables(0).Rows(0).ItemArray(4).ToString

                    sql = "SELECT * FROM product_info"

                    InvoiceDetailDataB = dbInvoiceDetail.execute_fill_dataset(sql)

                    lblItemPrice.Text = InvoiceDetailDataB.Tables(0).Rows(ddlInvoiceDetailItem.SelectedIndex).ItemArray(2)
                Catch
                    rblInvoiceDetail.SelectedValue = 1
                    lblTransactionStatus.Text = "Error 021 - There is no records at Invoice Details table."
                End Try

                dbInvoiceDetail.clear_connection_nonquery()
            Else
                lblExistingInvoiceDetail.Visible = True
                lblExistingInvoiceDetailInside.Visible = True
                ddlInvoiceDetails.Visible = True

                Dim dbInvoiceDetail As New db_class
                Dim InvoiceDetailDataA As New DataSet
                Dim InvoiceDetailDataB As New DataSet

                Dim sql As String = "SELECT * FROM invoice_details"

                Try
                    InvoiceDetailDataA = dbInvoiceDetail.execute_fill_dataset(sql)

                    lblInvoiceDetailID.Text = InvoiceDetailDataA.Tables(0).Rows(ddlInvoiceDetails.SelectedIndex).ItemArray(0).ToString
                    ddlInvoiceLink.SelectedValue = InvoiceDetailDataA.Tables(0).Rows(ddlInvoiceDetails.SelectedIndex).ItemArray(1)
                    lblLinkedInvoiceID.Text = InvoiceDetailDataA.Tables(0).Rows(ddlInvoiceDetails.SelectedIndex).ItemArray(1).ToString
                    ddlInvoiceDetailItem.SelectedValue = InvoiceDetailDataA.Tables(0).Rows(ddlInvoiceDetails.SelectedIndex).ItemArray(2)
                    txtItemQuantity.Text = InvoiceDetailDataA.Tables(0).Rows(ddlInvoiceDetails.SelectedIndex).ItemArray(3).ToString
                    lblItemPriceTotal.Text = InvoiceDetailDataA.Tables(0).Rows(ddlInvoiceDetails.SelectedIndex).ItemArray(4).ToString

                    sql = "SELECT * FROM product_info"

                    InvoiceDetailDataB = dbInvoiceDetail.execute_fill_dataset(sql)

                    lblItemPrice.Text = InvoiceDetailDataB.Tables(0).Rows(ddlInvoiceDetailItem.SelectedIndex).ItemArray(2)
                Catch
                    rblInvoiceDetail.SelectedValue = 1
                    lblTransactionStatus.Text = "Error 021 - There is no records at Invoice Details table."
                End Try

                dbInvoiceDetail.clear_connection_nonquery()
            End If
        End If
    End Sub

    Protected Sub ddlCustomerName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlCustomerName.SelectedIndexChanged
        Dim dbInvoiceCustomer As New db_class
        Dim InvoiceCustomerData As New DataSet

        Dim sql As String = "SELECT * FROM customer_info WHERE CustomerID=" + ddlCustomerName.SelectedValue

        InvoiceCustomerData = dbInvoiceCustomer.execute_fill_dataset(sql)

        lblCustomerID.Text = InvoiceCustomerData.Tables(0).Rows(0).ItemArray(0).ToString
        lblCustomerPhone.Text = InvoiceCustomerData.Tables(0).Rows(0).ItemArray(2).ToString
        lblCustomerAddress.Text = InvoiceCustomerData.Tables(0).Rows(0).ItemArray(3).ToString
        lblCustomerEmail.Text = InvoiceCustomerData.Tables(0).Rows(0).ItemArray(4).ToString

        dbInvoiceCustomer.clear_connection_nonquery()
    End Sub

    Protected Sub ddlInvoiceLink_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlInvoiceLink.SelectedIndexChanged
        Try
            Dim dbInvoiceLink As New db_class
            Dim InvoiceLinkData As New DataSet

            Dim sql As String = "SELECT * FROM invoice_info WHERE InvoiceID=" + ddlInvoiceLink.SelectedValue

            InvoiceLinkData = dbInvoiceLink.execute_fill_dataset(sql)

            lblLinkedInvoiceID.Text = InvoiceLinkData.Tables(0).Rows(0).ItemArray(0).ToString

            dbInvoiceLink.clear_connection_nonquery()
        Catch
            lblTransactionStatus.Text = "Error 022 - There is no records at Invoice Detail Link."
        End Try
    End Sub

    Protected Sub ddlInvoiceDetailItem_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlInvoiceDetailItem.SelectedIndexChanged
        Try
            Dim dbInvoiceDetailItem As New db_class
            Dim InvoiceDetailItemData As New DataSet

            Dim sql As String = "SELECT * FROM invoice_details"

            sql = "SELECT * FROM product_info WHERE ProductID =" + ddlInvoiceDetailItem.SelectedValue

            InvoiceDetailItemData = dbInvoiceDetailItem.execute_fill_dataset(sql)

            lblItemPrice.Text = InvoiceDetailItemData.Tables(0).Rows(0).ItemArray(2)

            dbInvoiceDetailItem.clear_connection_nonquery()
        Catch
            lblTransactionStatus.Text = "Error 023 - There is no records at Item."
        End Try
    End Sub

    Protected Sub btnInvoiceInfoApply_Click(sender As Object, e As EventArgs) Handles btnInvoiceInfoApply.Click
        Dim InvoiceInfoButtonChoice As Integer = rblInvoiceInfo.SelectedValue

        Select Case InvoiceInfoButtonChoice
            Case 1
                Dim dbInvoiceInfoInsert As New db_class
                Dim InvoiceInfoDataInsert As New DataSet
                Dim InvoicePrecheck As Boolean = True
                Dim InvoiceSubtotal As Decimal
                Dim InvoiceTotal As Decimal
                Dim sqlInvoiceInfoDataInsert As String

                Dim dbProduct As New db_class
                Dim ProductData As New DataSet
                Dim CountData As New Integer

                Dim sqlDataRetrieve As String = "SELECT SUM(InvoiceProductTotal) FROM invoice_details WHERE InvoiceID =" + ddlInvoiceInfo.SelectedValue.ToString + ";"

                Try
                    ProductData = dbProduct.execute_fill_dataset(sqlDataRetrieve)

                    InvoiceSubtotal = ProductData.Tables(0).Rows(0).ItemArray(0)
                    InvoiceTotal = InvoiceSubtotal * 1.1
                Catch
                    InvoiceSubtotal = 0
                    InvoiceTotal = 0

                End Try

                If InvoicePrecheck = True Then
                    Try
                        If Convert.ToInt32(lblInvoiceSubtotal.Text) <= 0 Or Convert.ToInt32(lblInvoiceTotal.Text) <= 0 Then
                            InvoiceSubtotal = 0
                            InvoiceTotal = 0
                        End If
                    Catch
                        InvoiceSubtotal = 0
                        InvoiceTotal = 0
                    End Try
                End If
                sqlInvoiceInfoDataInsert = "INSERT INTO invoice_info (InvoiceDate, CustomerID, EmployeeID, InvoiceSubTotal, InvoiceTotal) VALUES ('" + DateTime.Now + "', '" + ddlCustomerName.SelectedValue + "', '" + ddlEmployeeID.SelectedValue + "', '" + Convert.ToString(InvoiceSubtotal) + "', '" + Convert.ToString(InvoiceTotal) + "')"

                Try
                    dbInvoiceInfoInsert.execute_non_query(sqlInvoiceInfoDataInsert)
                Catch ex As Exception
                    lblTransactionStatus.Text = "Error 312 - Error while inserting invoice information."
                Finally
                    lblTransactionStatus.Text = "Information for the current invoice has successfully added."
                    dbInvoiceInfoInsert.clear_connection_nonquery()

                    ddlInvoiceInfo.DataBind()
                    ddlInvoiceLink.DataBind()
                    rblInvoiceInfo.SelectedValue = 1
                    ddlCustomerName.SelectedIndex = 0
                    ddlEmployeeID.SelectedIndex = 0
                    lblInvoiceID.Text = "-"
                    lblInvoiceSubtotal.Text = "-"
                    lblInvoiceTotal.Text = "-"
                    lblInvoiceDate.Text = "-"
                    lblInvoiceUpdateDate.Text = "-"
                End Try
            Case 2
                Dim dbInvoiceInfoUpdate As New db_class
                Dim InvoiceInfoUpdateData As New DataSet
                Dim InvoicePrecheck As Boolean = True
                Dim InvoiceSubtotal As Decimal
                Dim InvoiceTotal As Decimal
                Dim sqlInvoiceInfoDataUpdate As String

                Dim dbProduct As New db_class
                Dim ProductData As New DataSet
                Dim CountData As New Integer

                Dim sqlDataRetrieve As String = "SELECT SUM(InvoiceProductTotal) FROM invoice_details WHERE InvoiceID =" + ddlInvoiceInfo.SelectedValue.ToString + ";"

                Try
                    ProductData = dbProduct.execute_fill_dataset(sqlDataRetrieve)

                    InvoiceSubtotal = ProductData.Tables(0).Rows(0).ItemArray(0)
                    InvoiceTotal = InvoiceSubtotal * 1.1
                Catch
                    InvoiceSubtotal = 0
                    InvoiceTotal = 0

                End Try

                If InvoicePrecheck = True Then
                    Try
                        If InvoiceSubtotal <= 0 Or InvoiceTotal <= 0 Then
                            InvoiceSubtotal = 0
                            InvoiceTotal = 0
                        End If
                    Catch
                        InvoiceSubtotal = 0
                        InvoiceTotal = 0
                    End Try
                End If
                sqlInvoiceInfoDataUpdate = "UPDATE invoice_info SET InvoiceUpdateDate='" + DateTime.Now + "', CustomerID='" + ddlCustomerName.SelectedValue + "', EmployeeID='" + ddlEmployeeID.SelectedValue + "', InvoiceSubtotal='" + InvoiceSubtotal.ToString + "', InvoiceTotal='" + InvoiceTotal.ToString + "' WHERE InvoiceID=" + ddlInvoiceInfo.SelectedValue + ";"

                Try
                    dbInvoiceInfoUpdate.execute_non_query(sqlInvoiceInfoDataUpdate)
                Catch ex As Exception
                    lblTransactionStatus.Text = "Error 322 - Error while updating invoice information."
                Finally
                    lblTransactionStatus.Text = "Information for the current invoice has successfully updated."
                    dbInvoiceInfoUpdate.clear_connection_nonquery()

                    ddlInvoiceInfo.DataBind()
                    ddlInvoiceLink.DataBind()
                    rblInvoiceInfo.SelectedValue = 1
                    ddlCustomerName.SelectedIndex = 0
                    ddlEmployeeID.SelectedIndex = 0
                    lblInvoiceID.Text = "-"
                    lblInvoiceSubtotal.Text = "-"
                    lblInvoiceTotal.Text = "-"
                    lblInvoiceDate.Text = "-"
                    lblInvoiceUpdateDate.Text = "-"
                End Try
            Case 3
                Dim dbInvoiceInfoRemove As New db_class
                Dim InvoiceInfoDataRemove As New DataSet
                Dim DataPointer As Integer

                Dim sqlDataRetrieve As String = "SELECT * FROM invoice_info WHERE InvoiceID=" + ddlInvoiceInfo.SelectedValue + ";"
                InvoiceInfoDataRemove = dbInvoiceInfoRemove.execute_fill_dataset(sqlDataRetrieve)
                DataPointer = InvoiceInfoDataRemove.Tables(0).Rows(0).ItemArray(0)

                Dim sqlInvoiceInfoRemove As String
                sqlInvoiceInfoRemove = "DELETE FROM invoice_info WHERE InvoiceID=" + DataPointer.ToString + ";"

                Try
                    dbInvoiceInfoRemove.execute_non_query(sqlInvoiceInfoRemove)
                Catch ex As Exception
                    lblTransactionStatus.Text = "Error 332 - Error while removing invoice information."
                Finally
                    lblTransactionStatus.Text = "Information for the current invoice has successfully removed."
                    dbInvoiceInfoRemove.clear_connection_nonquery()

                    ddlInvoiceInfo.DataBind()
                    ddlInvoiceLink.DataBind()
                    rblInvoiceInfo.SelectedValue = 1
                    ddlCustomerName.SelectedIndex = 0
                    ddlEmployeeID.SelectedIndex = 0
                    lblInvoiceID.Text = "-"
                    lblInvoiceSubtotal.Text = "-"
                    lblInvoiceTotal.Text = "-"
                    lblInvoiceDate.Text = "-"
                    lblInvoiceUpdateDate.Text = "-"
                End Try
        End Select
    End Sub

    Protected Sub btnInvoiceDetailApply_Click(sender As Object, e As EventArgs) Handles btnInvoiceDetailApply.Click
        Dim InvoiceInfoButtonChoice As Integer = rblInvoiceDetail.SelectedValue

        Select Case InvoiceInfoButtonChoice
            Case 1
                Dim dbInvoiceDetailInsert As New db_class
                Dim InvoiceDetailDataInsert As New DataSet
                Dim InvoiceDetailCalculation As Decimal
                Dim sqlInvoiceDetailDataInsert As String = "SELECT ProductPrice FROM product_info WHERE ProductID =" + ddlInvoiceDetailItem.SelectedValue + ";"
                Dim ErrorCheck As Boolean = True

                Try
                    InvoiceDetailDataInsert = dbInvoiceDetailInsert.execute_fill_dataset(sqlInvoiceDetailDataInsert)
                    InvoiceDetailCalculation = InvoiceDetailDataInsert.Tables(0).Rows(ddlCustomerName.SelectedIndex).ItemArray(0).ToString * Convert.ToInt32(txtItemQuantity.Text)
                Catch
                    ErrorCheck = False
                    lblTransactionStatus.Text = "Error 411 - Invalid quantity has entered, or something has gone wrong."
                End Try

                sqlInvoiceDetailDataInsert = "INSERT INTO invoice_details (InvoiceID, ProductID, InvoiceProductQuantity, InvoiceProductTotal) VALUES ('" + ddlInvoiceLink.SelectedValue + "', '" + ddlInvoiceDetailItem.SelectedValue + "', '" + Convert.ToString(txtItemQuantity.Text) + "', '" + InvoiceDetailCalculation.ToString + "')"

                If ErrorCheck = True Then
                    Try
                        dbInvoiceDetailInsert.execute_non_query(sqlInvoiceDetailDataInsert)
                    Catch ex As Exception
                        lblTransactionStatus.Text = "Error 412 - Error while inserting invoice details."
                    Finally
                        lblTransactionStatus.Text = "Details for the current invoice has successfully added."
                        dbInvoiceDetailInsert.clear_connection_nonquery()

                        ddlInvoiceDetails.DataBind()
                        ddlInvoiceLink.SelectedIndex = 0
                        ddlInvoiceDetailItem.SelectedIndex = 0
                        txtItemQuantity.Text = ""
                        lblItemPriceTotal.Text = "-"
                    End Try
                End If
            Case 2
                Dim dbInvoiceDetailUpdate As New db_class
                Dim InvoiceDetailDataUpdate As New DataSet
                Dim InvoiceDetailUpdateCalculation As Decimal
                Dim sqlInvoiceDetailDataUpdate As String = "SELECT ProductPrice FROM product_info WHERE ProductID =" + ddlInvoiceDetailItem.SelectedValue + ";"
                Dim ErrorCheck As Boolean = True

                Try
                    InvoiceDetailDataUpdate = dbInvoiceDetailUpdate.execute_fill_dataset(sqlInvoiceDetailDataUpdate)
                    InvoiceDetailUpdateCalculation = InvoiceDetailDataUpdate.Tables(0).Rows(ddlCustomerName.SelectedIndex).ItemArray(0).ToString * Convert.ToInt32(txtItemQuantity.Text)
                Catch
                    ErrorCheck = False
                    lblTransactionStatus.Text = "Error 421 - Invalid quantity has entered, or something has gone wrong."
                End Try

                sqlInvoiceDetailDataUpdate = "UPDATE invoice_detail SET InvoiceID='" + ddlInvoiceLink.SelectedValue.ToString + "', ProductID='" + ddlInvoiceDetailItem.SelectedValue.ToString + "', InvoiceProductQuantity='" + txtItemQuantity.Text + "', InvoiceProductTotal='" + InvoiceDetailUpdateCalculation.ToString + "' WHERE InvoiceDetailID=" + ddlInvoiceDetails.SelectedValue + ";"

                If ErrorCheck = True Then
                    Try
                        dbInvoiceDetailUpdate.execute_non_query(sqlInvoiceDetailDataUpdate)
                    Catch ex As Exception
                        lblTransactionStatus.Text = "Error 422 - Error while update invoice details."
                    Finally
                        lblTransactionStatus.Text = "Details for the current invoice has successfully updated."
                        dbInvoiceDetailUpdate.clear_connection_nonquery()

                        ddlInvoiceDetails.DataBind()
                        ddlInvoiceLink.SelectedIndex = 0
                        ddlInvoiceDetailItem.SelectedIndex = 0
                        txtItemQuantity.Text = ""
                        lblItemPriceTotal.Text = "-"
                    End Try
                End If
            Case 3
                Dim dbInvoiceDataRemove As New db_class
                Dim InvoiceDetailDataRemove As New DataSet
                Dim sqlDataRetrieve As String = "SELECT * FROM invoice_details WHERE InvoiceDetailID=" + ddlInvoiceDetails.SelectedValue + ";"
                InvoiceDetailDataRemove = dbInvoiceDataRemove.execute_fill_dataset(sqlDataRetrieve)
                Dim DataPointer As Integer = InvoiceDetailDataRemove.Tables(0).Rows(0).ItemArray(0)

                Dim sqlInvoiceDetailsRemove As String
                sqlInvoiceDetailsRemove = "DELETE FROM invoice_details WHERE InvoiceDetailID=" + DataPointer.ToString + ";"

                Try
                    dbInvoiceDataRemove.execute_non_query(sqlInvoiceDetailsRemove)
                Catch ex As Exception
                    lblTransactionStatus.Text = "Error 432 - Error while remove invoice details."
                Finally
                    lblTransactionStatus.Text = "Details for the current invoice has successfully removed."
                    dbInvoiceDataRemove.clear_connection_nonquery()

                    ddlInvoiceDetails.DataBind()
                    ddlInvoiceLink.SelectedIndex = 0
                    ddlInvoiceDetailItem.SelectedIndex = 0
                    txtItemQuantity.Text = ""
                    lblItemPriceTotal.Text = "-"
                End Try
        End Select
    End Sub

    Protected Sub ddlInvoiceInfo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlInvoiceInfo.SelectedIndexChanged
        Dim dbInvoiceInfoRefresh As New db_class
        Dim InvoiceInfoRefreshdata As New DataSet

        Dim sqlDataRetrieve As String = "SELECT InvoiceID, InvoiceDate, InvoiceUpdateDate, InvoiceSubTotal, InvoiceTotal FROM invoice_info"

        InvoiceInfoRefreshdata = dbInvoiceInfoRefresh.execute_fill_dataset(sqlDataRetrieve)

        lblInvoiceID.Text = InvoiceInfoRefreshdata.Tables(0).Rows(ddlInvoiceInfo.SelectedIndex).ItemArray(0).ToString
        lblInvoiceDate.Text = InvoiceInfoRefreshdata.Tables(0).Rows(ddlInvoiceInfo.SelectedIndex).ItemArray(1).ToString
        lblInvoiceUpdateDate.Text = InvoiceInfoRefreshdata.Tables(0).Rows(ddlInvoiceInfo.SelectedIndex).ItemArray(2).ToString
        lblInvoiceSubtotal.Text = InvoiceInfoRefreshdata.Tables(0).Rows(ddlInvoiceInfo.SelectedIndex).ItemArray(3).ToString
        lblInvoiceTotal.Text = InvoiceInfoRefreshdata.Tables(0).Rows(ddlInvoiceInfo.SelectedIndex).ItemArray(4).ToString

        dbInvoiceInfoRefresh.clear_connection_nonquery()
    End Sub

    Protected Sub ddlInvoiceDetails_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlInvoiceDetails.SelectedIndexChanged
        Dim dbInvoiceDetailsRefresh As New db_class
        Dim InvoiceDetailsRefreshData As New DataSet
        Dim TemporaryPriceCheckData As New DataSet

        Dim sqlDataRetrieve As String = "SELECT InvoiceDetailID, InvoiceID, ProductID, InvoiceProductQuantity, InvoiceProductTotal FROM invoice_details"

        InvoiceDetailsRefreshData = dbInvoiceDetailsRefresh.execute_fill_dataset(sqlDataRetrieve)

        sqlDataRetrieve = "SELECT ProductPrice FROM product_info WHERE ProductID=" + InvoiceDetailsRefreshData.Tables(0).Rows(ddlInvoiceDetails.SelectedIndex).ItemArray(3).ToString + ";"

        TemporaryPriceCheckData = dbInvoiceDetailsRefresh.execute_fill_dataset(sqlDataRetrieve)

        lblInvoiceDetailID.Text = InvoiceDetailsRefreshData.Tables(0).Rows(ddlInvoiceDetails.SelectedIndex).ItemArray(0).ToString
        ddlInvoiceLink.SelectedValue = InvoiceDetailsRefreshData.Tables(0).Rows(ddlInvoiceDetails.SelectedIndex).ItemArray(1)
        lblLinkedInvoiceID.Text = InvoiceDetailsRefreshData.Tables(0).Rows(ddlInvoiceDetails.SelectedIndex).ItemArray(1).ToString
        ddlInvoiceDetailItem.SelectedValue = InvoiceDetailsRefreshData.Tables(0).Rows(ddlInvoiceDetails.SelectedIndex).ItemArray(2)
        lblItemPrice.Text = TemporaryPriceCheckData.Tables(0).Rows(0).ItemArray(0).ToString
        txtItemQuantity.Text = InvoiceDetailsRefreshData.Tables(0).Rows(ddlInvoiceDetails.SelectedIndex).ItemArray(3).ToString
        lblInvoiceTotal.Text = TemporaryPriceCheckData.Tables(0).Rows(0).ItemArray(0).ToString * InvoiceDetailsRefreshData.Tables(0).Rows(ddlInvoiceDetails.SelectedIndex).ItemArray(4).ToString

        dbInvoiceDetailsRefresh.clear_connection_nonquery()
    End Sub
End Class