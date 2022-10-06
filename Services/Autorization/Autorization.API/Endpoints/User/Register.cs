using Ardalis.ApiEndpoints;
using Authorization.API.Extensions;
using Authorization.Application.Features.Commands;
using AutoMapper;
using CommonRepository.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Authorization.API.Endpoints.User
{
    public class Register : EndpointBaseAsync
        .WithRequest<RegisterCommand>
        .WithResult<ActionResult>
    {
        private readonly JWTSettings _jwtSettings;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public Register(IOptions<JWTSettings> options, IMediator mediator, IMapper mapper)
        {
            _jwtSettings = options.Value;
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost("user/regiser")]
        public override async Task<ActionResult> HandleAsync([FromBody] RegisterCommand request, CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(request, cancellationToken);
            if (result.Item2.IsSuccess) HttpContext.Response.Cookies.SetJwtToken(result.Item1, _jwtSettings);
            return Ok(_mapper.Map<DefaultResponseObject<RegisterCommandVm>>(result.Item2));
        }
    }
}
