using System.Diagnostics;

namespace SpaceInvaders
{
    class DLinkList : ListBase
    {
        public DLinkNode poHead;
        public DLinkIterator iterator;

        public DLinkList()
        {
            // LTN - DLinkList
            iterator = new DLinkIterator();
        }
        public override void Add(NodeBase _pNode)
        {
            Debug.Assert(_pNode != null);

            DLinkNode pNode = (DLinkNode)_pNode;
            pNode.next = poHead;
            if (poHead != null) {
                poHead.prev = pNode;
            }
            poHead = pNode;

        }
        public override void Remove(NodeBase _pNode)
        {
            Debug.Assert(_pNode != null);

            DLinkNode node = (DLinkNode)_pNode;
            if (node.next != null) {
                node.next.prev = node.prev;
            }
            if (node.prev != null) {
                node.prev.next = node.next;
            } else {
                poHead = poHead.next;
            }
        }

        public override NodeBase RemoveFront()
        {
            Debug.Assert(poHead != null);
            NodeBase oldHead = poHead;
            poHead = poHead.next;
            if (poHead != null) {
                poHead.prev = null;
            }
            return oldHead;
        }
        public override NodeBase Front()
        {
            return poHead;
        }
        public override IteratorBase GetIterator()
        {
            Debug.Assert(iterator != null);
            iterator.Reset(poHead);
            return iterator;
        }
        public override void Clear()
        {

        }
    }
}
