using AutoMapper;
using CarsUsingLazyLoad.Data.Dtos;
using CarsUsingLazyLoad.Data.Models;
using CarsUsingLazyLoad.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ClientsUsingLazyLoad.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ClientController(IClientRepository repository, IMapper mapper) : ControllerBase
  {
    private readonly IClientRepository _repository = repository;
    private readonly IMapper _mapper = mapper;


    [HttpGet("{id}/salebyclient")]
    public async Task<IActionResult> GetSaleByClientId(int id)
    {
      var sale = await _repository.GetSaleByClientId(id);
      return sale != null ? Ok(sale) : NotFound("Cliente não possui vendas.");
    }
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
      var clients = await _repository.GetAll();
      return clients.Any()
        ? Ok(clients) :
        BadRequest("Clientes não encontrados.");
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
      var client = await _repository.GetById(id);
      //var clientRetorno = _mapper.Map<Client>(client);
      return client != null ? Ok(client) : BadRequest("Cliente não encontrado.");
    }
    [HttpPost]
    public async Task<IActionResult> Post(ClientAddDto client)
    {
      if (client == null) return BadRequest("Dados Inválidos");

      var clientAdicionar = _mapper.Map<Client>(client);

      _repository.Add(clientAdicionar);

      return await _repository.SaveChangesAsync()
          ? Ok("Cliente adicionado com sucesso.")
          : BadRequest("Erro ao salvar o cliente.");
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, ClientAddDto client)
    {
      if (id <= 0) return BadRequest("Cliente não informado.");

      var clientBanco = await _repository.GetById(id);

      var clientAtualizar = _mapper.Map(client, clientBanco);

      _repository.Update(clientAtualizar);

      return await _repository.SaveChangesAsync()
           ? Ok("Cliente atualizado com sucesso.")
           : BadRequest("Erro ao atualizar o cliente.");
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
      if (id <= 0) return BadRequest("Cliente inválido.");

      var clientExclui = await _repository.GetById(id);

      if (clientExclui == null) return NotFound("Cliente não encontrado.");

      _repository.Delete(clientExclui);

      return await _repository.SaveChangesAsync()
           ? Ok("Cliente deletado com sucesso")
           : BadRequest("Erro ao deletar o cliente.");
    }


  }
}
