using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Utility;
using System.Web.UI.WebControls;

namespace Component
{
    public class ProductCategorySubCategoryData
    {
        public ProductCategorySubCategoryData()
        {
        }

        Connect ObjSql = new Connect();
        CommanFunction ObjComm = new CommanFunction();
        ManageException ObjEx = new ManageException();

        private int _ProductCategorySubCategoryID = 0;
        private int _ProductID = 0;
        private int _StoreID = 0;
        private int _CategoryID = 0;
        private int _SubCategoryID = 0;

        private int _activeStatus = 0;
        private string _updatedBy = string.Empty;
        private DateTime _updatedOn = DateTime.UtcNow;
        public int ProductCategorySubCategoryID
        {
            get { return _ProductCategorySubCategoryID; }
            set { _ProductCategorySubCategoryID = value; }
        }
        public int ProductID
        {
            get { return _ProductID; }
            set { _ProductID = value; }
        }
        public int SubCategoryID
        {
            get { return _SubCategoryID; }
            set { _SubCategoryID = value; }
        }
        public int CategoryID
        {
            get { return _CategoryID; }
            set { _CategoryID = value; }
        }
        public int StoreID
        {
            get { return _StoreID; }
            set { _StoreID = value; }
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

        #region Admin Panel
        public int SaveProductCategorySubCategoryData()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[4];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SaveProductCategorySubCategoryData");
                _SqlParameter[1] = new SqlParameter("@ProductID", ProductID);
                _SqlParameter[2] = new SqlParameter("@CategoryID", CategoryID);
                _SqlParameter[3] = new SqlParameter("@SubCategoryID", SubCategoryID);
                return ObjSql.ExcuteProce("Mst_Sp_ProductCategorySubCategory", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SaveProductCategorySubCategoryData()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_ProductCategorySubCategory", _SqlParameter);
        }

        public SqlDataReader GetProductCategorySubCategoryData()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[2];

            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "GetProductCategorySubCategoryData");
                _SqlParameter[1] = new SqlParameter("@ProductID", ProductID);
                return ObjSql.GetDatareaderProc("Mst_Sp_ProductCategorySubCategory", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure GetProductCategorySubCategoryData()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.GetDatareaderProc("Mst_Sp_ProductCategorySubCategory", _SqlParameter);
        }

        public int DeleteProductCategorySubCategoryData()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "DeleteProductCategorySubCategoryData");
                _SqlParameter[1] = new SqlParameter("@ProductID", ProductID);
                return ObjSql.ExcuteProce("Mst_Sp_ProductCategorySubCategory", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure DeleteProductCategorySubCategoryData()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_ProductCategorySubCategory", _SqlParameter);
        }
        #endregion
    }
}
