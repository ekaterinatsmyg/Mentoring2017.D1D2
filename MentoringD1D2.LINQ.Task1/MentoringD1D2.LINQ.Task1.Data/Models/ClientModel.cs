using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MentoringD1D2.LINQ.Task1.Data.Models
{
    /// <summary>
    /// Model that represents client entity.
    /// </summary>
    public class ClientModel
    {
        /// <summary>
        /// The identifer of client in a system.
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// The clent company name.
        /// </summary>
        public string CompanyName { get; set; }

        /// <summary>
        /// The address of a client.
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// The city where a client is situated.
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// The region where a client is situated.
        /// </summary>
        public string Region { get; set; }

        /// <summary>
        /// The post code of region where a client is situated.
        /// </summary>
        public string PostalCode { get; set; }

        /// <summary>
        /// The country where a client is situated.
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// The phone number of a client.
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// The fax of a client.
        /// </summary>
        public string Fax { get; set; }

        /// <summary>
        /// The list of client orders. 
        /// </summary>
        public IList<OrderModel> Orders { get; set; }


        public override string ToString()
        {
            return
                $"---------{ClientId} --------- {Environment.NewLine} Comany's name : {CompanyName} {Environment.NewLine} Сountry:  {Country} | City: {City} | Region: {Region} {Environment.NewLine} ----------Contact Info--------- {Environment.NewLine} Address: {Address} | Postal Code: {PostalCode} | Phone Number: {PhoneNumber} | Fax: {Fax} {Environment.NewLine}";
        }
    }
}
