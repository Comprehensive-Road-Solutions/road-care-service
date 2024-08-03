using RoadCareService.IAM.Interfaces.ACL;

namespace RoadCareService.Publishing.Application.Internal.OutboundServices.ACL
{
    internal class ExternalIamService
        (IIamContextFacade iamContextFacade)
    {
        public async Task<bool> ExistsCitizenById
            (int id) => await iamContextFacade
            .ExistsCitizenById(id);
    }
}