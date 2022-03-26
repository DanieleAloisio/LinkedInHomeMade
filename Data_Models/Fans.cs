using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Models
{
    public class Fans
    {

        [ForeignKey("FanUserId")]
        public string FanUserId { get; set; }
        public ApplicationUser FanUser{ get; set; }
        [ForeignKey("FollowUserId")]
        public string FollowUserId { get; set; }
        public ApplicationUser FollowUser{ get; set; }

        public DateTime? RequestTime { get; set; }
    }
}
