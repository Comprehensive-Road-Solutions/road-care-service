﻿using RoadCareService.IAM.Interfaces.ACL;

namespace RoadCareService.Assignment.Application.Internal.OutboundServices.ACL
{
    public class ExternalIamService
        (IIamContextFacade iamContextFacade)
    {
        public async Task<bool> ExistsWorkerById
            (int id) => await iamContextFacade
            .ExistsWorkerById(id);
    }
}