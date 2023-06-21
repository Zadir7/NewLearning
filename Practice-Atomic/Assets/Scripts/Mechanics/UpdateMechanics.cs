using System;
using Declarative;

namespace Lessons.Gameplay.Atomic2.Mechanics
{
    public class UpdateMechanics : IUpdateListener
    {
        private Action<float> update;

        public void Do(Action<float> update)
        {
            this.update = update;
        }

        void IUpdateListener.Update(float deltaTime)
        {
            this.update.Invoke(deltaTime);
        }
    }
}