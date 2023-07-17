using APIfin.Models;
using APIfin.Data;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using APIfin.Models.Dtos;

namespace APIfin.Contoller;

[ApiController]
[Route("api/period")]
public class PeriodController : ControllerBase
{
    private DbRepository _repository;
    private IMapper _mapper;

    public PeriodController(DbRepository repository, IMapper mapper){
        _repository = repository;
        _mapper = mapper;
    }

    [HttpGet]
    public List<Period> Get(){
        return _mapper.Map<List<Period>>(_repository.Periods);
    }
    [HttpGet("Statement/{Year}")]
    public IActionResult GetStatementYearly(int year){
        float debt = 0 ;
        float cred = 0;
        ValueMovementDto ValueMovement = new ValueMovementDto();
        var period = _mapper.Map<List<Period>>(_repository.Periods.Where(period => period.Year == year));
        if(period == null) return NotFound();
        foreach(Period IdPeriod in period){
            debt = debt + _repository.Movements
                    .Where(movement => movement.IdPeriod == IdPeriod.Id  && movement.Type == "1")
                    .Sum(x => x.Value);

            cred = cred+ _repository.Movements
                    .Where(movement => movement.IdPeriod == IdPeriod.Id  && movement.Type == "0")
                    .Sum(x => x.Value);
        }
        ValueMovement.Value = cred - debt;
        return Ok(ValueMovement);
    }

    [HttpGet("Statement/mouth={mouth}&year={year}")]
    public IActionResult GetMonthlyStatement(int mouth, int year){
        float debt = 0 ;
        float cred = 0;
        ValueMovementDto ValueMovement = new ValueMovementDto();
        var period = _repository.Periods.FirstOrDefault(period => period.Month == mouth && period.Year == year);
        if(period == null) return NotFound();

        debt = _repository.Movements
                .Where(movement => movement.IdPeriod == period.Id  && movement.Type == "1")
                .Sum(x => x.Value);

        cred = _repository.Movements
                .Where(movement => movement.IdPeriod == period.Id  && movement.Type == "0")
                .Sum(x => x.Value);

        ValueMovement.Value = cred - debt;
        return Ok(ValueMovement);
    }
}