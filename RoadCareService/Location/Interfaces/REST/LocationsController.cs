using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using RoadCareService.IAM.Infrastructure.Pipeline.Middleware.Attributes;
using RoadCareService.Location.Domain.Model.Queries.Department;
using RoadCareService.Location.Domain.Model.Queries.District;
using RoadCareService.Location.Domain.Services.Department;
using RoadCareService.Location.Domain.Services.District;
using RoadCareService.Location.Interfaces.REST.Transform.Department;
using RoadCareService.Location.Interfaces.REST.Transform.District;

namespace RoadCareService.Location.Interfaces.REST
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

            var districtsResource = districts
                .Select(DistrictResourceFromEntityAssembler
                .ToResourceFromEntity);

            return Ok(districtsResource);
        }
    }
}