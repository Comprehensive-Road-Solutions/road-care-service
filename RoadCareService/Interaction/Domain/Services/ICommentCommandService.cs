using RoadCareService.Interaction.Domain.Model.Commands;

namespace RoadCareService.Interaction.Domain.Services
{
    public interface ICommentCommandService
    {
        Task<bool> Handle
            (AddCommentToPublicationCommand command);
    }
}