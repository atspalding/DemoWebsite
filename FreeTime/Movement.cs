using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FreeTime
{
    public class Movement
    {

        private String Direction;
        private Room currentRoom;


        public Movement(Room currentRoomInput)
        {
            this.currentRoom = currentRoomInput;
        }

        public int moveRoom(Room input, String direction)
        {
            int i = 0;
            this.currentRoom = input;
            this.Direction = direction;
            if (Direction.Equals("n"))
            {
                i = currentRoom.getNorth();
            }
            else if (Direction.Equals("e"))
            {
                i = currentRoom.getEast();
            }
            else if (Direction.Equals("s"))
            {
                i = currentRoom.getSouth();
            }
            else if (Direction.Equals("w"))
            {
                i = currentRoom.getWest();
            }
            return i;
        }


    }
}