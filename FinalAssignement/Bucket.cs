using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zharphyn
{
    class Bucket : Item
    {
        bool filled;

        public Bucket() : base()
        {
            filled = false;
            CanBePickedUp = true;
            Appearance = "A small wooden bucket";
        }

        public Bucket(string Appearance) : base()
        {
            filled = false;
            CanBePickedUp = true;
            this.Appearance = Appearance;
        }

        public bool Filled
        {
            get
            {
                return filled;
            }
            set
            {
                filled = value;
                if (Filled)
                {
                    Appearance = "A small wooden bucket filled with water";
                }
                else
                {
                    Appearance = "A small wooden bucket";
                }
            }
        }

    }
}
