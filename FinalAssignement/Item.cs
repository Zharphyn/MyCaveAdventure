using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zharphyn
{
    class Item
    {
        string name;
        bool _breakable;
        string _appearance;
        bool _canBeCarried;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public Item()
        {
            Breakable = false;

        }

        protected void Interact() { }

        public string Appearance
        {
            get
            {
                return _appearance;
            }
            set
            {
                _appearance = value;
            }
        }

        public bool Breakable
        {
            get
            {
                return _breakable;
            }
            set
            {
                try
                {
                    _breakable = value;
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }
                
            }
        }

        public bool CanBePickedUp
        {
            get
            {
                return _canBeCarried;
            }
            set
            {
                _canBeCarried = value;
            }
        }


    }
}
