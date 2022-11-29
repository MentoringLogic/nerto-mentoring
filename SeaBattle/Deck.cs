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
    }
}
