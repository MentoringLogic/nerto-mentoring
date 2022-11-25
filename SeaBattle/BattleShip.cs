using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle
{
    public class BattleShip : BaseShip, IAttack
    {
        public BattleShip(string Name, List<Point> points) : base(Name, points) 
        {
        
        }   
        
        // Method Shoot is not implmented yet
        public void Shoot() {
            throw new NotImplementedException("Method shoot not implemented yet");
        }

    }
}
