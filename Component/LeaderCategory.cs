using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Utility;

namespace Component
{
    public class LeaderCategory
    {
        Connect ObjSql = new Connect();
        CommanFunction ObjComm = new CommanFunction();
        ManageException ObjEx = new ManageException();

        public LeaderCategory()
        {
        }

        int _blogLeaderID = 0;
        string _LeaderName = string.Empty;
        string _LeaderRole = string.Empty;
        string _LeaderNameURL = string.Empty;
        string _Description = string.Empty;
        int _activeStatus = 0;
        string _updatedBy = string.Empty;
        DateTime _updatedOn = DateTime.UtcNow;
        string _metaTitle = string.Empty;
        string _metaKeywords = string.Empty;
        string _metaDescriptions = string.Empty;

        public int LeaderID
        {
            get { return _blogLeaderID; }
            set { _blogLeaderID = value; }
        }
        public string LeaderName
        {
            get { return _LeaderName; }
            set { _LeaderName = value; }
        }

        public string LeaderRole
        {
            get { return _LeaderRole; }
            set { _LeaderRole = value; }
        }
        public string LeaderNameURL
        {
            get { return _LeaderNameURL; }
            set { _LeaderNameURL = value; }
        }

        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
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

        #region Admin Panle
        public void SelectAllLeader(System.Web.UI.WebControls.GridView LeaderGrid)
        {
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectAllLeader");
                _SqlParameter[1] = new SqlParameter("@UpdatedBy", UpdatedBy);
                ObjSql.GdBind_SNO(LeaderGrid, "Mst_Sp_Leader", _SqlParameter);
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

        public void SelectAllLeaderForDD(System.Web.UI.WebControls.DropDownList DdLeader, string LeaderName, string LeaderID)
        {
            SqlParameter[] _SqlParameter = new SqlParameter[1];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectAllLeaderForDD");
                ObjSql.DdBing(DdLeader, "Mst_Sp_Leader", "LeaderName", "LeaderID", _SqlParameter);

            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure BindDdLeader()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
        }

        public SqlDataReader SelectLeaderByID()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectLeaderByID");
                _SqlParameter[1] = new SqlParameter("@LeaderID", LeaderID);
                return ObjSql.GetDatareaderProc("Mst_Sp_Leader", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure GetLeaderData()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.GetDatareaderProc("Mst_Sp_Leader", _SqlParameter);
        }

        public int SaveNewLeader()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[11];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SaveNewLeader");
                _SqlParameter[1] = new SqlParameter("@LeaderName", LeaderName);
                _SqlParameter[2] = new SqlParameter("@ActiveStatus", ActiveStatus);
                _SqlParameter[3] = new SqlParameter("@LeaderRole", LeaderRole);
                _SqlParameter[4] = new SqlParameter("@LeaderNameURL", LeaderNameURL);
                _SqlParameter[5] = new SqlParameter("@MetaTitle", MetaTitle);
                _SqlParameter[6] = new SqlParameter("@MetaKeywords", MetaKeywords);
                _SqlParameter[7] = new SqlParameter("@MetaDescriptions", MetaDescriptions);
                _SqlParameter[8] = new SqlParameter("@MetaSchema", MetaSchema);
                _SqlParameter[9] = new SqlParameter("@Description", Description);
                _SqlParameter[10] = new SqlParameter("@UpdatedBy", UpdatedBy);
                return ObjSql.ExcuteProce("Mst_Sp_Leader", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SaveLeader()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_Leader", _SqlParameter);
        }

        public int UpdateLeaderByID()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[13];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "UpdateLeaderByID");
                _SqlParameter[1] = new SqlParameter("@LeaderID", LeaderID);
                _SqlParameter[2] = new SqlParameter("@LeaderName", LeaderName);
                _SqlParameter[3] = new SqlParameter("@LeaderRole", LeaderRole);
                _SqlParameter[4] = new SqlParameter("@LeaderNameURL", LeaderNameURL);
                _SqlParameter[5] = new SqlParameter("@ActiveStatus", ActiveStatus);
                _SqlParameter[6] = new SqlParameter("@Updatedby", UpdatedBy);
                _SqlParameter[7] = new SqlParameter("@Updatedon", UpdatedOn);
                _SqlParameter[8] = new SqlParameter("@MetaTitle", MetaTitle);
                _SqlParameter[9] = new SqlParameter("@MetaKeywords", MetaKeywords);
                _SqlParameter[10] = new SqlParameter("@MetaDescriptions", MetaDescriptions);
                _SqlParameter[11] = new SqlParameter("@Description", Description);
                _SqlParameter[12] = new SqlParameter("@MetaSchema", MetaSchema);
                return ObjSql.ExcuteProce("Mst_Sp_Leader", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure UpdateLeaderByID()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_Leader", _SqlParameter);
        }



        public int DeletLeaderByID()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "DeletLeaderByID");
                _SqlParameter[1] = new SqlParameter("@LeaderID", LeaderID);
                return ObjSql.ExcuteProce("Mst_Sp_Leader", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure DeletLeaderByID()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_Leader", _SqlParameter);
        }
        #endregion

        #region Front End PAnel
        public void SelectAllAllLeaderForDD(System.Web.UI.WebControls.DropDownList DdLeader, string LeaderName, string LeaderID)
        {
            SqlParameter[] _SqlParameter = new SqlParameter[1];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectAllAllLeaderForDD");
                ObjSql.DdBing(DdLeader, "Mst_Sp_Leader", "LeaderName", "LeaderID", _SqlParameter);

            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SelectAllAllLeaderForDD()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
        }

        public int SelectLeaderIDbyURL(string LeaderNameURL1)
        {
            int ID = 0;
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectLeaderIDbyURL");
                _SqlParameter[1] = new SqlParameter("@LeaderNameURL", LeaderNameURL1);
                ID = Convert.ToInt32(ObjSql.GetScalarProc("Mst_Sp_Leader", _SqlParameter));
                return ID;
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SelectLeaderIDbyURL()", Ex);
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
                return ObjSql.ExcuteProce("Mst_Sp_Leader", _SqlParameter);
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

        #endregion
    }
}
