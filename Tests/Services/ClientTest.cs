using Xunit;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CustomerPanel.Domain.Entity.Model;
using CustomerPanel.Persistence.Repository;
using CustomerPanel.Domain.Entity.Dto;
using CustomerPanel.Services;

namespace CustomerPanel.Tests.Services
{
    public class ClientTest
    {
        [Fact]
        public async Task GetAllClients_ShouldReturnAllClients()
        {
            // Arrange
            var mockClientRepository = new Mock<IClientRepository>();
            var mockMapper = new Mock<IMapper>();

            // Criar uma lista de Client a ser retornada pelo repositório
            var clients = new List<Client>
            {
                new Client { Id = 1, LegalName = "José da Silva" },
                new Client { Id = 2, LegalName = "Maria de Fatima" },
                new Client { Id = 3, LegalName = "Joesley Batista" }
            };

            // Configurar o comportamento do repositório mockado
            mockClientRepository.Setup(repo => repo.GetAllClients()).ReturnsAsync(clients);

            mockMapper.Setup(mapper => mapper.Map<List<ClientDtoConsult>>(It.IsAny<List<Client>>()))
                    .Returns((List<Client> input) => input.Select(c => new ClientDtoConsult { Id = c.Id, LegalName = c.LegalName }).ToList());

            var clientService = new ClientService(mockMapper.Object, mockClientRepository.Object);

            // Act
            var result = await clientService.GetAllClients();

            // Assert
            Assert.NotNull(result);
            Assert.IsType<List<ClientDtoConsult>>(result);
            Assert.Equal(3, result.Count);
        }

