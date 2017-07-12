using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MentoringD1D2.Patterns.Task3.Commands;
using MentoringD1D2.Patterns.Task3.Observable;
using MentoringD1D2.Patterns.Task3.Observer;

namespace MentoringD1D2.Patterns.Task3
{
    public class Player: ICustomObservable<IReciver>, IReciver
    {
        private List<ICustomObserver<IReciver>> _observers;

        /// <summary>
        /// The name of the current command.
        /// </summary>
        public string CommandType { get; private set; }

        public Player()
        {
            _observers = new List<ICustomObserver<IReciver>>();
        }

        /// <summary>
        /// Add observer of the player.
        /// </summary>
        /// <param name="observer">The object that will observe for updates of the player and receive notifications.</param>
        public void AddObserver(ICustomObserver<IReciver> observer)
        {
            _observers.Add(observer);
        }

        /// <summary>
        /// Remove observer of the player.
        /// </summary>
        /// <param name="observer">The object that don't need to receive notifications from the player..</param>
        public void RemoveObserver(ICustomObserver<IReciver> observer)
        {
            _observers.Remove(observer);
        }

        /// <summary>
        /// When the current command in the completed state, notify quest command creater that next command should be created.
        /// </summary>
        public void NotifyObservers()
        {
            foreach (var obsreve in _observers)
            {
                obsreve.Update(this);
            }
        }

        /// <summary>
        /// Reacts to received command.
        /// </summary>
        /// <param name="command">The current command.</param>
        public void MakeDescision(ICommand command)
        {
            //Actions from player side based current command
            CommandType = command.GetType().Name;
            this.NotifyObservers();
        }
    }
}
