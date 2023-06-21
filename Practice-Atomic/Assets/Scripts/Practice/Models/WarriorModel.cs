using Declarative;

namespace Lessons.Gameplay.Atomic2.Practice.Models
{
    public class WarriorModel : DeclarativeModel
    {
        [Section] public MovingCharacterModel MoveModel;
        [Section] public MeleeAttackModel MeleeAttackModel;
        [Section] public HealthModel HealthModel;
    }
}