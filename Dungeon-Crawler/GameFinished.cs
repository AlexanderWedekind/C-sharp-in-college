using System;

namespace Gamefinished
{
    public class GameFinished : Exception
    {
        public GameFinished() : base() {}
        public GameFinished(string message) : base(message) {}
        public GameFinished(string message, Exception innerException) : base(message, innerException) {} 


    }
}