namespace _Assets.Scripts.MVVM.Commands
{
    public interface ICommand
    {
        void Execute();
        void Undo();
    }
}