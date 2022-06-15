namespace AidCare_The_Last_Aid.Models
{
    public class member
    {
        public int memberId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateTime { get; set; }

        public ICollection<memberevent> membersevent { get; set; }
        public ICollection<donation> donations { get; set; }
    }
}
