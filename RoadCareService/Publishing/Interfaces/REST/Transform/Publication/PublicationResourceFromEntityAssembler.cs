using RoadCareService.Publishing.Interfaces.REST.Resources.Publication;

namespace RoadCareService.Publishing.Interfaces.REST.Transform.Publication
{
    public class PublicationResourceFromEntityAssembler
    {
        public static PublicationResource ToResourceFromEntity
            (Domain.Model.Aggregates.Publication entity) =>
            new(entity.Id, entity.CitizensId, entity.DistrictsId,
                entity.Ubication, entity.Description);
    }
}