using RoadCareService.Monitoring.Domain.Model.ValueObjects;

namespace RoadCareService.Monitoring.Domain.Model.Queries
{
    public record GetDamagedInfrastructureByStateQuery
        (EDamagedInfrastructureState DamagedInfrastructureState);
}