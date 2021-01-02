using Feedback.Core.BusinessLayer.Interface;
using Feedback.Core.DataLayer.Repository;
using Feedback.Core.Models;
using Feedback.Core.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Feedback.Core.BusinessLayer.Manager
{
    public class UserManager : IUserManager
    {
        public UserRepository _userRepository;
        public ReturnMessage _returnMessage;
        public bool _isSaveChange;
        AppSession sessionUser = HttpContext.Current.Session[AppSetting.Session] as AppSession;
        public UserManager()
        {
            _userRepository = new UserRepository();
            _returnMessage = new ReturnMessage();
        }
        public ReturnMessage Add(User entity)
        {            
            _isSaveChange = _userRepository.Add(entity);
            if (_isSaveChange)
            {
                _returnMessage = ReturnMessage.SetSuccessMessage();
            }
            else
            {
                _returnMessage = ReturnMessage.SetErrorMessage();
            }
            return _returnMessage;
        }

        public IEnumerable<User> GetAll()
        {
            return _userRepository.GetAll();
        }

        public User GetById(int id)
        {
            return _userRepository.GetById(id);
        }

        public ReturnMessage Remove(User entity)
        {
            throw new NotImplementedException();
        }

        public ReturnMessage Update(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
