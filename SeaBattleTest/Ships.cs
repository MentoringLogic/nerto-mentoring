using SeaBattle;
using FluentAssertions;
using System.Drawing;

namespace SeaBattleTest
{
    [TestClass]
    public class Ships
    {
        [TestMethod]
        public void MoveTo_PlaceAlreadyOccupied_ThrowsException()
        {
            //arrange
            Sea sea = new Sea(10, 10);
            List<Point> MoveToCoords = new List<Point>(new Point[] { new Point(5, 5), new Point(5, 6), new Point(5, 7), new Point(5, 8) });
            List<Point> HybrydCoords = new List<Point>(new Point[] { new Point(3, 3), new Point(3, 4), new Point(3, 5), new Point(3, 6) });
            HybridShip hybrydo = new HybridShip("Kolipso", HybrydCoords);
            List<Point> WarCoords = new List<Point>(new Point[] { new Point(5, 5), new Point(5, 6), new Point(5, 7), new Point(5, 8)});
            BattleShip warrior = new BattleShip("Warr", WarCoords);
            //act
            sea.AddShip(hybrydo);
            sea.AddShip(warrior);
            //assert
            hybrydo.Invoking(hybrydo => hybrydo.MoveTo(MoveToCoords, sea)).Should().Throw<ArgumentOutOfRangeException>();
        }

        [TestMethod]
        public void MoveTo_SpeedToLow_ThrowException()
        {
            //arrange
            Sea sea = new Sea(10, 10);
            
            List<Point> WarCoords = new List<Point>(new Point[] { new Point(1, 1), new Point(1, 2)});
            BattleShip warrior = new BattleShip("Koalisto", WarCoords);          
            warrior.Speed = 5;
            sea.AddShip(warrior);
            List<Point> MoveToCoords = new List<Point>(new Point[] { new Point(8, 9), new Point(9, 9) });
            //act
            Action Act =  () => warrior.MoveTo(MoveToCoords, sea);
            //assert
            Act.Should().Throw<ArgumentOutOfRangeException>();
        }
        [TestMethod]
        public void AddShip_PlaceAvailable_ShipAdded()
        {
            //arrange
            Sea sea = new Sea(10, 10);
            List<Point> HybrydCoords = new List<Point>(new Point[] { new Point(4, 3), new Point(4, 4), new Point(4, 5), new Point(4, 6) });
            HybridShip hybrydo = new HybridShip("Gintama", HybrydCoords);
            List<Point> WarCoords = new List<Point>(new Point[] { new Point(7, 5), new Point(7, 6), new Point(7, 7) });
            BattleShip warrior = new BattleShip("Warrior", WarCoords);
            //act
            sea.AddShip(hybrydo);
            sea.AddShip(warrior);
            //assert
            sea[0].Should().Be(hybrydo);
            sea[1].Should().Be(warrior);

        }
        [TestMethod]
        public void toString_HybrydShip_ShouldPrintCorrectShipDescriptionToConsole()
        {
            //arrange
            List<Point> HybrydCoords = new List<Point>(new Point[] { new Point(5, 3), new Point(5, 4), new Point(5, 5) });
            HybridShip hybrydo = new HybridShip("Gintara", HybrydCoords);
            hybrydo.Speed = 5;
            hybrydo.Durability = 100;
            //act
            string toStr = hybrydo.ToString();
            //assert
            toStr.Should().Contain("Name: Gintara");
            toStr.Should().Contain("Durability: 100");
            toStr.Should().Contain("Speed: 5");
        }

        [TestMethod]
        public void Ships_AreEqual_true()
        {
            //arrange
            List<Point> HybrydCoords = new List<Point>(new Point[] { new Point(4, 3), new Point(4, 4), new Point(4, 5), new Point(4, 6) });
            BattleShip warr = new BattleShip("Tendari", HybrydCoords);
            List<Point> WarCoords = new List<Point>(new Point[] { new Point(7, 5), new Point(7, 6), new Point(7, 7), new Point(7, 8) });
            BattleShip warrior = new BattleShip("Warr", WarCoords);
            //act and assert
            warr.Should().Be(warrior);
        }

        [TestMethod]
        public void Ships_AreNotEqual_true()
        {
            //arrange
            List<Point> HybrydCoords = new List<Point>(new Point[] { new Point(4, 3), new Point(4, 4), new Point(4, 5), new Point(4, 6) });
            HybridShip hybrydo = new HybridShip("Gintara", HybrydCoords);
            List<Point> WarCoords = new List<Point>(new Point[] { new Point(7, 5), new Point(7, 6), new Point(7, 7) });
            BattleShip warrior = new BattleShip("Kalipso", WarCoords);
            //act and assert
            warrior.Should().NotBe(hybrydo);
        }
    }

}
