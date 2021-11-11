using AutoMapper;
using Ticket.Application.Features.Categories.Commands.CreateCateogry;
using Ticket.Application.Features.Categories.Queries.GetCategoriesList;
using Ticket.Application.Features.Categories.Queries.GetCategoriesListWithEvents;
using Ticket.Application.Features.Events.Commands.CreateEvent;
using Ticket.Application.Features.Events.Commands.UpdateEvent;
using Ticket.Application.Features.Events.Queries.GetEventList;
using Ticket.Application.Features.Events.Queries.GetEventsExport;
using Ticket.Application.Features.Orders.GetOrdersForMonth;
using Ticket.Domain.Entities;

namespace Ticket.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Event, EventListVm>().ReverseMap();
            CreateMap<Event, CreateEventCommand>().ReverseMap();
            CreateMap<Event, UpdateEventCommand>().ReverseMap();
            CreateMap<Event, EventDetailVm>().ReverseMap();
            CreateMap<Event, CategoryEventDto>().ReverseMap();
            CreateMap<Event, EventExportDto>().ReverseMap();

            CreateMap<Category, CategoryDto>();
            CreateMap<Category, CategoryListVm>();
            CreateMap<Category, CategoryEventListVm>();
            CreateMap<Category, CreateCategoryCommand>();
            CreateMap<Category, CreateCategoryDto>();

            CreateMap<Order, OrdersForMonthDto>();
        }
    }
}
