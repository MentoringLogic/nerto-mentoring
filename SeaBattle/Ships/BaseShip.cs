using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
namespace SeaBattle
{
    public class BaseShip
    {
        public List<Deck> Decks { get; set; }
        public int Durability { get; set; }
        private string Name { get; set; }
        public int Speed { get; set; }
        public BaseShip(string ShipName, List<Point> points)
        {
            Speed = 5;
            Decks = new List<Deck>();
            Name = ShipName;
            if (!this.ShipCoordsLine(points) || !this.ShipCoordsUnion(points) || !this.ShipCoordsUnique(points))
            {
                throw new ShipIsNotLineException();
            }
            for (int i = 0; i < points.Count - 1; i++)
            {
                Deck a = new Deck();
                a.Location = points[i];
                Decks.Add(a);
            }
        }
        public override string ToString()
        {
            StringBuilder output = new StringBuilder("Name: ", 25);
            output.Append(Name + ", ");
            output.Append("Type: " + GetType() + ", ");
            output.Append("Durability: " + Durability + ", ");
            output.Append("Speed: " + Speed + ", ");
            output.Append("Decks:" + Decks.Count + ", ");
            output.Append("Coordinates: ");
            foreach (var deck in Decks)
            {
                output.Append(deck.Location.X + ":" + deck.Location.Y + ", ");
            }
            return output.ToString();
        }

        public static bool operator == (BaseShip s1, BaseShip s2)
        {
            if (ReferenceEquals(s1, s2))
                return true;
            if (ReferenceEquals(s1, null))
                return false;
            if (ReferenceEquals(s2, null))
                return false;
            return s1.Equals(s2);
        }
        public static bool operator != (BaseShip s1, BaseShip s2) => !(s1 == s2);
        
        public bool Equals(BaseShip thisShip)
        {
            if (ReferenceEquals(thisShip, null))
                return false;
            if (ReferenceEquals(this, thisShip))
                return true;
            return Decks.Count.Equals(thisShip.Decks.Count) && GetType().Equals(thisShip.GetType());
        }
        public override bool Equals(object s1) => Equals(s1 as BaseShip);
        // To do in the MoveTo method  
        // 1. + calculating mid-ship coordinates of current position
        // 2. + calculating mid-ship coordinates of new position
        // 3. + calcualating distance of the move
        // 4. + checking if speed is enough to get to new position
        // 5. + checking if new position is available
        // 6. + updating current position with new position
        public void MoveTo(List<Point> NewPosition, Sea Sea1)
        {
            float midShipX = 0;
            float midShipY = 0;
            foreach (var d in Decks)
            {
                midShipX += d.Location.X;
                midShipY += d.Location.Y;
            }
            midShipX /= Decks.Count;
            midShipY /= Decks.Count;

            float midNewX = 0;
            float midNewY = 0;
            foreach (var p in NewPosition)
            {
                midNewX += p.X;
                midNewY += p.Y;
            }
            midNewX /= NewPosition.Count;
            midNewY /= NewPosition.Count;

            float TravelX = (float)Math.Pow(midShipX - midNewX, 2);
            float TravelY = (float)Math.Pow(midShipY - midNewY, 2);
            float TravelDistance;
            TravelDistance = (float)Math.Sqrt(TravelX + TravelY);
            if (Speed < TravelDistance)
            {
                throw new ShipCantMoveException();
            }
            if (Sea1.IsPlaceAvailable(this) && this.ShipCoordsLine(NewPosition) && this.ShipCoordsUnion(NewPosition) && this.ShipCoordsUnique(NewPosition))
            {
                for (int i = 0; i < NewPosition.Count; i++)
                {
                    Decks[i].Location.X = NewPosition[i].X;
                    Decks[i].Location.Y = NewPosition[i].Y;
                }
            }
            else

                throw new ShipCantMoveException();
        }
        public bool HasCoordinatesIntersect(List<Deck> DecksList)
        {
            return Decks.Any(e => e.HasCoordinatesIntersect(DecksList));
        }
        public bool ShipCoordsLine(List<Point> SameDecks)
        {
            bool lineFlagX = true;
            bool lineFlagY = true;

            for (int i = 0; i < SameDecks.Count - 1; i++)
            {
                lineFlagX &= SameDecks[i].X == SameDecks[i + 1].X;
                lineFlagY &= SameDecks[i].Y == SameDecks[i + 1].Y;
            }
            return lineFlagX ^ lineFlagY;
        }
        public bool ShipCoordsUnion(List<Point> SameDecks)
        {
            bool unionFlagX = true;
            bool unionFlagY = true;
            for (int i = 0; i < SameDecks.Count - 1; i++)
            {
                var current = SameDecks[i];
                var next = SameDecks[i + 1];
                unionFlagX &= Math.Abs(current.X - next.X) <= 1;
                unionFlagY &= Math.Abs(current.Y - next.Y) <= 1;
            }
            return unionFlagX && unionFlagY;
        }
        public bool ShipCoordsUnique(List<Point> SameDecks)
        {
            int uniqFlagX = 0;
            int uniqFlagY = 0;
            for (int i = 0; i < SameDecks.Count - 1; i++)
            {
                uniqFlagX = 0;
                uniqFlagY = 0;
                foreach (Point sd in SameDecks)
                {
                    if (SameDecks[i].X == sd.X) uniqFlagX++;
                    if (SameDecks[i].Y == sd.Y) uniqFlagY++;
                }
                if ((uniqFlagX > 1) && (uniqFlagY > 1)) 
                    return false;
            }
            return true;
        }
    }
}