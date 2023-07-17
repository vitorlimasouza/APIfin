using AutoMapper;
using APIfin.Models.Dtos;
using APIfin.Models;

public class MovementProfile : Profile
{
    public MovementProfile(){
        CreateMap<CreateMovementDto, Movement>();
        CreateMap<Movement, ReadMovementDto>();
        CreateMap<UpdateMovementDto, Movement>();    
    }
}