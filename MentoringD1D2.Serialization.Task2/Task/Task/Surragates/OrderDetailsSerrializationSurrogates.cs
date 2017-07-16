using System;
using System.Runtime.Serialization;
using Task.DB;

namespace Task.Surragates
{
    public class OrderDetailsSerrializationSurrogates : ISerializationSurrogate
    {
        /// <summary>
        /// Generate serialized representation of the Order_Details instance.
        /// </summary>
        /// <param name="obj">The Order_Details instance.</param>
        /// <param name="info"></param>
        /// <param name="context"></param>
        public void GetObjectData(object obj, SerializationInfo info, StreamingContext context)
        {
            var orderDetails =  obj as Order_Detail;

            if (orderDetails != null)
            {
                info.AddValue("OrderId", orderDetails.OrderID);
                info.AddValue("ProductId", orderDetails.ProductID);
                info.AddValue("Discount", orderDetails.Discount);
                info.AddValue("Quantity", orderDetails.Quantity);
                info.AddValue("Price", orderDetails.UnitPrice);
            }
        }

        /// <summary>
        /// Parses serialized before Order_Detailes instance.
        /// </summary>
        /// <param name="obj">The result of the deserialization.</param>
        /// <param name="info"></param>
        /// <param name="context"></param>
        /// <param name="selector"></param>
        /// <returns></returns>
        public object SetObjectData(object obj, SerializationInfo info, StreamingContext context, ISurrogateSelector selector)
        {
            var orderDetails = obj as Order_Detail;

            if (orderDetails != null)
            {
                orderDetails.OrderID = info.GetInt32("OrderId");
                orderDetails.ProductID = info.GetInt32("ProductId");
                orderDetails.Discount = info.GetInt64("Discount");
                orderDetails.Quantity = info.GetInt16("Quantity");
                orderDetails.UnitPrice = info.GetDecimal("Price");
            }

            return orderDetails;
        }
    }
}
