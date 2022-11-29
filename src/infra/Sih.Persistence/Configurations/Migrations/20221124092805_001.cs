using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sih.Persistence.Configurations.Migrations
{
    public partial class _001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NomPrenom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UsernameChangeLimit = table.Column<int>(type: "int", nullable: false),
                    ProfilePicture = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Avions",
                columns: table => new
                {
                    AvionEntityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Capacite = table.Column<int>(type: "int", nullable: false),
                    NumAvion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Avions", x => x.AvionEntityId);
                });

            migrationBuilder.CreateTable(
                name: "Encadreurs",
                columns: table => new
                {
                    EncadreurEntityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    POBirth = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DOBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PassportN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PassportDel = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PassportExp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Dtownn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nationality = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Encadreurs", x => x.EncadreurEntityId);
                });

            migrationBuilder.CreateTable(
                name: "Hadjs",
                columns: table => new
                {
                    HadjEntityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Edition = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Datedebut = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Datefin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Quota = table.Column<int>(type: "int", nullable: false),
                    Cout = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hadjs", x => x.HadjEntityId);
                });

            migrationBuilder.CreateTable(
                name: "PieceTypes",
                columns: table => new
                {
                    PiecesTypeEntityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Libelle = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PieceTypes", x => x.PiecesTypeEntityId);
                });

            migrationBuilder.CreateTable(
                name: "Regions",
                columns: table => new
                {
                    RegionEntityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodeReg = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NomReg = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regions", x => x.RegionEntityId);
                });

            migrationBuilder.CreateTable(
                name: "Usagers",
                columns: table => new
                {
                    UsagerEntityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    POBirth = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DOBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PassportN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PassportDel = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PassportExp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Townn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nationality = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usagers", x => x.UsagerEntityId);
                });

            migrationBuilder.CreateTable(
                name: "Voyages",
                columns: table => new
                {
                    VoyageEntityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VolEntityId = table.Column<int>(type: "int", nullable: false),
                    UsagerEntityId = table.Column<int>(type: "int", nullable: false),
                    Direction = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Datedepart = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Voyages", x => x.VoyageEntityId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Agreements",
                columns: table => new
                {
                    AgreementEntityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Datedebut = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Datefin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EncadreurEntityId = table.Column<int>(type: "int", nullable: false),
                    Numero = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    zone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agreements", x => x.AgreementEntityId);
                    table.ForeignKey(
                        name: "FK_Agreements_Encadreurs_EncadreurEntityId",
                        column: x => x.EncadreurEntityId,
                        principalTable: "Encadreurs",
                        principalColumn: "EncadreurEntityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Societes",
                columns: table => new
                {
                    SociteEntityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rsoc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Hqter = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EncadreurEntityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Societes", x => x.SociteEntityId);
                    table.ForeignKey(
                        name: "FK_Societes_Encadreurs_EncadreurEntityId",
                        column: x => x.EncadreurEntityId,
                        principalTable: "Encadreurs",
                        principalColumn: "EncadreurEntityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Villes",
                columns: table => new
                {
                    VilleEntityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomVille = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegionEntityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Villes", x => x.VilleEntityId);
                    table.ForeignKey(
                        name: "FK_Villes_Regions_RegionEntityId",
                        column: x => x.RegionEntityId,
                        principalTable: "Regions",
                        principalColumn: "RegionEntityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Inscriptions",
                columns: table => new
                {
                    InscriptionEntityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsagerEntityId = table.Column<int>(type: "int", nullable: false),
                    HadjEntityId = table.Column<int>(type: "int", nullable: false),
                    EncadreurEntityId = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Standing = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Etatpaiement = table.Column<int>(type: "int", nullable: false),
                    Etat = table.Column<int>(type: "int", nullable: false),
                    DateIns = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inscriptions", x => x.InscriptionEntityId);
                    table.ForeignKey(
                        name: "FK_Inscriptions_Encadreurs_EncadreurEntityId",
                        column: x => x.EncadreurEntityId,
                        principalTable: "Encadreurs",
                        principalColumn: "EncadreurEntityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inscriptions_Hadjs_HadjEntityId",
                        column: x => x.HadjEntityId,
                        principalTable: "Hadjs",
                        principalColumn: "HadjEntityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inscriptions_Usagers_UsagerEntityId",
                        column: x => x.UsagerEntityId,
                        principalTable: "Usagers",
                        principalColumn: "UsagerEntityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VillesDepart",
                columns: table => new
                {
                    DepartureTownEntityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsagerEntityId = table.Column<int>(type: "int", nullable: false),
                    HadjEntityId = table.Column<int>(type: "int", nullable: false),
                    VilleEntityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VillesDepart", x => x.DepartureTownEntityId);
                    table.ForeignKey(
                        name: "FK_VillesDepart_Villes_VilleEntityId",
                        column: x => x.VilleEntityId,
                        principalTable: "Villes",
                        principalColumn: "VilleEntityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vols",
                columns: table => new
                {
                    VolEntityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Numvol = table.Column<int>(type: "int", nullable: false),
                    VilleId = table.Column<int>(type: "int", nullable: false),
                    VilleDepartVilleEntityId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vols", x => x.VolEntityId);
                    table.ForeignKey(
                        name: "FK_Vols_Villes_VilleDepartVilleEntityId",
                        column: x => x.VilleDepartVilleEntityId,
                        principalTable: "Villes",
                        principalColumn: "VilleEntityId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Paiements",
                columns: table => new
                {
                    PaiementEntityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dateversement = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Montant = table.Column<int>(type: "int", nullable: false),
                    InscriptionEntityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paiements", x => x.PaiementEntityId);
                    table.ForeignKey(
                        name: "FK_Paiements_Inscriptions_InscriptionEntityId",
                        column: x => x.InscriptionEntityId,
                        principalTable: "Inscriptions",
                        principalColumn: "InscriptionEntityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PieceJointes",
                columns: table => new
                {
                    PieceJointesEntityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileContentType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileSize = table.Column<long>(type: "bigint", nullable: false),
                    FileNumerise = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Qualite = table.Column<bool>(type: "bit", nullable: false),
                    InscriptionEntityId = table.Column<int>(type: "int", nullable: false),
                    PiecesTypeEntityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PieceJointes", x => x.PieceJointesEntityId);
                    table.ForeignKey(
                        name: "FK_PieceJointes_Inscriptions_InscriptionEntityId",
                        column: x => x.InscriptionEntityId,
                        principalTable: "Inscriptions",
                        principalColumn: "InscriptionEntityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PieceJointes_PieceTypes_PiecesTypeEntityId",
                        column: x => x.PiecesTypeEntityId,
                        principalTable: "PieceTypes",
                        principalColumn: "PiecesTypeEntityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agreements_EncadreurEntityId",
                table: "Agreements",
                column: "EncadreurEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Inscriptions_EncadreurEntityId",
                table: "Inscriptions",
                column: "EncadreurEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Inscriptions_HadjEntityId",
                table: "Inscriptions",
                column: "HadjEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Inscriptions_UsagerEntityId",
                table: "Inscriptions",
                column: "UsagerEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Paiements_InscriptionEntityId",
                table: "Paiements",
                column: "InscriptionEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_PieceJointes_InscriptionEntityId",
                table: "PieceJointes",
                column: "InscriptionEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_PieceJointes_PiecesTypeEntityId",
                table: "PieceJointes",
                column: "PiecesTypeEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Societes_EncadreurEntityId",
                table: "Societes",
                column: "EncadreurEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Villes_RegionEntityId",
                table: "Villes",
                column: "RegionEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_VillesDepart_VilleEntityId",
                table: "VillesDepart",
                column: "VilleEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Vols_VilleDepartVilleEntityId",
                table: "Vols",
                column: "VilleDepartVilleEntityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Agreements");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Avions");

            migrationBuilder.DropTable(
                name: "Paiements");

            migrationBuilder.DropTable(
                name: "PieceJointes");

            migrationBuilder.DropTable(
                name: "Societes");

            migrationBuilder.DropTable(
                name: "VillesDepart");

            migrationBuilder.DropTable(
                name: "Vols");

            migrationBuilder.DropTable(
                name: "Voyages");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Inscriptions");

            migrationBuilder.DropTable(
                name: "PieceTypes");

            migrationBuilder.DropTable(
                name: "Villes");

            migrationBuilder.DropTable(
                name: "Encadreurs");

            migrationBuilder.DropTable(
                name: "Hadjs");

            migrationBuilder.DropTable(
                name: "Usagers");

            migrationBuilder.DropTable(
                name: "Regions");
        }
    }
}
