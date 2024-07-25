using RoadCareService.Assignment.Domain.Model.Queries.GovernmentEntity;

namespace RoadCareService.Assignment.Domain.Services.GovernmentEntity
{
    public interface IGovernmentEntityQueryService
    {
        Task<IEnumerable<Model.Aggregates.GovernmentEntity>> Handle
            (GetAllGovernmentsEntitiesQuery query);
        Task<Model.Aggregates.GovernmentEntity?> Handle
            (GetGovernmentEntityByIdQuery query);
    }
}