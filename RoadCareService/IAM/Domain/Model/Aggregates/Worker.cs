﻿using RoadCareService.Assignment.Domain.Model.Aggregates;
using RoadCareService.IAM.Domain.Model.Commands.Worker;
using RoadCareService.IAM.Domain.Model.Entities;
using RoadCareService.IAM.Domain.Model.ValueObjects.Worker;
using RoadCareService.Location.Domain.Model.Aggregates;
using RoadCareService.Monitoring.Domain.Model.Aggregates;

namespace RoadCareService.IAM.Domain.Model.Aggregates
{
    public class Worker
    {
        public int Id { get; private set; }
        public int DistrictsId { get; private set; }
        public int GovernmentsEntitiesId { get; private set; }
        public string Firstname { get; private set; } = null!;
        public string Lastname { get; private set; } = null!;
        public int Age { get; private set; }
        public string Genre { get; private set; } = null!;
        public int Phone { get; private set; }
        public string Email { get; private set; } = null!;
        public string Address { get; private set; } = null!;
        public string State { get; private set; } = null!;

        public virtual District District { get; } = null!;
        public virtual GovernmentEntity GovernmentEntity { get; } = null!;
        public virtual WorkerCredential? WorkerCredential { get; }

        public virtual ICollection<AssignmentWorker> AssignmentsWorkers { get; } = [];
        public virtual ICollection<Staff> Staff { get; } = [];

        public Worker()
        {
            this.Id = 0;
            this.DistrictsId = 0;
            this.GovernmentsEntitiesId = 0;
            this.Firstname = string.Empty;
            this.Lastname = string.Empty;
            this.Age = 0;
            this.Genre = string.Empty;
            this.Phone = 0;
            this.Email = string.Empty;
            this.Address = string.Empty;
            this.State = string.Empty;
        }
        public Worker
            (int id, int districtId, int governmentEntityId,
            string firstname, string lastname, int age,
            string genre, int phone, string email,
            string address, EWorkerState workerState)
        {
            this.Id = id;
            this.DistrictsId = districtId;
            this.GovernmentsEntitiesId = governmentEntityId;
            this.Firstname = firstname.ToUpper();
            this.Lastname = lastname.ToUpper();
            this.Age = age;
            this.Genre = genre;
            this.Phone = phone;
            this.Email = email;
            this.Address = address.ToUpper();
            this.State = workerState.ToString();
        }
        public Worker
            (RegisterWorkerCommand command)
        {
            this.Id = command.Id;
            this.DistrictsId = command.DistrictId;
            this.GovernmentsEntitiesId = command.GovernmentEntityId;
            this.Firstname = command.Firstname.ToUpper();
            this.Lastname = command.Lastname.ToUpper();
            this.Age = command.Age;
            this.Genre = command.Genre;
            this.Phone = command.Phone;
            this.Email = command.Email;
            this.Address = command.Address.ToUpper();
            this.State = command.WorkerState.ToString();
        }
    }
}