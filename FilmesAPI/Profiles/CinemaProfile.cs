using AutoMapper;
using FilmesApi.Data.Dtos;
using FilmesAPI.Data.DTOs;
using FilmesAPI.Models;

namespace FilmesApi.Profiles;

public class CinemaProfile : Profile
{
    public CinemaProfile()
    {
        CreateMap<CreateCinemaDTO, Cinema>();
        CreateMap<Cinema, ReadCinemaDTO>();
        CreateMap<UpdateCinemaDTO, Cinema>();
    }

}