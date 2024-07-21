﻿using RoadCareService.IAM.Domain.Model.Commands.Worker;
using RoadCareService.IAM.Domain.Repositories;
using RoadCareService.IAM.Domain.Services.Worker;
using RoadCareService.Shared.Domain.Repositories;

namespace RoadCareService.IAM.Application.Internal.CommandServices
{
    public class WorkerCommandService
        (IWorkerRepository workerRepository,
        IUnitOfWork unitOfWork) :
        IWorkerCommandService
    {
        public async Task<bool> Handle
            (RegisterWorkerCommand command)
        {
            try
            {
                await workerRepository
                    .AddAsync(new(command));

                await unitOfWork.CompleteAsync();

                return true;
            }
            catch (Exception) { return false; }
        }
    }
}