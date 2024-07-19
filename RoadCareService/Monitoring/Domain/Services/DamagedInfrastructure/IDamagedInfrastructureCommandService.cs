using RoadCareService.Monitoring.Domain.Model.Commands.DamagedInfrastructure;

namespace RoadCareService.Monitoring.Domain.Services.DamagedInfrastructure
{
    public interface IDamagedInfrastructureCommandService
    {
        Task<bool> Handle
            (RegisterDamagedInfrastructureCommand command);
        Task<bool> Handle
            (UpdateDamagedInfrastructureStateCommand command);
        Task<bool> Handle
            (AssignWorkDateToDamagedInfrastructureCommand command);
    }
}