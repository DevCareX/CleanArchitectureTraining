using MediatR;

namespace Ticket.Application.Features.Events.Queries.GetEventList
{
    public class GetEventListQuery : IRequest<List<EventListVm>>
    {
    }
}
