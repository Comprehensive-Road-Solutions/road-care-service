namespace RoadCareService.Publishing.Interfaces.ACL
{
    public interface IPublishingContextFacade
    {
        Task<bool> ExistsPublicationById
            (int id);
    }
}