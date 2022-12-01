using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class Player : Leaf
    {
        public Player(float x, float y)
            : base(Name.Player, SpriteAdaptor.Name.Player, x, y) 
        {
            ExtraLife1 = ProxySpriteManager.Add(ProxySprite.Name.Proxy, 80, 20, SpriteManager.Find(SpriteAdaptor.Name.Player));
            ExtraLife2 = ProxySpriteManager.Add(ProxySprite.Name.Proxy, 150, 20, SpriteManager.Find(SpriteAdaptor.Name.Player));
            pBatch = SpriteBatchManager.GetTopBatch();
            pBatch.Attach(ExtraLife1);
            pBatch.Attach(ExtraLife2);
        }
        public override void Move(float _x, float _y)
        {
            x += _x;
            y += _y;
        }
        public override void Accept(CollisionVisitor other)
        {
            other.Visit(this);
        }

        public void MoveLeft()
        {
            pMovementState.MoveLeft(this);
        }
        public void MoveRight()
        {
            pMovementState.MoveRight(this);
        }
        public void Shoot()
        {
            pMissileState.Shoot(this);
        }
        public void SetMissileState(MissileState _state)
        {
            pMissileState = _state;
        }
        public void SetMovementState(MovementState _state)
        {
            pMovementState = _state;
        }
        public override void Visit(Bomb bomb)
        {
            CollisionPair pCurrentPair = CollisionPairManager.GetActiveCollisionPair();
            pCurrentPair.SetPair(this, bomb);
            pCurrentPair.Notify();
        }
        public void LoseOneLife()
        {
            PlayerManager.lives--;
            if (PlayerManager.lives == 2) {
                pBatch.Detach(ExtraLife2.GetContainer());
            }
            else if (PlayerManager.lives == 1) {
                pBatch.Detach(ExtraLife1.GetContainer());
            }
            Text pLifeCountText = TextManager.GetLifeCountText();
            pLifeCountText.UpdateMessage(PlayerManager.lives.ToString());
        }
        public override void Remove()
        {
            if (PlayerManager.lives > 0) {
                x = 50;
                PlayerManager.ChangeMovementState(MovementState.Name.Ready);
            }
            else {
                SpaceInvaders.poSceneContext.CycleState();
            }
        }
        public void NextLevel()
        {
            pBatch = SpriteBatchManager.Add(5f);
            switch (PlayerManager.lives) {
                case 3:
                    pBatch.Attach(ExtraLife1);
                    pBatch.Attach(ExtraLife2);
                    break;
                case 2:
                    pBatch.Attach(ExtraLife1);
                    break;
                default:
                    break;

            }
        }

        public float deltaX = 7f;
        public Missile poMissile;
        MissileState pMissileState;
        MovementState pMovementState;
        SpriteBatch pBatch;
        ProxySprite ExtraLife1;
        ProxySprite ExtraLife2;
        public int score = 0;
    }
}
