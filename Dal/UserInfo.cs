using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    [Serializable]
    public class UserInfo
    {
        public int UserID { get; set; }
        public string Name { get; set; }
        public string AvatarPath { get; set; }
    }
}
