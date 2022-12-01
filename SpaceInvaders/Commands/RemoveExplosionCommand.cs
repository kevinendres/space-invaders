using System;

namespace SpaceInvaders
{
    class RemoveExplosionCommand : CommandBase
    {
        public RemoveExplosionCommand(GenericSprite _sprite)
        {
            pSprite = _sprite;
        }
        public override void Execute(float deltaTime)
        {
            SpriteBatch pBatch = SpriteBatchManager.GetTopBatch();
            pBatch.Detach(pSprite);

        }
        GenericSprite pSprite;
    }
}
