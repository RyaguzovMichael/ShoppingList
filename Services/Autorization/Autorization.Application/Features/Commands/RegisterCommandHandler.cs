using Ardalis.Result;
using Authorization.Domain.DbModels;
using Authorization.Infrastructure.Abstractions;
using AutoMapper;
using MediatR;
using System.Security.Claims;

namespace Authorization.Application.Features.Commands;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, (List<Claim>, Result<RegisterCommandVm>)>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public RegisterCommandHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<(List<Claim>, Result<RegisterCommandVm>)> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        User user = await _userRepository.AddAsync(_mapper.Map<User>(request));
        List<Claim> claims = new()
        {
            new Claim(ClaimTypes.Name, user.Name + " " + user.Surname),
            new Claim(ClaimTypes.NameIdentifier, user.Login)
        };
        var responce = _mapper.Map<RegisterCommandVm>(user);
        return (claims, Result.Success(responce));
    }
}
