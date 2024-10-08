﻿using RoadCareService.IAM.Domain.Model.Aggregates;
using RoadCareService.Shared.Domain.Repositories;

namespace RoadCareService.IAM.Domain.Repositories
{
    public interface IWorkerRepository :
        IBaseRepository<Worker>
    { }
}