<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="insert_image.aspx.cs" Inherits="BakersOvenWeb.BakersOvenAdmin.popups.insert_image" %>
<!DOCTYPE html>

<html>
<head id="Head1" runat="server">
    <title>RTE | Select Image</title>

    <script language="JavaScript">

        var qsParm = new Array();


        /* ---------------------------------------------------------------------- *\
        Function    : retrieveWYSIWYG()
        Description : Retrieves the textarea ID for which the image will be inserted into.
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


        /* ---------------------------------------------------------------------- *\
        Function    : insertImage()
        Description : Inserts image into the WYSIWYG.
        \* ---------------------------------------------------------------------- */
        function insertImage() {
            var image = '<img src="' + document.getElementById('imageurl').value + '" alt="' + document.getElementById('alt').value + '" alignment="' + document.getElementById('alignment').value + '" border="' + document.getElementById('borderThickness').value + '" hspace="' + document.getElementById('horizontal').value + '" vspace="' + document.getElementById('vertical').value + '">';
            window.opener.insertHTML(image, qsParm['wysiwyg']);
            window.close();
        }

    </script>

</head>
<body bgcolor="#EEEEEE" topmargin="0" leftmargin="0" onload="retrieveWYSIWYG();">
    <form id="form1" runat="server">
        <table border="0" cellpadding="0" cellspacing="0" style="padding: 10px;">
            <tr>
                <td>
                    <span style="font-family: arial, verdana, helvetica; font-size: 11px; font-weight: bold;">
                        Insert Image:</span>
                    <table width="500px" border="0" cellpadding="0" cellspacing="0" style="background-color: #F7F7F7;
                        border: 2px solid #FFFFFF; padding: 5px;">
                        <tr>
                            <td style="font-size: 11px; padding-bottom: 2px; padding-top: 0px; font-family: arial, verdana, helvetica"
                                width="80">
                                Image Upload</td>
                            <td style="padding-bottom: 2px; padding-top: 0px" width="300">
                                <input id="img_upload" runat="server" type="file" /><asp:Button ID="btn_upload" runat="server"
                                    CssClass="loginButton" OnClick="btn_upload_Click" Text="Upload" /></td>
                        </tr>
                        <tr>
                            <td style="padding-bottom: 2px; padding-top: 0px; font-family: arial, verdana, helvetica;
                                font-size: 11px;" width="80">
                                Image URL:</td>
                            <td style="padding-bottom: 2px; padding-top: 0px;" width="300">
                                <input type="text" name="imageurl" id="imageurl" value="" style="font-size: 10px;
                                    width: 100%;" runat="server"></td>
                        </tr>
                        <tr>
                            <td style="padding-bottom: 2px; padding-top: 0px; font-family: arial, verdana, helvetica;
                                font-size: 11px;">
                                Alternate Text:</td>
                            <td style="padding-bottom: 2px; padding-top: 0px;">
                                <input type="text" name="alt" id="alt" value="" style="font-size: 10px; width: 100%;"
                                    runat="server"></td>
                        </tr>
                    </table>
                    <table width="380" border="0" cellpadding="0" cellspacing="0" style="margin-top: 10px;">
                        <tr>
                            <td>
                                <span style="font-family: arial, verdana, helvetica; font-size: 11px; font-weight: bold;">
                                    Layout:</span>
                                <table width="185" border="0" cellpadding="0" cellspacing="0" style="background-color: #F7F7F7;
                                    border: 2px solid #FFFFFF; padding: 5px;">
                                    <tr>
                                        <td style="padding-bottom: 2px; padding-top: 0px; font-family: arial, verdana, helvetica;
                                            font-size: 11px;" width="100">
                                            Alignment:</td>
                                        <td style="padding-bottom: 2px; padding-top: 0px;" width="85">
                                            <select name="alignment" id="alignment" style="font-family: arial, verdana, helvetica;
                                                font-size: 11px; width: 100%;">
                                                <option value="">Not Set</option>
                                                <option value="left">Left</option>
                                                <option value="right">Right</option>
                                                <option value="texttop">Texttop</option>
                                                <option value="absmiddle">Absmiddle</option>
                                                <option value="baseline">Baseline</option>
                                                <option value="absbottom">Absbottom</option>
                                                <option value="bottom">Bottom</option>
                                                <option value="middle">Middle</option>
                                                <option value="top">Top</option>
                                            </select>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding-bottom: 2px; padding-top: 0px; font-family: arial, verdana, helvetica;
                                            font-size: 11px;">
                                            Border Thickness:</td>
                                        <td style="padding-bottom: 2px; padding-top: 0px;">
                                            <input type="text" name="borderThickness" id="borderThickness" value="" style="font-size: 10px;
                                                width: 100%;"></td>
                                    </tr>
                                </table>
                            </td>
                            <td width="10">
                                &nbsp;</td>
                            <td>
                                <span style="font-family: arial, verdana, helvetica; font-size: 11px; font-weight: bold;">
                                    Spacing:</span>
                                <table width="185" border="0" cellpadding="0" cellspacing="0" style="background-color: #F7F7F7;
                                    border: 2px solid #FFFFFF; padding: 5px;">
                                    <tr>
                                        <td style="padding-bottom: 2px; padding-top: 0px; font-family: arial, verdana, helvetica;
                                            font-size: 11px;" width="80">
                                            Horizontal:</td>
                                        <td style="padding-bottom: 2px; padding-top: 0px;" width="105">
                                            <input type="text" name="horizontal" id="horizontal" value="" style="font-size: 10px;
                                                width: 100%;"></td>
                                    </tr>
                                    <tr>
                                        <td style="padding-bottom: 2px; padding-top: 0px; font-family: arial, verdana, helvetica;
                                            font-size: 11px;">
                                            Vertical:</td>
                                        <td style="padding-bottom: 2px; padding-top: 0px;">
                                            <input type="text" name="vertical" id="vertical" value="" style="font-size: 10px;
                                                width: 100%;"></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    <div align="right" style="padding-top: 5px;">
                        <input type="submit" value="  Submit  " onclick="insertImage();" style="font-size: 12px;"
                            id="Submit1">&nbsp;<input type="submit" value="  Cancel  " onclick="window.close();"
                                style="font-size: 12px;"></div>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
