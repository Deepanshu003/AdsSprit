<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageSubCategory.aspx.cs" Inherits="AdsSprit.AdsSpritAdmin.ManageSubCategory" %>
<%@ Register Src="Header.ascx" TagName="Header" TagPrefix="uc1" %>
<%@ Register Src="Footer.ascx" TagName="Footer" TagPrefix="uc2" %>
<%@ Register Src="HeaderRight.ascx" TagName="HeaderRight" TagPrefix="uc3" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ADS : Administrator</title>
    <link rel="icon" href="images/adslogo.png" type="image/x-icon" />
    <link href="css/bootstrap.css" rel="stylesheet" />
    <link href="css/font-awesome.css" rel="stylesheet" />
    <link href="css/morris-0.4.3.min.css" rel="stylesheet" />
    <link href="css/custom-styles.css" rel="stylesheet" />
    <link href='http://fonts.googleapis.com/css?family=Open+Sans' rel='stylesheet' type='text/css' />
    <script src="Js/Validation.js" language="javascript" type="text/javascript"></script>
    <script type="text/javascript" language="javascript">
        function numeralsOnly(evt) {
            evt = (evt) ? evt : event;
            var charCode = (evt.charCode) ? evt.charCode : ((evt.keyCode) ? evt.keyCode : ((evt.which) ? evt.which : 0));
            if (charCode > 31 && (charCode < 48 || charCode > 57) && (charCode != 46)) {
                alert("Enter Digit only in this field!");
                return false;
            }
            return true;
        }
    </script>
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
                            <h3 class="page-header">Manage Sub Category </h3>
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
                                        <div class="col-lg-2">
                                            <asp:DropDownList ID="DdCategory" runat="server"  AutoPostBack="true" CssClass="form-control" onselectedindexchanged="DdCategory_SelectedIndexChanged" Width="150" ></asp:DropDownList>
                                        </div>
                                        <div class="col-lg-4">
                                            <asp:TextBox ID="txtSerachData" CssClass="txtSearch" Width="315px" placeholder="Search Category / Sub Category Name" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-lg-1">
                                            <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-default bt_right_box" onclick="btnSearch_Click"/>
                                        </div>
                                        <div class="col-lg-5">
                                            <asp:Button ID="btnAdd" runat="server" Text="+ Create New Sub Category" CssClass="btn btn-default bt_right_box" OnClick="btnAdd_Click" />
                                            <span style="display:none;"><asp:Button ID="btnUpdateOrder" runat="server" Text="Update Display Order" Visible="false" CssClass="btn btn-default bt_right_box" OnClick="btnUpdateOrder_Click" /></span>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-lg-12">
                                            <div class="form-group">
                                                <asp:GridView ID="GvCategory" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" AllowPaging="True" CaptionAlign="Left" Width="100%" OnPageIndexChanging="GvCategory_PageIndexChanging" OnRowCommand="GvCategory_RowCommand" OnRowDeleting="GvCategory_RowDeleting" PageSize="100" ForeColor="Black" GridLines="Both" onsorting="GvCategory_Sorting">
                                                    <AlternatingRowStyle BackColor="White" />
                                                    <Columns>
                                                        <asp:BoundField DataField="sno" HeaderText="S.No.">
                                                            <ItemStyle Width="40px" HorizontalAlign="center" />
                                                            <HeaderStyle Width="40px" HorizontalAlign="center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="SubCategoryName" HeaderText="Sub Category">
                                                            <ItemStyle HorizontalAlign="center" CssClass="LeftAlignINMAnagePAge" Width="200px"/>
                                                            <HeaderStyle HorizontalAlign="center" CssClass="LeftAlignINMAnagePAge" Width="200px"/>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="CategoryName" HeaderText="Category">
                                                            <ItemStyle HorizontalAlign="center" CssClass="LeftAlignINMAnagePAge" Width="200px"/>
                                                            <HeaderStyle HorizontalAlign="center" CssClass="LeftAlignINMAnagePAge" Width="200px"/>
                                                        </asp:BoundField>
                                                        <asp:TemplateField HeaderText="Display Order">
                                                            <ItemTemplate>
                                                                <asp:HiddenField ID="HiddenField1" runat="server" Value='<%#Eval("SubCategoryID") %>' />
                                                                <asp:TextBox ID="txtDisplayOrder" runat="server" Text='<%#Eval("DisplayOrder")%>' Width="50" MaxLength="3" CssClass="inpfield txtDisplayOrder" onkeypress="return numeralsOnly(event)" readonly></asp:TextBox>
                                                            </ItemTemplate>
                                                            <ItemStyle Width="180px" HorizontalAlign="Center" />
                                                            <HeaderStyle Width="180px" HorizontalAlign="Center" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Menu">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblDisplayOnHome" runat="server" CssClass='<%# (Convert.ToInt32(Eval("DisplayOnHome")) == 1) ? "txt_clr_active" : "txt_clr_inactive"  %>' Text='<%# (Convert.ToInt32(Eval("DisplayOnHome")) == 1) ? "Yes" : "No"   %>'></asp:Label>                                        
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" />
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Header">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblDisplayOnHeader" runat="server" CssClass='<%# (Convert.ToInt32(Eval("DisplayOnHeader")) == 1) ? "txt_clr_active" : "txt_clr_inactive"  %>' Text='<%# (Convert.ToInt32(Eval("DisplayOnHeader")) == 1) ? "Yes" : "No"   %>'></asp:Label>                                        
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" />
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </asp:TemplateField> 
                                                        <asp:TemplateField HeaderText="Status">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblCategoryStatus" runat="server" CssClass='<%# (Convert.ToInt32(Eval("ActiveStatus")) == 1) ? "txt_clr_active" : "txt_clr_inactive"  %>' Text='<%# (Convert.ToInt32(Eval("ActiveStatus")) == 1) ? "Active" : "Inactive"   %>'></asp:Label>                                        
                                                            </ItemTemplate>
                                                            <ItemStyle Width="100px" HorizontalAlign="Center" />
                                                            <HeaderStyle Width="100px" HorizontalAlign="Center" />
                                                        </asp:TemplateField>                                
                                                        <asp:TemplateField HeaderText="Edit">
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="ImgbtnEdit" runat="server" CommandArgument='<%#Eval("SubCategoryID")%>' CommandName="Edit" ImageUrl="images/edit.jpg" />
                                                            </ItemTemplate>
                                                            <ItemStyle Width="80px" HorizontalAlign="Center" />
                                                            <HeaderStyle Width="80px" HorizontalAlign="Center" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Delete">
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="IImgbtnDelete" runat="server" CommandArgument='<%#Eval("SubCategoryID")%>' CommandName="Delete" ImageUrl="images/delete.jpg" OnClientClick="return confirm('Are you sure you want to delete the record?');" />
                                                            </ItemTemplate>
                                                            <ItemStyle Width="80px" HorizontalAlign="Center" />
                                                            <HeaderStyle Width="80px" HorizontalAlign="Center" />
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <FooterStyle  />
                                                    <HeaderStyle  />
                                                    <PagerStyle CssClass="gridview" HorizontalAlign="Left" />
                                                    <RowStyle  />
                                                    <SelectedRowStyle  />
                                                    <SortedAscendingCellStyle  />
                                                    <SortedAscendingHeaderStyle  />
                                                    <SortedDescendingCellStyle  />
                                                    <SortedDescendingHeaderStyle  />
                                                </asp:GridView>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row" style="margin-bottom:10px;">
                                        <div class="col-lg-9">
                                            <asp:Label ID="lblTotalNoOFRow" runat="server"></asp:Label>
                                        </div>
                                        <div class="col-lg-3">
                                            <asp:Button ID="btnDownload" runat="server" Text="Export to excel" CssClass="btn btn-default bt_right_box" OnClick="btnDownload_Click" />
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
