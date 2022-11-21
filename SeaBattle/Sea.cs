using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Security.Cryptography;

namespace SeaBattle
{
    public class Sea
    {
        private List<BaseShip> Ships { get; set; }
        public int SeaWidth;
        public int SeaHeight;

        // This function adds s1(BaseShip) to the Sea
        // Checking if Point is available 
        // Checking if Point within Sea borders
        public void AddShip(BaseShip s1)
        {
            for (int i = 0; i < Ships.Count; i++)
            {
                for (int j = 0; j < Ships[i].Decks.Count; j++)
                {
                    if (s1.Decks[i].Location.X < SeaWidth && s1.Decks[i].Location.Y < SeaHeight && s1.Decks[i].Location.X > 0 && s1.Decks[i].Location.Y > 0) ;


                }

            }

            Ships.Add(s1);
        }
        // To enable client code to validate input when accessing your indexer
        public int Count => Ships.Count;
        public BaseShip this[int i]
        {
            get { return Ships[i]; }
            set { Ships[i] = value;}
        }
    }
}
