using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class DLinkIterator : IteratorBase
    {
        public DLinkNode current;
        public DLinkNode head;

        public override NodeBase Next()
        {
            Debug.Assert(current != null);
            current = current.next;
            return current;
        }
        public override bool IsValid()
        {
            return current != null;
        }
        public override NodeBase Begin()
        {
            return head;
        }
        public override NodeBase Current()
        {
            return current;
        }
        public override void Reset(NodeBase _pBegin)
        {
            current = (DLinkNode)_pBegin;
            head = (DLinkNode)_pBegin;
        }
    }
}
