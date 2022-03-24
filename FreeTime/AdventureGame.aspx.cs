using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
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
                Session["User"] = "user2";

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

            else if (textboxString.ToLower() == "save")
            {

                string UsernameValue= (string)Session["User"];
                /////////////
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["freeTimeConnection"].ConnectionString);
                ///
                //SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["freeTimeConnection2"].ConnectionString);
                conn.Open();
                string checkUser = "select * from Players where Username=@userName";
                SqlCommand comd = new SqlCommand(checkUser, conn);
                comd.Parameters.AddWithValue("@userName", UsernameValue);
                SqlDataReader dr = comd.ExecuteReader();
                if (dr.HasRows)
                {

                    SqlConnection conn2 = new SqlConnection(ConfigurationManager.ConnectionStrings["freeTimeConnection"].ConnectionString);
                    //SqlConnection conn2 = new SqlConnection(ConfigurationManager.ConnectionStrings["freeTimeDatabase2"].ConnectionString);
                    //SqlConnection conn2 = new SqlConnection(ConfigurationManager.ConnectionStrings["freeTimeConnection2"].ConnectionString);


                    conn2.Open();

                    string insertString = "update Players set Username=@Username, Playername=@PlayerName, Age=@Age, CurrentRoom=@CurrentRoom,HP=@HP  where Username=@userName ";
                    SqlCommand comd2 = new SqlCommand(insertString, conn2);
                    comd2.Parameters.AddWithValue("@Username", UsernameValue);
                    comd2.Parameters.AddWithValue("@PlayerName", mainPlayer.getName());
                    //comd.Parameters.AddWithValue("@Email", email);
                    //comd.Parameters.AddWithValue("@Country", country);
                    //comd.Parameters.AddWithValue("@Password", EncryptPassword.encryptString(password));
                    //////////////////comd2.Parameters.AddWithValue("@Password", passwordValue);
                    //comd2.Parameters.AddWithValue("@Password", strBuilder.ToString());
                    //comd.Parameters.AddWithValue("@Age", Convert.ToInt32(age));
                    comd2.Parameters.AddWithValue("@Age", mainPlayer.getAge());
                    comd2.Parameters.AddWithValue("@CurrentRoom", currentRoom.getRoomNumber());
                    comd2.Parameters.AddWithValue("@HP", mainPlayer.getHP());
                    comd2.ExecuteNonQuery();



                    dr.Close();
                    conn.Close();
                    // return true;
                    ////////////////////////////////////
                  




                    ///////////////////////////////////


                }
                else
                {

                    dr.Close();
                    conn.Close();

                    SqlConnection conn2 = new SqlConnection(ConfigurationManager.ConnectionStrings["freeTimeConnection"].ConnectionString);
                    //SqlConnection conn2 = new SqlConnection(ConfigurationManager.ConnectionStrings["freeTimeDatabase2"].ConnectionString);
                    //SqlConnection conn2 = new SqlConnection(ConfigurationManager.ConnectionStrings["freeTimeConnection2"].ConnectionString);


                    conn2.Open();

                    //////////////////////

          
                    //////////////////////////
                    //string insertString = "insert into Customer (UserName, Name, Password,Age) values (@userName,@Name,@Password,@Age,)";
                    string insertString = "insert into Players (Username, PlayerName, Age,CurrentRoom,HP) values (@UserName,@PlayerName,@Age,@CurrentRoom,@HP)";
                    SqlCommand comd2 = new SqlCommand(insertString, conn2);
                    comd2.Parameters.AddWithValue("@Username", UsernameValue);
                    comd2.Parameters.AddWithValue("@PlayerName", mainPlayer.getName());
                    //comd.Parameters.AddWithValue("@Email", email);
                    //comd.Parameters.AddWithValue("@Country", country);
                    //comd.Parameters.AddWithValue("@Password", EncryptPassword.encryptString(password));
                    //////////////////comd2.Parameters.AddWithValue("@Password", passwordValue);
                    //comd2.Parameters.AddWithValue("@Password", strBuilder.ToString());
                    //comd.Parameters.AddWithValue("@Age", Convert.ToInt32(age));
                    comd2.Parameters.AddWithValue("@Age", mainPlayer.getAge());
                    comd2.Parameters.AddWithValue("@CurrentRoom", currentRoom.getRoomNumber());
                    comd2.Parameters.AddWithValue("@HP", mainPlayer.getHP());
                    comd2.ExecuteNonQuery();
                    conn2.Close();
                    //////////////

                   
                    
                    //Response.AddHeader("refresh", "4; url=Login.aspx");
   
                }
                //dr.Close();
                //conn.Close();

                //return false;

                //////////////////
                ///
                SqlConnection conn4 = new SqlConnection(ConfigurationManager.ConnectionStrings["freeTimeConnection"].ConnectionString);
                ///
                //SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["freeTimeConnection2"].ConnectionString);
                conn4.Open();
                string checkUser4 = "select * from PlayersInventory where [User]=@userName";
                SqlCommand comd4 = new SqlCommand(checkUser4, conn4);
                comd4.Parameters.AddWithValue("@userName", UsernameValue);
                SqlDataReader dr4 = comd4.ExecuteReader();
                if (dr4.HasRows)
                {

                    SqlConnection conn5 = new SqlConnection(ConfigurationManager.ConnectionStrings["freeTimeConnection"].ConnectionString);
                    //SqlConnection conn2 = new SqlConnection(ConfigurationManager.ConnectionStrings["freeTimeDatabase2"].ConnectionString);
                    //SqlConnection conn2 = new SqlConnection(ConfigurationManager.ConnectionStrings["freeTimeConnection2"].ConnectionString);


                    conn5.Open();

                    string insertString5 = "delete from PlayersInventory where [User]=@User ";
                    SqlCommand comd5 = new SqlCommand(insertString5, conn5);
                    comd5.Parameters.AddWithValue("@User", UsernameValue);
                    comd5.ExecuteNonQuery();



                    dr4.Close();
                    conn4.Close();
                    // return true;

                }
                else
                {

                }


                /////////////////////
                int t = 0;
                SqlConnection conn3 = new SqlConnection(ConfigurationManager.ConnectionStrings["freeTimeConnection"].ConnectionString);
                conn3.Open();
                while (t < mainPlayer.InventorySize())
                {
                    //SqlConnection conn3 = new SqlConnection(ConfigurationManager.ConnectionStrings["freeTimeConnection"].ConnectionString);
                    string insertString3 = "insert into PlayersInventory (ItemName, ItemInfo, ItemNumber, InventorySpace, [User]) values (@ItemName,@ItemInfo,@ItemNumber,@InventorySpace,@User)";
                    SqlCommand comd3 = new SqlCommand(insertString3, conn3);
                    comd3.Parameters.AddWithValue("@ItemName", mainPlayer.InventoryItem(t).getName());
                    comd3.Parameters.AddWithValue("@ItemInfo", mainPlayer.InventoryItem(t).getInfo());
                    comd3.Parameters.AddWithValue("@ItemNumber", mainPlayer.InventoryItem(t).getNumber());

                    //comd3.Parameters.AddWithValue("@ItemName","hi");
                    //comd3.Parameters.AddWithValue("@ItemInfo","hi");
                    //comd3.Parameters.AddWithValue("@ItemNumber",1);


                    comd3.Parameters.AddWithValue("@InventorySpace", t);
                    comd3.Parameters.AddWithValue("@User", UsernameValue);

                    //comd3.Parameters.AddWithValue("@InventorySpace",0);
                    //comd3.Parameters.AddWithValue("@User","user1");

                    //////////////////comd2.Parameters.AddWithValue("@Password", passwordValue);
                    //comd2.Parameters.AddWithValue("@Password", strBuilder.ToString());
                    //comd.Parameters.AddWithValue("@Age", Convert.ToInt32(age));
                    comd3.ExecuteNonQuery();
                    t++;
                    //conn3.Close();
                }








                conn3.Close();





                ///////////////////////
                SqlConnection conn8 = new SqlConnection(ConfigurationManager.ConnectionStrings["freeTimeConnection"].ConnectionString);
                ///
                //SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["freeTimeConnection2"].ConnectionString);
                conn8.Open();
                string checkUser8 = "select * from RoomsInventory where [Username]=@userName";
                SqlCommand comd8 = new SqlCommand(checkUser8, conn8);
                comd8.Parameters.AddWithValue("@userName", UsernameValue);
                SqlDataReader dr8 = comd8.ExecuteReader();
                if (dr8.HasRows)
                {

                    SqlConnection conn9 = new SqlConnection(ConfigurationManager.ConnectionStrings["freeTimeConnection"].ConnectionString);
                    //SqlConnection conn2 = new SqlConnection(ConfigurationManager.ConnectionStrings["freeTimeDatabase2"].ConnectionString);
                    //SqlConnection conn2 = new SqlConnection(ConfigurationManager.ConnectionStrings["freeTimeConnection2"].ConnectionString);


                    conn9.Open();

                    string insertString9 = "delete from RoomsInventory where [Username]=@User ";
                    SqlCommand comd9 = new SqlCommand(insertString9, conn9);
                    comd9.Parameters.AddWithValue("@User", UsernameValue);
                    comd9.ExecuteNonQuery();



                    dr8.Close();
                    conn9.Close();
                    // return true;

                }
                else
                {

                }



                int z = 0;
                SqlConnection conn10 = new SqlConnection(ConfigurationManager.ConnectionStrings["freeTimeConnection"].ConnectionString);
                conn10.Open();
                while (z < roomList.Count)
                {
                    int s = 0;
                    while(s < roomList[z].RoomInventorySize())
                    {

                        string insertString10 = "insert into RoomsInventory (ItemName, ItemInfo, ItemNumber, InventorySpace, [Username],RoomNumber) values (@ItemName,@ItemInfo,@ItemNumber,@InventorySpace,@User,@RoomNumber)";
                        SqlCommand comd10 = new SqlCommand(insertString10, conn10);
                        comd10.Parameters.AddWithValue("@ItemName", roomList[z].ItemAtSpot(s).getName());
                        comd10.Parameters.AddWithValue("@ItemInfo", roomList[z].ItemAtSpot(s).getInfo());
                        comd10.Parameters.AddWithValue("@ItemNumber", roomList[z].ItemAtSpot(s).getNumber());

                        //comd3.Parameters.AddWithValue("@ItemName","hi");
                        //comd3.Parameters.AddWithValue("@ItemInfo","hi");
                        //comd3.Parameters.AddWithValue("@ItemNumber",1);


                        comd10.Parameters.AddWithValue("@InventorySpace", s);
                        comd10.Parameters.AddWithValue("@User", UsernameValue);
                        comd10.Parameters.AddWithValue("@RoomNumber", roomList[z].getRoomNumber());

                        //comd3.Parameters.AddWithValue("@InventorySpace",0);
                        //comd3.Parameters.AddWithValue("@User","user1");

                        //////////////////comd2.Parameters.AddWithValue("@Password", passwordValue);
                        //comd2.Parameters.AddWithValue("@Password", strBuilder.ToString());
                        //comd.Parameters.AddWithValue("@Age", Convert.ToInt32(age));
                        comd10.ExecuteNonQuery();


                        s++;
                    }
                    //SqlConnection conn3 = new SqlConnection(ConfigurationManager.ConnectionStrings["freeTimeConnection"].ConnectionString);
                   
                    z++;
                    //conn3.Close();
                }








                conn10.Close();








                //////////////////////
            }
            else if (textboxString == "load")
            {

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
                Session["roomList"] = roomList;





                string UsernameValue = (string)Session["User"];
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["freeTimeConnection"].ConnectionString);
                //SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["freeTimeDatabase2"].ConnectionString);
                //SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["freeTimeConnection2"].ConnectionString);
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
                    currentRoom = roomList[CurrentRoom-1];



                    Session["currentRoom"] = currentRoom;
                    mainPlayer = new Player("Player1", 23);
                    Session["player"] = mainPlayer;

                    Label1.Text = "The room number is " + currentRoom.getRoomName();

                    int North = currentRoom.getNorth() - 1;
                    int South = currentRoom.getSouth() - 1;
                    int West = currentRoom.getWest() - 1;
                    int East = currentRoom.getEast() - 1;

                    Label2.Text = "The north exit leads to " + roomList[North].getRoomName() + " the east exit leads to " + roomList[East].getRoomName() + " the south exit leads to " + roomList[South].getRoomName() + " The west exit leads to " + roomList[West].getRoomName();


                    dr.Close();
                  conn.Close();
                        
                    
                    
                }

                ///////////////////
                ///
                SqlConnection conn2 = new SqlConnection(ConfigurationManager.ConnectionStrings["freeTimeConnection"].ConnectionString);
                //SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["freeTimeDatabase2"].ConnectionString);
                //SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["freeTimeConnection2"].ConnectionString);
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
                    Session["player"] = mainPlayer;



                    dr2.Close();
                    conn2.Close();



                }






                /////////////////////
                ///
                //roomList = new List<Room>();
                //Room room1 = new Room(2, 1, 1, 1, 1, "This is the Starting room", "room 1");
                //Room room2 = new Room(4, 5, 1, 3, 2, "This is the Mid room", "room 2");
                //Room room3 = new Room(3, 3, 2, 3, 3, "This is the Ending room", "room 3");
                //Room room4 = new Room(4, 4, 2, 4, 4, "This is the Extra room", "room 4");
                //Room room5 = new Room(5, 5, 2, 6, 5, "This is Room 5", "room 5");
                //Room room6 = new Room(7, 5, 6, 3, 6, "This is Room 6", "room 6");
                //Room room7 = new Room(7, 7, 7, 1, 7, "This is Room 7", "Room 7");
                //roomList.Add(room1);
                //roomList.Add(room2);
                //roomList.Add(room3);
                //roomList.Add(room4);
                //roomList.Add(room5);
                //roomList.Add(room6);
                //roomList.Add(room7);
                //Session["roomList"] = roomList;




                ///////////////////////
                SqlConnection conn3 = new SqlConnection(ConfigurationManager.ConnectionStrings["freeTimeConnection"].ConnectionString);
                //SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["freeTimeDatabase2"].ConnectionString);
                //SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["freeTimeConnection2"].ConnectionString);
                conn3.Open();
                string checkUser3 = "select * from RoomsInventory where [Username]=@userName";
                SqlCommand comd3 = new SqlCommand(checkUser3, conn3);




                comd3.Parameters.AddWithValue("@userName", UsernameValue);
                SqlDataReader dr3 = comd3.ExecuteReader();
                if (dr3.HasRows)
                {
                    //
                    ////dr3.Read();
                    while (dr3.Read())
                    {

                        ///might work on InventorySpace later to make sure items get back to original spot in inventory
                        //int inventorySpace = (int)dr3["InventorySpace"];
                        Items item1 = new Items((string)dr3["ItemName"], (string)dr3["ItemInfo"], (int)dr3["ItemNumber"]);
                        int RoomNumber = (int)dr3["RoomNumber"];
                        RoomNumber = RoomNumber - 1;
                        roomList[RoomNumber].addItem(item1);


                    }

                    ///might work on InventorySpace later to make sure items get back to original spot in inventory
                    //int inventorySpace = (int)dr3["InventorySpace"];
                    //Items item1 = new Items((string)dr3["ItemName"], (string)dr3["ItemInfo"], (int)dr3["ItemNumber"]);
                    //int RoomNumber = (int)dr3["RoomNumber"];
                    //RoomNumber = RoomNumber - 1;
                    //roomList[RoomNumber].addItem(item1);



                    dr3.Close();
                    conn3.Close();

                    Session["roomList"] = roomList;

                }




                ////////////////////////




            }
            else
            {
                Label3.Text = "Wrong input";
                Session["ClearTurn"] = true;

            }

        }
    }
}
