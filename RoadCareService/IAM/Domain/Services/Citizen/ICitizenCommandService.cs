using RoadCareService.IAM.Domain.Model.Commands.Citizen;

namespace RoadCareService.IAM.Domain.Services.Citizen
{
    public interface ICitizenCommandService
    {
        Task<bool> Handle
            (RegisterCitizenCommand command);
    }
}