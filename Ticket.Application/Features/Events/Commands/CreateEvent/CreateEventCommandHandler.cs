using AutoMapper;
using MediatR;
using Ticket.Application.Contracts.Infrastructure;
using Ticket.Application.Contracts.Persistence;
using Ticket.Application.Models.Mail;
using Ticket.Domain.Entities;

namespace Ticket.Application.Features.Events.Commands.CreateEvent
{
    public class CreateEventCommandHandler : IRequestHandler<CreateEventCommand, Guid>
    {
        private readonly IMapper _mapper;
        private readonly IEventRepository _eventRepository;
        private readonly IEmailService _emailService;

        public CreateEventCommandHandler(IMapper mapper, IEventRepository eventRepository, IEmailService emailService)
        {
            _mapper = mapper;
            _eventRepository = eventRepository;
            _emailService = emailService;
        }

        public async Task<Guid> Handle(CreateEventCommand request, CancellationToken cancellationToken)
        {
            var validaor = new CreateEventCommandValidator(_eventRepository);
            var validationResult = await validaor.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new Exceptions.ValidationException(validationResult);

            var @event = _mapper.Map<Event>(request);
            @event = await _eventRepository.AddAsync(@event);

            var email = new Email
            {
                To = "receiver@mail.com",
                Body = $"New event was created: {request}",
                Subject = "New event"
            };

            try
            {
                await _emailService.SendEmail(email);
            }
            catch (Exception ex)
            {
                // this shouldn't stop teh API from doing else so this can be logged                
            }

            return @event.EventId;
        }
    }
}
