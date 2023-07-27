using AutoMapper;
using FilmesApi.Data.Dtos;
using FilmesAPI.Data.DTOs;
using FilmesAPI.Models;

namespace FilmesApi.Profiles;

public class FilmeProfile : Profile
{
    public FilmeProfile()
    {
        CreateMap<CreateFilmeDto, Filme>();
        CreateMap<UpdateFilmeDto, Filme>();
        CreateMap<Filme, UpdateFilmeDto>();
        CreateMap<Filme, ReadFilmeDto>().ForMember(filmeDto => filmeDto.Sessoes,
            opt => opt.MapFrom(filme => filme.Sessoes));
    }

}