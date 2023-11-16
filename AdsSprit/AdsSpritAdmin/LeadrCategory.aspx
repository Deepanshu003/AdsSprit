<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LeadrCategory.aspx.cs" Inherits="AdsSprit.AdsSpritAdmin.LeadrCategory" %>
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
    <script language="JavaScript" type="text/javascript">
        function pagecheck() {
            if (!req(document.getElementById("txtBlogCategory"), "Enter Blog Category Title"))
                return false;
        }
    </script>
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
                            <h3 class="page-header">Add/Update LeaderShip Category </h3>
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
                                             <a href="/AdsSpritAdmin/manage-Leader-events" class="dashCrdBtn bt_right_box">View Leader Category</a>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div role="form">
                                            <div class="col-lg-3">
                                                <div class="form-group">
                                                    <label><span style="color: Red;">*</span>&nbsp;Leader Name</label>
                                                </div>
                                            </div>
                                            <div class="col-lg-4">
                                                <div class="form-group">
                                                    <asp:TextBox ID="txtLeaderCategory" runat="server" CssClass="form-control" AutoPostBack="true" ontextChanged="txtLeaderCategory_TextChanged" Width="650"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="clearfix"></div>
                                            <div class="col-lg-3" style="display:none;">
                                                <div class="form-group">
                                                    <label><span style="display:none;">*</span>&nbsp;Leader Role</label>
                                                </div>
                                            </div>
                                             <div class="col-lg-4" style="display:none;">
                                                <div class="form-group">
                                                     <asp:TextBox ID="txtLeaderRole" runat="server" CssClass="form-control" Width="650" ></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="clearfix"></div>
                                            <div class="col-lg-3">
                                                <div class="form-group">
                                                    <label><span style="color: Red;">*</span>&nbsp;Leader Name URl</label>
                                                </div>
                                            </div>
                                            <div class="col-lg-4">
                                                <div class="form-group">
                                                     <asp:TextBox ID="txtLeaderURL" runat="server" CssClass="form-control" Width="650" ></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="clearfix"></div>
                                             <div class="col-lg-3">
                                        <div class="form-group">
                                            <label><span style="color: Red;">*</span>&nbsp;Small Description </label>
                                        </div>
                                    </div>
                                    <div class="col-lg-4">
                                        <div class="form-group">
                                            <asp:TextBox ID="txtBlogSmallDesc" runat="server" CssClass="form-control" TextMode="MultiLine" Height="100" Width="650"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="clearfix"></div>
                                              <div class="col-lg-3">
                                                <div class="form-group">
                                                    <label><span style="color: Red;">*</span>&nbsp;Display order</label>
                                                </div>
                                            </div>
                                          <%--  <div class="clearfix"></div>--%>
                                            <div class="col-lg-2">
                                                <div class="form-group">
                                                    <label>Status(Active/Inactive)</label>
                                                </div>
                                            </div>
                                            <div class="col-lg-4">
                                                <div class="form-group">
                                                    <asp:CheckBox ID="chkStatus" runat="server" />
                                                </div>
                                            </div>
                                            <div class="clearfix"></div>
                                            <div style="display:none;">
                                        <div class="col-lg-12" style="text-align:center;">
                                            <div class="form-group">
                                                <hr style="border: 1px solid #828386;"/><b>Only for Seo Purpose (Meta Title, Meta Keywords and Meta Descriptions)</b><hr style="border: 1px solid #828386;"/>
                                            </div>
                                        </div>
                                        <div class="clearfix"></div>
                                    <div class="col-lg-2">
                                        <div class="form-group">
                                            <label>&nbsp;Meta Title</label>
                                        </div>
                                    </div>
                                    <div class="col-lg-4">
                                        <div class="form-group">
                                            <asp:TextBox ID="txtMetaTitle" runat="server" CssClass="form-control" Width="650"></asp:TextBox>
                                        </div>
                                    </div>
                                            <div class="clearfix"></div>
                                    <div class="col-lg-2">
                                        <div class="form-group">
                                            <label>&nbsp;Meta Keywords</label>
                                        </div>
                                    </div>
                                    <div class="col-lg-4">
                                        <div class="form-group">
                                            <asp:TextBox ID="txtMetaKeywords" runat="server" CssClass="form-control" Width="650"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="clearfix"></div>
                                    <div class="col-lg-2">
                                        <div class="form-group">
                                            <label>&nbsp;Meta Descriptions</label>
                                        </div>
                                    </div>
                                    <div class="col-lg-4">
                                        <div class="form-group">
                                            <asp:TextBox ID="txtMetaDescriptions" runat="server" CssClass="form-control" Width="650" Height="100" TextMode="MultiLine"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="clearfix"></div>
                                    <div class="col-lg-2">
                                        <div class="form-group">
                                            <label>&nbsp;Meta Schema</label>
                                        </div>
                                    </div>
                                    <div class="col-lg-4">
                                        <div class="form-group">
                                            <asp:TextBox ID="txtMetaSchema" runat="server" CssClass="form-control" Width="650" Height="100" TextMode="MultiLine"></asp:TextBox>
                                        </div>
                                    </div>
                                            <div class="clearfix"></div>    
                                            </div>                                        
                                            <div style="display:none;">
                                            <div class="col-lg-2">
                                                <div class="form-group">
                                                    <label>Display On home(Active/Inactive)</label>
                                                </div>
                                            </div>
                                            <div class="col-lg-4">
                                                <div class="form-group">
                                                    <asp:CheckBox ID="chkDisplay" runat="server" />
                                                </div>
                                            </div>
                                            <div class="clearfix"></div>
                                            </div>
                                            <div class="col-lg-2">
                                                <div class="form-group">
                                                    <label>&nbsp;</label>
                                                </div>
                                            </div>
                                            <div class="col-lg-4">
                                                <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-default" onclick="btnSave_Click" />
                                                <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="btn btn-default" onclick="btnBack_Click" />
                                            </div>
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
