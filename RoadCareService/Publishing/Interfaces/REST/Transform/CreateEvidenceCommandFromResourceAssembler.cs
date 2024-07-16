using RoadCareService.Publishing.Domain.Model.Commands.Evidence;
using RoadCareService.Publishing.Interfaces.REST.Resources;

namespace RoadCareService.Publishing.Interfaces.REST.Transform
{
    public class CreateEvidenceCommandFromResourceAssembler
    {
        public static CreateEvidenceCommand ToCommandFromResource
            (CreateEvidenceResource resource) =>
            new(resource.PublicationsId, resource.FileUrl);
    }
}