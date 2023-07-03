using AutoMapper;
using CustomerPanel.Domain.Entity.Dto;
using CustomerPanel.Domain.Entity.Model;

namespace CustomerPanel.Domain.Entity.AutoMapper
{
    public class TelephoneMapper : Profile
    {
        public TelephoneMapper()
        {
            // Consult
            CreateMap<Telephone, TelephoneDtoConsult>().ReverseMap();

            // Action
            CreateMap<Telephone, TelephoneDtoAction>().ReverseMap();
        }
    }
}