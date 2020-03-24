using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlabberApp.Domain.Entities;

namespace BlabberApp.DomainTest.Entities
{
    [TestClass]
    public class BaseEntityTest_UnitTests
    {
        private BaseEntity _harness;
        public BaseEntityTest_UnitTests() 
        {
            _harness = new BaseEntity();
        }

        [TestMethod]
        public void TestGetSysId()
        {
            // Arrange
            string expected = _harness.getSysId();
            // Act
            string actual = _harness.getSysId();
            // Assert
            Assert.AreEqual(actual.ToString(), expected.ToString());
            Assert.AreEqual(true, _harness.getSysId() is string);
        }
        
        [TestMethod]
        public void TestCreatedDttm()
        {
            // Arrange
            BaseEntity Expected = new BaseEntity();
            // Act
            BaseEntity Actual = new BaseEntity();
            // Assert
            Assert.AreEqual(Expected.CreatedDTTM.ToString(), Actual.CreatedDTTM.ToString());


            //modify and then test again
            Actual.CreatedDTTM =  Actual.CreatedDTTM.AddDays(1.0);
            Assert.AreNotEqual(Expected.CreatedDTTM.ToString(), Actual.CreatedDTTM.ToString());
        }

        [TestMethod]
        public void TestModifiedDttm()
        {
            // Arrange
            BaseEntity Expected = new BaseEntity();
            // Act
            BaseEntity Actual = new BaseEntity();
            // Assert
            Assert.AreEqual(Expected.ModifiedDTTM.ToString(), Actual.ModifiedDTTM.ToString());
            
            //modify and then test again
            Actual.ModifiedDTTM =  Actual.ModifiedDTTM.AddDays(1.0);
            Assert.AreNotEqual(Expected.ModifiedDTTM.ToString(), Actual.ModifiedDTTM.ToString());
        }
    }
}
