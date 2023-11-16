using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Utility;

namespace Component
{
    public class CategoryData
    {
        Connect ObjSql = new Connect();
        CommanFunction ObjComm = new CommanFunction();
        ManageException ObjEx = new ManageException();

        public CategoryData()
        {
        }

        private int _categoryID = 0;
        private string _categoryName = string.Empty;
        private string _categoryAlias = string.Empty;
        private string _categoryImage = string.Empty;
        private string _categoryDescription = string.Empty;
        private string _categorysmallDescription = string.Empty;
        private int _displayOrder = 0;
        private int _activeStatus = 0;
        private string _updatedBy = string.Empty;
        private DateTime _updatedOn = DateTime.UtcNow;
        private string _categoryMetaTitle = string.Empty;
        private string _categoryMetaKeywords = string.Empty;
        private string _categoryMetaDescription = string.Empty;
        private string _CategoryImage2 = string.Empty;
        private string _Image2Description = string.Empty;

        public int CategoryID
        {
            get { return _categoryID; }
            set { _categoryID = value; }
        }
        public string CategoryName
        {
            get { return _categoryName; }
            set { _categoryName = value; }
        }
        public string CategoryAlias
        {
            get { return _categoryAlias; }
            set { _categoryAlias = value; }
        }
        public string CategoryImage
        {
            get { return _categoryImage; }
            set { _categoryImage = value; }
        }

        public string CategorysmallDescription
        {
            get { return _categorysmallDescription; }
            set { _categorysmallDescription = value; }
        }

