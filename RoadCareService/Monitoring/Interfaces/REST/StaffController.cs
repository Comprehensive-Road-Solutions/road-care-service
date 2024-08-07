﻿using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using RoadCareService.IAM.Infrastructure.Pipeline.Middleware.Attributes;
using RoadCareService.Monitoring.Domain.Model.Queries.Staff;
using RoadCareService.Monitoring.Domain.Model.ValueObjects.Staff;
using RoadCareService.Monitoring.Domain.Services.Staff;
using RoadCareService.Monitoring.Interfaces.REST.Resources.Staff;
using RoadCareService.Monitoring.Interfaces.REST.Transform.Staff;

namespace RoadCareService.Monitoring.Interfaces.REST
{
    [Route("api/staff/")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Authorize("TRABAJADOR")]
    public class StaffController
        (IStaffCommandService staffCommandService,
        IStaffQueryService staffQueryService) :
        ControllerBase
    {
        [Route("add-staff-in-charge")]
        [HttpPost]
        public async Task<IActionResult> AddStaffInCharge
            ([FromBody] AddStaffInChargeResource resource)
        {
            var result = await staffCommandService
                .Handle(AddStaffInChargeCommandFromResourceAssembler
                .ToCommandFromResource(resource));

            if (result is false)
                return BadRequest();

            return Ok(result);
        }

        [Route("update-staff-state")]
        [HttpPost]
        public async Task<IActionResult> UpdateStaffState
            ([FromBody] UpdateStaffStateResource resource)
        {
            var result = await staffCommandService
                .Handle(UpdateStaffStateCommandFromResourceAssembler
                .ToCommandFromResource(resource));

            if (result is false)
                return BadRequest();

            return Ok(result);
        }

        [Route("all-staff")]
        [HttpGet]
        public async Task<IActionResult> GetAllStaff()
        {
            var staff = await staffQueryService
                .Handle(new GetAllStaffQuery());

            var staffResource = staff.Select
                (StaffResourceFromEntityAssembler
                .ToResourceFromEntity);

            return Ok(staffResource);
        }

        [Route("staff-by-id")]
        [HttpGet]
        public async Task<IActionResult> GetStaffById
            ([FromQuery] int id)
        {
            var staff = await staffQueryService
                .Handle(new GetStaffByIdQuery(id));

            if (staff is null)
                return BadRequest();

            var staffResource =
                StaffResourceFromEntityAssembler
                .ToResourceFromEntity(staff);

            return Ok(staffResource);
        }

        [Route("staff-by-worker")]
        [HttpGet]
        public async Task<IActionResult> GetStaffByWorkerId
            ([FromQuery] int workerId)
        {
            var staff = await staffQueryService
                .Handle(new GetStaffByWorkerIdQuery
                (workerId));

            var staffResource = staff.Select
                (StaffResourceFromEntityAssembler
                .ToResourceFromEntity);

            return Ok(staffResource);
        }

        [Route("staff-by-state")]
        [HttpGet]
        public async Task<IActionResult> GetStaffByState
            ([FromQuery] string state)
        {
            var staff = await staffQueryService
                .Handle(new GetStaffByStateQuery
                (Enum.Parse<EStaffState>(state)));

            var staffResource = staff.Select
                (StaffResourceFromEntityAssembler
                .ToResourceFromEntity);

            return Ok(staffResource);
        }
    }
}