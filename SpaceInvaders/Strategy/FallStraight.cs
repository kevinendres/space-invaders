using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class FallStraight : FallStrategy
    {
        public override void Fall(Bomb pBomb)
        {
            // do nothing
        }
        public static FallStraight GetInstance()
        {
            if (pInstance == null) {
                pInstance = new FallStraight();
            }
            return pInstance;
        }
        static FallStraight pInstance;
    }
}