        public string CategoryDescription
        {
            get { return _categoryDescription; }
            set { _categoryDescription = value; }
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
        public string CategoryMetaTitle
        {
            get { return _categoryMetaTitle; }
            set { _categoryMetaTitle = value; }
        }
        public string CategoryMetaKeywords
        {
            get { return _categoryMetaKeywords; }
            set { _categoryMetaKeywords = value; }
        }
        public string CategoryMetaDescription
        {
            get { return _categoryMetaDescription; }
            set { _categoryMetaDescription = value; }
        }

        string _MetaSchema = string.Empty;

        public string MetaSchema
        {
            get { return _MetaSchema; }
            set { _MetaSchema = value; }
        }
        private string _CategoryImage1 = string.Empty;

        public string CategoryImage1
        {
            get { return _CategoryImage1; }
            set { _CategoryImage1 = value; }
        }
        private int _DisplayOnMenu = 0;

        public int DisplayOnMenu
        {
            get { return _DisplayOnMenu; }
            set { _DisplayOnMenu = value; }
        }
        private int _DisplayOnHeader = 0;

        public int DisplayOnHeader
        {
            get { return _DisplayOnHeader; }
            set { _DisplayOnHeader = value; }
        }
        private int _DisPlayOnCategory = 0;

        public int DisPlayOnCategory 
        {
            get { return _DisPlayOnCategory; }
            set { _DisPlayOnCategory = value; }
        }

        private int _SubCategoryID = 0;

        public int SubCategoryID
        {
            get { return _SubCategoryID; }
            set { _SubCategoryID = value; }
        }
        private int _FlavourID = 0;

        public int FlavourID
        {
            get { return _FlavourID; }
            set { _FlavourID = value; }
        }
        private int _OccasionID = 0;

        public int OccasionID
        {
            get { return _OccasionID; }
            set { _OccasionID = value; }
        }
        private string _FacebookURl = string.Empty;

        public string FacebookURl
        {
            get { return _FacebookURl; }
            set { _FacebookURl = value; }
        }

        public string Image2Description
        {
            get { return _Image2Description; }
            set { _Image2Description = value; }
        }

        public string CategoryImage2
        {
            get { return _CategoryImage2; }
            set { _CategoryImage2 = value; }
        }


        private int _PhotoCategory = 0;

        public int PhotoCategory
        {
            get { return _PhotoCategory; }
            set { _PhotoCategory = value; }
        }
        #region Admin Panel
        public void SelectAllCategory(System.Web.UI.WebControls.GridView CategoryGrid)
        {
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectAllCategoryData");
                _SqlParameter[1] = new SqlParameter("@UpdatedBy", UpdatedBy);
                ObjSql.GdBind_SNO(CategoryGrid, "Mst_Sp_CategoryData", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SelectAllCategory()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
        }



        public void BindDdCategory(System.Web.UI.WebControls.DropDownList DdCategory, string CategoryName, string CategoryID)
        {
            SqlParameter[] _SqlParameter = new SqlParameter[1];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectCategoryDataForDD");
                ObjSql.DdBing(DdCategory, "Mst_Sp_CategoryData", "CategoryName", "CategoryID", _SqlParameter);

            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure BindDdCategory()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
        }

        public SqlDataReader SelectCategoryByCategoryID()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectCategoryDataByCategoryID");
                _SqlParameter[1] = new SqlParameter("@CategoryID", CategoryID);
                return ObjSql.GetDatareaderProc("Mst_Sp_CategoryData", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SelectCategoryByCategoryID()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.GetDatareaderProc("Mst_Sp_CategoryData", _SqlParameter);
        }

        public int SaveCategory()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[21];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SaveCategory");
                _SqlParameter[1] = new SqlParameter("@CategoryName", CategoryName);
                _SqlParameter[2] = new SqlParameter("@CategoryAlias", CategoryAlias);
                _SqlParameter[3] = new SqlParameter("@CategoryImage", CategoryImage);
                _SqlParameter[4] = new SqlParameter("@CategoryDescription", CategoryDescription);
                _SqlParameter[5] = new SqlParameter("@DisplayOrder", DisplayOrder);
                _SqlParameter[6] = new SqlParameter("@ActiveStatus", ActiveStatus);
                _SqlParameter[7] = new SqlParameter("@CategoryMetaTitle", CategoryMetaTitle);
                _SqlParameter[8] = new SqlParameter("@CategoryMetaKeywords", CategoryMetaKeywords);
                _SqlParameter[9] = new SqlParameter("@CategoryMetaDescription", CategoryMetaDescription);
                _SqlParameter[10] = new SqlParameter("@MetaSchema", MetaSchema);
                _SqlParameter[11] = new SqlParameter("@CategoryImage1", CategoryImage1);
                _SqlParameter[12] = new SqlParameter("@DisplayOnMenu", DisplayOnMenu);
                _SqlParameter[13] = new SqlParameter("@DisplayOnHeader", DisplayOnHeader);
                _SqlParameter[14] = new SqlParameter("@FacebookURl", FacebookURl);
                _SqlParameter[15] = new SqlParameter("@PhotoCategory", PhotoCategory);
                _SqlParameter[16] = new SqlParameter("@CategorysmallDescription", CategorysmallDescription);
                _SqlParameter[17] = new SqlParameter("@CategoryImage2", CategoryImage2);
                _SqlParameter[18] = new SqlParameter("@Image2Description", Image2Description);
                _SqlParameter[19] = new SqlParameter("@DisPlayOnCategory ", DisPlayOnCategory);
                _SqlParameter[20] = new SqlParameter("@UpdatedBy", UpdatedBy);
                return ObjSql.ExcuteProce("Mst_Sp_CategoryData", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SaveCategory()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_CategoryData", _SqlParameter);
        }

        public int UpdateCategory()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[23];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "UpdateCategoryData");
                _SqlParameter[1] = new SqlParameter("@CategoryID", CategoryID);
                _SqlParameter[2] = new SqlParameter("@CategoryName", CategoryName);
                _SqlParameter[3] = new SqlParameter("@CategoryAlias", CategoryAlias);
                _SqlParameter[4] = new SqlParameter("@CategoryImage", CategoryImage);
                _SqlParameter[5] = new SqlParameter("@CategoryDescription", CategoryDescription);
                _SqlParameter[6] = new SqlParameter("@DisplayOrder", DisplayOrder);
                _SqlParameter[7] = new SqlParameter("@ActiveStatus", ActiveStatus);
                _SqlParameter[8] = new SqlParameter("@CategoryMetaTitle", CategoryMetaTitle);
                _SqlParameter[9] = new SqlParameter("@CategoryMetaKeywords", CategoryMetaKeywords);
                _SqlParameter[10] = new SqlParameter("@CategoryMetaDescription", CategoryMetaDescription);
                _SqlParameter[11] = new SqlParameter("@Updatedby", UpdatedBy);
                _SqlParameter[12] = new SqlParameter("@Updatedon", UpdatedOn);
                _SqlParameter[13] = new SqlParameter("@MetaSchema", MetaSchema);
                _SqlParameter[14] = new SqlParameter("@CategoryImage1", CategoryImage1);
                _SqlParameter[15] = new SqlParameter("@DisplayOnMenu", DisplayOnMenu);
                _SqlParameter[16] = new SqlParameter("@DisplayOnHeader", DisplayOnHeader);
                _SqlParameter[17] = new SqlParameter("@CategorysmallDescription", CategorysmallDescription);
                _SqlParameter[18] = new SqlParameter("@FacebookURl", FacebookURl);
                _SqlParameter[19] = new SqlParameter("@CategoryImage2", CategoryImage2);
                _SqlParameter[20] = new SqlParameter("@Image2Description", Image2Description);
                _SqlParameter[21] = new SqlParameter("@PhotoCategory", PhotoCategory);
                _SqlParameter[22] = new SqlParameter("@DisPlayOnCategory ", DisPlayOnCategory);
                return ObjSql.ExcuteProce("Mst_Sp_CategoryData", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure UpdateCategory()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_CategoryData", _SqlParameter);
        }

        public int DeleteCategoryByID()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "DeleteCategoryDataByID");
                _SqlParameter[1] = new SqlParameter("@CategoryID", CategoryID);
                return ObjSql.ExcuteProce("Mst_Sp_CategoryData", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure DeleteCategoryByID()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_CategoryData", _SqlParameter);
        }

