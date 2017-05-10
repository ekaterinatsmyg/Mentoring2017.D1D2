using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MentoringD1D2.LINQ.Task1.Data.Models
{
    /// <summary>
    /// Model that represents provider entity.
    /// </summary>
    public class ProviderModel
    {
        /// <summary>
        /// The provider's name.
        /// </summary>
        public string ProviderName { get; set; }

        /// <summary>
        /// The address of a provider's office.
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// The city where a provider's office is situated.
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// The country where a provider's office is situated.
        /// </summary>
        public string Country { get; set; }

        public override string ToString()
        {
            return $"Provider : {ProviderName} | Country : {Country} | Сity : {City} {Environment.NewLine} -------Contac Info:--------  {Environment.NewLine} Address : {Address}  {Environment.NewLine}";
        }
    }
}
