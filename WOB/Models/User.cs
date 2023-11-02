using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WOB.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [ForeignKey("UserCode")]
        public int UserCodeId { get; set; }

        [ForeignKey("Player")]
        public int? Number { get; set; }

        [ForeignKey("Coach")]
        public int? CoachId { get; set; }

        [ForeignKey("Staff")]
        public int? StaffId { get; set; }

        [EmailAddress]
        public string Mail { get; set;  }

        [Phone]
        public string Tel { get; set; }

        public UserCode UserCode { get; set; }
        public Coach Coach { get; set; }
        public Staff Staff { get; set; }
        public Player Player { get; set; }
    }
}
