using RoadCareService.IAM.Domain.Model.ValueObjects.Worker;

namespace RoadCareService.IAM.Domain.Model.Commands.Worker
{
    public record RegisterWorkerCommand
        (int Id, int DistrictId, int GovernmentEntityId,
        string Firstname, string Lastname, int Age,
        string Genre, int Phone, string Email, string Code,
        string Address, EWorkerState WorkerState);
}