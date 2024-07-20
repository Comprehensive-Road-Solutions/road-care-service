using RoadCareService.Monitoring.Domain.Model.Commands.Staff;
using RoadCareService.Monitoring.Domain.Model.ValueObjects.Staff;
using RoadCareService.Monitoring.Interfaces.REST.Resources.Staff;

namespace RoadCareService.Monitoring.Interfaces.REST.Transform.Staff
{
    public class UpdateStaffStateCommandFromResourceAssembler
    {
        public static UpdateStaffStateCommand ToCommandFromResource
            (UpdateStaffStateResource resource) =>
            new(resource.Id, Enum.Parse<EStaffState>
                (resource.StaffState));
    }
}