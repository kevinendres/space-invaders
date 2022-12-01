using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    abstract class NodeBase
    {
        public abstract void Clear();
        public abstract void Print();
        virtual public object GetName()
        {
            return null;
        }
        virtual public bool Compare(NodeBase other)
        {
            Debug.Assert(false);
            return false;
        }
    }

}
