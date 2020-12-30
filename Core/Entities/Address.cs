namespace eShop_Backend.Core.Entities
{
    public partial class Address
    {
        public int Id { get; set; }
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public int? Pincode { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}
