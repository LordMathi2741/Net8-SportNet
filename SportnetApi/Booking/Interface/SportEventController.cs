using System.Net.Mime;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SportnetApi.Booking.Domain.Model.Aggregates;
using SportnetApi.Booking.Domain.Model.Commands;
using SportnetApi.Booking.Domain.Model.Queries;
using SportnetApi.Booking.Domain.Services;
using SportnetApi.Booking.Interface.Rest.Resources;
using SportnetApi.Booking.Interface.Rest.Transform;
using SportnetApi.Shared.Domain.Model.Exceptions;

namespace SportnetApi.Booking.Interface;

[ApiController]
[Produces(MediaTypeNames.Application.Json)]
[Route("api/v1/[controller]")]
[ProducesResponseType(400)]
[ProducesResponseType(500)]
[AllowAnonymous]

public class SportEventController(ISportEventCommandService sportEventCommandService, ISportEventQueryService sportEventQueryService) : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(201)]
    public async Task<IActionResult> CreateSportEvent ([FromBody] CreateSportEventResource resource)
    {
        var query = new CountSportNamesByLocationAndEventNameAndSportTypeQuery(resource.Location, resource.EventName, resource.SportType);
        var command = CreateSportEventCommandFromResourceAssembler.ToCommandFromResource(resource);
        var countRegisters = await sportEventQueryService.Handle(query.Location, query.EventName, query.SportType);
        if (countRegisters >= 2)
        {
            throw new SportEventAlreadyHave2RegisteresException("The sport event already have 2 registers in this location.");
        }
        var sportEvent = new SportEvent(command);
        await sportEventCommandService.Handle(command);
        var sportEventResource = SportEventResourceFromEntityAssembler.ToResourceFromEntity(sportEvent);
        return StatusCode(201, sportEventResource);
    }
}
