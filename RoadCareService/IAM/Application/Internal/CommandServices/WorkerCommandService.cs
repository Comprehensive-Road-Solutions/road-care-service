using RoadCareService.IAM.Application.Internal.OutboundServices;
using RoadCareService.IAM.Application.Internal.OutboundServices.ACL;
using RoadCareService.IAM.Domain.Model.Commands.Worker;
using RoadCareService.IAM.Domain.Repositories;
using RoadCareService.IAM.Domain.Services.Worker;
using RoadCareService.Shared.Domain.Repositories;

namespace RoadCareService.IAM.Application.Internal.CommandServices
{
    public class WorkerCommandService
        (IWorkerRepository workerRepository,
        IUnitOfWork unitOfWork,
        ExternalLocationService externalLocationService,
        IReniecService reniecService) :
        IWorkerCommandService
    {
        public async Task<bool> Handle
            (RegisterWorkerCommand command)
        {
            try
            {
                if (await externalLocationService
                    .ExistsDistrictById
                    (command.DistrictId)
                    is false || await reniecService
                    .ValidateDni(command.Id)
                    is false)
                    return false;

                await workerRepository
                    .AddAsync(new(command));

                await unitOfWork.CompleteAsync();

                return true;
            }
            catch (Exception) { return false; }
        }
    }
}