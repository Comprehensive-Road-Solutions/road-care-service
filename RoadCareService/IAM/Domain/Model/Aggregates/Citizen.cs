using RoadCareService.IAM.Domain.Model.Commands.Citizen;
using RoadCareService.IAM.Domain.Model.Entities;
using RoadCareService.IAM.Domain.Model.ValueObjects.Citizen;
using RoadCareService.Interaction.Domain.Model.Aggregates;
using RoadCareService.Publishing.Domain.Model.Aggregates;

namespace RoadCareService.IAM.Domain.Model.Aggregates
{
    public class Citizen
    {
        public int Id { get; private set; }
        public string? ProfileUrl { get; private set; }
        public string Firstname { get; private set; } = null!;
        public string Lastname { get; private set; } = null!;
        public int Age { get; private set; }
        public string Genre { get; private set; } = null!;
        public int Phone { get; private set; }
        public string Email { get; private set; } = null!;
        public string State { get; private set; } = null!;

        public virtual CitizenCredential? CitizenCredential { get; }

        public virtual ICollection<Comment> Comments { get; } = [];
        public virtual ICollection<Publication> Publications { get; } = [];

        public Citizen()
        {
            this.Id = 0;
            this.ProfileUrl = string.Empty;
            this.Firstname = string.Empty;
            this.Lastname = string.Empty;
            this.Age = 0;
            this.Genre = string.Empty;
            this.Phone = 0;
            this.Email = string.Empty;
            this.State = string.Empty;
        }
        public Citizen
            (int id, string? profileUrl,
            string firstname, string lastname,
            int age, string genre, int phone,
            string email, ECitizenState citizenState)
        {
            this.Id = id;
            this.ProfileUrl = profileUrl;
            this.Firstname = firstname.ToUpper();
            this.Lastname = lastname.ToUpper();
            this.Age = age;
            this.Genre = genre;
            this.Phone = phone;
            this.Email = email;
            this.State = citizenState.ToString();
        }
        public Citizen
            (RegisterCitizenCommand command)
        {
            this.Id = command.Id;
            this.ProfileUrl = command.ProfileUrl;
            this.Firstname = command.Firstname.ToUpper();
            this.Lastname = command.Lastname.ToUpper();
            this.Age = command.Age;
            this.Genre = command.Genre;
            this.Phone = command.Phone;
            this.Email = command.Email;
            this.State = command.CitizenState.ToString();
        }
    }
}