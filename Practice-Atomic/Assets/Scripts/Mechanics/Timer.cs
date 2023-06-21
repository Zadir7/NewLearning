using System;

namespace Lessons.Gameplay.Atomic2.Mechanics
{
    public class Timer
    {
        public bool InProgress => timeLeft > 0.0f;
        
        private readonly float countdown;
        private float timeLeft;

        public Timer(float countdown)
        {
            this.countdown = countdown;
        }

        public void Update(float deltaTime)
        {
            if (this.timeLeft <= 0.0f)
            {
                return;
            }
            
            this.timeLeft -= deltaTime;
        }

        public void Start()
        {
            this.timeLeft = this.countdown;
        }
    }
}