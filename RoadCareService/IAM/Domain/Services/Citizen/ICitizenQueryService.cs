using RoadCareService.IAM.Domain.Model.Queries.Citizen;

namespace RoadCareService.IAM.Domain.Services.Citizen
{
    public interface ICitizenQueryService
    {
        Task<bool> Handle
            (GetCitizenByIdQuery query);
    }
}