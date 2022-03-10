using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FreeTime
{
    public partial class AdventureGame : System.Web.UI.Page
    {

       

    
        

        protected void Page_Load(object sender, EventArgs e)
        {


            if (!IsPostBack)

            {


                List<Room> roomList = new List<Room>();
                Player mainPlayer = new Player("Player1", 23);
                Room room1 = new Room(2, 1, 1, 1, 1, "This is the Starting room", "room 1");
                Room room2 = new Room(4, 5, 1, 3, 2, "This is the Mid room", "room 2");
                Room room3 = new Room(3, 3, 2, 3, 3, "This is the Ending room", "room 3");
                Room room4 = new Room(4, 4, 2, 4, 4, "This is the Extra room", "room 4");
                Room room5 = new Room(5, 5, 2, 6, 5, "This is Room 5", "room 5");
                Room room6 = new Room(7, 5, 6, 3, 6, "This is Room 6", "room 6");
                Room room7 = new Room(7, 7, 7, 1, 7, "This is Room 7", "Room 7");
                //Room currentRoom = new Room(7, 7, 7, 1, 7, "room 7", "room7");
                Room currentRoom = new Room(2, 1, 1, 1, 1, "room 1", "room 1");
                Movement move = new Movement(new Room(2, 1, 1, 1, 1, "Starting room", "room 1"));
                Items item1 = new Items("item1", "This is item 1", 1);
                Items item2 = new Items("item2", "This is item 2", 1);
                int ClearCount = 0;
                Boolean ClearTurn = false;


                //List<Room> roomList = new List<Room>();
                //Player mainPlayer = new Player("Player1", 23);
                room1.addItem(item1);
                room2.addItem(item2);
                roomList.Add(room1);
                roomList.Add(room2);
                roomList.Add(room3);
                roomList.Add(room4);
                roomList.Add(room5);
                roomList.Add(room6);
                roomList.Add(room7);
                currentRoom = roomList[0];
                // move = new Movement(currentRoom);
                Session["roomList"] = roomList;
                Session["currentRoom"] = currentRoom;
                Session["player"] = mainPlayer;
                Session["move"] = move;
                Session["ClearCount"] = ClearCount;
                Session["ClearTurn"] = ClearTurn;

                Label3.Text = "To win you need to find 2 items and drop them in room 1";

            }
            //might not need this won code
            List<Room> roomList3 = (List<Room>)Session["roomList"];
            if (roomList3[0].RoomInventorySize() == 2)
            {
                Label3.Text = "You have won the game";
                Button1.Visible = false;
            }

            Boolean ClearTurn2 = (Boolean)Session["ClearTurn"];
            if (ClearTurn2 == true)
            {
                int ClearCount = (int)Session["ClearCount"];
                //Added this to clear next turn not 2 turns from now
                ClearCount++;
                if (ClearCount == 0)
                {
                    ClearCount++;
                    //Label3.Text = ClearCount.ToString();
                    Session["ClearCount"] = ClearCount;
                }
                else
                {
                    ClearCount = 0;
                    Session["ClearCount"] = ClearCount;
                    ClearTurn2 = false;
                    Session["ClearTurn"] = ClearTurn2;
                    Label3.Text ="";

                }
            }



            Room currentRoom2 = (Room)Session["currentRoom"];
            Label1.Text ="The room number is "+currentRoom2.getRoomName();

            //Room currentRoom = (Room)Session["currentRoom"];
            List<Room> roomList2 = (List<Room>)Session["roomList"];
            Player mainPlayer2 = (Player)Session["player"];
            Movement move2 = (Movement)Session["move"];
            int North = currentRoom2.getNorth() - 1;
            int South = currentRoom2.getSouth() - 1;
            int West = currentRoom2.getWest() - 1;
            int East = currentRoom2.getEast() - 1;

            Label2.Text = "The north exit leads to " + roomList2[North].getRoomName() + " the east exit leads to "+roomList2[East].getRoomName()+" the south exit leads to "+roomList2[South].getRoomName()+" The west exit leads to "+roomList2[West].getRoomName();


        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            Room currentRoom = (Room)Session["currentRoom"];
            List<Room> roomList = (List<Room>)Session["roomList"];
            Player mainPlayer = (Player)Session["player"];
            Movement move = (Movement)Session["move"];

            var textboxString=TextBox1.Text.ToString();
            if (textboxString.ToLower()== "n")
            {
                //Label1.Text = "MovementWorks";
               // Room currentRoom =(Room)Session["currentRoom"];
               // List <Room> roomList= (List<Room>)Session["roomList"];
                //Player mainPlayer = (Player)Session["player"];
                //Movement move = (Movement)Session["move"];
                currentRoom = roomList[move.moveRoom(currentRoom,"n") - 1];
                //Label1.Text = currentRoom.getRoomName();
                Label1.Text = "The room number is " + currentRoom.getRoomName();

                int North = currentRoom.getNorth() - 1;
                int South = currentRoom.getSouth() - 1;
                int West = currentRoom.getWest() - 1;
                int East = currentRoom.getEast() - 1;

                Label2.Text = "The north exit leads to " + roomList[North].getRoomName() + " the east exit leads to " + roomList[East].getRoomName() + " the south exit leads to " + roomList[South].getRoomName() + " The west exit leads to " + roomList[West].getRoomName();


                //Label1.Text = roomList.Count.ToString();
                Session["currentRoom"] = currentRoom;
                Session["player"] = mainPlayer;
                Session["move"] = move;
                Session["roomList"] = roomList;
            }
            else if (textboxString.ToLower() == "e")
            {

                //Label1.Text = "MovementWorks";
                //Room currentRoom = (Room)Session["currentRoom"];
                //List<Room> roomList = (List<Room>)Session["roomList"];
                //Player mainPlayer = (Player)Session["player"];
                //Movement move = (Movement)Session["move"];
                currentRoom = roomList[move.moveRoom(currentRoom, "e") - 1];
                //Label1.Text = currentRoom.getRoomName();
                Label1.Text = "The room number is " + currentRoom.getRoomName();

                int North = currentRoom.getNorth() - 1;
                int South = currentRoom.getSouth() - 1;
                int West = currentRoom.getWest() - 1;
                int East = currentRoom.getEast() - 1;

                Label2.Text = "The north exit leads to " + roomList[North].getRoomName() + " the east exit leads to " + roomList[East].getRoomName() + " the south exit leads to " + roomList[South].getRoomName() + " The west exit leads to " + roomList[West].getRoomName();


                //Label1.Text = roomList.Count.ToString();
                Session["currentRoom"] = currentRoom;
                Session["player"] = mainPlayer;
                Session["move"] = move;
                Session["roomList"] = roomList;
            }
            else if (textboxString.ToLower() == "s")
            {

                //Label1.Text = "MovementWorks";
                //Room currentRoom = (Room)Session["currentRoom"];
                //List<Room> roomList = (List<Room>)Session["roomList"];
                //Player mainPlayer = (Player)Session["player"];
                //Movement move = (Movement)Session["move"];
                currentRoom = roomList[move.moveRoom(currentRoom, "s") - 1];
                //Label1.Text = currentRoom.getRoomName();
                Label1.Text = "The room number is " + currentRoom.getRoomName();

                int North = currentRoom.getNorth() - 1;
                int South = currentRoom.getSouth() - 1;
                int West = currentRoom.getWest() - 1;
                int East = currentRoom.getEast() - 1;

                Label2.Text = "The north exit leads to " + roomList[North].getRoomName() + " the east exit leads to " + roomList[East].getRoomName() + " the south exit leads to " + roomList[South].getRoomName() + " The west exit leads to " + roomList[West].getRoomName();


                //Label1.Text = roomList.Count.ToString();
                Session["currentRoom"] = currentRoom;
                Session["player"] = mainPlayer;
                Session["move"] = move;
                Session["roomList"] = roomList;

            }
            else if (textboxString.ToLower() == "w")
            {

                //Label1.Text = "MovementWorks";
                //Room currentRoom = (Room)Session["currentRoom"];
                //List<Room> roomList = (List<Room>)Session["roomList"];
                //Player mainPlayer = (Player)Session["player"];
                //Movement move = (Movement)Session["move"];
                currentRoom = roomList[move.moveRoom(currentRoom, "w") - 1];
                //Label1.Text = currentRoom.getRoomName();
                Label1.Text = "The room number is " + currentRoom.getRoomName();


                int North = currentRoom.getNorth() - 1;
                int South = currentRoom.getSouth() - 1;
                int West = currentRoom.getWest() - 1;
                int East = currentRoom.getEast() - 1;

                Label2.Text = "The north exit leads to " + roomList[North].getRoomName() + " the east exit leads to " + roomList[East].getRoomName() + " the south exit leads to " + roomList[South].getRoomName() + " The west exit leads to " + roomList[West].getRoomName();


                //Label1.Text = roomList.Count.ToString();
                Session["currentRoom"] = currentRoom;
                Session["player"] = mainPlayer;
                Session["move"] = move;
                Session["roomList"] = roomList;

            }
            else if (textboxString.ToLower() == "info")
            {

                //Room currentRoom = (Room)Session["currentRoom"];
                //List<Room> roomList = (List<Room>)Session["roomList"];
                //Player mainPlayer = (Player)Session["player"];
                //Movement move = (Movement)Session["move"];
                //currentRoom = roomList[move.moveRoom(currentRoom, "n") - 1];

                Label3.Text = currentRoom.getInfo();
            }
            else if (textboxString.ToLower() == "ri")
            {

                //Room currentRoom = (Room)Session["currentRoom"];
                //List<Room> roomList = (List<Room>)Session["roomList"];
                //Player mainPlayer = (Player)Session["player"];
                //Movement move = (Movement)Session["move"];
                //currentRoom = roomList[move.moveRoom(currentRoom, "n") - 1];

                Label3.Text = currentRoom.RoomItem();
                Session["ClearTurn"] = true;
            }
            else if (textboxString.ToLower() == "pi")
            {

                Label3.Text = mainPlayer.lookInventory();
                Session["ClearTurn"] = true;
            }
            else if (textboxString.ToLower() == "ti")
            {
                mainPlayer.addInventory(currentRoom.takeItem());
                Label3.Text = "Picked up the item";
                Session["ClearTurn"] = true;
            }
            else if (textboxString.ToLower() == "pd")
            {
                currentRoom.addItem(mainPlayer.dropItems());
                Label3.Text = "You droped the items";
                if (roomList[0].RoomInventorySize() == 2)
                {
                    Label3.Text = "You have won the game";
                    Button1.Visible = false;
                }
            }
            else
            {
                Label3.Text = "Wrong input";
                Session["ClearTurn"] = true;

            }

        }
    }
}
