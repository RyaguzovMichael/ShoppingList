using Ardalis.Result;
using AutoMapper;
using CommonRepository.Models;

namespace Authorization.API.Mappings;

public class FrontendMappingProfile : Profile
{
    public FrontendMappingProfile()
    {
        CreateMap(typeof(Result<>), typeof(DefaultResponseObject<>));
    }
}
