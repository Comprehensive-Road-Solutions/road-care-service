using RoadCareService.Interaction.Domain.Model.Commands;
using RoadCareService.Interaction.Domain.Repositories;
using RoadCareService.Interaction.Domain.Services;
using RoadCareService.Interaction.Infrastructure.Persistence.EFC.Repositories;
using RoadCareService.Shared.Domain.Repositories;
using RoadCareService.Shared.Infrastructure.Persistence.EFC.Configuration;

namespace RoadCareService.Interaction.Application.Internal.CommandServices
{
    public class CommentCommandService(RoadCareContext context,
        IUnitOfWork unitOfWork) : ICommentCommandService
    {
        private readonly ICommentRepository CommentRepository =
            new CommentRepositoryEFC(context);

        public async Task<bool> Handle
            (AddCommentToPublicationCommand command)
        {
            try
            {
                await CommentRepository.AddAsync(new(command));

                await unitOfWork.CompleteAsync();

                return true;
            }
            catch (Exception) { return false; }
        }
    }
}