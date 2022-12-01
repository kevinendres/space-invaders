using System;

namespace SpaceInvaders
{
    abstract class ListBase
    {
        public abstract void Add(NodeBase node);
        public abstract void Remove(NodeBase node);
        public abstract NodeBase RemoveFront();
        public abstract NodeBase Front();
        public abstract IteratorBase GetIterator();
        public abstract void Clear();
    }
}
