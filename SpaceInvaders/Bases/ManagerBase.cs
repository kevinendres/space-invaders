using System.Diagnostics;

namespace SpaceInvaders
{
    abstract class ManagerBase
    {
        public ManagerBase(ListBase _Active, ListBase _Reserve, int _delta, int _initialReserve)
        {
            Debug.Assert(_Active != null);
            Debug.Assert(_Reserve != null);
            Debug.Assert(_delta > 0);
            Debug.Assert(_initialReserve >= 0);

            poActive = _Active;
            poReserve = _Reserve;
            mDeltaGrow = _delta;

            privFillReserves(_initialReserve);
        }

        protected abstract NodeBase DerivedCreateNode();

        protected void ClearNode(NodeBase _node)
        {
            Debug.Assert(_node != null);
            _node.Clear();
        }

        protected void privFillReserves(int count)
        {
            for (int i = 0; i < count; ++i)
            {
                NodeBase node = DerivedCreateNode();
                poReserve.Add(node);
            }
            mTotalNodes += count;
            mNumReserve += count;
        }
        protected NodeBase AcquireFromBase() 
        { 
            if (mNumReserve == 0)
            {
                privFillReserves(mDeltaGrow);
            }
            Debug.Assert(poReserve != null);

            NodeBase node = poReserve.RemoveFront();
            Debug.Assert(node != null);
            
            node.Clear();
            poActive.Add(node);
            ++mNumActive;
            --mNumReserve;
            return node;
        }

        public NodeBase baseFind(NodeBase pNodeTarget)
        {
            IteratorBase pIt = poActive.GetIterator();
            NodeBase pNode = pIt.Begin();
            while (pIt.IsValid()) {
                if (pNode.Compare(pNodeTarget)) {
                    break;
                }
                pNode = pIt.Next();
            }

            return pNode;
        }

        protected void ReleaseToBase(NodeBase node)
        {
            Debug.Assert(node != null);
            poActive.Remove(node);
            node.Clear();
            poReserve.Add(node);
            --mNumActive;
            ++mNumReserve;
        }

        public void Remove(NodeBase node)
        {
            ReleaseToBase(node);
        }

        public void basePrint()
        {
            Debug.WriteLine("   --- " + this.ToString() + " Begin ---\n");

            Debug.WriteLine("         mDeltaGrow: {0} ", mDeltaGrow);
            Debug.WriteLine("     mTotalNumNodes: {0} ", mTotalNodes);
            Debug.WriteLine("       mNumReserved: {0} ", mNumReserve);
            Debug.WriteLine("         mNumActive: {0} \n", mNumActive);

            IteratorBase pItActive = poActive.GetIterator();
            Debug.Assert(pItActive != null);

            NodeBase pNodeActive = pItActive.Begin();
            if (pNodeActive == null) {
                Debug.WriteLine("    Active Head: null");
            } else {
                Debug.WriteLine("    Active Head: ({0})", pNodeActive.GetHashCode());
            }

            IteratorBase pItReserve = poReserve.GetIterator();
            Debug.Assert(pItReserve != null);

            NodeBase pNodeReserve = pItReserve.Begin();
            if (pNodeReserve == null) {
                Debug.WriteLine("   Reserve Head: null\n");
            } else {
                Debug.WriteLine("   Reserve Head: ({0})\n", pNodeReserve.GetHashCode());
            }

            Debug.WriteLine("   ------ Active List: -----------\n");


            int i = 0;
            NodeBase pData = pItActive.Begin();
            while (pItActive.IsValid()) {
                Debug.WriteLine("   {0}: -------------", i);
                pData.Print();
                i++;
                pData = pItActive.Next();
            }

            Debug.WriteLine("");
            Debug.WriteLine("   ------ Reserve List: ----------\n");

            i = 0;
            pData = pItReserve.Begin();
            while (pItReserve.IsValid()) {
                Debug.WriteLine("   {0}: -------------", i);
                pData.Print();
                i++;
                pData = pItReserve.Next();
            }

            Debug.WriteLine("   --- " + this.ToString() + " End ---\n");
        }

        public ListBase poActive;
        public ListBase poReserve;
        public readonly int mDeltaGrow;
        public int mTotalNodes;
        public int mNumActive;
        public int mNumReserve;
    }

}
