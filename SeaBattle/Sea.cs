using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle
{
    public class Sea
    {
        private List<Deck> Decks { get; set; }
        private List<BaseShip> Ships { get; set; }
        int SeaWidth;
        int SeaLenght;



        public void Create()
        {
            //will finish this IF parts tommorow. 
            //if ( > 10 &&  > 10)
            //{
            //}

            for (int i = 0; i < Ships.Count; i++)
            {
                for (int j = 0; j < Decks.Count; j++)
                {

                }

            }

            var items = new List<PointStruct>(4);

            items.Add(new PointStruct() { X = 2, Y = 1 });
            items.Add(new PointStruct() { X = 2, Y = 2 });
            items.Add(new PointStruct() { X = 2, Y = 3 });
            items.Add(new PointStruct() { X = 2, Y = 4 });

            var zxc = new List<PointStruct>(2);

            zxc.Add(new PointStruct() { X = 6, Y = 2 });
            zxc.Add(new PointStruct() { X = 3, Y = 3 });

            var RepairerShip = new List<PointStruct>(3);

            RepairerShip.Add(new PointStruct() { X = 6, Y = 7 });
            RepairerShip.Add(new PointStruct() { X = 6, Y = 8 });
            RepairerShip.Add(new PointStruct() { X = 6, Y = 9 });

            var ImAHealerShip = new List<PointStruct>(3);

            ImAHealerShip.Add(new PointStruct() { X = 8, Y = 7 });
            ImAHealerShip.Add(new PointStruct() { X = 8, Y = 8 });
            ImAHealerShip.Add(new PointStruct() { X = 8, Y = 9 });

            var Hybrydo = new List<PointStruct>(3);

            Hybrydo.Add(new PointStruct() { X = 2, Y = 5 });
            Hybrydo.Add(new PointStruct() { X = 3, Y = 5 });
            Hybrydo.Add(new PointStruct() { X = 4, Y = 5 });

            var tendari = new List<PointStruct>(3);

            tendari.Add(new PointStruct() { X = 3, Y = 9 });
            tendari.Add(new PointStruct() { X = 2, Y = 9 });
            tendari.Add(new PointStruct() { X = 1, Y = 9 });

            //I am creating 1  x4deck and 1 x2deck BattleShip, 2 x3deck Serviceship, 1 x2deck and x4deck ServiceShip.
            BattleShip ship1 = new BattleShip("Yamato", items);
            BattleShip ship2 = new BattleShip("Yamamoto", zxc);
            ServiceShip ship3 = new ServiceShip("Repairer", RepairerShip);
            ServiceShip ship4 = new ServiceShip("ImAHealer", ImAHealerShip);
            HybridShip ship5 = new HybridShip("Hybrydo", Hybrydo);
            HybridShip ship6 = new HybridShip("tendari", tendari);
        }
        //this method will get BaseShip by its INDEX from list. 
        public BaseShip GetShipByIndex(int i)
        {
            BaseShip ship = Ships[i];
            if (i < Ships.Count + 1)
                return Ships[i];
            else
                return null;

        }
    }
}

