Public Class Inventory
    Inherits System.Web.UI.Page
    Dim ExistingProductPreloaded As Boolean
    Dim ExistingVendorPreloaded As Boolean

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub rblProductChoice_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rblProductChoice.SelectedIndexChanged
        If rblProductChoice.SelectedValue = 1 Then
            lblExistingProduct.Visible = False
            lblExistingProductInside.Visible = False
            ddlExistingProduct.Visible = False

            lblProductID.Text = "-"
            txtProductDescription.Text = ""
            txtProductPrice.Text = ""
            txtProductQuantity.Text = ""
            ddlLinkedVendor.SelectedIndex = 0

        Else
            If ddlExistingProduct.SelectedIndex = -1 Then
                ExistingProductPreloaded = False
            Else
                ExistingProductPreloaded = True
            End If

            If ExistingProductPreloaded = False Then

                lblExistingProduct.Visible = True
                lblExistingProductInside.Visible = True
                ddlExistingProduct.Visible = True

                Dim dbProduct As New db_class
                Dim ProductData As New DataSet

                Dim sql As String = "SELECT * FROM product_info"

                ProductData = dbProduct.execute_fill_dataset(sql)

                lblProductID.Text = ProductData.Tables(0).Rows(0).ItemArray(0).ToString
                txtProductDescription.Text = ProductData.Tables(0).Rows(0).ItemArray(1).ToString
                txtProductPrice.Text = ProductData.Tables(0).Rows(0).ItemArray(2).ToString
                txtProductQuantity.Text = ProductData.Tables(0).Rows(0).ItemArray(3).ToString
                ddlLinkedVendor.SelectedValue = ProductData.Tables(0).Rows(0).ItemArray(4)

                dbProduct.clear_connection_nonquery()
            Else
                lblExistingProduct.Visible = True
                lblExistingProductInside.Visible = True
                ddlExistingProduct.Visible = True

                Dim dbProduct As New db_class
                Dim ProductData As New DataSet

                Dim sql As String = "SELECT * FROM product_info"

                ProductData = dbProduct.execute_fill_dataset(sql)

                lblProductID.Text = ProductData.Tables(0).Rows(ddlExistingProduct.SelectedIndex).ItemArray(0).ToString
                txtProductDescription.Text = ProductData.Tables(0).Rows(ddlExistingProduct.SelectedIndex).ItemArray(1).ToString
                txtProductPrice.Text = ProductData.Tables(0).Rows(ddlExistingProduct.SelectedIndex).ItemArray(2).ToString
                txtProductQuantity.Text = ProductData.Tables(0).Rows(ddlExistingProduct.SelectedIndex).ItemArray(3).ToString
                ddlLinkedVendor.SelectedValue = ProductData.Tables(0).Rows(ddlExistingProduct.SelectedIndex).ItemArray(4)

                dbProduct.clear_connection_nonquery()
            End If
        End If
    End Sub

    Protected Sub rblVendorChoice_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rblVendorChoice.SelectedIndexChanged
        If rblVendorChoice.SelectedValue = 1 Then
            lblExistingVendor.Visible = False
            lblExistingVendorInside.Visible = False
            ddlExistingVendor.Visible = False

            lblVendorID.Text = "-"
            txtVendorAccountNumber.Text = ""
            txtVendorName.Text = ""
            txtVendorAddress.Text = ""
            txtVendorContactName.Text = ""
            txtVendorContactPhone.Text = ""
        Else
            If ddlExistingVendor.SelectedIndex = -1 Then
                ExistingVendorPreloaded = False
            Else
                ExistingVendorPreloaded = True
            End If

            If ExistingVendorPreloaded = False Then

                lblExistingVendor.Visible = True
                lblExistingVendorInside.Visible = True
                ddlExistingVendor.Visible = True

                Dim dbVendor As New db_class
                Dim VendorData As New DataSet

                Dim sql As String = "SELECT * FROM vendor_info"

                VendorData = dbVendor.execute_fill_dataset(sql)

                lblVendorID.Text = VendorData.Tables(0).Rows(0).ItemArray(0).ToString
                txtVendorAccountNumber.Text = VendorData.Tables(0).Rows(0).ItemArray(1).ToString
                txtVendorName.Text = VendorData.Tables(0).Rows(0).ItemArray(2).ToString
                txtVendorAddress.Text = VendorData.Tables(0).Rows(0).ItemArray(3).ToString
                txtVendorContactName.Text = VendorData.Tables(0).Rows(0).ItemArray(4).ToString
                txtVendorContactPhone.Text = VendorData.Tables(0).Rows(0).ItemArray(5).ToString

                dbVendor.clear_connection_nonquery()
            Else
                lblExistingVendor.Visible = True
                lblExistingVendorInside.Visible = True
                ddlExistingVendor.Visible = True

                Dim dbVendor As New db_class
                Dim VendorData As New DataSet

                Dim sql As String = "SELECT * FROM vendor_info"

                VendorData = dbVendor.execute_fill_dataset(sql)

                lblVendorID.Text = VendorData.Tables(0).Rows(ddlExistingVendor.SelectedIndex).ItemArray(0).ToString
                txtVendorAccountNumber.Text = VendorData.Tables(0).Rows(ddlExistingVendor.SelectedIndex).ItemArray(1).ToString
                txtVendorName.Text = VendorData.Tables(0).Rows(ddlExistingVendor.SelectedIndex).ItemArray(2).ToString
                txtVendorAddress.Text = VendorData.Tables(0).Rows(ddlExistingVendor.SelectedIndex).ItemArray(3).ToString
                txtVendorContactName.Text = VendorData.Tables(0).Rows(ddlExistingVendor.SelectedIndex).ItemArray(4).ToString
                txtVendorContactPhone.Text = VendorData.Tables(0).Rows(ddlExistingVendor.SelectedIndex).ItemArray(5).ToString

                dbVendor.clear_connection_nonquery()
            End If
        End If
    End Sub

    Protected Sub btnProductApply_Click(sender As Object, e As EventArgs) Handles btnProductApply.Click
        Dim ProductRadioButtonChoice As Integer = rblProductChoice.SelectedValue

        Select Case ProductRadioButtonChoice
            Case 1
                Dim dbProductInsert As New db_class
                Dim ProductDataInsert As New DataSet

                Dim sqlProductDataInsert As String
                sqlProductDataInsert = "INSERT INTO product_info (ProductDescription, ProductPrice, ProductQuantity, VendorID) VALUES ('" + txtProductDescription.Text + "', '" + txtProductPrice.Text + "', '" + txtProductQuantity.Text + "', '" + ddlLinkedVendor.SelectedValue + "')"

                Try
                    dbProductInsert.execute_non_query(sqlProductDataInsert)
                Catch ex As Exception
                    lblInventoryStatus.Text = "Error 211 - Error while inserting product database record."
                Finally
                    lblInventoryStatus.Text = "Product information for " + txtProductDescription.Text + " has successfully added."
                    dbProductInsert.clear_connection_nonquery()

                    ddlExistingProduct.DataBind()
                    lblProductID.Text = "-"
                    txtProductDescription.Text = ""
                    txtProductPrice.Text = ""
                    txtProductQuantity.Text = ""
                    rblProductChoice.SelectedIndex = 0
                    ddlLinkedVendor.SelectedIndex = 0
                End Try
            Case 2
                Dim dbProductUpdate As New db_class
                Dim ProductDataUpdate As New DataSet
                Dim DataPointer As Integer

                Dim sqlDataRetrieve As String = "SELECT * FROM product_info"
                ProductDataUpdate = dbProductUpdate.execute_fill_dataset(sqlDataRetrieve)
                DataPointer = ProductDataUpdate.Tables(0).Rows(ddlExistingProduct.SelectedIndex).ItemArray(0)

                Dim sqlProductDataUpdate As String
                sqlProductDataUpdate = "UPDATE product_info SET ProductDescription='" + txtProductDescription.Text + "', ProductPrice='" + txtProductPrice.Text + "', ProductQuantity='" + txtProductQuantity.Text + "', VendorID='" + ddlLinkedVendor.SelectedValue + "' WHERE ProductID=" + DataPointer.ToString + ";"

                Try
                    dbProductUpdate.execute_non_query(sqlProductDataUpdate)
                Catch ex As Exception
                    lblInventoryStatus.Text = "Error 221 - Error while updating product database record."
                Finally
                    lblInventoryStatus.Text = "Product information for " + txtProductDescription.Text + " has successfully updated."
                    dbProductUpdate.clear_connection_nonquery()

                    ddlExistingProduct.DataBind()
                    lblProductID.Text = "-"
                    txtProductDescription.Text = ""
                    txtProductPrice.Text = ""
                    txtProductQuantity.Text = ""
                    rblProductChoice.SelectedIndex = 0
                    ddlLinkedVendor.SelectedIndex = 0
                End Try
            Case 3
                Dim dbProductRemove As New db_class
                Dim ProductDataRemove As New DataSet
                Dim DataPointer As Integer

                Dim sqlDataRetrieve As String = "SELECT * FROM product_info"
                ProductDataRemove = dbProductRemove.execute_fill_dataset(sqlDataRetrieve)
                DataPointer = ProductDataRemove.Tables(0).Rows(ddlExistingProduct.SelectedIndex).ItemArray(0)

                Dim sqlProductDataRemove As String
                sqlProductDataRemove = "DELETE FROM product_info WHERE ProductID=" + DataPointer.ToString + ";"

                Try
                    dbProductRemove.execute_non_query(sqlProductDataRemove)
                Catch ex As Exception
                    lblInventoryStatus.Text = "Error 231 - Error while removing product database record."
                Finally
                    lblInventoryStatus.Text = "Product information for " + txtProductDescription.Text + " has successfully removed."
                    dbProductRemove.clear_connection_nonquery()

                    ddlExistingProduct.DataBind()
                    lblProductID.Text = "-"
                    txtProductDescription.Text = ""
                    txtProductPrice.Text = ""
                    txtProductQuantity.Text = ""
                    rblProductChoice.SelectedIndex = 0
                    ddlLinkedVendor.SelectedIndex = 0
                End Try
        End Select
    End Sub

    Protected Sub btnVendorApply_Click(sender As Object, e As EventArgs) Handles btnVendorApply.Click
        Dim VendorRadioButtonChoice As Integer = rblVendorChoice.SelectedValue
        Dim ErrorCheck As Boolean = True

        If Convert.ToInt64(txtVendorContactPhone.Text) > 9999999999 Or Convert.ToInt64(txtVendorContactPhone.Text) < 1000000000 Then
            ErrorCheck = False
            lblInventoryStatus.Text = "Error 100 - Input error detected at Vendor Phone, or something wrong has happened."
        End If

        If ErrorCheck = True Then
            Select Case VendorRadioButtonChoice
                Case 1
                    Dim dbVendorInsert As New db_class
                    Dim VendorDataInsert As New DataSet

                    Dim sqlVendorDataInsert As String
                    sqlVendorDataInsert = "INSERT INTO vendor_info (VendorAccountNumber, VendorCompanyName, VendorCompanyAddress,VendorContactName, VendorContactPhone) VALUES ('" + txtVendorAccountNumber.Text + "', '" + txtVendorName.Text + "', '" + txtVendorAddress.Text + "', '" + txtVendorContactName.Text + "', '" + txtVendorContactPhone.Text + "')"

                    Try
                        dbVendorInsert.execute_non_query(sqlVendorDataInsert)
                    Catch ex As Exception
                        lblInventoryStatus.Text = "Error 212 - Error while inserting vendor database record."
                    Finally
                        lblInventoryStatus.Text = "Vendor information for " + txtVendorName.Text + " has successfully added."
                        dbVendorInsert.clear_connection_nonquery()

                        ddlExistingVendor.DataBind()
                        ddlLinkedVendor.DataBind()
                        lblVendorID.Text = "-"
                        txtVendorAccountNumber.Text = ""
                        txtVendorName.Text = ""
                        txtVendorAddress.Text = ""
                        txtVendorContactName.Text = ""
                        txtVendorContactPhone.Text = ""
                    End Try
                Case 2
                    Dim dbVendorUpdate As New db_class
                    Dim VendorDataUpdate As New DataSet
                    Dim DataPointer As Integer

                    Dim sqlDataRetrieve As String = "SELECT * FROM vendor_info"
                    VendorDataUpdate = dbVendorUpdate.execute_fill_dataset(sqlDataRetrieve)
                    DataPointer = VendorDataUpdate.Tables(0).Rows(ddlExistingVendor.SelectedIndex).ItemArray(0)

                    Dim sqlVendorDataUpdate As String
                    sqlVendorDataUpdate = "UPDATE vendor_info SET VendorAccountNumber='" + txtVendorAccountNumber.Text + "', VendorCompanyName='" + txtVendorName.Text + "', VendorCompanyAddress='" + txtVendorAddress.Text + "', VendorContactName='" + txtVendorContactName.Text + "', VendorcontactPhone='" + txtVendorContactPhone.Text + "' WHERE VendorID=" + DataPointer.ToString + ";"

                    Try
                        dbVendorUpdate.execute_non_query(sqlVendorDataUpdate)
                    Catch ex As Exception
                        lblInventoryStatus.Text = "Error 222 - Error while updating vendor database record."
                    Finally
                        lblInventoryStatus.Text = "Vendor information for " + txtVendorName.Text + " has successfully updated."
                        dbVendorUpdate.clear_connection_nonquery()

                        ddlExistingVendor.DataBind()
                        ddlLinkedVendor.DataBind()
                        lblVendorID.Text = "-"
                        txtVendorAccountNumber.Text = ""
                        txtVendorName.Text = ""
                        txtVendorAddress.Text = ""
                        txtVendorContactName.Text = ""
                        txtVendorContactPhone.Text = ""
                        rblVendorChoice.SelectedIndex = 0
                        ddlExistingVendor.SelectedIndex = 0
                    End Try
                Case 3
                    Dim dbVendorRemove As New db_class
                    Dim VendorDataRemove As New DataSet
                    Dim DataPointer As Integer

                    Dim sqlDataRetrieve As String = "SELECT * FROM vendor_info"
                    VendorDataRemove = dbVendorRemove.execute_fill_dataset(sqlDataRetrieve)
                    DataPointer = VendorDataRemove.Tables(0).Rows(ddlExistingVendor.SelectedIndex).ItemArray(0)

                    Dim sqlVendorRemove As String
                    sqlVendorRemove = "DELETE FROM vendor_info WHERE VendorID=" + DataPointer.ToString + ";"

                    Try
                        dbVendorRemove.execute_non_query(sqlVendorRemove)
                    Catch ex As Exception
                        lblInventoryStatus.Text = "Error 232 - Error while removing vendor database record."
                    Finally
                        lblInventoryStatus.Text = "Vendor information for " + txtVendorName.Text + " has successfully removed."
                        dbVendorRemove.clear_connection_nonquery()

                        ddlExistingVendor.DataBind()
                        ddlLinkedVendor.DataBind()
                        lblVendorID.Text = "-"
                        txtVendorAccountNumber.Text = ""
                        txtVendorName.Text = ""
                        txtVendorAddress.Text = ""
                        txtVendorContactName.Text = ""
                        txtVendorContactPhone.Text = ""
                        rblVendorChoice.SelectedIndex = 0
                        ddlExistingVendor.SelectedIndex = 0
                    End Try
            End Select
        End If
    End Sub

    Protected Sub ddlExistingProduct_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlExistingProduct.SelectedIndexChanged
        Dim dbProduct As New db_class
        Dim ProductData As New DataSet

        Dim sqlDataRetrieve As String = "SELECT * FROM product_info"

        ProductData = dbProduct.execute_fill_dataset(sqlDataRetrieve)

        lblProductID.Text = ProductData.Tables(0).Rows(ddlExistingProduct.SelectedIndex).ItemArray(0).ToString
        txtProductDescription.Text = ProductData.Tables(0).Rows(ddlExistingProduct.SelectedIndex).ItemArray(1).ToString
        txtProductPrice.Text = ProductData.Tables(0).Rows(ddlExistingProduct.SelectedIndex).ItemArray(2).ToString
        txtProductQuantity.Text = ProductData.Tables(0).Rows(ddlExistingProduct.SelectedIndex).ItemArray(3).ToString
        ddlLinkedVendor.SelectedValue = ProductData.Tables(0).Rows(ddlExistingProduct.SelectedIndex).ItemArray(4)

        dbProduct.clear_connection_nonquery()
    End Sub

    Protected Sub ddlExistingVendor_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlExistingVendor.SelectedIndexChanged
        Dim dbVendor As New db_class
        Dim VendorData As New DataSet

        Dim sqlDataRetrieve As String = "SELECT * FROM vendor_info"

        VendorData = dbVendor.execute_fill_dataset(sqlDataRetrieve)

        lblVendorID.Text = VendorData.Tables(0).Rows(ddlExistingVendor.SelectedIndex).ItemArray(0).ToString
        txtVendorAccountNumber.Text = VendorData.Tables(0).Rows(ddlExistingVendor.SelectedIndex).ItemArray(1).ToString
        txtVendorName.Text = VendorData.Tables(0).Rows(ddlExistingVendor.SelectedIndex).ItemArray(2).ToString
        txtVendorAddress.Text = VendorData.Tables(0).Rows(ddlExistingVendor.SelectedIndex).ItemArray(3).ToString
        txtVendorContactName.Text = VendorData.Tables(0).Rows(ddlExistingVendor.SelectedIndex).ItemArray(4).ToString
        txtVendorContactPhone.Text = VendorData.Tables(0).Rows(ddlExistingVendor.SelectedIndex).ItemArray(5).ToString

        dbVendor.clear_connection_nonquery()
    End Sub
End Class