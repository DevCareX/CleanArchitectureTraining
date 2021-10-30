using MediatR;

namespace Ticket.Application.Features.Events.Queries.GetEventList
{
    public class GetEventDetailQuery : IRequest<EventDetailVm>
    {
        public Guid Id { get; set; }
    }
}
