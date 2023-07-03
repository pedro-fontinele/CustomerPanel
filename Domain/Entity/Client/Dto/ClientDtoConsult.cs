using System.Collections.Generic;
using CustomerPanel.Domain.Entity.Model;

namespace CustomerPanel.Domain.Entity.Dto
{
    public class ClientDtoConsult
    {
        public uint Id { get; set; }
        public string LegalName { get; set; }
        public string Mail { get; set; }
        public List<TelephoneDtoConsult> Telephone { get; set; }
    }
}