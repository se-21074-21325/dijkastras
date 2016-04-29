using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Dijkstras_UI
{
    /// <summary>
    /// Interaction logic for one.xaml
    /// </summary>
    public partial class one : Page
    {
        public one()
        {
            InitializeComponent();

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();

        }

        // methods for finding paths

        public static double minimumlist(List<double> val) // minimum from list
        {
            double min = val[0];

            for (int a = 0; a < val.Count; a++)
            {
                if (val[a] < min)
                {
                    min = val[a];
                }
            }
            return min;
        }


        public static double minimum(double[] arr) // method for finding shorter path from start point to A
        {
            double min = arr[0];

            for (int a = 0; a < arr.Length; a++)
            {
                if (arr[a] < min)
                {
                    min = arr[a];
                }
            }
            return min;
        }

        public static double[] longerpath(double[] arr)  // method for finding all longer paths from start point to A
        {
            double min = arr[0];
            double[] longe = new double[arr.Length];

            for (int a = 0; a < arr.Length; a++)
            {
                if (arr[a] > min)
                {
                    longe[a] = arr[a];
                }

            }
            return longe;
        }

        public static double[] sumpath(double[] patharray, double connected) // method for calculating paths from one point to other
        {
            for (int i = 0; i < patharray.Length; i++)
            {
                patharray[i] = patharray[i] + connected;
            }
            return patharray;
        }


        void timer_Tick(object sender, EventArgs e)
        {
            timelabel.Content = DateTime.Now.ToLongTimeString();
        }

        private void find_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                // ---------------------------------------- path A ----------- start point where you are standing now ----------------------------


               double[] shortestA = new double[10];  // shortest path container at every instance of point

                double destA = Convert.ToDouble(start.Text);  // starting point

                double[] array = { Convert.ToDouble(a1.Text), Convert.ToDouble(a2.Text), Convert.ToDouble(a3.Text), Convert.ToDouble(a4.Text) };

                double[] pathA = sumpath(array, destA); // acknowledging paths of A
                List<double> list = new List<double>(pathA);

                double mini = minimum(pathA); // finding minimum path from A
                shortestA[0] = mini; // added minimum path to short path array
                list.Remove(shortestA[0]);

                // ---------------------------------------- path B ---------------------------------------

                double destB = shortestA[0];  // starting point

                double[] arrayB = { Convert.ToDouble(b1.Text), Convert.ToDouble(b2.Text), Convert.ToDouble(b3.Text), Convert.ToDouble(b4.Text) };

                double[] pathB = sumpath(arrayB, destB); // acknowledging paths of A
                List<double> listB = new List<double>(pathB);


                double miniB = minimum(pathB); // finding minimum path from B

                double miniA_b = minimumlist(list);

                if (miniB < miniA_b)
                {
                    shortestA[1] = miniB; // added minimum path to short path array
                    listB.Remove(shortestA[1]);
                }
                else
                {
                    shortestA[1] = miniA_b; // added minimum path to short path array
                    list.Remove(shortestA[1]);
                }

                // ---------------------------------------- path C ---------------------------------------

                double destC = shortestA[1];  // starting point

                double[] arrayC = { Convert.ToDouble(c1.Text), Convert.ToDouble(c2.Text), Convert.ToDouble(c3.Text), Convert.ToDouble(c4.Text) };

                double[] pathC = sumpath(arrayC, destC); // acknowledging paths of A
                List<double> listC = new List<double>(pathC);



                double miniC = minimum(pathC); // finding minimum path from A

                double miniA_c = minimumlist(list);
                double miniB_c = minimumlist(listB);

                if (miniC < miniA_c || miniC < miniB_c)
                {
                    shortestA[2] = miniC; // added minimum path to short path array
                    listC.Remove(shortestA[2]);
                }

                else if (miniA_c < miniC || miniA_c < miniB_c)
                {
                    shortestA[2] = miniA_c; // added minimum path to short path array
                    list.Remove(shortestA[2]);
                }
                else if (miniB_c < miniC || miniB_c < miniA_c)
                {
                    shortestA[2] = miniB_c; // added minimum path to short path array
                    listB.Remove(shortestA[2]);
                }

                // ---------------------------------------- path D---------------------------------------



                double destD = shortestA[2];  // starting point

                double[] arrayD = { Convert.ToDouble(d1.Text), Convert.ToDouble(d2.Text), Convert.ToDouble(d3.Text), Convert.ToDouble(d4.Text) };

                double[] pathD = sumpath(arrayD, destD); // acknowledging paths of A
                List<double> listD = new List<double>(pathD);


                double miniD = minimum(pathC); // finding minimum path from A
                double miniA_d = minimumlist(list);
                double miniB_d = minimumlist(listB);
                double miniC_d = minimumlist(listC);


                if (miniD < miniA_d || miniD < miniB_d || miniD < miniC_d)
                {
                    shortestA[3] = miniD; // added minimum path to short path array
                    listD.Remove(shortestA[3]);
                }
                else if (miniA_d < miniD || miniA_d < miniB_d || miniA_d < miniC_d)
                {
                    shortestA[3] = miniA_d; // added minimum path to short path array
                    list.Remove(shortestA[3]);
                }
                else if (miniB_d < miniD || miniB_d < miniA_d || miniB_d < miniC_d)
                {
                    shortestA[3] = miniB_d; // added minimum path to short path array
                    listB.Remove(shortestA[3]);
                }
                else if (miniC_d < miniD || miniC_d < miniA_d || miniC_d < miniB_d)
                {
                    shortestA[3] = miniC_d; // added minimum path to short path array
                    listC.Remove(shortestA[3]);
                }

                // ---------------------------------------- path Final---------------------------------------



                double destE = shortestA[3];  // starting point

                double E = Convert.ToDouble(end.Text);

                double currentshort = E + destE;



                double miniD_e = minimumlist(listD) + E; // finding minimum path from A
                double miniA_e = minimumlist(list) + E;
                double miniB_e = minimumlist(listB) + E;
                double miniC_e = minimumlist(listC) + E;

                if (currentshort < miniA_e || currentshort < miniB_e || currentshort < miniC_e || currentshort < miniD_e)
                {
                    shortestA[4] = currentshort; // added minimum path to short path array

                }
                else if (miniD_e < miniA_e || miniD_e < miniB_e || miniD_e < miniC_e || miniD_e < currentshort)
                {
                    shortestA[4] = miniD_e; // added minimum path to short path array
                    listD.Remove(shortestA[4]);
                }
                else if (miniA_e < miniD_e || miniA_e < miniB_d || miniA_e < miniC_e || miniA_e < currentshort)
                {
                    shortestA[4] = miniA_e; // added minimum path to short path array
                    list.Remove(shortestA[4]);
                }
                else if (miniB_e < miniD_e || miniB_e < miniA_e || miniB_e < miniC_e || miniB_e < currentshort)
                {
                    shortestA[4] = miniB_e; // added minimum path to short path array
                    listB.Remove(shortestA[4]);
                }
                else if (miniC_e < miniD_e || miniC_e < miniA_e || miniC_e < miniB_e || miniC_e < currentshort)
                {
                    shortestA[4] = miniC_e; // added minimum path to short path array
                    listC.Remove(shortestA[4]);
                }


                MessageBox.Show(""+shortestA[0] + "-" + shortestA[1] + "-" + shortestA[2] + "-" + shortestA[3] + "-" + shortestA[4]);
            }
            catch
            {
                MessageBox.Show("Don't leave any textbox empty ! insert path distance in a numeric way !");
            }

        }

        private void newb_Click(object sender, RoutedEventArgs e)
        {
            start.Text = "";
            a1.Text = ""; a2.Text = ""; a3.Text = ""; a4.Text = "";
            b1.Text = ""; b2.Text = ""; b3.Text = ""; b4.Text = "";
            c1.Text = ""; c2.Text = ""; c3.Text = ""; c4.Text = "";
            d1.Text = ""; d2.Text = ""; d3.Text = ""; d4.Text = "";
            end.Text = "";

        }

       
    }
}
