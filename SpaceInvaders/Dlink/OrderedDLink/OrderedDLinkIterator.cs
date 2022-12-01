using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class OrderedDLinkIterator : IteratorBase
    {
        public OrderedDLinkNode current;
        public OrderedDLinkNode head;

        public override NodeBase Next()
        {
            Debug.Assert(current != null);
            current = (OrderedDLinkNode)current.next;
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
            current = (OrderedDLinkNode)_pBegin;
            head = (OrderedDLinkNode)_pBegin;
        }
    }
}
