using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WOB.Models
{
    public class Player
    {
        [Key]
        public int Number { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }
        public double Height { get; set; }

        public double Weight { get; set; }
        [ForeignKey("Status")]
        public int StatusId { get; set; }

        public Status Status { get; set; }
    }
}
