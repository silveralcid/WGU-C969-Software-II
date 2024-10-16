namespace AMS.UI.Domain.Entities
{
    public class Address : BaseEntity
    {
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public City City { get; set; }
        public string PostalCode { get; set; }
        public string PhoneNumber { get; set; }
    }
}
