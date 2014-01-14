using Google.Api.Ads.AdWords.Lib;
using Google.Api.Ads.AdWords.v201309;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace GoogleAdword
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            GoogleServices objServe = new GoogleServices();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Console.WriteLine("For Estimate Keyword Traffic service Enter 1");
            Console.WriteLine("For Targeting Idea service Enter 2");
            string opt = Console.ReadLine();
            if (opt == "1")
            {
                Console.WriteLine("Estimate Traffic Service , Please enter a word");
                string Words = Console.ReadLine();
                try
                {
                    objServe.RunEstimatorService(new AdWordsUser(), Words);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An exception Occured while running this code example.{0}",
                        ExampleUtilities.FormatException(ex));
                }
                //Console.ReadLine();
                Console.WriteLine("Press 'n' to exit.. and 'y' to continue..");
                string response = Console.ReadLine();
                if (response == "y")
                {
                    Main();
                }
                else
                {
                    System.Environment.Exit(0);
                }
            }
            else if (opt == "2")
            {
                Console.WriteLine("Target Idea Service , Please enter a word or you can enter multiple words saperated by comma (',')");
                string Words = Console.ReadLine();
                string[] arrWords = Words.Split(',');
                try
                {
                    objServe.RunTargetIdea(new AdWordsUser(), arrWords);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An exception Occured while running this code example.{0}",
                           ExampleUtilities.FormatException(ex));
                }
                //Console.ReadLine();
                Console.WriteLine("Press 'n' to exit.. and 'y' to continue..");
                string response = Console.ReadLine();
                if (response == "y")
                {
                    Main();
                }
                else
                {
                    System.Environment.Exit(0);
                }
            }
            else
            {
                Console.WriteLine("Invalid Selection..!");
                Main();
                Console.ReadLine();
            }


        }
    }
}
