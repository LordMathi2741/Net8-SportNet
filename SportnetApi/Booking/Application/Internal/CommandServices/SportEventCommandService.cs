using SportnetApi.Booking.Domain.Model.Aggregates;
using SportnetApi.Booking.Domain.Model.Commands;
using SportnetApi.Booking.Domain.Repositories;
using SportnetApi.Booking.Domain.Services;
using SportnetApi.Shared.Domain.Model.Exceptions;
using SportnetApi.Shared.Domain.Repositories;

namespace SportnetApi.Booking.Application.Internal.CommandServices;

public class SportEventCommandService(IUnitOfWork unitOfWork, ISportEventRepository sportEventRepository) : ISportEventCommandService
{
    public async Task<SportEvent?> Handle(CreateSportEventCommand command)
    {
        var sportEvent = new SportEvent(command);
        await sportEventRepository.AddAsync(sportEvent);
        await unitOfWork.CompleteAsync();
        return sportEvent;
    }
}