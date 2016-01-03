using PrecheckBusinessModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrecheckDataAccess
{
    public class DA_VOE
    {
        public DA_VOE()
        { }
        public List<BM_VOE> getAllVOE()
        {
            List<BM_VOE> listVOE = new List<BM_VOE>();
            string query = "Select * FROM hectorhaas.precheckVOE";
            DataTable dt = DataAccess.getAnyDataTable(query);
            for (int i = 0;i<dt.Rows.Count;i++)
            {
                BM_VOE tempVOE = new BM_VOE();
                tempVOE.employer = dt.Rows[i]["employer"].ToString();
                tempVOE.id = dt.Rows[i]["id"].ToString();
                listVOE.Add(tempVOE);
            }
            return listVOE;
        }
        public BM_Logs getLogs(string voeID)
        {
            string query = "Select * hectorhaas.precheckVOE WHERE voeID = " + voeID;
            DataTable dt = DataAccess.getAnyDataTable(query);
            BM_Logs bml = new BM_Logs();
            bml.id = dt.Rows[0]["id"].ToString();
            bml.privateNotes = dt.Rows[0]["privateNotes"].ToString();
            bml.publicNotes = dt.Rows[0]["publicNotes"].ToString();
            bml.voeID = dt.Rows[0]["voeID"].ToString();
            return bml;
        }
        public void updateLogs(BM_Logs logs)
        {
            string query = "Select id, publicNotes, privateNotes, voeID FROM hectorhaas.precheckLogs WHERE voeID = "+logs.voeID;
            DataTable dt = DataAccess.getAnyDataTable(query);
            logs.privateNotes = logs.privateNotes +"<br /><br />" + dt.Rows[0]["privateNotes"].ToString();
            logs.publicNotes = logs.publicNotes + "<br /><br />" + dt.Rows[0]["publicNotes"].ToString();
            query = "UPDATE hectorhaas.precheckLogs SET publicNotes = '" + logs.publicNotes.Trim().Replace("'","''")+ "', privateNotes='" + logs.privateNotes.Trim().Replace("'", "''") + "', signoff = '"+logs.signoff.Trim().Replace("'","''")+"' WHERE voeID = " + logs.voeID;
            DataAccess.justExecuteQuery(query);
            //add time attempts
            DA_Attempts daa = new DA_Attempts();
            daa.insertAttempt(logs.seconds.ToString());
        }
        public DataTable CareForLogs(string voeID)
        {
            string query = "Select id, publicNotes, privateNotes, voeID, signoff FROM hectorhaas.precheckLogs WHERE voeID =" + voeID;
            DataTable dt = DataAccess.getAnyDataTable(query);
            return dt;
        }
    }
}
