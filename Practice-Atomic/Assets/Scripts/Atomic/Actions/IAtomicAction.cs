namespace Lessons.Gameplay.Atomic1
{
    public interface IAtomicAction
    {
        void Invoke();
    }

    public interface IAction<in T>
    {
        void Invoke(T args);
    }
}