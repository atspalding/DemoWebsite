using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;

namespace FreeTime
{
    public class Player
    {
        private String name;
        private int age;
        //private ArrayList<Items> Inventory;
        private List<Items> Inventory;
        private int HP;



        public Player (String name, int age)
        {
            this.name = name;
            this.age = age;
            Inventory = new List<Items>(5);

        }
        public void setName(String input)
        {
            this.name = input;
        }
        public String getName()
        {
            return this.name;
        }
        public void setAge(int input)
        {
            this.age = input;
        }
        public int getAge()
        {
            return this.age;
        }
        public int getHP()
        {
            return this.HP;
        }
        public void setHP(int input)
        {
            this.HP = input;
        }
        public void addInventory(Items input)
        {
            Inventory.Add(input);
        }
        public String lookInventory()
        {
            String itemString = "";
            int t = 0;
            while(t < Inventory.Count)
            {
                itemString = itemString + Inventory.ElementAt(t).getName();
                //itemString = itemString + ",";
                t++;
                if (t < Inventory.Count)
                {
                    itemString = itemString + ",";
                }

            }

           // Console.WriteLine("The player inventory is ");
            return "The player inventory is "+itemString;
        }
        public Items dropItems()
        {
            if(this.Inventory.Count > 0)
            {
                Items tempItems = this.Inventory[0];
                Console.WriteLine("You have droped" + tempItems.getName());
                this.Inventory.RemoveAt(0);
                return tempItems;
            }
            else
            {

                return null;
            }
        }
    }
}