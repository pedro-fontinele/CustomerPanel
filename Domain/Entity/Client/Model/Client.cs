using System.Collections.Generic;

namespace CustomerPanel.Domain.Entity.Model
{
    public class Client
    {
        public uint Id { get; set; }
        public string LegalName { get; set; }
        public string Mail { get; set; }
        public List<Telephone> Telephone { get; set; }
    }
}
