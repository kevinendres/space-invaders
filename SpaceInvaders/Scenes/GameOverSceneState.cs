using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class GameOverSceneState : SceneState
    {
        public GameOverSceneState()
        {
            name = SceneContext.Scene.Over;
        }
        public override void Draw()
        {
            SpriteBatchManager.Render();
        }

        public override void Entering()
        {
            this.Initialize();
            TextManager.ToggleSquids();
            SoundManager.StopSaucerSound();
            Text pGameOver = (Text)TextManager.Add(Text.Name.GameOver, "GAME OVER", 350, 830);
            pGameOver.ChangeColor(1, 0, 0);
            TextManager.Activate(Text.Name.GameOver);
            int currentScore = PlayerManager.GetScore();
            if (currentScore > SpaceInvaders.highScore) {
                SpaceInvaders.highScore = currentScore;
                TextManager.UpdateHighScore(currentScore);
            }
        }

        public override void Handle()
        {
            throw new NotImplementedException();
        }

        public override void Initialize()
        {
        }

        public override void Leaving()
        {
            SpriteBatchManager.Reset();
            GenericGameObjectManager.Reset();
            CollisionPairManager.Reset();
            ImageManager.Reset();
            SpriteManager.Reset();
            SpriteBoxManager.Reset();
            ProxySpriteManager.Reset();
            TimeEventManager.Reset();
            GhostManager.Reset();
            DeletionManager.Reset();
            PlayerManager.Reset();
            BombFactory.Reset();

            TextManager.Deactivate(Text.Name.GameOver);
        }

        public override void Update(float systemTime)
        {
            InputManager.Update();
        }
    }
}
