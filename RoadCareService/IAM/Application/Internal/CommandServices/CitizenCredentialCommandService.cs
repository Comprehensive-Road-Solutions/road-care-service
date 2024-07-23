using RoadCareService.IAM.Application.Internal.OutboundServices;
using RoadCareService.IAM.Domain.Model.Commands.CitizenCredential;
using RoadCareService.IAM.Domain.Repositories;
using RoadCareService.IAM.Domain.Services.CitizenCredential;
using RoadCareService.Shared.Domain.Repositories;

namespace RoadCareService.IAM.Application.Internal.CommandServices
{
    public class CitizenCredentialCommandService
        (ICitizenCredentialRepository citizenCredentialRepository,
        IUnitOfWork unitOfWork,
        IEncryptionService encryptionService) :
        ICitizenCredentialCommandService
    {
        public async Task<bool> Handle
            (AddCitizenCredentialCommand command)
        {
            try
            {
                var salt = encryptionService
                    .CreateSalt();

                var code = encryptionService
                    .HashCode(command.Code, salt);

                await citizenCredentialRepository
                    .AddAsync(new(command
                    .CitizenId, string.Concat
                    (salt, code)));

                await unitOfWork.CompleteAsync();

                return true;
            }
            catch (Exception) { return false; }
        }
    }
}