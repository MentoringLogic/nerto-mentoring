using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle
{
    
        class BaseShip
        {
            int Durability;
            int MoveSpeed;
            int MoveDirectionX;
            int MoveDirectionY;
        }



        interface IAttack
        {
            void Shoot();
        }
        interface IRepair
        {
            void Repair();
        }

        public class BattleShip : IAttack
        {
            void IAttack.Shoot() { }

        }

        public class ServiceShip : IRepair
        {
            void IRepair.Repair() { }

        }

        public class HybridShip : IAttack, IRepair
        {
            void IRepair.Repair() { }
            void IAttack.Shoot() { }
        }
 }


