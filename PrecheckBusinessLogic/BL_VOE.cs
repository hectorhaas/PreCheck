using PrecheckBusinessModel;
using PrecheckDataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrecheckBusinessLogic
{
    public class BL_VOE
    {
        public BL_VOE()
        {

        }
        public void LockVOE(string voeID)
        { }
        public void checkIfLocked(string voeID)
        { }
        public BM_Logs CareForLogs(string voeID)
        {
            DA_VOE dav = new DA_VOE();
            DataTable dt = dav.CareForLogs(voeID);
            BM_Logs bml = new BM_Logs();
            if (dt.Rows.Count>0)
            {
                bml.id = dt.Rows[0]["id"].ToString();
                bml.publicNotes = dt.Rows[0]["publicNotes"].ToString();
                bml.privateNotes = dt.Rows[0]["privateNotes"].ToString();
                bml.signoff = dt.Rows[0]["signoff"].ToString();
                bml.voeID = dt.Rows[0]["voeID"].ToString();
                return bml;
            }
            else
            {
                return null;
            }
        }
        public void updateLogs(BM_Logs logs)
        {
            DA_VOE dav = new DA_VOE();
            dav.updateLogs(logs);
        }
    }
}
