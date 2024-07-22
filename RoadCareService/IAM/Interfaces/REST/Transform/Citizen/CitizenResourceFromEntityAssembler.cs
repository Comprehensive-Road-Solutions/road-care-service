using RoadCareService.IAM.Interfaces.REST.Resources.Citizen;

namespace RoadCareService.IAM.Interfaces.REST.Transform.Citizen
{
    public class CitizenResourceFromEntityAssembler
    {
        public static CitizenResource ToResourceFromEntity
            (Domain.Model.Aggregates.Citizen entity) =>
            new(entity.Id, entity.ProfileUrl,
                entity.Firstname, entity.Lastname,
                entity.Age,entity.Genre,
                entity.Phone, entity.Email);
    }
}