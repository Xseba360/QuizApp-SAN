using System;
using System.Text;

namespace QuizApp.Cli
{
    internal static class Program
    {
        private static void Main( /*string[] args*/)
        {
            Console.OutputEncoding = Encoding.UTF8;
            /*if (args != null)
            {
                if (args.Length >= 1)
                {
                    switch (args[0])
                    {
                        case "quiz":
                            ShowQuiz();
                            break;
                        default:
                            ShowHelp();
                            break;
                            
                    }
                }
                else
                {
                    ShowHelp();
                }
            }
            else
            {
                ShowHelp();
            }*/
            ShowQuiz();
        }

        private static void ShowQuiz()
        {
            new QuizManagerCli().BeginQuiz(0);
        }

        /*private static void ShowHelp()
        {
            var currentExecutable = AppDomain.CurrentDomain.FriendlyName;
            Console.WriteLine($"Usage: {currentExecutable} <command>");
            Console.WriteLine("Commands:");
            Console.WriteLine("quiz \t- start the quiz");
            Console.WriteLine("help \t- display this");
        }*/
    }
}