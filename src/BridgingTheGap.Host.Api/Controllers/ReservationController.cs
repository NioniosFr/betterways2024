using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Threading;
using System.Threading.Tasks;
using BridgingTheGap.Abstractions;
using BridgingTheGap.Abstractions.Domain.Reservation;
using BridgingTheGap.Host.Api.Mappers;
using BridgingTheGap.Api.Models;
using BridgingTheGap.Api.Models.Reservation;
using BridgingTheGap.Core.Domain.Reservation.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BridgingTheGap.Host.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ReservationController : ApiControllerBase
{
    private readonly ILogger<ReservationController> _logger;
    private readonly IMediator _mediator;

    public ReservationController(ILogger<ReservationController> logger, IMediator mediator)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    [HttpGet("Index")]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(ApiResponse<ReservationItem>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetReservations(CancellationToken cancellationToken = default)
    {
        HandlerResult<IEnumerable<ReservationDto>> response = await _mediator.Send(new GetAllReservationsRequest(), cancellationToken);
        return HandleResult(response, ReservationsMapper.Map);
    }
}