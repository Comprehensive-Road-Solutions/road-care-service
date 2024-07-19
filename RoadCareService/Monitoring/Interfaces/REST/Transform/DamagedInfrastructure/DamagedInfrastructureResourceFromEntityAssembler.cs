using RoadCareService.Monitoring.Interfaces.REST.Resources.DamagedInfrastructure;

namespace RoadCareService.Monitoring.Interfaces.REST.Transform.DamagedInfrastructure
{
    public class DamagedInfrastructureResourceFromEntityAssembler
    {
        public static DamagedInfrastructureResource ToResourceFromEntity
            (Domain.Model.Aggregates.DamagedInfrastructure entity) =>
            new(entity.Id, entity.DistrictsId, entity.RegistrationDate,
                entity.Description, entity.Address, entity.WorkDate,
                entity.State);
    }
}