using System;

namespace Zharphyn
{
    class Player
    {
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private Inventory inventory;
        public Inventory Inventory
        {
            get { return inventory; }
            set { inventory = value; }
        }

        public Player()
        {
            Name = "";
        }

    }
}

