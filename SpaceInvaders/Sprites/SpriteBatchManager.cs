using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class SpriteBatchManager : ManagerBase
    {
        private SpriteBatchManager()
            // LTN - SpriteBatchManager through ManagerBase
            : base(new OrderedDLinkList(), new DLinkList(), 5, 20)
        { 
        }
        public static void Initialize()
        {
            Debug.Assert(pManagerInstance == null);
            if (pManagerInstance == null) {
                // LTN - SpriteBatchManager Singleton
                pManagerInstance = new SpriteBatchManager();
            }
        }

        public static SpriteBatch Add(float key)
        {
            // -------------------------
            // Because sprite batches have priorities we'll need to change
            // the way they're added to the base
            // -------------------------
            SpriteBatch spriteBatch = (SpriteBatch)AcquireFromBase(key);
            Debug.Assert(spriteBatch != null);
            spriteBatch.Set(key);
            return spriteBatch;
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
        public static void Remove(SpriteAdaptor sprite)
        {
            pManagerInstance.ReleaseToBase(sprite);
        }
        public static void Remove(SpriteBatch spriteBatch)
        {
            pManagerInstance.ReleaseToBase(spriteBatch);
        }

        protected override NodeBase DerivedCreateNode()
        {
            // LTN - SpriteBatchManager through ManagerBase
            return new SpriteBatch();
        }
        public static void Print()
        {
            Debug.Assert(pManagerInstance != null);
            pManagerInstance.basePrint();
        }

        public static void Update()
        {
            IteratorBase pIt = pManagerInstance.poActive.GetIterator();
            SpriteBatch pTmp = (SpriteBatch)pIt.Begin();
            while (pIt.IsValid()) {
                pTmp.Update();
                pTmp = (SpriteBatch)pIt.Next();
            }
        }

        public static void Render()
        {
            IteratorBase pIt = pManagerInstance.poActive.GetIterator();
            SpriteBatch pTmp = (SpriteBatch)pIt.Begin();
            while (pIt.IsValid()) {
                pTmp.Render();
                pTmp = (SpriteBatch)pIt.Next();
            }

        }
        public static void Reset()
        {
            pManagerInstance = new SpriteBatchManager();
        }
        public static void TurnOffBoxes()
        {
            IteratorBase pIt = pManagerInstance.poActive.GetIterator();
            SpriteBatch pCurrent = (SpriteBatch)pIt.Current();
            while (pIt.IsValid()) {
                if (pCurrent.isSpriteBoxBatch) {
                    pCurrent.ToggleDrawing();
                }
                pCurrent = (SpriteBatch)pIt.Next();
            }
        }
        public static SpriteBatch GetSpriteBoxBatch()
        {
            IteratorBase pIt = pManagerInstance.poActive.GetIterator();
            SpriteBatch pCurrent = (SpriteBatch)pIt.Current();
            while (pIt.IsValid()) {
                if (pCurrent.isSpriteBoxBatch) {
                    break;
                }
                pCurrent = (SpriteBatch)pIt.Next();
            }
            return pCurrent;
        }
        public static SpriteBatch GetTopBatch()
        {
            return (SpriteBatch)pManagerInstance.poActive.GetIterator().Current();
        }

        private static SpriteBatchManager pManagerInstance;

    }
}
