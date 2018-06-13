using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zharphyn;
using System.Collections;

namespace FinalProject
{
    class Program
    {
        const int timer = 20;  // number of milliseconds between each character being written to the display
        
        // Create n number of room Instances 
        public static Room[] CreateMaze(int number)
        {
            Room[] maze = new Room[number];
            
            for(int i = 0; i < number; i++)
            {
                maze[i] = new Room();
            }
            return maze;
        }

        // Create n number of Inventory instances
        public static Inventory[] CreateRoomsInventory(int number)
        {
            Inventory[] inventories = new Inventory[number];

            for (int i = 0; i < number; i++)
            {
                inventories[i] = new Inventory();
            }
            return inventories;
        }

        // Create n number of Door instances
        public static Door[] CreateConnections(int number)
        {
            Door[] connections = new Door[number];

            for (int i = 0; i < number; i++)
            {
                connections[i] = new Door();
            }
            return connections;
        }

        // Move the player through the map
        public static void GoAction(string userInput, Door[] door)
        {
            switch (userInput)
            {
                case "north":
                    if(door[0] != null)
                    {
                        door[0].OpenDoor();
                    }
                    else { Write("You can't go in that direction.\n"); }
                    break;
                case "east":
                    if (door[1] != null)
                    {
                        door[1].OpenDoor();
                    }
                    else { Write("You can't go in that direction.\n"); }
                    break;
                case "south":
                    if (door[2] != null)
                    {
                        door[2].OpenDoor();
                    }
                    else { Write("You can't go in that direction.\n"); }
                    break;
                case "west":
                    if (door[3] != null)
                    {
                        door[3].OpenDoor();
                    }
                    else { Write("You can't go in that direction.\n"); }
                    break;
                default:
                    Write("You can't go in that direction.\n");
                    break;
            }
        }
           
        // because of how the actions are structured, some commands will not work,
        // so we correct it to the correct command
        static string CleanAction(string userInput)
        {
            switch (userInput)
            {
                case "w":
                case "west":
                    userInput = "go west";
                    break;
                case "e":
                case "east":
                    userInput = "go east";
                    break;
                case "n":
                case "north":
                    userInput = "go north";
                    break;
                case "s":
                case "south":
                    userInput = "go south";
                    break;
                case "get water":
                    userInput = "use sink";
                    break;
            }
            return userInput;
        }

