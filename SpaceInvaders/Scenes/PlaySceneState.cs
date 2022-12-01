using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class PlaySceneState : SceneState
    {
        public PlaySceneState()
        {
            name = SceneContext.Scene.Play;
        }
        public override void Draw()
        {
            SpriteBatchManager.Render();
        }

        public override void Entering()
        {
            this.Initialize();
        }

        public override void Handle()
        {
            throw new NotImplementedException();
        }

        public override void Initialize()
        {
            //-------------------------------------------------------------------------
            // Sprite Batches
            //-------------------------------------------------------------------------

            SpriteBatch pAlienBatch = SpriteBatchManager.Add(90f);
            SpriteBatch pCrabBatch = SpriteBatchManager.Add(90f);
            SpriteBatch pSquidBatch = SpriteBatchManager.Add(90f);
            SpriteBatch pSpriteBoxBatch = SpriteBatchManager.Add(30f);
            pSpriteBoxBatch.isSpriteBoxBatch = true;
            pSpriteBoxBatch.ToggleDrawing();
            SpriteBatch pPlayerSpriteBatch = SpriteBatchManager.Add(1f);
            SpriteBatch pBombBatch = SpriteBatchManager.Add(10f);

            //---------------------------------------------------------------------------------------------------------
            // Create Images
            //---------------------------------------------------------------------------------------------------------
            Texture pAlienTexture = TextureManager.GetTexture();

            // --- aliens ---

            Image pAlienImage1 = ImageManager.Add(Image.Name.Alien1, pAlienTexture, 3f, 3f, 12f, 8f);
            Debug.Assert(pAlienImage1 != null);

            Image pAlienImage2 = ImageManager.Add(Image.Name.Alien2, pAlienTexture, 18f, 3f, 12f, 8f);
            Debug.Assert(pAlienImage2 != null);

            // --- crabs ---

            Image pCrabImage1 = ImageManager.Add(Image.Name.Crab1, pAlienTexture, 33f, 3f, 11f, 8f);
            Debug.Assert(pCrabImage1 != null);

            Image pCrabImage2 = ImageManager.Add(Image.Name.Crab2, pAlienTexture, 47f, 3f, 11f, 8f);
            Debug.Assert(pCrabImage2 != null);

            // --- squids ---

            Image pSquidImage1 = ImageManager.Add(Image.Name.Squid1, pAlienTexture, 61f, 3f, 8f, 8f);
            Debug.Assert(pSquidImage1 != null);

            Image pSquidImage2 = ImageManager.Add(Image.Name.Squid2, pAlienTexture, 72f, 3f, 8f, 8f);
            Debug.Assert(pSquidImage1 != null);

            // --- saucer ---
            Image pSaucerImage = ImageManager.Add(Image.Name.Saucer, pAlienTexture, 99, 3, 16, 8);

            // --- explosions ---
            Image pAlienExplosionImage = ImageManager.Add(Image.Name.AlienExplosion, pAlienTexture, 83, 3, 13, 8);
            Image pSaucerExplosionImage = ImageManager.Add(Image.Name.SaucerExplosion, pAlienTexture, 118, 3, 21, 8);
            Image pAlienShotExplosionImage = ImageManager.Add(Image.Name.AlienShotExplosion, pAlienTexture, 86, 25, 6, 8);
            Image pPlayerShotExplosionImage = ImageManager.Add(Image.Name.PlayerShotExplosion, pAlienTexture, 7, 25, 8, 8);
            Image pPlayerExplosionImage1 = ImageManager.Add(Image.Name.PlayerExplosionA, pAlienTexture, 19, 14, 16, 8);
            Image pPlayerExplosionImage2 = ImageManager.Add(Image.Name.PlayerExplosionB, pAlienTexture, 38, 14, 16, 8);

            // --- player ship ---
            Image pPlayerImage = ImageManager.Add(Image.Name.Player, pAlienTexture, 3f, 14f, 13f, 8f);
            Debug.Assert(pPlayerImage != null);

            // --- missile ---
            Image pMissileImage = ImageManager.Add(Image.Name.Missile, pAlienTexture, 3f, 29f, 1f, 4f);
            Debug.Assert(pMissileImage != null);

            // --- bombs ---
            Image pZigZag1 = ImageManager.Add(Image.Name.BombZigZag1, pAlienTexture, 18, 26, 3, 7);
            Image pZigZag2 = ImageManager.Add(Image.Name.BombZigZag2, pAlienTexture, 30, 26, 3, 7);
            Image pCross1 = ImageManager.Add(Image.Name.BombCross1, pAlienTexture, 42, 27, 3, 6);
            Image pCross2 = ImageManager.Add(Image.Name.BombCross2, pAlienTexture, 60, 27, 3, 6);
            Image pStraight = ImageManager.Add(Image.Name.BombStraight, pAlienTexture, 65, 26, 3, 7);

            // --- walls ---
            Image pWallImage = ImageManager.Add(Image.Name.Wall, pAlienTexture, 0f, 0, 2f, 40f);
            Debug.Assert(pWallImage != null);

            Image pFloorCeilingImage = ImageManager.Add(Image.Name.FloorCeiling, pAlienTexture, 0f, 0, 40f, 2f);
            Debug.Assert(pFloorCeilingImage != null);

            // --- shields ---
            Image pBrickTopLeft = ImageManager.Add(Image.Name.LeftTopBrick, pAlienTexture, 114, 31, 5, 4);
            Image pBrickLeft = ImageManager.Add(Image.Name.LeftBrick, pAlienTexture, 114, 35, 5, 4);
            Image pMidLeftBottom = ImageManager.Add(Image.Name.MidLeftBottom, pAlienTexture, 119, 43, 5.5f, 4);
            Image pMidRightBottom = ImageManager.Add(Image.Name.MidRightBottom, pAlienTexture, 124.5f, 43, 5.5f, 4);
            Image pMidBrick = ImageManager.Add(Image.Name.MidBrick, pAlienTexture, 119, 31, 5.5f, 4);
            Image pRightTopBrick = ImageManager.Add(Image.Name.RightTopBrick, pAlienTexture, 130, 31, 6, 4);
            Image pRightBrick = ImageManager.Add(Image.Name.RightBrick, pAlienTexture, 130, 35, 6, 4);



            //---------------------------------------------------------------------------------------------------------
            // Create Sprites
            //---------------------------------------------------------------------------------------------------------

            SpriteAdaptor pAlienSprite = SpriteManager.Add(SpriteAdaptor.Name.Alien, pAlienImage1, 0f, 0f, 48f, 32f);
            Debug.Assert(pAlienSprite != null);

            SpriteAdaptor pCrabSprite = SpriteManager.Add(SpriteAdaptor.Name.Crab, pCrabImage1, 0f, 0f, 44f, 32f);
            Debug.Assert(pCrabSprite != null);

            SpriteAdaptor pSquidSprite = SpriteManager.Add(SpriteAdaptor.Name.Squid, pSquidImage1, 0f, 0f, 32f, 32f);
            Debug.Assert(pSquidSprite != null);

            SpriteAdaptor pPlayerSprite = SpriteManager.Add(SpriteAdaptor.Name.Player, pPlayerImage, 0f, 0f, 52f, 32f);
            Debug.Assert(pPlayerSprite != null);
            pPlayerSprite.ChangeColor(0f, 1f, 0f);

            SpriteAdaptor pMissileSprite = SpriteManager.Add(SpriteAdaptor.Name.Missile, pMissileImage, 0f, 0f, 4f, 16f);
            Debug.Assert(pMissileSprite != null);

            SpriteAdaptor pWallSprite = SpriteManager.Add(SpriteAdaptor.Name.Wall, pWallImage, 50f, 500f, 10f, 900f);
            Debug.Assert(pWallSprite != null);

            SpriteAdaptor pFloorCeilingSprite = SpriteManager.Add(SpriteAdaptor.Name.FloorCeiling, pFloorCeilingImage, 500f, 100, 896f, 10f);
            Debug.Assert(pFloorCeilingSprite != null);

            SpriteAdaptor pSaucerSprite = SpriteManager.Add(SpriteAdaptor.Name.Saucer, pSaucerImage, 0f, 0f, 64f, 32f);
            pSaucerSprite.ChangeColor(1f, 0f, 0f);

            SpriteAdaptor pSaucerExplosionSprite = SpriteManager.Add(SpriteAdaptor.Name.SaucerExplosion, pSaucerExplosionImage, 0f, 0f, 84f, 32f);
            pSaucerExplosionSprite.ChangeColor(1f, 0f, 0f);

            SpriteAdaptor pAlienExplosionSprite = SpriteManager.Add(SpriteAdaptor.Name.AlienExplosion, pAlienExplosionImage, 0f, 0f, 52f, 32f);
            SpriteAdaptor pAlienShotExplosionSprite = SpriteManager.Add(SpriteAdaptor.Name.AlienShotExplosion, pAlienShotExplosionImage, 0f, 0f, 24f, 32f);
            pAlienShotExplosionSprite.ChangeColor(0f, 1f, 0f);
            SpriteAdaptor pPlayerShot = SpriteManager.Add(SpriteAdaptor.Name.PlayerShotExplosion, pPlayerShotExplosionImage, 0f, 0f, 32f, 32f);
            pPlayerShot.ChangeColor(1f, 0f, 0f);
            SpriteAdaptor pPlayerExplosionSprite = SpriteManager.Add(SpriteAdaptor.Name.PlayerExplosion, pPlayerExplosionImage1, 0f, 0f, 64f, 32f);
            pPlayerExplosionSprite.ChangeColor(0f, 1f, 0f);

            SpriteManager.Add(SpriteAdaptor.Name.BombCross, pCross1, 0f, 0f, 12f, 24f);
            SpriteManager.Add(SpriteAdaptor.Name.BombZigZag, pZigZag1, 0f, 0f, 12f, 28f);
            SpriteManager.Add(SpriteAdaptor.Name.BombStraight, pStraight, 0f, 0f, 12f, 28f);

            SpriteAdaptor pBrickSprite = SpriteManager.Add(SpriteAdaptor.Name.LeftTopBrick, pBrickTopLeft, 0f, 0f, 20f, 16f);
            pBrickSprite.ChangeColor(0, 1, 0);
            SpriteAdaptor pBrickLeftTop0Sprite = SpriteManager.Add(SpriteAdaptor.Name.LeftBrick, pBrickLeft, 0f, 0f, 20f, 16f);
            pBrickLeftTop0Sprite.ChangeColor(0, 1, 0);
            SpriteAdaptor pBrickLeftTop1Sprite = SpriteManager.Add(SpriteAdaptor.Name.MidLeftBottom, pMidLeftBottom, 0f, 0f, 22f, 16f);
            pBrickLeftTop1Sprite.ChangeColor(0, 1, 0);
            SpriteAdaptor pBrickLeftBottomSprite = SpriteManager.Add(SpriteAdaptor.Name.MidRightBottom, pMidRightBottom, 0f, 0f, 22f, 16f);
            pBrickLeftBottomSprite.ChangeColor(0, 1, 0);
            SpriteAdaptor pBrickRightTop0Sprite = SpriteManager.Add(SpriteAdaptor.Name.MidBrick, pMidBrick, 0f, 0f, 22f, 16f);
            pBrickRightTop0Sprite.ChangeColor(0, 1, 0);
            SpriteAdaptor pBrickRightTop1Sprite = SpriteManager.Add(SpriteAdaptor.Name.RightTopBrick, pRightTopBrick, 0f, 0f, 24f, 16f);
            pBrickRightTop1Sprite.ChangeColor(0, 1, 0);
            SpriteAdaptor pBrickRightBottomSprite = SpriteManager.Add(SpriteAdaptor.Name.RightBrick, pRightBrick, 0f, 0f, 24f, 16f);
            pBrickRightBottomSprite.ChangeColor(0, 1, 0);

            //-------------------------------------------------------------------------
            // Factories
            //-------------------------------------------------------------------------

            // STN - Factory is just used for initialization, not needed after that
            EnemyFactory pAlienFactory = new EnemyFactory(pAlienBatch, pSpriteBoxBatch);
            Debug.Assert(pAlienFactory != null);

            // STN - Factory is just used for initialization, not needed after that
            EnemyFactory pCrabFactory = new EnemyFactory(pCrabBatch, pSpriteBoxBatch);
            Debug.Assert(pCrabFactory != null);

            // STN - Factory is just used for initialization, not needed after that
            EnemyFactory pSquidFactory = new EnemyFactory(pSquidBatch, pSpriteBoxBatch);
            Debug.Assert(pSquidFactory != null);

            EnemyFactory pPlayerFactory = new EnemyFactory(pPlayerSpriteBatch, pSpriteBoxBatch);
            Debug.Assert(pPlayerFactory != null);

            GridFactory pGridFactory = new GridFactory(pSpriteBoxBatch);
            Debug.Assert(pGridFactory != null);

            ShieldFactory pShieldFactory = new ShieldFactory(pPlayerSpriteBatch, pSpriteBoxBatch);

            //-------------------------------------------------------------------------
            // Create shields
            //-------------------------------------------------------------------------

            ShieldGrid pShield1 = (ShieldGrid)pGridFactory.Create(GameObjectBase.Name.ShieldGrid, 150f, 200f);
            ShieldGrid pShield2 = (ShieldGrid)pGridFactory.Create(GameObjectBase.Name.ShieldGrid, 300f, 200f);
            ShieldGrid pShield3 = (ShieldGrid)pGridFactory.Create(GameObjectBase.Name.ShieldGrid, 450f, 200f);
            ShieldGrid pShield4 = (ShieldGrid)pGridFactory.Create(GameObjectBase.Name.ShieldGrid, 600f, 200f);

            ShieldManager.pShield1 = pShield1.CreateShield(pGridFactory, pShieldFactory);
            ShieldManager.pShield2 = pShield2.CreateShield(pGridFactory, pShieldFactory);
            ShieldManager.pShield3 = pShield3.CreateShield(pGridFactory, pShieldFactory);
            ShieldManager.pShield4 = pShield4.CreateShield(pGridFactory, pShieldFactory);

            // --- player ---
            Player pPlayer = (Player)pPlayerFactory.Create(GameObjectBase.Name.Player, 380f, 130f);
            pPlayer.poMissile = (Missile)pPlayerFactory.Create(GameObjectBase.Name.Missile, 200f, 130f);

            // --- walls ---
            GameObjectBase pLeftWall = pPlayerFactory.Create(GameObjectBase.Name.WallLeft, 15f, 500f);
            GameObjectBase pRightWall = pPlayerFactory.Create(GameObjectBase.Name.WallRight, 880f, 500f);
            GameObjectBase pTopWall = pPlayerFactory.Create(GameObjectBase.Name.WallTop, 450f, 930f);
            WallBottom pBottomWall = (WallBottom)pPlayerFactory.Create(GameObjectBase.Name.WallBottom, 450f, 40f);

            //------------------------------------------------------------------------
            // Bombs
            //------------------------------------------------------------------------
            BombFactory.Initalize(pBombBatch, pSpriteBoxBatch, pBottomWall);

            //-------------------------------------------------------------------------
            // Create Grid
            //-------------------------------------------------------------------------

            // LTN - GenericGameObjectManager 
            pGrid = (GridComposite)pGridFactory.Create(GameObjectBase.Name.Grid, 0f, 0f);

            // LTN - pGrid, which is owned by GenericGameObjectManager
            pGrid.AttachChildren(pGridFactory.Create(GameObjectBase.Name.Column, 0f, 0f));
            pGrid.AttachChildren(pGridFactory.Create(GameObjectBase.Name.Column, 0f, 0f));
            pGrid.AttachChildren(pGridFactory.Create(GameObjectBase.Name.Column, 0f, 0f));
            pGrid.AttachChildren(pGridFactory.Create(GameObjectBase.Name.Column, 0f, 0f));
            pGrid.AttachChildren(pGridFactory.Create(GameObjectBase.Name.Column, 0f, 0f));
            pGrid.AttachChildren(pGridFactory.Create(GameObjectBase.Name.Column, 0f, 0f));
            pGrid.AttachChildren(pGridFactory.Create(GameObjectBase.Name.Column, 0f, 0f));
            pGrid.AttachChildren(pGridFactory.Create(GameObjectBase.Name.Column, 0f, 0f));
            pGrid.AttachChildren(pGridFactory.Create(GameObjectBase.Name.Column, 0f, 0f));
            pGrid.AttachChildren(pGridFactory.Create(GameObjectBase.Name.Column, 0f, 0f));
            pGrid.AttachChildren(pGridFactory.Create(GameObjectBase.Name.Column, 0f, 0f));

            //BombManager.Initialize(pGrid);

            //---------------------------------------------------------------------------------------------------------
            // Create Proxies
            //---------------------------------------------------------------------------------------------------------

            IteratorBase pIt = pGrid.GetChildrenIterator();
            int i = 0;
            while (pIt.IsValid()) {
                Composite pColumn = (Composite)pIt.Current();
                pColumn.AttachChildren(pSquidFactory.Create(GameObjectBase.Name.Squid, 70f + i * 66f, 850f));
                pColumn.AttachChildren(pCrabFactory.Create(GameObjectBase.Name.Crab, 70f + i * 66f, 784f));
                pColumn.AttachChildren(pCrabFactory.Create(GameObjectBase.Name.Crab, 70f + i * 66f, 718f));
                pColumn.AttachChildren(pAlienFactory.Create(GameObjectBase.Name.Alien, 70f + i * 66f, 652f));
                pColumn.AttachChildren(pAlienFactory.Create(GameObjectBase.Name.Alien, 70f + i * 66f, 586f));
                pIt.Next();
                ++i;
            }


            pAlienFactory.Create(GameObjectBase.Name.Saucer, 0f, 0f);
            Saucer.GetInstance().Remove();

            //-------------------------------------------------------------------------
            // Texts
            //-------------------------------------------------------------------------
            TextManager.Initialize();
            TextManager.SetSquidBatch(pSquidBatch);
            TextManager.Add(Text.Name.LifeCount, PlayerManager.lives.ToString(), 20, 20);
            TextManager.Activate(Text.Name.LifeCount);
            TextManager.Activate(Text.Name.ScoreBar);
            TextManager.Activate(Text.Name.P1Score); 
            TextManager.Activate(Text.Name.HighScore); 

            //-------------------------------------------------------------------------
            // Commands
            //-------------------------------------------------------------------------

            //LTN - TimeEventManager 
            AnimateCommand pAlienAnimation = new AnimateCommand(pAlienSprite);
            Debug.Assert(pAlienAnimation != null);
            pAlienAnimation.Attach(pAlienImage1);
            pAlienAnimation.Attach(pAlienImage2);

            //LTN - TimeEventManager 
            AnimateCommand pCrabAnimation = new AnimateCommand(pCrabSprite);
            Debug.Assert(pCrabAnimation != null);
            pCrabAnimation.Attach(pCrabImage1);
            pCrabAnimation.Attach(pCrabImage2);

            //LTN - TimeEventManager 
            AnimateCommand pSquidAnimation = new AnimateCommand(pSquidSprite);
            Debug.Assert(pSquidAnimation != null);
            pSquidAnimation.Attach(pSquidImage1);
            pSquidAnimation.Attach(pSquidImage2);

            SpawnSaucerCommand pSpawnSaucerCommand = new SpawnSaucerCommand();

            DropBombCommand pDropBombCommand = new DropBombCommand(pGrid);

            DropSaucerBombCommand pSaucerBombCommand = new DropSaucerBombCommand();

            //LTN - TimeEventManager 
            MoveCommand pMoveCommand = new MoveCommand(pGrid, 15f);

            TimeEventManager.Add(0.5f, pAlienAnimation);
            TimeEventManager.Add(0.5f, pCrabAnimation);
            TimeEventManager.Add(0.5f, pSquidAnimation);
            TimeEventManager.Add(SelectDifficulty(), pMoveCommand);
            TimeEventManager.Add(25f, pSpawnSaucerCommand);
            TimeEventManager.Add(1f, pDropBombCommand);
            TimeEventManager.Add(15f, pSaucerBombCommand);

            //-------------------------------------------------------------
            // Collisions
            //-------------------------------------------------------------

            // --- Aliens vs Missile
            CollisionPair pAlienGrid_MissileCollision = CollisionPairManager.Add(CollisionPair.Name.AlienGrid_Missile, pGrid, pPlayer.poMissile);
            pAlienGrid_MissileCollision.poSubject.Attach(new RemoveGameObjectObserver());
            pAlienGrid_MissileCollision.poSubject.Attach(new PlaySoundObserver(SoundAdaptor.Name.AlienDeath));
            pAlienGrid_MissileCollision.poSubject.Attach(new AddExplosionObserver(SpriteAdaptor.Name.AlienExplosion));
            pAlienGrid_MissileCollision.poSubject.Attach(new AddPointsObserver());

            // --- Ship vs Wall
            CollisionPair pLeftWallCollision = CollisionPairManager.Add(CollisionPair.Name.Ship_Wall, pPlayer, pLeftWall);
            pLeftWallCollision.poSubject.Attach(new ChangeShipStateObserver());

            CollisionPair pRightWallCollision = CollisionPairManager.Add(CollisionPair.Name.Ship_Wall, pPlayer, pRightWall);
            pRightWallCollision.poSubject.Attach(new ChangeShipStateObserver());

            // --- Grid vs Wall
            CollisionPair pGrid_WallCollision = CollisionPairManager.Add(CollisionPair.Name.Grid_Wall, pGrid, pRightWall);
            pGrid_WallCollision.poSubject.Attach(new ChangeMovementObserver());

            CollisionPair pGrid_WallCollisionLeft = CollisionPairManager.Add(CollisionPair.Name.Grid_Wall, pGrid, pLeftWall);
            pGrid_WallCollisionLeft.poSubject.Attach(new ChangeMovementObserver());

            // --- Missile vs Ceiling
            CollisionPair pMissile_Wall = CollisionPairManager.Add(CollisionPair.Name.Missile_Wall, pPlayer.poMissile, pTopWall);
            pMissile_Wall.poSubject.Attach(new MissileFlyingObserver());
            pMissile_Wall.poSubject.Attach(new AddExplosionObserver(SpriteAdaptor.Name.PlayerShotExplosion));

            // --- Missile vs saucer
            CollisionPair pMissile_Saucer = CollisionPairManager.Add(CollisionPair.Name.AlienGrid_Missile, pPlayer.poMissile, Saucer.GetInstance());
            pMissile_Saucer.poSubject.Attach(new RemoveGameObjectObserver());
            pMissile_Saucer.poSubject.Attach(new AddExplosionObserver(SpriteAdaptor.Name.SaucerExplosion));
            pMissile_Saucer.poSubject.Attach(new AddPointsObserver());

            // --- Saucer vs Wall
            CollisionPair pSaucer_Wall = CollisionPairManager.Add(CollisionPair.Name.Saucer_Wall, Saucer.GetInstance(), pLeftWall);
            pSaucer_Wall.poSubject.Attach(new RemoveGameObjectObserver());

            CollisionPair pSaucer_Wall1 = CollisionPairManager.Add(CollisionPair.Name.Saucer_Wall, Saucer.GetInstance(), pRightWall);
            pSaucer_Wall1.poSubject.Attach(new RemoveGameObjectObserver());

            // --- Missile vs Shield
            CollisionPair pMissile_Shield1 = CollisionPairManager.Add(CollisionPair.Name.Missile_Shield, pShield1, pPlayer.poMissile);
            pMissile_Shield1.poSubject.Attach(new RemoveGameObjectObserver());
            CollisionPair pMissile_Shield2 = CollisionPairManager.Add(CollisionPair.Name.Missile_Shield, pShield2, pPlayer.poMissile);
            pMissile_Shield2.poSubject.Attach(new RemoveGameObjectObserver());
            CollisionPair pMissile_Shield3 = CollisionPairManager.Add(CollisionPair.Name.Missile_Shield, pShield3, pPlayer.poMissile);
            pMissile_Shield3.poSubject.Attach(new RemoveGameObjectObserver());
            CollisionPair pMissile_Shield4 = CollisionPairManager.Add(CollisionPair.Name.Missile_Shield, pShield4, pPlayer.poMissile);
            pMissile_Shield4.poSubject.Attach(new RemoveGameObjectObserver());

        }

        public override void Leaving()
        {
            TimeEventManager.Reset();
        }

        public override void Update(float systemTime)
        {
            TimeEventManager.Update(systemTime);
            InputManager.Update();
            GenericGameObjectManager.Update();
            CollisionPairManager.ProcessCollisions();
            DeletionManager.Update();
            SoundManager.Update();

            CheckAdvanceLevel();
        }

        private float SelectDifficulty()
        {
            float speed;
            switch (SpaceInvaders.currentLevel) {
                case 1:
                    speed = 0.5f;
                    break;
                case 2:
                    speed = 0.35f;
                    break;
                case 3:
                    speed = 0.3f;
                    break;
                case 4:
                    speed = 0.25f;
                    break;
                default:
                    speed = 0.6f;
                    break;
            }
            return speed;
        }
        private void CheckAdvanceLevel()
        {
            if (pGrid.AlienCount == 0) {
                SpaceInvaders.currentLevel++;

                SpriteBatchManager.Reset();
                GenericGameObjectManager.Reset();
                CollisionPairManager.Reset();
                ImageManager.Reset();
                SpriteManager.Reset();
                SpriteBoxManager.Reset();
                ProxySpriteManager.Reset();
                GhostManager.Reset();
                DeletionManager.Reset();
                BombFactory.Reset();

                PlayerManager.NextLevel();
                SpaceInvaders.poSceneContext.SetState(SceneContext.Scene.Play);
            }

        }
        private GridComposite pGrid;
    }
}
