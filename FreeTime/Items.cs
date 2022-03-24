using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FreeTime
{
    public class Items
    {
        private String name;
        private String info;
        private int number;

        public Items(String name, String info, int number)
        {
            this.name = name;
            this.info = info;
            this.number = number;


        }
        public String getName()
        {
            return this.name.ToString();
        }
        public String getInfo()
        {
            return this.info.ToString();

        }
        public int getNumber()
        {
            return this.number;
        }
    }
}