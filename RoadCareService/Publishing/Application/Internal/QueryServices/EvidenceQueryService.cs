using RoadCareService.Publishing.Domain.Model.Aggregates;
using RoadCareService.Publishing.Domain.Model.Queries.Evidence;
using RoadCareService.Publishing.Domain.Repositories;
using RoadCareService.Publishing.Domain.Services.Evidence;

namespace RoadCareService.Publishing.Application.Internal.QueryServices
{
    internal class EvidenceQueryService
        (IEvidenceRepository evidenceRepository) :
        IEvidenceQueryService
    {
        public async Task<IEnumerable<Evidence>> Handle
            (GetEvidencesByPublicationIdQuery query) =>
            await evidenceRepository
            .FindByPublicationIdAsync
            (query.PublicationId);
    }
}