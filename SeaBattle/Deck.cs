using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle
{
    public class Deck
    {
        public Point Location;
        // State for decks true = Onfloat, false = Sank 
        public bool State { get; set; } = true;
    }
}
