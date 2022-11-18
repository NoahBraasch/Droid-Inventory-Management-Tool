// Noah Braasch
// October 14 2022

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Droid_Inventory_Management_Tool
{
    /// <summary>
    /// a droid class that inherits from utility droid
    /// </summary>
    class JanitorDroid : UtilityDroid
    {
        // Variables
        private bool broom;
        private bool vacuum;

        private decimal JANITOR_BASE_COST = 50.0m;

        // Properties
        public bool Broom
        {
            get { return broom; }
            set { broom = value; }
        }
        public bool Vacuum
        {
            get { return vacuum; }
            set { vacuum = value; }
        }

        // Methods
        /// <summary>
        /// again appends more formatted string information to the string created in the parent
        /// class
        /// </summary>
        /// <returns>formatted string</returns>
        public override string ToString()
        {
            return base.ToString() +
                "Has Broom: " + this.broom + Environment.NewLine +
                "Has Vacuum: " + this.vacuum + Environment.NewLine;
        }
        /// <summary>
        /// adds the cost of this droid to the total costs calculated by the parent classes
        /// </summary>
        public override void CalculateTotalCost()
        {
            this.TotalCost += JANITOR_BASE_COST;

            base.CalculateTotalCost();
            if (this.broom == true)
                this.TotalCost += 10.0m;
            if (this.vacuum == true)
                this.TotalCost += 100.0m;
        }

        // Constructors
        /// <summary>
        /// same thing as the previous constructors in parent classes just with more parameters
        /// </summary>
        /// <param name="Material"></param>
        /// <param name="Color"></param>
        /// <param name="ToolBox"></param>
        /// <param name="ComputerConnection"></param>
        /// <param name="Scanner"></param>
        /// <param name="Broom"></param>
        /// <param name="Vacuum"></param>
        public JanitorDroid(string Material, string Color, bool ToolBox, bool ComputerConnection, bool Scanner, bool Broom, bool Vacuum) : base(Material, Color, ToolBox, ComputerConnection, Scanner)
        {
            this.broom = Broom;
            this.vacuum = Vacuum;
        }
    }
}