        // Validate actions and execute them
        public static void MakeActions(Room[] maze, Player player)
        {
            string userInput = Console.ReadLine();
            userInput = CleanAction(userInput.ToLower());


            // Check if the user enter something
            if (userInput.Length <= 0)
            {
                Write("You need an action.\n");
            }
            else
            {
                int index = userInput.IndexOf(' '); ;
                string userAction;
                string userSelection;
                // Check if the user enter two words
                try
                {
                    userAction = userInput.Substring(0, index);
                    userSelection = userInput.Substring(index + 1);
                }
                catch
                {
                    Write("You need an action and an object.\n");
                    return;
                }




                // Make user action
                switch (userAction)
                {
                    case "go":
                        foreach (Room room in maze)
                        {
                            if (room.IsPlayer)
                            {
                                GoAction(userSelection, room.Cardinal);
                                break;
                            }
                        }
                        break;
                    case "get":
                    case "pick":
                        foreach (Room room in maze)
                        {
                            if (room.IsPlayer)
                            {
                                foreach (Item item in room.Inventory.FullInventory)
                                {
                                    if (item.Name == userSelection && item.CanBePickedUp)
                                    {
                                        player.Inventory.AddItem(item);
                                        room.Inventory.Drop(item);
                                        Write(player.Name + " " + "Added" + " " + item.Name + " " + "to inventory\n");
                                        return;
                                    }
                                    else if (item.Name == userSelection && !item.CanBePickedUp)
                                    {
                                        Write("Can't pick that.\n");
                                        return;
                                    }
                                }
                                Write("You can't find such item.\n");
                            }
                        }
                        break;
                    // WIP
                    case "drop":
                        if (player.Inventory.CountItems() <= 0)
                        {
                            Write("No items in inventory.\n");
                        }
                        else
                        {
                            foreach (Item item in player.Inventory.FullInventory)
                            {
                                if (item.Name == userSelection)
                                {
                                    player.Inventory.Drop(item);
                                    foreach (Room room in maze)
                                    {
                                        if (room.IsPlayer)
                                        {
                                            room.Inventory.AddItem(item);
                                        }
                                    }
                                    return;
                                }
                                else { Write("You don't have such item.\n"); }
                            }
                        }

                        break;
                    //case "fill":
                    case "check":
                        if (userSelection == "room")
                        {
                            foreach (Room room in maze)
                            {
                                if (room.IsPlayer)
                                {
                                    if (room.Inventory.CountItems() <= 0)
                                    {
                                        Write("You can't see much around.\n");
                                    }
                                    else
                                    {
                                        foreach (Item item in room.Inventory.FullInventory)
                                        {
                                            Write("You can see" + " " + item.Appearance + "\n");
                                        }
                                    }

                                }

                            }
                        }
                        else if (userSelection == "inventory")
                        {
                            if (player.Inventory.CountItems() <= 0)
                            {
                                Write("No items in inventory.\n");
                            }
                            else
                            {
                                foreach (Item item in player.Inventory.FullInventory)
                                {
                                    if (player.Inventory.CountItems() == 1)
                                        Write("Your inventory contains" + " " + item.Appearance + "\n");
                                    else
                                        Write("Your inventory contains" + " " + item.Appearance + " " + "\n");
                                }
                            }
                        }

                        else { Write("Selection not recognized.\n"); }
                        break;
                    case "use":
                        if (userSelection == "sink")
                        {
                            if (player.Inventory.InInventory(new Bucket()))
                            {
                                Bucket bucket = (Bucket)player.Inventory.GetItem(new Bucket());
                                bucket.Filled = true;
                                Write("Bucket filled!. \n");
                            }
                            else
                            {
                                Write("Water splashes on the floor...\n");
                            }
                        }
                        else
                        {
                            Write("I do not know how to use that!\n");
                        }
                        break;
                    case "talk":
                        if (userSelection == "brad" || userSelection == "man")
                        {
                            foreach (Room room in maze)
                            {
                                if (room.IsPlayer)
                                {
                                    if (room.Inventory.InInventory(new NPC()))
                                    {
                                        NPC Brad = (NPC)room.Inventory.GetItem(new NPC());
                                        Write(Brad.Speak + "\n");
                                    }
                                    else
                                    {
                                        Write("There's no one else here.\n");
                                    }
                                }
                            }
                        }
                        else
                        {
                            Write("I cannot talk to that!\n");
                        }
                        break;
                    case "water":
                        if (userSelection == "plant")
                        {
                            if (player.Inventory.InInventory(new Bucket()))
                            {
                                Bucket bucket = (Bucket)player.Inventory.GetItem(new Bucket());
                                if (bucket.Filled)
                                {
                                    foreach (Room room in maze)
                                    {
                                        if (room.Inventory.InInventory(new Plant()))
                                        {
                                            Plant plant = (Plant)room.Inventory.GetItem(new Plant());
                                            plant.Water();
                                            bucket.Filled = false;
                                            Write(player.Name + " " + "poured water over the plant.\n");
                                            Write(plant.Appearance + "\n");
                                            if (plant.Size() == PlantSize.LARGE)
                                            {
                                                plant.Appearance = "There is a massive plant in here. The top of it has broken through the ceiling.";
                                                room.Inventory.AddItem(CreateKey());
                                            }
                                        }
                                    }

                                }
                            }
                        }
                        else
                        {
                            Write("I do not know how to water that!\n");
                        }
                        break;
                    case "read":
                        if (userSelection == "book" || userSelection == "journal")
                        {
                            if (player.Inventory.InInventory(new Paper()))
                            {
                                Paper journal = (Paper)player.Inventory.GetItem(new Paper());
                                Write(journal.Writing + "\n");
                            }
                            else
                            {
                                Write("You aren't carrying anything that you can read.\n");
                            }
                        }
                        else
                        {
                            Write("I do not know how to read that!\n");
                        }
                        break;
                    case "unlock":
                        if (userSelection == "door")
                        {
                            if (player.Inventory.InInventory(new Key()))
                            {
                                foreach (Room room in maze)
                                {
                                    if (!room.Cardinal[1].IsOpen)
                                    {
                                        room.Cardinal[1].IsOpen = true;
                                        Write("You opened the door!. \n");
                                        return;
                                    }
                                }
                            }
                        }
                        else
                        {
                            Write("I do not know how to unlock that!\n");
                        }
                        break;
                    default:
                        Write("Action not recognized\n");
                        break;
                }

            }
        }

        // Make text appear as if it was being typed
        public static void Write(string text)
        {
            foreach (char letter in text)
            {
                // Add \n so it breaks a line every time
                Console.Write(letter);
                System.Threading.Thread.Sleep(timer);
            }
            
        }

