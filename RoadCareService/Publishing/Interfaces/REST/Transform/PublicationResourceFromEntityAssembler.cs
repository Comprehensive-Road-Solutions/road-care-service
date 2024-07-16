using RoadCareService.Publishing.Domain.Model.Aggregates;
using RoadCareService.Publishing.Interfaces.REST.Resources;

namespace RoadCareService.Publishing.Interfaces.REST.Transform
{
    public class PublicationResourceFromEntityAssembler
    {
        public static PublicationResource ToResourceFromEntity
            (Publication entity) => new(entity.Id, entity.CitizensId,
                                        entity.DistrictsId, entity.Ubication,
                                        entity.Description);
    }
}