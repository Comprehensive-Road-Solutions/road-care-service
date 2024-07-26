namespace RoadCareService.IAM.Application.Internal.OutboundServices
{
    public interface IReniecService
    {
        Task<bool> ValidateDni(int dni);
    }
}