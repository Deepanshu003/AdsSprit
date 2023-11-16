using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;


namespace Utility
{
    public class ManageException
    {
        public ManageException()
        {

        }

        public void PublishError(string errPlace, Exception e)
        {
            HttpContext.Current.Response.Write("<b>Error in " + errPlace + " : </b><i>" + e.Message.ToString() + "</i><br>");
            HttpContext.Current.Response.End();
        }
    }
}
