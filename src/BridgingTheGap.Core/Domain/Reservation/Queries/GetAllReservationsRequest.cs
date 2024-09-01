using System.Collections.Generic;
using BridgingTheGap.Abstractions;
using BridgingTheGap.Abstractions.Domain.Reservation;
using MediatR;

namespace BridgingTheGap.Core.Domain.Reservation.Queries;

public class GetAllReservationsRequest : IRequest<HandlerResult<IEnumerable<ReservationDto>>>
{
}
