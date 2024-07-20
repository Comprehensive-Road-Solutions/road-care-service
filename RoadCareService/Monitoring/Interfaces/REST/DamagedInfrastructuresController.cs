using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using RoadCareService.Monitoring.Domain.Model.Queries.DamagedInfrastructure;
using RoadCareService.Monitoring.Domain.Model.ValueObjects.DamagedInfrastructure;
using RoadCareService.Monitoring.Domain.Services.DamagedInfrastructure;
using RoadCareService.Monitoring.Interfaces.REST.Resources.DamagedInfrastructure;
using RoadCareService.Monitoring.Interfaces.REST.Transform.DamagedInfrastructure;

namespace RoadCareService.Monitoring.Interfaces.REST
{
    [Route("api/damagedinfrastructures/")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    public class DamagedInfrastructuresController
        (IDamagedInfrastructureCommandService damagedInfrastructureCommandService,
        IDamagedInfrastructureQueryService damagedInfrastructureQueryService) :
        ControllerBase
    {
        [Route("register-damaged-infrastructure")]
        [HttpPost]
        public async Task<IActionResult> RegisterDamagedInfrastructure
            ([FromBody] RegisterDamagedInfrastructureResource resource)
        {
            var result = await damagedInfrastructureCommandService
                .Handle(RegisterDamagedInfrastructureCommandFromResourceAssembler
                .ToCommandFromResource(resource));

            if (result is false)
                return BadRequest();

            return Ok(result);
        }

        [Route("update-damaged-infrastructure-state")]
        [HttpPost]
        public async Task<IActionResult> UpdateDamagedInfrastructureState
            ([FromBody] UpdateDamagedInfrastructureStateResource resource)
        {
            var result = await damagedInfrastructureCommandService
                .Handle(UpdateDamagedInfrastructureStateCommandFromResourceAssembler
                .ToCommandFromResource(resource));

            if (result is false)
                return BadRequest();

            return Ok(result);
        }

        [Route("assign-work-date")]
        [HttpPost]
        public async Task<IActionResult> AssignWorkDateToDamagedInfrastructure
            ([FromBody] AssignWorkDateToDamagedInfrastructureResource resource)
        {
            var result = await damagedInfrastructureCommandService
                .Handle(AssignWorkDateToDamagedInfrastructureCommandFromResourceAssembler
                .ToCommandFromResource(resource));

            if (result is false)
                return BadRequest();

            return Ok(result);
        }

        [Route("damaged-infrastructures")]
        [HttpGet]
        public async Task<IActionResult> GetAllDamagedInfrastructures()
        {
            var damagedInfrastructures = await damagedInfrastructureQueryService
                .Handle(new GetAllDamagedInfrastructuresQuery());

            if (damagedInfrastructures is null)
                return BadRequest();

            var damagedInfrastructuresResource = damagedInfrastructures
                .Select(DamagedInfrastructureResourceFromEntityAssembler
                .ToResourceFromEntity);

            return Ok(damagedInfrastructuresResource);
        }

        [Route("damaged-infrastructures-by-id")]
        [HttpGet]
        public async Task<IActionResult> GetDamagedInfrastructuresById
            ([FromQuery] int id)
        {
            var damagedInfrastructure = await damagedInfrastructureQueryService
                .Handle(new GetDamagedInfrastructureByIdQuery(id));

            if (damagedInfrastructure is null)
                return BadRequest();

            var damagedInfrastructureResource = 
                DamagedInfrastructureResourceFromEntityAssembler
                .ToResourceFromEntity(damagedInfrastructure);

            return Ok(damagedInfrastructureResource);
        }

        [Route("damaged-infrastructures-by-department-and-district")]
        [HttpGet]
        public async Task<IActionResult> GetDamagedInfrastructuresByDepartmentsIdAndDistrictsId
            ([FromQuery] int departmentId, [FromQuery] int districtId)
        {
            var damagedInfrastructures = await damagedInfrastructureQueryService
                .Handle(new GetDamagedInfrastructuresByDepartmentsIdAndDistrictsIdQuery
                (departmentId, districtId));

            if (damagedInfrastructures is null)
                return BadRequest();

            var damagedInfrastructuresResource = damagedInfrastructures
                .Select(DamagedInfrastructureResourceFromEntityAssembler
                .ToResourceFromEntity);

            return Ok(damagedInfrastructuresResource);
        }

        [Route("damaged-infrastructures-by-state")]
        [HttpGet]
        public async Task<IActionResult> GetDamagedInfrastructuresByState
            ([FromQuery] string state)
        {
            var damagedInfrastructures = await damagedInfrastructureQueryService
                .Handle(new GetDamagedInfrastructuresByStateQuery
                (Enum.Parse<EDamagedInfrastructureState>(state)));

            if (damagedInfrastructures is null)
                return BadRequest();

            var damagedInfrastructuresResource = damagedInfrastructures
                .Select(DamagedInfrastructureResourceFromEntityAssembler
                .ToResourceFromEntity);

            return Ok(damagedInfrastructuresResource);
        }
    }
}