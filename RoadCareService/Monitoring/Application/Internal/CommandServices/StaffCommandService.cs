using RoadCareService.Monitoring.Application.Internal.OutboundServices.ACL;
using RoadCareService.Monitoring.Domain.Model.Commands.Staff;
using RoadCareService.Monitoring.Domain.Repositories;
using RoadCareService.Monitoring.Domain.Services.Staff;
using RoadCareService.Shared.Domain.Repositories;

namespace RoadCareService.Monitoring.Application.Internal.CommandServices
{
    internal class StaffCommandService
        (IStaffRepository staffRepository,
        IUnitOfWork unitOfWork,
        ExternalIamService externalIamService) :
        IStaffCommandService
    {
        public async Task<bool> Handle
            (AddStaffInChargeCommand command)
        {
            try
            {
                if (await externalIamService
                    .ExistsWorkerById
                    (command.WorkerId) is false)
                    return false;

                await staffRepository
                    .AddAsync(new(command));

                await unitOfWork.CompleteAsync();

                return true;
            }
            catch (Exception) { return false; }
        }

        public async Task<bool> Handle
            (UpdateStaffStateCommand command)
        {
            try
            {
                var result = await staffRepository.FindByIdAsync(command.Id);

                if (result is null)
                    return false;

                await staffRepository.UpdateStaffStateAsync
                    (command.Id, command.StaffState);

                return true;
            }
            catch (Exception) { return false; }
        }
    }
}