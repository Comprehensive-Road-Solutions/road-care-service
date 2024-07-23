using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using RoadCareService.IAM.Infrastructure.Pipiline.Middleware.Attributes;
using RoadCareService.Publishing.Domain.Model.Queries.Department;
using RoadCareService.Publishing.Domain.Model.Queries.District;
using RoadCareService.Publishing.Domain.Services.Department;
using RoadCareService.Publishing.Domain.Services.District;
using RoadCareService.Publishing.Interfaces.REST.Transform.Department;
using RoadCareService.Publishing.Interfaces.REST.Transform.District;

namespace RoadCareService.Publishing.Interfaces.REST
{
    [Route("api/locations/")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Authorize]
    public class LocationsController
        (IDepartmentQueryService departmentQueryService,
        IDistrictQueryService districtQueryService) :
        ControllerBase
    {
        [Route("all-departments")]
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllDepartments()
        {
            var deparments = await departmentQueryService
                .Handle(new GetAllDepartmentsQuery());

            if (deparments is null)
                return BadRequest();

            var deparmentsResource = deparments
                .Select(DepartmentResourceFromEntityAssembler
                .ToResourceFromEntity);

            return Ok(deparmentsResource);
        }

        [Route("districts-by-department")]
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetDistrictsByDepartmentsId
            (int departmentId)
        {
            var districts = await districtQueryService
                .Handle(new GetDistrictsByDepartmentIdQuery
                (departmentId));

            if (districts is null)
                return BadRequest();

            var districtsResource = districts
                .Select(DistrictResourceFromEntityAssembler
                .ToResourceFromEntity);

            return Ok(districtsResource);
        }
    }
}