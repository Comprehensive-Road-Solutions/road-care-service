using RoadCareService.Location.Domain.Model.Aggregates;
using RoadCareService.Location.Domain.Model.Queries.District;
using RoadCareService.Location.Domain.Repositories;
using RoadCareService.Location.Domain.Services.District;

namespace RoadCareService.Location.Application.Internal.QueryServices
{
    internal class DistrictQueryService
        (IDistrictRepository districtRepository) :
        IDistrictQueryService
    {
        public async Task<bool> Handle
            (GetDistrictByIdQuery query) =>
            await districtRepository
            .FindByIdAsync(query.Id)
            is not null;

        public async Task<IEnumerable<District>> Handle
            (GetDistrictsByDepartmentIdQuery query) =>
            await districtRepository.FindByDepartmentIdAsync
            (query.DepartmentId);
    }
}