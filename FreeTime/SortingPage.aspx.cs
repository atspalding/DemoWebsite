using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;

namespace FreeTime
{
    public partial class SortingPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void SortButton_Click(object sender, EventArgs e)
        {
            //int[] sortingArray;

            int[] sortingArray = new int[5] { 99, 98, 92, 97, 95 };
            int i = 0;
            int arrayEnd = sortingArray.Length-1;
            int swapValue = 0;
            Boolean swapped = true;
            int firstValue = Convert.ToInt32(TextBox1.Text.ToString());
            int secondValue = Convert.ToInt32(TextBox2.Text.ToString());
            int thirdValue = Convert.ToInt32(TextBox3.Text.ToString());
            int fourthValue = Convert.ToInt32(TextBox4.Text.ToString());
            int fifthValue = Convert.ToInt32(TextBox5.Text.ToString());
            int t = 0;
            string arrayString = "";

            sortingArray.SetValue(firstValue, 0);
            sortingArray.SetValue(secondValue, 1);
            sortingArray.SetValue(thirdValue, 2);
            sortingArray.SetValue(fourthValue, 3);
            sortingArray.SetValue(fifthValue, 4);

            var sortingValue = Convert.ToInt32(SortingDropDownList.SelectedValue);
            var sortingDirection = Convert.ToInt32(sortingDirectionList.SelectedValue);

            while (i < sortingArray.Length)
            {
                //Debug.WriteLine(sortingArray.GetValue(i).ToString());
                i++;
            }


