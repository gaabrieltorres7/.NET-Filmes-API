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
        CreateMap<Cinema, ReadCinemaDTO>().ForMember(cinemaDto => cinemaDto.Endereco, // para um membro de destino específico (ReadEnderecoDTO) quero que pegue do cinema
            opt => opt.MapFrom(cinema => cinema.Endereco)) // o endereço
            .ForMember(cinemaDto => cinemaDto.Sessoes,
            opt => opt.MapFrom(cinema => cinema.Sessoes));
            
        CreateMap<UpdateCinemaDTO, Cinema>();
    }

}