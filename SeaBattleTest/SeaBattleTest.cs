using SeaBattle;
using FluentAssertions;
using System.Drawing;
using System.Data.Common;
using System.Runtime.CompilerServices;

namespace SeaBattleTest
{
    
    [TestClass]
    public class SeaTest
    {
        //Verify that Sea is created (not null)
        //Verify that List of ships is created (not null) 
        //Verify that Ships placed outside sea (x<0) is returns exception
        //Verify that Ship placed on border (x = 0) is returns exception 
        //Verify that if added 2 ships and you trying do Sea[2] is returns exception 
        [TestMethod]
        public void CreateSeaTest()
        {
            Sea a = new Sea(10, 10);
            a.Should().NotBeNull("Sea is not created");
        }
        
        [TestMethod]
        public void CreateListOfShipsTest()
        {
            List<BaseShip> s = new List<BaseShip>();
            s.Should().NotBeNull("List is not created");

        }
        
        [TestMethod]
        public void ShipOutOfBordersTest()
        {
            Sea a = new Sea(10, 10);
            List<Point> p = new List<Point>(new Point[] { new Point(-2, -1), new Point(-2, -2), new Point(-2, -3)});
            BattleShip b = new BattleShip("Tendari", p);
            a.Invoking(a => a.AddShip(b)).Should().Throw<Exception>().WithMessage("Ship can not exsist with this Sea borders");
        }
        
        [TestMethod]
        public void ShipOnBorderTest()
        {
            Sea a = new Sea(10, 10);
            List<Point> p = new List<Point>(new Point[] { new Point(0, 0), new Point(0, 1), new Point(0, 2) });
            HybridShip h = new HybridShip("Colossus", p);
            a.Invoking(a => a.AddShip(h)).Should().Throw<Exception>().WithMessage("Ship can not exsist with this Sea borders");

        }
        
        [TestMethod]
        public void CheckIndexerTest()
        {
            Sea a = new Sea(10, 10);
            List<Point> p = new List<Point>(new Point[] { new Point(1, 2), new Point(1, 3), new Point(1, 4) });
            List<Point> d = new List<Point>(new Point[] { new Point(3, 3), new Point(3, 4) });
            HybridShip hybr = new HybridShip("Colossus", p);
            ServiceShip c = new ServiceShip("Gintama", d);
            a.AddShip(hybr);
            a.AddShip(c);
            a.Invoking(a => a[2]).Should().Throw<IndexOutOfRangeException>();
        }

    }

   
    [TestClass]
    public class ShipTest
    {
        //Verify that Ship is created (not null)
        //Verifying deck count
        //Verify that List of decks is created (not null)
        //Verify that is method Move to will return exception if you try to move to the point where ship already exists
        //Verify that if (speed < traveldistance) is returns exception
        [TestMethod]
        public void CreateShipTest()
        {
            List<Point> p = new List<Point>(new Point[] { new Point(1, 2), new Point(1, 3), new Point(1, 4), new Point(1, 5) });
            BattleShip b = new BattleShip("Yamato", p);
            b.Should().NotBeNull("Ship is not created");
        }

        [TestMethod]
        public void DecksCountTest()
        {
            List<Point> p = new List<Point>(new Point[] { new Point(2, 2), new Point(2, 3), new Point(2, 4), new Point(2, 5) });
            p.Should().HaveCount(4, "Not all decks were created");
        }

        [TestMethod]
        public void ListOfDecksTest()
        {
            List<Deck> d = new List<Deck>();
            d.Should().NotBeNull("List is not created");
        }
        
        [TestMethod]
        public void MoveToOccupiedCoordsTest()
        {
            Sea a = new Sea(10, 10);
            List<Deck> NewDecks = new List<Deck>(new Deck[] {new Deck(), new Deck(), new Deck() });
            
            //will finish tommorow this part, cant understand how to give coords from newPoints to NewDecks.

            List<Point> newPoints = new List<Point>(new Point[] { new Point(5, 5), new Point(6, 5), new Point(7, 5), new Point(8, 5) });

            List<Point> p = new List<Point>(new Point[] { new Point(2, 2), new Point(2, 3), new Point(2, 4), new Point(2, 5) });
            HybridShip hybrydo = new HybridShip("Killer", p);
            List<Point> g = new List<Point>(new Point[] { new Point(5, 5), new Point(5, 6), new Point(5, 7) });
            BattleShip warrior = new BattleShip("warrior", g);
            a.AddShip(hybrydo);
            a.AddShip(warrior);

            //hybrydo.Invoking(hybrydo => hybrydo.MoveTo(NewDecks, a)).Should().Throw<Exception>().WithMessage("Deck already occupied");
        }
        
        [TestMethod]
        public void MoveFurtherThanSpeed()
        {
           
        }
    }

}