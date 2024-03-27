using AutoMapper;
using CarsUsingLazyLoad.Data.Dtos;
using CarsUsingLazyLoad.Data.Models;
using CarsUsingLazyLoad.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CarsUsingLazyLoad.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class CarController(ICarRepository repository, IMapper mapper) : ControllerBase
  {
    private readonly ICarRepository _repository = repository;
    private readonly IMapper _mapper = mapper;

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
      var cars = await _repository.GetAll();
      return cars.Any()
        ? Ok(cars) :
        BadRequest("Carros não encontrados.");
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
      var car = await _repository.GetById(id);
      var carRetorno = _mapper.Map<CarDetail>(car);

      return carRetorno != null ? Ok(carRetorno) : BadRequest("Carro não encontrado.");
    }
    [HttpPost]
    public async Task<IActionResult> Post(CarAddDto car)
    {
      if (car == null) return BadRequest("Dados Inválidos");

      var carAdicionar = _mapper.Map<Car>(car);

      _repository.Add(carAdicionar);

      return await _repository.SaveChangesAsync()
          ? Ok("Carro adicionado com sucesso.")
          : BadRequest("Erro ao salvar o carro.");
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, CarAddDto car)
    {
      if (id <= 0) return BadRequest("Carro não informado.");

      var carBanco = await _repository.GetById(id);

      var carAtualizar = _mapper.Map(car, carBanco);

      _repository.Update(carAtualizar);

      return await _repository.SaveChangesAsync()
           ? Ok("Carro atualizado com sucesso.")
           : BadRequest("Erro ao atualizar o carro.");
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
      if (id <= 0) return BadRequest("Carro inválido.");

      var carExclui = await _repository.GetById(id);

      if (carExclui == null) return NotFound("Carro não encontrado.");

      _repository.Delete(carExclui);

      return await _repository.SaveChangesAsync()
           ? Ok("Carro deletado com sucesso")
           : BadRequest("Erro ao deletar o carro.");
    }

  }
}
