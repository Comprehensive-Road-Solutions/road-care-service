using System.Data;
using RoadCareService.Publishing.Domain.Model.Aggregates;
using RoadCareService.Publishing.Domain.Model.Queries.Evidence;
using RoadCareService.Publishing.Domain.Repositories;
using RoadCareService.Publishing.Domain.Services.Evidence;
using RoadCareService.Publishing.Infrastructure.Persistence.Dapper.Repositories;
using RoadCareService.Shared.Infrastructure.Persistence.EFC.Configuration;

namespace RoadCareService.Publishing.Application.Internal.QueryServices
{
    public class EvidenceQueryService(RoadCareContext context,
        IDbConnection connection) : IEvidenceQueryService
    {
        private readonly IEvidenceRepository EvidenceRepository =
            new EvidenceRepositoryDapper(context, connection);

        public async Task<IEnumerable<Evidence>?> Handle
            (GetEvidencesByPublicationsIdQuery query) =>
            await EvidenceRepository
            .FindByPublicationsIdAsync(query.PublicationsId);
    }
}