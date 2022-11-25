using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Security.Cryptography;
using System.Xml.Linq;

namespace SeaBattle
{
    public class Sea
    {
        public List<BaseShip> Ships { get; set; }
        public int SeaWidth;
        public int SeaHeight;

        // Property to provide indexer
        public BaseShip this[int i]
        {
            get {
                if (i > 0 && i < Ships.Count)
                    return Ships[i];
                else
                    throw new IndexOutOfRangeException();
            }
            // checking value is not null, checking value is in BaseShip family, checking Sea[i] is present
            set
            {
                if (value != null)
                    if (value is BaseShip)
                        if (i > 0 && i < Ships.Count)
                                Ships[i] = value;
                else
                    throw new Exception("Unable to add ship to the list");
            }
        }
        public override string ToString()
        {
            StringBuilder output = new StringBuilder("Height: ", 25);
            output.Append(SeaHeight + ", ");
            output.Append("Width: " + SeaWidth + ", ");
            output.Append("Ships: ");
            foreach (var s in Ships)
                output.Append(s.ToString());
            return output.ToString();
        }
    }
}
