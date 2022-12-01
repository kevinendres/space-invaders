using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class MissileReadyState : MissileState
    {
        public override void HandleTransition(Player pPlayer)
        {
            PlayerManager.ChangeMissileState();
        }

        public override void Shoot(Player pPlayer)
        {
            pPlayer.poMissile.Activate(pPlayer.x, pPlayer.y);
            SoundManager.PlaySound(SoundAdaptor.Name.MissileFire);
            HandleTransition(pPlayer);
        }
    }
}
