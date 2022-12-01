using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class NodeManager : ManagerBase
    {
        public NodeManager(ListBase _active, ListBase _reserve, int _delta, int _initialReserve)
            : base(_active, _reserve, _delta, _initialReserve)
        {
        }

        protected override NodeBase DerivedCreateNode()
        {
            // LTN - NodeManager
            return new Node();
        }

        public NodeBase Find(NodeBase _node)
        {
            return null;
        }
    }
}
