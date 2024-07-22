using RoadCareService.IAM.Interfaces.REST.Resources.WorkerCredentia;

namespace RoadCareService.IAM.Interfaces.REST.Transform.WorkerCredential
{
    public class WorkerCredentialResourceFromEntityAssembler
    {
        public static WorkerCredentialResource ToResourceFromEntity
            (Domain.Model.Entities.WorkerCredential entity) =>
            new(entity.WorkersId, entity.Code);
    }
}