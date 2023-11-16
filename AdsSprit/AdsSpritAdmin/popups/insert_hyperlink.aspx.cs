using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using Component;
using Utility;

namespace BakersOvenWeb.BakersOvenAdmin.popups
{
    public partial class insert_hyperlink : System.Web.UI.Page
    {
        CommanFunction ObjComm = new CommanFunction();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btn_upload_Click(object sender, EventArgs e)
        {
            string file = getfile(file_upload);
            string file_temp = file;
            file_temp = "../../BakersOvenImages/downloads/" + file_temp;
            url.Value = file_temp;
        }

        private string getfile(HtmlInputFile Filecontrol)
        {
            try
            {
                string file = "";
                string fpath = "";
                file = Filecontrol.PostedFile.FileName;
                file = Path.GetFileName(file);
                if (!file.Equals(""))
                {
                    string filename = Path.GetFileNameWithoutExtension(file);
                    string extenssion = Path.GetExtension(file);
                    string fname = ObjComm.UniqueFileName(Session);
                    file = fname + extenssion;
                    string s_path = Server.MapPath("../../BakersOvenImages/downloads/");
                    fpath = s_path + file;
                    Filecontrol.PostedFile.SaveAs(fpath);
                }
                return file;
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
            return "";
        }
    }
}