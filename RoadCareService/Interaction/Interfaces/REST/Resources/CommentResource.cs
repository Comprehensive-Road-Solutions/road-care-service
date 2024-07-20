namespace RoadCareService.Interaction.Interfaces.REST.Resources
{
    public record CommentResource(int Id, int PublicationId, int CitizenId,
        DateTime ShippingDate, string Opinion);
}