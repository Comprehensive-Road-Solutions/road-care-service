using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using RoadCareService.Publishing.Domain.Model.Queries.Publication;
using RoadCareService.Publishing.Domain.Services.Publication;
using RoadCareService.Publishing.Interfaces.REST.Resources;
using RoadCareService.Publishing.Interfaces.REST.Transform;

namespace RoadCareService.Publishing.Interfaces.REST
{
    [Route("api/publications/")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    public class PublicationsController(IPublicationCommandService publicationCommandService,
        IPublicationQueryService publicationQueryService) : ControllerBase
    {
        [Route("create-publication")]
        [HttpPost]
        public async Task<IActionResult> CreatePublication
            ([FromBody] CreatePublicationResource resource)
        {
            var publication = await publicationCommandService
                .Handle(CreatePublicationCommandFromResourceAssembler
                .ToCommandFromResource(resource));

            if (publication is false)
                return BadRequest();

            return Ok(publication);
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
    }
}