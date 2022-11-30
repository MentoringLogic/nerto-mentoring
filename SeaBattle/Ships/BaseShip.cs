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
            
            Decks = new List<Deck>();
            Name = ShipName;
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
        public static bool operator ==(BaseShip s1, BaseShip s2)
        {
            return s1.Decks.Count.Equals(s2.Decks.Count) && s1.GetType().Equals(s2.GetType());
        }
        public static bool operator !=(BaseShip s1, BaseShip s2)
        {
            return !(s1.Decks.Count.Equals(s2.Decks.Count) && s1.GetType().Equals(s2.GetType()));

        }
        public bool Equals(BaseShip s1)
        {
            return Decks.Count == s1.Decks.Count && GetType() == s1.GetType();

        }



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
            if (Speed > TravelDistance)
            {
                throw new Exception("Speed can be lower than TraveDistance");
            }
            if(Sea1.ShipSpaceCheck(NewPosition))
            {
                for (int i = 0; i < NewPosition.Count; i++)
                {
                    Decks[i].Location.X = NewPosition[i].X;
                    Decks[i].Location.Y = NewPosition[i].Y;
                }
            }
        }
    }
}