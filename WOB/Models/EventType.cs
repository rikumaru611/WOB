using System.ComponentModel.DataAnnotations;

namespace WOB.Models
{
    public class EventType
    {
        [Key]
        public int Id { get; set; }
        public string TypeName { get; set; }

    }
}
