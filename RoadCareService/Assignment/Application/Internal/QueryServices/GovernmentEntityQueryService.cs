using RoadCareService.Assignment.Domain.Model.Aggregates;
using RoadCareService.Assignment.Domain.Model.Queries.GovernmentEntity;
using RoadCareService.Assignment.Domain.Repositories;
using RoadCareService.Assignment.Domain.Services.GovernmentEntity;

namespace RoadCareService.Assignment.Application.Internal.QueryServices
{
    public class GovernmentEntityQueryService
        (IGovernmentEntityRepository governmentEntityRepository) :
        IGovernmentEntityQueryService
    {
        public async Task<IEnumerable<GovernmentEntity>> Handle
            (GetAllGovernmentsEntitiesQuery query) =>
            await governmentEntityRepository.ListAsync();

        public async Task<GovernmentEntity?> Handle
            (GetGovernmentEntityByIdQuery query) =>
            await governmentEntityRepository
            .FindByIdAsync(query.Id);
    }
}