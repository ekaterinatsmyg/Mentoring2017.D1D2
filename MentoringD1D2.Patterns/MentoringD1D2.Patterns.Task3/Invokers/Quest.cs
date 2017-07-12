using System;
using System.Collections.Generic;
using MentoringD1D2.Patterns.Task3.Commands;
using MentoringD1D2.Patterns.Task3.Enums;
using MentoringD1D2.Patterns.Task3.Observable;
using MentoringD1D2.Patterns.Task3.Observer;

namespace MentoringD1D2.Patterns.Task3.Invokers
{
    public class Quest : ICommandInvoker, ICustomObservable<Quest>
    {
        public QuestState State { get; private set; }

        private List<ICustomObserver<Quest>> _observers;

        private ICommand _command;
        public QuestStep Step { get; private set; }

        private IReciver _reciver;

        public Quest(IReciver reciver)
        {
            Step = QuestStep.StartDialogCommand;
            State = QuestState.NotStarted;
            _observers = new List<ICustomObserver<Quest>>();
            _reciver = reciver;
        }

        /// <summary>
        /// Run the first action of the quest and notify quest table that quest was started.
        /// </summary>
        public void RunQuest()
        {
            _command = new StartDialogCommand(_reciver);
            State = QuestState.InProgress;
            NotifyObservers();
        }

        /// <summary>
        /// Run the current command.
        /// </summary>
        public void Run()
        {
            _command.Execute();
            State = QuestState.Completed;
        }

        /// <summary>
        /// Cancel the current comand.
        /// </summary>
        public void Cancle()
        {
            _command.Undo();
        }

        /// <summary>
        /// Set current command that should be run.
        /// </summary>
        /// <param name="command">The command of the quest.</param>
        public void SetCommand(ICommand command)
        {
            _command = command;
        }

        /// <summary>
        /// Mark the quest as completed.
        /// </summary>
        public void Complete()
        {
            State = QuestState.Completed;
        }


        /// <summary>
        /// Add observer of the quest. 
        /// </summary>
        /// <param name="observer">The object that will observe for updates of the quest and receive notifications.</param>
        public void AddObserver(ICustomObserver<Quest> observer)
        {
            _observers.Add(observer);
        }

        /// <summary>
        /// Remove observer of the quest.
        /// </summary>
        /// <param name="observer">The object that don't need to receive notofocations from the quest.</param>
        public void RemoveObserver(ICustomObserver<Quest> observer)
        {
            _observers.Remove(observer);
        }

        /// <summary>
        /// Notify quest table that the quest is in progress now.
        /// </summary>
        public void NotifyObservers()
        {
            foreach (var observer in _observers)
            {
                observer.Update(this);
            }
        }

    }
}
