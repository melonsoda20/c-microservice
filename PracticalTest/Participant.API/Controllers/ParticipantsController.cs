using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Participant.Application.Features.Participants.Commands.CreateParticipant;
using System.Net;

namespace Participant.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ParticipantsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ParticipantsController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost(Name = "CreateParticipants")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreateParticipant([FromBody] CreateParticipantCommand request)
        {
            var result = await _mediator.Send(request);
            if (!result)
            {
                return BadRequest();
            }
            return Ok(result);
        }
    }
}
