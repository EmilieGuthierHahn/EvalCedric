using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EvalCedric.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Breeds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Breeds", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Unicorns",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Habitat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Diet = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MagicalPowers = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Origin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BreedId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Unicorns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Unicorns_Breeds_BreedId",
                        column: x => x.BreedId,
                        principalTable: "Breeds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Breeds",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Leur corne pure peut réfracter la lumière lunaire en énergie curative.", "Corne de Cristal" },
                    { 2, "Leur crinière scintille avec la lumière d'étoiles lointaines. Ce sont de grands sages.", "Crinière d'Étoiles" },
                    { 3, "Leur robe est tachetée comme le soleil à travers les feuilles. Protecteurs des bois anciens.", "Gardien de la Forêt" },
                    { 4, "Vivent sur les côtes et peuvent galoper sur l'eau. Leur robe a la couleur de l'écume.", "Écume de Mer" },
                    { 5, "Insaisissables et mystérieux, ils voyagent à travers les ombres.", "Sauteur d'Ombre" },
                    { 6, "Leur robe est d'obsidienne et leur crinière crépite comme de la lave. Ils canalisent l'énergie géothermique.", "Volcanique" },
                    { 7, "Leur pelage ondoie avec les couleurs célestes. Gardiens des ciels nocturnes du nord.", "Aurore Boréale" },
                    { 8, "Leur robe a la couleur du sable doré. Ils invoquent des mirages pour dérouter les voyageurs.", "Murmure des Sables" },
                    { 9, "Robustes, leur peau ressemble à du granit. Gardiens des trésors de la terre.", "Cœur de Montagne" },
                    { 10, "Presque éthérés, leur corps devient translucide à la pleine lune.", "Spectre Lunaire" }
                });

            migrationBuilder.InsertData(
                table: "Unicorns",
                columns: new[] { "Id", "BreedId", "Color", "DateOfBirth", "Description", "Diet", "Habitat", "ImageUrl", "MagicalPowers", "Name", "Origin" },
                values: new object[,]
                {
                    { 1, 1, "Blanc perle", new DateTime(1524, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sa corne luit d'une douce lumière apaisante.", "Rosée du matin et fleurs de lune", "Clairières éclairées par la lune", "https://placehold.co/600x400/EAEAEA/333?text=Luminara", "Guérison par la lumière et purification", "Luminara", "Née d'un éclat de lune." },
                    { 2, 1, "Ivoire et or", new DateTime(1680, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sa corne capture l'énergie du soleil.", "Nectar de tournesol", "Plateaux ensoleillés", "https://placehold.co/600x400/FFF8DC/333?text=Solarius", "Rayons de lumière et chaleur bienfaisante", "Solarius", "Incarnation d'un rayon de soleil." },
                    { 3, 2, "Bleu nuit constellé", new DateTime(877, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "De nouvelles constellations naissent de sa crinière.", "Poussière de comète", "Sommets des montagnes", "https://placehold.co/600x400/000080/FFF?text=Céleste", "Navigation stellaire et prophéties", "Céleste", "Tissée à partir d'une nébuleuse." },
                    { 4, 2, "Argent et saphir", new DateTime(345, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Guide les voyageurs égarés.", "Échos du Big Bang", "Observatoires anciens", "https://placehold.co/600x400/708090/FFF?text=Orion", "Création de portails cosmiques", "Orion", "Gardien d'une étoile déchue." },
                    { 5, 3, "Vert mousse et or", new DateTime(1250, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sa robe change avec les saisons.", "Sève d'arbres anciens", "Forêts primordiales", "https://placehold.co/600x400/228B22/FFF?text=Veridian", "Communication avec la faune et la flore", "Veridian", "Esprit d'une forêt millénaire." },
                    { 6, 3, "Écorce de bouleau", new DateTime(1100, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Murmure les secrets des arbres.", "Feuilles de chêne argenté", "Bosquets sacrés", "https://placehold.co/600x400/D2B48C/333?text=Sylva", "Camouflage et guérison par les plantes", "Sylva", "Née de la première graine." },
                    { 7, 4, "Turquoise et blanc", new DateTime(1801, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Laisse une traînée de perles irisées.", "Plancton bioluminescent", "Récifs coralliens cachés", "https://placehold.co/600x400/40E0D0/333?text=Aquaria", "Contrôle des courants", "Aquaria", "Née du baiser de la lune sur l'océan." },
                    { 8, 4, "Bleu océan profond", new DateTime(1754, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Son galop sur l'eau annonce la marée haute.", "Sel enchanté", "Grottes sous-marines", "https://placehold.co/600x400/0000CD/FFF?text=Marinus", "Respiration aquatique et chant des sirènes", "Marinus", "Gardien d'une cité engloutie." },
                    { 9, 5, "Gris charbon", new DateTime(999, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "N'apparaît que lors de la nouvelle lune.", "Silence et secrets", "Ruines oubliées", "https://placehold.co/600x400/2F4F4F/FFF?text=Noctis", "Voyage dans les ombres et illusions", "Noctis", "Tissé à partir de la première nuit." },
                    { 10, 5, "Noir de jais", new DateTime(666, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Son passage refroidit l'air ambiant.", "Peur et doutes", "Carrefours des mondes", "https://placehold.co/600x400/000000/FFF?text=Umbra", "Invisibilité et manipulation des rêves", "Umbra", "Fragment d'éclipse." },
                    { 11, 6, "Noir obsidienne", new DateTime(432, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sa corne est un conduit de magma purifié.", "Soufre et minéraux rares", "Caldeiras de volcans", "https://placehold.co/600x400/1C0000/FF4500?text=Ignis", "Pyromancie et terraformation", "Ignis", "Né du cœur en fusion de la terre." },
                    { 12, 6, "Rouge et noir", new DateTime(121, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sa crinière est une rivière de lave.", "Roches en fusion", "Chambres magmatiques", "https://placehold.co/600x400/8B0000/FFD700?text=Magma", "Endurance au feu et forge d'artefacts", "Magma", "Gardien du noyau terrestre." },
                    { 13, 7, "Multicolore et changeant", new DateTime(1905, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Peint le ciel nocturne de son galop.", "Cristaux de glace et vent solaire", "Toundra arctique", "https://placehold.co/600x400/8A2BE2/FFF?text=Aurora", "Manipulation de la lumière et du froid", "Aurora", "Esprit du ciel polaire." },
                    { 14, 7, "Vert et rose pastel", new DateTime(1859, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Son chant ressemble au craquement du champ magnétique terrestre.", "Lumière des étoiles polaires", "Fjords gelés", "https://placehold.co/600x400/98FB98/FF69B4?text=Borealis", "Hypnose visuelle et bouclier d'énergie", "Borealis", "Reflet terrestre d'une galaxie lointaine." },
                    { 15, 8, "Sable doré", new DateTime(753, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Court plus vite que le vent du désert.", "Chaleur du soleil et cactus en fleurs", "Dunes infinies", "https://placehold.co/600x400/F4A460/333?text=Sirocco", "Création de tempêtes de sable et de mirages", "Sirocco", "Né d'une tempête de sable millénaire." },
                    { 16, 8, "Beige et turquoise", new DateTime(1337, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Trouve de l'eau là où il n'y en a pas.", "Dattes et eau pure", "Oasis cachées", "https://placehold.co/600x400/F5DEB3/40E0D0?text=Oasis", "Divination de l'eau et purification", "Oasis", "Gardienne de la dernière oasis primordiale." },
                    { 17, 9, "Gris tacheté de quartz", new DateTime(200, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Aussi solide et immuable que la montagne.", "Gemmes et métaux bruts", "Cavernes de cristal", "https://placehold.co/600x400/696969/EEE?text=Granit", "Force surhumaine et géomancie", "Granit", "Cœur vivant d'une montagne." },
                    { 18, 9, "Argent brillant", new DateTime(580, 11, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sa robe brille comme du métal poli.", "Or et platine", "Veines de métaux précieux", "https://placehold.co/600x400/C0C0C0/333?text=Mithril", "Invulnérabilité et détection des trésors", "Mithril", "Forgé par des nains anciens." },
                    { 19, 10, "Translucide et argenté", new DateTime(1485, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Traverse les murs les nuits de pleine lune.", "Lumière de lune et émotions résiduelles", "Cimetières anciens et plans astraux", "https://placehold.co/600x400/F5F5F5/333?text=Phasma", "Intangibilité et communication avec les esprits", "Phasma", "Écho d'un rêve." },
                    { 20, 10, "Blanc laiteux", new DateTime(1969, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "La plus proche de la lune elle-même.", "Vide spatial", "Sur la lune", "https://placehold.co/600x400/FFFFFF/333?text=Luna", "Contrôle de la gravité et voyage astral", "Luna", "Née sur la face cachée de la lune." }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Unicorns_BreedId",
                table: "Unicorns",
                column: "BreedId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Unicorns");

            migrationBuilder.DropTable(
                name: "Breeds");
        }
    }
}
