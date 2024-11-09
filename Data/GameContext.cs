using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using W10_assignment_template.Models;

namespace W10_assignment_template.Data;

public class GameContext : DbContext
{
    public DbSet<Room> Rooms { get; set; }
    public DbSet<Character> Characters { get; set; }
    public DbSet<Ability> Abilities { get; set; }


    public GameContext(DbContextOptions<GameContext> options) : base(options)
    {
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        //base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configure TPH for Character hierarchy
        modelBuilder.Entity<Character>()
            .HasDiscriminator<string>("Discriminator")
            .HasValue<Player>("Player")
            .HasValue<Goblin>("Goblin");

        // Configure many-to-many relationship between Character and Ability
        modelBuilder.Entity<Character>()
            .HasMany(c => c.Abilities)
            .WithMany(a => a.Characters)
            .UsingEntity(j => j.ToTable("CharacterAbilities"));

        modelBuilder.Entity<Ability>()
            .HasDiscriminator<string>("Discriminator")
            .HasValue<PlayerAbility>("PlayerAbility")
            .HasValue<GoblinAbility>("GoblinAbility");

        base.OnModelCreating(modelBuilder);
    }

//    // Seed Method
//    public void Seed()
//    {
//        if (!Rooms.Any())
//        {
//            var room1 = new Room { Name = "Entrance Hall", Description = "The main entry." };
//            var room2 = new Room { Name = "Treasure Room", Description = "A room filled with treasures." };
//
//            var character1 = new Player { Name = "Knight", Level = 1, Experience = 2};
//            var character2 = new Player { Name = "Wizard", Level = 2, Experience = 1};
//            var character3 = new Player { Name = "Boo", Level = 1, Experience = 1 };

//            Rooms.AddRange(room1, room2);
//            Characters.AddRange(character1, character2, character3);
//
//            SaveChanges();
//        }
//    }
}