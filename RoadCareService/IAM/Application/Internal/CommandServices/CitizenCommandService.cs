using RoadCareService.IAM.Domain.Model.Commands.Citizen;
using RoadCareService.IAM.Domain.Repositories;
using RoadCareService.IAM.Domain.Services.Citizen;
using RoadCareService.Shared.Domain.Repositories;

namespace RoadCareService.IAM.Application.Internal.CommandServices
{
    public class CitizenCommandService
        (ICitizenRepository citizenRepository,
        IUnitOfWork unitOfWork) :
        ICitizenCommandService
    {
        public async Task<bool> Handle
            (RegisterCitizenCommand command)
        {
            try
            {
                await citizenRepository
                    .AddAsync(new(command));

                await unitOfWork.CompleteAsync();

                return true;
            }
            catch (Exception) { return false; }
        }
    }
}