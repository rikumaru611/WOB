using System.ComponentModel.DataAnnotations;

namespace WOB.Models
{
    public class UserCode
    {
        [Key]
        public int Id { get; set; }
        public string Code { get; set; }
    }
}
