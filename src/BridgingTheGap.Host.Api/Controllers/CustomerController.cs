using System;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BridgingTheGap.Host.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class CustomerController : ApiControllerBase
{
    private readonly ILogger<CustomerController> _logger;
    private readonly IMediator _mediator;

    public CustomerController(ILogger<CustomerController> logger, IMediator mediator)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }
}