            if (sortingValue.Equals(1)) {
                //Debug.WriteLine("Bubble sort");
                sortingPanel.Controls.Add(new LiteralControl("Bubble Sort"));
                sortingPanel.Controls.Add(new LiteralControl("<p></p>"));


                if (sortingDirection.Equals(1))
                {
                    sortingPanel.Controls.Add(new LiteralControl("low to high"));
                    sortingPanel.Controls.Add(new LiteralControl("<p></p>"));
                    while (swapped != false)
                    {
                        swapped = false;
                        i = 0;
                        while (i < arrayEnd)
                        {
                            if (Convert.ToInt32(sortingArray.GetValue(i)) > Convert.ToInt32(sortingArray.GetValue(i + 1)))
                            {
                                swapValue = Convert.ToInt32(sortingArray.GetValue(i));
                                sortingArray.SetValue(sortingArray.GetValue(i + 1), i);
                                sortingArray.SetValue(swapValue, i + 1);
                                swapped = true;


                            }
                            i++;
                        }

                        //////////

                        Debug.WriteLine("sorted this step");
                        t = 0;
                        while (t < arrayEnd + 1)
                        {
                            arrayString = arrayString + sortingArray.GetValue(t).ToString()+ "&nbsp"+ "&nbsp";

                            sortingPanel.Controls.Add(new LiteralControl("<p></p>"));

                            //Debug.WriteLine(sortingArray.GetValue(t).ToString());
                            t++;
                        }
                        sortingPanel.Controls.Add(new LiteralControl(arrayString));
                        //Debug.WriteLine("arrayString");
                        //Debug.WriteLine(arrayString);
                        arrayString = "";
                        //////////


                    }
                    sortingPanel.Controls.Add(new LiteralControl("<p></p>"));
                    sortingPanel.Controls.Add(new LiteralControl("Done sorting"));





                }
                else if (sortingDirection.Equals(2))
                {
                    sortingPanel.Controls.Add(new LiteralControl("high to low"));
                    sortingPanel.Controls.Add(new LiteralControl("<p></p>"));

                    while (swapped != false)
                    {
                        swapped = false;
                        i = 0;
                        while (i < arrayEnd)
                        {
                            if (Convert.ToInt32(sortingArray.GetValue(i)) < Convert.ToInt32(sortingArray.GetValue(i + 1)))
                            {
                                swapValue = Convert.ToInt32(sortingArray.GetValue(i));
                                sortingArray.SetValue(sortingArray.GetValue(i + 1), i);
                                sortingArray.SetValue(swapValue, i + 1);
                                swapped = true;


                            }
                            i++;


                        }
                        /////////////
                        //Debug.WriteLine("sorted this step");
                        t = 0;
                        while (t < arrayEnd+1)
                        {
                            arrayString = arrayString + sortingArray.GetValue(t).ToString() + "&nbsp" + "&nbsp";

                            sortingPanel.Controls.Add(new LiteralControl("<p></p>"));
                            //Debug.WriteLine(sortingArray.GetValue(t).ToString());
                            t++;
                        }
                        sortingPanel.Controls.Add(new LiteralControl(arrayString));
                        arrayString = "";
                        //////////////



                    }
                    sortingPanel.Controls.Add(new LiteralControl("<p></p>"));
                    sortingPanel.Controls.Add(new LiteralControl("Done sorting"));

                }
                else
                {



                }


            }
            else if (sortingValue.Equals(2))
            {
                //http://cforbeginners.com/CSharp/SelectionSort.html
                if (sortingDirection.Equals(1)){
                    int temp = 0;
                    //int n = 0;
                    for (int n=0; n < arrayEnd; n++)
                    {
                        int min = n;
                        for (int r = n + 1; r < arrayEnd + 1; r++){

                            if (Convert.ToInt32(sortingArray.GetValue(r)) < Convert.ToInt32(sortingArray.GetValue(min)))
                            {
                                min = r;

                            }
                        }

                        if(min != n)
                        {
                            temp = Convert.ToInt32(sortingArray.GetValue(n));
                            sortingArray.SetValue(Convert.ToInt32(sortingArray.GetValue(min)), n);
                            sortingArray.SetValue(temp, min);


                            ///////////////////
                            t = 0;
                            while (t < arrayEnd + 1)
                            {
                                arrayString = arrayString + sortingArray.GetValue(t).ToString() + "&nbsp" + "&nbsp";

                                sortingPanel.Controls.Add(new LiteralControl("<p></p>"));
                                t++;
                            }
                            sortingPanel.Controls.Add(new LiteralControl(arrayString));
                            arrayString = "";

                        }
                    }
                    sortingPanel.Controls.Add(new LiteralControl("<p></p>"));
                    sortingPanel.Controls.Add(new LiteralControl("Done sorting"));

                }
                else if (sortingDirection.Equals(2))
                {
                    int temp = 0;
                    //int n = 0;
                    for (int n = 0; n < arrayEnd; n++)
                    {
                        int min = n;
                        for (int r = n + 1; r < arrayEnd + 1; r++)
                        {

                            if (Convert.ToInt32(sortingArray.GetValue(r)) > Convert.ToInt32(sortingArray.GetValue(min)))
                            {
                                min = r;

                            }
                        }

                        if (min != n)
                        {
                            temp = Convert.ToInt32(sortingArray.GetValue(n));
                            sortingArray.SetValue(Convert.ToInt32(sortingArray.GetValue(min)), n);
                            sortingArray.SetValue(temp, min);
                        
                            t = 0;
                            while (t < arrayEnd + 1)
                            {
                                arrayString = arrayString + sortingArray.GetValue(t).ToString() + "&nbsp" + "&nbsp";

                                sortingPanel.Controls.Add(new LiteralControl("<p></p>"));
                                t++;
                            }
                            sortingPanel.Controls.Add(new LiteralControl(arrayString));
                            arrayString = "";
                            

                        }
                    }
                    
                    sortingPanel.Controls.Add(new LiteralControl("<p></p>"));
                    sortingPanel.Controls.Add(new LiteralControl("Done sorting"));
                }
                else
                {

                }



            }
            else if (sortingValue.Equals(3))
            {
                if (sortingDirection.Equals(1))
                {

                }
                else if (sortingDirection.Equals(2))
                {


                }
                else { }

            }
            else{

            }

            //Debug.WriteLine("sorted");
            i = 0;
            while (i < sortingArray.Length)
            {
                //Debug.WriteLine(sortingArray.GetValue(i).ToString());
                i++;
            }
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            //Response.AddHeader("refresh", "0; url=NewsSite.aspx");
            Server.Transfer("NewsSite.aspx", true);
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            //Response.AddHeader("refresh", "0; url=NewsSite.aspx");
            Server.Transfer("Login.aspx", true);
        }

    }
}