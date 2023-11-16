using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Utility;

namespace Component
{
    public class LeaderData
    {
        Connect ObjSql = new Connect();
        CommanFunction ObjComm = new CommanFunction();
        ManageException ObjEx = new ManageException();

        public LeaderData()
        {
        }


        int _LeaderDataID = 0;
        string _LeaderTitle = string.Empty;
        string _LeaderRole = string.Empty;
        int _LeaderLeaderID = 0;
        string _DefaultImg = string.Empty;
        string _largeImg = string.Empty;
        string _smallDescription = string.Empty;
        string _descriptions = string.Empty;
        int _activeStatus = 0;
        private int _SortOrder = 0;
        string _LeaderTitleURL = string.Empty;
        DateTime _postedDate = DateTime.UtcNow;
        string _updatedBy = string.Empty;
        DateTime _updatedOn = DateTime.UtcNow;
        string _metaTitle = string.Empty;
        string _metaKeywords = string.Empty;
        string _metaDescriptions = string.Empty;

        string _MetaSchema = string.Empty;

        public string MetaSchema
        {
            get { return _MetaSchema; }
            set { _MetaSchema = value; }
        }
        public int LeaderDataID
        {
            get { return _LeaderDataID; }
            set { _LeaderDataID = value; }
        }
        public string LeaderTitle
        {
            get { return _LeaderTitle; }
            set { _LeaderTitle = value; }
        }

