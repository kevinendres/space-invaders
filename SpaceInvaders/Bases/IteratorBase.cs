namespace SpaceInvaders
{
    abstract class IteratorBase
    {
        public abstract NodeBase Next();
        public abstract NodeBase Begin();
        public abstract NodeBase Current();
        public abstract bool IsValid();
        public abstract void Reset(NodeBase _pBegin);
    }
}
