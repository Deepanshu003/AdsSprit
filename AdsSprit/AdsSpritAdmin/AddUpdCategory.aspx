﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddUpdCategory.aspx.cs" Inherits="AdsSprit.AdsSpritAdmin.AddUpdCategory" %>
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
           if (!req(document.getElementById("txtCategoryName"), "Enter Category Name"))
               return false;
           if (!req(document.getElementById("txtDisplayOrder"), "Enter Display Order"))
               return false;
       }

       function pagecheck1() {
           if (!req(document.getElementById("txtCategoryName"), "Enter Category Name"))
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
    <script language="JavaScript" type="text/javascript">
        function validateFileUploadS(obj) {
            var fileName = new String();
            var fileExtension = new String();
            fileName = obj.value;
            fileExtension = fileName.substr(fileName.length - 3, 3);
            var validFileExtensions = new Array("Jpg", "jpeg", "png", "gif", "bmp");
            var flag = false;
            var FileExtension1 = fileName.substring(fileName.lastIndexOf('.') + 1).toLowerCase();
            var LengthOfFile = FileExtension1.length;
            if (LengthOfFile > 3) {
                if (FileExtension1 == "jpeg") {
                    flag = true;
                } else {
                    alert('Files with extension ".' + FileExtension1.toUpperCase() + '" are not allowed.\n\nYou can upload the files with following extensions only:\n.Jpg\n.jpeg\n.png\n.gif\n.bmp\n');

                    document.getElementById("ThumbImg1").value = "";

                    return false;
                }
            }
            if (FileExtension1 != "jpeg") {
                for (var index = 0; index < validFileExtensions.length; index++) {
                    if (fileExtension.toLowerCase() == validFileExtensions[index].toString().toLowerCase()) {
                        flag = true;
                    }
                }
            }
            if (flag == false) {
                alert('Files with extension ".' + fileExtension.toUpperCase() + '" are not allowed.\n\nYou can upload the files with following extensions only:\n.Jpg\n.jpeg\n.png\n.gif\n.bmp\n');

                document.getElementById("ThumbImg1").value = "";

                return false;
            } else {
                return true;
            }
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
                            <h3 class="page-header">Add/Update Category Data </h3>
                        </div>
                    </div>
                    <div class="row" style="margin-bottom:10px;">
                        <div class="col-lg-12">  
                            <a href="/AdsSpritAdmin/category" class="dashCrdBtn bt_right_box">Back</a>
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
                                        <div class="col-lg-3">
                                            <div class="form-group">
                                                <label><span style="color: Blue;">*</span>&nbsp;Category Name</label>                                                
                                            </div>
                                        </div>                                    
                                        <div class="col-lg-4">
                                            <div class="form-group">                                               
                                                <asp:TextBox ID="txtCategoryName" runat="server" CssClass="form-control" AutoPostBack="true" ontextchanged="txtCategoryName_TextChanged" Width="400" ></asp:TextBox>
                                            </div>                                           
                                        </div>                                       
                                        <div class="clearfix"></div>
                                        <div class="col-lg-3">
                                            <div class="form-group">
                                                <label><span style="color: Blue;">*</span>&nbsp;Category Name URl</label>
                                            </div>
                                        </div>
                                        <div class="col-lg-4">
                                            <div class="form-group">
                                                <asp:TextBox ID="txtTitleURL" runat="server" CssClass="form-control" Width="400"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="clearfix"></div>
                                        <div class="col-lg-3">
                                            <div class="form-group">
                                                <label><span style="color: Blue;">*</span>&nbsp;Home Category Image</label>                                                         
                                            </div>
                                        </div>
                                        <div class="col-lg-4">
                                            <div class="form-group">     
                                            <input id="txtCategoryImage" type="file" runat="server" /><span style="font-size:11px;">Category Image Size <b style="color:blue;">(1366 X 650)px</b></span><br />
                                            </div>                                           
                                        </div>
                                        <div class="col-lg-4" id="trImageTArea" runat="server" >
                                            <div class="form-group">     
                                                <asp:Image ID="CategoryImageThumb" runat="server" Width="150" Height="80" Visible="false" />
                                            </div>                                           
                                        </div>   
                                        <div class="clearfix"></div>
                                            <div class="col-lg-3">
                                            <div class="form-group">
                                                <label><span style="color: Blue;">*</span>&nbsp; Description Home Image </label>
                                            </div>
                                            </div>
                                           <div class="col-lg-4">
                                               <div class="form-group">
                                                   <asp:TextBox ID="txtCategorySmallDesc" runat="server" CssClass="form-control" TextMode="MultiLine" Height="40" Width="550"></asp:TextBox>
                                               </div>
                                           </div> 
                                        <div class="clearfix"></div>
                                        <%--<div style="display:none;">--%>
                                        <div class="col-lg-3">
                                            <div class="form-group">
                                                <label>&nbsp;Video URl</label>
                                            </div>
                                        </div>
                                        <div class="col-lg-4">
                                            <div class="form-group">
                                                <asp:TextBox ID="txtFacebookURl" runat="server" CssClass="form-control" Width="400"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="clearfix"></div>                                         
                                            <div class="col-lg-3">
                                                <div class="form-group">
                                                    <label><span style="color: blue;">*</span>&nbsp;Footer Image</label>
                                                </div>
                                            </div>
                                            <div class="col-lg-4">
                                                <div class="form-group">
                                                    <input id="LargImg2" type="file" runat="server" /><span style="font-size:11px;"><b style="color:blue;">(Image Size 1366px X 622px)</b></span>
                                                </div>
                                            </div>
                                            <div class="col-lg-4" id="trImageLArea1" runat="server">
                                                <div class="form-group">
                                                    <asp:Image ID="Image1" Visible="false" runat="server" Width="150" Height="80" />
                                                </div>
                                            </div>
                                         <div class="clearfix"></div>
                                        <div class="col-lg-3">
                                            <div class="form-group">
                                                <label><span style="color: Blue;">*</span>&nbsp;Description of footer</label>
                                            </div>
                                        </div>
                                        <div class="col-lg-4">
                                            <div class="form-group">
                                                <asp:TextBox ID="txtdesc" runat="server" CssClass="form-control" Width="500"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="clearfix"></div>
                                       <%-- </div>--%>                                                                                                                                                                 
                                            <div class="clearfix"></div>                                         
                                            <div class="col-lg-3">
                                                <div class="form-group">
                                                    <label><span style="color: blue;">*</span>&nbsp;Category Image</label>
                                                </div>
                                            </div>
                                            <div class="col-lg-4">
                                                <div class="form-group">
                                                    <input id="LargeImg1" type="file" runat="server" /><span style="font-size:11px;"><b style="color:blue;">(Image Size 625px X 376px)</b></span>
                                                </div>
                                            </div>
                                            <div class="col-lg-4" id="trImageLArea" runat="server">
                                                <div class="form-group">
                                                    <asp:Image ID="Image2" Visible="false" runat="server" Width="150" Height="80" />
                                                </div>
                                            </div>
                                            <div class="clearfix"></div>
                                            <div class="col-lg-3">
                                            <div class="form-group">
                                                <label><span style="color: Blue;">*</span>&nbsp;Category Description </label>
                                            </div>
                                            </div>
                                           <div class="col-lg-4">
                                               <div class="form-group">
                                                   <asp:TextBox ID="txtsmalldescription" runat="server" CssClass="form-control" TextMode="MultiLine" Height="40" Width="550"></asp:TextBox>
                                               </div>
                                           </div> 
                                            
                                            <div class="clearfix"></div>

                                            <div class="col-lg-3">
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
                                            <div class="col-lg-3">
                                                <div class="form-group">
                                                    <label><span style="color: blue;">*</span>&nbsp;Status(Active/Inactive)</label>                                                
                                                </div>
                                            </div>
                                            <div class="col-lg-1">
                                                <div class="form-group">                                               
                                                    <asp:CheckBox ID="chkStatus" runat="server" />
                                                </div>                                           
                                            </div>
                                            <div class="col-lg-3">
                                                <div class="form-group">
                                                    <label>Display On Home Image</label>                                                
                                                </div>
                                            </div>
                                            <div class="col-lg-1">
                                                <div class="form-group">                                               
                                                    <asp:CheckBox ID="chkDisplayOnMenu" runat="server" />
                                                </div>                                           
                                            </div>
                                            <div class="col-lg-3">
                                                <div class="form-group">
                                                    <label>Display On Footer</label>                                                
                                                </div>
                                            </div>
                                            <div class="col-lg-1">
                                                <div class="form-group">                                               
                                                    <asp:CheckBox ID="chkDisplayOnHeader" runat="server" />
                                                </div>                                           
                                            </div>
                                          <div class="col-lg-3">
                                                <div class="form-group">
                                                    <label>Display On Category</label>                                                
                                                </div>
                                            </div>
                                            <div class="col-lg-1">
                                                <div class="form-group">                                               
                                                    <asp:CheckBox ID="chkcategory" runat="server" />
                                                </div>                                           
                                            </div>
                                            <div class="clearfix"></div>
                                            <div>
                                            <div class="col-lg-12" style="text-align:center;">
                                            <div class="form-group">
                                                <hr style="border: 1px solid #828386;"/><b>Only for Seo Purpose (Meta Title, Meta Keywords and Meta Descriptions)</b><hr style="border: 1px solid #828386;"/>
                                            </div>
                                        </div>
                                            <div class="clearfix"></div>
                                        <div class="col-lg-3">
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
                                        <div class="col-lg-3">
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
                                        <div class="col-lg-3" >
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
                                        <div class="col-lg-3">
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
