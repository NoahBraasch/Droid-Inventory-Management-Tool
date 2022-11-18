// Noah Braasch
// October 14 2022

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Droid_Inventory_Management_Tool
{
    class AstromechDroid : UtilityDroid
    {
        // Variables
        private bool hasNavigation;
        private uint numberShips;

        private const decimal COST_PER_SHIP = 20000m;
        private const decimal BASE_ASTROMECH_COST = 150.0m;

        // Properties
        public bool HasNavigation
        {
            get { return this.hasNavigation; }
            set { hasNavigation = value; }
        }
        public uint NumberShips
        {
            get { return numberShips; }
            set { numberShips = value; }
        }

        // Methods
        /// <summary>
        /// same as before, formmated string onto previously created formatted string
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return base.ToString() +
                "Has Navigation: " + this.hasNavigation + Environment.NewLine +
                "Number of Ships: " + this.numberShips + Environment.NewLine;
        }
        /// <summary>
        /// same as before. Additional costs to costs calculated in parent classes
        /// </summary>
        public override void CalculateTotalCost()
        {
            this.TotalCost += BASE_ASTROMECH_COST;

            base.CalculateTotalCost();
            if (this.hasNavigation == true)
                this.TotalCost += 5000.0m;

            this.TotalCost += (numberShips * COST_PER_SHIP);
        }
        // Constructors
        /// <summary>
        /// again again same thing as before, but with more parameters than standard utility droid
        /// </summary>
        /// <param name="Material"></param>
        /// <param name="Color"></param>
        /// <param name="ToolBox"></param>
        /// <param name="ComputerConnection"></param>
        /// <param name="Scanner"></param>
        /// <param name="Navigation"></param>
        /// <param name="NumberShips"></param>
        public AstromechDroid(string Material, string Color, bool ToolBox, bool ComputerConnection, bool Scanner, bool Navigation, uint NumberShips) : base(Material, Color, ToolBox, ComputerConnection, Scanner)
        {
            this.hasNavigation = Navigation;
            this.numberShips = NumberShips;
        }
    }
}
