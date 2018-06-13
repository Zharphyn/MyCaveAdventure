using System;

namespace Zharphyn
{
    class Room
    {
        private Door[] roomDoors;
        private Door[] cardinal = new Door[4];
        private Inventory inventory;

        private int height;
        private int width;
        private string roomDescription;
        private int numberOfDoors;
        private bool isPlayer;

        public Inventory Inventory
        {
            get { return inventory; }
            private set { inventory = value; }
        }


        public int Height
        {
            get { return height; }
            private set { }
        }

        public int Width
        {
            get { return width; }
            private set { }
        }

        public bool IsPlayer
        {
            get { return isPlayer; }
            set { isPlayer = value; }
        }

        public Door[] Cardinal
        {
            get { return cardinal; }
            set { cardinal = value; }
        }

        // Constructor
        public Room()
        {
            isPlayer = false;

            for (int i = 0; i < cardinal.Length; i++)
            {
                cardinal[i] = null;
            }
        }
        
        // Create room
        public void CreateRoom (int height, int width, int numberOfDoors, Door[] roomDoors, string roomDescription, Inventory inventory)
        {
            this.height = height;
            this.width = width;

            this.numberOfDoors = numberOfDoors;
            this.roomDoors = roomDoors;

            this.roomDescription =  roomDescription;
            this.inventory = inventory;
        }

        // Actions to make when the player enters the room
        public void EnterRoom()
        {
            // Brief description of what is in the room
            // Check for what is in the room inventory
            IsPlayer = true;
            FinalProject.Program.Write("You enter a room: " + " " + roomDescription + "\n");
            
            if(numberOfDoors > 1)
            {
                FinalProject.Program.Write("There are" + " " + numberOfDoors + " doors" + ",");
                for (int i = 0; i < Cardinal.Length; i++)
                {
                    if (Cardinal[i] != null)
                    {
                        switch (i)
                        {
                            case 0:
                                FinalProject.Program.Write("One to the north");
                                break;
                            case 1:
                                FinalProject.Program.Write("One to the east");
                                break;
                            case 2:
                                FinalProject.Program.Write("One to the south");
                                break;
                            case 3:
                                FinalProject.Program.Write("One to the west");
                                break;

                        }
                        if(i < numberOfDoors)
                            FinalProject.Program.Write(" and ");
                    }
                }
                FinalProject.Program.Write("\n");
            }
            else if(numberOfDoors <= 1)
            {
                for (int i = 0; i < Cardinal.Length; i++)
                {
                    if (Cardinal[i] != null)
                    {
                        switch (i)
                        {
                            case 0:
                                FinalProject.Program.Write("There's a door to the north");
                                break;
                            case 1:
                                FinalProject.Program.Write("There's a door to the east");
                                break;
                            case 2:
                                FinalProject.Program.Write("There's a door to the south");
                                break;
                            case 3:
                                FinalProject.Program.Write("There's a door to the west");
                                break;

                        }
                    }
                }
                FinalProject.Program.Write("\n");
            }

            foreach (Item item in inventory.FullInventory)
            {
                FinalProject.Program.Write("You can see"+ " " + item.Appearance + "\n");
            }
            
        }

        
        public void LeaveRoom()
        {
            FinalProject.Program.Write("You left the room\n");
            IsPlayer = false;
        }

    }
}

