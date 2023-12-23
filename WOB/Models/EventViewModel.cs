namespace WOB.Models
{
    public class EventViewModel
    {
        public EventViewModel(Event eve) {
            title = eve.Title;
            start = eve.Start;
            end = eve.End;
        }
        public string title { get; set; }     
        public DateTime start { get; set; }
        public DateTime end { get; set; }

    }
}
