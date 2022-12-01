using System;

namespace SpaceInvaders
{
    class ShieldGrid : GridComposite
    {
        public ShieldGrid(ProxySprite proxy, float x, float y)
            : base(proxy, x, y) { }
            
        public ShieldGrid CreateShield(GridFactory pGridFactory, ShieldFactory SF)
        {
            //create columns
            for (int i = 0; i < 4; ++i) {
                AttachChildren(pGridFactory.Create(Name.ShieldColumn, 0f, 0f));
            }
            float width = 20f;
            float offX = 0f;
            float height = 16f;

            IteratorBase pIt = GetChildrenIterator();
            ShieldColumn pColumn = (ShieldColumn)pIt.Current();

            //Column 1
            pColumn.AttachChildren(SF.Create(SpriteAdaptor.Name.LeftBrick, x + offX, y));
            pColumn.AttachChildren(SF.Create(SpriteAdaptor.Name.LeftBrick, x + offX, y + height));
            pColumn.AttachChildren(SF.Create(SpriteAdaptor.Name.LeftBrick, x + offX, y + 2 * height));
            pColumn.AttachChildren(SF.Create(SpriteAdaptor.Name.LeftTopBrick, x + offX, y + 3 * height));

            offX += width;
            width = 22f;
            pColumn = (ShieldColumn)pIt.Next();
            //Column 2
            pColumn.AttachChildren(SF.Create(SpriteAdaptor.Name.MidLeftBottom, x + offX, y));
            pColumn.AttachChildren(SF.Create(SpriteAdaptor.Name.MidBrick, x + offX, y + height));
            pColumn.AttachChildren(SF.Create(SpriteAdaptor.Name.MidBrick, x + offX, y + 2 * height));
            pColumn.AttachChildren(SF.Create(SpriteAdaptor.Name.MidBrick, x + offX, y + 3 * height));

            offX += width;
            pColumn = (ShieldColumn)pIt.Next();
            //Column 3
            pColumn.AttachChildren(SF.Create(SpriteAdaptor.Name.MidRightBottom, x + offX, y));
            pColumn.AttachChildren(SF.Create(SpriteAdaptor.Name.MidBrick, x + offX, y + height));
            pColumn.AttachChildren(SF.Create(SpriteAdaptor.Name.MidBrick, x + offX, y + 2 * height));
            pColumn.AttachChildren(SF.Create(SpriteAdaptor.Name.MidBrick, x + offX, y + 3 * height));

            offX += width;
            pColumn = (ShieldColumn)pIt.Next();
            //Column 4
            pColumn.AttachChildren(SF.Create(SpriteAdaptor.Name.RightBrick, x + offX, y));
            pColumn.AttachChildren(SF.Create(SpriteAdaptor.Name.RightBrick, x + offX, y + height));
            pColumn.AttachChildren(SF.Create(SpriteAdaptor.Name.RightBrick, x + offX, y + 2 * height));
            pColumn.AttachChildren(SF.Create(SpriteAdaptor.Name.RightTopBrick, x + offX, y + 3 * height));

            return this;
        }
        public override void Update()
        {
            CollisionRectangle localRect = poCollisionObject.poCollisionRectangle;
            IteratorBase pIt = GetChildrenIterator();
            ShieldColumn tmpCol = (ShieldColumn)pIt.Current();
            Reset();
            while (pIt.IsValid()) {
                tmpCol.Update();

                //If the Column has no Aliens in it, don't union it's Rectangle
                //It resets the X,Y to 0,0 which will extend the grid's Rectangle to include that
                if (tmpCol.poCollisionObject.poCollisionRectangle.width != 0 && 
                    tmpCol.poCollisionObject.poCollisionRectangle.height != 0) {

                    localRect.Union(tmpCol.poCollisionObject.poCollisionRectangle);
                }
                tmpCol = (ShieldColumn)pIt.Next();
            }
            poCollisionObject.UpdatePosition(poCollisionObject.poCollisionRectangle.x, poCollisionObject.poCollisionRectangle.y);
        }
        public override void Visit(Bomb bomb)
        {
            IteratorBase pColumIterator = GetChildrenIterator();
            GameObjectBase pCurrent;
            while (pColumIterator.IsValid()) {
                pCurrent = (GameObjectBase)pColumIterator.Current();
                if (CollisionRectangle.Intersect(pCurrent, (GameObjectBase)bomb)) {
                    pCurrent.Visit(bomb);
                    break;
                }
                pColumIterator.Next();
            }
        }
    }
}