        // Create the different items
        static Sink CreateSink()
        {

            string Description = "A battered metal sink";
            Sink sink = new Sink(Description);
            sink.Name = "sink";

            return sink;

        }

        static Key CreateKey()
        {
            string Description = "An old key to open a door.";
            Key key = new Key(Description);
            key.Name = "key";
            return key;
        }

        static Bucket CreateBucket()
        {
            string Description = "A small wooden bucket";
            Bucket bucket = new Bucket(Description);
            bucket.Name = "bucket";

            return bucket;

        }

        static Rock CreateRock()
        {
            string Description = "A small grey rock.";
            Rock rock = new Rock(Description);
            rock.Name = "rock";
            return rock;
        }

        static Paper CreateJournal()
        {
            string Description = "A small book.";
            Paper Journal = new Paper(Description);
            Journal.Name = "book";
            Journal.Writing = "Day 1, I have awoken in a strange room. I do not know what is going on.";
            Journal.Writing += "\nDay 2, There are only a couple of rooms, I do not know what I will do";

            return Journal;
        }

        static NPC CreateBrad()
        {
            string Description = "There is a man, standing in the corner. He is overweight and middle-aged. He is wearing glasses.";
            NPC Brad = new NPC(Description);
            Brad.Name = "brad";
            Brad.Gender = "man";
            Brad.Speak = "Hi, my name is Brad.";
            Brad.PickUp = "You try to pick up the " + Brad.Gender + ". But you are not successful. The " + Brad.Gender + " looks at you strangely";

            return Brad;
        }

        static Plant CreatePlant()
        {
            Plant plant = new Plant();
            plant.Name = "plant";
            return plant;
        }

        // Run functions in order for the game
        public static void Game()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            //Create a new player
            Player newPlayer = new Player();

            if (newPlayer.Name == "")
            {
                Write("What's your name?\n");

                newPlayer.Name = Console.ReadLine();
                newPlayer.Inventory = new Inventory();
                //newPlayer.Inventory.AddItem(CreateKey());
            }
            else
            {
                //Continue game
            }

            //Create the maze
            Room[] newMaze = CreateMaze(5);
            Inventory[] inventories = CreateRoomsInventory(5);
            Door[] connections = CreateConnections(4);

            //Connect doors
            connections[0].ConnectDoor(newMaze[0], newMaze[4]);
            connections[0].IsOpen = false;
            connections[1].ConnectDoor(newMaze[0], newMaze[1]);
            connections[2].ConnectDoor(newMaze[1], newMaze[2]);
            connections[3].ConnectDoor(newMaze[2], newMaze[3]);

            //Create Rooms
            inventories[0].AddItem(CreateJournal());
            inventories[0].AddItem(CreateBrad());
            newMaze[0].CreateRoom(5, 5, 2, connections, "Old room, it seems like no one has cleaned it for a few weeks now", inventories[0]);
            newMaze[0].Cardinal[1] = connections[0];
            newMaze[0].Cardinal[2] = connections[1];

            inventories[1].AddItem(CreateSink());
            
            newMaze[1].CreateRoom(5, 5, 2, connections, "It seems to be empty...", inventories[1]);
            newMaze[1].Cardinal[0] = connections[1];
            newMaze[1].Cardinal[1] = connections[2];

            inventories[2].AddItem(CreateBucket());
            newMaze[2].CreateRoom(5, 5, 2, connections, "Seems like an old cleaning room, there's dust every wear and it seems like the pipes are not working anymore", inventories[2]);
            newMaze[2].Cardinal[3] = connections[2];
            newMaze[2].Cardinal[1] = connections[3];

            inventories[3].AddItem(CreatePlant());
            newMaze[3].CreateRoom(5, 5, 1, connections, "Looks like an old botanic garden.", inventories[3]);
            newMaze[3].Cardinal[3] = connections[3];

            newMaze[4].CreateRoom(5, 5, 1, connections, "You reached the exit.\nCongratulations!", inventories[4]);
            //newMaze[4].Cardinal[3] = connections[0];

            newMaze[0].EnterRoom();

            // Read player input and executre actions
            while (!newMaze[4].IsPlayer)
            {
                //Console.Clear();
                Write(newPlayer.Name + " " +"what do you want to do?\n");
                MakeActions(newMaze, newPlayer);
                //System.Threading.Thread.Sleep(1500);
            }
        }

        static void Main(string[] args)
        {
            //Console.WriteLine();
            Game();
            Console.ReadLine();
        }
    }
}
