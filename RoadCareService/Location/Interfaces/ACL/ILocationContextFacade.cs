namespace RoadCareService.Location.Interfaces.ACL
{
    public interface ILocationContextFacade
    {
        Task<bool> ExistsDistrictById
            (int id);
    }
}