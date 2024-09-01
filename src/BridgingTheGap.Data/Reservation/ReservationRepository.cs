using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
using BridgingTheGap.Abstractions.Domain.Reservation;

namespace BridgingTheGap.Data.Reservation;

public sealed class ReservationRepository
{
    List<ReservationItemEntity> Items { get; set; } = new List<ReservationItemEntity>
    {
        new()
        {
            Id = 1,
            CustomerName = "John Doe",
            RoomName = "Room A",
            CheckIn = DateTime.Now.AddDays(Random.Shared.Next(-10, 10)),
            CheckOut = DateTime.Now.AddDays(Random.Shared.Next(11, 20)),
            NumberOfGuests = Random.Shared.Next(1, 5),
            TotalPrice = (decimal)(Random.Shared.NextDouble() * 1000)
        },
        new()
        {
            Id = 2,
            CustomerName = "Jane Smith",
            RoomName = "Room B",
            CheckIn = DateTime.Now.AddDays(Random.Shared.Next(-10, 10)),
            CheckOut = DateTime.Now.AddDays(Random.Shared.Next(11, 20)),
            NumberOfGuests = Random.Shared.Next(1, 5),
            TotalPrice = (decimal)(Random.Shared.NextDouble() * 1000)
        },
        new()
        {
            Id = 3,
            CustomerName = "Alice Johnson",
            RoomName = "Room C",
            CheckIn = DateTime.Now.AddDays(Random.Shared.Next(-10, 10)),
            CheckOut = DateTime.Now.AddDays(Random.Shared.Next(11, 20)),
            NumberOfGuests = Random.Shared.Next(1, 5),
            TotalPrice = (decimal)(Random.Shared.NextDouble() * 1000)
        }
    };

    public Task<IReadOnlyCollection<ReservationDto>> GetAllAsync()
    {
        return Task.FromResult<IReadOnlyCollection<ReservationDto>>(
            Items.Select(x => new ReservationDto
            {
                Id = x.Id,
                CustomerName = x.CustomerName,
                RoomName = x.RoomName,
                CheckIn = x.CheckIn,
                CheckOut = x.CheckOut,
                NumberOfGuests = x.NumberOfGuests,
                TotalPrice = x.TotalPrice
            }).ToImmutableArray()
        );
    }
}
