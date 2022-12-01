using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class TimeEventManager : ManagerBase
    {
        private TimeEventManager()
            // LTN - TimeEventManager owns both of these through ManagerBase
            : base(new OrderedDLinkList(), new DLinkList(), 5, 5)
        {
        }
        public static void Initialize()
        {
            Debug.Assert(pManagerInstance == null);
            if (pManagerInstance == null) {
                // LTN - TimeEventManager
                pManagerInstance = new TimeEventManager();
                mCurrentTime = 0;
            }
        }

        public static TimeEvent Add(float deltaTime, CommandBase command)
        {
            float triggerTime = mCurrentTime + deltaTime;
            TimeEvent timeEvent = (TimeEvent)AcquireFromBase(triggerTime);
            Debug.Assert(timeEvent != null);
            timeEvent.Set(deltaTime, command);
            return timeEvent;
        }
        protected static NodeBase AcquireFromBase(float _key) 
        { 
            if (pManagerInstance.mNumReserve == 0)
            {
                pManagerInstance.privFillReserves(pManagerInstance.mDeltaGrow);
            }
            Debug.Assert(pManagerInstance.poReserve != null);

            NodeBase node = pManagerInstance.poReserve.RemoveFront();
            Debug.Assert(node != null);
            
            node.Clear();
            ((OrderedDLinkList)pManagerInstance.poActive).Add(node, _key);
            ++pManagerInstance.mNumActive;
            --pManagerInstance.mNumReserve;
            return node;
        }
        public static void Remove(TimeEvent timeEvent)
        {
            pManagerInstance.ReleaseToBase(timeEvent);
        }
        protected override NodeBase DerivedCreateNode()
        {
            // LTN - TimeEventManager through ManagerBase
            return new TimeEvent();
        }

        public static void Update(float currentTime)
        {
            mCurrentTime = currentTime;
            OrderedDLinkIterator pIt = (OrderedDLinkIterator)pManagerInstance.poActive.GetIterator();
            while (pIt.IsValid() && pIt.current.key <= currentTime) {
                TimeEvent tEvent = (TimeEvent)pIt.current;
                tEvent.Execute();
                //advance to next item before removing the current from the list
                pIt.Next();
                Remove(tEvent);
            }
        }

        public static float GetCurrTime()
        {
            return mCurrentTime;
        }
        public static void Reset()
        {
            pManagerInstance = new TimeEventManager();
        }

        private static TimeEventManager pManagerInstance;
        private static float mCurrentTime;
    }
}

