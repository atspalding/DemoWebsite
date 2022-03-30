using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FreeTime
{
    public class Room
    {

        private int North;
        private int East;
        private int South;
        private int West;
        private int RoomNumber;
        private String Info;
        private String roomName;
        private List<Items> ItemList;

        public Room(int North, int East, int South, int West, int RoomNumber, String Info, String name)
        {
            this.North = North;
            this.East = East;
            this.South = South;
            this.West = West;
            this.RoomNumber = RoomNumber;
            this.Info = Info;
            ItemList = new List<Items>(5);
            this.roomName = name;




        }

        public void setNorth(int input)
        {
            this.North = input;
        }
        public int getNorth()
        {
            return this.North;
        }
        public void setEast(int input)
        {
            this.East = input;
        }
        public int getEast()
        {
            return this.East;
        }
        public void setSouth(int input)
        {
            this.South = input;
        }
        public int getSouth()
        {
            return this.South;
        }
        public void setWest(int input)
        {
            this.West = input;
        }
        public int getWest()
        {
            return this.West;
        }
        public void setRoomNumber(int input)
        {
            this.RoomNumber = input;
        }
        public int getRoomNumber()
        {
            return this.RoomNumber;
        }
        public void setInfo(String input)
        {
            this.Info = input;
        }
        public String getInfo()
        {
            return this.Info;
        }
        public void addItem(Items input)
        {
            this.ItemList.Add(input);
        }
        public Items takeItem()
        {
            if(this.ItemList.Count > 0)
            {
                Items takenItem = this.ItemList[0];
                Console.WriteLine("You have taken" + this.ItemList[0].getName());
                this.ItemList.RemoveAt(0);
                return takenItem;


            }
            Console.WriteLine("No item to take");
            return null;
        }
        public String RoomItem()
        {
            String itemString = "";
            int t = 0;
            while(t < ItemList.Count){
                itemString = itemString + ItemList[t].getName();
                //itemString = itemString + ",";
                t++;
                if (t < ItemList.Count)
                {
                    itemString = itemString + ",";
                }

            }
            //Console.WriteLine("The items in the room are");
            itemString = "The items in the room are " + itemString;
            return itemString;
        }
        public int RoomInventorySize()
        {
            return this.ItemList.Count;
        }
        public void setRoomName(String input)
        {
            this.roomName = input;
        }
        public String getRoomName()
        {
            return this.roomName;
        }
        public Items ItemAtSpot(int input)
        {

            return this.ItemList[input];
        }

    }
}