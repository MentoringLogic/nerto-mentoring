using SeaBattle;
using FluentAssertions;
using System.Drawing;
using System.Data.Common;
using System.Runtime.CompilerServices;

namespace SeaBattleTest
{
    [TestClass]
    public class Seas
    {  
        [TestMethod]
        public void AddShip_DontAddShip_ifShipOutOfBorders()
        {
            //arrange
            Sea sea = new Sea(10, 10);
            List<Point> Coords = new List<Point>(new Point[] { new Point(-2, 1), new Point(-2, 2), new Point(-2, 3) });
            BattleShip warship = new BattleShip("Tendari", Coords);
            //act

            //assert
            sea.Invoking(sea => sea.AddShip(warship)).Should().Throw<Exception>().WithMessage("Ship can not exsist with this Sea borders");
        }
        [TestMethod]
        public void AddShip_DontAddShip_ifShipOnBorders()
        {
            //arrange
            Sea sea = new Sea(10, 10);
            List<Point> Coords = new List<Point>(new Point[] { new Point(0, 0), new Point(0, 1), new Point(0, 2) });
            HybridShip hybrydo = new HybridShip("Colossus", Coords);
            //act

            //assert
            sea.Invoking(sea => sea.AddShip(hybrydo)).Should().Throw<Exception>().WithMessage("Ship can not exsist with this Sea borders");
        }
        [TestMethod]
        public void Indexer_GetFirstElement_byIndexer()
        {
            //arrange
            Sea sea = new Sea(10, 10);
            List<Point> HybrydCoords = new List<Point>(new Point[] { new Point(1, 2), new Point(1, 3), new Point(1, 4) });
            HybridShip hybrydo = new HybridShip("SomeShip", HybrydCoords);
            //act
            sea.AddShip(hybrydo);
            //assert 

            hybrydo.Should().Be(sea[0]);
        }

        [TestMethod]
        public void Indexer_IfiLowerThan0_byIndexer()
        {
            //arrange
            Sea sea = new Sea(10, 10);
            List<Point> HybrydCoords = new List<Point>(new Point[] { new Point(1, 2), new Point(1, 3), new Point(1, 4) });
            HybridShip hybrydo = new HybridShip("SomeShip", HybrydCoords);
            //act
            sea.AddShip(hybrydo);
            //assert

            sea.Invoking(sea => sea[-1]).Should().Throw<IndexOutOfRangeException>();
        }
        [TestMethod]
        public void Indexer_GetNotExsisting_byIndexer()
        {
            //arrange
            Sea sea = new Sea(10, 10);
            List<Point> HybrydCoords = new List<Point>(new Point[] { new Point(1, 2), new Point(1, 3), new Point(1, 4) });
            List<Point> RepairCoords = new List<Point>(new Point[] { new Point(3, 3), new Point(3, 4) });
            HybridShip hybrydo = new HybridShip("Colossus", HybrydCoords);
            ServiceShip repairer = new ServiceShip("Gintama", RepairCoords);
            //act
            sea.AddShip(hybrydo);
            sea.AddShip(repairer);
            //assert
            sea.Invoking(sea => sea[2]).Should().Throw<IndexOutOfRangeException>();
        }
        [TestMethod]
        public void toString_ToStringWorks_good()
        {
            //arrange
            Sea sea = new Sea(10, 10);
            //act
            string toStr = sea.ToString();
            //assert
            toStr.Should().Contain("Height: 10");
            toStr.Should().Contain("Width: 10");
            toStr.Should().Contain("Ships: ");
        }

        [TestMethod]
        public void IsPlaceAvailable_ShipsHaveSameCoordinates_ShouldReturnFalse()
        {
            //arrange
            Sea sea = new Sea(10, 10);
            List<Point> HybrydCoords = new List<Point>(new Point[] { new Point(4, 3), new Point(4, 4), new Point(4, 5) });
            HybridShip hybrydo = new HybridShip("Gintara", HybrydCoords);
            List<Point> WarCoords = new List<Point>(new Point[] { new Point(4, 3), new Point(3, 4) });
            BattleShip warrior = new BattleShip("Kalipso", WarCoords);
            sea.AddShip(hybrydo);

            //act
            bool result = sea.IsPlaceAvailable(warrior);

            //assert
            result.Should().BeFalse();
        }
    }
}


