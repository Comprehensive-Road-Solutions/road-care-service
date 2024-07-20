﻿using RoadCareService.Assignment.Domain.Model.Commands.WorkerRole;
using RoadCareService.Assignment.Domain.Repositories;
using RoadCareService.Assignment.Domain.Services.WorkerRole;
using RoadCareService.Shared.Domain.Repositories;

namespace RoadCareService.Assignment.Application.Internal.CommandServices
{
    public class WorkerRoleCommandService
        (IWorkerRoleRepository workerRoleRepository,
        IUnitOfWork unitOfWork) : IWorkerRoleCommandService
    {
        public async Task<bool> Handle
            (AddWorkerRoleToWorkerAreaCommand command)
        {
            try
            {
                await workerRoleRepository
                    .AddAsync(new(command));

                await unitOfWork.CompleteAsync();
            }
            catch (Exception) { return false; }
        }

        public async Task<bool> Handle
            (UpdateWorkerRoleStateCommand command) =>
            await workerRoleRepository
            .UpdateWorkerRoleStateAsync
            (command.Id, command.WorkerRoleState);
    }
}