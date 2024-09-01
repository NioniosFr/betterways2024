using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BridgingTheGap.Core.Domain.Reservation.Queries;
using BridgingTheGap.Data.Reservation;
using Xunit;

namespace BridgingTheGap.Core.Tests.Domain.Reservaations;

public class GetAllReservationsRequestHandlerTests
{
    [Fact]
    public async Task TestThatTheHandlerReturnsOkWithANonEmptyResponse()
    {
        // Arrange
        var getAllReservationsRequestHandler = new GetAllReservationsRequestHandler(new ReservationRepository());

        // Act
        var response =
            await getAllReservationsRequestHandler.Handle(new GetAllReservationsRequest(), CancellationToken.None);

        // Assert
        Assert.NotNull(response);
        Assert.NotNull(response.Data);
        Assert.True(response.Data.Any());
    }
}
