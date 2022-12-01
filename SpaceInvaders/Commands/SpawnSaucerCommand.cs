using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class SpawnSaucerCommand : CommandBase
    {
        public SpawnSaucerCommand()
        {
            rand = new Random();
        }
        public override void Execute(float deltaTime)
        {
            Debug.Print("Current time is " + TimeEventManager.GetCurrTime());
            Saucer.Activate();
            SoundManager.PlaySaucerSound();
            TimeEventManager.Add(rand.Next(10, 20), this);
        }
        public float GetRandomTime()
        {
            int i = rand.Next(20, 30);
            return (float)i + 4.0f;
        }
        Random rand;
    }
}
