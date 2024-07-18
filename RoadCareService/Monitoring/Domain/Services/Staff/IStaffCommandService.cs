using RoadCareService.Monitoring.Domain.Model.Commands.Staff;

namespace RoadCareService.Monitoring.Domain.Services.Staff
{
    public interface IStaffCommandService
    {
        Task<bool> Handle(AddStaffInChargeCommand command);
        Task<bool> Handle(UpdateStaffStateCommand command);
    }
}