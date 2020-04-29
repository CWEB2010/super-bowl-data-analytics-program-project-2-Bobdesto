using System;
using System.Collections.Generic;
using System.IO;

namespace Project_Two
{
    class Program
    {
        static void Main(string[] args)
        {
            /**Your application should allow the end user to pass end a file path for output 
            * or guide them through generating the file.
            **/
            //DECLARATIONS
            const string PATH = @"C:\CWEB 2010\Project2.1\Super_Bowl_Project.csv";


            //FileStream input;
            //StreamReader read;
            string line;
            string[] data;
            List<Prospective_Player> prospectList = null; //generating a list of superbowl winners

            //Implementation of try catch error method 
            try
            {
                FileStream input = new FileStream(PATH, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                StreamReader read = new StreamReader(input);
                line = read.ReadLine(); // Priming input
                prospectList = new List<Prospective_Player>();

                //Implementation of looping structure to read through the records
                while (!read.EndOfStream)
                {

                    //Reading records and creating object instances at the same time.
                    data = read.ReadLine().Split(',');
                    prospectList.Add(new Prospective_Player(data[0], Convert.ToInt32(data[1]), data[2], data[3], data[4], Convert.ToDouble(data[5])));//Adding objects to the end of the list, using ToDouble to convert number to a double floating point.
                    Console.WriteLine(prospectList[prospectList.Count - 1]);// Writing and getting the number of elements contained in the list

                }

                read.Dispose();
                input.Dispose();


            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            //Writing to file

            FileStream output = new FileStream(PATH, FileMode.OpenOrCreate, FileAccess.ReadWrite);// Initializing a new instance of the file with read and write permision.
            StreamWriter write = new StreamWriter(output);
            write.WriteLine("Team name, Year team won, Winning Quaterback, Winning Coach, The MVP, Pt difference between winning and losing team");
            //Creating a for each loop 
            foreach (Prospective_Player y in prospectList)
            {
                //Writing out the record
                write.WriteLine($"{y.TeamName}, {y.YearTeamWon}, {y.WinningQuarterBack}, {y.WinningCoach}, {y.TheMVP}, {y.PtDifferenceBetweenWinningAndLosingTeam}");
                

            }

            write.Dispose(); //
            output.Dispose();//



        }
    }

    //Creating a class object for Prospective_Player used in the foreach loop
    class Prospective_Player
    {
        private string v1;
        private int v2;

        //Using the getter and setter method.

        public string TeamName { get; set; }
        public int YearTeamWon { get; set; }
        public string WinningQuarterBack{ get; set; }
        public string WinningCoach { get; set; }
        public string TheMVP { get; set; }
        public double PtDifferenceBetweenWinningAndLosingTeam { get; set; }

        public  Prospective_Player(string teamName, int yearTeamWon, string winningQuarterBack, string winningCoach, string theMVP, double ptDifferenceBetweenWinningAndLosingTeam)
        {
            TeamName = teamName;
            YearTeamWon = yearTeamWon;
            WinningQuarterBack = winningQuarterBack;
            WinningCoach = winningCoach;
            TheMVP = theMVP;
            PtDifferenceBetweenWinningAndLosingTeam = ptDifferenceBetweenWinningAndLosingTeam;
        }

      
    }
}
