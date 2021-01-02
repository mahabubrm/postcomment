using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feedback.Core.Models.Common
{
    public class AppSession
    {        
        public long UserId { get; set; }
        public string UserName { get; set; }
        public string UserFullName { get; set; }
        public int RoleId { get; set; }        
        public bool IsActive { get; set; }
    }
}
