using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MentoringD1D2.Patterns.Task3.Commands;

namespace MentoringD1D2.Patterns.Task3
{
    public interface IReciver
    {
        string CommandType { get; }
        void MakeDescision(ICommand command);
    }
}
