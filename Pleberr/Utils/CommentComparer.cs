using Pleberr.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pleberr.Utils
{
    public class CommentComparer : IComparer<Comment>
    {
        public int Compare(Comment x, Comment y)
        {
            return x.DateCreated.CompareTo(y.DateCreated);
        }
    }
}
