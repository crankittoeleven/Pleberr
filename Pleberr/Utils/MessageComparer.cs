using Pleberr.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pleberr.Utils
{
    public class MessageComparer : IComparer<Message>
    {
        public int Compare(Message x, Message y)
        {
            return y.DateCreated.CompareTo(x.DateCreated);
        }
    }
}
