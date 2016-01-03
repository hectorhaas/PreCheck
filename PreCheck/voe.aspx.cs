using PrecheckBusinessLogic;
using PrecheckBusinessModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PreCheck
{
    public partial class voe : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Request.QueryString["id"]==null)
            {
                Response.Redirect("Module.aspx");
            }
            if (!IsPostBack)
            {
                CareForLogs();
            }
        }

        protected void btnLock_Click(object sender, EventArgs e)
        {
            btnSubmit.Enabled = true;
            btnLock.Enabled = false;
            txtPrivateNotes.Enabled = true;
            txtPublicNotes.Enabled = true;
            txtSignOff.Enabled = true;
            //The Date
            hdnDate.Value = DateTime.Now.ToString();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            btnSubmit.Enabled = false;
            btnLock.Enabled = true;

            txtPrivateNotes.Enabled = false;
            txtPublicNotes.Enabled = false;
            txtSignOff.Enabled = false;

            //do the things
            BL_VOE blv = new BL_VOE();
            string voeID = Request.QueryString.Get("id");
            BM_Logs bml = new BM_Logs();
            bml.voeID = voeID;
            bml.signoff = txtSignOff.Text;
            bml.privateNotes = txtPrivateNotes.Text;
            bml.publicNotes = txtPublicNotes.Text;
            //get seconds
            DateTime pastdate = Convert.ToDateTime(hdnDate.Value.ToString());
            bml.seconds = Convert.ToInt32(((DateTime.Now - pastdate).TotalSeconds));
            //Update
            blv.updateLogs(bml);

            txtPrivateNotes.Text = "";
            txtPublicNotes.Text = "";

            CareForLogs();
        }
        private void CareForLogs()
        {
            BL_VOE blv = new BL_VOE();
            BM_Logs bml = blv.CareForLogs(Request.QueryString["id"].ToString());
            if(!(bml==null))
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("<button class=\"btn btn-info\" id=\"btnShowPublicLogs\">Public Logs</button>");
                sb.Append("&nbsp;&nbsp;&nbsp;");
                sb.Append("<button class=\"btn btn-info\" id=\"btnShowPrivateLogs\">Private Logs</button>");
                
                //divs
                sb.Append("<div id=\"divPrivateNotes\"><span style=\"font-size:1.2em\">Private</span><br /><br />" + bml.privateNotes + "</div>");
                sb.Append("<div id=\"divPublicNotes\"><span style=\"font-size:1.2em\">Public</span><br /><br />" + bml.publicNotes + "<br />"+bml.signoff+"</div>");
                //script
                sb.Append("<script>");
                sb.Append("$(document).ready(function() {");

                //Prepare dialogs
                sb.Append("$(\"#divPrivateNotes\").dialog({");
                sb.Append("autoOpen: false,");
                sb.Append("show: \"blind\",");
                sb.Append("hide: \"explode\"");
                sb.Append("});");

                sb.Append("$(\"#divPublicNotes\").dialog({");
                sb.Append("autoOpen: false,");
                sb.Append("show: \"blind\",");
                sb.Append("hide: \"explode\"");
                sb.Append("});");


                sb.Append("$(\"#btnShowPrivateLogs\").click(function() {");
                sb.Append("$(\"#divPrivateNotes\").dialog(\"open\");");
                sb.Append("return false;");
                sb.Append("    });");

                sb.Append("$(\"#btnShowPublicLogs\").click(function() {");
                sb.Append("$(\"#divPublicNotes\").dialog(\"open\");");
                sb.Append("return false;");
                sb.Append("    });");

                sb.Append("});");
                sb.Append("</script>");

                
                //Inner HTMLS
                divBtns.InnerHtml = sb.ToString();
                txtSignOff.Text = bml.signoff;
            }

        }
    }
}