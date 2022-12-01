using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class Bomb : GameObjectBase
    {
        public Bomb()
            : base(Name.BombZigZag, SpriteAdaptor.Name.BombZigZag, 0f, -100f) 
        {
            rand = new Random();
            pFallStrategy = FallStraight.GetInstance();
            fallSpeed = -9f;
        }

        public override void Accept(CollisionVisitor other)
        {
            other.Visit(this);
        }

        public override void Move(float _x, float _y)
        {
            x += _x;
            y += _y;
        }
        public override void Update()
        {
            Fall();
            base.Update();
        }
        public override void Remove()
        {
            if (pColumn != null) { 
                pColumn.BombReady = true;
            }
            y = -100f;
            base.Update();
        }
        public void Drop(float _x, float _y)
        {
            if (pColumn != null) {
                pColumn.BombReady = false;
            }
            x = _x;
            y = _y;
            previousY = _y;
        }
        public void SetColumn(ColumnComposite _pColumn)
        {
            pColumn = _pColumn;
        }
        public void SelectBombType()
        {
            int switcher = rand.Next() % 3;
            SpriteAdaptor pSprite;
            switch (switcher) {
                case 0:
                    pSprite = SpriteManager.Find(SpriteAdaptor.Name.BombCross);
                    pProxySprite.pSprite = pSprite;
                    pFallStrategy = FallRotate.GetInstance();
                    break;
                case 1:
                    pSprite = SpriteManager.Find(SpriteAdaptor.Name.BombStraight);
                    pProxySprite.pSprite = pSprite;
                    pFallStrategy = FallStraight.GetInstance();
                    break;
                case 2:
                    pSprite = SpriteManager.Find(SpriteAdaptor.Name.BombZigZag);
                    pProxySprite.pSprite = pSprite;
                    pFallStrategy = FallMirror.GetInstance();
                    break;
                default:
                    Debug.Assert(false);
                    break;
            }

        }
        public void MultiplyScale(float _sx, float _sy)
        {
            pProxySprite.sx *= _sx;
            pProxySprite.sy *= _sy;
        }
        public void Fall()
        {
            float flipY = previousY - 82f;
            if (y < flipY) {
                pFallStrategy.Fall(this);
                previousY = y;
            }
            Move(0, fallSpeed);
        }
        float previousY;
        float fallSpeed;
        ColumnComposite pColumn;
        FallStrategy pFallStrategy;
        Random rand;
    }
}
