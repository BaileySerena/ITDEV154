using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenAddressing
{
    class GroceryRecord
    {
        private int groceryID;
        private String groceryName;

        public GroceryRecord(int i, String name)
        {
            groceryID = i;
            groceryName = name;
        }

        public int getgroceryId()
        {
            return groceryID;
        }

        public void setgroceryId(int i)
        {
            groceryID = i;
        }
        
        public String toString()
        {
            return groceryID + " " + groceryName + " ";
        }
    }
}
