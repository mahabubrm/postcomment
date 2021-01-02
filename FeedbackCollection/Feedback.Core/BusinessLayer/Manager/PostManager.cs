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
    public class PostManager : IPostManager
    {
        public PostRepository _postRepository;
        public ReturnMessage _returnMessage;
        public bool _isSaveChange;
        AppSession sessionUser = HttpContext.Current.Session[AppSetting.Session] as AppSession;
        public PostManager()
        {
            _postRepository = new PostRepository();
            _returnMessage = new ReturnMessage();
        }
        public ReturnMessage Add(Post entity)
        {
            entity.PostDate = DateTime.Now;
            entity.IsActive = true;
            entity.PostBy = (int)sessionUser.UserId;
            _isSaveChange = _postRepository.Add(entity);
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

        public IEnumerable<Post> GetAll()
        {
            return _postRepository.GetAll();
        }

        public Post GetById(int id)
        {
            return _postRepository.GetById(id);
        }

        public ReturnMessage Remove(Post entity)
        {
            throw new NotImplementedException();
        }

        public ReturnMessage Update(Post entity)
        {
            throw new NotImplementedException();
        }
    }
}
