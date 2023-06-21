using Declarative;

namespace Lessons.Gameplay.Atomic2.Practice.Models
{
    public class TowerModel : DeclarativeModel
    {
        [Section] public RangedAttackModel RangedAttackModel;
        [Section] public HealthModel HealthModel;
    }
}