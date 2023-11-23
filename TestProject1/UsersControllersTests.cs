using Data;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Multiverse.Controllers;
using System.Collections.ObjectModel;
using WebApplicationParkinson.IServices;
using WebApplicationParkinson.Model;
using WebApplicationParkinson.Services;

namespace TestProject1
{
    [TestClass]
    public class UsersControllersTests
    {
        [TestMethod]
        public void Test_InsertUsers_ValidUser_ReturnsOkResult()
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
            var options = new DbContextOptionsBuilder<ServiceContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;
            using (var serviceContext = new ServiceContext(options))
            {
                var usersService = new UsersService(serviceContext);
                var controller = new UsersControllers(configuration, usersService, serviceContext);
                var InsertUsers = new UsersItems
                {
                    UserName = "Admin",
                    Password = "1234",
                };
                var result = controller.Post(InsertUsers);
                serviceContext.SaveChanges();
                Assert.IsNotNull(result);
            }
        }

        [TestMethod]
        public void Test_Login_ValidCredentials_ReturnsToken()
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
            var options = new DbContextOptionsBuilder<ServiceContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;
            using (var serviceContext = new ServiceContext(options))
            {
                var usersService = new UsersService(serviceContext);
                var controller = new UsersControllers(configuration, usersService, serviceContext);
                var loginRequest = new LoginRequestModel
                {
                    UserName = "Admin",
                    Password = "1234"
                };

                var result = controller.Login(loginRequest);
                var token = result;
                Assert.IsNotNull(token);
            }
        }
    }
}
