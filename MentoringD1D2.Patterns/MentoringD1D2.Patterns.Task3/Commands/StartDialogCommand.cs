using System;
using System.Collections.Generic;
using MentoringD1D2.Patterns.Task3.Enums;
using MentoringD1D2.Patterns.Task3.Observable;
using MentoringD1D2.Patterns.Task3.Observer;

namespace MentoringD1D2.Patterns.Task3.Commands
{
    public class StartDialogCommand: ICommand
    {
        private ActionState _state;
        private readonly IReciver _player;

        public StartDialogCommand(IReciver player)
        {
            _state = ActionState.NotStarted;
            _player =  player;
        }

        /// <summary>
        /// Execute several steps and send the results to the reciver.
        /// </summary>
        public void Execute()
        {
            //do something specific
            _state = ActionState.Completed;
            _player.MakeDescision(this);
        }

        /// <summary>
        /// Canceling of the command and send the results to the reciver.
        /// </summary>
        public void Undo()
        {
            //do something specific
            _state = ActionState.Canceled;
            _player.MakeDescision(this);
        }
        
    }
}
