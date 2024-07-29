using RoadCareService.Location.Domain.Model.Queries.District;

namespace RoadCareService.Location.Domain.Services.District
{
    public interface IDistrictQueryService
    {
        Task<bool> Handle
            (GetDistrictByIdQuery query);

        Task<IEnumerable<Model.Aggregates.District>> Handle
            (GetDistrictsByDepartmentIdQuery query);
    }
}