using RoadCareService.IAM.Application.Internal.OutboundServices;
using RoadCareService.IAM.Domain.Model.Commands.Citizen;
using RoadCareService.IAM.Domain.Repositories;
using RoadCareService.IAM.Domain.Services.Citizen;
using RoadCareService.Shared.Domain.Repositories;

namespace RoadCareService.IAM.Application.Internal.CommandServices
{
    public class CitizenCommandService
        (ICitizenRepository citizenRepository,
        IUnitOfWork unitOfWork,
        IReniecService reniecService) :
        ICitizenCommandService
    {
        public async Task<bool> Handle
            (RegisterCitizenCommand command)
        {
            try
            {
                if (await reniecService
                    .ValidateDni(command.Id)
                    is false)
                    return false;

                await citizenRepository
                    .AddAsync(new(command));

                await unitOfWork.CompleteAsync();

                return true;
            }
            catch (Exception) { return false; }
        }
    }
}