        public int UpdateCategoryDataDisplayOrder()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[3];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "UpdateCategoryDataDisplayOrder");
                _SqlParameter[1] = new SqlParameter("@CategoryID", CategoryID);
                _SqlParameter[2] = new SqlParameter("@DisplayOrder", DisplayOrder);
                return ObjSql.ExcuteProce("Mst_Sp_CategoryData", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure UpdateCategoryDataDisplayOrder()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_CategoryData", _SqlParameter);
        }

        public void SelectTop10CategoryDataForAdminHome(System.Web.UI.WebControls.GridView DoctorGrid)
        {
            SqlParameter[] _SqlParameter = new SqlParameter[1];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectTop10CategoryDataForAdminHome");
                ObjSql.GdBind_SNO(DoctorGrid, "Mst_Sp_CategoryData", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SelectTop10CategoryDataForAdminHome()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
        }

        public DataSet SelectAllCategoryDataForRptr()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[1];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectAllCategoryDataForRptr");
                return ObjSql.GetDsetProc("Mst_Sp_CategoryData", _SqlParameter);
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Error in procedure SelectAllCategoryDataForRptr()", ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.GetDsetProc("Mst_Sp_CategoryData", _SqlParameter);
        }

        public int SelectMaxDisplayOrder()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[1];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectMaxDisplayOrder");
                return ObjSql.ExcuteProce("Mst_Sp_CategoryData", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SelectMaxDisplayOrder()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.ExcuteProce("Mst_Sp_CategoryData", _SqlParameter);
        }

        public DataSet ExportEmailIDsintoExcel()
        {
            SqlParameter[] arrparam = new SqlParameter[1];
            try
            {
                arrparam[0] = new SqlParameter("@Action", "ExportEmailIDsintoExcel");
                return ObjSql.GetDsetProc1("Mst_Sp_CategoryData", arrparam);
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Error in procedure BindEmailIDsintoExcel()", ex);
            }
            finally
            {
                arrparam = (SqlParameter[])null;
                ObjSql = (Connect)null;
                ObjEx = (ManageException)null;
            }

            return ObjSql.GetDsetProc1("Mst_Sp_CategoryData", arrparam);
        }
        #endregion Admin Panel

