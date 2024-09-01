using System;

namespace BridgingTheGap.Data.Reservation;

public class ReservationItemEntity
{
    public int Id { get; set; }
    public string CustomerName { get; set; }
    public string RoomName { get; set; }
    public DateTime CheckIn { get; set; }
    public DateTime CheckOut { get; set; }
    public int NumberOfGuests { get; set; }
    public decimal TotalPrice { get; set; }
}