        public string LeaderRole
        {
            get { return _LeaderRole; }
            set { _LeaderRole = value; }
        }
        public int LeaderID
        {
            get { return _LeaderLeaderID; }
            set { _LeaderLeaderID = value; }
        }
        public string DefaultImg
        {
            get { return _DefaultImg; }
            set { _DefaultImg = value; }
        }
        public string LargeImg
        {
            get { return _largeImg; }
            set { _largeImg = value; }
        }
        public string SmallDescription
        {
            get { return _smallDescription; }
            set { _smallDescription = value; }
        }
        public string Descriptions
        {
            get { return _descriptions; }
            set { _descriptions = value; }
        }
        public int ActiveStatus
        {
            get { return _activeStatus; }
            set { _activeStatus = value; }
        }
        public string LeaderTitleURL
        {
            get { return _LeaderTitleURL; }
            set { _LeaderTitleURL = value; }
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

        public int SortOrder
        {
            get { return _SortOrder; }
            set { _SortOrder = value; }
        }

        private int _DisplayOnHome = 0;

        public int DisplayOnHome
        {
            get { return _DisplayOnHome; }
            set { _DisplayOnHome = value; }
        }

        private string _VideoURl = string.Empty;

        public string VideoURl
        {
            get { return _VideoURl; }
            set { _VideoURl = value; }
        }

        #region Admin Panle
        public void SelectAllLeaderByLeaderIDorNot(System.Web.UI.WebControls.GridView BlogCategoryGrid)
        {
            SqlParameter[] _SqlParameter = new SqlParameter[3];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectAllLeaderByLeaderIDorNot");
                _SqlParameter[1] = new SqlParameter("@LeaderID", LeaderID);
                _SqlParameter[2] = new SqlParameter("@UpdatedBy", UpdatedBy);
                ObjSql.GdBind_SNO(BlogCategoryGrid, "Mst_Sp_LeaderData", _SqlParameter);
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

        public void SelectAllLeader(System.Web.UI.WebControls.GridView BlogCategoryGrid)
        {
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectAllLeaderByLeaderIDorNot");
                _SqlParameter[1] = new SqlParameter("@LeaderID", LeaderID);
                _SqlParameter[2] = new SqlParameter("@UpdatedBy", UpdatedBy);
                ObjSql.GdBind_SNO(BlogCategoryGrid, "Mst_Sp_LeaderData", _SqlParameter);
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


        public SqlDataReader SelectLeaderDataByLeaderDataID()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectLeaderDataByLeaderDataID");
                _SqlParameter[1] = new SqlParameter("@LeaderDataID", LeaderDataID);
                return ObjSql.GetDatareaderProc("Mst_Sp_LeaderData", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure GetLeaderData()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.GetDatareaderProc("Mst_Sp_LeaderData", _SqlParameter);
        }

        public int SaveNewLeaderData()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[18];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SaveNewLeaderData");
                _SqlParameter[1] = new SqlParameter("@LeaderID", LeaderID);
                _SqlParameter[2] = new SqlParameter("@LeaderTitle", LeaderTitle);
                _SqlParameter[3] = new SqlParameter("@LeaderTitleURL", LeaderTitleURL);
                _SqlParameter[4] = new SqlParameter("@LeaderRole", LeaderRole);
                _SqlParameter[5] = new SqlParameter("@DefaultImg", DefaultImg);
                _SqlParameter[6] = new SqlParameter("@SmallDescription", SmallDescription);
                _SqlParameter[7] = new SqlParameter("@Descriptions", Descriptions);
                _SqlParameter[8] = new SqlParameter("@ActiveStatus", ActiveStatus);
                _SqlParameter[9] = new SqlParameter("@PostedDate", PostedDate);
                _SqlParameter[10] = new SqlParameter("@MetaTitle", MetaTitle);
                _SqlParameter[11] = new SqlParameter("@MetaKeywords", MetaKeywords);
                _SqlParameter[12] = new SqlParameter("@MetaDescriptions", MetaDescriptions);
                _SqlParameter[13] = new SqlParameter("@LargeImg", LargeImg);
                _SqlParameter[14] = new SqlParameter("@MetaSchema", MetaSchema);
                _SqlParameter[15] = new SqlParameter("@VideoURl", VideoURl);
                _SqlParameter[16] = new SqlParameter("@SortOrder", SortOrder);
                _SqlParameter[17] = new SqlParameter("@UpdatedBy", UpdatedBy);
                return ObjSql.ExcuteProce("Mst_Sp_LeaderData", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SaveNewLeaderData()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_LeaderData", _SqlParameter);
        }

        public int UpdateLeaderDataByLeaderDataID()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[20];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "UpdateLeaderDataByLeaderDataID");
                _SqlParameter[1] = new SqlParameter("@LeaderDataID", LeaderDataID);
                _SqlParameter[2] = new SqlParameter("@LeaderID", LeaderID);
                _SqlParameter[3] = new SqlParameter("@LeaderTitle", LeaderTitle);
                _SqlParameter[4] = new SqlParameter("@LeaderTitleURL", LeaderTitleURL);
                _SqlParameter[5] = new SqlParameter("@LeaderRole", LeaderRole);
                _SqlParameter[6] = new SqlParameter("@DefaultImg", DefaultImg);
                _SqlParameter[7] = new SqlParameter("@SmallDescription", SmallDescription);
                _SqlParameter[8] = new SqlParameter("@Descriptions", Descriptions);
                _SqlParameter[9] = new SqlParameter("@ActiveStatus", ActiveStatus);
                _SqlParameter[10] = new SqlParameter("@PostedDate", PostedDate);
                _SqlParameter[11] = new SqlParameter("@Updatedby", UpdatedBy);
                _SqlParameter[12] = new SqlParameter("@Updatedon", UpdatedOn);
                _SqlParameter[13] = new SqlParameter("@MetaTitle", MetaTitle);
                _SqlParameter[14] = new SqlParameter("@MetaKeywords", MetaKeywords);
                _SqlParameter[15] = new SqlParameter("@VideoURl", VideoURl);
                _SqlParameter[16] = new SqlParameter("@MetaDescriptions", MetaDescriptions);
                _SqlParameter[17] = new SqlParameter("@SortOrder", SortOrder);
                _SqlParameter[18] = new SqlParameter("@LargeImg", LargeImg);
                _SqlParameter[19] = new SqlParameter("@MetaSchema", MetaSchema);
                return ObjSql.ExcuteProce("Mst_Sp_LeaderData", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure UpdateLeaderDataByLeaderDataID()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_LeaderData", _SqlParameter);
        }

        public int DeleteLeaderByLeaderDataID()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "DeleteLeaderByLeaderDataID");
                _SqlParameter[1] = new SqlParameter("@LeaderDataID", LeaderDataID);
                return ObjSql.ExcuteProce("Mst_Sp_LeaderData", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure DeleteLeaderByLeaderDataID()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_LeaderData", _SqlParameter);
        }
        #endregion

        #region front End
        public DataSet SelectAllActiveLeaderDataWithOrWitOutLeaderID()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectAllActiveLeaderDataWithOrWitOutLeaderID");
                _SqlParameter[1] = new SqlParameter("@LeaderID", LeaderID);
                return ObjSql.GetDsetProc("Mst_Sp_LeaderData", _SqlParameter);
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Error in procedure SelectAllActiveLeaderDataWithOrWitOutLeaderID()", ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.GetDsetProc("Mst_Sp_LeaderData", _SqlParameter);
        }

