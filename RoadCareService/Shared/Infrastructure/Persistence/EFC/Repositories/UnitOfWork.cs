using RoadCareService.Shared.Domain.Repositories;
using RoadCareService.Shared.Infrastructure.Persistence.EFC.Configuration;

namespace RoadCareService.Shared.Infrastructure.Persistence.EFC.Repositories
{
    public class UnitOfWork
        (RoadCareContext context) :
        IUnitOfWork
    {
        public async Task CompleteAsync() =>
            await context.SaveChangesAsync();
    }
}