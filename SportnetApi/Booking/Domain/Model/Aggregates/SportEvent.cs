using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using SportnetApi.Booking.Domain.Model.Commands;
using SportnetApi.Booking.Domain.Model.ValueObjects;

namespace SportnetApi.Booking.Domain.Model.Aggregates;

public partial class SportEvent
{
    public long Id { get; set; }
    [NotNull]
    public string EventName { get; set; }
    [NotNull]
    public string SportType { get; set; }
    [NotNull]
    public long OrganizerId => OrganizerIdValue.OrganizerIdValue;
    [NotNull]
    public string Location { get; set; }
    [NotNull]
    public int Capacity { get; set; }
    
}

public partial class SportEvent
{
    public OrganizerId OrganizerIdValue { get; private set; }
}

public partial class SportEvent
{
    public SportEvent()
    {
        OrganizerIdValue = new OrganizerId();
    }
    
    public SportEvent(string eventName, string sportType, long organizerId, string location, int capacity)
    {
        EventName = eventName;
        SportType = sportType;
        OrganizerIdValue = new OrganizerId(organizerId);
        Location = location;
        Capacity = capacity;
    }
    
    public SportEvent(CreateSportEventCommand command)
    {
        EventName = command.EventName;
        SportType = command.SportType;
        OrganizerIdValue = new OrganizerId(command.OrganizerId);
        Location = command.Location;
        Capacity = command.Capacity;
    }

}