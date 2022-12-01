using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class BombNode : DLinkNode
    {
        public BombNode()
        {
        }
        public override void Print()
        {
            Debug.Assert(false);
        }
        public void Set(Bomb _pBomB)
        {
            pBomb = _pBomB;
        }

        Bomb pBomb;
    }
}
