namespace AMS.UI.Domain.Entities
{
    public class Customer : BaseEntity
    {
        public string Name { get; set; }
        public Address Address { get; set; }
        public bool IsActive { get; set; }
    }
}
