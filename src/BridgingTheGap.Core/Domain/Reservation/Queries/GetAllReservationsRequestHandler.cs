using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BridgingTheGap.Abstractions;
using BridgingTheGap.Abstractions.Domain.Reservation;
using BridgingTheGap.Data.Reservation;
using MediatR;

namespace BridgingTheGap.Core.Domain.Reservation.Queries;

public sealed class
    GetAllReservationsRequestHandler(ReservationRepository reservationRepository)
    : IRequestHandler<GetAllReservationsRequest,
        HandlerResult<IEnumerable<ReservationDto>>>
{
    public async Task<HandlerResult<IEnumerable<ReservationDto>>> Handle(GetAllReservationsRequest request,
        CancellationToken cancellationToken)
    {
        var random = Random.Shared;
        var reservations = await reservationRepository.GetAllAsync();

        return HandlerResult<IEnumerable<ReservationDto>>.Ok(reservations);
    }
}
