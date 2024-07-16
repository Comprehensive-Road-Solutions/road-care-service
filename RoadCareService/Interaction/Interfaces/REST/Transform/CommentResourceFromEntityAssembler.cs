using RoadCareService.Interaction.Domain.Model.Aggregates;
using RoadCareService.Interaction.Interfaces.REST.Resources;

namespace RoadCareService.Interaction.Interfaces.REST.Transform
{
    public class CommentResourceFromEntityAssembler
    {
        public static CommentResource ToResourceFromEntity
            (Comment entity) => new(entity.Id,
                                    entity.PublicationsId,
                                    entity.CitizensId,
                                    entity.ShippingDate,
                                    entity.Opinion);
    }
}