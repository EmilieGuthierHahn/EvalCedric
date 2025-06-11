using Bunit;
using Bunit.TestDoubles;
using EvalCedric.Components.Pages;
using EvalCedric.Data;
using EvalCedric.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
using TestContext = Bunit.TestContext;

namespace EvalCedric.Tests
{
    [TestClass]
    public class CodexTests : TestContext
    {
        private ApplicationDbContext CreateDbContext(string dbName)
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: dbName)
                .Options;
            return new ApplicationDbContext(options);
        }

       

        [TestMethod]
        public void Test_Codex_Aucune_Licorne()
        {
            // Arrange
            var dbContext = CreateDbContext("DB_Vide");
            Services.AddSingleton(dbContext);

            // Act
            var cut = RenderComponent<Codex>();

            // Assert
            cut.WaitForState(() => cut.Find(".alert-info") != null);
            var alert = cut.Find(".alert-info");
            Assert.IsTrue(alert.TextContent.Contains("Le Sanctuaire est silencieux"));
            Assert.IsTrue(alert.TextContent.Contains("Aucun écho magique n'a été perçu"));
        }

        [TestMethod]
        public void Test_Codex_Affiche_Une_Licorne()
        {
            // Arrange
            var dbContext = CreateDbContext("DB_UneLicorne");
            var breed = new Breed
            {
                Id = 1,
                Name = "Race Test",
                Description = "Description Test"
            };
            var unicorn = new Unicorn
            {
                Id = 1,
                Name = "Licorne Test",
                Color = "Rose",
                Description = "Description",
                ImageUrl = "test.jpg",
                Habitat = "Forêt",
                Diet = "Végétarien",
                MagicalPowers = "Test",
                Origin = "Test",
                DateOfBirth = DateTime.Now.AddYears(-5),
                BreedId = 1,
                Breed = breed
            };

            dbContext.Breeds.Add(breed);
            dbContext.Unicorns.Add(unicorn);
            dbContext.SaveChanges();
            Services.AddSingleton(dbContext);

            // Act
            var cut = RenderComponent<Codex>();

            // Assert
            cut.WaitForState(() => cut.Find("table") != null);
            var table = cut.Find("table");
            Assert.IsTrue(table.TextContent.Contains("Licorne Test"));
            Assert.IsTrue(table.TextContent.Contains("Rose"));
            Assert.IsTrue(table.TextContent.Contains("Forêt"));
        }

        [TestMethod]
        public void Test_Codex_Navigation_Vers_Profil()
        {
            // Arrange
            var dbContext = CreateDbContext("DB_Navigation");
            var breed = new Breed
            {
                Id = 1,
                Name = "Race Test",
                Description = "Description Test"
            };
            var unicorn = new Unicorn
            {
                Id = 42,
                Name = "Licorne Navigation",
                Color = "Bleu",
                Description = "Description",
                ImageUrl = "test.jpg",
                Habitat = "Montagne",
                Diet = "Végétarien",
                MagicalPowers = "Test",
                Origin = "Test",
                DateOfBirth = DateTime.Now.AddYears(-3),
                BreedId = 1,
                Breed = breed
            };

            dbContext.Breeds.Add(breed);
            dbContext.Unicorns.Add(unicorn);
            dbContext.SaveChanges();
            Services.AddSingleton(dbContext);

            var navManager = Services.GetRequiredService<FakeNavigationManager>();

            // Act
            var cut = RenderComponent<Codex>();
            cut.WaitForState(() => cut.Find(".btn-info") != null);
            var boutonVoirProfil = cut.Find(".btn-info");
            boutonVoirProfil.Click();

            // Assert
            Assert.AreEqual($"{navManager!.BaseUri}Profil/42", navManager.Uri);
        }

        [TestMethod]
        public void Test_Codex_Affichage_Image()
        {
            // Arrange
            var dbContext = CreateDbContext("DB_Image");
            var breed = new Breed
            {
                Id = 1,
                Name = "Race Test",
                Description = "Description Test"
            };
            var unicorn = new Unicorn
            {
                Id = 1,
                Name = "Licorne Image",
                Color = "Violet",
                Description = "Description",
                ImageUrl = "https://example.com/licorne.jpg",
                Habitat = "Prairie",
                Diet = "Végétarien",
                MagicalPowers = "Test",
                Origin = "Test",
                DateOfBirth = DateTime.Now,
                BreedId = 1,
                Breed = breed
            };

            dbContext.Breeds.Add(breed);
            dbContext.Unicorns.Add(unicorn);
            dbContext.SaveChanges();
            Services.AddSingleton(dbContext);

            // Act
            var cut = RenderComponent<Codex>();

            // Assert
            cut.WaitForState(() => cut.Find("img") != null);
            var image = cut.Find("img");
            Assert.AreEqual("https://example.com/licorne.jpg", image.GetAttribute("src"));
            Assert.AreEqual("Image de Licorne Image", image.GetAttribute("alt"));
        }
    }
}