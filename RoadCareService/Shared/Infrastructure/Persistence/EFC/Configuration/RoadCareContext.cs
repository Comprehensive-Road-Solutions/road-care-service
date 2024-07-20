using Microsoft.EntityFrameworkCore;
using RoadCareService.Assignment.Domain.Model.Aggregates;
using RoadCareService.Assignment.Domain.Model.Entities;
using RoadCareService.IAM.Domain.Model.Aggregates;
using RoadCareService.IAM.Domain.Model.Entities;
using RoadCareService.Interaction.Domain.Model.Aggregates;
using RoadCareService.Monitoring.Domain.Model.Aggregates;
using RoadCareService.Publishing.Domain.Model.Aggregates;
using RoadCareService.Publishing.Domain.Model.Entities;

namespace RoadCareService.Shared.Infrastructure.Persistence.EFC.Configuration
{
    public partial class RoadCareContext : DbContext
    {
        public RoadCareContext() { }
        public RoadCareContext(DbContextOptions<RoadCareContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AssignmentWorker>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("pk_assignment_worker_id");

                entity.ToTable("assignments_workers");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.FinalDate).HasColumnName("final_date");
                entity.Property(e => e.WorkersRolesId).HasColumnName("roles_id");
                entity.Property(e => e.StartDate).HasColumnName("start_date");
                entity.Property(e => e.State)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("state");
                entity.Property(e => e.WorkersId).HasColumnName("workers_id");

                entity.HasOne(d => d.Workers).WithMany(p => p.AssignmentsWorkers)
                    .HasForeignKey(d => d.WorkersId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_assignments_workers_workers_id");

                entity.HasOne(d => d.WorkersRoles).WithMany(p => p.AssignmentsWorkers)
                    .HasForeignKey(d => d.WorkersRolesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_assignments_workers_workers_roles_id");
            });

            modelBuilder.Entity<Citizen>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("pk_citizen_id");

                entity.ToTable("citizens");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");
                entity.Property(e => e.Age).HasColumnName("age");
                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("email");
                entity.Property(e => e.Firstname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("firstname");
                entity.Property(e => e.Genre)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("genre");
                entity.Property(e => e.Lastname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("lastname");
                entity.Property(e => e.Phone).HasColumnName("phone");
                entity.Property(e => e.ProfileUrl)
                    .IsUnicode(false)
                    .HasColumnName("profile_url");
                entity.Property(e => e.State)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("state");
            });

            modelBuilder.Entity<CitizenCredential>(entity =>
            {
                entity.HasKey(e => e.CitizensId).HasName("pk_citizen_credential_citizens_id");

                entity.ToTable("citizens_credentials");

                entity.Property(e => e.CitizensId)
                    .ValueGeneratedNever()
                    .HasColumnName("citizens_id");
                entity.Property(e => e.Code)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("code");

                entity.HasOne(d => d.Citizens).WithOne(p => p.CitizensCredential)
                    .HasForeignKey<CitizenCredential>(d => d.CitizensId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_citizens_credentials_citizens_id");
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("pk_comment_id");

                entity.ToTable("comments");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.CitizensId).HasColumnName("citizens_id");
                entity.Property(e => e.Opinion)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("opinion");
                entity.Property(e => e.PublicationsId).HasColumnName("publications_id");
                entity.Property(e => e.ShippingDate)
                    .HasColumnType("datetime")
                    .HasColumnName("shipping_date");
                entity.Property(e => e.State)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("state");

                entity.HasOne(d => d.Citizens).WithMany(p => p.Comments)
                    .HasForeignKey(d => d.CitizensId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_comments_citizens_id");

                entity.HasOne(d => d.Publications).WithMany(p => p.Comments)
                    .HasForeignKey(d => d.PublicationsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_comments_publications_id");
            });

            modelBuilder.Entity<DamagedInfrastructure>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("pk_damaged_infrastructure");

                entity.ToTable("damaged_infrastructures");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Address)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("address");
                entity.Property(e => e.Description)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("description");
                entity.Property(e => e.DistrictsId).HasColumnName("districts_id");
                entity.Property(e => e.RegistrationDate)
                    .HasColumnType("datetime")
                    .HasColumnName("registration_date");
                entity.Property(e => e.State)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("state");
                entity.Property(e => e.WorkDate)
                    .HasColumnType("datetime")
                    .HasColumnName("work_date");

                entity.HasOne(d => d.Districts).WithMany(p => p.DamagedInfrastructures)
                    .HasForeignKey(d => d.DistrictsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_damaged_infrastructures_districts_id");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("pk_department_id");

                entity.ToTable("departments");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<District>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("pk_district_id");

                entity.ToTable("districts");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.DepartmentsId).HasColumnName("departments_id");
                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.HasOne(d => d.Departments).WithMany(p => p.Districts)
                    .HasForeignKey(d => d.DepartmentsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_districts_departments_id");
            });

            modelBuilder.Entity<Evidence>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("pk_evidence_id");

