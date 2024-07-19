using RoadCareService.Monitoring.Domain.Model.Commands.DamagedInfrastructure;
using RoadCareService.Monitoring.Domain.Model.ValueObjects.DamagedInfrastructure;
using RoadCareService.Monitoring.Interfaces.REST.Resources.DamagedInfrastructure;

namespace RoadCareService.Monitoring.Interfaces.REST.Transform.DamagedInfrastructure
{
    public class RegisterDamagedInfrastructureCommandFromResourceAssembler
    {
        public static RegisterDamagedInfrastructureCommand ToCommandFromResource
            (RegisterDamagedInfrastructureResource resource) =>
            new(resource.DistrictsId, resource.Description, resource.Address,
                EDamagedInfrastructureState.ENPROCESO);
    }
}