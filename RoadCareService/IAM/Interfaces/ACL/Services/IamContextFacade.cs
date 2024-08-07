﻿using RoadCareService.IAM.Domain.Model.Queries.Citizen;
using RoadCareService.IAM.Domain.Model.Queries.Worker;
using RoadCareService.IAM.Domain.Services.Citizen;
using RoadCareService.IAM.Domain.Services.Worker;

namespace RoadCareService.IAM.Interfaces.ACL.Services
{
    internal class IamContextFacade
        (IWorkerQueryService workerQueryService,
        ICitizenQueryService citizenQueryService) :
        IIamContextFacade
    {
        public async Task<bool> ExistsWorkerById
            (int id) =>
            await workerQueryService.Handle
            (new GetWorkerByIdQuery(id)) != null;

        public async Task<bool> ExistsCitizenById
            (int id) =>
            await citizenQueryService.Handle
            (new GetCitizenByIdQuery(id)) != null;
    }
}