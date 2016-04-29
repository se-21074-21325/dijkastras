using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace djkstras_console
{
            class Program
            {

                public static double minimumlist(List<double>val) // minimum from list
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

                    for (int a = 0; a <arr.Length; a++)
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
                    for (int i = 0; i <patharray.Length; i++)
                    {
                        patharray[i] = patharray[i] + connected;
                    }
                    return patharray;
                }
                






                static void Main(string[] args)
                {
                   
                    // ---------------------------------------- path A ----------- start point where you are standing now ----------------------------

                   
                    double[] shortestA = new double[10];  // shortest path container at every instance of point

                    double destA = 2;  // starting point

                    double[] array = { 2 , 5 , 4 ,9  }; 

                   double[] pathA = sumpath(array,destA); // acknowledging paths of A
                   List<double> list = new List<double>(pathA);

                   double mini = minimum(pathA); // finding minimum path from A
                   shortestA[0] = mini; // added minimum path to short path array
                   list.Remove(shortestA[0]);

                   

                   // ---------------------------------------- path B ---------------------------------------

                   double destB = shortestA[0];  // starting point

                   double[] arrayB = { 3, 7, 9 ,2};

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

                         double[] arrayC = { 4, 2, 3 ,6};

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

                         double[] arrayD = { 7, 3, 12,5 };

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

                             double E = 4;

                             double currentshort = E+destE;



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

                         

                        
                         


                       
                        





             Console.Write("Shortest path  : " + shortestA[0] + "-" + shortestA[1] + "-" + shortestA[2] + "-" + shortestA[3] + "-" + shortestA[4]);






                 //  for (int i = 1; i < Alngremain_b.Length; i++)
                //   {
                //       Console.WriteLine(Alngremain_b[i]);
                //   }


                   Console.ReadKey();


          
                }





            }
}
