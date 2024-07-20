namespace RoadCareService.Interaction.Interfaces.REST.Resources
{
    public record AddCommentToPublicationResource(int PublicationId,
                                                  int CitizenId,
                                                  string Opinion);
}