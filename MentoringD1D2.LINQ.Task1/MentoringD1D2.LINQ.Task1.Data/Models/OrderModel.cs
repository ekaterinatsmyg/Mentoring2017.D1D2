using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MentoringD1D2.LINQ.Task1.Data.Models
{
    /// <summary>
    /// Model that represents order entity.
    /// </summary>
    public class OrderModel
    {
        /// <summary>
        /// The identifer of an order.
        /// </summary>
        public int OrderId { get; set; }

        /// <summary>
        /// The date when the order was created.
        /// </summary>
        public DateTime OrderDate { get; set; }

        /// <summary>
        /// The total price of an order.
        /// </summary>
        public decimal TotalPrice { get; set; }

        public override string ToString()
        {
            return
               $"---------{OrderId} --------- {Environment.NewLine} Order Date : {OrderDate} {Environment.NewLine} Total Price:  {TotalPrice} {Environment.NewLine}";
        }
    }
}
