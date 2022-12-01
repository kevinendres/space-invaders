using System;

namespace SpaceInvaders
{
    class FallRotate : FallStrategy
    {
        public FallRotate()
        {
        }
        public override void Fall(Bomb pBomb)
        {
            pBomb.MultiplyScale(1f, -1f);
        }
        public static FallRotate GetInstance()
        {
            if (pInstance == null) {
                pInstance = new FallRotate();
            }
            return pInstance;
        }
        static FallRotate pInstance;
    }
}
