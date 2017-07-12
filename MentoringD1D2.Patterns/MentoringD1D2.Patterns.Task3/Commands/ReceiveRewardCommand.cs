using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MentoringD1D2.Patterns.Task3.Enums;

namespace MentoringD1D2.Patterns.Task3.Commands
{
    public class ReceiveRewardCommand : ICommand
    {
        private ActionState _state;
        private readonly IReciver _player;

        public ReceiveRewardCommand(IReciver player)
        {
            _state = ActionState.NotStarted;
            _player = player;
        }
        public void Execute()
        {
            //do something specific
            _state = ActionState.Completed;
            
        }

        public void Undo()
        {
            //do something specific
            _state = ActionState.Canceled;
            _player.MakeDescision(this);
        }
    }
}
