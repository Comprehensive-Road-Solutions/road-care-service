using RoadCareService.Monitoring.Domain.Model.ValueObjects.DamagedInfrastructure;

namespace RoadCareService.Monitoring.Domain.Model.Commands.DamagedInfrastructure
{
    public record UpdateDamagedInfrastructureStateCommand(int Id,
        EDamagedInfrastructureState DamagedInfrastructureState);
}