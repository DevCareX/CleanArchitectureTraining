using Ticket.Application.Features.Events.Queries.GetEventsExport;

namespace Ticket.Application.Contracts.Infrastructure
{
    public interface ICsvExporter
    {
        byte[] ExportEventsToCsv(List<EventExportDto> eventExportDtos);
    }
}
