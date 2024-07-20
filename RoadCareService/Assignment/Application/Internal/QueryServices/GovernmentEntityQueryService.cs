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
        public Task<IEnumerable<GovernmentEntity>?> Handle
            (GetAllGovernmentsEntitiesQuery query)
        {
            throw new NotImplementedException();
        }

        public Task<GovernmentEntity?> Handle
            (GetGovernmentEntityByIdQuery query)
        {
            throw new NotImplementedException();
        }
    }
}