using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zharphyn
{
    class Sink : Item
    {
        
        public Sink() : base()
        {
            CanBePickedUp = false;

        }

        public Sink(string Appearance) : base()
        {
            this.Appearance = Appearance;
            CanBePickedUp = false;
        }




    }
}
