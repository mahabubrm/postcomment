using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feedback.Core.Models.Common
{
    public class EmailParameter
    {
        public string ClientMailAddress { get; set; }
        public string MailSubject { get; set; }
        public string UserName { get; set; }
        public string ClientName { get; set; }
        public string WebAddress { get; set; }
        public string ActivationLink { get; set; }
        public string Password { get; set; }
        public string SubmissionDate { get; set; }
        public string ProductionOrderNo { set; get; }
        public string ProductionOrderDate { set; get; }
        public string MailTo { set; get; }
        public string MailCC { set; get; }
        public string ScreenCode { set; get; }

        public string IssueWarehouse { set; get; }
        public string ReceiveWarehouse { set; get; }
        public string GrnNo { set; get; }
        public string MaterialName { set; get; }
        public string ReceiveDate { set; get; }
        public string ReceiveQty { set; get; }
                
    }
}
