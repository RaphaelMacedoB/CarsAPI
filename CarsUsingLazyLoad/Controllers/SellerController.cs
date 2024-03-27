using AutoMapper;
using CarsUsingLazyLoad.Data.Dtos;
using CarsUsingLazyLoad.Data.Models;
using CarsUsingLazyLoad.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace SellersUsingLazyLoad.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class SellerController(ISellerRepository repository, IMapper mapper) : ControllerBase
  {
    private readonly ISellerRepository _repository = repository;
    private readonly IMapper _mapper = mapper;

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
      var sellers = await _repository.GetAll();
      return sellers.Any()
        ? Ok(sellers) :
        BadRequest("Vendedores não encontrados.");
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
      var seller = await _repository.GetById(id);
      var sellerRetorno = _mapper.Map<SellerDto>(seller);

      return sellerRetorno != null ? Ok(sellerRetorno) : BadRequest("Vendedor não encontrado.");
    }
    [HttpPost]
    public async Task<IActionResult> Post(SellerAddDto seller)
    {
      if (seller == null) return BadRequest("Dados Inválidos");

      var sellerAdicionar = _mapper.Map<Seller>(seller);

      _repository.Add(sellerAdicionar);

      return await _repository.SaveChangesAsync()
          ? Ok("Vendedor adicionado com sucesso.")
          : BadRequest("Erro ao salvar o Vendedor.");
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, SellerAddDto seller)
    {
      if (id <= 0) return BadRequest("Vendedor não informado.");

      var sellerBanco = await _repository.GetById(id);

      var sellerAtualizar = _mapper.Map(seller, sellerBanco);

      _repository.Update(sellerAtualizar);

      return await _repository.SaveChangesAsync()
           ? Ok("Vendedor atualizado com sucesso.")
           : BadRequest("Erro ao atualizar o Vendedor.");
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
      if (id <= 0) return BadRequest("Vendedor inválido.");

      var sellerExclui = await _repository.GetById(id);

      if (sellerExclui == null) return NotFound("Vendedor não encontrado.");

      _repository.Delete(sellerExclui);

      return await _repository.SaveChangesAsync()
           ? Ok("Vendedor deletado com sucesso")
           : BadRequest("Erro ao deletar o Vendedor.");
    }

  }
}