        [Fact]
        public async Task GetClientById_ShouldReturnClient()
        {
            // Arrange
            uint clientId = 1;
            var mockClientRepository = new Mock<IClientRepository>();
            var mockMapper = new Mock<IMapper>();

            var client = new Client { Id = clientId, LegalName = "José da Silva" };

            mockClientRepository.Setup(repo => repo.GetClientById(clientId)).ReturnsAsync(client);

            mockMapper.Setup(mapper => mapper.Map<ClientDtoConsult>(It.IsAny<Client>()))
                    .Returns((Client input) => new ClientDtoConsult { Id = input.Id, LegalName = input.LegalName });

            var clientService = new ClientService(mockMapper.Object, mockClientRepository.Object);

            // Act
            var result = await clientService.GetClientById(clientId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(clientId, result.Id);
            Assert.Equal(client.LegalName, result.LegalName);
        }

        [Fact]
        public async Task GetClientsByMailAndTelephone_ShouldReturnClients()
        {
            // Arrange
            string mail = "teste@example.com";
            ulong telephone = 123456789;
            var mockClientRepository = new Mock<IClientRepository>();
            var mockMapper = new Mock<IMapper>();

            var clients = new List<Client>
            {
                new Client { Id = 1, LegalName = "José da Silva" },
                new Client { Id = 2, LegalName = "Maria de Fatima" },
                new Client { Id = 3, LegalName = "Joesley Batista" }
            };

            mockClientRepository.Setup(repo => repo.GetClientsByMailAndTelephone(mail, telephone)).ReturnsAsync(clients);

            mockMapper.Setup(mapper => mapper.Map<List<ClientDtoConsult>>(It.IsAny<List<Client>>()))
                    .Returns((List<Client> input) => input.ConvertAll(c => new ClientDtoConsult { Id = c.Id, LegalName = c.LegalName }));

            var clientService = new ClientService(mockMapper.Object, mockClientRepository.Object);

            // Act
            var result = await clientService.GetClientsByMailAndTelephone(mail, telephone);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(clients.Count, result.Count);
            for (int i = 0; i < clients.Count; i++)
            {
                Assert.Equal(clients[i].Id, result[i].Id);
                Assert.Equal(clients[i].LegalName, result[i].LegalName);
            }
        }

        [Fact]
        public async Task GetClientsByDDDAndTelephone_ShouldReturnClients()
        {
            // Arrange
            uint ddd = 11;
            ulong telephone = 123456789;
            var mockClientRepository = new Mock<IClientRepository>();
            var mockMapper = new Mock<IMapper>();

            var clients = new List<Client>
            {
                new Client { Id = 1, LegalName = "José da Silva" },
                new Client { Id = 2, LegalName = "Maria de Fatima" },
                new Client { Id = 3, LegalName = "Joesley Batista" }
            };

            mockClientRepository.Setup(repo => repo.GetClientsByDDDAndTelephone(ddd, telephone)).ReturnsAsync(clients);

            mockMapper.Setup(mapper => mapper.Map<List<ClientDtoConsult>>(It.IsAny<List<Client>>()))
                    .Returns((List<Client> input) => input.ConvertAll(c => new ClientDtoConsult { Id = c.Id, LegalName = c.LegalName }));

            var clientService = new ClientService(mockMapper.Object, mockClientRepository.Object);

            // Act
            var result = await clientService.GetClientsByDDDAndTelephone(ddd, telephone);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(clients.Count, result.Count);
            for (int i = 0; i < clients.Count; i++)
            {
                Assert.Equal(clients[i].Id, result[i].Id);
                Assert.Equal(clients[i].LegalName, result[i].LegalName);
            }
        }

        [Fact]
        public async Task InsertClient_ShouldReturnInsertedClient()
        {
            // Arrange
            var clientDto = new ClientDtoAction { LegalName = "João Maia Doe" };
            var client = new Client { Id = 1, LegalName = "João Maia Doe" };
            var mockClientRepository = new Mock<IClientRepository>();
            var mockMapper = new Mock<IMapper>();

            mockMapper.Setup(mapper => mapper.Map<Client>(clientDto)).Returns(client);

            mockClientRepository.Setup(repo => repo.InsertClient(client)).Returns(Task.CompletedTask);

            mockMapper.Setup(mapper => mapper.Map<ClientDtoAction>(client)).Returns(clientDto);

            var clientService = new ClientService(mockMapper.Object, mockClientRepository.Object);

            // Act
            var result = await clientService.InsertClient(clientDto);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(clientDto.LegalName, result.LegalName);
        }

        [Fact]
        public async Task InsertClient_ShouldReturnNullWhenClientDtoIsNull()
        {
            // Arrange
            ClientDtoAction clientDto = null;
            var mockClientRepository = new Mock<IClientRepository>();
            var mockMapper = new Mock<IMapper>();

            var clientService = new ClientService(mockMapper.Object, mockClientRepository.Object);

            // Act
            var result = await clientService.InsertClient(clientDto);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task UpdateClient_ShouldReturnUpdatedClient()
        {
            // Arrange
            uint id = 1;
            var clientDto = new ClientDtoAction { LegalName = "João Maia Doe" };
            var existingClient = new Client { Id = 1, LegalName = "Existing Client" };
            var updatedClient = new Client { Id = 1, LegalName = "João Maia Doe" };

            var mockClientRepository = new Mock<IClientRepository>();
            var mockMapper = new Mock<IMapper>();

            mockClientRepository.Setup(repo => repo.GetClientById(id)).ReturnsAsync(existingClient);

            mockMapper.Setup(mapper => mapper.Map<Client>(clientDto)).Returns(updatedClient);

            mockClientRepository.Setup(repo => repo.UpdateClient(updatedClient)).Returns(Task.CompletedTask);

            mockMapper.Setup(mapper => mapper.Map<ClientDtoAction>(updatedClient)).Returns(clientDto);

            var clientService = new ClientService(mockMapper.Object, mockClientRepository.Object);

            // Act
            var result = await clientService.UpdateClient(id, clientDto);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(clientDto.LegalName, result.LegalName);
        }

        [Fact]
        public async Task UpdateClient_ShouldReturnNullWhenClientDtoIsNull()
        {
            // Arrange
            uint id = 1;
            ClientDtoAction clientDto = null;
            var mockClientRepository = new Mock<IClientRepository>();
            var mockMapper = new Mock<IMapper>();

            var clientService = new ClientService(mockMapper.Object, mockClientRepository.Object);

            // Act
            var result = await clientService.UpdateClient(id, clientDto);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task UpdateClient_ShouldReturnNullWhenClientNotFound()
        {
            // Arrange
            uint id = 1;
            var clientDto = new ClientDtoAction { LegalName = "João Maia Doe" };
            var mockClientRepository = new Mock<IClientRepository>();
            var mockMapper = new Mock<IMapper>();

            mockClientRepository.Setup(repo => repo.GetClientById(id)).ReturnsAsync((Client)null);

            var clientService = new ClientService(mockMapper.Object, mockClientRepository.Object);

            // Act
            var result = await clientService.UpdateClient(id, clientDto);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task DeleteClient_ShouldDeleteClients()
        {
            // Arrange
            string mail = "test@example.com";
            var clients = new List<Client>
            {
                new Client { Id = 1, Mail = mail },
                new Client { Id = 2, Mail = mail },
                new Client { Id = 3, Mail = mail }
            };

            var mockClientRepository = new Mock<IClientRepository>();
            var mockMapper = new Mock<IMapper>();

            mockClientRepository.Setup(repo => repo.GetClientsByMail(mail)).ReturnsAsync(clients);

            var clientService = new ClientService(mockMapper.Object, mockClientRepository.Object);

            // Act
            await clientService.DeleteClient(mail);

            // Assert
            foreach (var client in clients)
            {
                mockClientRepository.Verify(repo => repo.DeleteClient(client), Times.Once);
            }
        }

        [Fact]
        public async Task DeleteClient_ShouldNotDeleteClientsWhenMailNotFound()
        {
            // Arrange
            string mail = "test@example.com";
            var mockClientRepository = new Mock<IClientRepository>();
            var mockMapper = new Mock<IMapper>();

            mockClientRepository.Setup(repo => repo.GetClientsByMail(mail)).ReturnsAsync((List<Client>)null);

            var clientService = new ClientService(mockMapper.Object, mockClientRepository.Object);

            // Act
            await clientService.DeleteClient(mail);

            // Assert
            mockClientRepository.Verify(repo => repo.DeleteClient(It.IsAny<Client>()), Times.Never);
        }
    }
}