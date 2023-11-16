<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="AdsSprit.AdsSpritAdmin.ChangePassword" %>
<%@ Register Src="Header.ascx" TagName="Header" TagPrefix="uc1" %>
<%@ Register Src="Footer.ascx" TagName="Footer" TagPrefix="uc2" %>
<%@ Register Src="HeaderRight.ascx" TagName="HeaderRight" TagPrefix="uc3" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <title>ADS : Administrator</title>
    <link rel="icon" href="images/favicon.png" type="image/x-icon" />
    <link href="css/bootstrap.css" rel="stylesheet" />
    <link href="css/font-awesome.css" rel="stylesheet" />
    <link href="css/morris-0.4.3.min.css" rel="stylesheet" />
    <link href="css/custom-styles.css" rel="stylesheet" />
    <link href='http://fonts.googleapis.com/css?family=Open+Sans' rel='stylesheet' type='text/css' />
    <script src="Js/Validation.js" language="javascript" type="text/javascript"></script>
    <script language="JavaScript">
        function pagecheck() {
            if (!req(document.getElementById("txtOldPassword"), "Enter Old Password"))
                return false
            if (!req(document.getElementById("txtNewPassword"), "Enter New Password"))
                return false
            if (!req(document.getElementById("txtConfirmPassword"), "Enter Confirm Password"))
                return false
            if (!chkPassMatch(document.getElementById("txtNewPassword"), document.getElementById("txtConfirmPassword"), "Password Mismatch"))
                return false
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
                        <h3 class="page-header">Change Password </h3>
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
                                <div class="row">                                
                                    <div role="form">
                                        <div class="col-lg-2">
                                            <div class="form-group">
                                                <label><span style="color: Red;">*</span>&nbsp;Old Password</label>                                                
                                            </div>
                                        </div>                                    
                                        <div class="col-lg-4">
                                            <div class="form-group"> 
                                                <asp:TextBox ID="txtOldPassword" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                                            </div>                                           
                                        </div>
                                        <div class="clearfix"></div>
                                        <div class="col-lg-2">
                                            <div class="form-group">
                                                <label><span style="color: Red;">*</span>&nbsp;New Password</label>                                                
                                            </div>
                                        </div>
                                        <div class="col-lg-4">
                                            <div class="form-group">     
                                                <asp:TextBox ID="txtNewPassword" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                                            </div>                                           
                                        </div>
                                        <div class="clearfix"></div>
                                        <div class="col-lg-2">
                                            <div class="form-group">
                                                <label><span style="color: Red;">*</span>&nbsp;Confirm password</label>                                                
                                            </div>
                                        </div>
                                        <div class="col-lg-4">
                                            <div class="form-group">     
                                                <asp:TextBox ID="txtConfirmPassword" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                                            </div>                                           
                                        </div>
                                        <div class="clearfix"></div>
                                        <div class="col-lg-2">
                                            <div class="form-group">
                                                <label>&nbsp;</label>                                                
                                            </div>
                                        </div>
                                        <div class="col-lg-4">
                                            <asp:Button ID="btnSave" runat="server" Text="Update" CssClass="btn btn-default" Onclick="btnSave_Click" />
                                            <input id="Reset1" type="reset" value="Reset" class="btn btn-default" />
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
    </form>
</body>
</html>
