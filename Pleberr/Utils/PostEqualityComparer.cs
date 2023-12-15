using Pleberr.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pleberr.Utils
{
    public class PostEqualityComparer : IEqualityComparer<Post>
    {
        public bool Equals(Post x, Post y)
        {
            return x.Owner == y.Owner;
        }

        public int GetHashCode(Post obj)
        {
            return obj.Owner.GetHashCode();
        }
    }
}
