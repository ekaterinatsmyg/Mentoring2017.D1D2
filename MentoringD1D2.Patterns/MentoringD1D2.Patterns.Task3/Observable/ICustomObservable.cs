using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MentoringD1D2.Patterns.Task3.Observer;

namespace MentoringD1D2.Patterns.Task3.Observable
{
    public interface ICustomObservable<T>
    {
        void AddObserver(ICustomObserver<T> observer);
        void RemoveObserver(ICustomObserver<T> observer);
        void NotifyObservers();
    }
}
