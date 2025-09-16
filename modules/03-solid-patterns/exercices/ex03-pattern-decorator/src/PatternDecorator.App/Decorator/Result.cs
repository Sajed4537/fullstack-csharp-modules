using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternDecorator.App.Decorator
{
    internal class Result
    {
        public decimal SousTotal { get; set; }
        public decimal Remise { get; set; }
        public decimal TotalAvantSurcharges { get; set; }
        public List<Surcharge> Surcharges { get; set; }
        public decimal TotalFinal { get; set; }

        public Result(decimal sousTotal, decimal remise, decimal totalAvantSurcharges,  decimal totalFinal, List<Surcharge> surcharges = null)
        {
            SousTotal = sousTotal;
            Remise = remise;
            TotalAvantSurcharges = totalAvantSurcharges;
            TotalFinal = totalFinal;
            if(surcharges == null)
            {
                Surcharges = new List<Surcharge>();
            }
            else
            {
                Surcharges = surcharges;
            }
            
        }


    }
}
