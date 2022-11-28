using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
namespace SeaBattle
{
    public class Sea
    {
        public List<BaseShip> Ships { get; set; }
        public int SeaWidth;
        public int SeaHeight;

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
            foreach (var deck in s1.Decks)
            {
                if (deck.Location.X > SeaWidth || deck.Location.Y > SeaHeight || deck.Location.X < 0 || deck.Location.Y < 0)

                    throw new Exception("Ship can not exsist with this Sea borders");
            }
            if (ShipSpaceCheck(s1.Decks))
            {
                Ships.Add(s1);
            }
        }
        public bool ShipSpaceCheck(List<Deck> myDecks)
        {
            foreach (var deck in myDecks)
            {
                foreach (var ship in Ships)
                {
                    foreach (var point in ship.Decks)
                    {
                        // If this true - point is occupied so thats why it returns false 
                        if (deck.Location.X == point.Location.X && deck.Location.Y == point.Location.Y)
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
