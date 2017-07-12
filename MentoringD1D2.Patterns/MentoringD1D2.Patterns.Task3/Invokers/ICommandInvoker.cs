using MentoringD1D2.Patterns.Task3.Commands;

namespace MentoringD1D2.Patterns.Task3.Invokers
{
    public interface ICommandInvoker
    {
        void Run();
        void Cancle();
        void SetCommand(ICommand command);
    }
}
