using RoadCareService.Publishing.Domain.Model.Entities;

namespace RoadCareService.Publishing.Interfaces.ACL
{
    public interface IPublishingContextFacade
    {
        Task<IEnumerable<District>?> ExistsDistrictByDepartmentsId(int departmentsId);
        Task<bool> ExistsPublicationById(int id);
    }
}