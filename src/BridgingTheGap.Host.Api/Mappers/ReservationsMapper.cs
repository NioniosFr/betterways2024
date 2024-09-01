using System;
using System.Collections.Generic;
using System.Linq;
using BridgingTheGap.Abstractions.Domain.Reservation;
using BridgingTheGap.Api.Models.Reservation;

namespace BridgingTheGap.Host.Api.Mappers;

public static class ReservationsMapper
{
    public static readonly Func<IEnumerable<ReservationDto>, IEnumerable<ReservationItem>> Map = (model)
        => model.Select(x => new ReservationItem
        {
            Id = x.Id,
            CustomerName = x.CustomerName,
            RoomName = x.RoomName,
            CheckIn = x.CheckIn,
            CheckOut = x.CheckOut,
            NumberOfGuests = x.NumberOfGuests,
            TotalPrice = x.TotalPrice
        });
}