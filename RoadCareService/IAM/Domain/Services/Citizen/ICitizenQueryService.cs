using RoadCareService.IAM.Domain.Model.Queries.CitizenCredential;

namespace RoadCareService.IAM.Domain.Services.Citizen
{
    public interface ICitizenQueryService
    {
        Task<bool> Handle
            (GetCitizenCredentialByIdAndCodeQuery query);
    }
}