using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle
{
    public class BaseShip
    {
        public BaseShip (string Name, List<PointStruct> points) { }
        private List<Deck> Decks { get; set; }
        int Durability;
        int MoveSpeed;
        int MoveDirectionX;
        int MoveDirectionY;

    }

    public class Deck
    {
        public PointStruct Location;

        // If 0 = SANK, 1 = AFLOAT.
        public int State;
    }

    interface IAttack
    {
        void Shoot();
    }
    interface IRepair
    {
        void Repair();
    }

    public class BattleShip : BaseShip, IAttack
    {
        public BattleShip(string Name, List<PointStruct> points) : base(Name, points) 
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

        void IAttack.Shoot() { 
        
        }

    }

    public class ServiceShip : BaseShip, IRepair
    {
        public ServiceShip(string Name, List<PointStruct> points) : base(Name, points)
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
        void IRepair.Repair()
        {
            
        }

    }

    public class HybridShip : BaseShip, IAttack, IRepair
    {
        public HybridShip(string Name, List<PointStruct> points) : base(Name, points)
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

        void IRepair.Repair() { }
        void IAttack.Shoot() { }
    }

    //public Point MoveTo(Point) { } this method will move Ships to the point. 
}


