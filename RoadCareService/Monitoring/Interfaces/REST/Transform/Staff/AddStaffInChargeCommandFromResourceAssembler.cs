using RoadCareService.Monitoring.Domain.Model.Commands.Staff;
using RoadCareService.Monitoring.Domain.Model.ValueObjects.Staff;
using RoadCareService.Monitoring.Interfaces.REST.Resources.Staff;

namespace RoadCareService.Monitoring.Interfaces.REST.Transform.Staff
{
    public class AddStaffInChargeCommandFromResourceAssembler
    {
        public static AddStaffInChargeCommand ToCommandFromResource
            (AddStaffInChargeResource resource) =>
            new(resource.DamagedInfrastructuresId, resource.WorkersId,
                EStaffState.ACTIVO);
    }
}