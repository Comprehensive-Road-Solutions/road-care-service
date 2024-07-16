using RoadCareService.Publishing.Interfaces.REST.Resources.Evidence;

namespace RoadCareService.Publishing.Interfaces.REST.Transform.Evidence
{
    public class EvidenceResourceFromEntityAssembler
    {
        public static EvidenceResource ToResourceFromEntity
            (Domain.Model.Aggregates.Evidence entity) =>
            new(entity.Id, entity.PublicationsId, entity.FileUrl);
    }
}