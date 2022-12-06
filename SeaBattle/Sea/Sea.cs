using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
namespace SeaBattle
{
    public class Sea
    {
        private List<BaseShip> Ships { get; set; }
        public int SeaWidth;
        public int SeaHeight;
        public Sea(int x, int y)
        {
            SeaWidth = x;
            SeaHeight = y;
            Ships = new List<BaseShip>();
        }
        // Property to provide indexer
        public BaseShip this[int i]
        {
            get
            {
                if (i >= 0 && i < Ships.Count)
                    return Ships[i];
                else
                    throw new IndexOutOfRangeException();
            }
            // checking value is not null, checking value is in BaseShip family, checking Sea[i] is present
            set
            {
                if (value != null)
                    if (value is BaseShip)
                        if (i > 0 && i < Ships.Count)
                            Ships[i] = value;
                        else
                            throw new Exception("Unable to add ship to the list");
            }
        }
        // This function adds s1(BaseShip) to the Sea
        // 1. + Checking if Point within Sea borders
        // 2. + Checking if Point is available 
        public void AddShip(BaseShip s1)
        {
            List<Point> NewLocations = new List<Point>();
            foreach (var deck in s1.Decks)
            {
                NewLocations.Add(new Point(deck.Location.X, deck.Location.Y));

                if (deck.Location.X > SeaWidth || deck.Location.Y > SeaHeight || deck.Location.X <= 0 || deck.Location.Y <= 0)

                    throw new Exception("Ship can not exsist with this Sea borders");
            }
            if (IsPlaceAvailable(NewLocations))

                Ships.Add(s1);
        }

        public bool IsPlaceAvailable(List<Point> DecksPoints)
        {
            foreach (var deck in DecksPoints)
            {
                foreach (var ship in Ships)
                {
                    if (ship.IsShipOnPoint(new Point (deck.X, deck.Y)))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder("Height: ", 25);
            output.Append(SeaHeight + ", ");
            output.Append("Width: " + SeaWidth + ", ");
            output.Append("Ships: ");
            foreach (var s in Ships)
                output.Append(s.ToString());
            return output.ToString();
        }
    }
}