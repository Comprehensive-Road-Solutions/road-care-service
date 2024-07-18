using RoadCareService.Monitoring.Domain.Model.Commands.Staff;
using RoadCareService.Monitoring.Domain.Repositories;
using RoadCareService.Monitoring.Domain.Services.Staff;
using RoadCareService.Shared.Domain.Repositories;

namespace RoadCareService.Monitoring.Application.Internal.CommandServices
{
    public class StaffCommandService(IStaffRepository staffRepository,
        IUnitOfWork unitOfWork) : IStaffCommandService
    {
        public async Task<bool> Handle(AddStaffInChargeCommand command)
        {
            try
            {
                await staffRepository.AddAsync(new(command));

                await unitOfWork.CompleteAsync();

                return true;
            }
            catch (Exception) { return false; }
        }
        public async Task<bool> Handle(UpdateStaffStateCommand command)
        {
            try
            {
                var result = await staffRepository.FindByIdAsync(command.Id);

                staffRepository.Update(new(command));

                await unitOfWork.CompleteAsync();

                return true;
            }
            catch (Exception) { return false; }
        }
    }
}