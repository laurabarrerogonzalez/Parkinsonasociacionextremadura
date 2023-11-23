using Data;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Multiverse.Controllers;
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
    public class Gallery1Test
    {
        [TestMethod]
        public void Test_InsertGallery1_ValidUser_ReturnsOkResult()
        {
            var configuration = new ConfigurationBuilder()
               .AddJsonFile("appsettings.json")
               .Build();
            var options = new DbContextOptionsBuilder<ServiceContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;
            using (var serviceContext = new ServiceContext(options))
            {
                var gallery1Service = new Gallery1Service(serviceContext);
                var controller = new Gallery1Controller(configuration, gallery1Service, serviceContext);
                var InsertGallery1 = new Gallery1Item
                {
                    url = ""
                };
                var result = controller.PostGallery(InsertGallery1);
                serviceContext.SaveChanges();
                Assert.IsNotNull(result);

            }
        }
    }
}
