using SeaBattle;
using FluentAssertions;
using System.Drawing;
using System.Threading;

namespace SeaBattleTest
{
    [TestClass]
    public class Seas
    {  
        [TestMethod]
        public void AddShip_ShipOutOfBorders_ThrowException()
        {
            //arrange
            Sea sea = new Sea(10, 10);
            List<Point> Coords = new List<Point>(new Point[] { new Point(-2, 1), new Point(-2, 2), new Point(-2, 3) });
            BattleShip warship = new BattleShip("Tendari", Coords);
            //act
            Action Act = () => sea.AddShip(warship);
            //assert
            Act.Should().Throw<Exception>().WithMessage("Ship can not exsist with this Sea borders");
        }
        [TestMethod]
        public void AddShip_ShipOnBorders_ThrowException()
        {
            //arrange
            Sea sea = new Sea(10, 10);
            List<Point> Coords = new List<Point>(new Point[] { new Point(0, 0), new Point(0, 1), new Point(0, 2) });
            HybridShip hybrydo = new HybridShip("Colossus", Coords);
            //act
            Action Act = () => sea.AddShip(hybrydo);
            //assert
            Act.Should().Throw<Exception>().WithMessage("Ship can not exsist with this Sea borders");
        }
        [TestMethod]
        public void Indexer_GetFirstElement_ShipByIndex()
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
        public void Indexer_IfiLowerThan0_throwException()
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
        public void Indexer_GetNotExsisting_throwException()
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
        public void toString_10x10Sea_PrintCorrectSeaDescriptionToConsole()
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
    }
}


