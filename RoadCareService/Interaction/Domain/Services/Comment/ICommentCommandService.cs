using RoadCareService.Interaction.Domain.Model.Commands.Comment;

namespace RoadCareService.Interaction.Domain.Services.Comment
{
    public interface ICommentCommandService
    {
        Task<bool> Handle
            (AddCommentToPublicationCommand command);
    }
}