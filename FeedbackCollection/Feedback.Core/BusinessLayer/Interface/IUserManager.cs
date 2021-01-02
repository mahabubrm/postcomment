using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Feedback.Core.Models;
using Feedback.Core.Models.Common;

namespace Feedback.Core.BusinessLayer.Interface
{
    public interface IUserManager : IManager<User>
    {
        ReturnMessage Login(string userName, string password);
    }
}
