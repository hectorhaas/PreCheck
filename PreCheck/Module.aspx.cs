using PrecheckBusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PreCheck
{
    public partial class Module : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadTable();
            getTheAverages();
        }
        private void LoadTable()
        {
            BL_Module blm = new BL_Module();
            divTableVOE.InnerHtml = blm.GetModuleTable().ToString();
        }
        private void getTheAverages()
        {
            BL_Module blm = new BL_Module();
            List<StringBuilder> sbList = blm.getAverages();
            divTodayAverage.InnerHtml = sbList[0].ToString();
            divAllAverage.InnerHtml = sbList[1].ToString();
        }
    }
}