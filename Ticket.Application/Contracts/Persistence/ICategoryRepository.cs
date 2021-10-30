﻿using Ticket.Domain.Entities;

namespace Ticket.Application.Contracts.Persistence
{
    public interface ICategoryRepository : IAsyncRepository<Category>
    {
         Task<List<Category>> GetCategoriesWithEvents(bool includePassedEvents);
    }
}