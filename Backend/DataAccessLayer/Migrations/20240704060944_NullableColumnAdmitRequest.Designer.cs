﻿// <auto-generated />
using System;
using DataAccessLayer.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DataAccessLayer.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240704060944_NullableColumnAdmitRequest")]
    partial class NullableColumnAdmitRequest
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Entities.DataModels.AdmitRequest", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)");

                    b.Property<byte>("AdmitRequestRoleId")
                        .HasColumnType("smallint");

                    b.Property<string>("Avatar")
                        .HasColumnType("text");

                    b.Property<byte>("BloodGroupId")
                        .HasColumnType("smallint");

                    b.Property<int?>("ClassId")
                        .HasColumnType("integer");

                    b.Property<long?>("CreatedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("character varying(32)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(18)
                        .HasColumnType("character varying(18)");

                    b.Property<byte>("GenderId")
                        .HasColumnType("smallint");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(18)
                        .HasColumnType("character varying(18)");

                    b.Property<byte?>("MediumId")
                        .HasColumnType("smallint");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("character varying(15)");

                    b.Property<long?>("UpdatedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("AdmitRequestRoleId");

                    b.HasIndex("BloodGroupId");

                    b.HasIndex("ClassId");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("GenderId");

                    b.HasIndex("MediumId");

                    b.HasIndex("UpdatedBy");

                    b.ToTable("AdmitRequests", (string)null);
                });

            modelBuilder.Entity("Entities.DataModels.AdmitRequestApproval", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("AdmitRequestId")
                        .HasColumnType("bigint");

                    b.Property<byte>("ApprovalStatus")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint")
                        .HasDefaultValue((byte)1);

                    b.Property<long?>("ApprovedBy")
                        .HasColumnType("bigint");

                    b.Property<string>("Comment")
                        .HasMaxLength(512)
                        .HasColumnType("character varying(512)");

                    b.Property<long?>("DeclinedBy")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("AdmitRequestId");

                    b.HasIndex("ApprovedBy");

                    b.HasIndex("DeclinedBy");

                    b.ToTable("AdmitRequestApprovals", (string)null);
                });

            modelBuilder.Entity("Entities.DataModels.BloodGroup", b =>
                {
                    b.Property<byte>("Id")
                        .HasColumnType("smallint");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)");

                    b.HasKey("Id");

                    b.ToTable("BloodGroups", (string)null);

                    b.HasData(
                        new
                        {
                            Id = (byte)1,
                            Title = "A+"
                        },
                        new
                        {
                            Id = (byte)2,
                            Title = "A-"
                        },
                        new
                        {
                            Id = (byte)3,
                            Title = "B+"
                        },
                        new
                        {
                            Id = (byte)4,
                            Title = "B-"
                        },
                        new
                        {
                            Id = (byte)5,
                            Title = "O+"
                        },
                        new
                        {
                            Id = (byte)6,
                            Title = "O-"
                        },
                        new
                        {
                            Id = (byte)7,
                            Title = "AB+"
                        },
                        new
                        {
                            Id = (byte)8,
                            Title = "AB-"
                        });
                });

            modelBuilder.Entity("Entities.DataModels.Class", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClassName")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("character varying(12)");

                    b.Property<int?>("ClassStrength")
                        .HasColumnType("integer");

                    b.Property<long?>("ClassTeacherId")
                        .HasColumnType("bigint");

                    b.Property<long?>("CreatedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long?>("UpdatedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("ClassTeacherId");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("UpdatedBy");

                    b.ToTable("Classes", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ClassName = "Class-11",
                            ClassStrength = 60,
                            CreatedOn = new DateTime(2024, 7, 4, 6, 9, 41, 472, DateTimeKind.Utc).AddTicks(4410),
                            UpdatedOn = new DateTime(2024, 7, 4, 6, 9, 41, 472, DateTimeKind.Utc).AddTicks(4410)
                        },
                        new
                        {
                            Id = 2,
                            ClassName = "Class-12",
                            ClassStrength = 120,
                            CreatedOn = new DateTime(2024, 7, 4, 6, 9, 41, 472, DateTimeKind.Utc).AddTicks(4410),
                            UpdatedOn = new DateTime(2024, 7, 4, 6, 9, 41, 472, DateTimeKind.Utc).AddTicks(4410)
                        });
                });

            modelBuilder.Entity("Entities.DataModels.Gender", b =>
                {
                    b.Property<byte>("Id")
                        .HasColumnType("smallint");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.HasKey("Id");

                    b.ToTable("Genders", (string)null);

                    b.HasData(
                        new
                        {
                            Id = (byte)1,
                            Title = "Male"
                        },
                        new
                        {
                            Id = (byte)2,
                            Title = "Female"
                        });
                });

            modelBuilder.Entity("Entities.DataModels.Medium", b =>
                {
                    b.Property<byte>("Id")
                        .HasColumnType("smallint");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)");

                    b.HasKey("Id");

                    b.ToTable("Mediums", (string)null);

                    b.HasData(
                        new
                        {
                            Id = (byte)1,
                            Title = "English"
                        },
                        new
                        {
                            Id = (byte)2,
                            Title = "Hindi"
                        },
                        new
                        {
                            Id = (byte)3,
                            Title = "Gujarati"
                        });
                });

            modelBuilder.Entity("Entities.DataModels.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ClassId")
                        .HasColumnType("integer");

                    b.Property<long?>("CreatedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<byte>("MediumId")
                        .HasColumnType("smallint");

                    b.Property<string>("StudentName")
                        .IsRequired()
                        .HasMaxLength(18)
                        .HasColumnType("character varying(18)");

                    b.Property<long?>("UpdatedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("ClassId");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("MediumId");

                    b.HasIndex("UpdatedBy");

                    b.ToTable("Students", (string)null);
                });

            modelBuilder.Entity("Entities.DataModels.Subject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<long?>("CreatedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("SubjectName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<long?>("SubjectTeacherId")
                        .HasColumnType("bigint");

                    b.Property<long?>("UpdatedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("SubjectTeacherId");

                    b.HasIndex("UpdatedBy");

                    b.ToTable("Subjects", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedOn = new DateTime(2024, 7, 4, 6, 9, 41, 472, DateTimeKind.Utc).AddTicks(4410),
                            SubjectName = "Physics",
                            UpdatedOn = new DateTime(2024, 7, 4, 6, 9, 41, 472, DateTimeKind.Utc).AddTicks(4410)
                        },
                        new
                        {
                            Id = 2,
                            CreatedOn = new DateTime(2024, 7, 4, 6, 9, 41, 472, DateTimeKind.Utc).AddTicks(4410),
                            SubjectName = "Chemistry",
                            UpdatedOn = new DateTime(2024, 7, 4, 6, 9, 41, 472, DateTimeKind.Utc).AddTicks(4410)
                        },
                        new
                        {
                            Id = 3,
                            CreatedOn = new DateTime(2024, 7, 4, 6, 9, 41, 472, DateTimeKind.Utc).AddTicks(4410),
                            SubjectName = "Biology",
                            UpdatedOn = new DateTime(2024, 7, 4, 6, 9, 41, 472, DateTimeKind.Utc).AddTicks(4410)
                        },
                        new
                        {
                            Id = 4,
                            CreatedOn = new DateTime(2024, 7, 4, 6, 9, 41, 472, DateTimeKind.Utc).AddTicks(4410),
                            SubjectName = "Maths",
                            UpdatedOn = new DateTime(2024, 7, 4, 6, 9, 41, 472, DateTimeKind.Utc).AddTicks(4410)
                        },
                        new
                        {
                            Id = 5,
                            CreatedOn = new DateTime(2024, 7, 4, 6, 9, 41, 472, DateTimeKind.Utc).AddTicks(4410),
                            SubjectName = "Physics Practical",
                            UpdatedOn = new DateTime(2024, 7, 4, 6, 9, 41, 472, DateTimeKind.Utc).AddTicks(4410)
                        },
                        new
                        {
                            Id = 6,
                            CreatedOn = new DateTime(2024, 7, 4, 6, 9, 41, 472, DateTimeKind.Utc).AddTicks(4410),
                            SubjectName = "Chemistry Practical",
                            UpdatedOn = new DateTime(2024, 7, 4, 6, 9, 41, 472, DateTimeKind.Utc).AddTicks(4410)
                        });
                });

            modelBuilder.Entity("Entities.DataModels.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)");

                    b.Property<string>("Avatar")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<byte>("BloodGroupId")
                        .HasColumnType("smallint");

                    b.Property<long?>("CreatedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long?>("DeletedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("character varying(32)");

                    b.Property<DateTime?>("ExpiryTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(18)
                        .HasColumnType("character varying(18)");

                    b.Property<byte>("GenderId")
                        .HasColumnType("smallint");

                    b.Property<string>("Headline")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<bool>("IsUserActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(true);

                    b.Property<bool>("IsUserDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false);

                    b.Property<long?>("LabInstructorId")
                        .HasColumnType("bigint");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(18)
                        .HasColumnType("character varying(18)");

                    b.Property<string>("OTP")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("character varying(13)");

                    b.Property<long?>("PrincipalId")
                        .HasColumnType("bigint");

                    b.Property<byte>("RoleId")
                        .HasColumnType("smallint");

                    b.Property<long?>("SuspendedBy")
                        .HasColumnType("bigint");

                    b.Property<int?>("SuspendedDuration")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("SuspendedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long?>("TeacherId")
                        .HasColumnType("bigint");

                    b.Property<long?>("UpdatedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("BloodGroupId");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("DeletedBy");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("GenderId");

                    b.HasIndex("LabInstructorId");

                    b.HasIndex("PrincipalId");

                    b.HasIndex("RoleId");

                    b.HasIndex("SuspendedBy");

                    b.HasIndex("TeacherId");

                    b.HasIndex("UpdatedBy");

                    b.ToTable("Users", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Address = "St. Mary's School Top Floor, Besides Wockhardt Hospital",
                            Avatar = "/images/Principal-photo.jpg",
                            BloodGroupId = (byte)5,
                            CreatedOn = new DateTime(2024, 7, 4, 6, 9, 41, 958, DateTimeKind.Utc).AddTicks(9957),
                            Email = "anurag@gmail.com",
                            FirstName = "Anurag",
                            GenderId = (byte)1,
                            Headline = "Principal since 2010",
                            IsUserActive = false,
                            IsUserDeleted = false,
                            LastName = "Patwardhan",
                            Password = "$2a$10$KrAm5ughTCf8bUKjZlr.SeKmffzR7tzgwMQ9fdaVxCX5uktNo19D2",
                            PhoneNumber = "8957486525",
                            RoleId = (byte)1,
                            UpdatedOn = new DateTime(2024, 7, 4, 6, 9, 41, 472, DateTimeKind.Utc).AddTicks(4410)
                        });
                });

            modelBuilder.Entity("Entities.DataModels.UserRole", b =>
                {
                    b.Property<byte>("Id")
                        .HasColumnType("smallint");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("character varying(16)");

                    b.HasKey("Id");

                    b.ToTable("UserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = (byte)1,
                            Title = "Principal"
                        },
                        new
                        {
                            Id = (byte)2,
                            Title = "Teacher"
                        },
                        new
                        {
                            Id = (byte)3,
                            Title = "Student"
                        },
                        new
                        {
                            Id = (byte)4,
                            Title = "Lab Instructor"
                        });
                });

            modelBuilder.Entity("Entities.DataModels.AdmitRequest", b =>
                {
                    b.HasOne("Entities.DataModels.UserRole", "AdmitRequestRoles")
                        .WithMany()
                        .HasForeignKey("AdmitRequestRoleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Entities.DataModels.BloodGroup", "BloodGroups")
                        .WithMany()
                        .HasForeignKey("BloodGroupId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Entities.DataModels.Class", "Classes")
                        .WithMany()
                        .HasForeignKey("ClassId");

                    b.HasOne("Entities.DataModels.User", "CreatedByUser")
                        .WithMany()
                        .HasForeignKey("CreatedBy")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Entities.DataModels.Gender", "Genders")
                        .WithMany()
                        .HasForeignKey("GenderId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Entities.DataModels.Medium", "Mediums")
                        .WithMany()
                        .HasForeignKey("MediumId");

                    b.HasOne("Entities.DataModels.User", "UpdatedByUser")
                        .WithMany()
                        .HasForeignKey("UpdatedBy")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("AdmitRequestRoles");

                    b.Navigation("BloodGroups");

                    b.Navigation("Classes");

                    b.Navigation("CreatedByUser");

                    b.Navigation("Genders");

                    b.Navigation("Mediums");

                    b.Navigation("UpdatedByUser");
                });

            modelBuilder.Entity("Entities.DataModels.AdmitRequestApproval", b =>
                {
                    b.HasOne("Entities.DataModels.AdmitRequest", "AdmitRequests")
                        .WithMany()
                        .HasForeignKey("AdmitRequestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.DataModels.User", "ApprovedByUser")
                        .WithMany()
                        .HasForeignKey("ApprovedBy")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Entities.DataModels.User", "DeclinedByUser")
                        .WithMany()
                        .HasForeignKey("DeclinedBy")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("AdmitRequests");

                    b.Navigation("ApprovedByUser");

                    b.Navigation("DeclinedByUser");
                });

            modelBuilder.Entity("Entities.DataModels.Class", b =>
                {
                    b.HasOne("Entities.DataModels.User", "ClassTeachers")
                        .WithMany()
                        .HasForeignKey("ClassTeacherId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Entities.DataModels.User", "CreatedByUser")
                        .WithMany()
                        .HasForeignKey("CreatedBy")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Entities.DataModels.User", "UpdatedByUser")
                        .WithMany()
                        .HasForeignKey("UpdatedBy")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("ClassTeachers");

                    b.Navigation("CreatedByUser");

                    b.Navigation("UpdatedByUser");
                });

            modelBuilder.Entity("Entities.DataModels.Student", b =>
                {
                    b.HasOne("Entities.DataModels.Class", "Classes")
                        .WithMany()
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Entities.DataModels.User", "CreatedByUser")
                        .WithMany()
                        .HasForeignKey("CreatedBy")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Entities.DataModels.Medium", "Mediums")
                        .WithMany()
                        .HasForeignKey("MediumId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Entities.DataModels.User", "UpdatedByUser")
                        .WithMany()
                        .HasForeignKey("UpdatedBy")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Classes");

                    b.Navigation("CreatedByUser");

                    b.Navigation("Mediums");

                    b.Navigation("UpdatedByUser");
                });

            modelBuilder.Entity("Entities.DataModels.Subject", b =>
                {
                    b.HasOne("Entities.DataModels.User", "CreatedByUser")
                        .WithMany()
                        .HasForeignKey("CreatedBy")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Entities.DataModels.User", "SubjectTeacher")
                        .WithMany()
                        .HasForeignKey("SubjectTeacherId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Entities.DataModels.User", "UpdatedByUser")
                        .WithMany()
                        .HasForeignKey("UpdatedBy")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("CreatedByUser");

                    b.Navigation("SubjectTeacher");

                    b.Navigation("UpdatedByUser");
                });

            modelBuilder.Entity("Entities.DataModels.User", b =>
                {
                    b.HasOne("Entities.DataModels.BloodGroup", "BloodGroups")
                        .WithMany()
                        .HasForeignKey("BloodGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.DataModels.User", "CreatedByUser")
                        .WithMany()
                        .HasForeignKey("CreatedBy");

                    b.HasOne("Entities.DataModels.User", "DeletedByUser")
                        .WithMany()
                        .HasForeignKey("DeletedBy");

                    b.HasOne("Entities.DataModels.Gender", "Genders")
                        .WithMany()
                        .HasForeignKey("GenderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.DataModels.User", "LabUsers")
                        .WithMany()
                        .HasForeignKey("LabInstructorId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Entities.DataModels.User", "Principal")
                        .WithMany()
                        .HasForeignKey("PrincipalId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Entities.DataModels.UserRole", "UserRoles")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.DataModels.User", "SuspendedByUser")
                        .WithMany()
                        .HasForeignKey("SuspendedBy");

                    b.HasOne("Entities.DataModels.User", "Teachers")
                        .WithMany()
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Entities.DataModels.User", "UpdatedByUser")
                        .WithMany()
                        .HasForeignKey("UpdatedBy");

                    b.Navigation("BloodGroups");

                    b.Navigation("CreatedByUser");

                    b.Navigation("DeletedByUser");

                    b.Navigation("Genders");

                    b.Navigation("LabUsers");

                    b.Navigation("Principal");

                    b.Navigation("SuspendedByUser");

                    b.Navigation("Teachers");

                    b.Navigation("UpdatedByUser");

                    b.Navigation("UserRoles");
                });
#pragma warning restore 612, 618
        }
    }
}
