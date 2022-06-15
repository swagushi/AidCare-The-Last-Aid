namespace AidCare_The_Last_Aid.Models
{
    public class donation
    {
        public int donationId { get; set; }
        public string donationDescription { get; set; }
        public int DonationAmount { get; set; }
        public member member { get; set; }
    }
}
