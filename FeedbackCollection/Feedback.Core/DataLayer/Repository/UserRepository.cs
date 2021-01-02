using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Feedback.Core.DataLayer.Interface;
using Feedback.Core.Models;

namespace Feedback.Core.DataLayer.Repository
{
    public class UserRepository : BaseRepository<User>, IUser, IDisposable
    {
        public FeedbackCollectionEntities context
        {
            get
            {
                return _db as FeedbackCollectionEntities;
            }
        }

        public UserRepository() : base(new FeedbackCollectionEntities())
        {

        }

        public void Dispose()
        {
            _db.Dispose();
        }

        public User GetUserByUserName(string userName)
        {
            return context.Users.Where(o => o.UserName == userName).FirstOrDefault();
        }
    }
}
