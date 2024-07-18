using RoadCareService.Monitoring.Domain.Model.ValueObjects.DamagedInfrastructure;

namespace RoadCareService.Monitoring.Domain.Model.Queries.DamagedInfrastructure
{
    public record GetDamagedInfrastructuresByStateQuery
        (EDamagedInfrastructureState DamagedInfrastructureState);
}