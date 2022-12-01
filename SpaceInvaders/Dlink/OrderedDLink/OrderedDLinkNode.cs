using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    abstract class OrderedDLinkNode : DLinkNode
    {
        public float key;

        public override void Clear()
        {
            next = null;
            prev = null;
            key = 999f;
        }
    }
}
