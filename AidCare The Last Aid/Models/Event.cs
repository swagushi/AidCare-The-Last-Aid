namespace AidCare_The_Last_Aid.Models
{
    public class Event
    {
        public int EventId { get; set; }
        public string EventName { get; set; }
        public string EventLocation { get; set; }
        public DateTime DateTime { get; set; }
        public ICollection<memberevent> memberevent { get; set; }
    }
}
