using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
namespace SeaBattle
{
    public class Deck
    {
        public Point Location;
        // State for decks true = Onfloat, false = Sank 
        public bool IsAlive { get; set; } = true;
        public bool HasCoordinatesIntersect(List<Deck> Decks)
        {
            return Decks.Any(x => x.Location == Location);
        }
    }
}
