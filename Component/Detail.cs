using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Utility;

namespace Component
{
    public class Detail
    {
        Connect ObjSql = new Connect();
        CommanFunction ObjComm = new CommanFunction();
        ManageException ObjEx = new ManageException();

        public Detail()
        {
        }

        int _DetailDetailID = 0;
        string _DetailName = string.Empty;
        string _DetailColor = string.Empty;
        string _DetailNOSE = string.Empty;
        string _DetailPalate = string.Empty;
        string _DetailABV = string.Empty;
        string _DetailNameURL = string.Empty;
        string _LargeImage = string.Empty;
        string _Description = string.Empty;
        int _activeStatus = 0;
        string _updatedBy = string.Empty;
        DateTime _updatedOn = DateTime.UtcNow;
        string _metaTitle = string.Empty;
        string _metaKeywords = string.Empty;
        string _metaDescriptions = string.Empty;

        public int DetailID
        {
            get { return _DetailDetailID; }
            set { _DetailDetailID = value; }
        }
        public string DetailName
        {
            get { return _DetailName; }
            set { _DetailName = value; }
        }

        public string DetailColor
        {
            get { return _DetailColor; }
            set { _DetailColor = value; }
        }

        public string DetailNOSE
        {
            get { return _DetailNOSE; }
            set { _DetailNOSE = value; }
        }
        public string DetailPalate
        {
            get { return _DetailPalate; }
            set { _DetailPalate = value; }
        }

        public string DetailABV
        {
            get { return _DetailABV; }
            set { _DetailABV = value; }
        }
        public string DetailNameURL
        {
            get { return _DetailNameURL; }
            set { _DetailNameURL = value; }
        }

