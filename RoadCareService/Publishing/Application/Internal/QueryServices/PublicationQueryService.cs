using System.Data;
using RoadCareService.Publishing.Domain.Model.Aggregates;
using RoadCareService.Publishing.Domain.Model.Queries.Publication;
using RoadCareService.Publishing.Domain.Repositories;
using RoadCareService.Publishing.Domain.Services.Publication;
using RoadCareService.Publishing.Infrastructure.Persistence.Dapper.Repositories;
using RoadCareService.Publishing.Infrastructure.Persistence.EFC.Repositories;
using RoadCareService.Shared.Infrastructure.Persistence.EFC.Configuration;

namespace RoadCareService.Publishing.Application.Internal.QueryServices
{
    public class PublicationQueryService(RoadCareContext context,
        IDbConnection connection) : IPublicationQueryService
    {
        private IPublicationRepository? PublicationRepository;

        public async Task<IEnumerable<Publication>?> Handle
            (GetAllPublicationsQuery query)
        {
            PublicationRepository =
                new PublicationRepositoryEFC(context);

            return await PublicationRepository.ListAsync();
        }
        public async Task<IEnumerable<Publication>?> Handle
            (GetPublicationsByDepartmentsIdAndDistrictsIdQuery query)
        {
            PublicationRepository =
                new PublicationRepositoryDapper(context, connection);

            return await PublicationRepository
                .FindByDepartmentsIdAndDistrictsIdAsync
                (query.DepartmentsId, query.DistrictsId);
        }
    }
}