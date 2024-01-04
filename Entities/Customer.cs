namespace PelatologioApi.Entities
{
    public class Customer : CustomerBase
    {
        public Telephone Telephones { get; set; }
        public string Response { get; set; } = string.Empty;
    }

    public class CustomerDbData : CustomerBase
    {
        public int TelephoneId { get; set; }
    }

    public class CustomerBase
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string? Address { get; set; }
        public string Email { get; set; } = string.Empty;
    }

}
