namespace PelatologioApi.Entities
{
    public class Telephone
    {
        public long? House { get; set; }
        public long? Mobile { get; set; }
        public long? Work { get; set; }
    }

    public class TelephoneDbData : Telephone
    {
        public int Id { get; set; }
    }

}
