using System.Linq;
using CustomerPanel.Data.Context;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using CustomerPanel.Domain.Entity.Model;

namespace CustomerPanel.Persistence.Repository
{
    public class ClientRepository : IClientRepository
    {
        private readonly DataContext _dataContext;

        public ClientRepository(DataContext dataContext)
        {
             _dataContext = dataContext;
        }

        public async Task<List<Client>> GetAllClients()
        {
            IQueryable<Client> query = _dataContext.Client;

            query = query.AsNoTracking()
                         .Include(e => e.Telephone)
                         .OrderByDescending(e => e.Id);

            return await query.ToListAsync();
        }

        public async Task<Client> GetClientById(uint id)
        {
            IQueryable<Client> query = _dataContext.Client;

            query = query.AsNoTracking()
                         .Where(e => e.Id == id)
                         .Include(e => e.Telephone);

            return await query.FirstAsync();
        }

        public async Task<List<Client>> GetClientsByMail(string mail)
        {
            IQueryable<Client> query = _dataContext.Client;

            query = query.AsNoTracking()
                         .Where(c => c.Mail == mail)
                         .Include(c => c.Telephone);

            return await query.ToListAsync();
        }

        public async Task<List<Client>> GetClientsByMailAndTelephone(string mail, ulong telephone)
        {
            IQueryable<Client> query = _dataContext.Client;

            query = query.AsNoTracking()
                         .Where(c => c.Mail == mail || c.Telephone.Any(t => t.Number == telephone))
                         .Include(c => c.Telephone);

            return await query.ToListAsync();
        }

        public async Task<List<Client>> GetClientsByDDDAndTelephone(uint DDD, ulong telephone)
        {
            IQueryable<Client> query = _dataContext.Client;

            query = query.AsNoTracking()
                         .Where(c => c.Telephone.Any(t => t.DDD == DDD && t.Number == telephone))
                         .Include(c => c.Telephone);

            return await query.ToListAsync();
        }

        public async Task InsertClient(Client client)
        {
            _dataContext.Client.Add(client);
            await _dataContext.SaveChangesAsync();
        }

        public async Task UpdateClient(Client client)
        {
            _dataContext.Client.Update(client);
            await _dataContext.SaveChangesAsync();
        }

        public async Task DeleteClient(Client client)
        {
            _dataContext.Client.Remove(client);
            await _dataContext.SaveChangesAsync();
        }
    }
}