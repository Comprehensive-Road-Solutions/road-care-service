using RoadCareService.Location.Domain.Model.Aggregates;
using RoadCareService.Location.Domain.Repositories;
using RoadCareService.Shared.Infrastructure.Persistence.EFC.Configuration;
using RoadCareService.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace RoadCareService.Location.Infrastructure.Persistence.EFC.Repositories
{
    internal class DepartmentRepository
        (RoadCareContext context) :
        BaseRepository<Department>(context),
        IDepartmentRepository
    { }
}