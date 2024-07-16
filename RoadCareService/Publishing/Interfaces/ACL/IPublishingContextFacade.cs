namespace RoadCareService.Publishing.Interfaces.ACL
{
    public interface IPublishingContextFacade
    {
        Task<bool> ExistsDistrictByDepartmentsId(int departmentsId);
        Task<bool> ExistsPublicationById(int id);
    }
}