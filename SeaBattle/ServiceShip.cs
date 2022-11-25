using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle
{
    public class ServiceShip : BaseShip, IRepair
    {
        public ServiceShip(string Name, List<Point> points) : base(Name, points)
        {
            
        }
        
        // Method Repair is not implmented yet
        public void Repair()
        {
            throw new NotImplementedException("Method repair not implemented yet");
        }

    }
}
