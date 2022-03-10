using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FreeTime
{
    public class GameSetUp
    {

        public Room setUpGameRoom()
        {

            List<Room> roomList = new List<Room>();
            Room room1 = new Room(2, 1, 1, 1, 1, "Starting room", "room1");
            Room room2 = new Room(3, 2, 1, 2, 2, "Mid room", "room2");
            Room room3 = new Room(4, 3, 2, 3, 3, "Ending room", "room3");
            Room room4 = new Room(1, 2, 3, 4, 4, "Extra room", "room4");
            Items item1 = new Items("item1", "This is item 1", 1);
            room1.addItem(item1);
            roomList.Add(room1);
            roomList.Add(room2);
            roomList.Add(room3);
            roomList.Add(room4);

            //might have to return the whole roomList instead
            return roomList[0];

        }
        public Player setUpGamePlayer()
        {
            Player mainPlayer = new Player("player1", 23);

            return mainPlayer;
        }
    }
}