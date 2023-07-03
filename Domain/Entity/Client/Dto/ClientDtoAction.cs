using System.Collections.Generic;
using CustomerPanel.Domain.Entity.Model;

namespace CustomerPanel.Domain.Entity.Dto
{
    public class ClientDtoAction
    {
        public string LegalName { get; set; }
        public string Mail { get; set; }
        public List<TelephoneDtoAction> Telephone { get; set; }
    }
}