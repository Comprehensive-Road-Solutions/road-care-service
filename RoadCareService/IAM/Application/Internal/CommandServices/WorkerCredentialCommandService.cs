using RoadCareService.IAM.Application.Internal.OutboundServices;
using RoadCareService.IAM.Domain.Model.Commands.WorkerCredential;
using RoadCareService.IAM.Domain.Repositories;
using RoadCareService.IAM.Domain.Services.WorkerCredential;
using RoadCareService.Shared.Domain.Repositories;

namespace RoadCareService.IAM.Application.Internal.CommandServices
{
    internal class WorkerCredentialCommandService
        (IWorkerCredentialRepository workerCredentialRepository,
        IUnitOfWork unitOfWork,
        IEncryptionService encryptionService) :
        IWorkerCredentialCommandService
    {
        public async Task<bool> Handle
            (AddWorkerCredentialCommand command)
        {
            try
            {
                var salt = encryptionService
                    .CreateSalt();

                var code = encryptionService
                    .HashCode(command.Code, salt);

                await workerCredentialRepository
                    .AddAsync(new(command
                    .WorkerId, string.Concat
                    (salt, code)));

                await unitOfWork.CompleteAsync();

                return true;
            }
            catch (Exception) { return false; }
        }
    }
}