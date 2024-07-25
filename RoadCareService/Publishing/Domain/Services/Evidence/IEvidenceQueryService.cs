using RoadCareService.Publishing.Domain.Model.Queries.Evidence;

namespace RoadCareService.Publishing.Domain.Services.Evidence
{
    public interface IEvidenceQueryService
    {
        Task<IEnumerable<Model.Aggregates.Evidence>> Handle
            (GetEvidencesByPublicationIdQuery query);
    }
}