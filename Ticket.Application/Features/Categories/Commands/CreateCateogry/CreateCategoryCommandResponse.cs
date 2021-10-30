using Ticket.Application.Responses;

namespace  Ticket.Application.Features.Categories.Commands.CreateCateogry
{
    public class CreateCategoryCommandResponse: BaseResponse
    {
        public CreateCategoryCommandResponse(): base()
        {

        }

        public CreateCategoryDto Category { get; set; }

        public List<string> ValidationErrors { get; set; }
    }
}