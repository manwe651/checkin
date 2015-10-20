using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using CheckInWeb.Data.Repositories;
using CheckInWeb.Data.Entities;
using CheckInWeb.Controllers;
using System.Web.Http.Routing;
using System.Net.Http;

namespace CheckInWeb.Tests
{
    [TestClass]
    public class AjaxLocationControllerTest
    {
        [TestMethod]
        public void Post_Should_Work()
        {
            // Setup mock repository
            var mockRepository = new Mock<IRepository>();
            var location = new Location
            {
                Id = 1,
                Name = "Wauwatosa"
            };
            mockRepository.Setup(x => x.Insert<Location>(location)).Verifiable();

            // Configure controller for testing
            var controller = new AjaxLocationController(mockRepository.Object);
            controller.Request = new HttpRequestMessage
            {
                RequestUri = new Uri("http://localhost/api/AjaxLocation")
            };
            controller.Configuration = new System.Web.Http.HttpConfiguration();
            WebApiConfig.Register(controller.Configuration);
            controller.RequestContext.RouteData = new HttpRouteData(
                route: new HttpRoute(),
                values: new HttpRouteValueDictionary { { "controller", "AjaxLocation" } }
            );

            // Call method being tested
            var result = controller.Post(location);
          
            // Verify results
            Assert.IsTrue(result.IsSuccessStatusCode);
            Assert.AreEqual("http://localhost/api/AjaxLocation/1", result.Headers.Location.AbsoluteUri);
            mockRepository.VerifyAll();
        }

    }
}
