using RoadCareService.Publishing.Domain.Model.Queries.District;

namespace RoadCareService.Publishing.Domain.Services.District
{
    public interface IDistrictQueryService
    {
        Task<bool> Handle
            (GetDistrictByIdQuery query);

        Task<IEnumerable<Model.Entities.District>> Handle
            (GetDistrictsByDepartmentIdQuery query);
    }
}