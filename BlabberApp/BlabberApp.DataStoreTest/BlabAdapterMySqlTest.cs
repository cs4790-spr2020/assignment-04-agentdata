using System.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlabberApp.DataStore.Adapters;
using BlabberApp.DataStore.Plugins;
using BlabberApp.Domain.Entities;

namespace BlabberApp.DataStoreTest
{
    [TestClass]
    public class BlabAdapter_MySql_UnitTests
    {
        private BlabAdapter _harness = new BlabAdapter(new MySqlBlab());

        [TestMethod]
        public void Canary()
        {
            Assert.AreEqual(true, true);
        }

        [TestMethod]
        public void TestAddAndGetBlab()
        {
            
            //Arrange
            string email = "jojo@andthecoons.com";
            User mockUser = new User(email);
            Blab blab = new Blab("initial test blab", mockUser);
            
            //Act
            _harness.Add(blab);
            ArrayList actual = (ArrayList)_harness.GetByUserId(email);

            //Assert
            Assert.AreEqual(1, actual.Count);
            _harness.Remove(blab);
        }
    }
}
