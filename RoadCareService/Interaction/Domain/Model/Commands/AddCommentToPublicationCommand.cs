using RoadCareService.Interaction.Domain.Model.ValueObjects;

namespace RoadCareService.Interaction.Domain.Model.Commands
{
    public record AddCommentToPublicationCommand(int PublicationId,
        int CitizenId, string Opinion, ECommentState CommentState);
}