using Authorization.Application.Features.Commands;
using Authorization.Domain.DbModels;
using AutoMapper;

namespace Authorization.Application.Mappings;

public class BackendMappingProfile : Profile
{
	public BackendMappingProfile()
	{
		CreateMap<User, RegisterCommandVm>()
			.ForMember(x => x.UserName, (o => o.MapFrom(m => m.Name + " " + m.Surname)));
		CreateMap<RegisterCommand, User>();
	}
}
