using RoadCareService.IAM.Domain.Model.Queries.Citizen;
using RoadCareService.IAM.Domain.Repositories;
using RoadCareService.IAM.Domain.Services.Citizen;

namespace RoadCareService.IAM.Application.Internal.QueryServices
{
    public class CitizenQueryService
        (ICitizenRepository citizenRepository) :
        ICitizenQueryService
    {
        public async Task<bool> Handle
            (GetCitizenCredentialByIdAndCodeQuery query) =>
            await citizenRepository
            .FinByIdAndCodeAsync
            (query.Id, query.Code);
    }
}