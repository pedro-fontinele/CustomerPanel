using CustomerPanel.Domain.Entity.Dto;

namespace CustomerPanel.Services
{
    public interface IClientService
    {
        // Consult
        Task<List<ClientDtoConsult>> GetAllClients();
        Task<ClientDtoConsult> GetClientById(uint id);
        Task<List<ClientDtoConsult>> GetClientsByMailAndTelephone(string mail, ulong telephone);
        Task<List<ClientDtoConsult>> GetClientsByDDDAndTelephone(uint DDD, ulong telephone);

        // Action
        Task<ClientDtoAction> InsertClient(ClientDtoAction clientDto);
        Task<ClientDtoAction> UpdateClient(uint id, ClientDtoAction clientDto);
        Task DeleteClient(string mail);
    }
}