// Noah Braasch
// October 14 2022

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Droid_Inventory_Management_Tool
{
    class UtilityDroid : Droid
    {
        // Variables
        private bool hasToolbox;
        private bool hasComputerConnection;
        private bool hasScanner;

        private const decimal UTILITY_BASE_COST = 100.0m;

        // Properties
        public bool HasToolbox 
        {
            get { return this.hasToolbox; }
            set { this.hasToolbox = value; }
        }

         public bool HasComputerConnection
        {
            get { return this.hasComputerConnection; }
            set { this.hasComputerConnection = value; }
        }
        public bool HasScanner
        {
            get { return this.hasScanner; }
            set { this.hasScanner = value; }
        }
        // Methods
        /// <summary>
        /// Takes the base to string method and appends more text based on the properties this inherited
        /// droid has
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return base.ToString() +
                "Has Toolbox: " + this.hasToolbox + Environment.NewLine +
                "Has Computer Connection: " + this.hasComputerConnection + Environment.NewLine +
                "Has Scanner: " + this.hasScanner + Environment.NewLine;
        }
        /// <summary>
        /// takes the base total cost from this droids parent class and adds to it the additional costs 
        /// for this class of droid
        /// </summary>
        public override void CalculateTotalCost()
        {
            this.TotalCost += UTILITY_BASE_COST;

            base.CalculateTotalCost();

            if (this.hasToolbox == true)
                this.TotalCost += 25.0m;

            if (this.hasComputerConnection == true)
                this.TotalCost += 30.0m;

            if (this.hasScanner == true)
                this.TotalCost += 45.0m;

        }

        // Constructors
        /// <summary>
        /// takes all required parameters to describe the droid as parameters for the constructor 
        /// </summary>
        /// <param name="Material"></param>
        /// <param name="Color"></param>
        /// <param name="ToolBox"></param>
        /// <param name="ComputerConnection"></param>
        /// <param name="Scanner"></param>
        public UtilityDroid(string Material, string Color, bool ToolBox, bool ComputerConnection, bool Scanner) : base(Material, Color)
        {
            this.hasToolbox = ToolBox;
            this.hasComputerConnection = ComputerConnection;
            this.hasScanner = Scanner;
        }
    }
}
