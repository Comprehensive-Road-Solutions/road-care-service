using RoadCareService.Interaction.Domain.Model.ValueObjects;

namespace RoadCareService.Interaction.Domain.Model.Commands
{
    public record AddCommentToPublicationCommand(int PublicationsId,
                                                 int CitizensId,
                                                 string Opinion,
                                                 ECommentState CommentState);
}