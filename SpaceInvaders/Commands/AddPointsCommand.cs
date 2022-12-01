using System;

namespace SpaceInvaders
{
    class AddPointsCommand
    {
        public void Execute(int points)
        {
            PlayerManager.AddScore(points);
            points = PlayerManager.GetScore();
            Text scoreText = TextManager.GetScoreText();
            scoreText.UpdateMessage(points.ToString());
        }
    }
}
