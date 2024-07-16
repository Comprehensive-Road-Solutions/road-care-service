using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using RoadCareService.Publishing.Domain.Model.Queries.Publication;
using RoadCareService.Publishing.Domain.Services.Publication;
using RoadCareService.Publishing.Interfaces.REST.Resources.Publication;
using RoadCareService.Publishing.Interfaces.REST.Transform.Publication;
using RoadCareService.Publishing.Domain.Services.Evidence;
using RoadCareService.Publishing.Interfaces.REST.Resources.Evidence;
using RoadCareService.Publishing.Interfaces.REST.Transform.Evidence;
using RoadCareService.Publishing.Domain.Model.Queries.Evidence;

namespace RoadCareService.Publishing.Interfaces.REST
{
    [Route("api/publications/")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    public class PublicationsController(IPublicationCommandService publicationCommandService,
        IPublicationQueryService publicationQueryService,
        IEvidenceCommandService evidenceCommandService,
        IEvidenceQueryService evidenceQueryService) : ControllerBase
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

        [Route("publications")]
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

        [Route("publications-by-zone")]
        [HttpGet]
        public async Task<IActionResult> GetPublicationsByDepartmentsIdAndDistrictsId
            ([FromQuery] int departmentsId, [FromQuery] int districtsId)
        {
            var publications = await publicationQueryService
                .Handle(new GetPublicationsByDepartmentsIdAndDistrictsIdQuery
                (departmentsId, districtsId));

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
        public async Task<IActionResult> GetEvidencesByPublicationsId
            ([FromQuery] int publicationsId)
        {
            var evidences = await evidenceQueryService
                .Handle(new GetEvidencesByPublicationsIdQuery
                (publicationsId));

            if (evidences is null)
                return BadRequest();

            var evidencesResource = evidences
                .Select(EvidenceResourceFromEntityAssembler
                .ToResourceFromEntity);

            return Ok(evidencesResource);
        }
    }
}