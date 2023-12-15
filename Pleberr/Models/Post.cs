using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pleberr.Models
{
    public class Post
    {
        public int Id { get; set; }
        public int Owner { get; set; }
        public int Author { get; set; }
        public DateTime DateCreated { get; set; }
        public string Content { get; set; }
        public int Likes { get; set; }
        public string Type { get; set; }
        public string Privacy { get; set; }
        public string Name { get; set; }
    }
}
