using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceRpgServer
{
    class GameException : Exception
    {
        public GameException(String msg):base(msg)
        {
        }
    }
}
