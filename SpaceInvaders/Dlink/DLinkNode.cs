using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    abstract class DLinkNode : NodeBase
    {
        public DLinkNode next;
        public DLinkNode prev;

        public override void Clear()
        {
            next = null;
            prev = null;
        }


        public void basePrint()
        {
            if (this.prev == null) {
                Debug.WriteLine("      prev: null");
            } else {
                NodeBase pTmp = (NodeBase)this.prev;
                Debug.WriteLine("      prev: {0} ({1})", pTmp.GetName(), pTmp.GetHashCode());
            }

            if (this.next == null) {
                Debug.WriteLine("      next: null");
            } else {
                NodeBase pTmp = (NodeBase)this.next;
                Debug.WriteLine("      next: {0} ({1})", pTmp.GetName(), pTmp.GetHashCode());
            }
        }

    }
}
