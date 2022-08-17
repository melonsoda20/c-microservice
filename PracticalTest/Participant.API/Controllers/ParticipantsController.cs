using MediatR;
using Microsoft.AspNetCore.Mvc;
using Participant.Application.Contracts.Services.Shared;
using Participant.Application.Features.Participants.Commands.CreateParticipant;
using Participant.Application.Models.DTOs;
using System.Net;

namespace Participant.API.Controllers
{
    public class ParticipantsController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly IMapperServices _mapperServices;

        public ParticipantsController(
            IMediator mediator,
            IMapperServices mapper
        )
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _mapperServices = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpPost(Name = "CreateParticipants")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreateParticipant([FromBody] CreateParticipantDTO request)
        {
            var createParams = _mapperServices.MapObjects<CreateParticipantDTO, CreateParticipantCommand>(request);
            createParams.Token = Request.Headers["Authorization"];
            var result = await _mediator.Send(createParams);
            if (!result)
            {
                return BadRequest();
            }
            return Ok(result);
        }
    }
}