        public string LargeImage
        {
            get { return _LargeImage; }
            set { _LargeImage = value; }
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
        public void SelectAllDetail(System.Web.UI.WebControls.GridView DetailGrid)
        {
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectAllDetail");
                _SqlParameter[1] = new SqlParameter("@UpdatedBy", UpdatedBy);
                ObjSql.GdBind_SNO(DetailGrid, "Mst_Sp_Detail", _SqlParameter);
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

        public DataSet SelectAllDetailforProductadd()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[1];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectAllDetailforProductadd");
                return ObjSql.GetDsetProc("Mst_Sp_Detail", _SqlParameter);
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Error in procedure SelectAllDetailforProductadd()", ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.GetDsetProc("Mst_Sp_Detail", _SqlParameter);
        }

        public void SelectAllDetailForDD(System.Web.UI.WebControls.DropDownList DdDetail, string DetailName, string DetailID)
        {
            SqlParameter[] _SqlParameter = new SqlParameter[1];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectAllDetailForDD");
                ObjSql.DdBing(DdDetail, "Mst_Sp_Detail", "DetailName", "DetailID", _SqlParameter);

            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure BindDdDetail()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
        }

        public SqlDataReader SelectDetailByID()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectDetailByID");
                _SqlParameter[1] = new SqlParameter("@DetailID", DetailID);
                return ObjSql.GetDatareaderProc("Mst_Sp_Detail", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure GetDetailData()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.GetDatareaderProc("Mst_Sp_Detail", _SqlParameter);
        }

        public int SaveNewDetail()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[15];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SaveNewDetail");
                _SqlParameter[1] = new SqlParameter("@DetailName", DetailName);
                _SqlParameter[2] = new SqlParameter("@DetailColor", DetailColor);
                _SqlParameter[3] = new SqlParameter("@DetailNOSE", DetailNOSE);
                _SqlParameter[4] = new SqlParameter("@DetailPalate", DetailPalate);
                _SqlParameter[5] = new SqlParameter("@DetailABV", DetailABV);
                _SqlParameter[6] = new SqlParameter("@LargeImage", LargeImage);
                _SqlParameter[7] = new SqlParameter("@Description", Description);
                _SqlParameter[8] = new SqlParameter("@ActiveStatus", ActiveStatus);
                _SqlParameter[9] = new SqlParameter("@DetailNameURL", DetailNameURL);
                _SqlParameter[10] = new SqlParameter("@MetaTitle", MetaTitle);
                _SqlParameter[11] = new SqlParameter("@MetaKeywords", MetaKeywords);
                _SqlParameter[12] = new SqlParameter("@MetaDescriptions", MetaDescriptions);
                _SqlParameter[13] = new SqlParameter("@MetaSchema", MetaSchema);
                _SqlParameter[14] = new SqlParameter("@UpdatedBy", UpdatedBy);
                return ObjSql.ExcuteProce("Mst_Sp_Detail", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SaveDetail()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_Detail", _SqlParameter);
        }

        public int UpdateDetailByID()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[16];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "UpdateDetailByID");
                _SqlParameter[1] = new SqlParameter("@DetailID", DetailID);
                _SqlParameter[2] = new SqlParameter("@DetailName", DetailName);
                _SqlParameter[3] = new SqlParameter("@DetailNameURL", DetailNameURL);
                _SqlParameter[4] = new SqlParameter("@DetailColor", DetailColor);
                _SqlParameter[3] = new SqlParameter("@DetailNOSE", DetailNOSE);
                _SqlParameter[5] = new SqlParameter("@DetailPalate", DetailPalate);
                _SqlParameter[6] = new SqlParameter("@DetailABV", DetailABV);
                _SqlParameter[7] = new SqlParameter("@LargeImage", LargeImage);
                _SqlParameter[8] = new SqlParameter("@Description", Description);
                _SqlParameter[9] = new SqlParameter("@ActiveStatus", ActiveStatus);
                _SqlParameter[10] = new SqlParameter("@Updatedby", UpdatedBy);
                _SqlParameter[11] = new SqlParameter("@Updatedon", UpdatedOn);
                _SqlParameter[12] = new SqlParameter("@MetaTitle", MetaTitle);
                _SqlParameter[13] = new SqlParameter("@MetaKeywords", MetaKeywords);
                _SqlParameter[14] = new SqlParameter("@MetaDescriptions", MetaDescriptions);
                _SqlParameter[15] = new SqlParameter("@MetaSchema", MetaSchema);                
                return ObjSql.ExcuteProce("Mst_Sp_Detail", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure UpdateDetailByID()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_Detail", _SqlParameter);
        }

        public int UpdateDetailDisplayOrder()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[3];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "UpdateDetailDisplayOrder");
                _SqlParameter[1] = new SqlParameter("@DetailID", DetailID);
                return ObjSql.ExcuteProce("Mst_Sp_Detail", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure UpdateMainMenuDisplayOrder()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_Detail", _SqlParameter);
        }

        public int DeletDetailByID()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "DeletDetailByID");
                _SqlParameter[1] = new SqlParameter("@DetailID", DetailID);
                return ObjSql.ExcuteProce("Mst_Sp_Detail", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure DeletDetailByID()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_Detail", _SqlParameter);
        }
        #endregion

        #region Front End PAnel
        public void SelectAllAllDetailForDD(System.Web.UI.WebControls.DropDownList DdDetail, string DetailName, string DetailID)
        {
            SqlParameter[] _SqlParameter = new SqlParameter[1];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectAllAllDetailForDD");
                ObjSql.DdBing(DdDetail, "Mst_Sp_Detail", "DetailName", "DetailID", _SqlParameter);

            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SelectAllAllDetailForDD()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
        }

        public int SelectDetailIDbyURL(string DetailNameURL1)
        {
            int ID = 0;
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectDetailIDbyURL");
                _SqlParameter[1] = new SqlParameter("@DetailNameURL", DetailNameURL1);
                ID = Convert.ToInt32(ObjSql.GetScalarProc("Mst_Sp_Detail", _SqlParameter));
                return ID;
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SelectDetailIDbyURL()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ID;
        }

        #endregion
    }
}
