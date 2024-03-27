using AutoMapper;
using CarsUsingLazyLoad.Data.Dtos;
using CarsUsingLazyLoad.Data.Models;
using CarsUsingLazyLoad.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace SalesUsingLazyLoad.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class SaleController(ISaleRepository repository, IMapper mapper, ICarRepository carRepository) : ControllerBase
  {
    private readonly ISaleRepository _repository = repository;
    private readonly ICarRepository _carRepository = carRepository;
    private readonly IMapper _mapper = mapper;

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
      var sales = await _repository.GetAll();
      return sales.Count != 0
        ? Ok(sales) :
        BadRequest("Vendas não encontradas.");
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
      var sale = await _repository.GetById(id);
      var saleRetorno = _mapper.Map<SaleDto>(sale);

      return saleRetorno != null ? Ok(saleRetorno) : BadRequest("Venda não encontrado.");
    }
    [HttpPost]
    public async Task<IActionResult> Post(SaleAddDto sale)
    {
      if (sale == null) return BadRequest("Dados Inválidos");

      var saleAdicionar = _mapper.Map<Sale>(sale);

      var carFromDb = await _carRepository.GetById(saleAdicionar.CarId);

      //var saleFromDb = await _repository.GetCarByCarId(saleAdicionar.CarId);

      if (carFromDb == null)
        return BadRequest("Carro não encontrado.");

      if (carFromDb.Amount <= 0)
        return BadRequest("Não há carros no estoque para fazer a venda.");

      carFromDb.Amount -= 1;

      _carRepository.Update(carFromDb);
      _repository.Update(saleAdicionar);

      return await _repository.SaveChangesAsync()
          ? Ok("Venda adicionada com sucesso.")
          : BadRequest("Erro ao salvar a venda.");
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, SaleAddDto sale)
    {
      if (id <= 0) return BadRequest("Venda não informado.");

      var saleBanco = await _repository.GetById(id);

      var saleAtualizar = _mapper.Map(sale, saleBanco);

      _repository.Update(saleAtualizar);

      return await _repository.SaveChangesAsync()
           ? Ok("Venda atualizado com sucesso.")
           : BadRequest("Erro ao atualizar o venda.");
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
      if (id <= 0) return BadRequest("Venda inválido.");

      var currentSale = await _repository.GetById(id);

      if (currentSale == null) return NotFound("Venda não encontrado.");

      var saleExclui = _mapper.Map<Sale>(currentSale);


      _repository.Delete(saleExclui);

      return await _repository.SaveChangesAsync()
           ? Ok("Venda removida com sucesso !")
           : BadRequest("Erro ao deletar o venda.");
    }

  }
}
