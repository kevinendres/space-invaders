using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class PlayerManager
    {
        public static GameObjectBase InitializePlayer(float x, float y)
        {
            if (pPlayer == null) {
                pPlayer = new Player(x, y);
                pPlayer.SetMissileState(pMissileReady);
                pPlayer.SetMovementState(pMovementReadyState);
                lives = 3;
            }
            return pPlayer;
        }
        public static void ChangeMissileState()
        {
            if (flying) {
                pPlayer.SetMissileState(pMissileReady);
                pPlayer.poMissile.Deactivate();
            }
            else {
                pPlayer.SetMissileState(pFlyingState);
            }
            flying = !flying;
        }
        public static void ChangeMovementState(MovementState.Name name)
        {
            switch (name) {
                case MovementState.Name.EdgeLeft:
                    pPlayer.SetMovementState(pLeftEdgeState);
                    break;
                case MovementState.Name.Ready:
                    pPlayer.SetMovementState(pMovementReadyState);
                    break;
                case MovementState.Name.EdgeRight:
                    pPlayer.SetMovementState(pRightEdgeState);
                    break;
                default:
                    Debug.Assert(false);
                    break;
            }

        }
        public static Missile GetMissile()
        {
            return pPlayer.poMissile;
        }
        public static void Reset()
        {
            pPlayer = null;
        }

        public static void AddScore(int points)
        {
            pPlayer.score += points;
        }
        public static int GetScore()
        {
            return pPlayer.score;
        }
        public static Player GetPlayer()
        {
            return pPlayer;
        }
        public static void NextLevel()
        {
            pPlayer.NextLevel();
        }
        public static Player pPlayer;
        public static bool flying = false;
        public static MissileFlyingState pFlyingState = new MissileFlyingState();
        public static MissileReadyState pMissileReady = new MissileReadyState();
        public static MovementReadyState pMovementReadyState = new MovementReadyState();
        public static LeftEdgeState pLeftEdgeState = new LeftEdgeState();
        public static RightEdgeState pRightEdgeState = new RightEdgeState();
        public static int lives;
    }
}
