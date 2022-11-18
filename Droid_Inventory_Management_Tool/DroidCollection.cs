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
    /// wrapper for the droid collection array
    /// allows for simple encapsulation of the array data
    /// </summary>
    class DroidCollection
    {
        const uint COLLECTION_SIZE = 100;

        uint currentSize = 0;
        Droid[] droidCollection = new Droid[COLLECTION_SIZE];

        /// <summary>
        /// does the actual work of adding a passed droid object to the array
        /// </summary>
        /// <param name="droid">passed object</param>
        public void AddDroid(Droid droid)
        {
            try
            {
                droidCollection[currentSize] = droid;
                ++currentSize;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
        /// <summary>
        /// Converts the collection to a string
        /// </summary>
        /// <returns>returns the formatted string that can be output by user interface</returns>
        public override string ToString()
        {
            string returnString = "";
            foreach (Droid droid in droidCollection)
            {
                if (droid != null)
                    returnString += droid.ToString() + Environment.NewLine;
            }
            return returnString;
        }
    }
}
