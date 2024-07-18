using RoadCareService.Monitoring.Domain.Model.ValueObjects;

namespace RoadCareService.Monitoring.Domain.Model.Commands
{
    public record RegisterDamagedInfrastructureCommand(string Description, string Address,
        EDamagedInfrastructureState DamagedInfrastructureState);
}