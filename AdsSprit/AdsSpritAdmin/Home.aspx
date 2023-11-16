<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="AdsSprit.AdsSpritAdmin.Home" %>
<%@ Register Src="Header.ascx" TagName="Header" TagPrefix="uc1" %>
<%@ Register Src="Footer.ascx" TagName="Footer" TagPrefix="uc2" %>
<%@ Register Src="HeaderRight.ascx" TagName="HeaderRight" TagPrefix="uc3" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <title>Ads : Administrator</title>
    <link rel="icon" href="images/adslogo.png" type="image/x-icon" />
    <link href="css/bootstrap.css" rel="stylesheet" />
    <link href="css/font-awesome.css" rel="stylesheet" />
    <link href="css/morris-0.4.3.min.css" rel="stylesheet" />
    <link href="css/custom-styles.css" rel="stylesheet" />
    <!-- <link href='http://fonts.googleapis.com/css?family=Open+Sans' rel='stylesheet' type='text/css' /> -->
     <style type="text/css">
        .page-body{padding: 0px 20px; width: 100%; /* min-height: 385px; */ display: inline-block;}
        .static-content{margin-top: 30px; margin-bottom: 40px; display: inline-block; width: 100%;}
        .col-1-3{width: 29%; margin: 2%;}[class*="col-"]{float: left; min-height: 1px;}
        .static-content .white-box{-webkit-border-radius: 3px; -moz-border-radius: 3px; -ms-border-radius: 3px; -o-border-radius: 3px; border-radius: 28px; padding: 30px; width: 304px; height: 149px;}
        .white-box{position: relative; background-color: #fff; min-height: 125px; border: 1px solid rgba(0, 174, 228, 0.36);}
        .badge{position: absolute; height: 31px; top: -1px; right: -10px; display: block; background-color: #772f69; color: #fff; font-weight: 400; font-size: 19px; line-height: 1; padding: 6px 13px 0; -webkit-border-radius: 40px; -moz-border-radius: 40px; -ms-border-radius: 40px; -o-border-radius: 40px; border-radius: 40px;}
        .badge.blue{background-color: #0363df;}.static-content .white-box h4{font-weight: 300; color: #fff; font-size: 22px; line-height: 28px; text-align: center;}
        .static-content .white-box::after{width: 83px; height: 45px; left: 0; top: 100%; background-position: left top;}
        table td{text-align: left;
    padding: 10px; background: #fff none repeat scroll 0 0;
    border: 1px solid rgba(107, 108, 109, 0.19);
    color: #000;
    font-size: 12px;
    line-height: 19px;}
        .cssWithhm_dat_ad a{color:#000000;text-decoration:none;}
        .cssWithouthm_dat_ad a{color:#ffffff;text-decoration:none;}
        .hm_dat_ad:hover, .hm_dat_ad a:hover{background-color:#e3e3e3;color:#fff;text-decoration:none;}
        .head_inn_title { float: left; }
        .head_inn { font-size: 16px;
    position: relative;
    padding: 0px;
    /* border-bottom: 1px solid rgba(69, 69, 85, 0.2); */
    color: #454555;
    margin-bottom: 10px; }
        .head_inn_act{ float:right; font-size:12px;line-height: 25px;} 
        .head_inn_act b{font-size:12px;}
        .head_inn_act a{ font-size: 12px;
    font-weight: 600;
    color: #780000;
    transition: all .5s;
    text-decoration: none;
    margin-left: 10px; } 
        .head_inn_act a:hover{ color:#f58634 }
.head_inn_title{line-height: 25px;
    font-size: 15px;
    font-weight: 500;}
.dashCard {padding:0px;}
.hm_dat_ad {padding:18px 5px;min-height:110px;}
.hm_dat_ad h2 { font-size: 15px; margin-bottom: 8px; }
.hm_dat_ad h3 { margin-bottom: 4px; color: #000; font-size: 14px;}
.hm_dat_ad i { font-size: 35px; color: #000; }
table, th {padding: 10px;
    text-align: left;
    font-size: 13px;
    text-shadow: none;
    line-height: 15px;
    font-weight: 400;}
table, th:last-child {text-align: center;}
table td:last-child { text-align: center;}
.dashRow {margin:20px 5px;}
        /* -----------------------bar graph Start------------------------------ */
        .chart__bar[data-value='1']{grid-row-start: 81 !important; position: relative;}
        .chart__bar[data-value] span p:before{display: inline-block; position: absolute; left: 0px; bottom: -20px; text-indent: 0; content: attr(rqurd-label);}
        .chart__bar[data-value]:after{display: inline-block; position: absolute; left: 50%; bottom: -1.8em; transform: translate(-50%); text-indent: 0; content: attr(aria-label); color: #888888;}
        .chart__bar[data-value='2']{grid-row-start: 71 !important; position: relative; text-indent: 0;}
        .chart__bar[data-value='3']{grid-row-start: 61 !important; position: relative; text-indent: 0;}
        .chart__bar[data-value='4']{grid-row-start: 51 !important; position: relative;}
        .chart__bar[data-value='5']{grid-row-start: 41 !important; position: relative;}
        .chart__bar[data-value='6']{grid-row-start: 31 !important; position: relative;}
        .chart__bar[data-value='7']{grid-row-start: 21 !important; position: relative;}
        .chart__bar[data-value='8']{grid-row-start: 11!important; position: relative;}
        .chart__bar[data-value='9']{grid-row-start: 1 !important; position: relative;}
        .chart{display: grid; grid-template-columns: repeat(5, 1fr); grid-template-rows: repeat(100, 1fr); grid-column-gap: 36px; width: 55%; height: 358px; border-bottom: 1px solid #dadada; border-left: 1px solid #dadada; padding-right: 80px; padding-left: 50px; margin-right: 50px;position:relative;}
        .chart:before{content: ""; position: absolute; top: -4px; left: -7px; width: 0; height: 0; border-left: 6px solid transparent; border-right: 6px solid transparent; border-bottom: 8px solid #b7b8b8;}
        .chart:after{content: ""; position: absolute; bottom: -6px; right: -7px;width: 0; height: 0; border-top: 6px solid transparent;border-bottom: 6px solid transparent;border-left: 8px solid #b7b8b8;}
        .chart__bar{grid-row-start: 1; grid-row-end: 101; background: #dadada; color: #ffffff;}
        .chart__bar span{position: absolute; width: 100%; height: 100%; bottom: 0px; left: 0px;}
        .chart__bar span p{transform: rotate(-90deg); position: absolute; bottom: 10px; left: -8%; transform: translate(0%, -100%) rotate(-90deg); width: 100%; font-size: 12px;}*{font-size: 12px;}
        .chart__act{content:"";position:absolute;left:0px; background: #f8c611;animation-name: floating; animation-duration: 1s; animation-iteration-count: infinite; animation-timing-function: ease-in-out;}
        .chart__bar span:before{content: attr(rerd-height);}
        .chart__bar[data-value='1'] .chart__act{background: #780000;}
        .chart__bar[data-value='2'] .chart__act{background: #780000;}
        .chart__bar[data-value='3'] .chart__act{background: #780000;}
        .chart__bar[data-value='4'] .chart__act{background: #780000;}
        .chart__bar[data-value='5'] .chart__act{background: #780000;}
        .chart__bar[data-value='6'] .chart__act{background: #780000;}
        .chart__bar[data-value='7'] .chart__act{background: #780000;}
        .chart__bar[data-value='8'] .chart__act{background: #780000;}
        .chart__bar[data-value='9'] .chart__act{background: #780000;}@keyframes floating{from{transform: translate(0);}65%{transform: translate(0);}to{transform: translate(0);}}
        .chart__bar[data-value='9'] .chart__act{background: #780000;}
        .chart__act{content: ""; position: absolute; left: 0px; background: #f8c611; animation-name: floating; animation-duration: 1s; animation-iteration-count: infinite; animation-timing-function: ease-in-out;}
        .chartGraph{padding:20px 7px;}
        div#piechart { position: absolute; bottom: 0; left: auto; right: 0; border-left: 1px solid #e7e7e7; margin-bottom: 7%;}
        /* -----------------------bar graph End------------------------------ */

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
                            <h1 class="page-header" style="color:#333;">Welcome to Administrator </h1>
                            <p style="text-align:center;padding-top:5px;margin:0px;"><asp:Literal ID="litMsgg" runat="server"></asp:Literal></p>                            
                        </div>
                    </div>                   
          </div>
       </div>
    </div>
    </form>
</body>
</html>
