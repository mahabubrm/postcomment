using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feedback.Core.Models.ViewModels
{
    public class PostCommentViewModel
    {
        public int CommentId { set; get; }
        public string Comment { set; get; }
        public string Date { set; get; }
    }
}
