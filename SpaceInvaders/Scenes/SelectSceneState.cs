using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class SelectSceneState : SceneState
    {
        public SelectSceneState()
        {
            name = SceneContext.Scene.Select;
        }
        public override void Draw()
        {
            SpriteBatchManager.Render();
        }

        public override void Entering()
        {
            SpaceInvaders.currentLevel = 1;
            this.Initialize();
        }

        public override void Handle()
        {
            throw new NotImplementedException();
        }

        public override void Initialize()
        {
            GlyphManager.Initialize();
            TextManager.Initialize();

            Text pScoreBar = (Text)TextManager.Add(Text.Name.ScoreBar, "SCORE<1> HI-SCORE SCORE<2>", 70, 980);
            pScoreBar.ChangeColor(1, 1, 1);
            TextManager.Add(Text.Name.P1Score, "0", 200, 940);
            TextManager.Add(Text.Name.HighScore, SpaceInvaders.highScore.ToString(), 500, 940);

            TextManager.Add(Text.Name.Play, "PLAY", 375, 700);
            TextManager.Add(Text.Name.Title, "SPACE INVADERS", 245, 620);
            TextManager.Add(Text.Name.ScoreTable, "*SCORE ADVANCE TABLE*", 150, 540);
            TextManager.Add(Text.Name.SaucerScore, "=? MYSTERY", 345, 480);
            TextManager.Add(Text.Name.SquidScore, "=30 POINTS", 345, 420);
            TextManager.Add(Text.Name.CrabScore, "=20 POINTS", 345, 360);
            TextManager.Add(Text.Name.AlienScore, "=10 POINTS", 345, 300);
            TextManager.Activate(Text.Name.ScoreBar);
            TextManager.Activate(Text.Name.P1Score); 
            TextManager.Activate(Text.Name.HighScore); 

            TextManager.Activate(Text.Name.Play);
            TextManager.Activate(Text.Name.Title); 
            TextManager.Activate(Text.Name.ScoreTable); 
            TextManager.Activate(Text.Name.SaucerScore);
            TextManager.Activate(Text.Name.SquidScore); 
            TextManager.Activate(Text.Name.CrabScore); 
            TextManager.Activate(Text.Name.AlienScore); 

            //---------------------------------------------------------------------------------------------------------
            // Create Images
            //---------------------------------------------------------------------------------------------------------
            Texture pAlienTexture = TextureManager.GetTexture();

            // --- aliens ---

            Image pAlienImage1 = ImageManager.Add(Image.Name.Alien1, pAlienTexture, 3f, 3f, 12f, 8f);
            Debug.Assert(pAlienImage1 != null);

            // --- crabs ---

            Image pCrabImage1 = ImageManager.Add(Image.Name.Crab1, pAlienTexture, 33f, 3f, 11f, 8f);
            Debug.Assert(pCrabImage1 != null);

            // --- squids ---

            Image pSquidImage1 = ImageManager.Add(Image.Name.Squid1, pAlienTexture, 61f, 3f, 8f, 8f);
            Debug.Assert(pSquidImage1 != null);

            // --- saucer ---
            Image pSaucerImage = ImageManager.Add(Image.Name.Saucer, pAlienTexture, 99, 3, 16, 8);

            SpriteAdaptor pAlienSprite = SpriteManager.Add(SpriteAdaptor.Name.Alien, pAlienImage1, 280f, 300f, 48f, 32f);
            Debug.Assert(pAlienSprite != null);

            SpriteAdaptor pCrabSprite = SpriteManager.Add(SpriteAdaptor.Name.Crab, pCrabImage1, 280f, 360f, 44f, 32f);
            Debug.Assert(pCrabSprite != null);

            SpriteAdaptor pSquidSprite = SpriteManager.Add(SpriteAdaptor.Name.Squid, pSquidImage1, 280f, 420f, 32f, 32f);
            Debug.Assert(pSquidSprite != null);

            SpriteAdaptor pSaucerSprite = SpriteManager.Add(SpriteAdaptor.Name.Saucer, pSaucerImage, 280f, 480f, 64f, 32f);
            pSaucerSprite.ChangeColor(1f, 0f, 0f);

            pBatch = SpriteBatchManager.Add(99f);
            pBatch.Attach(pAlienSprite);
            pBatch.Attach(pCrabSprite);
            pBatch.Attach(pSquidSprite);
            pBatch.Attach(pSaucerSprite);
        }

        public override void Leaving()
        {
            TextManager.Deactivate(Text.Name.Play);
            TextManager.Deactivate(Text.Name.Title); 
            TextManager.Deactivate(Text.Name.ScoreTable); 
            TextManager.Deactivate(Text.Name.SaucerScore);
            TextManager.Deactivate(Text.Name.SquidScore); 
            TextManager.Deactivate(Text.Name.CrabScore); 
            TextManager.Deactivate(Text.Name.AlienScore);

            pBatch.ToggleDrawing();
        }

        public override void Update(float systemTime)
        {
            SpriteBatchManager.Update();
            InputManager.Update();
            SoundManager.Update();
        }
        SpriteBatch pBatch;
    }
}
