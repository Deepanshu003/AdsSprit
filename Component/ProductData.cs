using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Utility;
using System.Data;
namespace Component
{
    public class ProductData
    {
        Connect ObjSql = new Connect();
        CommanFunction ObjComm = new CommanFunction();
        ManageException ObjEx = new ManageException();

        public ProductData()
        {
        }
        private int _ProductID = 0;
        private string _ProductName = string.Empty;
        private string _DetailName = string.Empty;
        private string _DetailColor = string.Empty;
        private string _DetailNOSE = string.Empty;
        private string _DetailPalate = string.Empty;
        private string _DetailABV = string.Empty;
        private string _ProductNameAlias = string.Empty;
        private int _categoryID = 0;
        private string _ProductDefaultImage = string.Empty;
        private string _ProductImage1 = string.Empty;
        private string _ProductImage2 = string.Empty;

        private string _ProductDescription = string.Empty;
        private string _SmallDescription = string.Empty;
        private string _ProductIngredients = string.Empty;
        private string _ProductDetailDescription = string.Empty;        

        private string _AwardName = string.Empty;
        private string _AwardDescription = string.Empty;
        private string _AwardImage = string.Empty;

        private string _TastingNotes = string.Empty;

        public string SmallDescription
        {
            get { return _SmallDescription; }
            set { _SmallDescription = value; }
        }


        private int _displayOrder = 0;
        private int _activeStatus = 0;
        private int _displayOnHome = 0;
        private string _updatedBy = string.Empty;
        private DateTime _updatedOn = DateTime.UtcNow;
        private string _metaTitle = string.Empty;
        private string _metaKeyword = string.Empty;
        private string _metaDescription = string.Empty;
        private string _sortOrder = string.Empty;
        private string _ProductSearch = string.Empty;
        private string _ProductCode = string.Empty;

        public string ProductCode
        {
            get { return _ProductCode; }
            set { _ProductCode = value; }
        }
        private string _ProductBenefits = string.Empty;

        public string ProductBenefits
        {
            get { return _ProductBenefits; }
            set { _ProductBenefits = value; }
        }
        private string _ProductApplication = string.Empty;

        public string ProductApplication
        {
            get { return _ProductApplication; }
            set { _ProductApplication = value; }
        }
        private string _ProductCharacterstics = string.Empty;

        public string ProductCharacterstics
        {
            get { return _ProductCharacterstics; }
            set { _ProductCharacterstics = value; }
        }
        private string _ProductNotice = string.Empty;

        public string ProductNotice
        {
            get { return _ProductNotice; }
            set { _ProductNotice = value; }
        }

        public int ProductID
        {
            get { return _ProductID; }
            set { _ProductID = value; }
        }
        public string ProductName
        {
            get { return _ProductName; }
            set { _ProductName = value; }
        }
        public string ProductNameAlias
        {
            get { return _ProductNameAlias; }
            set { _ProductNameAlias = value; }
        }
        public int CategoryID
        {
            get { return _categoryID; }
            set { _categoryID = value; }
        }
        public string ProductDefaultImage
        {
            get { return _ProductDefaultImage; }
            set { _ProductDefaultImage = value; }
        }
        public string ProductImage1
        {
            get { return _ProductImage1; }
            set { _ProductImage1 = value; }
        }
        public string ProductImage2
        {
            get { return _ProductImage2; }
            set { _ProductImage2 = value; }
        }

        public string ProductDescription
        {
            get { return _ProductDescription; }
            set { _ProductDescription = value; }
        }

        public string ProductDetailDescription
        {
            get { return _ProductDetailDescription; }
            set { _ProductDetailDescription = value; }
        }

        public string ProductIngredients
        {
            get { return _ProductIngredients; }
            set { _ProductIngredients = value; }
        }

        public string TastingNotes
        {
            get { return _TastingNotes; }
            set { _TastingNotes = value; }
        }

