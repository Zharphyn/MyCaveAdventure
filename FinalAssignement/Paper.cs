using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zharphyn
{
    class Paper : Item
    {
        string writing = "";
        bool torn = false;

        public Paper() : base()
        {
            Breakable = true;
        }

        public Paper(String Appearance) : base()
        {
            Breakable = true;
            this.Appearance = Appearance;
            CanBePickedUp = true;
        }

        public string Writing
        {
            get
            {
                return writing;
            }
            set
            {
                writing = value;
            }
        }
        private bool Torn
        {
            set
            {
                torn = value;
            }
            get
            {
                return torn;
            }
        }

        public void TearUp()
        {
            Torn = true;
            Console.WriteLine("You tear the paper up into tiny pieces and throw it on the floor.");

        }
    }
}
