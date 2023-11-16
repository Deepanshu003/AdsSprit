using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Utility;

namespace Component
{
    public class Banner
    {
        Connect ObjSql = new Connect();
        CommanFunction ObjComm = new CommanFunction();
        ManageException ObjEx = new ManageException();

        public Banner()
        {
        }

        int _BannerBannerID = 0;
        string _BannerName = string.Empty;
        string _BannerNameURL = string.Empty;
        string _LargeImage = string.Empty;
        string _Description = string.Empty;
        int _activeStatus = 0;
        int _CategoryID = 0;
        string _updatedBy = string.Empty;
        DateTime _updatedOn = DateTime.UtcNow;
        string _metaTitle = string.Empty;
        string _metaKeywords = string.Empty;
        string _metaDescriptions = string.Empty;

        public int BannerID
        {
            get { return _BannerBannerID; }
            set { _BannerBannerID = value; }
        }
        public string BannerName
        {
            get { return _BannerName; }
            set { _BannerName = value; }
        }

        public int CategoryID
        {
            get { return _CategoryID; }
            set { _CategoryID = value; }
        }
        public string BannerNameURL
        {
            get { return _BannerNameURL; }
            set { _BannerNameURL = value; }
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
        public void SelectAllBanner(System.Web.UI.WebControls.GridView BannerGrid)
        {
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectAllBanner");
                _SqlParameter[1] = new SqlParameter("@UpdatedBy", UpdatedBy);
                ObjSql.GdBind_SNO(BannerGrid, "Mst_Sp_Banner", _SqlParameter);
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

        public DataSet SelectAllBannerforProductadd()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[1];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectAllBannerforProductadd");
                return ObjSql.GetDsetProc("Mst_Sp_Banner", _SqlParameter);
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Error in procedure SelectAllBannerforProductadd()", ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.GetDsetProc("Mst_Sp_Banner", _SqlParameter);
        }

        public void SelectAllBannerForDD(System.Web.UI.WebControls.DropDownList DdBanner, string BannerName, string BannerID)
        {
            SqlParameter[] _SqlParameter = new SqlParameter[1];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectAllBannerForDD");
                ObjSql.DdBing(DdBanner, "Mst_Sp_Banner", "BannerName", "BannerID", _SqlParameter);

            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure BindDdBanner()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
        }

        public SqlDataReader SelectBannerByID()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectBannerByID");
                _SqlParameter[1] = new SqlParameter("@BannerID", BannerID);
                return ObjSql.GetDatareaderProc("Mst_Sp_Banner", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure GetBannerData()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.GetDatareaderProc("Mst_Sp_Banner", _SqlParameter);
        }

        public int SaveNewBanner()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[12];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SaveNewBanner");
                _SqlParameter[1] = new SqlParameter("@BannerName", BannerName);
                _SqlParameter[2] = new SqlParameter("@LargeImage", LargeImage);
                _SqlParameter[3] = new SqlParameter("@Description", Description);
                _SqlParameter[4] = new SqlParameter("@ActiveStatus", ActiveStatus);
                _SqlParameter[5] = new SqlParameter("@BannerNameURL", BannerNameURL);
                _SqlParameter[6] = new SqlParameter("@MetaTitle", MetaTitle);
                _SqlParameter[7] = new SqlParameter("@MetaKeywords", MetaKeywords);
                _SqlParameter[8] = new SqlParameter("@MetaDescriptions", MetaDescriptions);
                _SqlParameter[9] = new SqlParameter("@MetaSchema", MetaSchema);
                _SqlParameter[10] = new SqlParameter("@CategoryID", CategoryID);
                _SqlParameter[11] = new SqlParameter("@UpdatedBy", UpdatedBy);
                return ObjSql.ExcuteProce("Mst_Sp_Banner", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SaveBanner()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_Banner", _SqlParameter);
        }

        public int UpdateBannerByID()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[14];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "UpdateBannerByID");
                _SqlParameter[1] = new SqlParameter("@BannerID", BannerID);
                _SqlParameter[2] = new SqlParameter("@BannerName", BannerName);
                _SqlParameter[3] = new SqlParameter("@BannerNameURL", BannerNameURL);
                _SqlParameter[4] = new SqlParameter("@LargeImage", LargeImage);
                _SqlParameter[5] = new SqlParameter("@Description", Description);
                _SqlParameter[6] = new SqlParameter("@ActiveStatus", ActiveStatus);
                _SqlParameter[7] = new SqlParameter("@Updatedby", UpdatedBy);
                _SqlParameter[8] = new SqlParameter("@Updatedon", UpdatedOn);
                _SqlParameter[9] = new SqlParameter("@MetaTitle", MetaTitle);
                _SqlParameter[10] = new SqlParameter("@MetaKeywords", MetaKeywords);
                _SqlParameter[11] = new SqlParameter("@MetaDescriptions", MetaDescriptions);
                _SqlParameter[12] = new SqlParameter("@MetaSchema", MetaSchema);
                _SqlParameter[13] = new SqlParameter("@CategoryID", CategoryID);
                return ObjSql.ExcuteProce("Mst_Sp_Banner", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure UpdateBannerByID()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_Banner", _SqlParameter);
        }

