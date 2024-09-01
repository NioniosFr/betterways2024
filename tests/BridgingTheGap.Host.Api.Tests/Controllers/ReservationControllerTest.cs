using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BridgingTheGap.Abstractions;
using BridgingTheGap.Abstractions.Domain.Reservation;
using BridgingTheGap.Api.Models;
using BridgingTheGap.Api.Models.Reservation;
using BridgingTheGap.Core.Domain.Reservation.Queries;
using BridgingTheGap.Host.Api.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace BridgingTheGap.Host.Api.Tests.Controllers;

public class ReservationControllerTest
{
    [Fact]
    public async Task Get_ReturnsWeatherForecasts()
    {
        // Arrange
        var mockLogger = new Mock<ILogger<ReservationController>>();
        var mockMediator = new Mock<IMediator>();
        mockMediator.Setup(m => m.Send(It.IsAny<GetAllReservationsRequest>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(HandlerResult<IEnumerable<ReservationDto>>.Ok(new List<ReservationDto>
            {
                new ReservationDto
                {
                    Id = 1, CustomerName = "John Doe", RoomName = "Room A", CheckIn = DateTime.Now,
                    CheckOut = DateTime.Now.AddDays(1), NumberOfGuests = 2, TotalPrice = 100
                }
            }));
        var controller = new ReservationController(mockLogger.Object, mockMediator.Object);

        // Act
        var result = await controller.GetReservations();

        // Assert
        Assert.NotNull(result);
        Assert.IsAssignableFrom<JsonResult>(result);
        var objResult = (JsonResult)result;

        var actionResult = Assert.IsAssignableFrom<ApiResponse<IEnumerable<ReservationItem>>>(objResult.Value);
        Assert.NotNull(actionResult.Payload);
        Assert.NotEmpty(actionResult.Payload);
    }

    [Fact]
    public async Task GetReservations_ReturnsEmptyList_WhenNoReservations()
    {
        // Arrange
        var mockLogger = new Mock<ILogger<ReservationController>>();
        var mockMediator = new Mock<IMediator>();
        mockMediator.Setup(m => m.Send(It.IsAny<GetAllReservationsRequest>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(HandlerResult<IEnumerable<ReservationDto>>.Ok([]));

        var controller = new ReservationController(mockLogger.Object, mockMediator.Object);

        // Act
        var result = await controller.GetReservations();

        // Assert
        Assert.NotNull(result);
        Assert.IsAssignableFrom<JsonResult>(result);
        var objResult = (JsonResult)result;

        var actionResult = Assert.IsAssignableFrom<ApiResponse<IEnumerable<ReservationItem>>>(objResult.Value);

        Assert.NotNull(actionResult.Payload);
        Assert.Empty(actionResult.Payload);
    }

    [Fact]
    public async Task GetReservations_ReturnsCorrectData()
    {
        // Arrange
        var mockLogger = new Mock<ILogger<ReservationController>>();
        var mockMediator = new Mock<IMediator>();
        mockMediator.Setup(m => m.Send(It.IsAny<GetAllReservationsRequest>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(HandlerResult<IEnumerable<ReservationDto>>.Ok(new List<ReservationDto>
            {
                new ReservationDto
                {
                    Id = 1, CustomerName = "John Doe", RoomName = "Room A", CheckIn = DateTime.Now,
                    CheckOut = DateTime.Now.AddDays(1), NumberOfGuests = 2, TotalPrice = 100
                }
            }));
        var controller = new ReservationController(mockLogger.Object, mockMediator.Object);

        // Act
        var result = await controller.GetReservations();

        // Assert
        Assert.NotNull(result);
        Assert.IsAssignableFrom<JsonResult>(result);
        var objResult = (JsonResult)result;

        var actionResult = Assert.IsAssignableFrom<ApiResponse<IEnumerable<ReservationItem>>>(objResult.Value);

        var reservation = Assert.Single(actionResult.Payload);
        Assert.Equal("John Doe", reservation.CustomerName);
        Assert.Equal("Room A", reservation.RoomName);
    }
}
