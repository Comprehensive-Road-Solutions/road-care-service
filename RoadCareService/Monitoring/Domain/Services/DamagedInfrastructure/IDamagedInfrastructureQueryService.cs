using RoadCareService.Monitoring.Domain.Model.Queries.DamagedInfrastructure;

namespace RoadCareService.Monitoring.Domain.Services.DamagedInfrastructure
{
    public interface IDamagedInfrastructureQueryService
    {
        Task<IEnumerable<Model.Aggregates.DamagedInfrastructure>> Handle
            (GetAllDamagedInfrastructuresQuery query);

        Task<Model.Aggregates.DamagedInfrastructure?> Handle
            (GetDamagedInfrastructureByIdQuery query);

        Task<IEnumerable<Model.Aggregates.DamagedInfrastructure>> Handle
            (GetDamagedInfrastructuresByStateQuery query);

        Task<IEnumerable<Model.Aggregates.DamagedInfrastructure>> Handle
            (GetDamagedInfrastructuresByDepartmentsIdAndDistrictsIdQuery query);
    }
}