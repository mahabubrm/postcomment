using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Feedback.Core.DataLayer.Interface;
using Feedback.Core.Models;

namespace Feedback.Core.DataLayer.Repository
{
    public class PostCommentRepository : BaseRepository<PostComment>, IPostComment, IDisposable
    {
        public FeedbackCollectionEntities context
        {
            get
            {
                return _db as FeedbackCollectionEntities;
            }
        }

        public PostCommentRepository() : base(new FeedbackCollectionEntities())
        {

        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
