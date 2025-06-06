namespace EvalCedric.Models
{
    public class Unicorn
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Color { get; set; }
        public required string Description { get; set; }
        public required string ImageUrl { get; set; }
        public required string Habitat { get; set; }
        public required string Diet { get; set; }
        public required string MagicalPowers { get; set; }
        public required string Origin { get; set; }
        public required DateTime DateOfBirth { get; set; }
        public int Age => (int)Math.Floor((DateTime.Now - DateOfBirth).TotalDays / 365.25);
        public int BreedId { get; set; }
        public required Breed Breed { get; set; }
    }
}
