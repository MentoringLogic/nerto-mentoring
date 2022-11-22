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
using System.Xml.Linq;

namespace SeaBattle
{
    public class BaseShip
    { 
        public List<Deck> Decks { get; set; }
        int Durability { get; set; }
        int MoveSpeed { get; set; }
        int MoveDirectionX { get; set; }
        int MoveDirectionY { get; set; }
        string Name { get; set; }
        int Speed { get; set; }
        
        public BaseShip(string Name, List<Point> points) {
            var Decks = new List<Deck>();

            for (int i = 0; i < points.Count - 1; i++)
            {
                Deck a = new Deck();
                a.Location = points[i];
                Decks.Add(a);
            }
        }
        public override string ToString()
        {
            string output = "Name: " + Name + ", ";
            output += "Type: " + this.GetType() + ", ";
            output += "Durability: " + Durability + ", ";
            output += "Speed: " + Speed + ", ";
            output += "Decks:" + Decks.Count + ", ";
            output += "Coordinates: ";
            foreach (var deck in Decks)
            {
                output +=  deck.Location.X + ":" + deck.Location.Y + ", ";
            }
            return output;
        }
        public static bool operator== (BaseShip s1, BaseShip s2)
        {
            return ((s1.Decks.Count == s2.Decks.Count) && (s1.GetType() == s2.GetType()));
        }
        public static bool operator!= (BaseShip s1, BaseShip s2)
        {  
            return !((s1.Decks.Count == s2.Decks.Count) && (s1.GetType() == s2.GetType()));

        }

        // To do in the MoveTo method  
        // 1. + calculating mid-ship coordinates of current position
        // 2. + calculating mid-ship coordinates of new position
        // 3. + calcualating distance of the move
        // 4. + checking if speed is enough to get to new position
        // 5. + checking if new position is available
        // 6. updating current position with new position
        // 7. return OK if everything was good
        public void MoveTo(List<Point> NewPosition)
        {
            float midShipX = 0;
            float midShipY = 0;
            foreach (var d in Decks)
            {
                midShipX += d.Location.X;
                midShipY += d.Location.Y;
            }
            midShipX = midShipX / Decks.Count;
            midShipY = midShipY / Decks.Count;

            float midNewX = 0;
            float midNewY = 0;
            foreach (var p in NewPosition)
            {
                midNewX += p.X;
                midNewY += p.Y;
            }
            midNewX = midNewX / NewPosition.Count;
            midNewY = midNewY / NewPosition.Count;

            float TravelX = (float) Math.Pow((midShipX - midNewX), 2);
            float TravelY = (float) Math.Pow((midShipY - midNewY), 2);
            float TravelDistance;
            TravelDistance = (float) Math.Sqrt(TravelX + TravelY);

            if (Speed < TravelDistance)
            {
                throw new Exception("Ship speed lower then distance");
            }
            
        }
    }
        
}   