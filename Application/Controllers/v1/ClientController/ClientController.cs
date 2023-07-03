using CustomerPanel.Services;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CustomerPanel.Domain.Entity.Dto;

namespace CustomerPanel.Application.Controllers.v1
{
    [ApiController]
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _iclientService;

        public ClientController(IClientService iclientService)
        {
            _iclientService = iclientService;
        }

        /// <summary>
        /// Método HTTP GET que busca todos os registros de clientes.
        /// </summary>
        /// <returns> Retorna uma lista de clientes cadastrados.
        /// </returns>
        /// <remarks>
        /// Exemplo de requisição: http://localhost:5000/api/v1/client
        /// </remarks>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var client = await _iclientService.GetAllClients();
            return Ok(client);
        }

        /// <summary>
        /// Método HTTP GET que busca o registro de um clientes pelo seu ID.
        /// </summary>
        /// <param name="id">O ID do cliente a ser buscado.</param>
        /// <returns> Retorna um objeto com o cliente cadastrado.
        /// </returns>
        /// <remarks>
        /// Exemplo de requisição: http://localhost:5000/api/v1/client/id/1
        /// </remarks>
        [HttpGet("id/{id}")]
        public async Task<IActionResult> Get([FromRoute] uint id)
        {
            var client = await _iclientService.GetClientById(id);
            return Ok(client);
        }

        /// <summary>
        /// Método HTTP GET que busca o registro de um cliente com base em seu email e/ou telefone.
        /// </summary>
        /// <param name="mail">Email do cliente cadastrado</param>
        /// <param name="telephone">Telefone do cliente cadastrado</param>
        /// <returns> Retorna um objeto com o cliente cadastrado.
        /// </returns>
        /// <remarks>
        /// Exemplo de requisição: http://localhost:5000/api/v1/client/mail/user@email.com/telephone/999999999
        /// </remarks>
        [HttpGet("mail/{mail}/telephone/{telephone}")]
        public async Task<IActionResult> Get([FromRoute] string mail, [FromRoute] ulong telephone)
        {
            var client = await _iclientService.GetClientsByMailAndTelephone(mail, telephone);
            return Ok(client);
        }

        /// <summary>
        /// Método HTTP GET que busca o registro de um cliente com base em seu DDD e/ou telefone.
        /// </summary>
        /// <param name="DDD">DDD do cliente cadastrado</param>
        /// <param name="telephone">Telefone do cliente cadastrado</param>
        /// <returns> Retorna um objeto com o cliente cadastrado.
        /// </returns>
        /// <remarks>
        /// Exemplo de requisição: http://localhost:5000/api/v1/client/ddd/11/telephone/999999999
        /// </remarks>
        [HttpGet("ddd/{DDD}/telephone/{telephone}")]
        public async Task<IActionResult> Get([FromRoute] uint DDD, [FromRoute] ulong telephone)
        {
            var client = await _iclientService.GetClientsByDDDAndTelephone(DDD, telephone);
            return Ok(client);
        }

        /// <summary>
        /// Método HTTP POST que cadastra um novo cliente na base de dados.
        /// </summary>
        /// <param name="clientDtoAction">Objeto DtoAction responsavel por carregar as informações do novo cadastro.</param>
        /// <returns> Retorna um objeto com o cliente cadastrado.
        /// </returns>
        /// <remarks>
        /// Exemplo de requisição: http://localhost:5000/api/v1/client/
        /// Usar estrutura de body, disponibilizado na aplicação do Swagger
        /// </remarks>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ClientDtoAction clientDtoAction)
        {
            var client = await _iclientService.InsertClient(clientDtoAction);
            return Ok(client);
        }

        /// <summary>
        /// Método HTTP PUT que atualiza o cadastro de um cliente na base de dados.
        /// </summary>
        /// <param name="clientDtoAction">Objeto DtoAction responsavel por carregar as informações a serem modificadas.</param>
        /// <returns> Retorna um objeto com o cliente aopos alteração.
        /// </returns>
        /// <remarks>
        /// Exemplo de requisição: http://localhost:5000/api/v1/client/
        /// Usar estrutura de body, disponibilizado na aplicação do Swagger
        /// </remarks>
        [HttpPut("id/{id}")]
        public async Task<IActionResult> Put ([FromRoute] uint id, [FromBody] ClientDtoAction clientDtoAction)
        {
            var client = await _iclientService.UpdateClient(id, clientDtoAction);
            return Ok(client);
        }

        /// <summary>
        /// Método HTTP DELETE que exclui o cadastro de um cliente na base de dados com base em seu email.
        /// </summary>
        /// <param name="mail">Email vinculado ao cliente.</param>
        /// <remarks>
        /// Exemplo de requisição: http://localhost:5000/api/v1/client/
        /// Usar estrutura de body, disponibilizado na aplicação do Swagger
        /// </remarks>
        [HttpDelete("mail/{mail}")]
        public async Task Delete([FromRoute] string mail)
        {
            await _iclientService.DeleteClient(mail);
        }
    }
}