using Data;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplicationParkinson.Controllers;
using WebApplicationParkinson.Services;

namespace TestProject1
{
    [TestClass]
    public class Gallery2Test
    {
        [TestMethod]
        public void Test_InsertGallery2_ValidUser_ReturnsOkResult()
        {
            var configuration = new ConfigurationBuilder()
               .AddJsonFile("appsettings.json")
               .Build();
            var options = new DbContextOptionsBuilder<ServiceContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;
            using (var serviceContext = new ServiceContext(options))
            {
                var gallery2Service = new Gallery2Service(serviceContext);
                var controller = new Gallery2Controller(configuration, gallery2Service, serviceContext);
                var InsertGallery2 = new Gallery2Item
                {
                    url = ""
                };
                var result = controller.PostGallery(InsertGallery2);
                serviceContext.SaveChanges();
                Assert.IsNotNull(result);

            }
        }
    }
}
