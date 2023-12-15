using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pleberr.Models
{
    public class Request
    {
        public int Id { get; set; }
        public int From { get; set; }
        public int To { get; set; }
        public bool Accepted { get; set; }
        public bool Read { get; set; }
        public bool Pending { get; set; }
        public string FromName { get; set; }
        public string ToName { get; set; }
    }
}
