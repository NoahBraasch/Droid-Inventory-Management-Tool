// Noah Braasch
// October 14 2022

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Droid_Inventory_Management_Tool
{
    class ProtocolDroid : Droid
    {
        // Variables
        private uint numberLanguages;

        private const decimal COST_PER_LANGUAGE = 1000.0m;
        private const decimal PROTOCOL_BASE_COST = 200.0m;

        // Properites
        public uint NumberLanguages
        {
            get { return numberLanguages; }
            set { numberLanguages = value; }
        }

        //Methods 

        /// <summary>
        /// Again takes the base to string and appends more information that is needed to describe this droid
        ///
        /// </summary>
        /// <returns>formatted string</returns>
        public override string ToString()
        {
            return base.ToString() +
                "Number of Langugages: " + this.numberLanguages + Environment.NewLine;
        }
        /// <summary>
        /// again takes the parent class's total cost and adds to it the extra costs from this class
        /// </summary>
        public override void CalculateTotalCost()
        {
            this.TotalCost += PROTOCOL_BASE_COST;

            base.CalculateTotalCost();
            this.TotalCost += (this.numberLanguages * COST_PER_LANGUAGE);
        }

        // Constructor
        // This constructor has the required constructor elements as dictated by the Droid base class but also adds
        // a number of languages at another requried element
        public ProtocolDroid(string Material, string Color, uint NumberLanugages) : base( Material, Color)
        {
            this.numberLanguages = NumberLanugages;
        }
    }
}
