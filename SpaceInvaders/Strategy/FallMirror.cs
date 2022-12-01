using System;

namespace SpaceInvaders
{
    class FallMirror : FallStrategy
    {
        private FallMirror()
        {
        }
        public static FallStrategy GetInstance()
        {
            if (pInstance == null) {
                pInstance = new FallMirror();
            }
            return pInstance;
        }
        public override void Fall(Bomb pBomb)
        {
            pBomb.MultiplyScale(-1f, 1f);
        }
        static FallMirror pInstance;
    }
}
