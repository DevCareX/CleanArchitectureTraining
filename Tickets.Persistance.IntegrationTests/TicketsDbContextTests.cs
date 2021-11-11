using Microsoft.EntityFrameworkCore;
using Moq;
using Shouldly;
using System;
using Ticket.Application.Contracts;
using Ticket.Domain.Entities;
using Ticket.Persistence;
using Xunit;

namespace Tickets.Persistance.IntegrationTests
{
    public class TicketDbContextTests
    {
        private readonly Ticket.Persistence.TicketDbContext _ticketDbContext;
        private readonly Mock<ILoggedInUserService> _loggedInUserServiceMock;
        private readonly string _loggedInUserId;

        public TicketDbContextTests()
        {
            var dbContextOptions = new DbContextOptionsBuilder<Ticket.Persistence.TicketDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

            _loggedInUserId = "00000000-0000-0000-0000-000000000000";
            _loggedInUserServiceMock = new Mock<ILoggedInUserService>();
            _loggedInUserServiceMock.Setup(m => m.UserId).Returns(_loggedInUserId);

            _ticketDbContext = new Ticket.Persistence.TicketDbContext(dbContextOptions, _loggedInUserServiceMock.Object);
        }

        [Fact]
        public async void Save_SetCreatedByProperty()
        {
            var ev = new Event() { EventId = Guid.NewGuid(), Name = "Test event", Artist = "xxx", CreatedBy = "00000000-0000-0000-0000-000000000000", Description = "test", ImageUrl = "test", LastModifiedBy = "test" };

            _ticketDbContext.Events.Add(ev);
            await _ticketDbContext.SaveChangesAsync();

            ev.CreatedBy.ShouldBe(_loggedInUserId);
        }
    }
}
