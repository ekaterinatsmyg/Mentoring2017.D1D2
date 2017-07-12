
namespace MentoringD1D2.Patterns.Task3.Commands
{
    public interface ICommand
    {
        void Execute();
        void Undo();
    }
}
