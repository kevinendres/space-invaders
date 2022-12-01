using System;

namespace SpaceInvaders
{
    abstract class SubjectBase
    {
        public virtual void Notify()
        {
            IteratorBase pIt = poSubscribers.GetIterator();
            ObserverBase pCurrent;
            while (pIt.IsValid()) {
                pCurrent = (ObserverBase)pIt.Current();
                pCurrent.Notify();
                pIt.Next();
            }
        }
        public virtual void Attach(ObserverBase observer)
        {
            observer.SetSubject(this);
            poSubscribers.Add(observer);
        }
        DLinkList poSubscribers = new DLinkList();
    }
}
