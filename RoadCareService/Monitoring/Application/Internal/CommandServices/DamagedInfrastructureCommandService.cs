using RoadCareService.Monitoring.Application.Internal.OutboundServices.ACL;
using RoadCareService.Monitoring.Domain.Model.Commands.DamagedInfrastructure;
using RoadCareService.Monitoring.Domain.Repositories;
using RoadCareService.Monitoring.Domain.Services.DamagedInfrastructure;
using RoadCareService.Shared.Domain.Repositories;

namespace RoadCareService.Monitoring.Application.Internal.CommandServices
{
    public class DamagedInfrastructureCommandService
        (IDamagedInfrastructureRepository damagedInfrastructureRepository,
        IUnitOfWork unitOfWork,
        ExternalPublishingService externalPublishingService) :
        IDamagedInfrastructureCommandService
    {
        public async Task<bool> Handle
            (RegisterDamagedInfrastructureCommand command)
        {
            try
            {
                if (await externalPublishingService
                    .ExistsDistrictById
                    (command.DistrictId) is false)
                    return false;

                await damagedInfrastructureRepository
                    .AddAsync(new(command));

                await unitOfWork.CompleteAsync();

                return true;
            }
            catch (Exception) { return false; }
        }

        public async Task<bool> Handle
            (UpdateDamagedInfrastructureStateCommand command)
        {
            try
            {
                var result = await damagedInfrastructureRepository
                    .FindByIdAsync(command.Id);

                if (result is null)
                    return false;

                await damagedInfrastructureRepository
                     .UpdateDamagedInfrastructureStateAsync
                     (command.Id, command.DamagedInfrastructureState);

                return true;
            }
            catch (Exception) { return false; }
        }

        public async Task<bool> Handle
            (AssignWorkDateToDamagedInfrastructureCommand command)
        {
            try
            {
                var result = await damagedInfrastructureRepository
                    .FindByIdAsync(command.Id);

                if (result is null)
                    return false;

                await damagedInfrastructureRepository
                     .AssignWorkDateToDamagedInfrastructureAsync
                     (command.Id, command.WorkDate);

                return true;
            }
            catch (Exception) { return false; }
        }
    }
}