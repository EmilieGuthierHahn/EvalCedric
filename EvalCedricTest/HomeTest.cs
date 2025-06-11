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
    public class HomeTests : TestContext
    {
        [TestMethod]
        public void Test_Home_Affiche_Contenu_Statique()
        {

            // ACT
       
            var cut = RenderComponent<Home>();

            // ASSERT
           
            var titrePrincipal = cut.Find("h1.titre-arc-en-ciel");
            Assert.IsTrue(titrePrincipal.TextContent.Contains("Sanctuaire des Licornes"));

            var titresCartes = cut.FindAll("h2");
            Assert.AreEqual(2, titresCartes.Count, "Il devrait y avoir deux cartes avec des titres h2.");
            Assert.IsTrue(titresCartes[0].TextContent.Contains("Consulter le Codex"));
            Assert.IsTrue(titresCartes[1].TextContent.Contains("Ajouter une Créature"));
        }

        [TestMethod]
        public void Test_Home_Navigation_Vers_Codex()
        {
            // ARRANGE

            var navManager = Services.GetRequiredService<FakeNavigationManager>();

            // ACT
            var cut = RenderComponent<Home>();
            var carteCodex = cut.FindAll(".carte")[0]; 
            carteCodex.Click();

            // ASSERT
           
            Assert.AreEqual($"{navManager.BaseUri}codex", navManager.Uri);
        }

        [TestMethod]
        public void Test_Home_Navigation_Vers_Ajout()
        {
            // ARRANGE
            var navManager = Services.GetRequiredService<FakeNavigationManager>();

            // ACT
            var cut = RenderComponent<Home>();
            var carteAjout = cut.FindAll(".carte")[1]; 
            carteAjout.Click();

            // ASSERT
          
            Assert.AreEqual($"{navManager.BaseUri}ajout", navManager.Uri);
        }
    }
}