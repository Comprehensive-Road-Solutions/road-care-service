using RoadCareService.Publishing.Domain.Model.Aggregates;
using RoadCareService.Publishing.Interfaces.REST.Resources;

namespace RoadCareService.Publishing.Interfaces.REST.Transform
{
    public class EvidenceResourceFromEntityAssembler
    {
        public static EvidenceResource ToResourceFromEntity
            (Evidence entity) => new(entity.Id,
                                     entity.PublicationsId,
                                     entity.FileUrl);
    }
}