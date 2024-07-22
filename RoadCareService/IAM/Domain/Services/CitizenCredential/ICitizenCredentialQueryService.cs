using RoadCareService.IAM.Domain.Model.Queries.CitizenCredential;

namespace RoadCareService.IAM.Domain.Services.CitizenCredential
{
    public interface ICitizenCredentialQueryService
    {
        Task<string?> Handle
            (GetCitizenCredentialByCitizenIdAndCodeQuery query);
    }
}