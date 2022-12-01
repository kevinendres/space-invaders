using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    abstract class FallStrategy
    {
        public abstract void Fall(Bomb pBomb);

        ~FallStrategy()
        {
        }
    }
}
