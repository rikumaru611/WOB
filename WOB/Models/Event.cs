using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WOB.Models
{
    public class Event
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        [ForeignKey(nameof(EventType))]
        public int EventTypeId { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public string Time { get; set; }

        public string? Place { get; set; }

        public string? Description { get; set; }

        public Boolean Valid { get; set; }
        
        public EventType? Type { get; set; }

        // この1文でエラーでる
        //public virtual List<EventType> EventTypes { get; set; }
    }
}
