﻿using RoadCareService.Publishing.Domain.Model.Queries.Department;

namespace RoadCareService.Publishing.Domain.Services.Department
{
    public interface IDepartmentQueryService
    {
        Task<IEnumerable<Model.Entities.Department>> Handle
            (GetAllDepartmentsQuery query);
        Task<Model.Entities.Department?> Handle
            (GetDepartmentByIdQuery query);
    }
}