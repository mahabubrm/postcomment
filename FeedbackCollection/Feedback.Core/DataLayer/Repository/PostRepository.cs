using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Feedback.Core.DataLayer.Interface;
using Feedback.Core.Models;

namespace Feedback.Core.DataLayer.Repository
{
    public class PostRepository : BaseRepository<Post>, IPost, IDisposable
    {
        public FeedbackCollectionEntities context
        {
            get
            {
                return _db as FeedbackCollectionEntities;
            }
        }

        public PostRepository() : base(new FeedbackCollectionEntities())
        {

        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
