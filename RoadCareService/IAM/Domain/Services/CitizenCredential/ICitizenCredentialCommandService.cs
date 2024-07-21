using RoadCareService.IAM.Domain.Model.Commands.CitizenCredential;

namespace RoadCareService.IAM.Domain.Services.CitizenCredential
{
    public interface ICitizenCredentialCommandService
    {
        Task<bool> Handle
            (AddCitizenCredentialCommand command);
    }
}