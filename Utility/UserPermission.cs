using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Utility;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace Component
{
    public class UserPermission
    {
        Connect ObjSql = new Connect();
        CommanFunction ObjComm = new CommanFunction();
        ManageException ObjEx = new ManageException();

        public UserPermission()
        {
        }

        int _PageUserID = 0;
        int _PageID = 0;

        public int PageID
        {
            get { return _PageID; }
            set { _PageID = value; }
        }
        int _UserID = 0;

        public int UserID
        {
            get { return _UserID; }
            set { _UserID = value; }
        }
        int _ReadOnly = 0;

        public int ReadOnly
        {
            get { return _ReadOnly; }
            set { _ReadOnly = value; }
        }
        int _AddOnly = 0;

        public int AddOnly
        {
            get { return _AddOnly; }
            set { _AddOnly = value; }
        }
        int _ModifiedOnly = 0;

        public int ModifiedOnly
        {
            get { return _ModifiedOnly; }
            set { _ModifiedOnly = value; }
        }
        int _DeleteOnly = 0;

        public int DeleteOnly
        {
            get { return _DeleteOnly; }
            set { _DeleteOnly = value; }
        }
        DateTime _PostedDate = DateTime.Now;

        string _updatedBy = string.Empty;
        DateTime _updatedOn = DateTime.Now;

        public int PageUserID
        {
            get { return _PageUserID; }
            set { _PageUserID = value; }
        }

        public DateTime PostedDate
        {
            get { return _PostedDate; }
            set { _PostedDate = value; }
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


        //*******************Check Admin User login ************************//


        public DataSet SelectPageDatabyUserID()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectPageDatabyUserID");
                _SqlParameter[1] = new SqlParameter("@UserID", UserID);
                return ObjSql.GetDsetProc("Mst_Sp_UserPermission", _SqlParameter);
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Error in procedure admindashboardreport()", ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.GetDsetProc("Mst_Sp_UserPermission", _SqlParameter);
        }
        public DataSet SelectPageHeaderDatabyUserID()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectPageHeaderDatabyUserID");
                _SqlParameter[1] = new SqlParameter("@UserID", UserID);
                return ObjSql.GetDsetProc("Mst_Sp_UserPermission", _SqlParameter);
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Error in procedure SelectPageHeaderDatabyUserID()", ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.GetDsetProc("Mst_Sp_UserPermission", _SqlParameter);
        }

        public int SaveUserPermission()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[10];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SaveUserPermission");
                _SqlParameter[1] = new SqlParameter("@PageID", PageID);
                _SqlParameter[2] = new SqlParameter("@UserID", UserID);
                _SqlParameter[3] = new SqlParameter("@ReadOnly", ReadOnly);
                _SqlParameter[4] = new SqlParameter("@ModifiedOnly", ModifiedOnly);
                _SqlParameter[5] = new SqlParameter("@DeleteOnly", DeleteOnly);
                _SqlParameter[6] = new SqlParameter("@PostedDate", PostedDate);
                _SqlParameter[7] = new SqlParameter("@UpdatedBy", UpdatedBy);
                _SqlParameter[8] = new SqlParameter("@UpdatedOn", UpdatedOn);
                _SqlParameter[9] = new SqlParameter("@AddOnly", AddOnly);



                return ObjSql.ExcuteProce("Mst_Sp_UserPermission", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SaveUserPermission()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_UserPermission", _SqlParameter);
        }

        public int SelectPageIDByPageURL(string PageUrl)
        {
            int ID = 0;
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectPageIDByPageURL");
                _SqlParameter[1] = new SqlParameter("@PageUrl", PageUrl);
                ID = Convert.ToInt32(ObjSql.GetScalarProc("Mst_Sp_UserPermission", _SqlParameter));
                return ID;
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SelectPageIDByPageURL()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ID;
        }

        public SqlDataReader SelectPageDatabyUserIDPageID()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[3];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectPageDatabyUserIDPageID");
                _SqlParameter[1] = new SqlParameter("@PageID", PageID);
                _SqlParameter[2] = new SqlParameter("@UserID", UserID);
                return ObjSql.GetDatareaderProc("Mst_Sp_UserPermission", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SelectPageDatabyUserIDPageID()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.GetDatareaderProc("Mst_Sp_BlogData", _SqlParameter);
        }
        public void SelectLogFileData(System.Web.UI.WebControls.GridView DepartmentGrid)
        {
            SqlParameter[] _SqlParameter = new SqlParameter[1];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectLogFileData");
                ObjSql.GdBind_SNO(DepartmentGrid, "Mst_Sp_UserPermission", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SelectLogFileData()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
        }

    }
}
