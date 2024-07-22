﻿using Microsoft.AspNetCore.Mvc;
using RoadCareService.IAM.Domain.Model.Queries.CitizenCredential;
using RoadCareService.IAM.Domain.Model.Queries.WorkerCredential;
using RoadCareService.IAM.Domain.Model.ValueObjects.Credential;
using RoadCareService.IAM.Domain.Services.Citizen;
using RoadCareService.IAM.Domain.Services.CitizenCredential;
using RoadCareService.IAM.Domain.Services.Worker;
using RoadCareService.IAM.Domain.Services.WorkerCredential;
using RoadCareService.IAM.Interfaces.REST.Resources.Citizen;
using RoadCareService.IAM.Interfaces.REST.Resources.CitizenCredential;
using RoadCareService.IAM.Interfaces.REST.Resources.User;
using RoadCareService.IAM.Interfaces.REST.Resources.Worker;
using RoadCareService.IAM.Interfaces.REST.Resources.WorkerCredentia;
using RoadCareService.IAM.Interfaces.REST.Transform.Citizen;
using RoadCareService.IAM.Interfaces.REST.Transform.CitizenCredential;
using RoadCareService.IAM.Interfaces.REST.Transform.Worker;
using RoadCareService.IAM.Interfaces.REST.Transform.WorkerCredential;

namespace RoadCareService.IAM.Interfaces.REST
{
    [Route("api/access/")]
    [ApiController]
    public class AccessController
        (IWorkerCommandService workerCommandService,
        IWorkerCredentialCommandService workerCredentialCommandService,
        IWorkerCredentialQueryService workerCredentialQueryService,
        ICitizenCommandService citizenCommandService,
        ICitizenCredentialCommandService citizenCredentialCommandService,
        ICitizenCredentialQueryService citizenCredentialQueryService) :
        ControllerBase
    {
        [Route("login")]
        [HttpPost]
        public async Task<IActionResult> Login
            ([FromBody] UserResource resource)
        {
            if (!Enum.TryParse<ECredentialRole>
                (resource.Role, out var role))
                return BadRequest();

            try
            {
                var result = role switch
                {
                    ECredentialRole.TRABAJADOR =>
                    await workerCredentialQueryService
                    .Handle(new GetWorkerCredentialByWorkerIdAndCodeQuery
                    (resource.Username, resource.Password)),

                    ECredentialRole.CIUDADANO =>
                    await citizenCredentialQueryService
                    .Handle(new GetCitizenCredentialByCitizenIdAndCodeQuery
                    (resource.Username, resource.Password)),

                    _ => null
                };

                if (string.IsNullOrEmpty(result))
                    return Unauthorized();

                return Ok(result);
            }
            catch (Exception)
            { return BadRequest(); }
        }

        [Route("register-worker")]
        [HttpPost]
        public async Task<IActionResult> RegisterWorker
            ([FromBody] RegisterWorkerResource resource)
        {
            var result = await workerCommandService
                .Handle(RegisterWorkerCommandFromResourceAssembler
                .ToCommandFromResource(resource));

            if (result is false)
                return BadRequest();

            result = await workerCredentialCommandService
                .Handle(AddWorkerCredentialCommandFromResourceAssembler
                .ToCommandFromResource(new AddWorkerCredentialResource
                (resource.Id, resource.Code)));

            return Ok(result);
        }

        [Route("register-citizen")]
        [HttpPost]
        public async Task<IActionResult> RegisterCitizen
            ([FromBody] RegisterCitizenResource resource)
        {
            var result = await citizenCommandService
                .Handle(RegisterCitizenCommandFromResourceAssembler
                .ToCommandFromResource(resource));

            if (result is false)
                return BadRequest();

            result = await citizenCredentialCommandService
                .Handle(AddCitizenCredentialCommandFromResourceAssembler
                .ToCommandFromResource(new AddCitizenCredentialResource
                (resource.Id, resource.Code)));

            return Ok(result);
        }
    }
}