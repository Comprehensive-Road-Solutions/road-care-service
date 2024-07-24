using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using RoadCareService.IAM.Infrastructure.Pipeline.Middleware.Attributes;
using RoadCareService.Publishing.Domain.Model.Queries.Evidence;
using RoadCareService.Publishing.Domain.Model.Queries.Publication;
using RoadCareService.Publishing.Domain.Services.Evidence;
using RoadCareService.Publishing.Domain.Services.Publication;
using RoadCareService.Publishing.Interfaces.REST.Resources.Evidence;
using RoadCareService.Publishing.Interfaces.REST.Resources.Publication;
using RoadCareService.Publishing.Interfaces.REST.Transform.Evidence;
using RoadCareService.Publishing.Interfaces.REST.Transform.Publication;

namespace RoadCareService.Publishing.Interfaces.REST
{
    [Route("api/publications/")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Authorize("CIUDADANO")]
    public class PublicationsController
        (IPublicationCommandService publicationCommandService,
        IPublicationQueryService publicationQueryService,
        IEvidenceCommandService evidenceCommandService,
        IEvidenceQueryService evidenceQueryService) :
        ControllerBase
    {
        [Route("create-publication")]
        [HttpPost]
        public async Task<IActionResult> CreatePublication
            ([FromBody] CreatePublicationResource resource)
        {
            var result = await publicationCommandService
                .Handle(CreatePublicationCommandFromResourceAssembler
                .ToCommandFromResource(resource));

            if (result is false)
                return BadRequest();

            return Ok(result);
        }

        [Route("all-publications")]
        [HttpGet]
        public async Task<IActionResult> GetAllPublications()
        {
            var publications = await publicationQueryService
                .Handle(new GetAllPublicationsQuery());

            if (publications is null)
                return BadRequest();

            var publicationResource = publications
                .Select(PublicationResourceFromEntityAssembler
                .ToResourceFromEntity);

            return Ok(publicationResource);
        }

        [Route("publications-by-department-and-district")]
        [HttpGet]
        public async Task<IActionResult> GetPublicationsByDepartmentIdAndDistrictId
            ([FromQuery] int departmentId, [FromQuery] int districtId)
        {
            var publications = await publicationQueryService
                .Handle(new GetPublicationsByDepartmentIdAndDistrictIdQuery
                (departmentId, districtId));

            if (publications is null)
                return BadRequest();

            var publicationsResource = publications
                .Select(PublicationResourceFromEntityAssembler
                .ToResourceFromEntity);

            return Ok(publicationsResource);
        }

        [Route("add-evidence-to-publication")]
        [HttpPost]
        public async Task<IActionResult> AddEvidenceToPublication
            ([FromBody] AddEvidenceToPublicationResource resource)
        {
            var result = await evidenceCommandService
                .Handle(AddEvidenceToPublicationCommandFromResourceAssembler
                .ToCommandFromResource(resource));

            if (result is false)
                return BadRequest();

            return Ok(result);
        }

        [Route("evidences-by-publication")]
        [HttpGet]
        public async Task<IActionResult> GetEvidencesByPublicationId
            ([FromQuery] int publicationId)
        {
            var evidences = await evidenceQueryService
                .Handle(new GetEvidencesByPublicationIdQuery
                (publicationId));

            if (evidences is null)
                return BadRequest();

            var evidencesResource = evidences
                .Select(EvidenceResourceFromEntityAssembler
                .ToResourceFromEntity);

            return Ok(evidencesResource);
        }
    }
}