using RoadCareService.Publishing.Domain.Model.Aggregates;
using RoadCareService.Publishing.Domain.Repositories;
using RoadCareService.Shared.Infrastructure.Persistence.EFC.Configuration;
using RoadCareService.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace RoadCareService.Publishing.Infrastructure.Persistence.EFC.Repositories
{
    public class PublicationRepositoryEFC(RoadCareContext context) :
        BaseRepository<Publication>(context), IPublicationRepository
    {
        public Task<IEnumerable<Publication>?> FindByDepartmentsIdAndDistrictsIdAsync
            (int departmentsId, int districtsId) => throw new NotSupportedException
            ("This search is done by dapper!");
    }
}