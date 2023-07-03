using AutoMapper;
using CustomerPanel.Domain.Entity.Dto;
using CustomerPanel.Domain.Entity.Model;
using CustomerPanel.Persistence.Repository;

namespace CustomerPanel.Services
{
    public class ClientService : IClientService
    {
        private readonly IMapper _imapper;
        private readonly IClientRepository _iclientRepository;

        public ClientService(IMapper imapper, IClientRepository iclientRepository)
        {
            _imapper = imapper;
            _iclientRepository = iclientRepository;
        }

        public async Task<List<ClientDtoConsult>> GetAllClients()
        {
            var returnedClient = await _iclientRepository.GetAllClients();
            return _imapper.Map<List<ClientDtoConsult>>(returnedClient);
        }

        public async Task<ClientDtoConsult> GetClientById(uint id)
        {
            var returnedClient = await _iclientRepository.GetClientById(id);
            return _imapper.Map<ClientDtoConsult>(returnedClient);
        }

        public async Task<List<ClientDtoConsult>> GetClientsByMailAndTelephone(string mail, ulong telephone)
        {
            var returnedClient = await _iclientRepository.GetClientsByMailAndTelephone(mail, telephone);
            return _imapper.Map<List<ClientDtoConsult>>(returnedClient);
        }

        public async Task<List<ClientDtoConsult>> GetClientsByDDDAndTelephone(uint DDD, ulong telephone)
        {
            var returnedClient = await _iclientRepository.GetClientsByDDDAndTelephone(DDD, telephone);
            return _imapper.Map<List<ClientDtoConsult>>(returnedClient);
        }

        public async Task<ClientDtoAction> InsertClient(ClientDtoAction clientDto)
        {
            if (clientDto == null)
            {
                return null;
            }

            var client = _imapper.Map<Client>(clientDto);
            await _iclientRepository.InsertClient(client);
            return _imapper.Map<ClientDtoAction>(client);
        }

        public async Task<ClientDtoAction> UpdateClient(uint id, ClientDtoAction clientDto)
        {
            if (clientDto == null)
            {
                return null;
            }

            var client = await _iclientRepository.GetClientById(id);
            if (client == null)
            {
                return null;
            }

            client = _imapper.Map<Client>(clientDto);
            client.Id = id;
            await _iclientRepository.UpdateClient(client);
            return _imapper.Map<ClientDtoAction>(client);
        }

        public async Task DeleteClient(string mail)
        {
            var client = await _iclientRepository.GetClientsByMail(mail);
            if(client != null)
            {
                foreach (var item in client)
                {
                    await _iclientRepository.DeleteClient(item);
                }
            }
        }
    }
}