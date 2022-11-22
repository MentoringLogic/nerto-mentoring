﻿using System;
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
        // Property to provide indexer
        public BaseShip this[int i]
        {
            get {
                if (i > 0 && i < Ships.Count)
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

        public override string ToString()
        {
            string output = "Height: " + SeaHeight + ", ";
            output += "Width: " + SeaWidth + ", ";
            output += "Ships: ";
            foreach (var s in Ships)
                output += s.ToString();
            return output;
        }
    }
}
