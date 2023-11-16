using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Utility;

namespace Component
{
    public class Job
    {
        Connect ObjSql = new Connect();
        CommanFunction ObjComm = new CommanFunction();
        ManageException ObjEx = new ManageException();

        public Job()
        {
        }

        int _JobID = 0;
        string _JobName = string.Empty;
        string _JobNameURL = string.Empty;
        int _activeStatus = 0;
        string _updatedBy = string.Empty;
        DateTime _updatedOn = DateTime.UtcNow;
        string _metaTitle = string.Empty;
        string _metaKeywords = string.Empty;
        string _metaDescriptions = string.Empty;
        string _JobDescription = string.Empty;
        string _JobType = string.Empty;

        public int JobID
        {
            get { return _JobID; }
            set { _JobID = value; }
        }
        public string JobName
        {
            get { return _JobName; }
            set { _JobName = value; }
        }
        public string JobNameURL
        {
            get { return _JobNameURL; }
            set { _JobNameURL = value; }
        }
        public int ActiveStatus
        {
            get { return _activeStatus; }
            set { _activeStatus = value; }
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
        public string MetaTitle
        {
            get { return _metaTitle; }
            set { _metaTitle = value; }
        }
        public string MetaKeywords
        {
            get { return _metaKeywords; }
            set { _metaKeywords = value; }
        }
        public string MetaDescriptions
        {
            get { return _metaDescriptions; }
            set { _metaDescriptions = value; }
        }
        string _MetaSchema = string.Empty;

        public string MetaSchema
        {
            get { return _MetaSchema; }
            set { _MetaSchema = value; }
        }

        public string JobDescription
        {
            get { return _JobDescription; }
            set { _JobDescription = value; }
        }

        public string JobType
        {
            get { return _JobType; }
            set { _JobType = value; }
        }
        #region Admin Panle
        public void SelectAllJob(System.Web.UI.WebControls.GridView JobGrid)
        {
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectAllJob");
                _SqlParameter[1] = new SqlParameter("@UpdatedBy", UpdatedBy);
                ObjSql.GdBind_SNO(JobGrid, "Mst_Sp_Job", _SqlParameter);
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

        public void SelectAllJobForDD(System.Web.UI.WebControls.DropDownList DdJob, string JobName, string JobID)
        {
            SqlParameter[] _SqlParameter = new SqlParameter[1];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectAllJobForDD");
                ObjSql.DdBing(DdJob, "Mst_Sp_Job", "JobName", "JobID", _SqlParameter);

            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure BindDdJob()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
        }

        public SqlDataReader SelectJobByID()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectJobByID");
                _SqlParameter[1] = new SqlParameter("@JobID", JobID);
                return ObjSql.GetDatareaderProc("Mst_Sp_Job", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure GetJobData()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.GetDatareaderProc("Mst_Sp_Job", _SqlParameter);
        }

        public int SaveNewJob()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[11];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SaveNewJob");
                _SqlParameter[1] = new SqlParameter("@JobName", JobName);
                _SqlParameter[2] = new SqlParameter("@ActiveStatus", ActiveStatus);
                _SqlParameter[3] = new SqlParameter("@JobNameURL", JobNameURL);
                _SqlParameter[4] = new SqlParameter("@MetaTitle", MetaTitle);
                _SqlParameter[5] = new SqlParameter("@MetaKeywords", MetaKeywords);
                _SqlParameter[6] = new SqlParameter("@MetaDescriptions", MetaDescriptions);
                _SqlParameter[7] = new SqlParameter("@MetaSchema", MetaSchema);
                _SqlParameter[8] = new SqlParameter("@JobDescription", JobDescription);
                _SqlParameter[9] = new SqlParameter("@JobType", JobType);
                _SqlParameter[10] = new SqlParameter("@UpdatedBy", UpdatedBy);
                return ObjSql.ExcuteProce("Mst_Sp_Job", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SaveJob()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_Job", _SqlParameter);
        }

        public int UpdateJobByID()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[13];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "UpdateJobByID");
                _SqlParameter[1] = new SqlParameter("@JobID", JobID);
                _SqlParameter[2] = new SqlParameter("@JobName", JobName);
                _SqlParameter[3] = new SqlParameter("@JobNameURL", JobNameURL);
                _SqlParameter[4] = new SqlParameter("@ActiveStatus", ActiveStatus);
                _SqlParameter[5] = new SqlParameter("@Updatedby", UpdatedBy);
                _SqlParameter[6] = new SqlParameter("@Updatedon", UpdatedOn);
                _SqlParameter[7] = new SqlParameter("@MetaTitle", MetaTitle);
                _SqlParameter[8] = new SqlParameter("@JobDescription", JobDescription);
                _SqlParameter[9] = new SqlParameter("@JobType", JobType);
                _SqlParameter[10] = new SqlParameter("@MetaKeywords", MetaKeywords);
                _SqlParameter[11] = new SqlParameter("@MetaDescriptions", MetaDescriptions);
                _SqlParameter[12] = new SqlParameter("@MetaSchema", MetaSchema);
                return ObjSql.ExcuteProce("Mst_Sp_Job", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure UpdateJobByID()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_Job", _SqlParameter);
        }



        public int DeletJobByID()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "DeletJobByID");
                _SqlParameter[1] = new SqlParameter("@JobID", JobID);
                return ObjSql.ExcuteProce("Mst_Sp_Job", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure DeletJobByID()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_Job", _SqlParameter);
        }
        #endregion

        #region Front End PAnel
        public void SelectAllAllJobForDD(System.Web.UI.WebControls.DropDownList DdJob, string JobName, string JobID)
        {
            SqlParameter[] _SqlParameter = new SqlParameter[1];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectAllAllJobForDD");
                ObjSql.DdBing(DdJob, "Mst_Sp_Job", "JobName", "JobID", _SqlParameter);

            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SelectAllAllJobForDD()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
        }

        public int SelectJobIDbyURL(string JobNameURL1)
        {
            int ID = 0;
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectJobIDbyURL");
                _SqlParameter[1] = new SqlParameter("@JobNameURL", JobNameURL1);
                ID = Convert.ToInt32(ObjSql.GetScalarProc("Mst_Sp_Job", _SqlParameter));
                return ID;
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SelectJobIDbyURL()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ID;
        }

        public int SelectMaxDisplayOrder()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[1];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectMaxDisplayOrder");
                return ObjSql.ExcuteProce("Mst_Sp_Job", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SelectMaxDisplayOrder()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_SubCategoryData", _SqlParameter);
        }

        public DataSet SelectAllActiveJob()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[1];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectAllActiveJob");
                return ObjSql.GetDsetProc("Mst_Sp_Job", _SqlParameter);
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Error in procedure SelectAllActiveJob()", ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.GetDsetProc("Mst_Sp_Job", _SqlParameter);
        }

        public DataSet SelectAllActiveJobDetail()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[3];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectAllActiveJobDetail");
                _SqlParameter[1] = new SqlParameter("@JobDescription", "JobDescription");
                _SqlParameter[2] = new SqlParameter("@JobType", "JobType");
                return ObjSql.GetDsetProc("Mst_Sp_Job", _SqlParameter);
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Error in procedure SelectAllActiveJob()", ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.GetDsetProc("Mst_Sp_Job", _SqlParameter);
        }

        #endregion
    }
}
