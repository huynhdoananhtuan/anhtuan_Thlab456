using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NguyenDuyNam_lab456.Models
{
    public class Following
    {
        [Key]
        [Column(Order = 1)]
        public string FolloWerId { get; set; }

        [Key]
        [Column(Order = 2)]
        public string FolloweerId { get; set; }
        public ApplicationUser Follower { get; set; }
        public ApplicationUser Follwee { get; set; }

    }
}