        public int DisplayOrder
        {
            get { return _displayOrder; }
            set { _displayOrder = value; }
        }
        public int ActiveStatus
        {
            get { return _activeStatus; }
            set { _activeStatus = value; }
        }
        public int DisplayOnHome
        {
            get { return _displayOnHome; }
            set { _displayOnHome = value; }
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
        public string MetaKeyword
        {
            get { return _metaKeyword; }
            set { _metaKeyword = value; }
        }
        public string MetaDescription
        {
            get { return _metaDescription; }
            set { _metaDescription = value; }
        }
        public string SortOrder
        {
            get { return _sortOrder; }
            set { _sortOrder = value; }
        }

        public string ProductSearch
        {
            get { return _ProductSearch; }
            set { _ProductSearch = value; }
        }

        string _MetaSchema = string.Empty;

        public string MetaSchema
        {
            get { return _MetaSchema; }
            set { _MetaSchema = value; }
        }

        private string _WhereCondition = string.Empty;

        public string WhereCondition
        {
            get { return _WhereCondition; }
            set { _WhereCondition = value; }
        }
        private string _WherePackage = string.Empty;

        public string WherePackage
        {
            get { return _WherePackage; }
            set { _WherePackage = value; }
        }

        private int _PackageID = 0;

        public int PackageID
        {
            get { return _PackageID; }
            set { _PackageID = value; }
        }
        private string _WhereColor = string.Empty;

        public string WhereColor
        {
            get { return _WhereColor; }
            set { _WhereColor = value; }
        }
        private int _ColorID = 0;

        public int ColorID
        {
            get { return _ColorID; }
            set { _ColorID = value; }
        }
        private int _DisplayOnNewProduct = 0;

        public int DisplayOnNewProduct
        {
            get { return _DisplayOnNewProduct; }
            set { _DisplayOnNewProduct = value; }
        }
        private int _BestSeller = 0;

        public int BestSeller
        {
            get { return _BestSeller; }
            set { _BestSeller = value; }
        }
        
        private string _TimeIntervalHours = string.Empty;

        public string TimeIntervalHours
        {
            get { return _TimeIntervalHours; }
            set { _TimeIntervalHours = value; }
        }
        private string _TimeIntervalMinute = string.Empty;

        public string TimeIntervalMinute
        {
            get { return _TimeIntervalMinute; }
            set { _TimeIntervalMinute = value; }
        }
        private int _TaxAmountPercentage = 0;

        public int TaxAmountPercentage
        {
            get { return _TaxAmountPercentage; }
            set { _TaxAmountPercentage = value; }
        }
        private string _GSTHSNCode = string.Empty;

        public string GSTHSNCode
        {
            get { return _GSTHSNCode; }
            set { _GSTHSNCode = value; }
        }
       
        private string _ProductImage3 = string.Empty;

        public string ProductImage3
        {
            get { return _ProductImage3; }
            set { _ProductImage3 = value; }
        }
        private int _OccasionID = 0;

        public int OccasionID
        {
            get { return _OccasionID; }
            set { _OccasionID = value; }
        }
      
        private string _WhereCategoryCondition = string.Empty;

        public string WhereCategoryCondition
        {
            get { return _WhereCategoryCondition; }
            set { _WhereCategoryCondition = value; }
        }
        private string _WhereSubCategoryCondition = string.Empty;

        public string WhereSubCategoryCondition
        {
            get { return _WhereSubCategoryCondition; }
            set { _WhereSubCategoryCondition = value; }
        }
        
        private string _WhereOccasionCondition = string.Empty;

        public string WhereOccasionCondition
        {
            get { return _WhereOccasionCondition; }
            set { _WhereOccasionCondition = value; }
        }
        private int _PageIndex = 0;

        public int PageIndex
        {
            get { return _PageIndex; }
            set { _PageIndex = value; }
        }
        private string _WhereConditionCatgeory = string.Empty;

        public string WhereConditionCatgeory
        {
            get { return _WhereConditionCatgeory; }
            set { _WhereConditionCatgeory = value; }
        }
        string _WhereIDData = string.Empty;
        string _WhereActiveStatus = string.Empty;
        public string WhereIDData
        {
            get { return _WhereIDData; }
            set { _WhereIDData = value; }
        }
        public string WhereActiveStatus
        {
            get { return _WhereActiveStatus; }
            set { _WhereActiveStatus = value; }
        }       
        private int _SubCategoryID = 0;

        public int SubCategoryID
        {
            get { return _SubCategoryID; }
            set { _SubCategoryID = value; }
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

        public string AwardName
        {
            get { return _AwardName; }
            set { _AwardName = value; }
        }

        public string AwardDescription
        {
            get { return _AwardDescription; }
            set { _AwardDescription = value; }
        }

        public string AwardImage
        {
            get { return _AwardImage; }
            set { _AwardImage = value; }
        }
        #region Admin Panel
        public void SelectAllProductsData(System.Web.UI.WebControls.GridView GvAmenitiesGrid)
        {
            SqlParameter[] _SqlParameter = new SqlParameter[3];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectAllProductsData");
                _SqlParameter[1] = new SqlParameter("@CategoryID", CategoryID);
                _SqlParameter[2] = new SqlParameter("@UpdatedBy", UpdatedBy);
                ObjSql.GdBind_SNO(GvAmenitiesGrid, "Mst_Sp_ProductData", _SqlParameter);

            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SelectAllProductsData()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
        }
              

        public SqlDataReader SelectProductByProductID()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[2];

            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectProductByProductID");
                _SqlParameter[1] = new SqlParameter("@ProductID", ProductID);
                return ObjSql.GetDatareaderProc("Mst_Sp_ProductData", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SelectProductByProductID()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.GetDatareaderProc("Mst_Sp_ProductData", _SqlParameter);
        }

        public int SaveNewProductData()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[31];
            try
            {
                _SqlParameter[0]  = new SqlParameter("@Action", "SaveNewProductData");
                _SqlParameter[1]  = new SqlParameter("@ProductName", ProductName);
                _SqlParameter[2]  = new SqlParameter("@ProductNameAlias", ProductNameAlias);
                _SqlParameter[3]  = new SqlParameter("@CategoryID", CategoryID);
                _SqlParameter[4]  = new SqlParameter("@MetaDescription", MetaDescription);
                _SqlParameter[5]  = new SqlParameter("@ProductDefaultImage", ProductDefaultImage);
                _SqlParameter[6]  = new SqlParameter("@ProductImage1", ProductImage1);
                _SqlParameter[7]  = new SqlParameter("@ProductImage2", ProductImage2);
                _SqlParameter[8]  = new SqlParameter("@ProductDescription", ProductDescription);
                _SqlParameter[9]  = new SqlParameter("@SmallDescription", SmallDescription);
                _SqlParameter[10] = new SqlParameter("@DisplayOrder", DisplayOrder);
                _SqlParameter[11] = new SqlParameter("@ProductCode", ProductCode);
                _SqlParameter[12] = new SqlParameter("@ActiveStatus", ActiveStatus);
                _SqlParameter[13] = new SqlParameter("@DisplayOnHome", DisplayOnHome);
                _SqlParameter[14] = new SqlParameter("@MetaTitle", MetaTitle);
                _SqlParameter[15] = new SqlParameter("@MetaKeyword", MetaKeyword);
                _SqlParameter[16] = new SqlParameter("@MetaSchema", MetaSchema);
                _SqlParameter[17] = new SqlParameter("@DisplayOnNewProduct", DisplayOnNewProduct);
                _SqlParameter[18] = new SqlParameter("@ProductImage3", ProductImage3);
                _SqlParameter[19] = new SqlParameter("@UpdatedBy", UpdatedBy);
                _SqlParameter[20] = new SqlParameter("@DetailName", DetailName);
                _SqlParameter[21] = new SqlParameter("@DetailColor", DetailColor);
                _SqlParameter[22] = new SqlParameter("@DetailNOSE", DetailNOSE);
                _SqlParameter[23] = new SqlParameter("@DetailPalate", DetailPalate);
                _SqlParameter[24] = new SqlParameter("@DetailABV", DetailABV);
                _SqlParameter[25] = new SqlParameter("@AwardName", AwardName);
                _SqlParameter[26] = new SqlParameter("@AwardDescription", AwardDescription);
                _SqlParameter[27] = new SqlParameter("@AwardImage", AwardImage);
                _SqlParameter[28] = new SqlParameter("@ProductIngredients", ProductIngredients);
                _SqlParameter[29] = new SqlParameter("@ProductDetailDescription", ProductDetailDescription);
                _SqlParameter[30] = new SqlParameter("@TastingNotes", TastingNotes);
                return ObjSql.ExcuteProce("Mst_Sp_ProductData", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SaveNewProductData()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_ProductData", _SqlParameter);
        }

        public int UpdateProductByProductID()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[33];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "UpdateProductByProductID");
                _SqlParameter[1] = new SqlParameter("@ProductID", ProductID);
                _SqlParameter[2] = new SqlParameter("@ProductName", ProductName);
                _SqlParameter[3] = new SqlParameter("@ProductNameAlias", ProductNameAlias);
                _SqlParameter[4] = new SqlParameter("@CategoryID", CategoryID);
                _SqlParameter[5] = new SqlParameter("@ProductDefaultImage", ProductDefaultImage);
                _SqlParameter[6] = new SqlParameter("@ProductImage1", ProductImage1);
                _SqlParameter[7] = new SqlParameter("@ProductImage2", ProductImage2);
                _SqlParameter[8] = new SqlParameter("@ProductDescription", ProductDescription);
                _SqlParameter[9] = new SqlParameter("@SmallDescription", SmallDescription);
                _SqlParameter[10] = new SqlParameter("@DisplayOrder", DisplayOrder);
                _SqlParameter[11] = new SqlParameter("@ActiveStatus", ActiveStatus);
                _SqlParameter[12] = new SqlParameter("@DisplayOnHome", DisplayOnHome);
                _SqlParameter[13] = new SqlParameter("@MetaTitle", MetaTitle);
                _SqlParameter[14] = new SqlParameter("@MetaKeyword", MetaKeyword);
                _SqlParameter[15] = new SqlParameter("@MetaDescription", MetaDescription);
                _SqlParameter[16] = new SqlParameter("@UpdatedBy", UpdatedBy);
                _SqlParameter[17] = new SqlParameter("@UpdatedOn", UpdatedOn);
                _SqlParameter[18] = new SqlParameter("@ProductCode", ProductCode);
                _SqlParameter[19] = new SqlParameter("@MetaSchema", MetaSchema);
                _SqlParameter[20] = new SqlParameter("@DisplayOnNewProduct", DisplayOnNewProduct);
                _SqlParameter[21] = new SqlParameter("@ProductImage3", ProductImage3);
                _SqlParameter[22] = new SqlParameter("@DetailName", DetailName);
                _SqlParameter[23] = new SqlParameter("@DetailColor", DetailColor);
                _SqlParameter[24] = new SqlParameter("@DetailNOSE", DetailNOSE);
                _SqlParameter[25] = new SqlParameter("@DetailPalate", DetailPalate);
                _SqlParameter[26] = new SqlParameter("@DetailABV", DetailABV);
                _SqlParameter[27] = new SqlParameter("@AwardName", AwardName);
                _SqlParameter[28] = new SqlParameter("@AwardDescription", AwardDescription);
                _SqlParameter[29] = new SqlParameter("@AwardImage", AwardImage);
                _SqlParameter[30] = new SqlParameter("@ProductIngredients", ProductIngredients);
                _SqlParameter[31] = new SqlParameter("@ProductDetailDescription", ProductDetailDescription);
                _SqlParameter[32] = new SqlParameter("@TastingNotes", TastingNotes);
                return ObjSql.ExcuteProce("Mst_Sp_ProductData", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure UpdateProductByProductID()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_ProductData", _SqlParameter);
        }

        public int DeleteProductByProductID()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "DeleteProductByProductID");
                _SqlParameter[1] = new SqlParameter("@ProductID", ProductID);

                return ObjSql.ExcuteProce("Mst_Sp_ProductData", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure DeleteProductByProductID()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_ProductData", _SqlParameter);
        }


        public int RemoveProductImage2ByProductID()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "RemoveProductImage2ByProductID");
                _SqlParameter[1] = new SqlParameter("@ProductID", ProductID);
                return ObjSql.ExcuteProce("Mst_Sp_ProductData", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure RemoveProductImage2ByProductID()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_ProductData", _SqlParameter);
        }

