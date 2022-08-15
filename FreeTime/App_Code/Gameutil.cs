using FreeTime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Configuration;
using System.Data.SqlClient;

using System.Web.UI;
using System.Web.UI.WebControls;

namespace FreeTimeWebsite.App_Code
{
    public class Gameutil
    {
        public Gameutil()
        {

        }
        public void saveGame()
        {


        }
        public void loadGame()
        {
            Player mainPlayer = new Player("Player1", 23);
            Room currentRoom = new Room(2, 1, 1, 1, 1, "room 1", "room 1");
            List<Room> roomList = (List<Room>)System.Web.HttpContext.Current.Session["roomList"];
            roomList = new List<Room>();
            Room room1 = new Room(2, 1, 1, 1, 1, "This is the Starting room", "room 1");
            Room room2 = new Room(4, 5, 1, 3, 2, "This is the Mid room", "room 2");
            Room room3 = new Room(3, 3, 2, 3, 3, "This is the Ending room", "room 3");
            Room room4 = new Room(4, 4, 2, 4, 4, "This is the Extra room", "room 4");
            Room room5 = new Room(5, 5, 2, 6, 5, "This is Room 5", "room 5");
            Room room6 = new Room(7, 5, 6, 3, 6, "This is Room 6", "room 6");
            Room room7 = new Room(7, 7, 7, 1, 7, "This is Room 7", "Room 7");
            roomList.Add(room1);
            roomList.Add(room2);
            roomList.Add(room3);
            roomList.Add(room4);
            roomList.Add(room5);
            roomList.Add(room6);
            roomList.Add(room7);
            System.Web.HttpContext.Current.Session["roomList"] = roomList;

            string UsernameValue = (string)System.Web.HttpContext.Current.Session["User"];
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["freeTimeConnection"].ConnectionString);

            conn.Open();
            string checkUser = "select * from Players where Username=@userName";
            SqlCommand comd = new SqlCommand(checkUser, conn);




            comd.Parameters.AddWithValue("@userName", UsernameValue);
            SqlDataReader dr = comd.ExecuteReader();
            if (dr.HasRows)
            {
                //
                dr.Read();
                int CurrentRoom = (int)dr["CurrentRoom"];
                currentRoom = roomList[CurrentRoom - 1];



                System.Web.HttpContext.Current.Session["currentRoom"] = currentRoom;
                mainPlayer = new Player("Player1", 23);
                System.Web.HttpContext.Current.Session["player"] = mainPlayer;

                /////Label1.Text = "The room number is " + currentRoom.getRoomName();

                int North = currentRoom.getNorth() - 1;
                int South = currentRoom.getSouth() - 1;
                int West = currentRoom.getWest() - 1;
                int East = currentRoom.getEast() - 1;

               ///////// Label2.Text = "The north exit leads to " + roomList[North].getRoomName() + " the east exit leads to " + roomList[East].getRoomName() + " the south exit leads to " + roomList[South].getRoomName() + " The west exit leads to " + roomList[West].getRoomName();


                dr.Close();
                conn.Close();

            }

            SqlConnection conn2 = new SqlConnection(ConfigurationManager.ConnectionStrings["freeTimeConnection"].ConnectionString);
            conn2.Open();
            string checkUser2 = "select * from PlayersInventory where [User]=@userName";
            SqlCommand comd2 = new SqlCommand(checkUser2, conn2);

            comd2.Parameters.AddWithValue("@userName", UsernameValue);
            SqlDataReader dr2 = comd2.ExecuteReader();
            if (dr2.HasRows)
            {
                //
                dr2.Read();

                ///might work on InventorySpace later to make sure items get back to original spot in inventory
                int inventorySpace = (int)dr2["InventorySpace"];
                Items item1 = new Items((string)dr2["ItemName"], (string)dr2["ItemInfo"], (int)dr2["ItemNumber"]);
                mainPlayer.addInventory(item1);
                System.Web.HttpContext.Current.Session["player"] = mainPlayer;



                dr2.Close();
                conn2.Close();



            }


            ///////////////////////
            SqlConnection conn3 = new SqlConnection(ConfigurationManager.ConnectionStrings["freeTimeConnection"].ConnectionString);
            conn3.Open();
            string checkUser3 = "select * from RoomsInventory where [Username]=@userName";
            SqlCommand comd3 = new SqlCommand(checkUser3, conn3);

            comd3.Parameters.AddWithValue("@userName", UsernameValue);
            SqlDataReader dr3 = comd3.ExecuteReader();
            if (dr3.HasRows)
            {

                while (dr3.Read())
                {


                    Items item1 = new Items((string)dr3["ItemName"], (string)dr3["ItemInfo"], (int)dr3["ItemNumber"]);
                    int RoomNumber = (int)dr3["RoomNumber"];
                    RoomNumber = RoomNumber - 1;
                    roomList[RoomNumber].addItem(item1);


                }


                dr3.Close();
                conn3.Close();

                System.Web.HttpContext.Current.Session["roomList"] = roomList;

            }
        }
        public string getCurrentRoom()
        {

            Room currentRoom = (Room)System.Web.HttpContext.Current.Session["currentRoom"];
            return currentRoom.getRoomName();
        }
        public string getNextRoom()
        {
            List<Room> nextRoom = (List<Room>)System.Web.HttpContext.Current.Session["roomList"];
            Room currentRoom = (Room)System.Web.HttpContext.Current.Session["currentRoom"];
            int North = currentRoom.getNorth() - 1;
            return nextRoom[North].getRoomName();
        }
        public List<Room> getRoomList()
        {
            List<Room> RoomList = (List<Room>)System.Web.HttpContext.Current.Session["roomList"];

            return RoomList;
        }
        





    }
}