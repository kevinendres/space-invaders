using System;

namespace SpaceInvaders
{
    abstract class ObserverBase : DLinkNode
    {
        public abstract void Notify();
        public abstract void SetSubject(SubjectBase _subject);
        public override void Print()
        {
            throw new NotImplementedException();
        }
    }
}
