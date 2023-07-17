using APIfin.Models.Dtos;
using APIfin.Models;
using APIfin.Data;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

namespace APIfin.Contoller;

[ApiController]
[Route("api/movement")]
public class MovementController : ControllerBase
{
    private DbRepository _repository;
    private IMapper _mapper;
    public MovementController(DbRepository repository, IMapper mapper){
        _repository = repository;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult Post(CreateMovementDto request){
        int Month = request.Date.Month;
        int Year = request.Date.Year;
        var period = _repository.Periods
                .FirstOrDefault(period => period.Month == Month && period.Year == Year);
        if(period == null) {
            period = new Period();
            period.Month = Month;
            period.Year = Year;
            _repository.Periods.Add(period);
            _repository.SaveChanges();
        }
        period = _repository.Periods
                .FirstOrDefault(period => period.Month == Month && period.Year == Year);
        if(period == null ) return NotFound();

        Movement movement = _mapper.Map<Movement>(request);
        movement.Period = period;
        movement.IdPeriod = period.Id;
        _repository.Movements.Add(movement);
        _repository.SaveChanges();
        return Ok();
    }

    [HttpGet]
    public List<ReadMovementDto> Get(){
        return _mapper.Map<List<ReadMovementDto>>(_repository.Movements);
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id){
        var movement = _mapper.Map<ReadMovementDto>(_repository.Movements.FirstOrDefault(movement => movement.Id == id));
        if(movement == null) NotFound() ;
        return Ok(movement);
    }
    [HttpGet("period/{id}")]
    public IActionResult GetPerPeriod(int id){
        var movement = _mapper.Map<List<ReadMovementDto>>(_repository.Movements.Where(movement => movement.IdPeriod == id));
        if(movement == null) NotFound() ;
        return Ok(movement);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] UpdateMovementDto request){
        var movement = _repository.Movements.FirstOrDefault(movement => movement.Id == id);
        if(movement == null) return NotFound();
        _mapper.Map(request, movement);
        _repository.SaveChanges();
        return Ok();
    }
    [HttpDelete("{id}")]
    public IActionResult Delete(int id){
        var movement = _repository.Movements.FirstOrDefault(movement => movement.Id == id);
        if(movement == null) return NotFound();
        _repository.Remove(movement);
        _repository.SaveChanges();
        return Ok();
    }
}