        public int RemoveProductImage3ByProductID()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "RemoveProductImage3ByProductID");
                _SqlParameter[1] = new SqlParameter("@ProductID", ProductID);
                return ObjSql.ExcuteProce("Mst_Sp_ProductData", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure RemoveProductImage3ByProductID()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_ProductData", _SqlParameter);
        }

        public int RemoveProductImage4ByProductID()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "RemoveProductImage4ByProductID");
                _SqlParameter[1] = new SqlParameter("@ProductID", ProductID);
                return ObjSql.ExcuteProce("Mst_Sp_ProductData", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure RemoveProductImage4ByProductID()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_ProductData", _SqlParameter);
        }      

        public int SelectMaxDisplayOrder()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[1];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectMaxDisplayOrder");
                return ObjSql.ExcuteProce("Mst_Sp_ProductData", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SelectMaxDisplayOrder()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_ProductData", _SqlParameter);
        }
        #endregion

        #region Front End

        public DataSet SelectFooterDisplay()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectProductIDByProductTitleURL");
                _SqlParameter[1] = new SqlParameter("@ProductNameAlias", ProductNameAlias);

                return ObjSql.GetDsetProc("Mst_Sp_ProductData", _SqlParameter);
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Error in procedure SelectFooterDisplay", ex);
                return null; // Return null to handle the error gracefully.
            }
            finally
            {
                ObjSql.Disconnect();
            }
        }
        public DataSet SearchTextAutoResult()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SearchTextAutoResult");
                _SqlParameter[1] = new SqlParameter("@ProductSearch", ProductSearch);
                return ObjSql.GetDsetProc("Mst_Sp_ProductData", _SqlParameter);
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Error in procedure SearchTextAutoResult()", ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.GetDsetProc("Mst_Sp_ProductData", _SqlParameter);
        }

        public DataSet SelectTop8ActiveFeaturedProductByDisplayOnHome()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[1];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectTop8ActiveFeaturedProductByDisplayOnHome");
                return ObjSql.GetDsetProc("Mst_Sp_ProductData", _SqlParameter);
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Error in procedure SelectTop8ActiveFeaturedProductByDisplayOnHome()", ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.GetDsetProc("Mst_Sp_ProductData", _SqlParameter);
        }

        public DataSet SelectTop7ActiveOccasionProductByOccasionIDForHomeWithSamePriceing()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectTop7ActiveOccasionProductByOccasionIDForHomeWithSamePriceing");
                _SqlParameter[1] = new SqlParameter("@OccasionID", OccasionID);
                return ObjSql.GetDsetProc("Mst_Sp_ProductData", _SqlParameter);
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Error in procedure SelectTop7ActiveOccasionProductByOccasionIDForHomeWithSamePriceing()", ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.GetDsetProc("Mst_Sp_ProductData", _SqlParameter);
        }

        public DataSet SelectTop4ActivePhoteCakeProductForDisplayOnHomeWithSamePriceing()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[1];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectTop4ActivePhoteCakeProductForDisplayOnHomeWithSamePriceing");
                return ObjSql.GetDsetProc("Mst_Sp_ProductData", _SqlParameter);
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Error in procedure SelectTop4ActivePhoteCakeProductForDisplayOnHomeWithSamePriceing()", ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.GetDsetProc("Mst_Sp_ProductData", _SqlParameter);
        }

        public DataSet SelectTop16ActiveBestSellerProductByBestSellerForHome()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[1];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectTop16ActiveBestSellerProductByBestSellerForHome");
                return ObjSql.GetDsetProc("Mst_Sp_ProductData", _SqlParameter);
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Error in procedure v()", ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.GetDsetProc("Mst_Sp_ProductData", _SqlParameter);
        }

        public DataSet SelectAllActiveProductDataByWithCondition()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[4];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectAllActiveProductDataByWithCondition");
                _SqlParameter[1] = new SqlParameter("@WhereCategoryCondition", WhereCategoryCondition);
                _SqlParameter[2] = new SqlParameter("@WhereSubCategoryCondition", WhereSubCategoryCondition);
                _SqlParameter[3] = new SqlParameter("@WhereOccasionCondition", WhereOccasionCondition);
                return ObjSql.GetDsetProc("Mst_Sp_ProductData", _SqlParameter);
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Error in procedure SelectAllActiveProductDataByWithCondition()", ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.GetDsetProc("Mst_Sp_ProductData", _SqlParameter);
        }

        public int SelectProductIDbyProductNameAlias(string ProductNameAlias)
        {
            int ID = 0;
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectProductIDbyProductNameAlias");
                _SqlParameter[1] = new SqlParameter("@ProductNameAlias", ProductNameAlias);
                ID = Convert.ToInt32(ObjSql.GetScalarProc("Mst_Sp_ProductData", _SqlParameter));
                return ID;
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SelectProductIDbyProductNameAlias()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ID;
        }


        public SqlDataReader SelectActiveProductDataByProductID()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[2];

            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectActiveProductDataByProductID");
                _SqlParameter[1] = new SqlParameter("@ProductID", ProductID);
                return ObjSql.GetDatareaderProc("Mst_Sp_ProductData", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SelectActiveProductDataByProductID()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.GetDatareaderProc("Mst_Sp_ProductData", _SqlParameter);
        }



        public DataSet SelectDisplayImage()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[1];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectDisplayImage");
                return ObjSql.GetDsetProc("Mst_Sp_ProductData", _SqlParameter);
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

        public DataSet SelectBannerImageOfProducts()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[1];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectBannerImageOfProducts");
                return ObjSql.GetDsetProc("Mst_Sp_ProductData", _SqlParameter);
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

        public DataSet SelectProductBannerImage()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectProductBannerImage");
                _SqlParameter[1] = new SqlParameter("@ProductID", ProductID);               
                return ObjSql.GetDsetProc("Mst_Sp_ProductData", _SqlParameter);
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Error in procedure SelectProductBannerImage()", ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.GetDsetProc("Mst_Sp_CategoryData", _SqlParameter);
        }       
        public DataSet SelectProductBannerImageAndDetail()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectProductBannerImageAndDetail");
                _SqlParameter[1] = new SqlParameter("@ProductID", ProductID);
                return ObjSql.GetDsetProc("Mst_Sp_ProductData", _SqlParameter);
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Error in procedure SelectProductBannerImage()", ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.GetDsetProc("Mst_Sp_CategoryData", _SqlParameter);
        }



        public DataSet SelectAllActiveProductForMenu()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[1];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectAllActiveProductForMenu");           
                return ObjSql.GetDsetProc("Mst_Sp_ProductData", _SqlParameter);
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Error in procedure SelectAllActiveProductForMenu()", ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.GetDsetProc("Mst_Sp_ProductData", _SqlParameter);
        }

        public DataSet SelectAllActiveProductForFooter()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[1];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectAllActiveProductForFooter");
                return ObjSql.GetDsetProc("Mst_Sp_ProductData", _SqlParameter);
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Error in procedure SelectAllActiveProductForMenu()", ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.GetDsetProc("Mst_Sp_ProductData", _SqlParameter);
        }

        public DataSet SelectAllActiveLinks()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[1];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectAllActiveLinks");
                return ObjSql.GetDsetProc("Mst_Sp_ProductData", _SqlParameter);
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Error in procedure SelectAllActiveProductForMenu()", ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.GetDsetProc("Mst_Sp_ProductData", _SqlParameter);
        }  
        public int SelectProductIDByProductCategoryIDORProductTitleURL(string ProductNameAlias)
        {
            int ID = 0;
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectProductIDByProductCategoryIDORProductTitleURL");   
                _SqlParameter[1] = new SqlParameter("@ProductNameAlias", ProductNameAlias);
                ID = Convert.ToInt32(ObjSql.GetScalarProc("Mst_Sp_ProductData", _SqlParameter));
                return ID;
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SelectProductIDByProductCategoryIDORProductTitleURL()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ID;
        }



 /*       public DataSet SelectProductImagesforWhisky(int ProductID)
        {
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectProductImagesforWhisky");
                _SqlParameter[1] = new SqlParameter("@ProductID", ProductID);
                return ObjSql.GetDsetProc("Mst_Sp_ProductData", _SqlParameter); 
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Error in procedure SelectProductImagesforWhisky()", ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return null; // Return null if there's an error
        }  */

        public DataSet SelectProductData()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[1];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectProductData");
                return ObjSql.GetDsetProc("Mst_Sp_ProductData", _SqlParameter);
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

   /*     public DataSet SelectProductImagesforWhisky1(int ProductID)
        {
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectProductImagesforWhisky1");
                _SqlParameter[1] = new SqlParameter("@ProductID", ProductID);
                return ObjSql.GetDsetProc("Mst_Sp_ProductData", _SqlParameter);
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
        }  */

        public DataSet SelectRelatedProducts(int ProductID, int CategoryID)
        {
            SqlParameter[] _SqlParameter = new SqlParameter[3];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectRelatedProducts");
                _SqlParameter[1] = new SqlParameter("@ProductID", ProductID);
                _SqlParameter[2] = new SqlParameter("@CategoryID", CategoryID);
                return ObjSql.GetDsetProc("Mst_Sp_ProductData", _SqlParameter);
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Error in procedure SelectRelatedProducts()", ex);
                return null;
            }
            finally
            {
                ObjSql.Disconnect();
            }
        }


        public int SelectProductIDByProductTitleURL(string ProductNameAlias)
        {
            int ID = 0;
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectProductIDByProductTitleURL");
                _SqlParameter[1] = new SqlParameter("@ProductNameAlias", ProductNameAlias);
                ID = Convert.ToInt32(ObjSql.GetScalarProc("Mst_Sp_ProductData", _SqlParameter));
                return ID;
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SelectProductIDByProductTitleURL()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ID;
        }

        public DataSet GetDataForParentRepeater()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[1];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectAllActiveProductForMenu");
                return ObjSql.GetDsetProc("Mst_Sp_ProductData", _SqlParameter);
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Error in procedure SelectAllActiveProductForMenu()", ex);
            }
            return ObjSql.GetDsetProc("Mst_Sp_ProductData", _SqlParameter);
        }

        public DataSet SelectAllActiveCategories()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[1];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectAllActiveCategories");
                return ObjSql.GetDsetProc("Mst_Sp_ProductData", _SqlParameter);
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Error in procedure SelectAllActiveProductForMenu()", ex);
            }
            return ObjSql.GetDsetProc("Mst_Sp_ProductData", _SqlParameter);
        }


        public DataSet SelectAwardDescription(int ProductID)
        {
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectAwardDescription");
                _SqlParameter[1] = new SqlParameter("@ProductID", ProductID);
                return ObjSql.GetDsetProc("Mst_Sp_ProductData", _SqlParameter);
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Error in procedure SelectProductBannerImage()", ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.GetDsetProc("Mst_Sp_ProductData", _SqlParameter);
        }



        public DataSet SelectBannerIndegrients(int ProductID)
        {
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectBannerIndegrients");
                _SqlParameter[1] = new SqlParameter("@ProductID", ProductID);
                return ObjSql.GetDsetProc("Mst_Sp_ProductData", _SqlParameter);
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Error in procedure SelectBannerIndegrients()", ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.GetDsetProc("Mst_Sp_ProductData", _SqlParameter);
        }

        public void BindDdProduct(System.Web.UI.WebControls.DropDownList DdProduct, string CockTailsName, string CockTailsID)
        {
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectAllCockTailsForDD");
                _SqlParameter[1] = new SqlParameter("@ProductID", ProductID);
                ObjSql.DdBing(DdProduct, "Mst_Sp_ProductData", "ProductName", "ProductID", _SqlParameter);

            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure BindDdProduct()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
        }
        #endregion

    }
}

