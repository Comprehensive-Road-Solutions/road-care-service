using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using RoadCareService.IAM.Domain.Services.Worker;
using RoadCareService.IAM.Domain.Services.Citizen;
using RoadCareService.IAM.Domain.Model.Queries.Citizen;
using RoadCareService.IAM.Domain.Model.Queries.Worker;
using RoadCareService.IAM.Infrastructure.Pipeline.Middleware.Attributes;
using RoadCareService.IAM.Interfaces.REST.Transform.Worker;
using RoadCareService.IAM.Interfaces.REST.Transform.Citizen;

namespace RoadCareService.IAM.Interfaces.REST
{
    [Route("api/informations/")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Authorize("TRABAJADOR", "CIUDADANO")]
    public class InformationsController
        (IWorkerQueryService workerQueryService,
        ICitizenQueryService citizenQueryService) :
        ControllerBase
    {
        [Route("worker-by-id")]
        [HttpGet]
        public async Task<IActionResult> GetWorkerById
            ([FromQuery] int id)
        {
            var worker = await workerQueryService
                .Handle(new GetWorkerByIdQuery(id));

            if (worker is null)
                return BadRequest();

            var workerResource = WorkerResourceFromEntityAssembler
                .ToResourceFromEntity(worker);

            return Ok(workerResource);
        }

        [Route("citizen-by-id")]
        [HttpGet]
        public async Task<IActionResult> GetCitizenById
            ([FromQuery] int id)
        {
            var citizen = await citizenQueryService
                .Handle(new GetCitizenByIdQuery(id));

            if (citizen is null)
                return BadRequest();

            var citizenResource = CitizenResourceFromEntityAssembler
                .ToResourceFromEntity(citizen);

            return Ok(citizenResource);
        }
    }
}