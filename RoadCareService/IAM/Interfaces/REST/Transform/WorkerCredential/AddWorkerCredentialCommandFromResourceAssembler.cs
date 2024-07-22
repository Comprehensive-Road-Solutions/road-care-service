using RoadCareService.IAM.Domain.Model.Commands.WorkerCredential;
using RoadCareService.IAM.Interfaces.REST.Resources.WorkerCredentia;

namespace RoadCareService.IAM.Interfaces.REST.Transform.WorkerCredential
{
    public class AddWorkerCredentialCommandFromResourceAssembler
    {
        public static AddWorkerCredentialCommand ToCommandFromResource
            (AddWorkerCredentialResource resource) =>
            new(resource.WorkerId, resource.Code);
    }
}