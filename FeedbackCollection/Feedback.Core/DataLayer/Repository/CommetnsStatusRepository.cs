using Feedback.Core.DataLayer.Interface;
using Feedback.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feedback.Core.DataLayer.Repository
{
    public class CommetnsStatusRepository : BaseRepository<CommentsStatu>, ICommentsStatus, IDisposable
    {
        public FeedbackCollectionEntities context
        {
            get
            {
                return _db as FeedbackCollectionEntities;
            }
        }

        public CommetnsStatusRepository() : base(new FeedbackCollectionEntities())
        {

        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
