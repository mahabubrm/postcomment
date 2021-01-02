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
    public class PostCommentManager : IPostCommentManager
    {
        public PostCommentRepository _postCommentRepository;
        public ReturnMessage _returnMessage;
        public bool _isSaveChange;
        AppSession sessionUser = HttpContext.Current.Session[AppSetting.Session] as AppSession;
        public PostCommentManager()
        {
            _postCommentRepository = new PostCommentRepository();
            _returnMessage = new ReturnMessage();
        }
        public ReturnMessage Add(PostComment entity)
        {
            entity.CommentsBy = (int)sessionUser.UserId;
            _isSaveChange = _postCommentRepository.Add(entity);
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

        public IEnumerable<PostComment> GetAll()
        {
            return _postCommentRepository.GetAll();
        }

        public PostComment GetById(int id)
        {
            return _postCommentRepository.GetById(id);
        }

        public ReturnMessage Remove(PostComment entity)
        {
            throw new NotImplementedException();
        }

        public ReturnMessage Update(PostComment entity)
        {
            throw new NotImplementedException();
        }
    }
}
