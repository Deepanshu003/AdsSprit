using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Microsoft.VisualBasic;
using System.Diagnostics;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Security.Cryptography;


namespace Utility
{
    public class CommanFunction
    {
        public CommanFunction()
        {

        }

        ManageException Objexp = new ManageException();
        Connect ObjSql = new Connect();
        private const string CrLf = Microsoft.VisualBasic.Constants.vbCrLf;
        private const string Tab = Microsoft.VisualBasic.Constants.vbTab;

        public string getdate(string ddate)
        {
            char[] arr;
            ddate = ddate + " ";
            arr = ddate.ToCharArray();
            ArrayList arraylist1 = new ArrayList();
            int m;
            string str1 = "";
            for (m = 0; m <= arr.Length - 1; m++)
            {
                while (arr[m] != ' ')
                {
                    str1 = str1 + arr[m];
                    m++;
                }
                arraylist1.Add(str1);
                str1 = "";
            }
            ddate = arraylist1[0] + "/";
            arr = ddate.ToCharArray();
            ArrayList arraylist2 = new ArrayList();
            for (m = 0; m <= arr.Length - 1; m++)
            {
                while (arr[m] != '/')
                {
                    str1 = str1 + arr[m];
                    m++;
                }
                arraylist2.Add(str1);
                str1 = "";
            }
            if (Convert.ToInt16(arraylist2[0].ToString()) < 10)
            {
                arraylist2[0] = "0" + Convert.ToInt16(arraylist2[0].ToString());
            }
            if (Convert.ToInt16(arraylist2[1].ToString()) < 10)
            {
                arraylist2[1] = "0" + Convert.ToInt16(arraylist2[1].ToString());
            }
            string fdate = arraylist2[1] + "/" + arraylist2[0] + "/" + arraylist2[2];
            return fdate;
        }

        public void SetFocus(System.Web.UI.Page Page, System.Web.UI.Control Control)
        {
            System.Text.StringBuilder StringBuilder;
            StringBuilder = new System.Text.StringBuilder();
            StringBuilder.Append(CrLf);
            StringBuilder.Append("<script type=\"text/javascript\">");
            StringBuilder.Append(CrLf);
            StringBuilder.Append("<!--");
            StringBuilder.Append(CrLf);
            StringBuilder.Append(Tab);
            StringBuilder.Append("document.getElementById(\"");
            StringBuilder.Append(Control.ClientID);
            StringBuilder.Append("\").focus();");
            StringBuilder.Append(CrLf);
            StringBuilder.Append("//-->");
            StringBuilder.Append(CrLf);
            StringBuilder.Append("</script>");
            StringBuilder.Append(CrLf);
            Page.ClientScript.RegisterStartupScript(typeof(Page), "SetFocusScript", StringBuilder.ToString());
        }
        public object fileUpLoad1(HttpPostedFile file, string folder, string fileName, System.Web.HttpServerUtility objServer)
        {
            try
            {
                string imgPath;
                imgPath = objServer.MapPath(folder);
                file.SaveAs(imgPath + "\\" + fileName);
            }
            catch (Exception ex)
            {
                Objexp.PublishError("Problem in function 'fileUpLoad()'", ex);
            }
            return null;
        }
        public object fileUpLoad(System.Web.UI.HtmlControls.HtmlInputFile file, string folder, string fileName, System.Web.HttpServerUtility objServer)
        {
            try
            {
                string imgPath;
                imgPath = objServer.MapPath(folder);
                file.PostedFile.SaveAs(imgPath + "\\" + fileName);
            }
            catch (Exception ex)
            {
                Objexp.PublishError("Problem in function 'fileUpLoad()'", ex);
            }
            return null;
        }

        public string UniqueFileName(System.Web.SessionState.HttpSessionState session)
        {
            DateTime myDate = DateTime.Now;
            string s = Guid.NewGuid().ToString().Replace("-", string.Empty);
            return s;
        }

        public int IsExists(string TableName, string Column, string value)
        {
            DataSet ds = new DataSet();
            SqlParameter[] _SqlParameter = new SqlParameter[3];
            try
            {
                _SqlParameter[0] = new SqlParameter("@TableName", TableName);
                _SqlParameter[1] = new SqlParameter("@Column", Column);
                _SqlParameter[2] = new SqlParameter("@Value", value);

                return ObjSql.ExcuteProce("Sp_CheckExistence", _SqlParameter);
            }
            catch (Exception ex)
            {
                Objexp.PublishError("Error in Procedure IsExists()", ex);
            }
            return ObjSql.ExcuteProce("VATech_Sp_CheckExistence", _SqlParameter);
        }

        public void ExportGridView(DataTable dt, string fileName)
        {
            string attachment = "attachment; filename=" + fileName + ".xls";
            HttpContext.Current.Response.ClearContent();
            HttpContext.Current.Response.AddHeader("content-disposition", attachment);
            HttpContext.Current.Response.ContentType = "application/vnd.ms-excel";
            string tab = "";
            foreach (DataColumn dc in dt.Columns)
            {
                HttpContext.Current.Response.Write(tab + dc.ColumnName);
                tab = "\t";
            }
            HttpContext.Current.Response.Write("\n");
            int i;
            foreach (DataRow dr in dt.Rows)
            {
                tab = "";
                for (i = 0; i < dt.Columns.Count; i++)
                {
                    HttpContext.Current.Response.Write(tab + dr[i].ToString());
                    tab = "\t";
                }
                HttpContext.Current.Response.Write("\n");
            }
            HttpContext.Current.Response.End();
        }
    }
}
