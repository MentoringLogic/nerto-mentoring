using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Reflection;

namespace SeaBattle
{
    public class BaseShip
    { 
        public List<Deck> Decks { get; set; }
        int Durability { get; set; }
        int MoveSpeed { get; set; }
        int MoveDirectionX { get; set; }
        int MoveDirectionY { get; set; }
        
        public BaseShip(string Name, List<Point> points) {
            var Decks = new List<Deck>();

            for (int i = 0; i < points.Count - 1; i++)
            {
                Deck a = new Deck();
                a.Location = points[i];
                Decks.Add(a);
            }
        }
        
}
    //public Point MoveTo(Point) { } this method will move Ships to the point. 
}   