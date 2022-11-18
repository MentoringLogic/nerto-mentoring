using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle
{
    public class HybridShip : BaseShip, IAttack, IRepair
    {
        public HybridShip(string Name, List<Point> points)
        {
            var Decks = new List<Deck>();

            for (int i = 0; i < points.Count - 1; i++)
            {
                Deck a = new Deck();
                a.Location = points[i];
                Decks.Add(a);
                a.State = 1;
            }
        }

        void Repair() { }
        void Shoot() { }
    }
}
