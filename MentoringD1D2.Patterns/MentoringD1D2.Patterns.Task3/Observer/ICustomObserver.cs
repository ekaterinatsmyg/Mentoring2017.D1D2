using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MentoringD1D2.Patterns.Task3.Commands;

namespace MentoringD1D2.Patterns.Task3.Observer
{
    public interface ICustomObserver<T>
    {
        void Update(T value);
    }
}
