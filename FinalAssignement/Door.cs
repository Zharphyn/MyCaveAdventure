using System;

namespace Zharphyn
{
    class Door
    {
        private bool isOpen;
        public bool IsOpen
        {
            get { return isOpen; }
            set { isOpen = value; }
        }

        Room[] connectedRooms;

        public Door() { }
        
        public void ConnectDoor(Room room01, Room room02)
        {
            IsOpen = true;
            connectedRooms = new Room[2];
            connectedRooms[0] = room01;
            connectedRooms[1] = room02;
        }

        public void OpenDoor()
        {
            if(isOpen)
            {
                if(connectedRooms[0].IsPlayer)
                {
                    connectedRooms[0].LeaveRoom();
                    connectedRooms[1].EnterRoom();
                }
                else
                {
                    connectedRooms[1].LeaveRoom();
                    connectedRooms[0].EnterRoom();
                }
            }
            else { FinalProject.Program.Write("This door is closed\n"); }
        }
    }
}