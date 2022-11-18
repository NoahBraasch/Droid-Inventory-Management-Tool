// Noah Braasch
// October 14 2022

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Droid_Inventory_Management_Tool
{
    public abstract class Droid : IDroid
    {
        //Variables
        private string material;
        private string color;
        private decimal totalCost;

        //Properties
        //This property is now virtual because it may need to be overridden in inherited methods
        public virtual decimal TotalCost
        {
            get { return totalCost; }
            set { totalCost = value; }
        }

        // Constructors
        // This constructor forces all droids regardless of other constructors to at the bare minimum need a material and color
        public Droid (string Material, string Color)
        {
            this.material = Material;
            this.color = Color;
        }

        //Methods

        /// <summary>
        /// THis method was originally abstract because it was unclear how it needed to be implemented. 
        /// As the program evolved, it became clear that each droid would need its type, cost, 
        /// material and color printed to screen and so those attributes of the tostring method
        /// were implemented here first and inherited by all other droid sub-classes
        /// </summary>
        /// <returns>the first part of a droid string</returns>
        public override string ToString()
        {
            CalculateTotalCost();
            return "Type: " + String.Format(this.GetType().Name) + Environment.NewLine + Environment.NewLine +
                   "Cost: " + this.totalCost + Environment.NewLine + Environment.NewLine +
                   "Material: " + this.material + Environment.NewLine +
                   "Color: " + this.color + Environment.NewLine;
        }

        /// <summary>
        /// declared as virtual because there is no body to override in the interface implamented
        /// this method calculates the total cost of the droid. (Given that it is a base droid)
        /// In each inherited class, this base method is first called and then the additional costs
        /// are added 
        /// </summary>
        public virtual void CalculateTotalCost() 
        { 
            switch (this.material) 
            {
                case "Aluminum":
                    this.totalCost += 100.0m;
                    break;

                case "Steel":
                    this.totalCost += 500.0m; 
                    break;

                case "Tungsten Carbide":
                    this.totalCost += 2000.0m;
                    break;

                case "Gold":
                    this.totalCost += 500000.00m;
                    break;
            }
            switch (this.color) 
            {
                case "Red":
                    this.totalCost += 50.0m;
                    break;

                case "Orange":
                    this.totalCost += 50.0m;
                    break;

                case "Yellow":
                    this.totalCost += 50.0m;
                    break;

                case "Green":
                    this.totalCost += 50.0m;
                    break;

                case "Blue":
                    this.totalCost += 50.0m;
                    break;

                case "Purple:":
                    this.totalCost += 50.0m;
                    break;

                case "Protective Coating":
                    this.totalCost += 2000.0m;
                    break;

                case "No Color":
                    break;
                
            }
        }
    }
}
