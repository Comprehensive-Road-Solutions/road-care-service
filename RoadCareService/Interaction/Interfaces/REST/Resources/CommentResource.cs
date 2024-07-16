namespace RoadCareService.Interaction.Interfaces.REST.Resources
{
    public record CommentResource(int Id,
                                  int PublicationsId,
                                  int CitizensId,
                                  DateTime shippingDate,
                                  string Opinion);
}