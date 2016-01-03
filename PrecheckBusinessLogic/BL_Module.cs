using PrecheckBusinessModel;
using PrecheckDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrecheckBusinessLogic
{
    public class BL_Module
    {
        public BL_Module()
        { }
        public StringBuilder GetModuleTable()
        {
            List<BM_VOE> voes = GetAllVOE();
            StringBuilder sb = new StringBuilder();
            sb.Append("<table class=\"table table-striped table-bordered\">");
            sb.Append("<head>");

            sb.Append("<tr>");
            sb.Append("<td></td>");
            sb.Append("<td>Person</td>");
            sb.Append("<td>Client</td>");
            sb.Append("<td>Employer</td>");
            sb.Append("</tr>");

            sb.Append("</head>");

            sb.Append("<body>");

            for (int i = 0; i < voes.Count; i++)
            {
                sb.Append("<tr>");
                sb.Append("<td><a href=\"voe.aspx?id="+voes[i].id+ "\">" + voes[i].id + "</a></td>");
                sb.Append("<td>John Jane Doe</td>");
                sb.Append("<td>Client</td>");
                sb.Append("<td>" + voes[i].employer + "</td>");
                sb.Append("</tr>");
            }
            sb.Append("</body>");
            sb.Append("</table>");
            return sb;
        }
        public List<BM_VOE> GetAllVOE()
        {
            DA_VOE dav = new DA_VOE();
            return dav.getAllVOE();
        }
        public List<StringBuilder> getAverages()
        {
            List<StringBuilder> sbList = new List<StringBuilder>();
            StringBuilder sbToday = new StringBuilder();
            StringBuilder sbAll = new StringBuilder();
            List<BM_Attempt> todayList = null;
            List<BM_Attempt> allList = null;
            DA_Attempts daa = new DA_Attempts();
            todayList = daa.returnAllAttemptsToday();
            allList = daa.returnAllAttempts();

            #region averages
            //today List

            if(todayList.Count > 0)
            {
                int todaySum = 0;
                double todayMinutesAverage = 0;
                for (int i = 0; i<todayList.Count;i++)
                {
                    todaySum += Convert.ToInt32(todayList[i].secondsamt);
                }
                double todayAverage = todaySum / todayList.Count;
                todayMinutesAverage = todayAverage / 60;
                todayMinutesAverage = Math.Round(todayMinutesAverage, 1);
                sbToday.Append("<span style=\"font-size:1.2em\">Today's Average</span>");
                sbToday.Append("<br /><br />");
                sbToday.Append("<span style=\"font-size:1.8em\">"+todayMinutesAverage.ToString()+"</span><br />");
                sbToday.Append("<span style=\"font-size:0.9em\">minute(s)</span>");
                sbList.Add(sbToday);
            }
            else
            {
                //No records for today
                sbToday.Append("<span style=\"font-size:1.2em\">Today's Average</span>");
                sbToday.Append("<br /><br />");
                sbToday.Append("<span style=\"font-size:1.8em\">0.0</span><br />");
                sbToday.Append("<span style=\"font-size:0.9em\">minute(s)</span>");
                sbList.Add(sbToday);
            }

            if(allList.Count > 0)
            {
                int allSum = 0;
                double allMinutesAverage = 0;
                for (int i = 0; i < allList.Count; i++)
                {
                    allSum += Convert.ToInt32(allList[i].secondsamt);
                }
                double allAverage = allSum / allList.Count;
                allMinutesAverage = allAverage / 60;
                allMinutesAverage = Math.Round(allMinutesAverage, 1);
                sbAll.Append("<span style=\"font-size:1.2em\">All-time Average</span>");
                sbAll.Append("<br /><br />");
                sbAll.Append("<span style=\"font-size:1.8em\">" + allMinutesAverage.ToString() + "</span><br />");
                sbAll.Append("<span style=\"font-size:0.9em\">minute(s)</span>");
                sbList.Add(sbAll);
            }
            else
            {
                sbAll.Append("<span style=\"font-size:1.2em\">All-time Average</span>");
                sbAll.Append("<br /><br />");
                sbAll.Append("<span style=\"font-size:1.8em\">0.0</span><br />");
                sbAll.Append("<span style=\"font-size:0.9em\">minute(s)</span>");
                sbList.Add(sbAll);
            }
            #endregion

            return sbList;
        }




    }
}
