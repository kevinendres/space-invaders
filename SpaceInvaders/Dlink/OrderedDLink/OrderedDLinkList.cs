using System.Diagnostics;

namespace SpaceInvaders
{
    class OrderedDLinkList : ListBase
    {
        public DLinkNode poHead;
        public OrderedDLinkIterator iterator;

        public OrderedDLinkList()
        {
            // LTN - OrderedDLinkList
            iterator = new OrderedDLinkIterator();
        }
        public override void Add(NodeBase _pNode)
        {
            Debug.Assert(_pNode != null);

            Add(_pNode, 999);
        }

        public void Add(NodeBase _pNode, float _priority)
        {
            Debug.Assert(_pNode != null);

            OrderedDLinkNode pNode = (OrderedDLinkNode)_pNode;
            pNode.key = _priority;
            //Empty list
            if (poHead == null) {
                poHead = pNode;
                pNode.next = null;
                pNode.prev = null;
            }
            else {
                OrderedDLinkNode pIt = (OrderedDLinkNode)poHead;
                while(pIt != null) { 
                    // Add anywhere except after last node
                    if (pIt.key >= pNode.key) {
                        //insert before pTmp
                        pNode.next = pIt;
                        pNode.prev = pIt.prev;
                        //update surrounding nodes
                        if (pIt.prev != null) { 
                            pIt.prev.next = pNode;
                        }
                        else {
                            poHead = pNode;
                        }
                        pIt.prev = pNode;
                        break;
                    }
                    // add to end of list
                    if (pIt.next == null) {
                        pIt.next = pNode;
                        pNode.prev = pIt;
                        pNode.next = null;
                        break;
                    } else {
                        pIt = (OrderedDLinkNode)pIt.next;
                    }
                }
            }
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
