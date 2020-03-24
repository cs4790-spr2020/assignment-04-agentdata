using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlabberApp.DataStore;
using BlabberApp.Domain.Entities;

namespace BlabberApp.DataStoreTest
{
    [TestClass]
    public class InMemory_UnitTests 
    {
        private InMemory<Blab> _harness;
        public InMemory_UnitTests()
        {
            var options = new DbContextOptionsBuilder<ApplicationContext>()
                .UseInMemoryDatabase(databaseName: "Add_writes")
                .Options;
            _harness = new InMemory<Blab>(new ApplicationContext(options));
        }

        [TestMethod]
        public void Add_Blab_GetByUserId_Success()
        {
            // Arrange
            string Email = "foo@example.com";
            Blab Expected = new Blab();
            Expected.Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer gravida posuere pretium. Cras maximus nibh sed accumsan elementum. Lorem ipsum dolor sit amet, consectetur adipiscing elit.";
            Expected.UserID = Email;
            var sysId = Expected.getSysId();
            _harness.Add(Expected);
            
            // Act
            Blab Actual = (Blab)_harness.GetByUserId(Email);

            // Assert
            Assert.AreEqual(Expected, Actual);
        }

        //additional tests
        [TestMethod]
        public void Update_Blab_GetById_Success()
        {
            // Arrange
            string Email = "foo@example.com";
            Blab Expected = (Blab)_harness.GetByUserId(Email);
            Expected.Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer gravida posuere pretium. Cras maximus nibh sed accumsan elementum. Lorem ipsum dolor sit amet, consectetur adipiscing elit.";
            Expected.Message = "Integer gravida posuere pretium. Cras maximus nibh sed accumsan elementum. Lorem ipsum dolor sit amet, consectetur adipiscing elit.";
            _harness.Update(Expected);

            // Act
            Blab Actual = (Blab)_harness.GetByUserId(Email);

            // Assert
            Assert.AreEqual(Expected, Actual);
        }

        [TestMethod]
        public void Remove_Blab_GetById_Success()
        {
            // Arrange
            string Email = "foo@example.com";
            Blab Expected = (Blab)_harness.GetByUserId(Email);
            _harness.Remove(Expected);

            // Act
            Blab Actual = (Blab)_harness.GetByUserId(Email);

            // Assert
            Assert.AreNotEqual(Expected, Actual);
        }
    }
}