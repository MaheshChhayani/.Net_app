using System;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Threading;
using System.Linq;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace project_final
{
    class Program
    { 
        static void Main(string[] args)
        {
            int flag = 0;
            int c = 0;
            int a ;
            int SelectMovie;
            int SelectAge;
            string SelectAge1;
            string mRating;
            
            string moviename;
            string moviePlaying = null;
            var valid = false;
            int y;
            


            string[] movieName=null;
            string[] movieRating=null;
            int[] movieRatingAge = Enumerable.Range(1,100).ToArray();
            string[] movieRatings = { "G", "PG", "PG-13", "R", "NC-17" };

            do {
                Console.WriteLine("\t *****************************************************");
                Console.WriteLine("\t ********* Welcome to MoviePlex Theatre **************");
                Console.WriteLine("\t *****************************************************");

                do
                {

                    Console.WriteLine("\n \n Please Select From The Following Opetions:");
                    Console.WriteLine("1: Administrator \n2: Guests");
                    Console.WriteLine("Selection:");
                    

                    if (int.TryParse(Console.ReadLine(), out a))
                    {
                        if (a == 1)
                        {
                            break;
                        }
                        else if (a == 2 && movieRating == null)
                        {
                            Console.WriteLine("There is no movie entered.");
                        }
                        else if (a == 2 && movieRating != null)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Please choose valid option.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Please enter integer value only");
                    }
                } while (a == 2 && movieRating == null || a != 1 || a != 2) ;
                    
              

                /* --------------------------admin------------------------ */

                if (a == 1)
                {
                    int count = 4;
                    string userInput = "C";
                    do
                    {
                        Console.WriteLine("Please Enter The Admin Password:");
                        string b = Console.ReadLine();

                        

                        if (b == "admin")
                        {
                            int z = 0;
                            Console.WriteLine("You have successfully loged in.");
                            do
                            {
                                while(!valid)
                                {
                                    Console.WriteLine("How many movies are playing today?: ");
                                    moviePlaying = Console.ReadLine();
                                
                                    valid = !string.IsNullOrWhiteSpace(moviePlaying) &&
                                        moviePlaying.All(c => c >= '0' && c <= '9');

                                    if (!valid)
                                        Console.WriteLine("Please enter only integer numbers.");
                                    else
                                    {
                                        break;
                                    }
                                }
                                

                                c = Convert.ToInt32(moviePlaying);


                                movieName = new string[c];
                                movieRating = new string[c];

                                int k = 1;
                                for (int i = 0; i < c; i++)
                                {
                                    do
                                    {
                                        Console.WriteLine("Please Enter The " + k + "st Movie's Name:");
                                        moviename = Console.ReadLine();
                                        if (moviename == "")
                                        {
                                            Console.WriteLine("Please enter movie name.");
                                        }
                                        else
                                        {
                                            movieName[i] = moviename;
                                        }
                                    } while (moviename == "");

                                    do
                                    {
                                        flag = 0;
                                        Console.WriteLine("Please Enter The Age Limit or Rating For The " + k + "st Movie: ");
                                        mRating = Console.ReadLine();
                                        
                                        if (mRating == "")
                                        {
                                            Console.WriteLine("Please enter some value in rating");
                                        }

                                        if (mRating.All(char.IsDigit))
                                        {
                                            y = Convert.ToInt32(mRating);
                                            if (!movieRatingAge.Contains(y))
                                            {
                                                Console.WriteLine("Please enter valid Age.");
                                                flag = 1;
                                            }
                                            else
                                            {
                                                if(y >= 17)
                                                {
                                                    movieRating[i] = "NC-17";
                                                }
                                                else if(y >= 15)
                                                {
                                                    movieRating[i] = "R";
                                                }
                                                else if(y >= 13)
                                                {
                                                    movieRating[i] = "PG-13";
                                                }
                                                else if(y >= 10)
                                                {
                                                    movieRating[i] = "PG";
                                                }
                                                else
                                                {
                                                    movieRating[i] = "G";
                                                }
                                            }
                                        }
                                        else
                                        {
                                            if(!movieRatings.Contains(mRating))
                                            {
                                                Console.WriteLine("Please enter valid rating for the movie.");
                                                flag = 1;
                                            }
                                            else
                                            {
                                                movieRating[i] = mRating;
                                            }
                                        }
                                    } while (mRating == "" || flag == 1 );



                               



                                    k++;
                                }

                                for (int j = 0; j < c; j++)
                                {
                                    Console.WriteLine("\n" + movieName[j] + " " + "{" + movieRating[j] + "}" + "\n");
                                }

                                do
                                {
                                    Console.WriteLine("Your Movies Playing Today Are Listed Above. Are you satisfied? (Y/N)?");
                                    string yesNo = Console.ReadLine();

                                    if (yesNo == "Y" || yesNo == "y")
                                    {
                                        z = 1;
                                    }
                                    else if (yesNo == "N" || yesNo == "n")
                                    {
                                        z = 0;
                                    }
                                    else if (yesNo != "Y" || yesNo != "y" || yesNo != "N" || yesNo != "n")
                                    {
                                        Console.WriteLine("Please choose valid option.");
                                        z = -1;
                                    }
                                } while (z == -1);

                            } while (z == 0);
                            flag = 1;
                        }
                        else
                        {
                            Console.WriteLine("You entered an invalid password.");
                            Console.WriteLine("You have {0} more attempts to enter the correct password Press enter to continue OR Press B to go back to the previous screen.", count);
                             userInput =  Console.ReadLine();
                            count--;
                        }
                    } while (count >= 0 && flag == 0 && userInput != "B" );
                }
                else if(a == 2)
                {
                    

                    for (int j = 0; j < c; j++)
                    {
                        Console.WriteLine("\t " + movieName[j] + "   {"+movieRating[j]+"} \n");
                    }

                    do
                    {
                        Console.WriteLine("Which Movie Would You Like To Watch: ");
                        SelectMovie = Convert.ToInt32(Console.ReadLine());

                        if (SelectMovie > c || SelectMovie < 0)
                        {
                            Console.WriteLine("Please enter valid slected option.");
                        }
                    } while (SelectMovie > c || SelectMovie < 0);

                    Console.WriteLine("Please Enter Your Age For Varification: ");
                    SelectAge = Convert.ToInt32(Console.ReadLine());

                    if(SelectAge >= 17)
                    {
                        SelectAge1 = "NC-17";
                    }
                    else if(SelectAge >=15)
                    {
                        SelectAge1 = "R";
                    }
                    else if(SelectAge >=13)
                    {
                        SelectAge1 = "PG-13";
                    }
                    else if(SelectAge >= 10)
                    {
                        SelectAge1 = "PG";
                    }
                    else
                    {
                        SelectAge1 = "G";
                    }

                    if(SelectAge1 != movieRating[SelectMovie-1])
                    {
                        Console.WriteLine("Your age is lower than the required age for this movie.");
                    }
                    else
                    {
                        Console.WriteLine("Enjoy the movie");
                    }
                }

            } while (flag == 1);
    }
    }
}
