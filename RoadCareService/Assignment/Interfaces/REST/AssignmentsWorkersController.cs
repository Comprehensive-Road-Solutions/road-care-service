using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using RoadCareService.Assignment.Domain.Model.Queries.AssignmentWorker;
using RoadCareService.Assignment.Domain.Services.AssignmentWorker;
using RoadCareService.Assignment.Interfaces.REST.Resources.AssignmentWorker;
using RoadCareService.Assignment.Interfaces.REST.Transform.AssignmentWorker;
using RoadCareService.IAM.Infrastructure.Pipiline.Middleware.Attributes;

namespace RoadCareService.Assignment.Interfaces.REST
{
    [Route("api/assignmentsworkers/")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Authorize("TRABAJADOR")]
    public class AssignmentsWorkersController
        (IAssignmentWorkerCommandService assignmentWorkerCommandService,
        IAssignmentWorkerQueryService assignmentWorkerQueryService) :
        ControllerBase
    {
        [Route("add-assignment-worker")]
        [HttpPost]
        public async Task<IActionResult> AddAssignmentWorker
            ([FromBody] AddAssignmentWorkerResource resource)
        {
            var result = await assignmentWorkerCommandService
                .Handle(AddAssignmentWorkerCommandFromResourceAssembler
                .ToCommandFromResource(resource));

            if (result is false)
                return BadRequest();

            return Ok(result);
        }

        [Route("update-assignment-worker-state")]
        [HttpPost]
        public async Task<IActionResult> UpdateWorkerAreaState
            ([FromBody] UpdateAssignmentWorkerStateResource resource)
        {
            var result = await assignmentWorkerCommandService
                .Handle(UpdateAssignmentWorkerStateCommandFromResourceAssembler
                .ToCommandFromResource(resource));

            if (result is false)
                return BadRequest();

            return Ok(result);
        }

        [Route("all-assignments-workers")]
        [HttpGet]
        public async Task<IActionResult> GetAllAssignmentsWorkers()
        {
            var assignmentsWorkers = await assignmentWorkerQueryService
                .Handle(new GetAllAssignmentsWorkersQuery());

            if (assignmentsWorkers is null)
                return BadRequest();

            var assignmentsWorkersResource = assignmentsWorkers
                .Select(AssignmentWorkerResourceFromEntityAssembler
                .ToResourceFromEntity);

            return Ok(assignmentsWorkersResource);
        }

        [Route("assignment-worker-by-id")]
        [HttpGet]
        public async Task<IActionResult> GetAssignmentWorkerById
            ([FromQuery] int id)
        {
            var assignmentWorker = await assignmentWorkerQueryService
                .Handle(new GetAssignmentWorkerByIdQuery(id));

            if (assignmentWorker is null)
                return BadRequest();

            var assignmentWorkerResource = AssignmentWorkerResourceFromEntityAssembler
                .ToResourceFromEntity(assignmentWorker);

            return Ok(assignmentWorkerResource);
        }

        [Route("assignments-workers-by-government-entity-and-worker-area-and-role")]
        [HttpGet]
        public async Task<IActionResult> GetAssignmentsWorkersByGovernmentEntityIdAndWorkerAreaIdAndRoleId
            ([FromQuery] int governmentEntityId, [FromQuery] int workerAreaId, [FromQuery] int roleId)
        {
            var assignmentsWorkers = await assignmentWorkerQueryService
                .Handle(new GetAssignmentsWorkersByGovernmentEntityIdAndWorkerAreaIdAndRoleIdQuery
                (governmentEntityId, workerAreaId, roleId));

            if (assignmentsWorkers is null)
                return BadRequest();

            var assignmentsWorkersResource = assignmentsWorkers
                .Select(AssignmentWorkerResourceFromEntityAssembler
                .ToResourceFromEntity);

            return Ok(assignmentsWorkersResource);
        }

        [Route("assignments-workers-by-government-entity-and-worker-area")]
        [HttpGet]
        public async Task<IActionResult> GetAssignmentsWorkersByGovernmentEntityIdAndWorkerAreaId
            ([FromQuery] int governmentEntityId, [FromQuery] int workerAreaId)
        {
            var assignmentsWorkers = await assignmentWorkerQueryService
                .Handle(new GetAssignmentsWorkersByGovernmentEntityIdAndWorkerAreaIdQuery
                (governmentEntityId, workerAreaId));

            if (assignmentsWorkers is null)
                return BadRequest();

            var assignmentsWorkersResource = assignmentsWorkers
                .Select(AssignmentWorkerResourceFromEntityAssembler
                .ToResourceFromEntity);

            return Ok(assignmentsWorkersResource);
        }
    }
}