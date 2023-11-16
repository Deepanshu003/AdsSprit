using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Utility;
using System.Web.UI.WebControls;

namespace Component
{
    public class ProductAwards
    {
        Connect ObjSql = new Connect();
        CommanFunction ObjComm = new CommanFunction();
        ManageException ObjEx = new ManageException();
        public ProductAwards()
        { }

        private int _productAwardsID = 0;
        private int _AwardsID = 0;
        private int _productID = 0;
        private string _productDefaultImageByAwards = string.Empty;
        private string _productImage1ByAwards = string.Empty;
        private string _productImage2ByAwards = string.Empty;
        private string _productImage3ByAwards = string.Empty;
        private int _activeStatus = 0;
        private string _updatedBy = string.Empty;
        private DateTime _updatedOn = DateTime.UtcNow;
        private string _productIDs = string.Empty;

        public int ProductAwardsID
        {
            get { return _productAwardsID; }
            set { _productAwardsID = value; }
        }
        public int AwardsID
        {
            get { return _AwardsID; }
            set { _AwardsID = value; }
        }
        public int ProductID
        {
            get { return _productID; }
            set { _productID = value; }
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
        public string ProductIDs
        {
            get { return _productIDs; }
            set { _productIDs = value; }
        }

        #region Admin Panel
        public int SaveProductAwards()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[3];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SAVEPRODUCTAwards");
                _SqlParameter[1] = new SqlParameter("@ProductID", ProductID);
                _SqlParameter[2] = new SqlParameter("@AwardsID", AwardsID);

                return ObjSql.ExcuteProce("Mst_Sp_ProductAwards", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SaveProductAwards()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_ProductAwards", _SqlParameter);
        }

        public SqlDataReader GetProductAwardsData()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[2];

            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "GETPRODUCTAwardsNDATA");
                _SqlParameter[1] = new SqlParameter("@ProductID", ProductID);
                return ObjSql.GetDatareaderProc("Mst_Sp_ProductAwards", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure GetProductAwardsData()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.GetDatareaderProc("Mst_Sp_ProductAwards", _SqlParameter);
        }

        public int DeleteProductByAwards()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "DELETEPRODUCTAwards");
                _SqlParameter[1] = new SqlParameter("@ProductID", ProductID);


                return ObjSql.ExcuteProce("Mst_Sp_ProductAwards", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure DeleteProductByAwards()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_ProductAwards", _SqlParameter);
        }
        #endregion Admin Panel
    }
}
