<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="AdsSprit.AdsSpritAdmin.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
    <title>ADS : Administrator</title>
    <link rel="icon" href="images/adslogo.png" type="image/x-icon" />
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=5" />
    <link href='http://fonts.googleapis.com/css?family=Open+Sans' rel='stylesheet' type='text/css' />
    <style type="text/css">        
        body{margin:0;padding:0;}
        .clr{clear:both;}
        .m_c{width: 100%; height: 100%;  background: #aaa; position: fixed; background: url(images/AdsBanner.jpg) center center no-repeat; background-size: cover;}
        .hed{text-align:center;z-index:999999999;position:relative;}
       .hed {text-align: left;z-index: 999999999;position: relative;}
        .hed a {z-index: 99999999;display: block;}
        .hed img {margin-top: 2%;z-index: 99999999;}
        .my_fom {width: 20%;margin: 134px 70%; padding: 25px 2.8%; position: relative; top: -3.1%; z-index: 999; border-radius: 45px 0px 45px 0px; background: #001478; float: left;}
        .my_fom input {border-radius: 20px 20px 20px 20px;width: 78%;margin: 11px 13px;height: 35px;line-height: 35px;font-size: 19px;outline: none;font-family: 'FuturaBT-Book';background:#001478; padding: 2px 20px;letter-spacing: 3px;}
        .my_fom .lg_in_btn{margin-top: 18px; font-size: 15px; padding: 0px 7%; margin-right: 10%; margin-left: 88px; width: 42%; color: #001478; line-height: 35px; cursor: pointer; background: #ffffff; border-radius: 20px; height: 40px;}
        .my_fom .lg_in_btn:active{padding: 0px 3%;}
        .cld{position: absolute; top: 42%; left: 0; right: 0; text-align: center; z-index: 99;}
        .pd{position: absolute; top: 0%; left: 0; right: 0; text-align: center; z-index: 9;}
        .cldfooter{position: absolute; top: 76%; right: 13%; text-align: center; z-index: 99; padding: 11px; color: #001478; margin: 0px; font-size: 16px; font-family: 'Lato', sans-serif;}
        .cldfooter a{top: 5%;}
        .textRed{color:#fff;}::-webkit-input-placeholder{color: #ffffff;}::-moz-placeholder{color: #ffffff;}:-ms-input-placeholder{color: #ffffff;}:-moz-placeholder{color: #ffffff;}
        @media (max-width:992px){.my_fom{width: 45%; margin: 0% 25% 5%;}.pd{display: none;}}@media (max-width:480px){.my_fom{width: 65%; margin: 0% 15% 5%;}}
         .cldfooter{position:absolute; top:97%;left:0;right:0;text-align:center;z-index:99; background:#001478; width:100%; padding:5px; color:#fff; margin:0px;}
        .cldfooter a{top:5%;}
        .textRed{color:#red;}
    </style>
</head>
<body>
    <form id="form1" runat="server">
          <div class="m_c">  
              <div class="hed">
                <img src="images/adslogo.png"  style="margin-left: 75%; /* width: 277px; */ margin-top: 3%; background-color:blue;" />
                <br />
            </div>
            <div class="my_fom">
                <asp:TextBox ID="username" runat="server" placeholder="USERNAME" ></asp:TextBox><br/>
                <asp:TextBox ID="password" runat="server" placeholder="PASSWORD" TextMode="Password"></asp:TextBox><br/>
                <asp:Button ID="submit" runat="server" Text="LOG IN" CssClass="lg_in_btn" onClick="submit_Click" /><br />
                <p><asp:Label id="lblError" runat="server" CssClass="textRed"></asp:Label></p>
                <div class="clr"></div>
            </div>            
            <div class="cldfooter">Made with passion : <a href="https://www.ibrandox.com" target="_blank"><img src="images/ox.png" alt="iBrandox Online Pvt. Ltd."  style="vertical-align: middle;"/></a></div>
        </div>
    </form>
</body>
</html>