        #region Front Panel
        public DataSet SelectTop6ActiveCategoryDataForHeaderByDisplayOnHeader()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[1];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectTop6ActiveCategoryDataForHeaderByDisplayOnHeader");
                return ObjSql.GetDsetProc("Mst_Sp_CategoryData", _SqlParameter);
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Error in procedure SelectTop6ActiveCategoryDataForHeaderByDisplayOnHeader()", ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.GetDsetProc("Mst_Sp_CategoryData", _SqlParameter);
        }

        public DataSet SelectTop6ActiveCategoryDataForHeaderByDisplayOnMenu()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[1];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectTop6ActiveCategoryDataForHeaderByDisplayOnMenu");
                return ObjSql.GetDsetProc("Mst_Sp_CategoryData", _SqlParameter);
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Error in procedure SelectTop6ActiveCategoryDataForHeaderByDisplayOnMenu()", ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.GetDsetProc("Mst_Sp_CategoryData", _SqlParameter);
        }

        public DataSet SelectAllActiveCategoryData()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[1];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectAllActiveCategoryData");
                return ObjSql.GetDsetProc("Mst_Sp_CategoryData", _SqlParameter);
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Error in procedure SelectAllActiveCategoryData()", ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.GetDsetProc("Mst_Sp_CategoryData", _SqlParameter);
        }

        public DataSet SelectAllActiveCategoryDataForListing()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[1];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectAllActiveCategoryDataForListing");
                return ObjSql.GetDsetProc("Mst_Sp_CategoryData", _SqlParameter);
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Error in procedure SelectAllActiveCategoryDataForListing()", ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.GetDsetProc("Mst_Sp_CategoryData", _SqlParameter);
        }

        public int SelectCategoryIDbyCategoryAlias(string CategoryAlias)
        {
            int ID = 0;
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectCategoryIDbyCategoryAlias");
                _SqlParameter[1] = new SqlParameter("@CategoryAlias", CategoryAlias);
                ID = Convert.ToInt32(ObjSql.GetScalarProc("Mst_Sp_CategoryData", _SqlParameter));
                return ID;
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SelectCategoryIDbyCategoryAlias()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ID;
        }

        public SqlDataReader SelectCategorySubCategoryFlavourOccasionByCategoryIDSubCategoryIDFlavourIDOccasionID()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[5];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectCategorySubCategoryFlavourOccasionByCategoryIDSubCategoryIDFlavourIDOccasionID");
                _SqlParameter[1] = new SqlParameter("@CategoryID", CategoryID);
                _SqlParameter[2] = new SqlParameter("@SubCategoryID", SubCategoryID);
                _SqlParameter[3] = new SqlParameter("@FlavourID", FlavourID);
                _SqlParameter[4] = new SqlParameter("@OccasionID", OccasionID);
                return ObjSql.GetDatareaderProc("Mst_Sp_CategoryData", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SelectCategorySubCategoryFlavourOccasionByCategoryIDSubCategoryIDFlavourIDOccasionID()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ObjSql.GetDatareaderProc("Mst_Sp_CategoryData", _SqlParameter);
        }

        /*      public DataSet SelectDisplayImage()
             {
                SqlParameter[] _SqlParameter = new SqlParameter[1];
                try
                {
                    _SqlParameter[0] = new SqlParameter("@Action", "SelectDisplayImage");
                    return ObjSql.GetDsetProc("Mst_Sp_CategoryData", _SqlParameter);
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
            } */

        public DataSet SelectDisplayImage(int CategoryID)
        {
            DataSet ds = new DataSet();
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectDisplayImage");
                _SqlParameter[1] = new SqlParameter("@CategoryID", CategoryID);

                return ObjSql.GetDsetProc("Mst_Sp_CategoryData", _SqlParameter);
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SelectDisplayImage()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ds;
        }
        public DataSet SelectProductIDByProductTitleURL(string categoryAlias)
        {
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectProductIDByProductTitleURL");
                _SqlParameter[1] = new SqlParameter("@CategoryAlias", CategoryAlias);

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
            return ObjSql.GetDsetProc("Mst_Sp_ProductData", _SqlParameter);
        }

        public DataSet SelectActiveCategory()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[1];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectActiveCategory");
                return ObjSql.GetDsetProc("Mst_Sp_CategoryData", _SqlParameter);
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


      /*  public int SelectFooterDisplay(string categoryAlias)
        {
            int ID = 0;
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectProductIDbyProductNameAlias");
                _SqlParameter[1] = new SqlParameter("@CategoryAlias", CategoryAlias);
                ID = Convert.ToInt32(ObjSql.GetScalarProc("Mst_Sp_CategoryData", _SqlParameter));
                return ID;
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SelectFooterDisplay()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ID;
        }
        */

        public DataSet SelectFooterDisplay1()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[1];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectFooterDisplay1");
                return ObjSql.GetDsetProc("Mst_Sp_CategoryData", _SqlParameter);
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

        public DataSet SelectFooterDisplay2()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[1];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectFooterDisplay2");
                return ObjSql.GetDsetProc("Mst_Sp_CategoryData", _SqlParameter);
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

        public DataSet SelectFooterDisplay2(String CategoryName)
        {
            SqlParameter[] _SqlParameter = new SqlParameter[1];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectFooterDisplay2");
                return ObjSql.GetDsetProc("Mst_Sp_CategoryData", _SqlParameter);
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Error in procedure SelectDisplayImage()", ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return null; // Return null if there's an error or no data found.
        }


        public DataSet SelectFooterDisplay3()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[5];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectFooterDisplay3");
                _SqlParameter[1] = new SqlParameter("@CategoryID", CategoryID);
                _SqlParameter[2] = new SqlParameter("@CategoryDescription", CategoryDescription);
                _SqlParameter[3] = new SqlParameter("@CategorysmallDescription", CategorysmallDescription);
                _SqlParameter[4] = new SqlParameter("@CategoryName", CategoryName);
                return ObjSql.GetDsetProc("Mst_Sp_CategoryData", _SqlParameter);
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

        public int SelectCategoryIDByCategoryIDORCategoryTitleURL(string CategoryAlias)
        {
            int ID = 0;
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectCategoryIDByCategoryIDORCategoryTitleURL");
                _SqlParameter[1] = new SqlParameter("@CategoryAlias", CategoryAlias);
                ID = Convert.ToInt32(ObjSql.GetScalarProc("Mst_Sp_CategoryData", _SqlParameter));
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

        public int SelectCategoryIDByCategoryTitleURL(string CategoryAlias)
        {
            int ID = 0;
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectCategoryIDByCategoryTitleURL");
                _SqlParameter[1] = new SqlParameter("@CategoryAlias", CategoryAlias);
                ID = Convert.ToInt32(ObjSql.GetScalarProc("Mst_Sp_CategoryData", _SqlParameter));
                return ID;
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SelectCategoryIDByCategoryTitleURL()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ID;
        }

        public int SelectProductIDByProductNameAlias(string ProductNameAlias)
        {
            int ID = 0;
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectCategoryIDByCategoryTitleURL");
                _SqlParameter[1] = new SqlParameter("@ProductNameAlias", ProductNameAlias);
                ID = Convert.ToInt32(ObjSql.GetScalarProc("Mst_Sp_CategoryData", _SqlParameter));
                return ID;
            }
            catch (Exception Ex)
            {
                ObjEx.PublishError("Error in procedure SelectCategoryIDByCategoryTitleURL()", Ex);
            }
            finally
            {
                ObjSql.Disconnect();
            }
            return ID;
        }

        public DataSet SelectDisplayImageLink()
        {
            SqlParameter[] _SqlParameter = new SqlParameter[1];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectDisplayImage");
                return ObjSql.GetDsetProc("Mst_Sp_CategoryData", _SqlParameter);
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

        public DataSet SelectFooterImagesforCategories(int CategoryID)
        {
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectFooterImagesforCategories");
                _SqlParameter[1] = new SqlParameter("@CategoryID", CategoryID);
                return ObjSql.GetDsetProc("Mst_Sp_CategoryData", _SqlParameter);
            }
            catch (Exception ex)
            {
                ObjEx.PublishError("Error in procedure SelectFooterImagesforCategories()", ex);
                return null;
            }
            finally
            {
                ObjSql.Disconnect();
            }
        }


        public DataSet SelectProductImagesforWhisky(int CategoryID)
        {
            SqlParameter[] _SqlParameter = new SqlParameter[2];
            try
            {
                _SqlParameter[0] = new SqlParameter("@Action", "SelectProductImagesforWhisky");
                _SqlParameter[1] = new SqlParameter("@CategoryID", CategoryID);
                return ObjSql.GetDsetProc("Mst_Sp_CategoryData", _SqlParameter);
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
