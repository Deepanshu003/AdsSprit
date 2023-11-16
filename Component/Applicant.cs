using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Utility;


namespace Component
{
    public class Applicant
    {
        Connect ObjSql = new Connect();
        CommanFunction ObjComm = new CommanFunction();
        ManageException ObjEx = new ManageException();

        public Applicant()
        {
        }

        int _ApplicantID = 0;
        int _JobID = 0;
        string _FirstName = string.Empty;
        string _Email = string.Empty;
        string _Address = string.Empty;
        string _FileData = string.Empty;
        string _Message = string.Empty;
        string _JobName = string.Empty;
        string _updatedBy = string.Empty;
        DateTime _updatedOn = DateTime.UtcNow;

        public int ApplicantID
        {
            get { return _ApplicantID; }
            set { _ApplicantID = value; }
        }

        public int JobID
        {
            get { return _JobID; }
            set { _JobID = value; }
        }
        public string FirstName
        {
            get { return _FirstName; }
            set { _FirstName = value; }
        }

        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }

        public string Address
        {
            get { return _Address; }
            set { _Address = value; }
        }

        public string FileData
        {
            get { return _FileData; }
            set { _FileData = value; }
        }

        public string Message
        {
            get { return _Message; }
            set { _Message = value; }
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

        public string JobName
        {
            get { return _JobName; }
            set { _JobName = value; }
        }



        public void SelectAllApplicants(System.Web.UI.WebControls.GridView JobGrid)
        {
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectAllApplicants");
                _SqlParameter[1] = new SqlParameter("@UpdatedBy", UpdatedBy);
                ObjSql.GdBind_SNO(JobGrid, "Mst_Sp_Applicants", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SelectAll()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
        }
        public int SaveNewApplicants()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[9];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SaveNewApplicants");
                _SqlParameter[1] = new SqlParameter("@JobID", JobID);
                _SqlParameter[2] = new SqlParameter("@FirstName", FirstName);
                _SqlParameter[3] = new SqlParameter("@Email", Email);
                _SqlParameter[4] = new SqlParameter("@Address", Address);
                _SqlParameter[5] = new SqlParameter("@FileData", FileData);
                _SqlParameter[6] = new SqlParameter("@Message", Message);
                _SqlParameter[7] = new SqlParameter("@JobName", JobName);
                _SqlParameter[8] = new SqlParameter("@UpdatedBy", UpdatedBy);
                return ObjSql.ExcuteProce("Mst_Sp_Applicants", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SaveNewApplicants()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_Applicants", _SqlParameter);
        }

    }
}
