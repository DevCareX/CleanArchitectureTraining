using AutoMapper;
using Ticket.Application.Features.Categories.Queries.GetCategoriesList;
using Ticket.Application.Features.Categories.Queries.GetCategoriesListWithEvents;
using Ticket.Application.Features.Events.Commands.CreateEvent;
using Ticket.Application.Features.Events.Commands.UpdateEvent;
using Ticket.Application.Features.Events.Queries.GetEventList;
using Ticket.Domain.Entities;

namespace Ticket.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Event, EventListVw>().ReverseMap();
            CreateMap<Event, EventDetailVm>().ReverseMap();
            CreateMap<Category, CategoryDto>();
            CreateMap<Category, CategoryListVm>();
            CreateMap<Category, CategoryEventListVm>();
            CreateMap<Event, CreateEventCommand>().ReverseMap();
            CreateMap<Event, UpdateEventCommand>().ReverseMap();
        }
    }
}
