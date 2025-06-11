// Projet : EvalCedric.Tests
// Fichier : ErrorTests.cs

using System.Diagnostics;
using Bunit;
using EvalCedric.Components.Pages; // Assurez-vous que le chemin vers votre page Error est correct
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
using TestContext = Bunit.TestContext;

namespace EvalCedric.Tests
{
    [TestClass]
    public class ErrorTests : TestContext
    {
        [TestMethod]
        public void Test_Error_Affiche_Les_Messages_Par_Defaut()
        {
            // ARRANGE & ACT
          
            var cut = RenderComponent<Error>();

            // ASSERT
         
            Assert.IsNotNull(cut.Find("h1.text-danger"));
            Assert.IsTrue(cut.Find("h2.text-danger").TextContent.Contains("An error occurred"));

          
            Assert.AreEqual(0, cut.FindAll("p > strong:contains('Request ID:')").Count);
        }

        [TestMethod]
        public void Test_Error_Avec_Activity_Affiche_RequestId()
        {
            // ARRANGE
           
            using var activity = new Activity("TestActivity");
            activity.Start();

            // ACT
            var cut = RenderComponent<Error>();

            // ASSERT
          
            var requestIdElement = cut.Find("code");
            Assert.IsNotNull(requestIdElement);
            Assert.AreEqual(activity.Id, requestIdElement.TextContent);
        }

        [TestMethod]
        public void Test_Error_Avec_HttpContext_Affiche_TraceIdentifier()
        {
            // ARRANGE
       
            var fakeHttpContext = new DefaultHttpContext();
            var testTraceId = "trace-id-pour-le-test-123";
            fakeHttpContext.TraceIdentifier = testTraceId;

            // ACT
          
            var cut = RenderComponent<CascadingValue<HttpContext>>(parameters => parameters
                .Add(p => p.Value, fakeHttpContext) 
                .AddChildContent<Error>()          
            );

            // ASSERT
           
            var requestIdElement = cut.Find("code");
            Assert.IsNotNull(requestIdElement);
            Assert.AreEqual(testTraceId, requestIdElement.TextContent);
        }
    }
}