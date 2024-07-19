using RoadCareService.Monitoring.Domain.Model.Commands.DamagedInfrastructure;
using RoadCareService.Monitoring.Interfaces.REST.Resources.DamagedInfrastructure;

namespace RoadCareService.Monitoring.Interfaces.REST.Transform.DamagedInfrastructure
{
    public class AssignWorkDateToDamagedInfrastructureCommandFromResourceAssembler
    {
        public static AssignWorkDateToDamagedInfrastructureCommand ToCommandFromResource
            (AssignWorkDateToDamagedInfrastructureResource resource) =>
            new(resource.Id, resource.WorkDate);
    }
}