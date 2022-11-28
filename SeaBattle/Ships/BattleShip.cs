using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
namespace SeaBattle
{
    public class BattleShip : BaseShip, IAttack
    {
        public BattleShip(string Name, List<Point> points) : base(Name, points)
        {

        }

        // Method Shoot is not implmented yet
        public void Shoot()
        {
            throw new NotImplementedException("Method shoot not implemented yet");
        }

    }
}
