using AutoMapper;
using FilmesAPI.Models;
using FilmesAPI.Data.DTOs;

namespace FilmesAPI.Profiles;
public class EnderecoProfile : Profile
{
  public EnderecoProfile()
  {
    CreateMap<CreateEnderecoDTO, Endereco>(); //mapeando é do dto para o model
    CreateMap<Endereco, ReadEnderecoDTO>(); //buscando do model para o dto
    CreateMap<UpdateEnderecoDTO, Endereco>(); //msm coisa do create
  }

}