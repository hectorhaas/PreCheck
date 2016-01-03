using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrecheckBusinessModel
{
    public class BM_Logs
    {
        public BM_Logs()
        { }
        public string publicNotes { get; set; }
        public string privateNotes { get; set; }
        public string voeID { get; set; }
        public string id { get; set; }
        public string signoff { get; set; }
        public int seconds { get; set; }
    }
}
