using EvalCedric.Models;
using Microsoft.EntityFrameworkCore;

namespace EvalCedric.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Breed> Breeds { get; set; }
        public DbSet<Unicorn> Unicorns { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
          var breeds = new List<Breed>
            {
              new Breed { Id = 1, Name = "Corne de Cristal", Description = "Leur corne pure peut réfracter la lumière lunaire en énergie curative." },
                new Breed { Id = 2, Name = "Crinière d'Étoiles", Description = "Leur crinière scintille avec la lumière d'étoiles lointaines. Ce sont de grands sages." },
                new Breed { Id = 3, Name = "Gardien de la Forêt", Description = "Leur robe est tachetée comme le soleil à travers les feuilles. Protecteurs des bois anciens." },
                new Breed { Id = 4, Name = "Écume de Mer", Description = "Vivent sur les côtes et peuvent galoper sur l'eau. Leur robe a la couleur de l'écume." },
                new Breed { Id = 5, Name = "Sauteur d'Ombre", Description = "Insaisissables et mystérieux, ils voyagent à travers les ombres." },
                new Breed { Id = 6, Name = "Volcanique", Description = "Leur robe est d'obsidienne et leur crinière crépite comme de la lave. Ils canalisent l'énergie géothermique." },
                new Breed { Id = 7, Name = "Aurore Boréale", Description = "Leur pelage ondoie avec les couleurs célestes. Gardiens des ciels nocturnes du nord." },
                new Breed { Id = 8, Name = "Murmure des Sables", Description = "Leur robe a la couleur du sable doré. Ils invoquent des mirages pour dérouter les voyageurs." },
                new Breed { Id = 9, Name = "Cœur de Montagne", Description = "Robustes, leur peau ressemble à du granit. Gardiens des trésors de la terre." },
                new Breed { Id = 10, Name = "Spectre Lunaire", Description = "Presque éthérés, leur corps devient translucide à la pleine lune." }
            };
            modelBuilder.Entity<Breed>().HasData(breeds);

            modelBuilder.Entity<Unicorn>().HasData(
                new { Id = 1, Name = "Luminara", Description = "Sa corne luit d'une douce lumière apaisante.", BreedId = 1, Color = "Blanc perle", ImageUrl = "https://placehold.co/600x400/EAEAEA/333?text=Luminara", Habitat = "Clairières éclairées par la lune", Diet = "Rosée du matin et fleurs de lune", MagicalPowers = "Guérison par la lumière et purification", Origin = "Née d'un éclat de lune.", DateOfBirth = new DateTime(1524, 5, 20) },
                new { Id = 2, Name = "Solarius", Description = "Sa corne capture l'énergie du soleil.", BreedId = 1, Color = "Ivoire et or", ImageUrl = "https://placehold.co/600x400/FFF8DC/333?text=Solarius", Habitat = "Plateaux ensoleillés", Diet = "Nectar de tournesol", MagicalPowers = "Rayons de lumière et chaleur bienfaisante", Origin = "Incarnation d'un rayon de soleil.", DateOfBirth = new DateTime(1680, 7, 10) },
                // -- Crinière d'Étoiles (BreedId = 2)
                new { Id = 3, Name = "Céleste", Description = "De nouvelles constellations naissent de sa crinière.", BreedId = 2, Color = "Bleu nuit constellé", ImageUrl = "https://placehold.co/600x400/000080/FFF?text=Céleste", Habitat = "Sommets des montagnes", Diet = "Poussière de comète", MagicalPowers = "Navigation stellaire et prophéties", Origin = "Tissée à partir d'une nébuleuse.", DateOfBirth = new DateTime(877, 11, 12) },
                new { Id = 4, Name = "Orion", Description = "Guide les voyageurs égarés.", BreedId = 2, Color = "Argent et saphir", ImageUrl = "https://placehold.co/600x400/708090/FFF?text=Orion", Habitat = "Observatoires anciens", Diet = "Échos du Big Bang", MagicalPowers = "Création de portails cosmiques", Origin = "Gardien d'une étoile déchue.", DateOfBirth = new DateTime(345, 1, 30) },
                // -- Gardien de la Forêt (BreedId = 3)
                new { Id = 5, Name = "Veridian", Description = "Sa robe change avec les saisons.", BreedId = 3, Color = "Vert mousse et or", ImageUrl = "https://placehold.co/600x400/228B22/FFF?text=Veridian", Habitat = "Forêts primordiales", Diet = "Sève d'arbres anciens", MagicalPowers = "Communication avec la faune et la flore", Origin = "Esprit d'une forêt millénaire.", DateOfBirth = new DateTime(1250, 8, 1) },
                new { Id = 6, Name = "Sylva", Description = "Murmure les secrets des arbres.", BreedId = 3, Color = "Écorce de bouleau", ImageUrl = "https://placehold.co/600x400/D2B48C/333?text=Sylva", Habitat = "Bosquets sacrés", Diet = "Feuilles de chêne argenté", MagicalPowers = "Camouflage et guérison par les plantes", Origin = "Née de la première graine.", DateOfBirth = new DateTime(1100, 4, 22) },
                // -- Écume de Mer (BreedId = 4)
                new { Id = 7, Name = "Aquaria", Description = "Laisse une traînée de perles irisées.", BreedId = 4, Color = "Turquoise et blanc", ImageUrl = "https://placehold.co/600x400/40E0D0/333?text=Aquaria", Habitat = "Récifs coralliens cachés", Diet = "Plancton bioluminescent", MagicalPowers = "Contrôle des courants", Origin = "Née du baiser de la lune sur l'océan.", DateOfBirth = new DateTime(1801, 7, 15) },
                new { Id = 8, Name = "Marinus", Description = "Son galop sur l'eau annonce la marée haute.", BreedId = 4, Color = "Bleu océan profond", ImageUrl = "https://placehold.co/600x400/0000CD/FFF?text=Marinus", Habitat = "Grottes sous-marines", Diet = "Sel enchanté", MagicalPowers = "Respiration aquatique et chant des sirènes", Origin = "Gardien d'une cité engloutie.", DateOfBirth = new DateTime(1754, 9, 3) },
                // -- Sauteur d'Ombre (BreedId = 5)
                new { Id = 9, Name = "Noctis", Description = "N'apparaît que lors de la nouvelle lune.", BreedId = 5, Color = "Gris charbon", ImageUrl = "https://placehold.co/600x400/2F4F4F/FFF?text=Noctis", Habitat = "Ruines oubliées", Diet = "Silence et secrets", MagicalPowers = "Voyage dans les ombres et illusions", Origin = "Tissé à partir de la première nuit.", DateOfBirth = new DateTime(999, 12, 31) },
                new { Id = 10, Name = "Umbra", Description = "Son passage refroidit l'air ambiant.", BreedId = 5, Color = "Noir de jais", ImageUrl = "https://placehold.co/600x400/000000/FFF?text=Umbra", Habitat = "Carrefours des mondes", Diet = "Peur et doutes", MagicalPowers = "Invisibilité et manipulation des rêves", Origin = "Fragment d'éclipse.", DateOfBirth = new DateTime(666, 6, 6) },
                // -- Volcanique (BreedId = 6)
                new { Id = 11, Name = "Ignis", Description = "Sa corne est un conduit de magma purifié.", BreedId = 6, Color = "Noir obsidienne", ImageUrl = "https://placehold.co/600x400/1C0000/FF4500?text=Ignis", Habitat = "Caldeiras de volcans", Diet = "Soufre et minéraux rares", MagicalPowers = "Pyromancie et terraformation", Origin = "Né du cœur en fusion de la terre.", DateOfBirth = new DateTime(432, 2, 18) },
                new { Id = 12, Name = "Magma", Description = "Sa crinière est une rivière de lave.", BreedId = 6, Color = "Rouge et noir", ImageUrl = "https://placehold.co/600x400/8B0000/FFD700?text=Magma", Habitat = "Chambres magmatiques", Diet = "Roches en fusion", MagicalPowers = "Endurance au feu et forge d'artefacts", Origin = "Gardien du noyau terrestre.", DateOfBirth = new DateTime(121, 10, 25) },
                // -- Aurore Boréale (BreedId = 7)
                new { Id = 13, Name = "Aurora", Description = "Peint le ciel nocturne de son galop.", BreedId = 7, Color = "Multicolore et changeant", ImageUrl = "https://placehold.co/600x400/8A2BE2/FFF?text=Aurora", Habitat = "Toundra arctique", Diet = "Cristaux de glace et vent solaire", MagicalPowers = "Manipulation de la lumière et du froid", Origin = "Esprit du ciel polaire.", DateOfBirth = new DateTime(1905, 12, 1) },
                new { Id = 14, Name = "Borealis", Description = "Son chant ressemble au craquement du champ magnétique terrestre.", BreedId = 7, Color = "Vert et rose pastel", ImageUrl = "https://placehold.co/600x400/98FB98/FF69B4?text=Borealis", Habitat = "Fjords gelés", Diet = "Lumière des étoiles polaires", MagicalPowers = "Hypnose visuelle et bouclier d'énergie", Origin = "Reflet terrestre d'une galaxie lointaine.", DateOfBirth = new DateTime(1859, 2, 14) },
                // -- Murmure des Sables (BreedId = 8)
                new { Id = 15, Name = "Sirocco", Description = "Court plus vite que le vent du désert.", BreedId = 8, Color = "Sable doré", ImageUrl = "https://placehold.co/600x400/F4A460/333?text=Sirocco", Habitat = "Dunes infinies", Diet = "Chaleur du soleil et cactus en fleurs", MagicalPowers = "Création de tempêtes de sable et de mirages", Origin = "Né d'une tempête de sable millénaire.", DateOfBirth = new DateTime(753, 5, 5) },
                new { Id = 16, Name = "Oasis", Description = "Trouve de l'eau là où il n'y en a pas.", BreedId = 8, Color = "Beige et turquoise", ImageUrl = "https://placehold.co/600x400/F5DEB3/40E0D0?text=Oasis", Habitat = "Oasis cachées", Diet = "Dattes et eau pure", MagicalPowers = "Divination de l'eau et purification", Origin = "Gardienne de la dernière oasis primordiale.", DateOfBirth = new DateTime(1337, 8, 19) },
                // -- Cœur de Montagne (BreedId = 9)
                new { Id = 17, Name = "Granit", Description = "Aussi solide et immuable que la montagne.", BreedId = 9, Color = "Gris tacheté de quartz", ImageUrl = "https://placehold.co/600x400/696969/EEE?text=Granit", Habitat = "Cavernes de cristal", Diet = "Gemmes et métaux bruts", MagicalPowers = "Force surhumaine et géomancie", Origin = "Cœur vivant d'une montagne.", DateOfBirth = new DateTime(200, 1, 1) },
                new { Id = 18, Name = "Mithril", Description = "Sa robe brille comme du métal poli.", BreedId = 9, Color = "Argent brillant", ImageUrl = "https://placehold.co/600x400/C0C0C0/333?text=Mithril", Habitat = "Veines de métaux précieux", Diet = "Or et platine", MagicalPowers = "Invulnérabilité et détection des trésors", Origin = "Forgé par des nains anciens.", DateOfBirth = new DateTime(580, 11, 8) },
                // -- Spectre Lunaire (BreedId = 10)
                new { Id = 19, Name = "Phasma", Description = "Traverse les murs les nuits de pleine lune.", BreedId = 10, Color = "Translucide et argenté", ImageUrl = "https://placehold.co/600x400/F5F5F5/333?text=Phasma", Habitat = "Cimetières anciens et plans astraux", Diet = "Lumière de lune et émotions résiduelles", MagicalPowers = "Intangibilité et communication avec les esprits", Origin = "Écho d'un rêve.", DateOfBirth = new DateTime(1485, 3, 28) },
                new { Id = 20, Name = "Luna", Description = "La plus proche de la lune elle-même.", BreedId = 10, Color = "Blanc laiteux", ImageUrl = "https://placehold.co/600x400/FFFFFF/333?text=Luna", Habitat = "Sur la lune", Diet = "Vide spatial", MagicalPowers = "Contrôle de la gravité et voyage astral", Origin = "Née sur la face cachée de la lune.", DateOfBirth = new DateTime(1969, 7, 20) }
                );
        }
    }
}
