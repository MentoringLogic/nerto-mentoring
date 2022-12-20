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

    public class ShipIsNotLineException : Exception
    {
        public ShipIsNotLineException()
        {
        }

        public ShipIsNotLineException(string message)
            : base(message)
        {
            message = "Ship is not a line";
        }

        public ShipIsNotLineException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }

    public class SeaBordersException : Exception
    {
        public SeaBordersException()
        {
        }

        public SeaBordersException(string message)
            : base(message)
        {
            message = "Ship can not exsist with this Sea borders";
        }

        public SeaBordersException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }

}
