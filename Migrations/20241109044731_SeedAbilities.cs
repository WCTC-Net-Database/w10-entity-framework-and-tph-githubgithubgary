using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace W10_assignment_template.Migrations
{
    public partial class SeedAbilities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Enable identity insert for Abilities
            migrationBuilder.Sql("SET IDENTITY_INSERT Abilities ON");

            // Insert Abilities
            migrationBuilder.Sql("INSERT INTO Abilities (Id, Name, Description, CharacterId, Discriminator, Taunt, Shove) VALUES (1, 'Scream', 'Scream', 1, 'GoblinAbility', 1, 0)");
            migrationBuilder.Sql("INSERT INTO Abilities (Id, Name, Description, CharacterId, Discriminator, Taunt, Shove) VALUES (2, 'Moan', 'Moan', 2, 'GoblinAbility', 1, 0)");
            migrationBuilder.Sql("INSERT INTO Abilities (Id, Name, Description, CharacterId, Discriminator, Taunt, Shove) VALUES (3, 'Run', 'Runs fast', 3, 'PlayerAbility', 0, 1)");
            migrationBuilder.Sql("INSERT INTO Abilities (Id, Name, Description, CharacterId, Discriminator, Taunt, Shove) VALUES (4, 'Push', 'Push', 4, 'PlayerAbility', 0, 1)");

//            // Enable identity insert for Character Abilities
//            migrationBuilder.Sql("SET IDENTITY_INSERT CharacterAbilities ON");

            // Insert CharacterAbilities
            migrationBuilder.Sql("INSERT INTO CharacterAbilities (AbilitiesId, CharactersId) VALUES (1, 1)");
            migrationBuilder.Sql("INSERT INTO CharacterAbilities (AbilitiesId, CharactersId) VALUES (1, 2)");
            migrationBuilder.Sql("INSERT INTO CharacterAbilities (AbilitiesId, CharactersId) VALUES (2, 2)");
            migrationBuilder.Sql("INSERT INTO CharacterAbilities (AbilitiesId, CharactersId) VALUES (4, 3)");
            migrationBuilder.Sql("INSERT INTO CharacterAbilities (AbilitiesId, CharactersId) VALUES (3, 4)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