        public int UpdateBannerDisplayOrder()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[3];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "UpdateBannerDisplayOrder");
                _SqlParameter[1] = new SqlParameter("@BannerID", BannerID);
                return ObjSql.ExcuteProce("Mst_Sp_Banner", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure UpdateMainMenuDisplayOrder()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_Banner", _SqlParameter);
        }

        public int DeletBannerByID()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "DeletBannerByID");
                _SqlParameter[1] = new SqlParameter("@BannerID", BannerID);
                return ObjSql.ExcuteProce("Mst_Sp_Banner", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure DeletBannerByID()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_Banner", _SqlParameter);
        }
        #endregion

        #region Front End PAnel
        public void SelectAllAllBannerForDD(System.Web.UI.WebControls.DropDownList DdBanner, string BannerName, string BannerID)
        {
            SqlParameter[] _SqlParameter = new SqlParameter[1];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectAllAllBannerForDD");
                ObjSql.DdBing(DdBanner, "Mst_Sp_Banner", "BannerName", "BannerID", _SqlParameter);

            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SelectAllAllBannerForDD()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
        }

        public int SelectBannerIDbyURL(string BannerNameURL1)
        {
            int ID = 0;
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectBannerIDbyURL");
                _SqlParameter[1] = new SqlParameter("@BannerNameURL", BannerNameURL1);
                ID = Convert.ToInt32(ObjSql.GetScalarProc("Mst_Sp_Banner", _SqlParameter));
                return ID;
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SelectBannerIDbyURL()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ID;
        }

        public DataSet SelectDisplayValueImage()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[4];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectDisplayValueImage");
                _SqlParameter[1] = new SqlParameter("@LargeImage", LargeImage);
                _SqlParameter[2] = new SqlParameter("@Description", Description);
                _SqlParameter[3] = new SqlParameter("@BannerName", BannerName);
                return ObjSql.GetDsetProc("Mst_Sp_Banner", _SqlParameter);
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Error in procedure SelectDisplayImage()", ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.GetDsetProc("Mst_Sp_Banner", _SqlParameter);
        }

        public DataSet SelectBannerDisplay()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[3];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectDisplayValueImage1");
                _SqlParameter[1] = new SqlParameter("@BannerID", BannerID);
                _SqlParameter[2] = new SqlParameter("@LargeImage", LargeImage);
                return ObjSql.GetDsetProc("Mst_Sp_Banner", _SqlParameter);
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Error in procedure SelectDisplayImage()", ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.GetDsetProc("Mst_Sp_CategoryData", _SqlParameter);
        }

        public DataSet SelectBannerDisplay1()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[4];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectDisplayValueImage2");
                _SqlParameter[1] = new SqlParameter("@BannerID", BannerID);
                _SqlParameter[2] = new SqlParameter("@LargeImage", LargeImage);
                _SqlParameter[3] = new SqlParameter("@Description", Description);
                return ObjSql.GetDsetProc("Mst_Sp_Banner", _SqlParameter);
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Error in procedure SelectDisplayImage()", ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.GetDsetProc("Mst_Sp_CategoryData", _SqlParameter);
        }

        public DataSet SelectContactImage()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[1];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectContactImage");
                return ObjSql.GetDsetProc("Mst_Sp_Banner", _SqlParameter);
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Error in procedure SelectDisplayImage()", ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.GetDsetProc("Mst_Sp_CategoryData", _SqlParameter);
        }

        public DataSet SelectValueBanner()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[1];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectValueBanner");
                return ObjSql.GetDsetProc("Mst_Sp_Banner", _SqlParameter);
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Error in procedure SelectDisplayImage()", ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.GetDsetProc("Mst_Sp_CategoryData", _SqlParameter);
        }

        public DataSet SelectBusinessBanner()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[1];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectBusinessBanner");
                return ObjSql.GetDsetProc("Mst_Sp_Banner", _SqlParameter);
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Error in procedure SelectDisplayImage()", ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.GetDsetProc("Mst_Sp_CategoryData", _SqlParameter);
        }

        public DataSet Selectcsrbanner()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[1];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "Selectcsrbanner");
                return ObjSql.GetDsetProc("Mst_Sp_Banner", _SqlParameter);
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Error in procedure SelectDisplayImage()", ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.GetDsetProc("Mst_Sp_CategoryData", _SqlParameter);
        }

        public DataSet SelectCarrerbanner()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[1];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectCarrerbanner");
                return ObjSql.GetDsetProc("Mst_Sp_Banner", _SqlParameter);
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Error in procedure SelectDisplayImage()", ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.GetDsetProc("Mst_Sp_CategoryData", _SqlParameter);
        }
        #endregion
    }
}
