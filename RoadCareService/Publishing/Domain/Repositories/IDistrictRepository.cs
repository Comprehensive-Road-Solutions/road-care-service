using RoadCareService.Publishing.Domain.Model.Entities;

namespace RoadCareService.Publishing.Domain.Repositories
{
    public interface IDistrictRepository
    {
        Task<IEnumerable<District>?> FindByDepartmentsIdAsync
            (int departmentsId);
    }
}