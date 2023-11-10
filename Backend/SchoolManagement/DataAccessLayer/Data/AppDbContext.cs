using Common.Constants;
using Common.Utils;
using Entities.Abstract;
using Entities.DataModels;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DataAccessLayer.Data
{
    public class AppDbContext : DbContext
    {
        #region Constructor

        private readonly IHttpContextAccessor _httpContextAccessor;
        public AppDbContext(DbContextOptions<AppDbContext> options, IHttpContextAccessor httpContextAccessor) : base(options)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        #endregion

        #region Methods
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            IEnumerable<EntityEntry> entries = ChangeTracker
                    .Entries()
                    .Where(e => (IsAuditableEntity(e.Entity.GetType())) &&
                        (e.State == EntityState.Added || e.State == EntityState.Modified));

            foreach (EntityEntry entityEntry in entries)
            {
                if (IsAuditableEntity(entityEntry.Entity.GetType()))
                {
                    dynamic? baseEntity = (dynamic)entityEntry.Entity;

                    long userId = GetUserId();

                    if (entityEntry.State == EntityState.Added)
                    {
                        baseEntity.CreatedOn = DateUtil.UtcNow;
                        baseEntity.CreatedBy = userId;
                    }
                    if (entityEntry.State == EntityState.Modified)
                    {
                        baseEntity.UpdatedOn = DateUtil.UtcNow;
                        baseEntity.UpdatedBy = userId;
                    }
                }
            }

            return await base.SaveChangesAsync(cancellationToken);
        }

        private long GetUserId()
        {
            System.Security.Claims.Claim? userIdClaim = _httpContextAccessor.HttpContext?.User.FindFirst("UserId");
            if (userIdClaim != null && long.TryParse(userIdClaim.Value, out long userId))
            {
                return userId;
            }
            return 1; // Default value if the claim is not present or not parseable
        }

        private static bool IsAuditableEntity(Type entityType)
        {
            Type? baseType = entityType.BaseType;
            while (baseType != null)
            {
                if (baseType.IsGenericType &&
                    baseType.GetGenericTypeDefinition() == typeof(AuditableEntity<>))
                {
                    return true;
                }
                baseType = baseType.BaseType;
            }
            return false;
        }

        #endregion

        #region DbSets

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<UserRole> UserRoles { get; set; }

        public virtual DbSet<Gender> Genders { get; set; }

        public virtual DbSet<BloodGroup> BloodGroups { get; set; }

        public virtual DbSet<AdmitRequest> AdmitRequests { get; set; }

        public virtual DbSet<AdmitRequestApproval> AdmitRequestsApproval { get; set;}

        public virtual DbSet<UserRefreshTokens> UserRefreshTokens { get; set; }

        #endregion

        #region Model_Builder

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.ToTable("userRole");
                entity.Property(e => e.Title).IsRequired().HasMaxLength(16);
            });

            modelBuilder.Entity<Gender>(entity =>
            {
                entity.ToTable("gender");
                entity.Property(e => e.Title).IsRequired().HasMaxLength(20);
            });

            modelBuilder.Entity<BloodGroup>(entity =>
            {
                entity.ToTable("bloodGroup");
                entity.Property(e => e.Title).IsRequired().HasMaxLength(10);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");
                entity.HasIndex(e => e.Email).IsUnique();
                entity.Property(e => e.FirstName).IsRequired().HasMaxLength(18);
                entity.Property(e => e.LastName).IsRequired().HasMaxLength(18);
                entity.Property(e => e.Email).IsRequired().HasMaxLength(32);
                entity.Property(e => e.Password).IsRequired().HasMaxLength(150);
                entity.Property(e => e.Headline).HasMaxLength(50);
                entity.Property(e => e.PhoneNumber).IsRequired().HasMaxLength(13);
                entity.Property(e => e.Address).IsRequired().HasMaxLength(1000);
                entity.Property(e => e.DateOfBirth).IsRequired();
                entity.Property(e => e.Role).IsRequired();
                entity.Property(e => e.Gender).IsRequired();
                entity.Property(e => e.Avatar).IsRequired();
                entity.Property(e => e.BloodGroup).IsRequired();
                entity.Property(e => e.IsUserActive).IsRequired().HasDefaultValue(true);
                entity.Property(e => e.IsUserDeleted).IsRequired().HasDefaultValue(false);

                entity.HasOne(u => u.Principal)
                    .WithMany()
                    .HasForeignKey(u => u.PrincipalId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(u => u.Teachers)
                    .WithMany()
                    .HasForeignKey(u => u.TeacherId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(u => u.LabUsers)
                    .WithMany()
                    .HasForeignKey(u => u.LabInstructorId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<AdmitRequest>(entity =>
            {
                entity.ToTable("admitRequest");
                entity.HasIndex(e => e.Email).IsUnique();
                entity.Property(e => e.FirstName).IsRequired().HasMaxLength(18);
                entity.Property(e => e.LastName).IsRequired().HasMaxLength(18);
                entity.Property(e => e.Email).IsRequired().HasMaxLength(32);
                entity.Property(e => e.PhoneNumber).IsRequired().HasMaxLength(13);
                entity.Property(e => e.Address).IsRequired().HasMaxLength(1000);
                entity.Property(e => e.DateOfBirth).IsRequired();
                entity.Property(e => e.Gender).IsRequired();
                entity.Property(e => e.Avatar).IsRequired();
                entity.Property(e => e.BloodGroup).IsRequired();
            });

            modelBuilder.Entity<AdmitRequestApproval>(entity =>
            {
                entity.ToTable("admitRequestApproval");
                entity.Property(e => e.AdmitRequestId).IsRequired();
                entity.Property(e => e.ApprovalStatus).IsRequired().HasDefaultValue(EntityStatusConstants.PENDING);
                entity.Property(e => e.Comment).HasMaxLength(512);
                entity.Property(e => e.ApprovedBy).IsRequired();
                entity.Property(e => e.DeclinedBy).IsRequired();

                entity.HasOne(u => u.ApprovedByUser)
                    .WithMany()
                    .HasForeignKey(u => u.ApprovedBy)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(u => u.DeclinedByUser)
                    .WithMany()
                    .HasForeignKey(u => u.DeclinedBy)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<UserRefreshTokens>(entity =>
            {
                entity.ToTable("userRefreshToken");
                entity.HasIndex(e => e.Id);
            });

            #region Seeders

            modelBuilder.Entity<Gender>().HasData(
                 new Gender { Id = 1, Title = "Male" },
                 new Gender { Id = 2, Title = "Female" },
                 new Gender { Id = 3, Title = "Other" }
            );

            modelBuilder.Entity<UserRole>().HasData(
                 new UserRole { Id = 1, Title = "Principal" },
                 new UserRole { Id = 2, Title = "Teacher" },
                 new UserRole { Id = 3, Title = "Student" },
                 new UserRole { Id = 4, Title = "LabInstructor" }
            );

            modelBuilder.Entity<BloodGroup>().HasData(
                 new BloodGroup { Id = 1, Title = "A+" },
                 new BloodGroup { Id = 2, Title = "A-" },
                 new BloodGroup { Id = 3, Title = "B+" },
                 new BloodGroup { Id = 4, Title = "B-" },
                 new BloodGroup { Id = 5, Title = "O+" },
                 new BloodGroup { Id = 6, Title = "O-" },
                 new BloodGroup { Id = 7, Title = "AB+" },
                 new BloodGroup { Id = 8, Title = "AB-" }
            );

            modelBuilder.Entity<User>().HasData(
                    new User { Id = 1, FirstName = "Anurag", LastName = "Patwardhan", Email = "anurag@gmail.com", Password = "$2a$10$KrAm5ughTCf8bUKjZlr.SeKmffzR7tzgwMQ9fdaVxCX5uktNo19D2", Headline = "Principal since 2010", PhoneNumber = "8957486525", Address = "St. Mary's School Top Floor, Besides Wockhardt Hospital", DateOfBirth = new DateTime(1976, 4, 12), Role = 1, Gender = 1, Avatar = "/images/Principal-photo.jpg", BloodGroup = 5, CreatedOn = DateTime.Now }
                );

            #endregion
        }

        #endregion


    }
}
