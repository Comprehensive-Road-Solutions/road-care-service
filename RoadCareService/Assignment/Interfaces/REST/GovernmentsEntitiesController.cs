using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using RoadCareService.Assignment.Domain.Model.Queries.GovernmentEntity;
using RoadCareService.Assignment.Domain.Services.GovernmentEntity;
using RoadCareService.Assignment.Interfaces.REST.Transform.GovernmentEntity;
using RoadCareService.IAM.Infrastructure.Pipiline.Middleware.Attributes;

namespace RoadCareService.Assignment.Interfaces.REST
{
    [Route("api/governmentsentities/")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Authorize]
    public class GovernmentsEntitiesController
        (IGovernmentEntityQueryService governmentEntityQueryService) :
        ControllerBase
    {
        [Route("all-governments-entities")]
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllGovernmentsEntities()
        {
            var govenmentsEntities = await governmentEntityQueryService
                .Handle(new GetAllGovernmentsEntitiesQuery());

            if (govenmentsEntities is null)
                return BadRequest();

            var govenmentsEntitiesResource = govenmentsEntities
                .Select(GovernmentEntityResourceFromEntityAssembler
                .ToResourceFromEntity);

            return Ok(govenmentsEntitiesResource);
        }

        [Route("government-entity-by-id")]
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetGovernmentEntityById
            ([FromQuery] int id)
        {
            var govenmentEntity = await governmentEntityQueryService
                .Handle(new GetGovernmentEntityByIdQuery(id));

            if (govenmentEntity is null)
                return BadRequest();

            var govenmentEntityResource = GovernmentEntityResourceFromEntityAssembler
                .ToResourceFromEntity(govenmentEntity);

            return Ok(govenmentEntityResource);
        }      
    }
}