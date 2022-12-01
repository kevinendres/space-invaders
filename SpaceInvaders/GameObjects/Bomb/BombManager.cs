using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class BombManager : ManagerBase
    {
        private BombManager()
            : base(new DLinkList(), new DLinkList(), 10, 25)
        {
        }
        public static void Initialize(GridComposite _pGrid)
        {
            if (pInstance == null) {
                pInstance = new BombManager();
                pInstance.pGrid = _pGrid;
                pInstance.rand = new Random();
            }
        }
        private Bomb SelectBomb()
        {
            //returns bomb with appropriate sprite and fall behavior
            int switcher = rand.Next() % 3;
            Bomb pBomb = (Bomb)AcquireFromBase();
            pBomb.SelectBombType();
            return pBomb;
        }
        public static void DropBomb()
        {
            ColumnComposite pColumn = SelectColumn();
            if (pColumn.BombReady) {
                Bomb pBomb = pInstance.SelectBomb();
                pBomb.SetColumn(pColumn);
                BombGroup.Attach(pBomb);
                Debug.Assert(false);
                //pBomb.Drop();
            }
        }
        public static ColumnComposite SelectColumn()
        {
            IteratorBase pColumnIterator = pInstance.pGrid.GetChildrenIterator();
            int length = pInstance.rand.Next() % 11;
            for (int i = 0; i < length; ++i) {
                pColumnIterator.Next();
            }
            ColumnComposite pColumn = (ColumnComposite)pColumnIterator.Current();
            //if column doesn't already have bomb in air AND has children
            if (pColumn.BombReady && pColumn.GetChildrenIterator().Current() != null) {
                return pColumn;
            } else {
                pColumnIterator.Begin();
                pColumn = (ColumnComposite)pColumnIterator.Current();
                return pColumn;
            }

        }
        public static BombNode Add(Bomb pBomb)
        {
            BombNode pNode = (BombNode)pInstance.AcquireFromBase();
            pNode.Set(pBomb);
            return pNode;
        }
        public static void Remove(BombNode pBomb)
        {
            pInstance.ReleaseToBase(pBomb);
        }
        protected override NodeBase DerivedCreateNode()
        {
            return new BombNode();
        }
        ~BombManager()
        {
        }
        private static BombManager pInstance;
        GridComposite pGrid;
        Random rand;
    }
}
