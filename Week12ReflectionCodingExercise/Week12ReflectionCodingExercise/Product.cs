using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week12ReflectionCodingExercise
{
    /// <summary>
    /// Creates a product with properties and methods.
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Default constructor for Product.
        /// </summary>
        public Product()
        {

        }

        public int SalesRevenue { get; set; }

        public int CostOfGoodsSold { get; set; }

        /// <summary>
        /// Calculates profit margin of a product.
        /// </summary>
        /// <param name="netIncome">Income after expenses.</param>
        /// <param name="netSales">Sales after expenses.</param>
        /// <returns>The profit margin as a converted percentage number, without the percent sign of course.</returns>
        private double ProfitMargin(double netIncome, double netSales)
        {
            double result = (double)(netIncome / netSales) * 100;
            return result;
        }
    }
}
