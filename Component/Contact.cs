using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Utility;

namespace Component
{
    public class Contact
    {
        Connect ObjSql = new Connect();
        CommanFunction ObjComm = new CommanFunction();
        ManageException ObjEx = new ManageException();

        public Contact()
        {
        }

        int _contactID = 0;
        string _firstName = string.Empty;
        string _lastName = string.Empty;
        string _emailID = string.Empty;
        string _phoneNo = string.Empty;
        string _Designation = string.Empty;
        string _Organisation = string.Empty;
        string _Companywebsite = string.Empty;
        string _pageName = string.Empty;
        string _city = string.Empty;
        string _message = string.Empty;
        DateTime _postedDate = DateTime.UtcNow;
        string _updatedBy = string.Empty;
        DateTime _updatedOn = DateTime.UtcNow;
        string _APPOINTMENTDate = string.Empty;
        string _Address = string.Empty;

        public string APPOINTMENTDate
        {
            get { return _APPOINTMENTDate; }
            set { _APPOINTMENTDate = value; }
        }

        public string Address
        {
            get { return _Address; }
            set { _Address = value; }
        }

        public int ContactID
        {
            get { return _contactID; }
            set { _contactID = value; }
        }

        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        public string Organisation
        {
            get { return _Organisation; }
            set { _Organisation = value; }
        }

        public string Companywebsite
        {
            get { return _Companywebsite; }
            set { _Companywebsite = value; }
        }
        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }
        public string Designation
        {
            get { return _Designation; }
            set { _Designation = value; }
        }
        public string PageName
        {
            get { return _pageName; }
            set { _pageName = value; }
        }
        public string EmailID
        {
            get { return _emailID; }
            set { _emailID = value; }
        }
        public string PhoneNo
        {
            get { return _phoneNo; }
            set { _phoneNo = value; }
        }
        public string City
        {
            get { return _city; }
            set { _city = value; }
        }
        public string Message
        {
            get { return _message; }
            set { _message = value; }
        }
        public DateTime PostedDate
        {
            get { return _postedDate; }
            set { _postedDate = value; }
        }
        public string UpdatedBy
        {
            get { return _updatedBy; }
            set { _updatedBy = value; }
        }
        public DateTime UpdatedOn
        {
            get { return _updatedOn; }
            set { _updatedOn = value; }
        }

        #region AdminPanel
        public void SelectAllEnquiry(System.Web.UI.WebControls.GridView ContactGrid)
        {
            SqlParameter[] _SqlParameter = new SqlParameter[4];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectAllEnquiry");
                _SqlParameter[1] = new SqlParameter("@Designation", Designation);
                _SqlParameter[2] = new SqlParameter("@UpdatedBy", UpdatedBy); 
                _SqlParameter[3] = new SqlParameter("@City", City); 
                ObjSql.GdBind_SNO(ContactGrid, "Mst_sp_Contact", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SelectAllEnquiry()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
        }

        public void SelectRecent5Enquiry(System.Web.UI.WebControls.GridView ContactGrid)
        {
            SqlParameter[] _SqlParameter = new SqlParameter[1];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectRecent5Enquiry");
                ObjSql.GdBind_SNO(ContactGrid, "Mst_sp_Contact", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SelectRecent5Enquiry()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
        }

        public SqlDataReader SelectEnquiryByEnquiryID()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectEnquiryByEnquiryID");
                _SqlParameter[1] = new SqlParameter("@ContactID", ContactID);
                return ObjSql.GetDatareaderProc("Mst_sp_Contact", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SelectEnquiryByEnquiryID()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.GetDatareaderProc("Mst_sp_Contact", _SqlParameter);
        }

        public int DeleteEnquiryByEnquiryID()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "DeleteEnquiryByEnquiryID");
                _SqlParameter[1] = new SqlParameter("@ContactID", ContactID);
                return ObjSql.ExcuteProce("Mst_sp_Contact", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure DeleteRecord()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_sp_Contact", _SqlParameter);
        }

        public DataSet ExportEmailIDsintoExcel()
        {
            SqlParameter[] arrparam = new SqlParameter[2];
            try
            {
                arrparam[0] = new SqlParameter("@Action", "ExportEmailIDsintoExcel");
                arrparam[1] = new SqlParameter("@Designation", Designation);
                return ObjSql.GetDsetProc1("Mst_sp_Contact", arrparam);
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Error in procedure BindEmailIDsintoExcel()", ex);
            }
            finally
            {
                arrparam = (SqlParameter[])null;
                ObjSql = (Connect)null;
                ObjEx = (ManageException)null;
            }

            return ObjSql.GetDsetProc1("Mst_Sp_Subscribe", arrparam);
        }

        #endregion AdminPanel

        #region Front Panel
        public int SaveNewEnquiry()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[13];
            try
            {      
                _SqlParameter[0] = new SqlParameter("@Action", "SaveNewEnquiry");
                _SqlParameter[1] = new SqlParameter("@FirstName", FirstName);
                _SqlParameter[2] = new SqlParameter("@EmailID", EmailID);
                _SqlParameter[3] = new SqlParameter("@PhoneNo", PhoneNo);
                _SqlParameter[4] = new SqlParameter("@Message", Message);
                _SqlParameter[5] = new SqlParameter("@Designation", Designation);
                _SqlParameter[6] = new SqlParameter("@Organisation", Organisation);
                _SqlParameter[7] = new SqlParameter("@Companywebsite", Companywebsite);
                _SqlParameter[8] = new SqlParameter("@PageName", PageName);
                _SqlParameter[9] = new SqlParameter("@PostedDate", PostedDate);
                _SqlParameter[10] = new SqlParameter("@City", City);
                _SqlParameter[11] = new SqlParameter("@LastName", LastName);
                _SqlParameter[12] = new SqlParameter("@Address", Address);
                return ObjSql.ExcuteProce("Mst_sp_Contact", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SaveNewEnquiry()", Ex);
            }
            return ObjSql.ExcuteProce("Mst_sp_Contact", _SqlParameter);
        }
        #endregion
    }
}
