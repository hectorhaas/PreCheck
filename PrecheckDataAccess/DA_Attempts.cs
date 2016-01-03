using PrecheckBusinessModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrecheckDataAccess
{
    public class DA_Attempts
    {
        public DA_Attempts()
        { }
        public void insertAttempt(string seconds)
        {
            string query = "INSERT INTO hectorhaas.precheckAverageAttempts (secondsamt, datetimesubmitted) VALUES ("+seconds+", GETDATE())";
            DataAccess.justExecuteQuery(query);
        }
        public List<BM_Attempt> returnAllAttempts()
        {
            string query = "SELECT Id, secondsamt, datetimesubmitted FROM hectorhaas.precheckAverageAttempts";
            List<BM_Attempt> attemptList = new List<BM_Attempt>();
            SqlConnection conn = new SqlConnection(DataAccess.connstring);
            //Open Conn
            conn.Open();
            SqlCommand sc = new SqlCommand(query, conn);
            SqlDataReader dr = sc.ExecuteReader();
            //Loop the reader
            if(dr.HasRows)
            {
                while(dr.Read())
                {
                    //Create temp object
                    BM_Attempt attempt = new BM_Attempt();
                    attempt.Id = dr.GetValue(0).ToString();
                    attempt.secondsamt = dr.GetValue(1).ToString();
                    attempt.datetimesubmitted = dr.GetValue(2).ToString();
                    //Add to list
                    attemptList.Add(attempt);
                }
            }
            //Close Conn
            conn.Close();
            //Return the list and end the method
            return attemptList;
        }
        public List<BM_Attempt> returnAllAttemptsToday()
        {
            string query = "SELECT [Id],[secondsamt],[datetimesubmitted] FROM [hectorhaas].[precheckAverageAttempts] WHERE [datetimesubmitted] >= DATEADD(DAY, 0, DATEDIFF(DAY, 0, CURRENT_TIMESTAMP)) AND [datetimesubmitted] < DATEADD(DAY, 1, DATEDIFF(DAY, 0, CURRENT_TIMESTAMP))";
            List<BM_Attempt> attemptList = new List<BM_Attempt>();
            SqlConnection conn = new SqlConnection(DataAccess.connstring);
            //Open Conn
            conn.Open();
            SqlCommand sc = new SqlCommand(query, conn);
            SqlDataReader dr = sc.ExecuteReader();
            //Loop the reader
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    //Create temp object
                    BM_Attempt attempt = new BM_Attempt();
                    attempt.Id = dr.GetValue(0).ToString();
                    attempt.secondsamt = dr.GetValue(1).ToString();
                    attempt.datetimesubmitted = dr.GetValue(2).ToString();
                    //Add to list
                    attemptList.Add(attempt);
                }
            }
            //Close Conn
            conn.Close();
            //Return the list and end the method
            return attemptList;
        }
    }
}
