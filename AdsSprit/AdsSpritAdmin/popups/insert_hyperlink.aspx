﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="insert_hyperlink.aspx.cs" Inherits="BakersOvenWeb.BakersOvenAdmin.popups.insert_hyperlink" %>
<!DOCTYPE html>

<html>
<head id="Head1" runat="server">
    <title>RTE | Select Link</title>

    <script language="JavaScript">

        var qsParm = new Array();


        /* ---------------------------------------------------------------------- *\
        Function    : retrieveWYSIWYG()
        Description : Retrieves the textarea ID for which the link will be inserted into.
        \* ---------------------------------------------------------------------- */
        function retrieveWYSIWYG() {
            var query = window.location.search.substring(1);
            var parms = query.split('&');
            for (var i = 0; i < parms.length; i++) {
                var pos = parms[i].indexOf('=');
                if (pos > 0) {
                    var key = parms[i].substring(0, pos);
                    var val = parms[i].substring(pos + 1);
                    qsParm[key] = val;
                }
            }
        }


        function insertHyperLink() {
            var hyperLink = document.getElementById('url').value; // document.getElementById('linkType').value + 
            window.opener.document.getElementById('wysiwyg' + qsParm['wysiwyg']).contentWindow.document.execCommand("CreateLink", false, hyperLink);
            window.close();
        }

    </script>

</head>
<body bgcolor="#EEEEEE" topmargin="0" leftmargin="0" onload="retrieveWYSIWYG();">
    <form id="form1" runat="server">
        <table border="0" cellpadding="0" cellspacing="0" style="padding: 10px;" width="350px">
            <tr>
                <td>
                    <span style="font-family: arial, verdana, helvetica; font-size: 11px; font-weight: bold;">
                        Insert Hyperlink:</span>
                    <table width="340px" border="0" cellpadding="0" cellspacing="0" style="background-color: #F7F7F7;
                        border: 2px solid #FFFFFF; padding: 5px;">
                        <tr>
                            <td style="padding-bottom: 2px; width: 50px; font-family: arial, verdana, helvetica;
                                font-size: 11px;">
                                Type:</td>
                            <td style="padding-bottom: 2px;">
                                <select name="linkType" id="linkType" style="margin-right: 10px; font-size: 10px;"
                                    runat="server">
                                    <option value="https://">http:</option>
                                    <option value="https://">https:</option>
                                    <option value="mailto:">mailto:</option>
                                </select>
                            </td>
                        </tr>
                        <tr>
                            <td style="font-size: 11px; padding-bottom: 2px; padding-top: 0px; font-family: arial, verdana, helvetica">
                                File</td>
                            <td style="padding-bottom: 2px; padding-top: 0px">
                                <input id="file_upload" runat="server" type="file" /><asp:Button ID="btn_upload"
                                    runat="server" CssClass="loginButton" OnClick="btn_upload_Click" Text="Upload" /></td>
                        </tr>
                        <tr>
                            <td style="padding-bottom: 2px; padding-top: 0px; font-family: arial, verdana, helvetica;
                                font-size: 11px;">
                                URL:</td>
                            <td style="padding-bottom: 2px; padding-top: 0px;">
                                <input type="text" name="url" id="url" value="" style="font-size: 10px; width: 100%;"
                                    runat="server"></td>
                        </tr>
                    </table>
                    <div align="right" style="padding-top: 5px;">
                        <input type="submit" value="  Submit  " onclick="insertHyperLink();" style="font-size: 12px;"
                            id="Submit1">&nbsp;<input type="submit" value="  Cancel  " onclick="window.close();"
                                style="font-size: 12px;"></div>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>