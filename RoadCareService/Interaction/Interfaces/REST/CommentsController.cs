using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using RoadCareService.Interaction.Domain.Services;
using RoadCareService.Interaction.Interfaces.REST.Resources;
using RoadCareService.Interaction.Interfaces.REST.Transform;
using RoadCareService.Interaction.Domain.Model.Queries;

namespace RoadCareService.Interaction.Interfaces.REST
{
    [Route("api/comments/")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    public class CommentsController(ICommentCommandService commentCommandService,
        ICommentQueryService commentQueryService) : ControllerBase
    {
        [Route("add-comment-to-publication")]
        [HttpPost]
        public async Task<IActionResult> AddCommentToPublication
            ([FromBody] AddCommentToPublicationResource resource)
        {
            var result = await commentCommandService
                .Handle(AddCommentToPublicationCommandFromResourceAssembler
                .ToCommandFromResource(resource));

            if (result is false)
                return BadRequest();

            return Ok(result);
        }

        [Route("comments-by-publications")]
        [HttpGet]
        public async Task<IActionResult> GetCommentsByPublicationsId
            ([FromQuery] int publicationsId)
        {
            var comments = await commentQueryService
                .Handle(new GetCommentsByPublicationsIdQuery
                (publicationsId));

            if (comments is null)
                return BadRequest();

            var commentsResource = comments
                .Select(CommentResourceFromEntityAssembler
                .ToResourceFromEntity);

            return Ok(commentsResource);
        }
    }
}