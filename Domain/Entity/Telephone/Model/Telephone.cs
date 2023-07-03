namespace CustomerPanel.Domain.Entity.Model
{
    public class Telephone
    {
        public uint Id { get; set; }
        public uint ClientId { get; set; }
        public uint DDD { get; set; }
        public ulong Number { get; set; }
        public string TypeNumber { get; set; }
    }
}