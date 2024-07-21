using RoadCareService.Publishing.Domain.Model.Entities;
using RoadCareService.Publishing.Domain.Repositories;
using RoadCareService.Shared.Infrastructure.Persistence.EFC.Configuration;
using RoadCareService.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace RoadCareService.Publishing.Infrastructure.Persistence.EFC.Repositories
{
    public class DepartmentRepository
        (RoadCareContext context) :
        BaseRepository<Department>(context),
        IDepartmentRepository
    { }
}