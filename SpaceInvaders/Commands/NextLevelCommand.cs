using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class NextLevelCommand : CommandBase
    {
        public NextLevelCommand(GridComposite _pGrid)
        {
            pGrid = _pGrid;
        }
        public override void Execute(float deltaTime)
        {
            TimeEventManager.Add(deltaTime, this);

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

                SpaceInvaders.poSceneContext.SetState(SceneContext.Scene.Play);
            }

        }
        GridComposite pGrid;
    }
}
