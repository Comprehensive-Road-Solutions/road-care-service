namespace RoadCareService.Interaction.Interfaces.REST.Resources
{
    public record AddCommentToPublicationResource(int PublicationsId,
                                                  int CitizensId,
                                                  string Opinion);
}