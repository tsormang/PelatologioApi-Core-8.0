namespace PelatologioApi.Entities
{
    public class Customer : BaseCustomer
    {
        public Telephone Telephones { get; set; }
    }

    public class CustomerDbData : BaseCustomer
    {
        public int Id { get; set; }
        public int TelephoneId { get; set; }
    }

    public class BaseCustomer
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string? Address { get; set; }
        public string Email { get; set; } = string.Empty;
    }
}
