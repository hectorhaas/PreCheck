using PrecheckBusinessModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrecheckDataAccess
{
    public class DA_Blurbs
    {
        public DA_Blurbs()
        {

        }
        #region blurbs
        public void addBlurb(BM_Blurb blurb)
        {
            string query = "INSERT INTO hectorhaas.precheckBlurbs (blurbText, categoryID) VALUES ('"+cleanText(blurb.blurbText)+"', "+blurb.categoryID+")";
            DataAccess.justExecuteQuery(query);
        }
        public BM_Blurb getBlurbWithID(string blurbID)
        {
            BM_Blurb blurb = new BM_Blurb();
            string query = "SELECT id, blurbText, categoryID FROM hectorhaas.precheckBlurbs WHERE id = " + blurbID;
            DataTable dt = DataAccess.getAnyDataTable(query);
            blurb.categoryID = dt.Rows[0]["categoryID"].ToString();
            blurb.blurbText = dt.Rows[0]["blurbText"].ToString();
            blurb.id = blurbID;
            return blurb;
        }
        public List<BM_Blurb> getAllBlurbs()
        {
            List<BM_Blurb> blurbList = new List<BM_Blurb>();
            //get data
            string query = "SELECT id, blurbText, categoryID FROM hectorhaas.precheckBlurbs ORDER BY blurbText ASC";
            DataTable dt = DataAccess.getAnyDataTable(query);
            for (int i = 0;i<dt.Rows.Count;i++)
            {
                BM_Blurb tempBlurb = new BM_Blurb();
                tempBlurb.id = dt.Rows[i]["id"].ToString();
                tempBlurb.categoryID = dt.Rows[i]["categoryID"].ToString();
                tempBlurb.blurbText = dt.Rows[i]["blurbText"].ToString();
                blurbList.Add(tempBlurb);
            }
            return blurbList;
        }
        public List<BM_Blurb> getAllBlurbsByCategory(string categoryID)
        {
            List<BM_Blurb> blurbList = new List<BM_Blurb>();
            //get data
            string query = "SELECT id, blurbText, categoryID FROM hectorhaas.precheckBlurbs WHERE categoryID = " + categoryID+" ORDER BY blurbText ASC";
            DataTable dt = DataAccess.getAnyDataTable(query);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                BM_Blurb tempBlurb = new BM_Blurb();
                tempBlurb.id = dt.Rows[i]["id"].ToString();
                tempBlurb.categoryID = dt.Rows[i]["categoryID"].ToString();
                tempBlurb.blurbText = dt.Rows[i]["blurbText"].ToString();
                blurbList.Add(tempBlurb);
            }
            return blurbList;
        }
        #endregion
        #region categories
        public void addBlurbCategory(BM_BlurbCategory category)
        {
            string query = "INSERT INTO hectorhaas.precheckBlurbCategories (categoryName, categoryDescription) VALUES ('"+ cleanText(category.categoryName)+"', '"+ cleanText(category.categoryDescription)+"')";
            DataAccess.justExecuteQuery(query);
        }
        public BM_BlurbCategory getBlurbCategoryWithID(string ID)
        {
            BM_BlurbCategory blurbCat = new BM_BlurbCategory();
            string query = "SELECT id, categoryName, categoryDescription FROM hectorhaas.precheckBlurbCategories WHERE id = " + ID;
            DataTable dt = DataAccess.getAnyDataTable(query);
            blurbCat.id = ID;
            blurbCat.categoryName = dt.Rows[0]["categoryName"].ToString();
            blurbCat.categoryDescription = dt.Rows[0]["categoryDescription"].ToString();
            return blurbCat;
        }
        public List<BM_BlurbCategory> getAllBlurbCategories()
        {
            List<BM_BlurbCategory> catList = new List<BM_BlurbCategory>();
            string query = "SELECT id, categoryName, categoryDescription FROM hectorhaas.precheckBlurbCategories ORDER BY categoryName ASC";
            DataTable dt = DataAccess.getAnyDataTable(query);
            for (int i = 0;i<dt.Rows.Count;i++)
            {
                BM_BlurbCategory blurbCat = new BM_BlurbCategory();
                blurbCat.id = dt.Rows[i]["id"].ToString();
                blurbCat.categoryName = dt.Rows[i]["categoryName"].ToString();
                blurbCat.categoryDescription = dt.Rows[i]["categoryDescription"].ToString();
                catList.Add(blurbCat);
            }
            return catList;
        }

        #endregion
        private string cleanText(string text)
        {
            text = text.Trim().Replace("'", "''");
            return text;
        }
    }
}
