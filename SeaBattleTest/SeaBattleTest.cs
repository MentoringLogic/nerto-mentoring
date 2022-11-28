using SeaBattle;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Security.Cryptography;

namespace SeaBattleTest
{
    [TestClass]
    public class SeaBattleTest
    {
        [TestMethod]
        public void CreateSeaTest()
        {
            //arrange

            //act
            Sea a = new Sea();
            
            //assert
            Assert.IsNotNull(a, "Sea is not created");
        }
    }
}