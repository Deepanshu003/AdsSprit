﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageContact.aspx.cs" Inherits="AdsSprit.AdsSpritAdmin.ManageContact" %>
<%@ Register Src="Header.ascx" TagName="Header" TagPrefix="uc1" %>
<%@ Register Src="Footer.ascx" TagName="Footer" TagPrefix="uc2" %>
<%@ Register Src="HeaderRight.ascx" TagName="HeaderRight" TagPrefix="uc3" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ADS</title>
    <link rel="icon" href="images/adslogo.png" type="image/x-icon" />
    <link href="css/bootstrap.css" rel="stylesheet" />
    <link href="css/font-awesome.css" rel="stylesheet" />
    <link href="css/morris-0.4.3.min.css" rel="stylesheet" />
    <link href="css/custom-styles.css" rel="stylesheet" />
    <link href='http://fonts.googleapis.com/css?family=Open+Sans' rel='stylesheet' type='text/css' />
    <script src="Js/Validation.js" language="javascript" type="text/javascript"></script>
    <style>
.modalPopup {background-color: #FFFFFF;border-width: 2px;border-style: solid;border-color: #90001f;padding: 3px;width: 500px;}
.modalPopup11_1 {border: none;}
.modalPopup11_1 table {font-family: Verdana, Arial, Helvetica, sans-serif;}
table {border-collapse: collapse;margin: auto;width: 100%;}
table, td {background: #fff none repeat scroll 0 0;border: 1px solid black;color: #000;font-size: 12px;line-height: 19px;padding: 5px 10px;text-align: center;}
.modalPopup11_1 table tr {display: table-row;vertical-align: inherit;border-color: inherit;}
.modalPopup11_1 table tr td {display: table-cell;vertical-align: inherit;border: none;padding: 0px;margin-bottom: 0px;float: left;}
.modalPopup11_1 table tr td a {text-decoration: none;color:#000;}
</style>
</head>
<body>
    <form id="form1" runat="server">
<div id="wrapper">
            <uc1:Header ID="Header1" runat="server" />
            <div id="page-wrapper">
             <uc3:HeaderRight ID="HeaderRight1" runat="server" />
                <div id="page-inner">
                    <div class="row">
                        <div class="col-md-12">
                            <h3 class="page-header">Manage Enquiry </h3>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-12">
                            <div class="panel panel-default">
                                <div class="panel-heading">
                                    <asp:Label ID="lblMsg" runat="server" Text="" CssClass="textGreen"></asp:Label>
                                    <asp:Label ID="lblError" runat="server" Text="" CssClass="textRed"></asp:Label>
                                </div>
                                <div class="panel-body">
                                  <div class="row" style="margin-bottom:10px;">
                                    <div class="col-lg-12">
                                        <asp:DropDownList ID="DdEnquiry" runat="server" Visible="false"  AutoPostBack="true" CssClass="form-control" style="display: inline-block;" onselectedindexchanged="DdEnquiry_SelectedIndexChanged" Width="200" Height="35">
                                            <asp:ListItem Value="">Select Enquiry Type</asp:ListItem>
                                            <asp:ListItem Value="Quick Enquiry">Quick Enquiry</asp:ListItem>
                                            <asp:ListItem Value="Normal Enquiry">Normal Enquiry</asp:ListItem>
                                             <asp:ListItem Value="Product Enquiry">Product Enquiry</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:DropDownList ID="ddProductCategory" runat="server" Visible="false" AutoPostBack="true" CssClass="form-control"  style="display: inline-block;" onselectedindexchanged="ddProductCategory_SelectedIndexChanged" Width="200" Height="35"></asp:DropDownList>
                                        <asp:DropDownList ID="ddProductData" runat="server" Visible="false" AutoPostBack="true" CssClass="form-control"  style="display: inline-block;" onselectedindexchanged="ddProductData_SelectedIndexChanged" Width="200" Height="35">
                                            <asp:ListItem Value="">Select Enquiry Type</asp:ListItem>
                                            <asp:ListItem Value="Quick Enquiry">Quick Enquiry</asp:ListItem>
                                            <asp:ListItem Value="Normal Enquiry">Normal Enquiry</asp:ListItem>
                                             <asp:ListItem Value="Product Enquiry">Product Enquiry</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:Button ID="btnDownload" runat="server" Text="Export to excel" CssClass="btn btn-default bt_right_box" OnClick="btnDownload_Click" />
                                    </div>
                                  </div>
                                    <div class="row">
                                        <div class="col-lg-12">
                                            <div class="form-group">
                                <ContentTemplate>
                                    <asp:GridView ID="GvContact" runat="server" AutoGenerateColumns="False" BackColor="#CCCCCC"
                            BorderColor="#999999" BorderStyle="Solid" BorderWidth="2px" CellPadding="0" CellSpacing="2"
                            ForeColor="Black" AllowPaging="True" CaptionAlign="Left" Width="100%" 
                                                    OnPageIndexChanging="GvContact_PageIndexChanging" onrowdatabound="GvContact_RowDataBound"
                            OnRowCommand="GvContact_RowCommand" OnRowDeleting="GvContact_RowDeleting" PageSize="100" >
                            <Columns>
                                <asp:BoundField DataField="sno" HeaderText="S.No.">
                                    <ItemStyle HorizontalAlign="center" />
                                    <HeaderStyle HorizontalAlign="center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="FullName" HeaderText="Name">
                                    <ItemStyle HorizontalAlign="center" CssClass="LeftAlignINMAnagePAge"/>
                                    <HeaderStyle HorizontalAlign="center" CssClass="LeftAlignINMAnagePAge"/>
                                </asp:BoundField>
                                <asp:BoundField DataField="EmailID" HeaderText="Email ID">
                                    <ItemStyle HorizontalAlign="center" CssClass="LeftAlignINMAnagePAge"/>
                                    <HeaderStyle HorizontalAlign="center" CssClass="LeftAlignINMAnagePAge" />
                                </asp:BoundField>
                                <asp:BoundField DataField="PhoneNo" HeaderText="Phone No">
                                    <ItemStyle HorizontalAlign="center" />
                                    <HeaderStyle HorizontalAlign="center" />
                                </asp:BoundField>
                                 <asp:BoundField DataField="Designation" HeaderText="Enquiry for">
                                    <ItemStyle HorizontalAlign="center" />
                                    <HeaderStyle HorizontalAlign="center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="PostedDate" HeaderText="Posted Date">
                                    <ItemStyle HorizontalAlign="center" />
                                    <HeaderStyle HorizontalAlign="center" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Delete">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="IImgbtnDelete" runat="server" CommandArgument='<%#Eval("ContactID")%>'
                                            CommandName="Delete" ImageUrl="images/delete.jpg" OnClientClick="return confirm('Are you sure you want to delete the record?');" />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                            </Columns>
                         <FooterStyle  />
                          <HeaderStyle  />
                          <PagerStyle CssClass="gridview" HorizontalAlign="Left" />
                          <RowStyle  />
                          <SelectedRowStyle  />
                          <SortedAscendingCellStyle  />
                          <SortedAscendingHeaderStyle  />
                        </asp:GridView>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row" style="margin-bottom:10px;">
                                        <div class="col-lg-12">
                                            <asp:Label ID="lblTotalNoOFRow" runat="server"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <uc2:Footer ID="Footer1" runat="server" />
        </div>
    </form>
</body>
</html>
