<%@ Page Title="" Language="C#" MasterPageFile="~/AdsSpirit.Master" AutoEventWireup="true" CodeBehind="thankyou.aspx.cs" Inherits="AdsSprit.thankyou" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <style>
        body {
            background-size: cover;
            background-position: center;
            background-repeat: no-repeat;
            height: 100vh;
            margin: 0;
            display: flex;
            align-items: center;
            justify-content: center;
            flex-direction: column;
        }
        
        .thank-you-text {
            font-size: 24px;
            color: #ffffff;
            text-align: center;
        }
        
        .thank-you-text p {
            font-size: 18px;
            margin: 0;
        }
    </style>
    <div class="thank-you-text">
        <h1>Thank You!</h1>
        <p>Your message has been received.</p>
         <img src='https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRT85T6NEpaKqjG9OuBKEtQbjivKE2Vcva--g&usqp=CAU' alt="Thank You Image"/>
    </div>
</asp:Content>
