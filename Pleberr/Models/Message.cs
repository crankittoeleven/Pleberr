using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pleberr.Models
{
    public class Message
    {
        public int Id { get; set; }
        public int From { get; set; }
        public int To { get; set; }
        public DateTime DateCreated { get; set; }
        public string Content { get; set; }
        public bool Read { get; set; }
    }
}
