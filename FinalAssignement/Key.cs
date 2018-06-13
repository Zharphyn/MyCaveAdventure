using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zharphyn
{
    class Key : Item
    {
        public Key() : base()
        {
            CanBePickedUp = true;
        }

        public Key(string Appearance) : base()
        {
            CanBePickedUp = true;
            this.Appearance = Appearance;
        }
    }
}
