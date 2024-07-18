using RoadCareService.Monitoring.Domain.Model.ValueObjects.DamagedInfrastructure;

namespace RoadCareService.Monitoring.Domain.Model.Commands.DamagedInfrastructure
{
    public record RegisterDamagedInfrastructureCommand(int DistrictsId,
                                                       string Description,
                                                       string Address,
        EDamagedInfrastructureState DamagedInfrastructureState);
}