using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pleberr.Models
{
    public class Setting
    {
        public int Id { get; set; }
        public int User { get; set; }
        public bool PostsPrivacy { get; set; }
        public bool InfoPrivacy { get; set; }
        public bool FriendsPrivacy { get; set; }
        public bool PicturesPrivacy { get; set; }
    }
}
