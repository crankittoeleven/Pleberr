using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pleberr.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public int Post { get; set; }
        public int User { get; set; }
        public string Content { get; set; }
        public int Author { get; set; }
        public string Name { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
