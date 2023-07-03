using AutoMapper;
using CustomerPanel.Domain.Entity.Dto;
using CustomerPanel.Domain.Entity.Model;

namespace CustomerPanel.Domain.Entity.AutoMapper
{
    public class ClientMapper : Profile
    {
        public ClientMapper()
        {
            // Consult
            CreateMap<Client, ClientDtoConsult>().ReverseMap();
        
            // Action
            CreateMap<Client, ClientDtoAction>().ReverseMap();
        }
    }
}
