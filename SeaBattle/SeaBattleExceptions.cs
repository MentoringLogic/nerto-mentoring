using System;
using System.Collections.Generic;
using System.Text;

namespace SeaBattle
{
    public class ShipCantMoveException : Exception
    {
        public ShipCantMoveException()
        {
        }

        public ShipCantMoveException(string message)
            : base(message)
        {
            message = "Ship can`t move";
        }

        public ShipCantMoveException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
