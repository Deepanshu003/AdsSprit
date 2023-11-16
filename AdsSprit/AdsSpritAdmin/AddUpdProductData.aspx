<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddUpdProductData.aspx.cs" Inherits="AdsSprit.AdsSpritAdmin.AddUpdProductData" %>
<%@ Register Src="Header.ascx" TagName="Header" TagPrefix="uc1" %>
<%@ Register Src="Footer.ascx" TagName="Footer" TagPrefix="uc2" %>
<%@ Register Src="HeaderRight.ascx" TagName="HeaderRight" TagPrefix="uc3"%>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head id="Head1" runat="server">
    <title>ADS</title>
    <link rel="icon" href="images/adslogo.png" type="image/x-icon" />
    <link href="css/bootstrap.css" rel="stylesheet" />
    <link href="css/font-awesome.css" rel="stylesheet" />
    <link href="css/morris-0.4.3.min.css" rel="stylesheet" />
    <link href="css/custom-styles.css" rel="stylesheet" />
    <link href='http://fonts.googleapis.com/css?family=Open+Sans' rel='stylesheet' type='text/css' />
    <script language="JavaScript" type="text/javascript" src="Js/wysiwyg.js"></script>
    <script src="Js/Validation.js" type="text/javascript" language="javascript"></script>
    <script language="JavaScript" type="text/javascript">
        function pagecheck() {
            if (!chkValue(document.getElementById("DdCategory"), 0, "Select Default Category"))
                return false;
            if (!req(document.getElementById("txtProductName"), "Enter Product Name"))
                return false;
            if (!req(document.getElementById("txtProductDefaultImage"), "Upload Default Image"))
                return false;

        }

        function pagecheck1() {
            if (!chkValue(document.getElementById("DdCategory"), 0, "Select Default Category"))
                return false;
            if (!chkValue(document.getElementById("DDSubCategory"), 0, "Select Default Sub Category"))
                return false;
            if (!req(document.getElementById("txtProductName"), "Enter Product Name"))
                return false;
        }

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
    <script language="JavaScript" type="text/javascript">
        function validateFileUploadDefault(obj) {
            var fileName = new String();
            var fileExtension = new String();                // store the file name into the variable        
            fileName = obj.value;                // extract and store the file extension into another variable        
            fileExtension = fileName.substr(fileName.length - 3, 3);                // array of allowed file type extensions        
            var validFileExtensions = new Array("Jpg", "jpeg", "png", "gif", "bmp");
            var flag = false;                // loop over the valid file extensions to compare them with uploaded file        
            var FileExtension1 = fileName.substring(fileName.lastIndexOf('.') + 1).toLowerCase();
            var LengthOfFile = FileExtension1.length;
            if (LengthOfFile > 3) {
                if (FileExtension1 == "jpeg") {
                    flag = true;
                }
                else {
                    alert('Files with extension ".' + FileExtension1.toUpperCase() + '" are not allowed.\n\nYou can upload the files with following extensions only:\n.Jpg\n.jpeg\n.png\n.gif\n.bmp\n');
                    //document.getElementById("File1").value = "";
                    document.getElementById("txtProductDefaultImage").value = "";

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

            var uploadedFile = document.getElementById('txtProductDefaultImage');
            var fileSize = uploadedFile.files[0].size;
            if (fileSize > 20480000000)
                flagsize = false;
            else
                flagsize = true;

            if (flag == false) {
                alert('Files with extension ".' + fileExtension.toUpperCase() + '" are not allowed.\n\nYou can upload the files with following extensions only:\n.Jpg\n.jpeg\n.png\n.gif\n.bmp\n');
                document.getElementById("txtProductDefaultImage").value = "";
                return false;
            }
            else if (flagsize == false) {
                fileSize = parseInt(fileSize / 1024);
                fileSize = parseInt(fileSize / 1024);
                alert('Uploaded photo size is more than ' + fileSize + 'MB.\n\nPlease upload less than 2000KB photo size.\n');
                document.getElementById("txtProductDefaultImage").value = "";
                return false;
            }
            else {
                return true;
            }
        }
    </script>
    <script language="JavaScript" type="text/javascript">
        function validateFileUploadImage1(obj) {
            var fileName = new String();
            var fileExtension = new String();                // store the file name into the variable        
            fileName = obj.value;                // extract and store the file extension into another variable        
            fileExtension = fileName.substr(fileName.length - 3, 3);                // array of allowed file type extensions        
            var validFileExtensions = new Array("Jpg", "jpeg", "png", "gif", "bmp");
            var flag = false;                // loop over the valid file extensions to compare them with uploaded file        
            var FileExtension1 = fileName.substring(fileName.lastIndexOf('.') + 1).toLowerCase();
            var LengthOfFile = FileExtension1.length;
            if (LengthOfFile > 3) {
                if (FileExtension1 == "jpeg") {
                    flag = true;
                }
                else {
                    alert('Files with extension ".' + FileExtension1.toUpperCase() + '" are not allowed.\n\nYou can upload the files with following extensions only:\n.Jpg\n.jpeg\n.png\n.gif\n.bmp\n');
                    //document.getElementById("File1").value = "";
                    document.getElementById("txtProductImage1").value = "";

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

            var uploadedFile = document.getElementById('txtProductImage1');
            var fileSize = uploadedFile.files[0].size;
            if (fileSize > 204800000)
                flagsize = false;
            else
                flagsize = true;

            if (flag == false) {
                alert('Files with extension ".' + fileExtension.toUpperCase() + '" are not allowed.\n\nYou can upload the files with following extensions only:\n.Jpg\n.jpeg\n.png\n.gif\n.bmp\n');
                document.getElementById("txtProductImage1").value = "";
                return false;
            }
            else if (flagsize == false) {
                fileSize = parseInt(fileSize / 1024);
                fileSize = parseInt(fileSize / 1024);
                alert('Uploaded photo size is more than ' + fileSize + 'MB.\n\nPlease upload less than 2000KB photo size.\n');
                document.getElementById("txtProductImage1").value = "";
                return false;
            }
            else {
                return true;
            }
        }
    </script>
    <script language="JavaScript" type="text/javascript">
        function validateFileUploadImage2(obj) {
            var fileName = new String();
            var fileExtension = new String();                // store the file name into the variable        
            fileName = obj.value;                // extract and store the file extension into another variable        
            fileExtension = fileName.substr(fileName.length - 3, 3);                // array of allowed file type extensions        
            var validFileExtensions = new Array("Jpg", "jpeg", "png", "gif", "bmp");
            var flag = false;                // loop over the valid file extensions to compare them with uploaded file        
            var FileExtension1 = fileName.substring(fileName.lastIndexOf('.') + 1).toLowerCase();
            var LengthOfFile = FileExtension1.length;
            if (LengthOfFile > 3) {
                if (FileExtension1 == "jpeg") {
                    flag = true;
                }
                else {
                    alert('Files with extension ".' + FileExtension1.toUpperCase() + '" are not allowed.\n\nYou can upload the files with following extensions only:\n.Jpg\n.jpeg\n.png\n.gif\n.bmp\n');
                    //document.getElementById("File1").value = "";
                    document.getElementById("txtProductImage2").value = "";

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

            var uploadedFile = document.getElementById('txtProductImage2');
            var fileSize = uploadedFile.files[0].size;
            if (fileSize > 204800000)
                flagsize = false;
            else
                flagsize = true;

            if (flag == false) {
                alert('Files with extension ".' + fileExtension.toUpperCase() + '" are not allowed.\n\nYou can upload the files with following extensions only:\n.Jpg\n.jpeg\n.png\n.gif\n.bmp\n');
                document.getElementById("txtProductImage2").value = "";
                return false;
            }
            else if (flagsize == false) {
                fileSize = parseInt(fileSize / 1024);
                fileSize = parseInt(fileSize / 1024);
                alert('Uploaded photo size is more than ' + fileSize + 'MB.\n\nPlease upload less than 2000KB photo size.\n');
                document.getElementById("txtProductImage2").value = "";
                return false;
            }
            else {
                return true;
            }
        }
    </script>
    <script language="JavaScript" type="text/javascript">
        function validateFileUploadImage3(obj) {
            var fileName = new String();
            var fileExtension = new String();                // store the file name into the variable        
            fileName = obj.value;                // extract and store the file extension into another variable        
            fileExtension = fileName.substr(fileName.length - 3, 3);                // array of allowed file type extensions        
            var validFileExtensions = new Array("Jpg", "jpeg", "png", "gif", "bmp");
            var flag = false;                // loop over the valid file extensions to compare them with uploaded file        
            var FileExtension1 = fileName.substring(fileName.lastIndexOf('.') + 1).toLowerCase();
            var LengthOfFile = FileExtension1.length;
            if (LengthOfFile > 3) {
                if (FileExtension1 == "jpeg") {
                    flag = true;
                }
                else {
                    alert('Files with extension ".' + FileExtension1.toUpperCase() + '" are not allowed.\n\nYou can upload the files with following extensions only:\n.Jpg\n.jpeg\n.png\n.gif\n.bmp\n');
                    //document.getElementById("File1").value = "";
                    document.getElementById("File1").value = "";

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

            var uploadedFile = document.getElementById('File1');
            var fileSize = uploadedFile.files[0].size;
            if (fileSize > 204800000)
                flagsize = false;
            else
                flagsize = true;

            if (flag == false) {
                alert('Files with extension ".' + fileExtension.toUpperCase() + '" are not allowed.\n\nYou can upload the files with following extensions only:\n.Jpg\n.jpeg\n.png\n.gif\n.bmp\n');
                document.getElementById("File1").value = "";
                return false;
            }
            else if (flagsize == false) {
                fileSize = parseInt(fileSize / 1024);
                fileSize = parseInt(fileSize / 1024);
                alert('Uploaded photo size is more than ' + fileSize + 'MB.\n\nPlease upload less than 2000KB photo size.\n');
                document.getElementById("File1").value = "";
                return false;
            }
            else {
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
    <style>
    
    .Add_upDte {
    display: flex;
    float: left;
    width: 100%;
    position: relative;
    flex-wrap: wrap;
}

.Col_ud_4 {
    float: left;
    width: 22%;
    display: flex;
    position: relative;
    margin-bottom: 35px;
    max-height: 190px;
    justify-content: space-between;
}

.Col_ud_4 img {
    width: 100%;
    height:100%;
    object-fit: contain;
}

.Col_ud_4 a 
{
    position: absolute;
    right: 12px;
    font-size: 25px;
    color: #191818;
    background: #fff;
    padding: 7px;
    line-height: 15px;
 
   }
   .popnew
   {
     display: flex;
    flex-wrap: wrap;
    width: 100%;
    position: relative;
    margin-bottom: 10px;}
   .popshow
   {
       display: flex;
    flex-wrap: wrap;
    width: 100%;
    position: relative;
    margin-bottom: 10px;}
       .asdcv
       {
           border-left: 1px solid #cccccc;
           border-right: 1px solid #cccccc;
           border-bottom: 1px solid #cccccc;
            padding-bottom: 0px;
           }
           .CSSS
           {
               float: left;
    width: 100%;
    position: relative;
    display: block;}
    .FontStgfr
    {
        font-size:12px;
        vertical-align: middle;
    }
    .FontStgfr input { vertical-align: middle;
    margin: 0px;}
    .FontStgfr label{ margin :0 5px;}
    .ometgvshgd
    {
        border: 1px solid #ffffff;
    background: #780000;
    margin-bottom: 0px;
    padding: 0px;
    height: 24px;
    padding-left: 3px;
    text-transform: uppercase;
    font-weight: bold;
    color: #ffffff;
    }
    .form-group.siz_chk.slctAll img {
    display: block;
}
    .part_comm .form-group { margin:5px 0px; }
    .popshow input{ height:23px; font-size:13px; padding:5px;}
    .popnew input{ height:23px; font-size:13px; padding:5px;}
    </style>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/2.2.0/jquery.min.js" language="javascript" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div id="wrapper">
            <uc1:Header ID="Header1" runat="server" />
            <div id="page-wrapper">
             <uc3:HeaderRight ID="HeaderRight1" runat="server" />
                <div id="page-inner">
                    <div class="row">
                        <div class="col-md-12">
                            <h3 class="page-header">Add/Update Product</h3>
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
                                            <a href="/AdsSpritAdmin/product-data" class="dashCrdBtn bt_right_box">Back</a>
                                        </div>
                                    </div>
                                    <div class="row">   
                                    <div role="form">
                                    <ul class="nav nav-tabs  m_ul_tab_st">
                                        <li class="active"><a data-toggle="tab" href="#ProductData">Product Data</a></li>
                                        <li><a data-toggle="tab" href="#SEoData">SEO</a></li>
                                    </ul>
                                    <div class="tab-content m_tabbed_cntnt">                             
                                    <div id="ProductData" class="tab-pane fade in active">
                                        <div class="col-lg-2">
                                            <div class="form-group">
                                               <label><span style="color: Blue;">*</span>&nbsp; Select Category</label>                                              
                                            </div>
                                        </div>
                                        <div class="col-lg-4">
                                            <div class="form-group">     
                                                <asp:DropDownList ID="DdCategory" runat="server"  CssClass="form-control" AutoPostBack="true" onselectedindexchanged="DdCategory_SelectedIndexChanged"></asp:DropDownList>                         
                                            </div>                                           
                                        </div>
                                        <div class="clearfix"></div>
                                        <div class="col-lg-2">
                                            <div class="form-group">
                                                <label><span style="color: Blue;">*</span>&nbsp;Product Title</label>                                                
                                            </div>
                                        </div>                                    
                                        <div class="col-lg-4">
                                            <div class="form-group"> 
                                                <asp:TextBox ID="txtProductName" runat="server" CssClass="form-control" AutoPostBack="true" ontextchanged="txtProductName_TextChanged"></asp:TextBox>
                                            </div>                                           
                                        </div>
                                        <%--<div class="clearfix"></div>--%>
                                        <div class="col-lg-2">
                                            <div class="form-group">
                                                <label><span style="color: Blue;">*</span>&nbsp;Product Title URl</label>
                                            </div>
                                        </div>
                                        <div class="col-lg-4">
                                            <div class="form-group">
                                                <asp:TextBox ID="txtTitleURL" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div id="PnlProductCode" runat="server" visible="false">
                                            <div class="clearfix"></div>
                                            <div class="col-lg-2">
                                                <div class="form-group">
                                                    <label>&nbsp;Product Code</label>                                                
                                                </div>
                                            </div>                                    
                                            <div class="col-lg-4">
                                                <div class="form-group"> 
                                                    <asp:TextBox ID="txtProductCode" runat="server" CssClass="form-control"></asp:TextBox>
                                                </div>                                           
                                            </div>
                                        </div>                                                                  
                                        <div class="clearfix"></div>
                                        <div class="col-lg-2">
                                            <div class="form-group">
                                              <label><span style="color: Blue;">*</span>&nbsp;Default Image</label>                                                         
                                            </div>
                                        </div>
                                        <div class="col-lg-2">
                                            <div class="form-group">     
                                           <input id="txtProductDefaultImage" type="file" runat="server" /><span style="color:Blue;">(1500 X 1500)px and Max 200KB</span><br />                                              
                                            </div>                                           
                                        </div>
                                        <div class="col-lg-2" id="trImageTArea" runat="server" >
                                            <div class="form-group">     
                                              <asp:Image ID="ProductDefaultImageThumb" runat="server" Width="100" Height="80" Visible="false" />
                                            </div>                                           
                                        </div>
                                     
                                        <%--<div class="clearfix"></div>--%>
                                       <%-- <div >--%>
                                        <div class="col-lg-2">
                                            <div class="form-group">
                                                 <label>Banner Image 1</label>                                        
                                            </div>
                                        </div>
                                        <div class="col-lg-2">
                                            <div class="form-group">     
                                                 <input id="txtProductImage1" type="file" runat="server" /> <span style="color:Blue;">(1366 X 650)px and Max 200KB</span><br /> 
                                            </div>                                           
                                        </div>
                                        <div class="col-lg-2" id="trImageLArea" runat="server" >
                                            <div class="form-group">  
                                                <asp:Image ID="ProductImage1Thumb" runat="server" Width="100" Height="80" Visible="false" />
                                                <asp:Button ID="BtnRemoveImage2" runat="server" Text="Remove Image" Visible="false" CssClass="btn btn-default" onclick="BtnRemoveImage2_Click" />
                                            </div>                                           
                                        </div>
                                         <div class="clearfix"></div>
                                         <%--</div>--%>
                                          <div class="col-lg-2">
                                            <div class="form-group">
                                                 <label>Product Image 2</label>                                        
                                            </div>
                                        </div>
                                        <div class="col-lg-2">
                                            <div class="form-group">     
                                                 <input id="txtProductImage2" type="file" runat="server" /> <span style="color:Blue;">(1500 X 1500)px and Max 200KB</span><br /> 
                                            </div>                                           
                                        </div>
                                        <div class="col-lg-2" id="trImageTArea1" runat="server" >
                                            <div class="form-group">   
                                               <asp:Image ID="Image1" runat="server" Width="100" Height="80" Visible="false" />
                                               <asp:Button ID="BtnRemoveImage3" runat="server" Text="Remove Image" Visible="false" CssClass="btn btn-default" onclick="BtnRemoveImage3_Click" />
                                            </div>                                           
                                        </div>                                         
                                       <%-- <div class="clearfix"></div>--%>
                                        <div class="col-lg-2">
                                            <div class="form-group">
                                                 <label>Product Image 3</label>                                        
                                            </div>
                                        </div>
                                        <div class="col-lg-2">
                                            <div class="form-group">     
                                                 <input id="File1" type="file" runat="server" /> <span style="color:Blue;">(1500 X 1500)px and Max 200KB</span><br /> 
                                            </div>                                           
                                        </div>
                                        <div class="col-lg-2" id="Div1" runat="server" >
                                            <div class="form-group">   
                                               <asp:Image ID="Image2" runat="server" Width="100" Height="80" Visible="false" />
                                               <asp:Button ID="BtnRemoveImage4" runat="server" Text="Remove Image" Visible="false" CssClass="btn btn-default" onclick="BtnRemoveImage4_Click" />
                                            </div>                                           
                                        </div>                                         
                                        <div class="clearfix"></div>
                                        <div class="col-lg-2">
                                            <div class="form-group">
                                                <label>Bannner Descriptions</label>                                                
                                            </div>
                                        </div>                                    
                                        <div class="col-lg-4">
                                            <div class="form-group"> 
                                                <asp:TextBox ID="txtProductSpecification" runat="server" TextMode="MultiLine" Width="800px" Height="150Px" CssClass="form-control"></asp:TextBox>
                                            </div>                                           
                                        </div>                                        
                                        <div class="clearfix" ></div>
                                        <div class="col-lg-2">
                                            <div class="form-group">
                                                <label>Descriptions</label>                                                
                                            </div>
                                        </div>
                                        <div class="col-lg-4">
                                            <div class="form-group">
                                            <textarea id="textarea1" name="textarea1" style="padding:0px;" runat="server"></textarea>
                                            <script language="javascript1.2" type="text/javascript">
                                                generate_wysiwyg('textarea1');
                                            </script>
                                        </div>                                      
                                        </div>
                                        <div class="clearfix"></div>
                                        <div class="col-lg-2">
                                            <div class="form-group">
                                                <label>Status(Active/Inactive)</label>                                                
                                            </div>
                                        </div>
                                        <div class="col-lg-1">
                                            <div class="form-group">                                               
                                                <asp:CheckBox ID="chkStatus" runat="server" Checked="true" />
                                            </div>                                           
                                        </div>                                     
                                        <div class="col-lg-2">
                                            <div class="form-group">
                                                <label>Display Banner image</label>                                                
                                            </div>
                                        </div>
                                        <div class="col-lg-1">
                                            <div class="form-group">                                               
                                                <asp:CheckBox ID="chkDisplayOnHome" runat="server" />
                                            </div>                                           
                                        </div>
                                        <div class="clearfix"></div>
                                    <div class="col-lg-2">
                                        <div class="form-group">
                                            <label><span style="color: Blue;">*</span>&nbsp;SPIRITSSOURCE Name</label>
                                        </div>
                                    </div>
                                    <div class="col-lg-4">
                                        <div class="form-group">
                                            <asp:TextBox ID="txtSPIRITSSOURCETitle" runat="server" CssClass="form-control" Width="650" MaxLength="95" onkeyup="LimtCharacters(this,100,'LabelCHaracterLimit');"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="clearfix"></div>
                                    <div class="col-lg-2">
                                       
                                    </div>
                                    <div class="col-lg-4">
                                        <div class="form-group">
                                            <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" Width="650" style="display: none;"  ></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="clearfix"></div>
                                     <div class="col-lg-2">
                                        <div class="form-group">
                                            <label><span style="color: Blue;">*</span>&nbsp;SPIRITSSOURCE Color</label>
                                        </div>
                                    </div>
                                    <div class="col-lg-4">
                                        <div class="form-group">
                                            <asp:TextBox ID="txtColor" runat="server" CssClass="form-control" Width="650" MaxLength="95" onkeyup="LimtCharacters(this,100,'LabelCHaracterLimit');"></asp:TextBox>                                     
                                        </div>
                                    </div>
                                             <div class="clearfix"></div>
                                     <div class="col-lg-2">
                                        <div class="form-group">
                                            <label><span style="color: Blue;">*</span>&nbsp;SPIRITSSOURCE NOSE</label>
                                        </div>
                                    </div>
                                    <div class="col-lg-4">
                                        <div class="form-group">
                                            <asp:TextBox ID="txtNose" runat="server" CssClass="form-control" Width="650" MaxLength="95" onkeyup="LimtCharacters(this,100,'LabelCHaracterLimit');"></asp:TextBox>
                                        </div>
                                    </div>
                                             <div class="clearfix"></div>
                                     <div class="col-lg-2">
                                        <div class="form-group">
                                            <label><span style="color: Blue;">*</span>&nbsp;SPIRITSSOURCE Palate</label>
                                        </div>
                                    </div>
                                    <div class="col-lg-4">
                                        <div class="form-group">
                                            <asp:TextBox ID="txtPlalate" runat="server" CssClass="form-control" Width="650" MaxLength="95"></asp:TextBox>          
                                        </div>
                                    </div>
                                             <div class="clearfix"></div>
                                     <div class="col-lg-2">
                                        <div class="form-group">
                                            <label><span style="color: Blue;">*</span>&nbsp;SPIRITSSOURCE ABV</label>
                                        </div>
                                    </div>
                                    <div class="col-lg-4">
                                        <div class="form-group">
                                            <asp:TextBox ID="txtabv" runat="server" CssClass="form-control" Width="650" MaxLength="95"></asp:TextBox>
                                        </div>
                                    </div>
                                          <div class="clearfix"></div>
                                         <div class="col-lg-2">
                                            <div class="form-group">
                                                <label>Tasting Notes Descriptions</label>                                                
                                            </div>
                                        </div>                                    
                                        <div class="col-lg-4">
                                            <div class="form-group"> 
                                               <asp:TextBox ID="txtTastingNotes" runat="server" TextMode="MultiLine" Width="800px" Height="150Px" CssClass="form-control"></asp:TextBox>
                                            </div>                                           
                                        </div>                                        
                                        <div class="clearfix" ></div>
                                          <div class="col-lg-2">
                                        <div class="form-group">
                                            <label><span style="color: Blue;">*</span>&nbsp;Award Name</label>
                                        </div>
                                    </div>
                                    <div class="col-lg-4">
                                        <div class="form-group">
                                            <asp:TextBox ID="txtAward" runat="server" CssClass="form-control" Width="650" MaxLength="95"></asp:TextBox>
                                        </div>
                                    </div>
                                          <div class="clearfix"></div>
                                         <div class="col-lg-2">
                                            <div class="form-group">
                                                <label>Award Descriptions</label>                                                
                                            </div>
                                        </div>                                    
                                        <div class="col-lg-4">
                                            <div class="form-group"> 
                                               <asp:TextBox ID="txtAwardDescripton" runat="server" TextMode="MultiLine" Width="800px" Height="150Px" CssClass="form-control"></asp:TextBox>
                                            </div>                                           
                                        </div>                                        
                                        <div class="clearfix" ></div>
                                         <div class="col-lg-2">
                                            <div class="form-group">
                                                <label><span style="color: Blue;">*</span>&nbsp;Award Image</label>                                                         
                                            </div>
                                        </div>
                                        <div class="col-lg-4">
                                            <div class="form-group">     
                                            <input id="txtAWARDImage" type="file" runat="server" /><span style="font-size:11px;">Award Image Size <b style="color:blue;">(1366 X 650)px</b></span><br />
                                            </div>                                           
                                        </div>
                                        <div class="col-lg-2" id="AwardImage" runat="server" >
                                            <div class="form-group">     
                                                <asp:Image ID="AwardImageThumb" runat="server" Width="150" Height="80" Visible="false" />
                                            </div>                                           
                                        </div>   
                                        <div class="clearfix"></div>
                                         <div class="col-lg-2">
                                            <div class="form-group">
                                                <label><span style="color: Blue;">*</span>&nbsp;Banner Detail Ingerients </label>                                                         
                                            </div>
                                        </div>
                                        <div class="col-lg-4">
                                            <div class="form-group">     
                                            <input id="txtBannerDetail" type="file" runat="server" /><span style="font-size:11px;">Banner Ingerients Size <b style="color:blue;">(1366 X 650)px</b></span><br />
                                            </div>                                           
                                        </div>
                                        <div class="col-lg-2" id="Div2" runat="server" >
                                            <div class="form-group">     
                                                <asp:Image ID="BannerDetailThumb" runat="server" Width="150" Height="80" Visible="false" />
                                            </div>                                           
                                        </div>   
                                        <div class="clearfix"></div>
                                         <div class="col-lg-2">
                                            <div class="form-group">
                                                <label>Descriptions</label>                                                
                                            </div>
                                        </div>
                                        <div class="col-lg-4">
                                            <div class="form-group">
                                            <textarea id="textarea2" name="textarea2" style="padding:0px;" runat="server"></textarea>
                                            <script language="javascript1.2" type="text/javascript">
                                                generate_wysiwyg('textarea2');
                                            </script>
                                        </div>                                      
                                        </div>
                                        <div class="clearfix"></div>
                                        <div class="col-lg-2">
                                            <div class="form-group">
                                                <label>&nbsp;Display Order</label>                                                
                                            </div>
                                        </div>                                    
                                        <div class="col-lg-4">
                                            <div class="form-group"> 
                                                <asp:TextBox ID="txtDisplayOrder" Width="100" runat="server" CssClass="form-control" MaxLength="4" onkeypress="return numeralsOnly(event)" Text="0"></asp:TextBox>
                                            </div>                                           
                                        </div>              
                                    
                                       
                                        <div class="clearfix"></div>
                                        <div class="col-lg-10"></div>
                                        <div class="col-lg-2" style="display:none;">
                                            <div class="form-group">
                                                <span class="btn btn-default trg_next">Next</span>
                                            </div>
                                        </div>
                                        <div class="clearfix"></div> 
                                    </div>                                    
                                    <div id="SEoData" class="tab-pane fade in">
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
                                                <asp:TextBox ID="txtMetaTitle" runat="server" CssClass="form-control" Width="800px"></asp:TextBox>
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
                                                <asp:TextBox ID="txtMetaKeywords" runat="server" CssClass="form-control" Width="800px"></asp:TextBox>
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
                                                <asp:TextBox ID="txtMetaDescriptions" runat="server" CssClass="form-control" Width="800px" Height="150px" TextMode="MultiLine"></asp:TextBox>
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
                                                <asp:TextBox ID="txtMetaSchema" runat="server" CssClass="form-control" Width="800px" Height="150px" TextMode="MultiLine"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="clearfix"></div>
                                         <div class="clearfix"></div>
                                            <div class="row" style="margin-top:10px;">
                                                <div class="form-group">
                                                    <div class="col-lg-10"></div>
                                                    <div class="col-lg-2">
                                                        <div class="form-group">  
                                                            <span class="btn btn-default trg_back">Back</span>
                                                        </div>
                                                    </div>
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
                                            <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-default" OnClick="btnSave_Click" />
                                            <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="btn btn-default" OnClick="btnBack_Click" />
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
            </div>
        </div>
        <asp:HiddenField ID="hdnDDCatgeoryID" runat="server" />
        <asp:HiddenField ID="hdnTimeIntervalData" runat="server" />
        <asp:HiddenField ID="hdnFlavourData" Value="0" runat="server" />
        <script type="text/javascript">
            function LimtCharacters(txtMsg, CharLength, indicator) {
                chars = txtMsg.value.length;
                document.getElementById(indicator).innerHTML = CharLength - chars;
                if (chars > CharLength) {
                    txtMsg.value = txtMsg.value.substring(0, CharLength);
                }
            }
            //            $("input:checkbox").on('click', function() {
            //        var $box = $(this);
            //        if ($box.is(":checked")) {
            //            var group = "input:checkbox[name='" + $box.attr("name") + "']";
            //            $(group).prop("checked", false);
            //            $box.prop("checked", true);
            //        } else {
            //            $box.prop("checked", false);
            //        }
            //    });

            //    $('.BlgAdrdres input').change(function () {
            //        $(".BlgAdrdres input").prop("checked", false);
            //        $(this).prop("checked", true);
            //    });

            $("#PnlDesignVariableCost input:checkbox").on('click', function () {
                var $box = $(this);
                if ($box.is(":checked")) {
                    var group = "#PnlDesignVariableCost input:checkbox[type='" + $box.attr("type") + "']";
                    $(group).prop("checked", false);
                    $box.prop("checked", true);
                } else {
                    $box.prop("checked", false);
                }
            });

            $('select.taxinput').on('change', function () {
                let txtval = $(this).val();
                $('input#hdnTimeIntervalData').val(txtval)
            })
        </script>
        <script type="text/javascript">
            $('.btnCalculate').click(function () {
                $('.calculate').nextAll().addClass('MncrShwn');
                var MRP = $('.calculate').children('.row.siz_s').children().find('.Mrlclc').val();
                var SalePrice = $('.calculate').children('.row.siz_s').children().find('.Priceclc').val();
                $('.MncrShwn').each(function () {
                    var DalSmn = $(this).attr('data-sizetype');
                    var totalMRP = parseFloat(MRP) * parseFloat(DalSmn);
                    var totalSalePrice = parseFloat(SalePrice) * parseFloat(DalSmn);
                    //alert(DalSmn + ',' + totalMRP + ' ,' + totalSalePrice);
                    $(this).children('.row.siz_s').children().find('.Mrlclc').val(totalMRP);
                    $(this).children('.row.siz_s').children().find('.Priceclc').val(totalSalePrice);
                });
            });

            $('.btnSelectAll').click(function () {
                $('.slctAll input[type="checkbox"]').prop('checked', true);
            });
        </script>
    </form>
</body>
</html>
