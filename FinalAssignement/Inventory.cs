using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Zharphyn
{
    class Inventory
    {
        List<Item> stuff;
        
        public Inventory()
        {
            stuff = new List<Item>();
        }

        public void AddItem(Item value)
        {
            stuff.Add(value);
        }

        public Item Drop(Item value)
        {
            Item found = new Item();

            foreach (Item item in stuff)
            {
                if (item.GetType() == value.GetType())
                {
                    found = item;
 
                }
            }
            stuff.Remove(found);
            return found;
        }

        public Item GetItem(Item value)
        {
            Item found = new Item();

            foreach (Item item in stuff)
            {
                if (item.GetType() == value.GetType())
                {
                    found = item;
                }
            }

            return found;
        }

        public bool InInventory(Item thing)
        {
            bool found = false;
            foreach (Item item in stuff)
            {
                if (item.GetType() == thing.GetType())
                {
                    found = true;
                    break;
                }
            }
            return found;
        }

        public List<Item> FullInventory
        {
            get
            {
                return stuff;
            }
            private set { }
        }

        public int CountItems()
        {
            return stuff.Count;
        }

    }
}
