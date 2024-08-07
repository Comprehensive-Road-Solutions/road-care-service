using RoadCareService.Interaction.Domain.Model.ValueObjects.Comment;

namespace RoadCareService.Interaction.Domain.Model.Commands.Comment
{
    public record AddCommentToPublicationCommand
        (int PublicationId, int CitizenId,
        string Opinion, ECommentState CommentState);
}