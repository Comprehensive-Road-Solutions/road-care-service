using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using RoadCareService.Interaction.Domain.Model.Queries.Comment;
using RoadCareService.IAM.Infrastructure.Pipeline.Middleware.Attributes;
using RoadCareService.Interaction.Interfaces.REST.Resources;
using RoadCareService.Interaction.Interfaces.REST.Transform;
using RoadCareService.Interaction.Domain.Services.Comment;

namespace RoadCareService.Interaction.Interfaces.REST
{
    [Route("api/comments/")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Authorize("CIUDADANO")]
    public class CommentsController
        (ICommentCommandService commentCommandService,
        ICommentQueryService commentQueryService) :
        ControllerBase
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

        [Route("comments-by-publication")]
        [HttpGet]
        public async Task<IActionResult> GetCommentsByPublicationId
            ([FromQuery] int publicationId)
        {
            var comments = await commentQueryService
                .Handle(new GetCommentsByPublicationIdQuery
                (publicationId));

            var commentsResource = comments
                .Select(CommentResourceFromEntityAssembler
                .ToResourceFromEntity);

            return Ok(commentsResource);
        }
    }
}