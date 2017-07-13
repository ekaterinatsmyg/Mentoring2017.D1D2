using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindLibrary
{
    public interface IReadable<T>
    {
        T ReadSingleRow(IDataReader reader, T entity);
    }
}
