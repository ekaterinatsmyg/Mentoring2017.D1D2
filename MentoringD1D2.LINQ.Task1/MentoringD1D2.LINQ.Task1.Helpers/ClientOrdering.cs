using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MentoringD1D2.LINQ.Task1.Helpers
{
    /// <summary>
    /// The avaliable way of the ordering results.
    /// </summary>
    public enum ClientOrdering
    {
        /// <summary>
        /// The ordering by the first order's date.
        /// </summary>
        ByFirstOrderDate,

        /// <summary>
        /// The ordering by the first month of order's date.
        /// </summary>
        ByMonthOfFirstOrderDate,

        /// <summary>
        /// The ordering by the first year of order's date.
        /// </summary>
        ByYearOfFirstOrderDate,

        /// <summary>
        /// The ordering by company name of the client.
        /// </summary>
        ByNameOfClient,

        /// <summary>
        /// The ordering by sum of orders' total proce of the client.
        /// </summary>
        ByTurnoverOfClient
    }
}
