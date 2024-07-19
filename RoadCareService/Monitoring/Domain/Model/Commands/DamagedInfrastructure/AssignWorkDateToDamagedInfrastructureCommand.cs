namespace RoadCareService.Monitoring.Domain.Model.Commands.DamagedInfrastructure
{
    public record AssignWorkDateToDamagedInfrastructureCommand(int Id, DateTime WorkDate);
}