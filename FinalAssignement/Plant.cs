using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zharphyn 
{
    enum PlantSize { SMALL, MEDIUM, LARGE }
    class Plant : Item
    {
        PlantSize growth;

        public Plant() : base()
        {
            Appearance = "There is a small plant in the corner of the room";
            growth = PlantSize.SMALL;
            CanBePickedUp = false;
        }

        public void Water()
        {
            switch (growth)
            {
                case PlantSize.SMALL:
                    growth = PlantSize.MEDIUM;
                    Appearance = "There is a large imposing plant here. The top of it almost reaches the ceiling!";
                    break;
                case PlantSize.MEDIUM:
                    growth = PlantSize.LARGE;
                    Appearance = "There is a massive plant in here. The top of it has broken through the ceiling, and you a key dropped to the floor";
                    break;

            }
        }
        new public string Interact()
        {
            string message = "";

            switch (growth)
            {
                case PlantSize.SMALL:
                    message = "You poke the small plant, and nothing seems to happen.";
                    break;
                case PlantSize.MEDIUM:
                    Appearance = "The plant is clearly not strong enough for you to climb.";
                    break;
                case PlantSize.LARGE:
                    Appearance = "You climb the plant, and escape to freedom!";
                    break;
            }
            return message;
        }

        public PlantSize Size()
        {
            return this.growth;
        }
    }
}
