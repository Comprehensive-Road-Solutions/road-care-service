namespace RoadCareService.IAM.Interfaces.ACL
{
    public interface IIamContextFacade
    {
        Task<bool> ExistsWorkerById
            (int id);

        Task<bool> ExistsCitizenById
            (int id);
    }
}