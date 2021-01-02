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
    public class CommentStatusManager : ICommentStatusManager
    {
        public CommetnsStatusRepository _commentStatusRepository;
        public ReturnMessage _returnMessage;
        public bool _isSaveChange;
        AppSession sessionUser = HttpContext.Current.Session[AppSetting.Session] as AppSession;
        public CommentStatusManager()
        {
            _commentStatusRepository = new CommetnsStatusRepository();
            _returnMessage = new ReturnMessage();
        }
        public ReturnMessage Add(CommentsStatu entity)
        {
            entity.UserId = (int)sessionUser.UserId;            
            _isSaveChange = _commentStatusRepository.Add(entity);
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

        public IEnumerable<CommentsStatu> GetAll()
        {
            return _commentStatusRepository.GetAll();
        }

        public CommentsStatu GetById(int id)
        {
            return _commentStatusRepository.GetById(id);
        }

        public ReturnMessage Remove(CommentsStatu entity)
        {
            _isSaveChange = _commentStatusRepository.Remove(entity);
            if (_isSaveChange)
            {
                _returnMessage = ReturnMessage.SetDeleteSuccessMessage();
            }
            else
            {
                _returnMessage = ReturnMessage.SetErrorMessage();
            }
            return _returnMessage;
        }

        public ReturnMessage Update(CommentsStatu entity)
        {
            _isSaveChange = _commentStatusRepository.Update(entity);
            if (_isSaveChange)
            {
                _returnMessage = ReturnMessage.SetUpdateSuccessMessage();
            }
            else
            {
                _returnMessage = ReturnMessage.SetErrorMessage();
            }
            return _returnMessage;
        }
    }
}
