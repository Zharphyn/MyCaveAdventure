using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zharphyn
{
    class NPC : Item
    {
        string gender = "unknown";
        string pickup = "";
        string speak = "";


        public NPC() : base()
        {
            CanBePickedUp = false;
        }

        public NPC(string Appearance) : base()
        {
            this.Appearance = Appearance;
        }

        public string Speak
        {
            get
            {
                return this.speak;
            }
            set
            {
                this.speak = value;
            }
        }

        public string PickUp
        {
            get
            {
                return this.pickup;
            }
            set
            {
                this.pickup = value;
            }
        }

        public string Gender
        {
            get
            {
                return this.gender;
            }
            set
            {
                this.gender = value;
            }
        }

    }
}
