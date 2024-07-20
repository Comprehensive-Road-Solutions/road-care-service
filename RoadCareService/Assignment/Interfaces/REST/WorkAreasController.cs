using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using RoadCareService.Assignment.Domain.Model.Queries.WorkerArea;
using RoadCareService.Assignment.Domain.Model.Queries.WorkerRole;
using RoadCareService.Assignment.Domain.Model.ValueObjects.WorkerArea;
using RoadCareService.Assignment.Domain.Services.WorkerArea;
using RoadCareService.Assignment.Domain.Services.WorkerRole;
using RoadCareService.Assignment.Interfaces.REST.Resources.WorkerArea;
using RoadCareService.Assignment.Interfaces.REST.Resources.WorkerRole;
using RoadCareService.Assignment.Interfaces.REST.Transform.WorkerArea;
using RoadCareService.Assignment.Interfaces.REST.Transform.WorkerRole;

namespace RoadCareService.Assignment.Interfaces.REST
{
    [Route("api/worksareas/")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    public class WorkAreasController
        (IWorkerAreaCommandService workerAreaCommandService,
        IWorkerAreaQueryService workerAreaQueryService,
        IWorkerRoleCommandService workerRoleCommandService,
        IWorkerRoleQueryService workerRoleQueryService) :
        ControllerBase
    {
        [Route("create-worker-area")]
        [HttpPost]
        public async Task<IActionResult> CreateWorkerArea
            ([FromBody] CreateWorkerAreaResource resource)
        {
            var result = await workerAreaCommandService
                .Handle(CreateWorkerAreaCommandFromResourceAssembler
                .ToCommandFromResource(resource));

            if (result is false)
                return BadRequest();

            return Ok(result);
        }

        [Route("update-worker-area-state")]
        [HttpPost]
        public async Task<IActionResult> UpdateWorkerAreaState
            ([FromBody] UpdateWorkerAreaStateResource resource)
        {
            var result = await workerAreaCommandService
                .Handle(UpdateWorkerAreaStateCommandFromResourceAssembler
                .ToCommandFromResource(resource));

            if (result is false)
                return BadRequest();

            return Ok(result);
        }

        [Route("all-workers-areas")]
        [HttpGet]
        public async Task<IActionResult> GetAllWorkersAreas()
        {
            var workersAreas = await workerAreaQueryService
                .Handle(new GetAllWorkersAreasQuery());

            if (workersAreas is null)
                return BadRequest();

            var workersAreasResource = workersAreas
                .Select(WorkerAreaResourceFromEntityAssembler
                .ToResourceFromEntity);

            return Ok(workersAreasResource);
        }

        [Route("worker-area-by-id")]
        [HttpGet]
        public async Task<IActionResult> GetWorkerAreaById
            ([FromQuery] int id)
        {
            var workerArea = await workerAreaQueryService
                .Handle(new GetWorkerAreaByIdQuery(id));

            if (workerArea is null)
                return BadRequest();

            var workerAreaResource = WorkerAreaResourceFromEntityAssembler
                .ToResourceFromEntity(workerArea);

            return Ok(workerAreaResource);
        }

        [Route("workers-areas-by-government-entity-and-state")]
        [HttpGet]
        public async Task<IActionResult> GetWorkersAreasByGovernmentEntityIdAndState
            ([FromQuery] int governmentEntityId, [FromQuery] string state)
        {
            var workersAreas = await workerAreaQueryService
                .Handle(new GetWorkersAreasByGovernmentEntityIdAndStateQuery
                (governmentEntityId, Enum.Parse<EWorkerAreaState>(state)));

            if (workersAreas is null)
                return BadRequest();

            var workersAreasResource = workersAreas
                .Select(WorkerAreaResourceFromEntityAssembler
                .ToResourceFromEntity);

            return Ok(workersAreasResource);
        }

        [Route("workers-areas-by-government-entity")]
        [HttpGet]
        public async Task<IActionResult> GetWorkersAreasByGovernmentEntityId
            ([FromQuery] int governmentEntityId)
        {
            var workersAreas = await workerAreaQueryService
                .Handle(new GetWorkersAreasByGovernmentEntityIdQuery
                (governmentEntityId));

            if (workersAreas is null)
                return BadRequest();

            var workersAreasResource = workersAreas
                .Select(WorkerAreaResourceFromEntityAssembler
                .ToResourceFromEntity);

            return Ok(workersAreasResource);
        }

        [Route("create-worker-role")]
        [HttpPost]
        public async Task<IActionResult> CreateWorkerRole
            ([FromBody] AddWorkerRoleToWorkerAreaResource resource)
        {
            var result = await workerRoleCommandService
                .Handle(AddWorkerRoleToWorkerAreaCommandFromResourceAssembler
                .ToCommandFromResource(resource));

            if (result is false)
                return BadRequest();

            return Ok(result);
        }

        [Route("update-worker-role-state")]
        [HttpPost]
        public async Task<IActionResult> UpdateWorkerRoleState
            ([FromBody] UpdateWorkerRoleStateResource resource)
        {
            var result = await workerRoleCommandService
                .Handle(UpdateWorkerRoleStateCommandFromResourceAssembler
                .ToCommandFromResource(resource));

            if (result is false)
                return BadRequest();

            return Ok(result);
        }

        [Route("all-workers-roles")]
        [HttpGet]
        public async Task<IActionResult> GetAllWorkersRoles()
        {
            var workersRoles = await workerRoleQueryService
                .Handle(new GetAllWorkersRolesQuery());

            if (workersRoles is null)
                return BadRequest();

            var workersRolesResource = workersRoles
                .Select(WorkerRoleResourceFromEntityAssembler
                .ToResourceFromEntity);

            return Ok(workersRolesResource);
        }

        [Route("worker-role-by-id")]
        [HttpGet]
        public async Task<IActionResult> GetWorkerRoleById
            ([FromQuery] int id)
        {
            var workerRole = await workerRoleQueryService
                .Handle(new GetWorkerRoleByIdQuery(id));

            if (workerRole is null)
                return BadRequest();

            var workerRoleResource = WorkerRoleResourceFromEntityAssembler
                .ToResourceFromEntity(workerRole);

            return Ok(workerRoleResource);
        }

        [Route("workers-roles-by-government-entity-and-worker-area")]
        [HttpGet]
        public async Task<IActionResult> GetWorkersRolesByGovernmentEntityIdAndWorkerAreaId
            ([FromQuery] int governmentEntityId, [FromQuery] int WorkerAreaId)
        {
            var workersRoles = await workerRoleQueryService
                .Handle(new GetWorkersRolesByGovernmentEntityIdAndWorkerAreaIdQuery
                (governmentEntityId, WorkerAreaId));

            if (workersRoles is null)
                return BadRequest();

            var workersRolesResource = workersRoles
                .Select(WorkerRoleResourceFromEntityAssembler
                .ToResourceFromEntity);

            return Ok(workersRolesResource);
        }
    }
}