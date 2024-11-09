﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using W10_assignment_template.Data;

#nullable disable

namespace W10_assignment_template.Migrations
{
    [DbContext(typeof(GameContext))]
    partial class GameContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.35")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AbilityCharacter", b =>
                {
                    b.Property<int>("AbilitiesId")
                        .HasColumnType("int");

                    b.Property<int>("CharactersId")
                        .HasColumnType("int");

                    b.HasKey("AbilitiesId", "CharactersId");

                    b.HasIndex("CharactersId");

                    b.ToTable("CharacterAbilities", (string)null);
                });

            modelBuilder.Entity("W10_assignment_template.Models.Ability", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CharacterId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Abilities");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Ability");
                });

            modelBuilder.Entity("W10_assignment_template.Models.Character", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoomId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoomId");

                    b.ToTable("Characters");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Character");
                });

            modelBuilder.Entity("W10_assignment_template.Models.Room", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("W10_assignment_template.Models.Goblin", b =>
                {
                    b.HasBaseType("W10_assignment_template.Models.Character");

                    b.Property<int>("AggressionLevel")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("Goblin");
                });

            modelBuilder.Entity("W10_assignment_template.Models.GoblinAbility", b =>
                {
                    b.HasBaseType("W10_assignment_template.Models.Ability");

                    b.Property<int>("Taunt")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("GoblinAbility");
                });

            modelBuilder.Entity("W10_assignment_template.Models.Player", b =>
                {
                    b.HasBaseType("W10_assignment_template.Models.Character");

                    b.Property<int>("Experience")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("Player");
                });

            modelBuilder.Entity("W10_assignment_template.Models.PlayerAbility", b =>
                {
                    b.HasBaseType("W10_assignment_template.Models.Ability");

                    b.Property<int>("Shove")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("PlayerAbility");
                });

            modelBuilder.Entity("AbilityCharacter", b =>
                {
                    b.HasOne("W10_assignment_template.Models.Ability", null)
                        .WithMany()
                        .HasForeignKey("AbilitiesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("W10_assignment_template.Models.Character", null)
                        .WithMany()
                        .HasForeignKey("CharactersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("W10_assignment_template.Models.Character", b =>
                {
                    b.HasOne("W10_assignment_template.Models.Room", "Room")
                        .WithMany("Characters")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Room");
                });

            modelBuilder.Entity("W10_assignment_template.Models.Room", b =>
                {
                    b.Navigation("Characters");
                });
#pragma warning restore 612, 618
        }
    }
}
