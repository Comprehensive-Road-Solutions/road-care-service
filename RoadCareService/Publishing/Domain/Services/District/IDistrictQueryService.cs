using RoadCareService.Publishing.Domain.Model.Queries.District;

namespace RoadCareService.Publishing.Domain.Services.District
{
    public interface IDistrictQueryService
    {
        Task<IEnumerable<Model.Entities.District>> Handle
            (GetDistrictsByDepartmentsIdQuery query);
    }
}