                entity.ToTable("evidences");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.FileUrl)
                    .IsUnicode(false)
                    .HasColumnName("file_url");
                entity.Property(e => e.PublicationsId).HasColumnName("publications_id");

                entity.HasOne(d => d.Publications).WithMany(p => p.Evidences)
                    .HasForeignKey(d => d.PublicationsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_evidences_publications_id");
            });

            modelBuilder.Entity<GovernmentEntity>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("pk_government_entity_id");

                entity.ToTable("governments_entities");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Address)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("address");
                entity.Property(e => e.DistrictsId).HasColumnName("districts_id");
                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("email");
                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");
                entity.Property(e => e.Phone).HasColumnName("phone");
                entity.Property(e => e.Ruc)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("ruc");

                entity.HasOne(d => d.Districts).WithMany(p => p.GovernmentsEntities)
                    .HasForeignKey(d => d.DistrictsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fK_governments_entities_districts_id");
            });

            modelBuilder.Entity<Publication>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("pk_publication_id");

                entity.ToTable("publications");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.CitizensId).HasColumnName("citizens_id");
                entity.Property(e => e.Description)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("description");
                entity.Property(e => e.DistrictsId).HasColumnName("districts_id");
                entity.Property(e => e.PublicationDate)
                    .HasColumnType("datetime")
                    .HasColumnName("publication_date");
                entity.Property(e => e.State)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("state");
                entity.Property(e => e.Ubication)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("ubication");

                entity.HasOne(d => d.Citizens).WithMany(p => p.Publications)
                    .HasForeignKey(d => d.CitizensId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_publications_citizens_id");

                entity.HasOne(d => d.Districts).WithMany(p => p.Publications)
                    .HasForeignKey(d => d.DistrictsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_publications_districts_id");
            });

            modelBuilder.Entity<WorkerRole>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("pk_worker_role_id");

                entity.ToTable("workers_roles");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Name)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("name");
                entity.Property(e => e.State)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("state");
                entity.Property(e => e.WorkersAreasId).HasColumnName("workers_areas_id");

                entity.HasOne(d => d.WorkersAreas).WithMany(p => p.WorkersRoles)
                    .HasForeignKey(d => d.WorkersAreasId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_workers_roles_workers_areas_id");
            });

            modelBuilder.Entity<Staff>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("pk_staff_id");

                entity.ToTable("staff");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.DamagedInfrastructuresId).HasColumnName("damaged_infrastructures_id");
                entity.Property(e => e.State)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("state");
                entity.Property(e => e.WorkersId).HasColumnName("workers_id");

                entity.HasOne(d => d.DamagedInfrastructures).WithMany(p => p.Staff)
                    .HasForeignKey(d => d.DamagedInfrastructuresId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_staff_damaged_infrastructures_id");

                entity.HasOne(d => d.Workers).WithMany(p => p.Staff)
                    .HasForeignKey(d => d.WorkersId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_staff_workers_id");
            });

            modelBuilder.Entity<Worker>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("pk_worker_id");

                entity.ToTable("workers");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");
                entity.Property(e => e.Address)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("address");
                entity.Property(e => e.Age).HasColumnName("age");
                entity.Property(e => e.DistrictsId).HasColumnName("districts_id");
                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("email");
                entity.Property(e => e.Firstname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("firstname");
                entity.Property(e => e.Genre)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("genre");
                entity.Property(e => e.GovernmentsEntitiesId).HasColumnName("governments_entities_id");
                entity.Property(e => e.Lastname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("lastname");
                entity.Property(e => e.Phone).HasColumnName("phone");
                entity.Property(e => e.State)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("state");

                entity.HasOne(d => d.Districts).WithMany(p => p.Workers)
                    .HasForeignKey(d => d.DistrictsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_workers_districts_id");

                entity.HasOne(d => d.GovernmentsEntities).WithMany(p => p.Workers)
                    .HasForeignKey(d => d.GovernmentsEntitiesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_workers_governments_entities_id");
            });

            modelBuilder.Entity<WorkerArea>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("pk_worker_area_id");

                entity.ToTable("workers_areas");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.GovernmentsEntitiesId).HasColumnName("governments_entities_id");
                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");
                entity.Property(e => e.State)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("state");

                entity.HasOne(d => d.GovernmentsEntities).WithMany(p => p.WorkersAreas)
                    .HasForeignKey(d => d.GovernmentsEntitiesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_workers_areas_governments_entities_id");
            });

            modelBuilder.Entity<WorkerCredential>(entity =>
            {
                entity.HasKey(e => e.WorkersId).HasName("pk_worker_credential_workers_id");

                entity.ToTable("workers_credentials");

                entity.Property(e => e.WorkersId)
                    .ValueGeneratedNever()
                    .HasColumnName("workers_id");
                entity.Property(e => e.Code)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("code");

                entity.HasOne(d => d.Workers).WithOne(p => p.WorkersCredential)
                    .HasForeignKey<WorkerCredential>(d => d.WorkersId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_workers_credentials_workers_id");
            });

            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}