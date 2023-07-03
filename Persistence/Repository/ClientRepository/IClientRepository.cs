using System.Threading.Tasks;
using CustomerPanel.Domain.Entity.Model;
using System.Collections.Generic;

namespace CustomerPanel.Persistence.Repository
{
    public interface IClientRepository
    {
        // Consult
        Task<List<Client>> GetAllClients();
        Task<Client> GetClientById(uint id);
        Task<List<Client>> GetClientsByMail(string mail);
        Task<List<Client>> GetClientsByMailAndTelephone(string mail, ulong telephone);
        Task<List<Client>> GetClientsByDDDAndTelephone(uint DDD, ulong telephone);

        // Action
        Task InsertClient(Client client);
        Task UpdateClient(Client client);
        Task DeleteClient(Client client);
    }
}