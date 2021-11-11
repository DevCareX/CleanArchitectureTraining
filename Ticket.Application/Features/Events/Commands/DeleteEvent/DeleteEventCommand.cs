using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticket.Application.Features.Events.Commands.DeleteEvent
{
    public class DeleteEventCommand
    {
        public Guid EventId { get; set; }
    }
}
