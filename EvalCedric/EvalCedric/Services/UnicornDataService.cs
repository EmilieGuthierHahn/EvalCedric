using EvalCedric.Models;

namespace EvalCedric.Services
{
    public class UnicornDataService
    {
        private List<Breed> _breeds;
        private List<Unicorn> _unicorns;

        public UnicornDataService()
        {
            InitializeData();
        }

        private void InitializeData()
        {
            // Création des races de licornes
            _breeds = new List<Breed>
            {
                new Breed { Id = 1, Name = "Corne de Cristal", Description = "Licornes dont la corne pure peut réfracter la lumière lunaire en énergie curative." },
                new Breed { Id = 2, Name = "Crinière d'Étoiles", Description = "Leur crinière scintille avec la lumière d'étoiles lointaines. Elles sont d'une grande sagesse." },
                new Breed { Id = 3, Name = "Gardien de la Forêt", Description = "Leur robe est tachetée comme la lumière du soleil à travers les feuilles. Protectrices des bois anciens." },
                new Breed { Id = 4, Name = "Écume de Mer", Description = "Vivent sur les côtes, leur robe a la couleur de l'écume et elles peuvent galoper sur l'eau." },
                new Breed { Id = 5, Name = "Sauteur d'Ombre", Description = "Insaisissables et mystérieuses, elles voyagent à travers les ombres et sont rarement vues." }
            };

           
            _unicorns = new List<Unicorn>
            {
                new Unicorn
                {
                    Id = 1,
                    Name = "Luminara",
                    Description = "Sa corne luit d'une douce lumière apaisante, capable de repousser les ténèbres.",
                    Breed = _breeds[0],
                    Color = "Blanc perle avec des reflets argentés",
                    ImageUrl = "https://placehold.co/600x400/FFF/333?text=Luminara",
                    Habitat = "Clairières éclairées par la lune",
                    Diet = "Rosée du matin et fleurs de lune",
                    MagicalPowers = "Guérison par la lumière et purification",
                    Origin = "Née d'un éclat de lune tombé sur terre.",
                    DateOfBirth = new DateTime(1524, 5, 20)
                },
                new Unicorn
                {
                    Id = 2,
                    Name = "Céleste",
                    Description = "On dit que de nouvelles constellations naissent des étincelles de sa crinière.",
                    Breed = _breeds[1],
                    Color = "Bleu nuit profond constellé d'étoiles",
                    ImageUrl = "https://placehold.co/600x400/001/EEE?text=Céleste",
                    Habitat = "Sommets des plus hautes montagnes, au-dessus des nuages",
                    Diet = "Poussière de comète et murmures du vent solaire",
                    MagicalPowers = "Navigation stellaire et prophéties mineures",
                    Origin = "Tissée à partir d'une nébuleuse par des entités cosmiques.",
                    DateOfBirth = new DateTime(877, 11, 12)
                },
                new Unicorn
                {
                    Id = 3,
                    Name = "Veridian",
                    Description = "Gardien du Bosquet Murmurant, sa robe change avec les saisons.",
                    Breed = _breeds[2],
                    Color = "Vert mousse avec des taches de lumière dorée",
                    ImageUrl = "https://placehold.co/600x400/2A4/EEE?text=Veridian",
                    Habitat = "Cœur des forêts primordiales et intouchées",
                    Diet = "Sève d'arbres anciens et champignons lumineux",
                    MagicalPowers = "Communication avec la faune et la flore, croissance végétale accélérée",
                    Origin = "Incarnation de l'esprit d'une forêt millénaire.",
                    DateOfBirth = new DateTime(1250, 8, 1)
                },
                 new Unicorn
                {
                    Id = 4,
                    Name = "Aquaria",
                    Description = "Elle laisse une traînée de perles irisées sur le sable à l'aube.",
                    Breed = _breeds[3],
                    Color = "Turquoise et blanc comme l'écume",
                    ImageUrl = "https://placehold.co/600x400/0AF/111?text=Aquaria",
                    Habitat = "Récifs coralliens cachés et plages de sable blanc",
                    Diet = "Plancton bioluminescent et sel enchanté",
                    MagicalPowers = "Contrôle des courants mineurs et capacité à respirer sous l'eau",
                    Origin = "Née du baiser de la lune sur l'océan.",
                    DateOfBirth = new DateTime(1801, 7, 15)
                }
            };
        }


        public List<Breed> GetAllBreeds() => _breeds;

        public void AddBreed(Breed breed)
        {
            breed.Id = _breeds.Any() ? _breeds.Max(b => b.Id) + 1 : 1;
            _breeds.Add(breed);
        }

        public void UpdateBreed(Breed updatedBreed)
        {
            var breed = _breeds.FirstOrDefault(b => b.Id == updatedBreed.Id);
            if (breed != null)
            {
                breed.Name = updatedBreed.Name;
                breed.Description = updatedBreed.Description;
            }
        }


        public List<Unicorn> GetAllUnicorns() => _unicorns;

        public Unicorn GetUnicornById(int id) => _unicorns.FirstOrDefault(u => u.Id == id);

        public void AddUnicorn(Unicorn unicorn)
        {
            unicorn.Id = _unicorns.Any() ? _unicorns.Max(u => u.Id) + 1 : 1;
            _unicorns.Add(unicorn);
        }

        public void UpdateUnicorn(Unicorn updatedUnicorn)
        {
            var unicorn = _unicorns.FirstOrDefault(u => u.Id == updatedUnicorn.Id);
            if (unicorn != null)
            {
                unicorn.Name = updatedUnicorn.Name;
                unicorn.Description = updatedUnicorn.Description;
                unicorn.Breed = updatedUnicorn.Breed;
                unicorn.Color = updatedUnicorn.Color;
                unicorn.ImageUrl = updatedUnicorn.ImageUrl;
                unicorn.Habitat = updatedUnicorn.Habitat;
                unicorn.Diet = updatedUnicorn.Diet;
                unicorn.MagicalPowers = updatedUnicorn.MagicalPowers;
                unicorn.Origin = updatedUnicorn.Origin;
                unicorn.DateOfBirth = updatedUnicorn.DateOfBirth;
            }
        }

        public void DeleteUnicorn(int id)
        {
            var unicorn = _unicorns.FirstOrDefault(u => u.Id == id);
            if (unicorn != null)
            {
                _unicorns.Remove(unicorn);
            }
        }

        public List<Unicorn> SearchUnicornsByName(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                return _unicorns;
            }
            return _unicorns.Where(u => u.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)).ToList();
        }
    }
}