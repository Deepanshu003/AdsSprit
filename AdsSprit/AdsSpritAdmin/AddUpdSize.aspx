<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddUpdSize.aspx.cs" Inherits="AdsSprit.AdsSpritAdmin.AddUpdSize" %>
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
   <script language="JavaScript" type="text/javascript">
       function pagecheck() {
           if (!req(document.getElementById("txtCategoryName"), "Enter Size"))
               return false;
           if (!chkValue(document.getElementById("DDSizeType"), 0, "Select Size Unit."))
               return false;
           if (!req(document.getElementById("txtDisplayOrder"), "Enter Display Order"))
               return false;
       }

       function pagecheck1() {
           if (!req(document.getElementById("txtCategoryName"), "Enter Size"))
               return false;
           if (!chkValue(document.getElementById("DDSizeType"), 0, "Select Size Unit."))
               return false;
           if (!req(document.getElementById("txtDisplayOrder"), "Enter Display Order"))
               return false;
       }

       function checkIt(evt) {
           evt = (evt) ? evt : window.event
           var charCode = (evt.which) ? evt.which : evt.keyCode
           if (charCode > 31 && (charCode < 48 || charCode > 57) && charCode != 47) {
               status = "This field accepts numbers only."
               return false
           }
           status = ""
           return true
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
                            <h3 class="page-header">Add/Update Size Data </h3>
                        </div>
                    </div>
                    <div class="row" style="margin-bottom:10px;">
                        <div class="col-lg-12">  
                            <a href="/AdsSpritAdmin/package" class="dashCrdBtn bt_right_box">Back</a>
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
                                                <label><span style="color: Red;">*</span> Size<span style="color: Red;">*</span></label>                                                
                                            </div>
                                        </div>                                    
                                        <div class="col-lg-3">
                                            <div class="form-group">                                               
                                                <asp:TextBox ID="txtCategoryName" runat="server" CssClass="form-control" Width="200"></asp:TextBox>
                                            </div>                                           
                                        </div>  
                                        <div class="col-lg-3">
                                            <div class="form-group">                                               
                                                <asp:DropDownList ID="DDSizeType" runat="server" CssClass="form-control" Width="200">
                                                    <asp:ListItem Text="Select Unit" Value="0"></asp:ListItem>
                                                    <asp:ListItem Text="Liter" Value="Liter"></asp:ListItem>
                                                    <asp:ListItem Text="Ml" Value="Ml"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>                                           
                                        </div>                                      
                                        <div class="clearfix"></div>
                                        <div class="col-lg-2">
                                            <div class="form-group">
                                                <label>Display order</label>                                                
                                            </div>
                                        </div>
                                        <div class="col-lg-4">
                                            <div class="form-group">                                               
                                                <asp:TextBox ID="txtDisplayOrder" runat="server"  Width="50" CssClass="form-control" onkeypress="return numeralsOnly(event)" Text="0"></asp:TextBox>
                                            </div>                                           
                                        </div>
                                         <div class="clearfix"></div>
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
                                        <div class="col-lg-3">
                                            <div class="form-group">
                                                <label>&nbsp;</label>                                                
                                            </div>
                                        </div>
                                        <div class="col-lg-3">
                                            <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-default" OnClick="btnSave_Click" />
                                            <asp:Button ID="btnBack" Visible="false" runat="server" Text="Back" CssClass="btn btn-default" OnClick="btnBack_Click" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <uc2:footer ID="Footer1" runat="server" />
        </div>
        <script type="text/javascript">
            function LimtCharacters(txtMsg, CharLength, indicator) {
                chars = txtMsg.value.length;
                document.getElementById(indicator).innerHTML = CharLength - chars;
                if (chars > CharLength) {
                    txtMsg.value = txtMsg.value.substring(0, CharLength);
                }
            }
        </script>
    </form>
</body>
</html>
