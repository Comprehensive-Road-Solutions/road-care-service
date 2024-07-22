using RoadCareService.IAM.Domain.Model.Commands.Worker;
using RoadCareService.IAM.Domain.Model.ValueObjects.Worker;
using RoadCareService.IAM.Interfaces.REST.Resources.Worker;

namespace RoadCareService.IAM.Interfaces.REST.Transform.Worker
{
    public class RegisterWorkerCommandFromResourceAssembler
    {
        public static RegisterWorkerCommand ToCommandFromResource
            (RegisterWorkerResource resource) =>
            new(resource.Id, resource.DistrictId,
                resource.GovernmentEntityId,
                resource.Firstname, resource.Lastname,
                resource.Age, resource.Genre,
                resource.Phone, resource.Email,
                resource.Address, EWorkerState.ACTIVO);
    }
}