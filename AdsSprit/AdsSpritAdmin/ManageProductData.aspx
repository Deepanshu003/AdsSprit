<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageProductData.aspx.cs" Inherits="AdsSprit.AdsSpritAdmin.ManageProductData" %>
<%@ Register Src="Header.ascx" TagName="Header" TagPrefix="uc1" %>
<%@ Register Src="Footer.ascx" TagName="Footer" TagPrefix="uc2" %>
<%@ Register Src="HeaderRight.ascx" TagName="HeaderRight" TagPrefix="uc3" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ADS </title>
     <link rel="icon" href="images/adslogo.png" type="image/x-icon" />
    <link href="css/bootstrap.css" rel="stylesheet" />
    <link href="css/font-awesome.css" rel="stylesheet" />
    <link href="css/morris-0.4.3.min.css" rel="stylesheet" />
    <link href="css/custom-styles.css" rel="stylesheet" />
    <link href='http://fonts.googleapis.com/css?family=Open+Sans' rel='stylesheet' type='text/css' />
    <style>
        .artimsleftal{text-align:left;}
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
                            <h3 class="page-header">Manage Product Data </h3>
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
                                    <div class="row"   style="display: none;">
                                        <div class="col-lg-12">                                           
                                             <a href="/AdsSpritAdmin/category" class="dashCrdBtn bt_right_box">View Category</a>
                                        </div>
                                    </div>
                                    <div class="row"  style="display: none;"
                                        <div class="col-lg-3">
                                            <asp:DropDownList ID="DdCategory" runat="server" CssClass="form-control" Width="176" AutoPostBack="true" OnSelectedIndexChanged="DdCategory_SelectedIndexChanged"></asp:DropDownList>
                                        </div>
                                        <div class="col-lg-6">
                                            <asp:TextBox ID="txtSerachData" CssClass="txtSearch" Width="200px" placeholder="Search Product Name" runat="server"></asp:TextBox>
                                            <asp:Button ID="btnSearch" runat="server" Text="Search" style="margin-right:154px; padding-right:0px;" Width="100"  CssClass="btn btn-default bt_right_box" OnClick="btnSearch_Click"/>
                                        </div>
                                        <div class="col-lg-3">
                                            <asp:Button ID="btnAdd" runat="server" Text="+ Create New Product" CssClass="btn btn-default bt_right_box" OnClick="btnAdd_Click" /> 
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-lg-12">
                                            <div class="form-group">
                                                <asp:GridView ID="GvServiceData" runat="server" AutoGenerateColumns="False" AllowPaging="True" CaptionAlign="Left" Width="100%" OnPageIndexchanging="GvServiceData_PageIndexChanging" OnRowCommand="GvServiceData_RowCommand" OnRowDeleting="GvServiceData_RowDeleting" PageSize="100" AllowSorting="True" OnSorting="GvServiceData_Sorting">
                                                    <Columns>
                                                        <asp:BoundField DataField="sno" HeaderText="S.No.">
                                                            <ItemStyle Width="20px" HorizontalAlign="center" />
                                                            <HeaderStyle Width="20px" HorizontalAlign="center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="ProductName" HeaderText="Product Name" SortExpression="ProductName">
                                                            <ItemStyle HorizontalAlign="center"  CssClass="LeftAlignINMAnagePAge"/>
                                                            <HeaderStyle HorizontalAlign="center" CssClass="LeftAlignINMAnagePAge"/>
                                                        </asp:BoundField>
                                                        <asp:TemplateField HeaderText="Image" SortExpression="SmallImg">
                                                            <ItemTemplate>
                                                                <img width="70" alt="ADS-SPIRITS-IMAGE" src="../AdsSpritImages/ProductImages/<%#Eval("ProductDefaultImage")%>" />
                                                            </ItemTemplate>
                                                            <ItemStyle  HorizontalAlign="Center" />
                                                            <HeaderStyle  HorizontalAlign="Center" />
                                                        </asp:TemplateField>                                                    
                                                        <asp:TemplateField HeaderText="Status" SortExpression="ActiveStatus">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblCategoryStatus" runat="server" CssClass='<%# (Convert.ToInt32(Eval("ActiveStatus")) == 1) ? "txt_clr_active" : "txt_clr_inactive"  %>' Text='<%# (Convert.ToInt32(Eval("ActiveStatus")) == 1) ? "Active" : "Inactive"   %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" />
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Display On Banner">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblDisplayOnCategory" runat="server" CssClass='<%# (Convert.ToInt32(Eval("DisplayOnHome")) == 1) ? "txt_clr_active" : "txt_clr_inactive"  %>' Text='<%# (Convert.ToInt32(Eval("DisplayOnHome")) == 1) ? "Yes" : "No"   %>'></asp:Label>                                        
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" />
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Edit">
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="ImgbtnEdit" runat="server" CommandArgument='<%#Eval("ProductID")%>' CommandName="Edit" ImageUrl="images/edit.jpg" />
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" />
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Delete">
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="IImgbtnDelete" runat="server" CommandArgument='<%#Eval("ProductID")%>' CommandName="Delete" ImageUrl="images/delete.jpg" OnClientClick="return confirm('Are you sure you want to delete the record?');" />
                                                            </ItemTemplate>
                                                            <ItemStyle Width="40px" HorizontalAlign="Center" />
                                                            <HeaderStyle Width="40px" HorizontalAlign="Center" />
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <FooterStyle Width="100px" />
                                                    <HeaderStyle />
                                                    <PagerStyle HorizontalAlign="Left" />
                                                    <RowStyle />
                                                    <SelectedRowStyle />
                                                    <SortedAscendingCellStyle />
                                                    <SortedAscendingHeaderStyle />
                                                    <SortedDescendingCellStyle />
                                                    <SortedDescendingHeaderStyle />
                                                </asp:GridView>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row" style="margin-bottom:10px;">
                                    <div class="col-lg-12">
                                        <asp:Label ID="lblTotalNoOFStore" runat="server"></asp:Label>
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
