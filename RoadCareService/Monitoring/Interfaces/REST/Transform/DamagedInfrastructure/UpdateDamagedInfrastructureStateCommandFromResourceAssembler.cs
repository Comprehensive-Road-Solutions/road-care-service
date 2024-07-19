using RoadCareService.Monitoring.Domain.Model.Commands.DamagedInfrastructure;
using RoadCareService.Monitoring.Domain.Model.ValueObjects.DamagedInfrastructure;
using RoadCareService.Monitoring.Interfaces.REST.Resources.DamagedInfrastructure;

namespace RoadCareService.Monitoring.Interfaces.REST.Transform.DamagedInfrastructure
{
    public class UpdateDamagedInfrastructureStateCommandFromResourceAssembler
    {
        public static UpdateDamagedInfrastructureStateCommand ToCommandFromResource
            (UpdateDamagedInfrastructureStateResource resource) =>
            new(resource.Id, Enum.Parse<EDamagedInfrastructureState>
                (resource.DamagedInfrastructureState));
    }
}