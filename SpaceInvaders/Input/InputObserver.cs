using System;

namespace SpaceInvaders
{
    abstract class InputObserver : DLinkNode
    {
        public abstract void Notify();
        public override void Print()
        {
            throw new NotImplementedException();
        }
        public InputSubject pSubject;
    }
}
