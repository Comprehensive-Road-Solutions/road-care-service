namespace RoadCareService.Interaction.Domain.Model.Commands
{
    public record AddCommentToPublicationCommand(int PublicationsId,
                                                 int CitizensId,
                                                 string Opinion);
}