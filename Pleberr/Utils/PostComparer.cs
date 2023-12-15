using Pleberr.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pleberr.Utils
{
    public class PostComparer : IComparer<Post>
    {
        public int Compare(Post x, Post y)
        {
            return x.DateCreated.CompareTo(y.DateCreated);
        }
    }
}
