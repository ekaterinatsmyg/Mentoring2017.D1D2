using MentoringD1D2.Patterns.Task3.Enums;

namespace MentoringD1D2.Patterns.Task3.Commands
{
    public class FightCommand : ICommand
    {
        private ActionState _state;
        private readonly IReciver _player;

        public FightCommand(IReciver player)
        {
            _state = ActionState.NotStarted;
            _player = player;
        }
        public void Execute()
        {
            //do something specific
            _state = ActionState.Completed;
            _player.MakeDescision(this);
        }

        public void Undo()
        {
            //do something specific
            _state = ActionState.Canceled;
            _player.MakeDescision(this);
        }
    }
}
