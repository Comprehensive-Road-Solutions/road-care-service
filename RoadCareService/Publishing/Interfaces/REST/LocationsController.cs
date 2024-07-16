using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using RoadCareService.Publishing.Domain.Services.Department;
using RoadCareService.Publishing.Domain.Services.District;
using RoadCareService.Publishing.Domain.Model.Queries.Department;
using RoadCareService.Publishing.Interfaces.REST.Transform.Department;
using RoadCareService.Publishing.Interfaces.REST.Transform.District;

namespace RoadCareService.Publishing.Interfaces.REST
{
    [Route("api/locations/")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    public class LocationsController(IDepartmentQueryService departmentQueryService,
        IDistrictQueryService districtQueryService) : ControllerBase
    {
        [Route("departments")]
        [HttpGet]
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
        public async Task<IActionResult> GetDistrictsByDepartmentsId(int departmentsId)
        {
            var districts = await districtQueryService
                .Handle(new Domain.Model.Queries.District.GetDistrictsByDepartmentsIdQuery(departmentsId));

            if (districts is null)
                return BadRequest();

            var districtsResource = districts
                .Select(DistrictResourceFromEntityAssembler
                .ToResourceFromEntity);

            return Ok(districtsResource);
        }
    }
}