using System;

namespace SpaceInvaders
{
    class DropBombCommand : CommandBase
    {
        public DropBombCommand(GridComposite _pGrid)
        {
            pGrid = _pGrid;
            rand = new Random();
        }
        public override void Execute(float deltaTime)
        {
            if (pGrid.AlienCount > 0) {
                ColumnComposite pColumn = SelectColumn();
                pColumn.DropBomb();
                TimeEventManager.Add(deltaTime, this);
            }
        }
        public ColumnComposite SelectColumn()
        {
            ColumnComposite pColumn;
            //keep looping until you find a column that's ready
            while (true) {
                int limit = rand.Next() % pGrid.ColumnCount;
                IteratorBase pIt = pGrid.GetChildrenIterator();
                for (int i = 0; i < limit; ++i) {
                    pIt.Next();
                }
                pColumn = (ColumnComposite)pIt.Current();
                if (pColumn.BombReady == true && pColumn.AlienCount > 0) {
                    break;
                } else if (pGrid.ColumnCount < 3) {
                    break;
                }
            }

            return pColumn;
        }
        GridComposite pGrid;
        Random rand;
    }
}