        public int SelectLeaderDataIDbyLeaderIDOrURL(string LeaderTitleURL1)
        {
            int ID = 0;
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectLeaderDataIDbyLeaderIDOrURL");
                //_SqlParameter[1] = new SqlParameter("@LeaderID", LeaderID);
                _SqlParameter[1] = new SqlParameter("@LeaderTitleURL", LeaderTitleURL1);
                ID = Convert.ToInt32(ObjSql.GetScalarProc("Mst_Sp_LeaderData", _SqlParameter));
                return ID;
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SelectLeaderDataIDbyLeaderIDOrURL()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ID;
        }

        public SqlDataReader SelectActiveLeaderDetailByLeaderDataID()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectActiveLeaderDetailByLeaderDataID");
                _SqlParameter[1] = new SqlParameter("@LeaderDataID", LeaderDataID);
                return ObjSql.GetDatareaderProc("Mst_Sp_LeaderData", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SelectActiveLeaderDetailByLeaderDataID()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.GetDatareaderProc("Mst_Sp_LeaderData", _SqlParameter);
        }

        public DataSet SelectTop3ActiveRealtedLeaderDataWithOrWitOutLeaderID()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[3];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectTop3ActiveRealtedLeaderDataWithOrWitOutLeaderID");
                _SqlParameter[1] = new SqlParameter("@LeaderID", LeaderID);
                _SqlParameter[2] = new SqlParameter("@LeaderDataID", LeaderDataID);
                return ObjSql.GetDsetProc("Mst_Sp_LeaderData", _SqlParameter);
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Error in procedure SelectTop3ActiveRealtedLeaderDataWithOrWitOutLeaderID()", ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.GetDsetProc("Mst_Sp_LeaderData", _SqlParameter);
        }

        public int UpdateLeaderTimeDisplayOrder()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[3];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "UpdateLeaderTimeDisplayOrder");
                _SqlParameter[1] = new SqlParameter("@LeaderDataID", LeaderDataID);
                _SqlParameter[2] = new SqlParameter("@SortOrder", SortOrder);
                return ObjSql.ExcuteProce("Mst_Sp_LeaderData", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure UpdateLeaderTimeDisplayOrder()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_LeaderData", _SqlParameter);
        }


        public DataSet SelectLeaderData()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[1];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectLeaderData");
                return ObjSql.GetDsetProc("Mst_Sp_LeaderData", _SqlParameter);
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Error in procedure SelectProductImagesforWhisky()", ex);
                return null;
            }
            finally
            {
                ObjSql.Disconnect();
            }
        }

        public DataSet SelectLeader()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[1];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectLeader");
                return ObjSql.GetDsetProc("Mst_Sp_LeaderData", _SqlParameter);
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Error in procedure SelectProductImagesforWhisky()", ex);
                return null;
            }
            finally
            {
                ObjSql.Disconnect();
            }
        }

        #endregion
    }
}
