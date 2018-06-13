using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zharphyn
{
    class Rock : Item
    {

        public Rock() : base()
        {
            CanBePickedUp = true;
        }

        public Rock(string Appearance) : base()
        {
            this.Appearance = Appearance;
        }
    }
}
