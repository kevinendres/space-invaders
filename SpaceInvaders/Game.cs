using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class SpaceInvaders : Azul.Game
    {
        //-----------------------------------------------------------------------------
        // Game::Initialize()
        //		Allows the engine to perform any initialization it needs to before 
        //      starting to run.  This is where it can query for any required services 
        //      and load any non-graphic related content. 
        //-----------------------------------------------------------------------------
        public override void Initialize()
        {
            // Game Window Device setup
            this.SetWindowName("Sprites");
            this.SetWidthHeight(896, 1024);
            this.SetClearColor(0f, 0f, 0f, 1.0f);
        }

        //-----------------------------------------------------------------------------
        // Game::LoadContent()
        //		Allows you to load all content needed for your engine,
        //	    such as objects, graphics, etc.
        //-----------------------------------------------------------------------------
        public override void LoadContent()
        {
            //-------------------------------------------------------------------------
            // Static Managers
            //-------------------------------------------------------------------------

            TextureManager.Initialize();
            ImageManager.Initialize();
            SpriteManager.Initialize();
            SpriteBoxManager.Initialize();
            ProxySpriteManager.Initialize();
            SpriteBatchManager.Initialize();
            TimeEventManager.Initialize();
            GenericGameObjectManager.Initialize();
            GhostManager.Initialize();
            CollisionPairManager.Initialize();
            InputManager.Initialize();
            SoundManager.Initialize(true); //true for on, false for off
            DeletionManager.Initialize();

            //---------------------------------------------------------------------------------------------------------
            // Load the Texture
            //---------------------------------------------------------------------------------------------------------

            Texture pAlienTexture = TextureManager.Add(Texture.Name.Aliens, "SpaceInvaders.tga");
            Debug.Assert(pAlienTexture != null);

            //-------------------------------------------------------------------------
            // Sounds
            //-------------------------------------------------------------------------

            SoundManager.Add(SoundAdaptor.Name.MissileFire, "shoot.wav");
            SoundManager.Add(SoundAdaptor.Name.AlienDeath, "invaderkilled.wav");
            SoundManager.Add(SoundAdaptor.Name.PlayerDeath, "explosion.wav");
            SoundManager.Add(SoundAdaptor.Name.AlienMovement1, "fastinvader1.wav");
            SoundManager.Add(SoundAdaptor.Name.AlienMovement2, "fastinvader2.wav");
            SoundManager.Add(SoundAdaptor.Name.AlienMovement3, "fastinvader3.wav");
            SoundManager.Add(SoundAdaptor.Name.AlienMovement4, "fastinvader4.wav");
            SoundManager.Add(SoundAdaptor.Name.UFO1, "ufo_highpitch.wav");
            SoundManager.Add(SoundAdaptor.Name.Music, "theme.wav");
            SoundManager.PlayLoopedMusic();
            SoundManager.SetVolume(0.6f);

            // --- Create scene Context ---
            poSceneContext = new SceneContext();
        }

        //-----------------------------------------------------------------------------
        // Game::Update()
        //      Called once per frame, update data, tranformations, etc
        //      Use this function to control process order
        //      Input, AI, Physics, Animation, and Graphics
        //-----------------------------------------------------------------------------
        public override void Update()
        {
            poSceneContext.GetState().Update(this.GetTime());
        }

        //-----------------------------------------------------------------------------
        // Game::Draw()
        //		This function is called once per frame
        //	    Use this for draw graphics to the screen.
        //      Only do rendering here
        //-----------------------------------------------------------------------------
        public override void Draw()
        {
            poSceneContext.GetState().Draw();
        }

        //-----------------------------------------------------------------------------
        // Game::UnLoadContent()
        //       unload content (resources loaded above)
        //       unload all content that was loaded before the Engine Loop started
        //-----------------------------------------------------------------------------
        public override void UnLoadContent()
        {

        }

        public static int currentLevel = 1;
        public static int highScore = 0;
        public static SceneContext poSceneContext;
    }
}


