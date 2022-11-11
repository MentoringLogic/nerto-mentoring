using SeaBattle;
using System;
using System.Security.Cryptography.X509Certificates;

namespace SeaBattle
{
    class Program {
        static void Main()
        {
            BattleShip MyBattleShip = new BattleShip();
            Sea MySea = new Sea();

            void AddShipToList()
            {
                
                //ShipsAdd;

            }
        }
    }
}

// if (sea.ship is BattleShip)
// {
//   BattleShip a = (BattleShip)sea.ship;
//    a.attack();
// }
// else if (sea.ship is ServiceShip)
// {
//    ServiceShip b = (ServiceShip)sea.ship;
//    b.Repair();
// }
// else if (sea.ship is HybridShip)
// {
//    HybridShip c = (HybridShip)sea.ship;
//  c.attack && c.repair;
// }