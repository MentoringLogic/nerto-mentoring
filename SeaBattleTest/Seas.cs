using SeaBattle;
using FluentAssertions;
using System.Drawing;

namespace SeaBattleTest
{
    [TestClass]
    public class Seas
    {
        [TestMethod]
        [DataRow(1, 3, 3, 4, 5, 6)]
        [DataRow(1, 1, 1, 2, 1, 4)]
        [DataRow(1, 1, 1, 2, 1, 1)]
        [DataRow(1, 1, 3, 2, 1, 2)]
        public void CreateShip_AddShipIsNotLine_Exception(int x1, int y1, int x2, int y2, int x3, int y3)
        {
            List<Point> Coords = new List<Point>(new Point[] { new Point(x1, y1), new Point(x2, y2), new Point(x3, y3) });
            HybridShip Mship;
            //act
            Action Act = () => Mship = new HybridShip("Tendari", Coords);
            //assert
            Act.Should().Throw<Exception>().WithMessage("Ship is not a line");
        }
        [TestMethod]
        [DataRow (0, 0, 0, 1, 0, 2)]
        [DataRow (-2, 1, -2, 2, -2, 3)]
        [DataRow(1, 0, 1, 1, 1, 2)]
        [DataRow(-1, 1, -1, 2, -1, 3)]
        public void AddShip_ShipOutOfBorders_ThrowException(int x1, int y1, int x2, int y2, int x3, int y3)
        {
            //arrange
            Sea sea = new Sea(10, 10);
            List<Point> Coords = new List<Point>(new Point[] { new Point(x1, y1), new Point(x2, y2), new Point(x3, y3) });
            BattleShip warship = new BattleShip("Tendari", Coords);
            //act
            Action Act = () => sea.AddShip(warship);
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
        public void toString_10x10Sea_BeCorrect()
        {
            //arrange
            Sea sea = new Sea(10, 10);
            //act
            string toStr = sea.ToString();
            //assert
            toStr.Should().Be("Height: 10, Width: 10, Ships: ");
        }
        
    }
}


