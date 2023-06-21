using Lessons.Gameplay.Atomic1;

namespace Lessons.Gameplay.Atomic2.Practice.Components
{
    public interface ITakeDamageComponent
    {
        void TakeDamage(int value);
    }
    
    public sealed class TakeDamageComponent : ITakeDamageComponent
    {
        private readonly IAction<int> _onTakeDamage;

        public TakeDamageComponent(IAction<int> onTakeDamage)
        {
            _onTakeDamage = onTakeDamage;
        }
        
        public void TakeDamage(int value)
        {
            this._onTakeDamage.Invoke(value);
        }
    }
}