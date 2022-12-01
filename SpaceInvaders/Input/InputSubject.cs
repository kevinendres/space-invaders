using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class InputSubject 
    {
        public void Attach(InputObserver pObserver)
        {
            Debug.Assert(pObserver != null);

            pObserver.pSubject = this;

            poListeners.Add(pObserver);
        }


        public void Notify()
        {
            IteratorBase pIt = poListeners.GetIterator();

            InputObserver pObserver = (InputObserver)pIt.Current();

            while (pIt.IsValid()) {
                pObserver = (InputObserver)pIt.Current();
                pObserver.Notify();
                pIt.Next();
            }

        }

        DLinkList poListeners = new DLinkList();
    }
}
