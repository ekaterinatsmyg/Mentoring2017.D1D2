using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MentoringD1D2.Patterns.Task3.Commands;
using MentoringD1D2.Patterns.Task3.Enums;
using MentoringD1D2.Patterns.Task3.Invokers;
using MentoringD1D2.Patterns.Task3.Observer;

namespace MentoringD1D2.Patterns.Task3
{
    public class QuestCommandCreator : ICommandCreator, ICustomObserver<IReciver>
    {
        /// <summary>
        /// The quest.
        /// </summary>
        private ICommandInvoker _commandInvoker;

        private QuestStep _questStep;
        public QuestCommandCreator(ICommandInvoker commandInvoker)
        {
            _commandInvoker = commandInvoker;
        }

        /// <summary>
        /// Create necessary command.
        /// </summary>
        /// <param name="reciver">The player of the quest.</param>
        /// <returns>The next command that should be run.</returns>
        public ICommand CommandFactory(IReciver reciver)
        {
            if (reciver == null)
            {
                throw new ArgumentNullException(nameof(reciver));
            }
            
            switch (_questStep)
            {
                case QuestStep.StartDialogCommand:
                    return new SelectLocationCommand(reciver);
                case QuestStep.SelectLocationCommand:
                    return new FightCommand(reciver);
                case QuestStep.FightCommand:
                    return new ReceiveRewardCommand(reciver);
                default:
                    return null;
            }
        }

        /// <summary>
        /// Create and run next command, when the player makes descision related to the current command
        /// </summary>
        /// <param name="player">The player of the quest.</param>
        public void Update(IReciver player)
        {
            if (!Enum.TryParse(player.CommandType, out _questStep))
            {
                throw new InvalidCastException($"The {player.CommandType} command doesn't defind for the quest.");
            }

            if (_questStep == QuestStep.ReceiveRewardCommand)
            {
                return;
            }
            var command = CommandFactory(player);
            _commandInvoker.SetCommand(command);
         }
        
    }
}

